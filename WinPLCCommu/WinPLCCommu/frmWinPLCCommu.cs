#region Header
///----------------------------------------------------------------------------------------------------
///
/// FILE NAME: frmWinPLCCommu.cs
///
///	DESCRIPTION:
///	
///    History
///	***********************************************************************************************
///     Date            Editor      Version         Description
///	***********************************************************************************************
///     2017.09.09      Kuei       v1.0.0.9         改變字幕機顯示時機
///     2017.09.18      Kuei       v1.0.0.11        新增周邊異常時顯示字幕機
///     2017.09.20      Kuei       v1.0.0.12        修改周邊異常顯示清除時機
///     2017.09.21      Kuei       v1.0.0.13        修改讀入Buffer資料效能(for->Parallel.For)
///     2017.10.30      Kuei       v1.0.0.15        新增EQUCMD時Where條件 CMDSTS小於3
///     2017.11.03      Kuei       v1.0.0.16        新增入庫時若Loc不足7碼就Continue
///     2017.11.03      Kuei       v1.0.0.17        將入出庫部分異常時return改為Continue
///     2017.11.14      Kuei       v1.0.0.18        1.Fix 發生空出庫時，更新Cmd_Mst
///                                                 2.Fix 地上盤強制取消時，Update Cmd_Sts = 8,Cmd_Abnormal ='EF'
///                                                 
///     2018.01.17      Kuei       v1.0.0.19        新增盤點入庫條件IO_TYPE=63  frmWinPLCCommu_funStockIn.cs--->v1.02
///     2018.01.18      Kuei       v1.0.0.20        Fix 產生庫對庫IOTYPE一律是51
///                                                 Fix 產生庫對庫Trn_Qty=0
///                                                 Fix 出庫卡其他Crane問題
///     2018.01.18      Kuei       v1.0.0.21        新增Log 自動產生庫對庫 Begin失敗Log
///     2018.01.22      Kuei       v1.0.0.22        1.Fix:移除產生庫對庫時，寫CMD_DTL
///                                                 2.Fix 產生庫對庫時間改為24小時制
///     2018.01.23      Kuei       v1.0.0.23        1.Add 新增預約Loc_Mst 寫入Trn_Date和MEMO='WCS'
///                                                 2.Add 新增全部Begin Fail寫Log
///     2018.01.23      Kuei       v1.0.0.24        1.Fix 顯示字幕機3F以上不顯示BUG
///     2018.01.23      Kuei       v1.0.0.25        Fix Bug 新增更新Loc_Mst判斷條件 Loc_Sts='N'
///     2018.01.24      Kuei       v1.0.0.26        Fix移除v1.0.0.17修改
///     2018.01.29      Kuei       v1.0.1.0         修改入庫時預約儲位時機，並預約儲位同時更新Trace=12
///     2018.02.08      Kuei       v1.0.1.1         Fix 新增Cmd_Mst Plt_Count加入單引號
///     2018.04.19      Kuei       v1.0.1.2         1.Fix Begin 時 不可再重複Begin或Select     
///                                                 2.新增DB PLC重新連線
///     2018.05.15      Kuei       v1.0.1.4         1.Fix DB Lock
///                                                 2.Fix 當外儲位與內儲位同時被出庫預約的情況
///     2018.05.24      Kuei       v1.0.1.5         Update frmWinPLCCommu_funStockIn.cs v1.03
///     2018.05.24      Kuei       v1.0.1.6         Update frmWinPLCCommu_funStockIn.cs v1.04
///     2018.07.19      Julia      v1.0.1.7         Fix 當外儲位與內儲位同時被出庫預約的情況, 應包含 cmd_mode in ('3','2')
///     2018.11.16      Julia      v1.0.1.8         找儲位條件,找 HNNH. (柱位的儲位,內儲位也要可以被找到)
///     2018.12.07      Julia      v1.0.1.9         自動庫對庫的時候....找儲位條件,找 HNNH. (柱位的儲位,內儲位也要可以被找到)
///     2019.01.03      Julia      v1.0.2.0         當庫位滿的時候, 要找暫存儲位.(storage_type='T')
/// 
/// 
///----------------------------------------------------------------------------------------------------
///         
///
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mirle.Library;

namespace Mirle.WinPLCCommu
{
    public partial class frmWinPLCCommu : Form
    {
        private delegate void delShowSystemTrace(ListBox TraceListBox, clsTraceLogEventArgs TraceLog, bool WriteLog);
        private clsTraceLogEventArgs strLastSystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
        private clsTraceLogEventArgs strLastMPLCTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);

        private Dictionary<int, Control> dicBufferMap = new Dictionary<int, Control>();
        private List<clsStnDef> lstInModeStnDef = new List<clsStnDef>();
        private List<clsStnDef> lstOutModeStnDef = new List<clsStnDef>();
        private List<string> lstStn = new List<string>();
        private List<string> lstStn_WT = new List<string>();
        private clsBufferData objBufferData = new clsBufferData();
        private clsBCRData objBCRData = new clsBCRData();
        private clsWTData objWTData = new clsWTData();
        private Timer timRefresh = new Timer();
        private System.Timers.Timer timProgram = new System.Timers.Timer();
        private System.Timers.Timer timProgram_2 = new System.Timers.Timer();
        private System.Timers.Timer timProgram_3 = new System.Timers.Timer();
        private bool bolClose = false;
        private bool bolAutoPaseFlag = true;
        // 臨時記帳程式，略過讀BCR區段 By Leon
        private bool bolPassReadBCR = true;

        private frmPLCModify PLCModify = null;
        private frmEquCmd EquCmd = null;
        private frmBufferInfo BufferInfo = null;

        #region 建構函式
        /// <summary>
        /// 初始化 Mirle.WinPLCCommu.frmWinPLCCommu 類別的新執行個體
        /// </summary>
        public frmWinPLCCommu()
        {
            InitializeComponent();
        }
        #endregion 建構函式

        #region 事件
        /// <summary>
        /// 表示 frmWinPLCCommu 觸發 Load 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWinPLCCommu_Load(object sender, EventArgs e)
        {
            this.Text = "Mirle AS/RS System Communication" + " (V." + Application.ProductVersion + ")";
            btnAutoPause.Text = "Pause";
            bolAutoPaseFlag = true;

            //chkAutoRunA01.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunA02.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunA03.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunD04ToRM1.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunD04ToRM2.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunD04ToRM3.Enabled = chkAutoRunTest.Checked;

            funInitCraneStsLayout();
            funInitBuffer(); 
            funInitTimer();
            //內容已被註解完，無用 By Leon
            //SubObjectInit();
            objBufferData.AlarmData += new clsBufferData.delAlarmEventHandler(objBufferData_AlarmData);
            uclBuffer.uclBufferClick += new EventHandler(uclBuffer_uclBufferClick);
            objBufferData.wcsAlarmData += new clsBufferData.wcsAlarmEventHandler(objBufferData_wcsAlarmData);
        }

