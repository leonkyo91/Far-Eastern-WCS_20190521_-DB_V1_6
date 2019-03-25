using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
            this.Text = "WinBCRRead (" + clsSystem.cstrStnNo + ")";
            nfiMain.Text = "WinBCRRead (" + clsSystem.cstrStnNo + ")";
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            lblBCRNo_L.Text = clsSystem.cstrStnNo + "_L";
            lblBCRNo_R.Text = clsSystem.cstrStnNo + "_R";
            lblLastReadingTime_L.Text = string.Empty;
            lblLastReadingTime_R.Text = string.Empty;
            
            funShowConnect(clsSystem.gobjDB.ConnFlag, ref lblDBSts);
            funShowConnect(clsSystem.gobjLeftBCR.IsOpen, ref lblBCRSts1_L);
            funShowConnect(clsSystem.gobjRightBCR.IsOpen, ref lblBCRSts1_R);

            timUpdata.Stop();
            timUpdata.Tick += new EventHandler(timUpdata_Tick);
            timUpdata.Interval = 1000;
            timUpdata.Start();
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
        /// 表示 timUpdata 觸發 Tick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timUpdata_Tick(object sender, EventArgs e)
        {
            timUpdata.Stop();

            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");

            funGetBCRInfo();

            timUpdata.Start();
        }
        #endregion 事件

        #region 私用方法

        #region AP相關
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
                nfiMain.Visible = false;
                bolClose = true;
                this.Close();
            }
        }
        #endregion AP相關

        private void funGetBCRInfo()
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            DataTable objDataTable = new DataTable();

            try
            {
                strSQL = "SELECT * FROM IN_BUF WHERE BCR_NO IN";
                strSQL += " ('" + clsSystem.cstrStnNo + "_L', '" + clsSystem.cstrStnNo + "_R')";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    for(int intCount = 0; intCount < objDataTable.Rows.Count; intCount++)
                    {
                        string strBCRNo = objDataTable.Rows[intCount]["BCR_NO"].ToString();
                        string strBCRSts = objDataTable.Rows[intCount]["BCR_STS"].ToString();
                        string strBCRID = objDataTable.Rows[intCount]["BCR_DATA"].ToString();

                        switch(strBCRNo)
                        {
                            case clsSystem.cstrStnNo + "_L":
                                funShowBCRSts(strBCRSts, ref lblBCRSts2_L);
                                lblBCRReadID_L.Text = strBCRID;
                                if(strBCRSts == cstrBCRReading)
                                    funReadBCR("L");
                                break;
                            case clsSystem.cstrStnNo + "_R":
                                funShowBCRSts(strBCRSts, ref lblBCRSts2_R);
                                lblBCRReadID_R.Text = strBCRID;
                                if(strBCRSts == cstrBCRReading)
                                    funReadBCR("R");
                                break;
                            default:
                                break;
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

        private void funReadBCR(string LR)
        {
            string strBCRID = string.Empty;
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                switch(LR)
                {
                    case "L":
                        clsSystem.gobjLeftBCR.DiscardOutBuffer();
                        clsSystem.gobjLeftBCR.DiscardInBuffer();
                        clsSystem.gobjLeftBCR.Write("LON" + "\r");
                        Thread.Sleep(1500);
                        clsSystem.gobjLeftBCR.Write("LOFF" + "\r");
                        strBCRID = clsSystem.gobjLeftBCR.ReadExisting().Replace("\r", "");
                        break;
                    case "R":
                        clsSystem.gobjRightBCR.DiscardOutBuffer();
                        clsSystem.gobjRightBCR.DiscardInBuffer();
                        clsSystem.gobjRightBCR.Write("LON" + "\r");
                        Thread.Sleep(1500);
                        clsSystem.gobjRightBCR.Write("LOFF" + "\r");
                        strBCRID = clsSystem.gobjRightBCR.ReadExisting().Replace("\r", "");
                        break;
                }

                if(string.IsNullOrWhiteSpace(strBCRID))
                    strBCRID = "ERROR";

                strSQL = "UPDATE IN_BUF SET BCR_DATA='" + strBCRID + "', BCR_STS='2'";
                strSQL += " WHERE BCR_NO='" + clsSystem.cstrStnNo + "_" + LR + "'";

                clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                clsSystem.funWriteBCRReadLog(clsSystem.cstrStnNo + "_" + LR + ": <" + strBCRID + ">");

                switch(LR)
                {
                    case "L":
                        lblLastReadingTime_L.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                    case "R":
                        lblLastReadingTime_R.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                }
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }
        #endregion 私用方法
    }
}
