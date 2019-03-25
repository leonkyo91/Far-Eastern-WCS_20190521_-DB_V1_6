using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.WinBCRRead
{
    public partial class frmWinBCRRead : Form
    {
        #region 變數
        private bool bolClose = false;
        private const string cstrBCRNone = "0";
        private const string cstrBCRReading = "1";
        private const string cstrBCRReadFinish = "2";

        //秤重機
        private const string cstrWTNone = "0";
        private const string cstrWTReading = "1";
        private const string cstrWTReadFinish = "2";
        private const string cstrWTReadOver = "E1";
        private const string cstrWTReadFail = "E2";
        #endregion 變數

        #region 建構函式
        /// <summary>
        /// 初始化 Mirle.WinBCRRead.frmWinBCRRead 類別的新執行個體
        /// </summary>
        public frmWinBCRRead()
        {
            InitializeComponent();
        }
        #endregion 建構函式

        #region 事件
        /// <summary>
        /// 表示 frmWinBCRRead 觸發 Load 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWinBCRRead_Load(object sender, EventArgs e)
        {
            funInitBCRLayout();
            funInitWTLayout();
            funInitUpdata();
            this.Text = "BCR Weight Reader " + " (V." + Application.ProductVersion + ")";
        }

        /// <summary>
        /// 表示 frmWinBCRRead 觸發 FormClosing 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWinBCRRead_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !bolClose;
        }

        /// <summary>
        /// 表示 frmWinBCRRead 觸發 Resize 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWinBCRRead_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                nfiMain.Visible = true;
            }
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
        /// 表示 nfiMain 觸發 DoubleClick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nfiMain_DoubleClick(object sender, EventArgs e)
        {
            funShowWinBCR();
        }

        /// <summary>
        /// 表示 tslShowWinBCR 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslShowWinBCR_Click(object sender, EventArgs e)
        {
            funShowWinBCR();
        }

        /// <summary>
        /// 表示 tslCloseWinBCR 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslCloseWinBCR_Click(object sender, EventArgs e)
        {
            funClose();
        }

        private static object objSyncHanele = new object();
        /// <summary>
        /// 表示 timUpdata 觸發 Tick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timUpdata_Tick(object sender, EventArgs e)
        {
            timUpdata.Stop();

            lblDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff");

            funShowConnect(clsSystem.gobjDB.ConnFlag, lblDBSts);

            //新增DB斷線自動重連
            if (!clsSystem.gobjDB.ConnFlag)
            {
                clsSystem.gobjDB.funCloseDB();
                if (clsSystem.gobjDB.funOpenDB() == ErrDef.ProcSuccess)
                {
                }
            }

            funGetBCRInfo();

            funGetWTInfo();

            timUpdata.Start();
        }
        #endregion 事件

        #region 私用方法

        #region 初始化相關
        /// <summary>
        /// 表示 Show ASRS Communication之方法
        /// </summary>
        private void funShowWinBCR()
        {
            this.Visible = true;
            nfiMain.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 表示 Close ASRS Communication之方法
        /// </summary>
        private void funClose()
        {
            frmCloseProgram objCloseProgram = new frmCloseProgram();

            if(objCloseProgram.ShowDialog() != DialogResult.OK)
                return;
            else
            {
                timUpdata.Stop();
                timSerialPortReopen.Stop();
                nfiMain.Visible = false;
                bolClose = true;
                this.Close();
            }
        }

        /// <summary>
        /// 初始化 timUpdata
        /// </summary>
        private void funInitUpdata()
        {
            timUpdata.Stop();
            timUpdata.Tick += new EventHandler(timUpdata_Tick);
            timUpdata.Interval = 1000;
            timUpdata.Start();

            timSerialPortReopen.Stop();
            timSerialPortReopen.Interval = 10000;
            timSerialPortReopen.Start();
        }

        /// <summary>
        /// 初始化 BCR Layout
        /// </summary>
        private void funInitBCRLayout()
        {
            try
            {
                for(int intQty = 0; intQty < clsSystem.gintBCRQty; intQty++)
                {
                    #region BCRNo
                    Label objLabel = new Label();
                    objLabel.Name = "lbl" + clsSystem.glstBCRMap[intQty].BCRNo;
                    objLabel.Text = clsSystem.glstBCRMap[intQty].BCRNo;
                    objLabel.BackColor = Color.White;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpBCR.Controls.Add(objLabel, 0, intQty + 1);
                    #endregion BCRNo

                    #region BCRSts1
                    objLabel = new Label();
                    objLabel.Name = "lblBCRSts1_" + clsSystem.glstBCRMap[intQty].BCRNo;
                    objLabel.Text = "未連線";
                    objLabel.BackColor = Color.Red;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpBCR.Controls.Add(objLabel, 1, intQty + 1);
                    #endregion BCRSts1

                    #region BCRSts2
                    objLabel = new Label();
                    objLabel.Name = "lblBCRSts2_" + clsSystem.glstBCRMap[intQty].BCRNo;
                    objLabel.Text = "未讀取";
                    objLabel.BackColor = Color.Lime;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpBCR.Controls.Add(objLabel, 2, intQty + 1);
                    #endregion BCRSts2

                    #region BCRReadID
                    objLabel = new Label();
                    objLabel.Name = "lblBCRReadID_" + clsSystem.glstBCRMap[intQty].BCRNo;
                    objLabel.Text = string.Empty;
                    objLabel.BackColor = Color.White;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpBCR.Controls.Add(objLabel, 3, intQty + 1);
                    #endregion BCRReadID

                    #region ReadingTime
                    objLabel = new Label();
                    objLabel.Name = "lblReadingTime_" + clsSystem.glstBCRMap[intQty].BCRNo;
                    objLabel.Text = string.Empty;
                    objLabel.BackColor = Color.White;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpBCR.Controls.Add(objLabel, 4, intQty + 1);
                    #endregion ReadingTime
                }
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                MessageBox.Show(varObject.DeclaringType.FullName + "." + varObject.Name + " Exception:" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化 WT Layout
        /// </summary>
        private void funInitWTLayout()
        {
            try
            {
                for (int intQty = 0; intQty < clsSystem.gintWTQty; intQty++)
                {
                    #region WTNo
                    Label objLabel = new Label();
                    objLabel.Name = "lbl" + clsSystem.glstWTMap[intQty].WTNo;
                    objLabel.Text = clsSystem.glstWTMap[intQty].WTNo;
                    objLabel.BackColor = Color.White;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpWT.Controls.Add(objLabel, 0, intQty + 1);
                    #endregion WTNo

                    #region WTSts1
                    objLabel = new Label();
                    objLabel.Name = "lblWTSts1_" + clsSystem.glstWTMap[intQty].WTNo;
                    objLabel.Text = "未連線";
                    objLabel.BackColor = Color.Red;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpWT.Controls.Add(objLabel, 1, intQty + 1);
                    #endregion WTSts1

                    #region WTSts2
                    objLabel = new Label();
                    objLabel.Name = "lblWTSts2_" + clsSystem.glstWTMap[intQty].WTNo;
                    objLabel.Text = "未讀取";
                    objLabel.BackColor = Color.Lime;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpWT.Controls.Add(objLabel, 2, intQty + 1);
                    #endregion WTSts2

                    #region WTReadID
                    objLabel = new Label();
                    objLabel.Name = "lblWTReadID_" + clsSystem.glstWTMap[intQty].WTNo;
                    objLabel.Text = string.Empty;
                    objLabel.BackColor = Color.White;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpWT.Controls.Add(objLabel, 3, intQty + 1);
                    #endregion WTReadID

                    #region ReadingTime
                    objLabel = new Label();
                    objLabel.Name = "lblWTReadingTime_" + clsSystem.glstWTMap[intQty].WTNo;
                    objLabel.Text = string.Empty;
                    objLabel.BackColor = Color.White;
                    objLabel.TextAlign = ContentAlignment.MiddleCenter;
                    objLabel.Margin = new Padding(0);
                    objLabel.Dock = DockStyle.Fill;
                    tlpWT.Controls.Add(objLabel, 4, intQty + 1);
                    #endregion ReadingTime
                }
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                MessageBox.Show(varObject.DeclaringType.FullName + "." + varObject.Name + " Exception:" + ex.Message);
            }
        }

        #endregion 初始化相關

        private void funGetBCRInfo()
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            DataTable objDataTable = new DataTable();

            try
            {
                strSQL = "SELECT * FROM IN_BUF WHERE BCR_NO IN ('" + string.Join("', '", clsSystem.gstrarrBCRID) + "')";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    clsSystem.intBCRCount = objDataTable.Rows.Count;

                    for(int intCount = 0; intCount < objDataTable.Rows.Count; intCount++)
                    {
                        string strBCRNo = objDataTable.Rows[intCount]["BCR_NO"].ToString();
                        string strBCRSts = objDataTable.Rows[intCount]["BCR_STS"].ToString();
                        string strBCRID = objDataTable.Rows[intCount]["BCR_DATA"].ToString();

                        if(clsSystem.glstBCRMap.Exists(BCR => BCR.BCRNo == strBCRNo))
                        {
                            clsCustomSerialPort CustomSerialPort = clsSystem.glstBCRMap.Find(BCR => BCR.BCRNo == strBCRNo);

                            if(tlpBCR.Controls.ContainsKey("lblBCRSts1_" + strBCRNo))
                            {
                                Label objLabel = (Label)tlpBCR.Controls["lblBCRSts1_" + strBCRNo];
                                funShowConnect(CustomSerialPort.IsOpen, objLabel);
                            }
                            if(tlpBCR.Controls.ContainsKey("lblBCRReadID_" + strBCRNo))
                            {
                                Label objLabel = (Label)tlpBCR.Controls["lblBCRReadID_" + strBCRNo];
                                objLabel.Text = strBCRID;

                                if(tlpBCR.Controls.ContainsKey("lblReadingTime_" + strBCRNo) && strBCRID != "n/a")
                                {
                                    Label objLabel2 = (Label)tlpBCR.Controls["lblReadingTime_" + strBCRNo];
                                    objLabel2.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                                }
                            }
                            if(tlpBCR.Controls.ContainsKey("lblBCRSts2_" + strBCRNo))
                            {
                                Label objLabel = (Label)tlpBCR.Controls["lblBCRSts2_" + strBCRNo];
                                funShowBCRSts(strBCRSts, objLabel);

                                if(strBCRSts == cstrBCRReading)
                                {
                                    CustomSerialPort.DiscardOutBuffer();
                                    CustomSerialPort.DiscardInBuffer();
                                    CustomSerialPort.Write("LON" + "\r");
                                    Thread.Sleep(500);
                                    CustomSerialPort.Write("LOFF" + "\r");
                                }
                            }
                        }
                    }
                }
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

        private void funGetWTInfo()
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            DataTable objDataTable = new DataTable();

            try
            {
                strSQL = "SELECT * FROM IN_Weight WHERE Weight_NO IN ('" + string.Join("', '", clsSystem.gstrarrWTID) + "')";
                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    
                    for (int intCount = 0; intCount < objDataTable.Rows.Count; intCount++)
                    {
                        string strWTNo = objDataTable.Rows[intCount]["Weight_NO"].ToString();
                        string strWTSts = objDataTable.Rows[intCount]["Weight_STS"].ToString();
                        string strWTID = objDataTable.Rows[intCount]["Weight_DATA"].ToString();

                        if (clsSystem.glstWTMap.Exists(WT => WT.WTNo == strWTNo))
                        {
                            clsWTSerialPort WTSerialPort = clsSystem.glstWTMap.Find(WT => WT.WTNo == strWTNo);
                            if (tlpWT.Controls.ContainsKey("lblWTSts1_" + strWTNo))
                            {
                                Label objLabel = (Label)tlpWT.Controls["lblWTSts1_" + strWTNo];
                                funShowConnect(WTSerialPort.IsOpen, objLabel);
                            }
                            if (tlpWT.Controls.ContainsKey("lblWTReadID_" + strWTNo))
                            {
                                Label objLabel = (Label)tlpWT.Controls["lblWTReadID_" + strWTNo];
                                objLabel.Text = strWTID;

                                if (tlpWT.Controls.ContainsKey("lblWTReadingTime_" + strWTNo) && strWTID != "n/a")
                                {
                                    Label objLabel2 = (Label)tlpWT.Controls["lblWTReadingTime_" + strWTNo];
                                    objLabel2.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                                }
                            }//lblWTSts2_
                            if (tlpWT.Controls.ContainsKey("lblWTSts2_" + strWTNo))
                            {
                                Label objLabel = (Label)tlpWT.Controls["lblWTSts2_" + strWTNo];
                                funShowWTSts(strWTSts, objLabel);

                                if (strWTSts == cstrWTReading)
                                {
                                    WTSerialPort.DiscardOutBuffer();
                                    WTSerialPort.DiscardInBuffer();
                                    WTSerialPort.Write("RW" + "\r\n");
                                    
                                }
                            }

                            

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                if (objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
            }
        }
        #endregion 私用方法

        private void timSerialPortReopen_Tick(object sender, EventArgs e)
        {
            timSerialPortReopen.Stop();
            clsInitSys.funReconnectionBCRWT();
            timSerialPortReopen.Start();
        }
    }
}