        /// <summary>
        /// 表示 frmWinPLCCommu 觸發 FormClosing 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWinPLCCommu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !bolClose;
        }

        /// <summary>
        ///  表示PLC1 timRefresh 觸發 Tick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timProgram_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timProgram.Stop();
            timProgram.Enabled = false;
            try
            {
                if(chkAutoReconnect.Checked)
                {
                    if(!clsSystem.gobjPLC.ConnectionFlag)
                        funReconnectionPLC(0);
                    if(!clsSystem.gobjDB.ConnFlag)
                        funReconnectionDB();
                }
                
                if(clsSystem.gobjPLC.ConnectionFlag && bolAutoPaseFlag)
                {
                    #region Read PLC Data To Buffer/UI
                    objBufferData.funReadPC2PLCData2Buffer(1);
                    if(objBufferData.funReadPLC2PCDataBuffer(1))
                    {
                        #region Read Success
                        //v1.0.0.13
                        Parallel.For(0, objBufferData.PLC2PCBuffer.Length, intItem =>
                            {
                                if (dicBufferMap.ContainsKey(intItem))
                                {
                                    uclBuffer BufferControl = (uclBuffer)dicBufferMap[intItem];
                                    BufferControl.StnMode = clsTool.funGetEnumValue<uclBuffer.enuStnMode>(objBufferData.PLC2PCBuffer[intItem].StnMode);
                                    // = clsTool.funGetEnumValue<uclBuffer.enuCmdMode>(objBufferData.PLC2PCBuffer[intItem].CmdMode);
                                    BufferControl.LeftCmdSno = objBufferData.PLC2PCBuffer[intItem].LeftCmdSno;
                                    BufferControl.StnChange = clsTool.funGetEnumValue<uclBuffer.enuStnChange>(((int)objBufferData.PLC2PCBuffer[intItem].StnChange).ToString());
                                    BufferControl.Ready = clsTool.funGetEnumValue<uclBuffer.enuReady>(((int)objBufferData.PLC2PCBuffer[intItem].Ready).ToString());
                                    BufferControl.ReadNotice =
                                        clsTool.funGetEnumValue<uclBuffer.enuReadNotice>(((int)objBufferData.PLC2PCBuffer[intItem].ReadNotice).ToString());
                                    BufferControl.FunNotice = objBufferData.PLC2PCBuffer[intItem].StnModeCode_PalletLoad;
                                    BufferControl.Error = objBufferData.PLC2PCBuffer[intItem].Error.ToString();
                                    BufferControl.CargoLoad = objBufferData.PLC2PCBuffer[intItem].StnModeCode_CargoLoad;
                                    //BufferControl.RightLoad = objBufferData.PLC2PCBuffer[intItem].StnModeCode_RightLoad;
                                    BufferControl.PalletNo = clsTool.funGetEnumValue<uclBuffer.enuPalletNo>(((int)objBufferData.PLC2PCBuffer[intItem].Avail).ToString());
                                    BufferControl.Auto = objBufferData.PLC2PCBuffer[intItem].StnModeCode_Auto;
                                    BufferControl.Manual = objBufferData.PLC2PCBuffer[intItem].StnModeCode_Manual;
                                    //v1.0.0.9決定顯示字幕機的時機
                                    int iBuffer_IN_Out = intItem % 2;//等於1為外Buffer，等於0為內Buffer
                                    if (objBufferData.PLC2PCBuffer[intItem].StnModeCode_In && iBuffer_IN_Out == 1 &&
                                        !string.IsNullOrEmpty(objBufferData.PLC2PCBuffer[intItem].LeftCmdSno))
                                    {
                                        if (objBufferData.PLC2PCBuffer[intItem].StnModeCode_CargoLoad)
                                        {
                                            //內Buffer有序號時顯示於字幕機                                     
                                            funMvsData(BufferControl.BufferName, objBufferData.PLC2PCBuffer[intItem].LeftCmdSno, "1", "1", "", true);
                                        }
                                        else if (objBufferData.PLC2PCBuffer[intItem].Error == 0)
                                        {
                                            funMvsData(BufferControl.BufferName, "", "3", "1", "", true);
                                        }
                                    }
                                    else if (objBufferData.PLC2PCBuffer[intItem].StnModeCode_Out && iBuffer_IN_Out == 0 &&
                                        !string.IsNullOrEmpty(objBufferData.PLC2PCBuffer[intItem].LeftCmdSno))
                                    {
                                        if (objBufferData.PLC2PCBuffer[intItem].StnModeCode_CargoLoad)
                                        {
                                            //外Buffer有序號時顯示於字幕機
                                            funMvsData(BufferControl.BufferName, objBufferData.PLC2PCBuffer[intItem].LeftCmdSno, "1", "1", "", true);
                                        }
                                        else if (objBufferData.PLC2PCBuffer[intItem].Error == 0)
                                        {
                                            funMvsData(BufferControl.BufferName, "", "3", "1", "", true);
                                        }
                                    }
                                    else if (!objBufferData.PLC2PCBuffer[intItem].StnModeCode_CargoLoad)
                                    {
                                    }
                                    if (objBufferData.PLC2PCBuffer[intItem].Error > 0)
                                    {
                                        if (intItem % 2 == 0)
                                        {
                                           

                                            string strAlarmMsg = funAlarmLog(intItem, objBufferData.PLC2PCBuffer[intItem].Error);
                                            if (objBufferData.PLC2PCBuffer[intItem + 1].Error > 0)
                                            {
                                                strAlarmMsg += funAlarmLog(intItem + 1, objBufferData.PLC2PCBuffer[intItem + 1].Error);
                                            }

                                            //v1.0.0.11 異常時
                                            string strStnNo = string.Empty;
                                            switch (strAlarmMsg.Substring(0, 1))
                                            {
                                                case "A":
                                                    strStnNo = "A10" + strAlarmMsg.Substring(4, 1);
                                                    break;
                                                case "B":
                                                    strStnNo = "B20" + strAlarmMsg.Substring(4, 1);
                                                    break;
                                                case "C":
                                                    strStnNo = "C30" + strAlarmMsg.Substring(4, 1);
                                                    break;
                                                case "D":
                                                    strStnNo = "D40" + strAlarmMsg.Substring(4, 1);
                                                    break;
                                                case "E":
                                                    strStnNo = "E50" + strAlarmMsg.Substring(4, 1);
                                                    break;
                                                case "F":
                                                    strStnNo = "F60" + strAlarmMsg.Substring(4, 1);
                                                    break;
                                                case "G":
                                                    strStnNo = "G70" + strAlarmMsg.Substring(4, 1);
                                                    break;
                                            }
                                            string strSQL = "Update MVS_MST SET Dsp_Flag='1',Error_Flag = '1',Error_Msg ='" + strAlarmMsg + "' Where Stn_No ='" + strStnNo + "'";
                                            string strEM = string.Empty;
                                            if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == 0)
                                            {
                                            }
                                        }
                                    }
                                    else if (objBufferData.PLC2PCBuffer[intItem].Error == 0)
                                    {
                                        //v1.0.0.12
                                        if (intItem % 2 == 0)
                                        {
                                            string strAlarmMsg = string.Empty;
                                            if (objBufferData.PLC2PCBuffer[intItem + 1].Error > 0)
                                            {
                                                strAlarmMsg += funAlarmLog(intItem + 1, objBufferData.PLC2PCBuffer[intItem + 1].Error);
                                                //v1.0.0.11 異常時
                                                string strStnNo = string.Empty;
                                                switch (strAlarmMsg.Substring(0, 1))
                                                {
                                                    case "A":
                                                        strStnNo = "A10" + strAlarmMsg.Substring(4, 1);
                                                        break;
                                                    case "B":
                                                        strStnNo = "B20" + strAlarmMsg.Substring(4, 1);
                                                        break;
                                                    case "C":
                                                        strStnNo = "C30" + strAlarmMsg.Substring(4, 1);
                                                        break;
                                                    case "D":
                                                        strStnNo = "D40" + strAlarmMsg.Substring(4, 1);
                                                        break;
                                                    case "E":
                                                        strStnNo = "E50" + strAlarmMsg.Substring(4, 1);
                                                        break;
                                                    case "F":
                                                        strStnNo = "F60" + strAlarmMsg.Substring(4, 1);
                                                        break;
                                                    case "G":
                                                        strStnNo = "G70" + strAlarmMsg.Substring(4, 1);
                                                        break;
                                                }
                                                string strSQL = "Update MVS_MST SET Dsp_Flag='1',Error_Flag = '1',Error_Msg ='" + strAlarmMsg + "' Where Stn_No ='" + strStnNo + "'";
                                                string strEM = string.Empty;
                                                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == 0)
                                                {
                                                }

                                            }
                                            else if (objBufferData.PLC2PCBuffer[intItem + 1].Error == 0 &&
                                            string.IsNullOrEmpty(objBufferData.PLC2PCBuffer[intItem].LeftCmdSno)
                                                &&
                                            string.IsNullOrEmpty(objBufferData.PLC2PCBuffer[intItem + 1].LeftCmdSno))
                                            {
                                                string strBufferName = objBufferData.PLC2PCBuffer[intItem + 1].AlarmSignal[1].BufferName;
                                                string strStnNo = string.Empty;
                                                switch (strBufferName.Substring(0, 1))
                                                {
                                                    case "A":
                                                        strStnNo = "A10" + strBufferName.Substring(4, 1);
                                                        break;
                                                    case "B":
                                                        strStnNo = "B20" + strBufferName.Substring(4, 1);
                                                        break;
                                                    case "C":
                                                        strStnNo = "C30" + strBufferName.Substring(4, 1);
                                                        break;
                                                    case "D":
                                                        strStnNo = "D40" + strBufferName.Substring(4, 1);
                                                        break;
                                                    case "E":
                                                        strStnNo = "E50" + strBufferName.Substring(4, 1);
                                                        break;
                                                    case "F":
                                                        strStnNo = "F60" + strBufferName.Substring(4, 1);
                                                        break;
                                                    case "G":
                                                        strStnNo = "G70" + strBufferName.Substring(4, 1);
                                                        break;
                                                } 
                                                string strSQL = "Update MVS_MST SET Dsp_Flag='1',Error_Flag = '1',Error_Msg ='' Where Stn_No ='" + strStnNo + "'";
                                                string strEM = string.Empty;
                                                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == 0)
                                                {
                                                }
                                            }
                                        }
                                    }
                                }
                            });
                        //for(int intItem = 0; intItem < objBufferData.PLC2PCBuffer.Length; intItem++)
                        //{
                            
                        //}
                        #endregion Read Success
                    }
                    else
                    {
                        #region Read Fail
                        foreach(Control objControl in dicBufferMap.Values)
                            ((uclBuffer)objControl).funReadPLCError();
                        #endregion Read Fail
                    }
                    #endregion Read PLC Data To Buffer/UI

                    #region Stock In/Out
                    
                    funStockIn(1);
                    funStockOut();
                    funLocToLoc();
                    //funAutoMoveLoc();
                    #endregion Stock In/Out

                    #region AutoRun---已註解

                    #region 撿料模式
                    //if(chkAutoRunA01.Checked)
                    //    funAutoRunTest1(1);
                    //if(chkAutoRunA02.Checked)
                    //    funAutoRunTest1(2);
                    //if(chkAutoRunA03.Checked)
                    //    funAutoRunTest1(3);
                    //if(chkAutoRunD04ToRM1.Checked)
                    //    funAutoRunTest1(4);
                    //if(chkAutoRunD04ToRM2.Checked)
                    //    funAutoRunTest1(5);
                    //if(chkAutoRunD04ToRM3.Checked)
                    //    funAutoRunTest1(6);
                    #endregion 撿料模式

                    #region 庫對庫模式
                    //if(chkAutoRunRM1.Checked)
                    //    funAutoRunTest2(1);
                    //if(chkAutoRunRM2.Checked)
                    //    funAutoRunTest2(2);
                    //if(chkAutoRunRM3.Checked)
                    //    funAutoRunTest2(3);
                    #endregion 庫對庫模式

                    #endregion AutoRun
                }
                else
                {
                    #region Read Fail
                    //foreach(Control objControl in dicBufferMap.Values)
                    //    ((uclBuffer)objControl).funReadPLCError();
                    #endregion Read Fail
                }
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                timProgram.Start();
                timProgram.Enabled = true;
            }
        }

        /// <summary>
        ///  表示PLC2 timRefresh 觸發 Tick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timProgram_2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timProgram_2.Stop();

            try
            {
                if (chkAutoReconnect.Checked)
                {
                    if (!clsSystem.gobjPLC2.ConnectionFlag)
                        funReconnectionPLC(2);
                    //if (!clsSystem.gobjDB.ConnFlag)
                    //    funReconnectionDB();
                }

                if (clsSystem.gobjPLC2.ConnectionFlag && bolAutoPaseFlag)
                {
                    #region Read PLC Data To Buffer/UI
                    objBufferData.funReadPC2PLCData2Buffer(2);
                    if (objBufferData.funReadPLC2PCDataBuffer(2))
                    {
                        #region Read Success
                        for (int intItem = 0; intItem < objBufferData.PLC2PCBuffer.Length; intItem++)
                        {
                            if (dicBufferMap.ContainsKey(intItem))
                            {
                                uclBuffer BufferControl = (uclBuffer)dicBufferMap[intItem];
                                BufferControl.StnMode = clsTool.funGetEnumValue<uclBuffer.enuStnMode>(objBufferData.PLC2PCBuffer[intItem].StnMode);
                                //BufferControl.CmdMode = clsTool.funGetEnumValue<uclBuffer.enuCmdMode>(objBufferData.PLC2PCBuffer[intItem].CmdMode);
                                BufferControl.LeftCmdSno = objBufferData.PLC2PCBuffer[intItem].LeftCmdSno;
                                BufferControl.StnChange = clsTool.funGetEnumValue<uclBuffer.enuStnChange>(((int)objBufferData.PLC2PCBuffer[intItem].StnChange).ToString());
                                BufferControl.Ready = clsTool.funGetEnumValue<uclBuffer.enuReady>(((int)objBufferData.PLC2PCBuffer[intItem].Ready).ToString());
                                BufferControl.ReadNotice =
                                    clsTool.funGetEnumValue<uclBuffer.enuReadNotice>(((int)objBufferData.PLC2PCBuffer[intItem].ReadNotice).ToString());
                                BufferControl.FunNotice = BufferControl.FunNotice = objBufferData.PLC2PCBuffer[intItem].StnModeCode_PalletLoad;
                                BufferControl.Error = objBufferData.PLC2PCBuffer[intItem].Error.ToString();
                                BufferControl.CargoLoad = objBufferData.PLC2PCBuffer[intItem].StnModeCode_CargoLoad;
                                //BufferControl.RightLoad = objBufferData.PLC2PCBuffer[intItem].StnModeCode_RightLoad;
                                BufferControl.PalletNo = clsTool.funGetEnumValue<uclBuffer.enuPalletNo>(((int)objBufferData.PLC2PCBuffer[intItem].Avail).ToString());
                                BufferControl.Auto = objBufferData.PLC2PCBuffer[intItem].StnModeCode_Auto;
                                BufferControl.Manual = objBufferData.PLC2PCBuffer[intItem].StnModeCode_Manual;
                            }
                        }
                        #endregion Read Success
                    }
                    else
                    {
                        #region Read Fail
                        foreach (Control objControl in dicBufferMap.Values)
                            ((uclBuffer)objControl).funReadPLCError();
                        #endregion Read Fail
                    }
                    #endregion Read PLC Data To Buffer/UI

                    #region Stock In/Out
                    funStockIn(2);
                    funStockOut();
                    funLocToLoc();
                    //funAutoMoveLoc();
                    #endregion Stock In/Out

                    #region AutoRun

                    #region 撿料模式--註解
                    //if (chkAutoRunA01.Checked)
                    //    funAutoRunTest1(1);
                    //if (chkAutoRunA02.Checked)
                    //    funAutoRunTest1(2);
                    //if (chkAutoRunA03.Checked)
                    //    funAutoRunTest1(3);
                    //if (chkAutoRunD04ToRM1.Checked)
                    //    funAutoRunTest1(4);
                    //if (chkAutoRunD04ToRM2.Checked)
                    //    funAutoRunTest1(5);
                    //if (chkAutoRunD04ToRM3.Checked)
                    //    funAutoRunTest1(6);
                    #endregion 撿料模式

                    #region 庫對庫模式--註解
                    //if (chkAutoRunRM1.Checked)
                    //    funAutoRunTest2(1);
                    //if (chkAutoRunRM2.Checked)
                    //    funAutoRunTest2(2);
                    //if (chkAutoRunRM3.Checked)
                    //    funAutoRunTest2(3);
                    #endregion 庫對庫模式

                    #endregion AutoRun
                }
                else
                {
                    #region Read Fail---先註解 若一個PLC讀不到 會有閃爍的情況
                    //foreach (Control objControl in dicBufferMap.Values)
                    //    ((uclBuffer)objControl).funReadPLCError();
                    #endregion Read Fail
                }
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                timProgram_2.Start();
            }
        }

        /// <summary>
        ///  表示PLC3 timRefresh 觸發 Tick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timProgram_3_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timProgram_3.Stop();

            try
            {
                if (chkAutoReconnect.Checked)
                {
                    if (!clsSystem.gobjPLC3.ConnectionFlag)
                        funReconnectionPLC(3);
                    //if (!clsSystem.gobjDB.ConnFlag)
                    //    funReconnectionDB();
                }

                if (clsSystem.gobjPLC3.ConnectionFlag && bolAutoPaseFlag)
                {
                    #region Read PLC Data To Buffer/UI
                    objBufferData.funReadPC2PLCData2Buffer(3);
                    if (objBufferData.funReadPLC2PCDataBuffer(3))
                    {
                        #region Read Success
                        for (int intItem = 0; intItem < objBufferData.PLC2PCBuffer.Length; intItem++)
                        {
                            if (dicBufferMap.ContainsKey(intItem))
                            {
                                uclBuffer BufferControl = (uclBuffer)dicBufferMap[intItem];
                                BufferControl.StnMode = clsTool.funGetEnumValue<uclBuffer.enuStnMode>(objBufferData.PLC2PCBuffer[intItem].StnMode);
                                //BufferControl.CmdMode = clsTool.funGetEnumValue<uclBuffer.enuCmdMode>(objBufferData.PLC2PCBuffer[intItem].CmdMode);
                                BufferControl.LeftCmdSno = objBufferData.PLC2PCBuffer[intItem].LeftCmdSno;
                                BufferControl.StnChange = clsTool.funGetEnumValue<uclBuffer.enuStnChange>(((int)objBufferData.PLC2PCBuffer[intItem].StnChange).ToString());
                                BufferControl.Ready = clsTool.funGetEnumValue<uclBuffer.enuReady>(((int)objBufferData.PLC2PCBuffer[intItem].Ready).ToString());
                                BufferControl.ReadNotice =
                                    clsTool.funGetEnumValue<uclBuffer.enuReadNotice>(((int)objBufferData.PLC2PCBuffer[intItem].ReadNotice).ToString());
                                BufferControl.FunNotice = BufferControl.FunNotice = objBufferData.PLC2PCBuffer[intItem].StnModeCode_PalletLoad;
                                BufferControl.Error = objBufferData.PLC2PCBuffer[intItem].Error.ToString();
                                BufferControl.CargoLoad = objBufferData.PLC2PCBuffer[intItem].StnModeCode_CargoLoad;
                                //BufferControl.RightLoad = objBufferData.PLC2PCBuffer[intItem].StnModeCode_RightLoad;
                                BufferControl.PalletNo = clsTool.funGetEnumValue<uclBuffer.enuPalletNo>(((int)objBufferData.PLC2PCBuffer[intItem].Avail).ToString());
                                BufferControl.Auto = objBufferData.PLC2PCBuffer[intItem].StnModeCode_Auto;
                                BufferControl.Manual = objBufferData.PLC2PCBuffer[intItem].StnModeCode_Manual;                           
                            }
                        }
                        #endregion Read Success
                    }
                    else
                    {
                        #region Read Fail
                        foreach (Control objControl in dicBufferMap.Values)
                            ((uclBuffer)objControl).funReadPLCError();
                        #endregion Read Fail
                    }
                    #endregion Read PLC Data To Buffer/UI

                    #region Stock In/Out
                    funStockIn(3);
                    funStockOut();
                    funLocToLoc();
                    //funAutoMoveLoc();
                    #endregion Stock In/Out

                    #region AutoRun

                    #region 撿料模式--註解
                    //if (chkAutoRunA01.Checked)
                    //    funAutoRunTest1(1);
                    //if (chkAutoRunA02.Checked)
                    //    funAutoRunTest1(2);
                    //if (chkAutoRunA03.Checked)
                    //    funAutoRunTest1(3);
                    //if (chkAutoRunD04ToRM1.Checked)
                    //    funAutoRunTest1(4);
                    //if (chkAutoRunD04ToRM2.Checked)
                    //    funAutoRunTest1(5);
                    //if (chkAutoRunD04ToRM3.Checked)
                    //    funAutoRunTest1(6);
                    #endregion 撿料模式

                    #region 庫對庫模式--註解
                    //if (chkAutoRunRM1.Checked)
                    //    funAutoRunTest2(1);
                    //if (chkAutoRunRM2.Checked)
                    //    funAutoRunTest2(2);
                    //if (chkAutoRunRM3.Checked)
                    //    funAutoRunTest2(3);
                    #endregion 庫對庫模式

                    #endregion AutoRun
                }
                else
                {
                    #region Read Fail---先註解 若一個PLC讀不到 會有閃爍的情況
                    //foreach (Control objControl in dicBufferMap.Values)
                    //    ((uclBuffer)objControl).funReadPLCError();
                    #endregion Read Fail
                }
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                timProgram_3.Start();
            }
        }


        /// <summary>
        /// 表示 timRefresh 觸發 Tick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timRefresh_Tick(object sender, EventArgs e)
        {
            timRefresh.Stop();

            try
            {
                lblDateTime.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff");

                #region DB、PLC連線狀態
                funShowConnect(clsSystem.gobjDB.ConnFlag, ref lblDBSts);
                funShowConnect(clsSystem.gobjPLC.ConnectionFlag, ref lblMPLC1Sts);
                funShowConnect(clsSystem.gobjPLC2.ConnectionFlag, ref lblMPLC2Sts);
                funShowConnect(clsSystem.gobjPLC3.ConnectionFlag, ref lblMPLC3Sts);
                #endregion DB、PLC連線狀態
                //if (clsSystem.gobjPLC.ConnectionFlag)
                //{
                //    if (!timProgram.Enabled)
                //        timProgram.Start();
                //}
                //else
                //{
                //    timProgram.Stop();
                //}
                //if (clsSystem.gobjPLC2.ConnectionFlag)
                //{
                //    if(!timProgram_2.Enabled)
                //        timProgram_2.Start();
                //}
                //else
                //{
                //    timProgram_2.Stop();
                //}
                //if (clsSystem.gobjPLC3.ConnectionFlag)
                //{
                //    if (!timProgram_3.Enabled)
                //        timProgram_3.Start();
                //}
                //else
                //{
                //    timProgram_3.Stop();
                //}
                #region  更新Crane Mode/Sts
                if (clsSystem.intBegin == 0)
                {
                    funReadCraneMode();
                    funReadCraneSts();
                }
                #endregion  更新Crane Mode/Sts

                #region Auto Reconnect
                if(!chkAutoReconnect.Checked)
                {
                    btnReconnectDB.Enabled = !clsSystem.gobjDB.ConnFlag;
                    btnReconnectPLC.Enabled = !clsSystem.gobjPLC.ConnectionFlag;
                }
                #endregion Auto Reconnect

                #region WriteAutoRun--註解
                //funWriteAutoRunBit("A01", chkAutoRunTest.Checked);
                //funWriteAutoRunBit("A02", chkAutoRunTest.Checked);
                //funWriteAutoRunBit("A03", chkAutoRunTest.Checked);
                //funWriteAutoRunBit("D04", chkAutoRunTest.Checked);
                #endregion WriteAutoRun

                #region HandShaking & Set PLC DateTime
                if(clsSystem.gobjPLC.ConnectionFlag)
                {
                    if(!objBufferData.HandShaking)
                        funWritePC2PLC_HandShake("1",1);
                    else
                        funWritePC2PLC_HandShake("0",1);

                    funWritePLCSetDateTime(1);
                }
                if (clsSystem.gobjPLC2.ConnectionFlag)
                {
                    if (!objBufferData.HandShaking)
                        funWritePC2PLC_HandShake("1", 2);
                    else
                        funWritePC2PLC_HandShake("0", 2);

                    funWritePLCSetDateTime(2);
                }
                if (clsSystem.gobjPLC3.ConnectionFlag)
                {
                    if (!objBufferData.HandShaking)
                        funWritePC2PLC_HandShake("1", 3);
                    else
                        funWritePC2PLC_HandShake("0", 3);

                    funWritePLCSetDateTime(3);
                }
                #endregion HandShaking & Set PLC DateTime

                #region 檢查是否有做完的命令並Update字幕機Table

                

                #endregion 檢查是否有做完的命令並Update字幕機Table

                #region Release 暫存儲位

                #endregion Release 暫存儲位

                #region 站對站
                funStnToStn();
                #endregion 站對站
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                timRefresh.Start();
            }
        }

        private void chkAutoRunTest_CheckedChanged(object sender, EventArgs e)
        {
            //chkAutoRunA01.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunA02.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunA03.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunD04ToRM1.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunD04ToRM2.Enabled = chkAutoRunTest.Checked;
            //chkAutoRunD04ToRM3.Enabled = chkAutoRunTest.Checked;
        }

        /// <summary>
        /// 表示 tslShowASRSCommunication 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslShowASRSCommunication_Click(object sender, EventArgs e)
        {
            funShowASRSCommunication();
        }

        /// <summary>
        /// 表示 nfiMain 觸發 DoubleClick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nfiMain_DoubleClick(object sender, EventArgs e)
        {
            funShowASRSCommunication();
        }

        /// <summary>
        /// 表示 tslCloseASRSCommunication 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslCloseASRSCommunication_Click(object sender, EventArgs e)
        {
            funClose();
        }

        /// <summary>
        /// 表示 btnExit 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            funClose();
        }

        /// <summary>
        /// 表示 frmWinPLCCommu 觸發 Resize 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWinPLCCommu_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                nfiMain.Visible = true;
            }
        }

        /// <summary>
        /// 表示 btnReconnectDB 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReconnectDB_Click(object sender, EventArgs e)
        {
            funReconnectionDB();
        }

        /// <summary>
        /// 表示 btnReconnectPLC 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReconnectPLC_Click(object sender, EventArgs e)
        {
            funReconnectionPLC(0);
        }

        /// <summary>
        /// 表示 btnCraneCommand 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCraneCommand_Click(object sender, EventArgs e)
        {
            if(EquCmd == null)
            {
                EquCmd = new frmEquCmd();
                EquCmd.TopMost = true;
                EquCmd.FormClosed += new FormClosedEventHandler(funMdiForm_FormClosed);
                EquCmd.ShowSystemTrace += new Mirle.WinPLCCommu.frmEquCmd.delShowSystemTraceEventHandler(frmMdiForm_ShowSystemTrace);
                EquCmd.Show();
            }
            else
                EquCmd.BringToFront();
        }

        /// <summary>
        /// 表示 btnSetPLC 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPLCModify_Click(object sender, EventArgs e)
        {
            if(PLCModify == null)
            {
                PLCModify = new frmPLCModify(objBufferData);
                PLCModify.TopMost = true;
                PLCModify.FormClosed += new FormClosedEventHandler(funMdiForm_FormClosed);
                PLCModify.ShowSystemTrace += new Mirle.WinPLCCommu.frmPLCModify.delShowSystemTraceEventHandler(frmMdiForm_ShowSystemTrace);
                PLCModify.Show();
            }
            else
                PLCModify.BringToFront();
        }

        /// <summary>
        /// 表示 btnBufferInfo 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBufferInfo_Click(object sender, EventArgs e)
        {
            if(BufferInfo == null)
            {
                BufferInfo = new frmBufferInfo();
                BufferInfo.TopMost = true;
                BufferInfo.FormClosed += new FormClosedEventHandler(funMdiForm_FormClosed);
                BufferInfo.Show();
            }
            else
                BufferInfo.BringToFront();
        }

        /// <summary>
        /// 表示 MdiForm 觸發 FormClosed 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void funMdiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(BufferInfo != null)
                BufferInfo = null;
            if(PLCModify != null)
                PLCModify = null;
            if(EquCmd != null)
                EquCmd = null;
        }

        /// <summary>
        /// 表示 uclBuffer 觸發 uclBufferClick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uclBuffer_uclBufferClick(object sender, EventArgs e)
        {
            if(sender is uclBuffer && PLCModify != null)
            {
                uclBuffer Buffer = (uclBuffer)sender;
                if(clsSystem.gdicBufferIndex.ContainsKey(Buffer.BufferName))
                    PLCModify.funBufferIndexChange(clsSystem.gdicBufferIndex[Buffer.BufferName]);
            }
        }

        /// <summary>
        /// 表示 objBufferData 觸發 AlarmData 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void objBufferData_AlarmData(object sender, clsBufferData.clsAlarmEventArgs e)
        {
            clsTraceLogEventArgs TraceLogEventArgs = new clsTraceLogEventArgs(enuTraceLog.Alarm);
            TraceLogEventArgs.LogMessage = e.AlarmDesc;
            TraceLogEventArgs.AlarmClear = e.AlarmClear;
            funShowSystemTrace(lsbAlarmList, TraceLogEventArgs, true);
            TraceLogEventArgs = null;
        }
        /// <summary>
        /// 表示 objBufferData 觸發 wcsAlarmData 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void objBufferData_wcsAlarmData(object sender, clsBufferData.clsAlarmEventArgs e)
        {


            clsTraceLogEventArgs TraceLogEventArgs = new clsTraceLogEventArgs(enuTraceLog.Alarm);
            TraceLogEventArgs.LogMessage = e.AlarmDesc;
            TraceLogEventArgs.AlarmClear = e.AlarmClear;
            funShowSystemTrace(lsbAlarmList, TraceLogEventArgs, true);
            TraceLogEventArgs = null;

            
        }
        /// <summary>
        /// 表示 MdiForm 觸發 ShowSystemTrace 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMdiForm_ShowSystemTrace(object sender, clsTraceLogEventArgs TraceLog)
        {
            switch(TraceLog.objTraceLog)
            {
                case enuTraceLog.MPLC:
                    funShowSystemTrace(lsbMPLC, TraceLog, true);
                    break;
                case enuTraceLog.System:
                    funShowSystemTrace(lsbSystemTrace, TraceLog, true);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 表示 btnAutoPause 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoPause_Click(object sender, EventArgs e)
        {
            btnAutoPause.Text = btnAutoPause.Text == "Auto" ? "Pause" : "Auto";
            bolAutoPaseFlag = btnAutoPause.Text == "Auto" ? false : true;
            lblCmuSts.Text = btnAutoPause.Text == "Auto" ? "Pause" : "Auto";
            lblCmuSts.BackColor = btnAutoPause.Text == "Auto" ? Color.Red : Color.Lime;
        }

        /// <summary>
        /// 表示 chkAutoReconnect 觸發 CheckedChanged 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAutoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            btnReconnectDB.Enabled = !chkAutoReconnect.Checked;
            btnReconnectPLC.Enabled = !chkAutoReconnect.Checked;
        }

        #region Auto Run Event (暫無用)
        private void chkAutoRunA01_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAutoRunA02_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAutoRunA03_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAutoRunD04ToRM1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkAutoRunD04ToRM2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkAutoRunD04ToRM3_CheckedChanged(object sender, EventArgs e)
        {
        }
        #endregion Auto Run Event (暫無用)

        #endregion 事件

        #region 私用方法

        #region 初始化相關

        #region InitLayout
        /// <summary>
        /// 初始化 Crane Sts Layout
        /// </summary>
        private void funInitCraneStsLayout()
        {
            tlpCraneSts.Controls.Clear();
            tlpCraneSts.RowCount = 2;
            tlpCraneSts.ColumnCount = clsSystem.gintRMQty * 2;
            tlpCraneSts.ColumnStyles.Clear();
            int intColumn = 0;

            for(int intCount = 1; intCount <= clsSystem.gintRMQty; intCount++)
            {
                tlpCraneSts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / (clsSystem.gintRMQty * 2)));
                tlpCraneSts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / (clsSystem.gintRMQty * 2)));

                #region CraneStsLable
                Label objLabel = new Label();
                objLabel.Name = "lblCrane" + intCount + "StsLable";
                objLabel.Text = "Crane" + intCount + " Sts";
                objLabel.TextAlign = ContentAlignment.MiddleCenter;
                objLabel.BorderStyle = BorderStyle.Fixed3D;
                objLabel.BackColor = Color.Black;
                objLabel.ForeColor = Color.White;
                objLabel.Dock = DockStyle.Fill;
                objLabel.Margin = new Padding(0);
                tlpCraneSts.Controls.Add(objLabel, intColumn, 0);
                tlpCraneSts.SetColumnSpan(objLabel, 2);
                #endregion CraneStsLable

                #region CraneMode
                objLabel = new Label();
                objLabel.Name = "lblCrane" + intCount + "Mode";
                funShowCraneMode("X", ref objLabel);
                objLabel.TextAlign = ContentAlignment.MiddleCenter;
                objLabel.BorderStyle = BorderStyle.Fixed3D;
                objLabel.ForeColor = Color.Black;
                objLabel.Dock = DockStyle.Fill;
                objLabel.Margin = new Padding(0);
                tlpCraneSts.Controls.Add(objLabel, intColumn, 1);
                intColumn++;
                #endregion CraneMode

                #region CraneSts
                objLabel = new Label();
                objLabel.Name = "lblCrane" + intCount + "Sts";
                funShowCraneSts("X", ref objLabel);
                objLabel.TextAlign = ContentAlignment.MiddleCenter;
                objLabel.BorderStyle = BorderStyle.Fixed3D;
                objLabel.ForeColor = Color.Black;
                objLabel.Dock = DockStyle.Fill;
                objLabel.Margin = new Padding(0);
                tlpCraneSts.Controls.Add(objLabel, intColumn, 1);
                intColumn++;
                #endregion CraneSts
            }
        }
        #endregion InitLayout

        /// <summary>
        /// 初始化RefreshTimer
        /// </summary>
        private void funInitTimer()
        {
            timRefresh.Stop();
            timRefresh.Tick += new EventHandler(timRefresh_Tick);
            timRefresh.Interval = 500;
            timRefresh.Start();

            timProgram.Stop();
            timProgram.Elapsed += new System.Timers.ElapsedEventHandler(timProgram_Elapsed);
            timProgram.Interval = 1000;
            timProgram.Start();

            // 暫時不用 By Leon
            //timProgram_2.Stop();
            //timProgram_2.Elapsed += new System.Timers.ElapsedEventHandler(timProgram_2_Elapsed);
            //timProgram_2.Interval = 1000;
            //timProgram_2.Start();

            // 暫時不用 By Leon
            //timProgram_3.Stop();
            //timProgram_3.Elapsed += new System.Timers.ElapsedEventHandler(timProgram_3_Elapsed);
            //timProgram_3.Interval = 1000;
            //timProgram_3.Start();
        }

        /// <summary>
        /// 初始化 Buffer Map
        /// </summary>
        private void funInitBuffer()
        {
            DataTable objDataTable = new DataTable();
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                #region dicBufferMap & dicPC2PLCMap
                strSQL = "SELECT * FROM BufferDef ORDER BY BufferIndex, PLC2PC, PC2PLC";
                if(clsSystem.gobjSystemDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    List<Control> lstTmp = new List<Control>();
                    funGetControl(tbcMain, ref lstTmp);
                    foreach(DataRow objDataRow in objDataTable.Rows)
                    {
                        try
                        {
                            Control objControl = lstTmp.Find(ctl => ctl.Name == objDataRow["ObjectName"].ToString());
                            if(objControl != null)
                                dicBufferMap.Add(int.Parse(objDataRow["BufferIndex"].ToString()), objControl);

                            if(objDataRow["Buffer"].ToString() != "System")
                                clsSystem.gdicBufferIndex.Add(objDataRow["Buffer"].ToString(), int.Parse(objDataRow["BufferIndex"].ToString()));

                            clsSystem.gdicPC2PLCMap.Add(objDataRow["Buffer"].ToString(), int.Parse(objDataRow["PC2PLC"].ToString()));
                            //For大立光新增PLCIndex
                            //if(!clsSystem.gdicPLCIndex.ContainsValue(int.Parse(objDataRow["PLCIndex"].ToString())))
                                clsSystem.gdicPLCIndex.Add(objDataRow["Buffer"].ToString(), int.Parse(objDataRow["PLCIndex"].ToString()));
                            
                        }
                        catch(Exception ex)
                        {
                            var varObject = MethodBase.GetCurrentMethod();
                            clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, "BufferMap" + ex.Message);
                        }
                    }
                }
                #endregion dicBufferMap & dicPC2PLCMap

                #region objBCRData
                objDataTable = new DataTable();
                //strSQL = "SELECT * FROM BCRDef ORDER BY BCRIndex";
                strSQL = "select * from BCRDEF as a left join BufferDef as b where a.[Buffer] = b.[Buffer]";
                if(clsSystem.gobjSystemDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    if(objDataTable.Rows.Count > 0)
                    {
                        clsBCR[] objarBCR = new clsBCR[objDataTable.Rows.Count];
                        for(int intCount = 0; intCount < objDataTable.Rows.Count; intCount++)
                        {
                            objarBCR[intCount] = new clsBCR();
                            objarBCR[intCount].StnNo = objDataTable.Rows[intCount]["StnNo"].ToString();
                            objarBCR[intCount].PLC2PCBufferIndex = int.Parse(objDataTable.Rows[intCount]["BufferIndex"].ToString());
                            objarBCR[intCount].BCRNo = objDataTable.Rows[intCount]["BCRNO"].ToString();
                            objarBCR[intCount].BCRLoc = clsTool.funGetEnumValue<clsBCR.enuBCRLoc>(objDataTable.Rows[intCount]["BCRLoc"].ToString());
                            objarBCR[intCount].BufferName = objDataTable.Rows[intCount]["Buffer"].ToString();
                            objarBCR[intCount].StnIndex = int.Parse(objDataTable.Rows[intCount]["StnIndex"].ToString());
                            objarBCR[intCount].PLCIndex = objDataTable.Rows[intCount]["PLCIndex"].ToString();
                            if(!lstStn.Contains(objarBCR[intCount].StnNo))
                                lstStn.Add(objarBCR[intCount].StnNo);
                        }

                        objBCRData.funAddBCR(objarBCR);
                        objarBCR = null;
                    }
                }



                strSQL = "UPDATE IN_BUF SET BCR_DATA='n/a', BCR_STS='0'";
                clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                strSQL = "UPDATE IN_Weight SET Weight_DATA='n/a', Weight_STS='0'";
                clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                #endregion objBCRData

                objDataTable = new DataTable();
                strSQL = "select * from WeightDef as a left join BufferDef as b where a.[Buffer] = b.[Buffer]";
                if (clsSystem.gobjSystemDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    if (objDataTable.Rows.Count > 0)
                    {
                        clsWT[] objarWT = new clsWT[objDataTable.Rows.Count];
                        int intWTCoount = 0;
                        for (int intCount = 0; intCount < objDataTable.Rows.Count; intCount++)
                        {
                            //if (intCount % 2 == 0)
                            //    continue;
                            //intWTCoount = intCount / 2;
                            objarWT[intCount] = new clsWT();
                            objarWT[intCount].StnNo = objDataTable.Rows[intCount]["StnNo"].ToString();
                            objarWT[intCount].StnIndex = int.Parse(objDataTable.Rows[intCount]["StnIndex"].ToString());
                            objarWT[intCount].WeightNo = objDataTable.Rows[intCount]["WeightNo"].ToString();
                            objarWT[intCount].WeightIndex = int.Parse(objDataTable.Rows[intCount]["WeightIndex"].ToString());
                           // objarWT[intCount].WTLoc = clsTool.funGetEnumValue<clsWT.enuWTLoc>(objDataTable.Rows[intCount]["WTLoc"].ToString());
                            objarWT[intCount].Buffer = objDataTable.Rows[intCount]["Buffer"].ToString();
                            if (!lstStn_WT.Contains(objarWT[intCount].StnNo))
                                lstStn_WT.Add(objarWT[intCount].StnNo);
                        }
                        objWTData.funAddWT(objarWT);
                        objarWT = null;
                    }
                }

                #region StnDef
                objDataTable = new DataTable();
                strSQL = "SELECT * FROM StnDef";
                if(clsSystem.gobjSystemDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    foreach(DataRow objDataRow in objDataTable.Rows)
                    {
                        clsStnDef StnDef = new clsStnDef();
                        StnDef.Buffer = objDataRow["Buffer"].ToString();
                        StnDef.BufferIndex = int.Parse(objDataRow["BufferIndex"].ToString());
                        StnDef.CraneNo = int.Parse(objDataRow["CraneNo"].ToString());
                        StnDef.PortNo = objDataRow["PortNo"].ToString().PadLeft(7, '0');
                        StnDef.DoublePortNo = objDataRow["DoublePortNo"].ToString().PadLeft(7, '0');
                        StnDef.StnNo = objDataRow["StnNo"].ToString();
                        StnDef.StnIndex = int.Parse(objDataRow["StnIndex"].ToString());

                        switch(objDataRow["Direction"].ToString())
                        {
                            case clsInOutMode.cstrInMode:
                                lstInModeStnDef.Add(StnDef);
                                break;
                            case clsInOutMode.cstrOutMode:
                                lstOutModeStnDef.Add(StnDef);
                                break;
                            case clsInOutMode.cstrBoth:
                                lstInModeStnDef.Add(StnDef);
                                lstOutModeStnDef.Add(StnDef);
                                break;
                        }
                    }
                }
                #endregion StnDef

                #region AlarmCode
                objDataTable = new DataTable();
                strSQL = "SELECT * FROM AlarmCode";
                if(clsSystem.gobjSystemDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                    objBufferData.funSetAlarmCode(objDataTable);
                #endregion AlarmCode
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                if(objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
            }
        }

        /// <summary>
        /// 尋找 uclBuffer 控制項，並回傳List
        /// </summary>
        /// <param name="control"></param>
        /// <param name="ControlList"></param>
        private void funGetControl(Control control, ref List<Control> ControlList)
        {
            for(int intCount = 0; intCount < control.Controls.Count; intCount++)
            {
                if(control.Controls[intCount] is uclBuffer)
                    ControlList.Add(control.Controls[intCount]);
                else if(control.Controls[intCount].Controls.Count > 0)
                {
                    funGetControl(control.Controls[intCount], ref ControlList);
                    continue;
                }
            }
        }

        private void SubObjectInit()
        {
            //string strMSG = string.Empty;
            //uclWT_A_2L.ComPort = clsSystem.gstrWT_A_2L; uclWT_A_2L.Weight_NAME = "Weight_A_2";
            //uclWT_A_4L.ComPort = clsSystem.gstrWT_A_4L; uclWT_A_4L.Weight_NAME = "Weight_A_4";
            //uclWT_A_6L.ComPort = clsSystem.gstrWT_A_6L; uclWT_A_6L.Weight_NAME = "Weight_A_6";

            //uclWT_B_2L.ComPort = clsSystem.gstrWT_B_2L; uclWT_B_2L.Weight_NAME = "Weight_B_2";
            //uclWT_B_4L.ComPort = clsSystem.gstrWT_B_4L; uclWT_B_4L.Weight_NAME = "Weight_B_4";
            //uclWT_B_6L.ComPort = clsSystem.gstrWT_B_6L; uclWT_B_6L.Weight_NAME = "Weight_B_6";

            //uclWT_C_2L.ComPort = clsSystem.gstrWT_C_2L; uclWT_C_2L.Weight_NAME = "Weight_C_2";
            //uclWT_C_4L.ComPort = clsSystem.gstrWT_C_4L; uclWT_C_4L.Weight_NAME = "Weight_C_4";
            //uclWT_C_6L.ComPort = clsSystem.gstrWT_C_6L; uclWT_C_6L.Weight_NAME = "Weight_C_6";

            //uclWT_D_2L.ComPort = clsSystem.gstrWT_D_2L; uclWT_D_2L.Weight_NAME = "Weight_D_2";
            //uclWT_D_4L.ComPort = clsSystem.gstrWT_D_4L; uclWT_D_4L.Weight_NAME = "Weight_D_4";
            //uclWT_D_6L.ComPort = clsSystem.gstrWT_D_6L; uclWT_D_6L.Weight_NAME = "Weight_D_6";

            //uclWT_E_2L.ComPort = clsSystem.gstrWT_E_2L; uclWT_E_2L.Weight_NAME = "Weight_E_2";
            //uclWT_E_4L.ComPort = clsSystem.gstrWT_E_4L; uclWT_E_4L.Weight_NAME = "Weight_E_4";
            //uclWT_E_6L.ComPort = clsSystem.gstrWT_E_6L; uclWT_E_6L.Weight_NAME = "Weight_E_6";

            //uclWT_F_2L.ComPort = clsSystem.gstrWT_F_2L; uclWT_F_2L.Weight_NAME = "Weight_F_2";
            //uclWT_F_4L.ComPort = clsSystem.gstrWT_F_4L; uclWT_F_4L.Weight_NAME = "Weight_F_4";
            //uclWT_F_6L.ComPort = clsSystem.gstrWT_F_6L; uclWT_F_6L.Weight_NAME = "Weight_F_6";

            //uclWT_G_2L.ComPort = clsSystem.gstrWT_G_2L; uclWT_G_2L.Weight_NAME = "Weight_G_2";
            //uclWT_G_4L.ComPort = clsSystem.gstrWT_G_4L; uclWT_G_4L.Weight_NAME = "Weight_G_4";
            //uclWT_G_6L.ComPort = clsSystem.gstrWT_G_6L; uclWT_G_6L.Weight_NAME = "Weight_G_6";

            //#region 開啟2F秤重機Port
            //uclWT_A_2L.subStart();
            ////若連線失敗Show再Trance Log中
            //if (!uclWT_A_2L.Conn)
            //    strMSG += "\n" + uclWT_A_2L.ErrorMSG;
            //uclWT_A_4L.subStart();
            //if (!uclWT_A_4L.Conn)
            //    strMSG += "\n" + uclWT_A_4L.ErrorMSG;
            //uclWT_A_6L.subStart();
            //if (!uclWT_A_6L.Conn)
            //    strMSG += "\n" + uclWT_A_6L.ErrorMSG;
         
            //#endregion 開啟2F秤重機Port

            //#region 開啟3F秤重機Port
            //uclWT_B_2L.subStart();
            ////若連線失敗Show再Trance Log中
            //if (!uclWT_B_2L.Conn)
            //    strMSG += "\n" + uclWT_B_2L.ErrorMSG;
            //uclWT_B_4L.subStart();
            //if (!uclWT_B_4L.Conn)
            //    strMSG += "\n" + uclWT_B_4L.ErrorMSG;
            //uclWT_B_6L.subStart();
            //if (!uclWT_B_6L.Conn)
            //    strMSG += "\n" + uclWT_B_6L.ErrorMSG;
          
          
            //#endregion 開啟3F秤重機Port

            //#region 開啟4F秤重機Port
            //uclWT_C_2L.subStart();
            ////若連線失敗Show再Trance Log中
            //if (!uclWT_C_2L.Conn)
            //    strMSG += "\n" + uclWT_C_2L.ErrorMSG;
            //uclWT_C_4L.subStart();
            //if (!uclWT_C_4L.Conn)
            //    strMSG += "\n" + uclWT_C_4L.ErrorMSG;
            //uclWT_C_6L.subStart();
            //if (!uclWT_C_6L.Conn)
            //    strMSG += "\n" + uclWT_C_6L.ErrorMSG;
            
            //#endregion 開啟4F秤重機Port

            //#region 開啟5F秤重機Port
            //uclWT_D_2L.subStart();
            ////若連線失敗Show再Trance Log中
            //if (!uclWT_D_2L.Conn)
            //    strMSG += "\n" + uclWT_D_2L.ErrorMSG;
            //uclWT_D_4L.subStart();
            //if (!uclWT_D_4L.Conn)
            //    strMSG += "\n" + uclWT_D_4L.ErrorMSG;
            //uclWT_D_6L.subStart();
            //if (!uclWT_D_6L.Conn)
            //    strMSG += "\n" + uclWT_D_6L.ErrorMSG;
            //#endregion 開啟5F秤重機Port

            //#region 開啟6F秤重機Port
            //uclWT_E_2L.subStart();
            ////若連線失敗Show再Trance Log中
            //if (!uclWT_E_2L.Conn)
            //    strMSG += "\n" + uclWT_E_2L.ErrorMSG;
            //uclWT_E_4L.subStart();
            //if (!uclWT_E_4L.Conn)
            //    strMSG += "\n" + uclWT_E_4L.ErrorMSG;
            //uclWT_E_6L.subStart();
            //if (!uclWT_E_6L.Conn)
            //    strMSG += "\n" + uclWT_E_6L.ErrorMSG;
            //#endregion 開啟6F秤重機Port

            //#region 開啟7F秤重機Port
            //uclWT_F_2L.subStart();
            ////若連線失敗Show再Trance Log中
            //if (!uclWT_F_2L.Conn)
            //    strMSG += "\n" + uclWT_F_2L.ErrorMSG;
            //uclWT_F_4L.subStart();
            //if (!uclWT_F_4L.Conn)
            //    strMSG += "\n" + uclWT_F_4L.ErrorMSG;
            //uclWT_F_6L.subStart();
            //if (!uclWT_F_6L.Conn)
            //    strMSG += "\n" + uclWT_F_6L.ErrorMSG;
            //#endregion 開啟7F秤重機Port

            //#region 開啟8F秤重機Port
            //uclWT_G_2L.subStart();
            ////若連線失敗Show再Trance Log中
            //if (!uclWT_G_2L.Conn)
            //    strMSG += "\n" + uclWT_G_2L.ErrorMSG;
            //uclWT_G_4L.subStart();
            //if (!uclWT_G_4L.Conn)
            //    strMSG += "\n" + uclWT_G_4L.ErrorMSG;
            //uclWT_G_6L.subStart();
            //if (!uclWT_G_6L.Conn)
            //    strMSG += "\n" + uclWT_G_6L.ErrorMSG;
            //#endregion 開啟8F秤重機Port

            //if (!string.IsNullOrEmpty(strMSG))
            //{
            //    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //    SystemTraceLog.LogMessage = strMSG;
            //    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
            //}
        }
        #endregion 初始化相關 

        /// <summary>
        /// 表示 Close ASRS Communication之方法
        /// </summary>
        private void funClose()
        {
            frmCloseProgram objCloseProgram = new frmCloseProgram();

            if(objCloseProgram.ShowDialog() == DialogResult.OK)
            {
                timRefresh.Stop();
                timProgram.Stop();
                timProgram_2.Stop();
                timProgram_3.Stop();
                nfiMain.Visible = false;
                bolClose = true;
                this.Close();
            }
        }

        /// <summary>
        /// 表示 Reconnection PLC之方法
        /// </summary>
        private async void funReconnectionPLC(int intPLC)
        {
            if (await clsInitSys.funReconnectionPLC(intPLC))
            {
                clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                SystemTraceLog.LogMessage = "Try Reconnection PLC" + intPLC + " Success!";
                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                SystemTraceLog = null;
            }
            else
            {
                clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                SystemTraceLog.LogMessage = "Try Reconnection PLC" + intPLC + " Fail!";
                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                SystemTraceLog = null;
            }


        }

        /// <summary>
        /// 表示 Reconnection DB之方法
        /// </summary>
        private async void funReconnectionDB()
        {
            if(await clsInitSys.funReconnectionDB())
            {
                clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                SystemTraceLog.LogMessage = "Try Reconnection DB Success!";
                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                SystemTraceLog = null;
            }
            else
            {
                clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                SystemTraceLog.LogMessage = "Try Reconnection DB Fail!";
                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                SystemTraceLog = null;
            }
        }

        /// <summary>
        /// 表示 Show ASRS Communication之方法
        /// </summary>
        private void funShowASRSCommunication()
        {
            this.Size = new Size(1024, 768);
            this.Visible = true;
            nfiMain.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 表示顯示SystemTrace之方法
        /// </summary>
        /// <param name="TraceListBox"></param>
        /// <param name="TraceLog"></param>
        /// <param name="WriteLog"></param>
        private void funShowSystemTrace(ListBox TraceListBox, clsTraceLogEventArgs TraceLog, bool WriteLog)
        {
            if(this.InvokeRequired)
            {
                delShowSystemTrace ShowSystemTrace = new delShowSystemTrace(funShowSystemTrace);
                this.Invoke(ShowSystemTrace, TraceListBox, TraceLog, WriteLog);
            }
            else
            {
                try
                {
                    string strLogMessage = TraceLog.LogMessage.PadRight(35, ' ');
                    switch(TraceLog.objTraceLog)
                    {
                        case enuTraceLog.System:
                            #region System
                            if(!string.IsNullOrWhiteSpace(TraceLog.BCRNo))
                            {
                                #region BCR相關
                                strLogMessage += " => BCRNo:<" + TraceLog.BCRNo + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.BCRSts))
                                    strLogMessage += "BCRSts:<" + TraceLog.BCRSts + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.BCRID))
                                    strLogMessage += "BCRID:<" + TraceLog.BCRID + "> ";
                                #endregion BCR相關
                            }
                            else if(!string.IsNullOrWhiteSpace(TraceLog.LeftCmdSno) || !string.IsNullOrWhiteSpace(TraceLog.RightCmdSno))
                            {
                                #region CmdSno相關
                                strLogMessage += " => CmdSno:<";
                                if(!string.IsNullOrWhiteSpace(TraceLog.LeftCmdSno) && !string.IsNullOrWhiteSpace(TraceLog.RightCmdSno))
                                    strLogMessage += TraceLog.LeftCmdSno + ", " + TraceLog.RightCmdSno + "> ";
                                else if(!string.IsNullOrWhiteSpace(TraceLog.LeftCmdSno))
                                    strLogMessage += TraceLog.LeftCmdSno + "> ";
                                else if(!string.IsNullOrWhiteSpace(TraceLog.RightCmdSno))
                                    strLogMessage += TraceLog.RightCmdSno + "> ";
                                else
                                    strLogMessage += "> ";

                                if(!string.IsNullOrWhiteSpace(TraceLog.SNO))
                                    strLogMessage += "SNO:<" + TraceLog.SNO + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.CmdSts))
                                    strLogMessage += "CmdSts:<" + TraceLog.CmdSts + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.CmdMode))
                                    strLogMessage += "CmdMode:<" + TraceLog.CmdMode + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.Trace))
                                    strLogMessage += "Trace:<" + TraceLog.Trace + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.StnNo))
                                    strLogMessage += "StnNo:<" + TraceLog.StnNo + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.CmdCraneNo))
                                    strLogMessage += "CmdCraneNo:<" + TraceLog.CmdCraneNo + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.LocID))
                                    strLogMessage += "LocID:<" + TraceLog.LocID + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.NewLocID))
                                    strLogMessage += "NewLocID:<" + TraceLog.NewLocID + "> ";
                                #endregion CmdSno相關
                            }
                            else if(!string.IsNullOrWhiteSpace(TraceLog.CraneNo))
                            {
                                #region Crane相關
                                strLogMessage += " => CraneNo:<" + TraceLog.CraneNo + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.CraneSts))
                                    strLogMessage += "CraneSts:<" + TraceLog.CraneSts + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.CraneStsLast))
                                    strLogMessage += "CraneStsLast:<" + TraceLog.CraneStsLast + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.CraneMode))
                                    strLogMessage += "CraneMode:<" + TraceLog.CraneMode + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.CraneModeLast))
                                    strLogMessage += "CraneModeLast:<" + TraceLog.CraneModeLast + "> ";
                                #endregion Crane相關
                            }
                            else if(!string.IsNullOrWhiteSpace(TraceLog.LocSts))
                            {
                                #region LocSts相關
                                strLogMessage += " => Loc:<" + TraceLog.LocID + "> ";
                                strLogMessage += "LocSts:<" + TraceLog.LocSts + "> ";
                                strLogMessage += "OldLocSts:<" + TraceLog.OldLocSts + "> ";
                                #endregion LocSts相關
                            }

                            if(strLastSystemTraceLog.LogMessage != TraceLog.LogMessage)
                            {
                                if(TraceListBox.Items.Count > 200)
                                    TraceListBox.Items.RemoveAt(0);

                                TraceListBox.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] " + strLogMessage);
                                TraceListBox.SelectedIndex = TraceListBox.Items.Count - 1;
                                strLastSystemTraceLog = TraceLog;

                                if(WriteLog)
                                    clsSystem.funWriteSystemTraceLog(strLogMessage);
                            }
                            #endregion System
                            break;
                        case enuTraceLog.MPLC:
                            #region MPLC
                            if(!string.IsNullOrWhiteSpace(TraceLog.BufferName))
                            {
                                strLogMessage += " => BuffwerName:<" + TraceLog.BufferName + "> ";
                                if(!string.IsNullOrWhiteSpace(TraceLog.AddressSection))
                                    strLogMessage += "AddressSection:<" + TraceLog.AddressSection + "> ";
                                if(TraceLog.PLCValues.Length > 0)
                                    strLogMessage += "PLCValues:<" + string.Join(", ", TraceLog.PLCValues) + "> ";
                            }

                            if(strLastMPLCTraceLog.LogMessage != TraceLog.LogMessage)
                            {
                                if(TraceListBox.Items.Count > 200)
                                    TraceListBox.Items.RemoveAt(0);

                                TraceListBox.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] " + strLogMessage);
                                TraceListBox.SelectedIndex = TraceListBox.Items.Count - 1;
                                strLastMPLCTraceLog = TraceLog;

                                if(WriteLog)
                                    clsSystem.funWriteMPLCTraceLog(strLogMessage);
                            }
                            #endregion MPLC
                            break;
                        case enuTraceLog.Alarm:
                            #region Alarm
                            if(TraceLog.AlarmClear)
                            {
                                if(TraceListBox.Items.Contains(TraceLog.LogMessage))
                                    TraceListBox.Items.Remove(TraceLog.LogMessage);

                                if(WriteLog)
                                    clsSystem.funWriteAlarmLog("Alarm Clear  => " + TraceLog.LogMessage);
                            }
                            else
                            {
                                if(!TraceListBox.Items.Contains(TraceLog.LogMessage))
                                    TraceListBox.Items.Add(TraceLog.LogMessage);

                                if(WriteLog)
                                    clsSystem.funWriteAlarmLog("Alarm Set => " + TraceLog.LogMessage);
                            }
                            #endregion Alarm
                            break;
                        case enuTraceLog.SQL:
                            if (WriteLog)
                                clsSystem.funWriteAlarmLog("SQL => " + TraceLog.LogMessage);
                            break;
                        case enuTraceLog.None:

                        default:
                            break;
                    }
                }
                catch(Exception ex)
                {
                    var varObject = MethodBase.GetCurrentMethod();
                    clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                }
            }
        }
        #endregion 私用方法

        private void btnReconnectWeight_Click(object sender, EventArgs e)
        {
            SubObjectInit();
        }

        private void ptbA01_DoubleClick(object sender, EventArgs e)
        {
            //if(ptbA01.Image
        }
        private void ptbA01_DoubleClick_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定更換站口(A01)方向?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (ptbA01.Tag == "IN")
                {
                    ptbA01.Tag = "OUT";
                    ptbA01.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
                }
                else
                {
                    ptbA01.Tag = "IN";
                    ptbA01.Image = global::Mirle.WinPLCCommu.Properties.Resources.Top;
                }
            }
        }
        private void ptbA02_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定更換站口(A02)方向?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (ptbA02.Tag == "IN")
                {
                    ptbA02.Tag = "OUT";
                    ptbA02.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
                }
                else
                {
                    ptbA02.Tag = "IN";
                    ptbA02.Image = global::Mirle.WinPLCCommu.Properties.Resources.Top;
                }
            }
        }

        private void ptbA03_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定更換站口(A03)方向?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (ptbA03.Tag == "IN")
                {
                    ptbA03.Tag = "OUT";
                    ptbA03.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
                }
                else
                {
                    ptbA03.Tag = "IN";
                    ptbA03.Image = global::Mirle.WinPLCCommu.Properties.Resources.Top;
                }
            }
        }

        private void ptbA04_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定更換站口(A04)方向?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (ptbA04.Tag == "IN")
                {
                    ptbA04.Tag = "OUT";
                    ptbA04.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
                }
                else
                {
                    ptbA04.Tag = "IN";
                    ptbA04.Image = global::Mirle.WinPLCCommu.Properties.Resources.Top;
                }
            }
        }

        private void ptbA05_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定更換站口(A05)方向?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (ptbA05.Tag == "IN")
                {
                    ptbA05.Tag = "OUT";
                    ptbA05.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
                }
                else
                {
                    ptbA05.Tag = "IN";
                    ptbA05.Image = global::Mirle.WinPLCCommu.Properties.Resources.Top;
                }
            }
        }

        private void ptbA06_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定更換站口(A06)方向?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (ptbA06.Tag == "IN")
                {
                    ptbA06.Tag = "OUT";
                    ptbA06.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
                }
                else
                {
                    ptbA06.Tag = "IN";
                    ptbA06.Image = global::Mirle.WinPLCCommu.Properties.Resources.Top;
                }
            }
        }

        public string funAlarmLog(int iBufferIndex, int iAlarmCode)
        {
            string strAlarmMsg = string.Empty;
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                string strAlarmCode = Convert.ToString(iAlarmCode, 2);
                char[] charAlarm = strAlarmCode.ToCharArray();
                int iAlarmIndex = charAlarm.Length;
                for (int i = 0; i < charAlarm.Length; i++)
                {

                    if (charAlarm[i].ToString() == "1")
                    {
                        //strAlarmMsg += objarPLC2PCBuffer[iBufferIndex].AlarmSignal[iAlarmIndex].AlarmDesc;
                        strAlarmMsg += objBufferData.PLC2PCBuffer[iBufferIndex].AlarmSignal[iAlarmIndex].AlarmDesc +" ";

                    }
                    iAlarmIndex--;
                }

                return strAlarmMsg;
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
            }
        }
        
    }
}
