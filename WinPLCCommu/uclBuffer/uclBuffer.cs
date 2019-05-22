using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.WinPLCCommu
{
    public partial class uclBuffer : UserControl
    {
        #region 變數
        private enuStnMode objStnMode = enuStnMode.None;
        private enuCmdMode objCmdMode = enuCmdMode.None;
        private enuReady objReady = enuReady.NoReady;
        private enuReadNotice objReadNotice = enuReadNotice.None;
        private enuFunNotice objFunNotice = enuFunNotice.None;
        private enuStnChange objStnChange = enuStnChange.None;
        private enuOverSize objOverSize = enuOverSize.None;   
        private string strError = string.Empty;
        private bool bolRightLoad = false;
        private bool bolCargoLoad = false;
        private bool bolFunNotice = false;
        private bool bolAuto = false;
        private bool bolManual = false;
        #endregion 變數

        #region 事件
        /// <summary>
        /// 發生於按下uclBuffer控制項時
        /// </summary>
        public static event EventHandler uclBufferClick;
        #endregion 事件

        #region 委派
        private delegate void delUpdate(Label label, string Value);
        private delegate void delUpdateOnlyColor(Label label, Color color);
        private delegate void delUpdateWithColor(Label label, string Value, Color color);
        #endregion 委派

        #region 列舉
        /// <summary>
        /// 站口模式列舉
        /// </summary>
        public enum enuStnMode
        {
            None = 0,
            Left = 1,
            Right = 3,
            Both = 3,
        }

        /// <summary>
        /// 命令模式列舉
        /// </summary>
        public enum enuCmdMode
        {
            None = 0,
            Left = 1,
            Right = 3,
            Both = 3,
        }

        /// <summary>
        /// Ready列舉
        /// </summary>
        public enum enuReady
        {
            NoReady = 0,
            InReady = 1,
            OutReady = 2
        }

        /// <summary>
        /// 讀取通知列舉
        /// </summary>
        public enum enuReadNotice
        {
            None = 0,
            Read = 1,
            IDPass = 2,
            IDFail = 3
        }
        /// <summary>
        /// 功能通知列舉
        /// </summary>
        public enum enuFunNotice
        {
            None = 0,
            PalletLoad = 1
            //Height = 1,
            //Low = 2
        }
        /// <summary>
        /// 站口切換列舉
        /// </summary>
        public enum enuStnChange
        {
            None = 0,
            Change = 1
        }
        /// <summary>
        /// 站口切換列舉
        /// </summary>
        public enum enuOverSize
        {
            None = 0
        }
        /// <summary>
        /// Auto 自動訊號
        /// </summary>
        public enum enuAuto
        {
            None = 0,
            Auto = 1
        }
        /// <summary>
        /// Manual 手動訊號
        /// </summary>
        public enum enuManual
        {
            None = 0,
            Manual = 1
        }

        #endregion 列舉

        #region 屬性

        #region 控制項文字
        /// <summary>
        /// Buffer編號
        /// </summary>
        [Category("自訂屬性"), Description("Buffer編號")]
        public string BufferName
        {
            get
            {
                return lblBufferName.Text;
            }
            set
            {
                funUpdate(lblBufferName, value);
                //lblBufferName.Text = value;
            }
        }

        /// <summary>
        /// 站口模式; 1:入庫 2:出庫 3:撿料
        /// </summary>
        [Category("自訂屬性"), Description("站口模式")]
        public enuStnMode StnMode
        {
            get
            {
                return objStnMode;
            }
            set
            {
                objStnMode = value;
                if (((int)objStnMode) != 0)
                {
                    //funUpdate(lblStnMode, ((int)objStnMode).ToString());
                    funUpdate(lblStnMode, ((int)objStnMode).ToString(), Color.Lime);
                }
                else
                {
                    funUpdate(lblStnMode, string.Empty, Color.White);
                }
                //lblStnMode.Text = ((int)objStnMode).ToString();
            }
        }

        /// <summary>
        /// 命令模式; 1:左 3:左右(單板靠左)
        /// </summary>
        [Category("自訂屬性"), Description("命令模式")]
        public enuCmdMode CmdMode
        {
            get
            {
                return objCmdMode;
            }
            set
            {
                objCmdMode = value;
                funUpdate(lblManual, ((int)objCmdMode).ToString());
                //lblCmdMode.Text = ((int)objCmdMode).ToString();
            }
        }

        /// <summary>
        /// 左序號
        /// </summary>
        [Category("自訂屬性"), Description("左序號")]
        public string LeftCmdSno
        {
            get
            {
                return lblCmdSno.Text;
            }
            set
            {
                funUpdate(lblCmdSno, value);
                //lblLeftCmdSno.Text = value;
            }
        }

        /// <summary>
        /// 站口模式切換 0:不可切換,1:可切換
        /// </summary>
        [Category("自訂屬性"), Description("站口模式切換")]
        public enuStnChange StnChange
        {
            get
            {
                return  objStnChange;
            }
            set
            {
                objStnChange = value;
                if (((int)objStnChange) != 0)
                {
                    funUpdate(lblStnChanges, ((int)objStnChange).ToString(), Color.Lime);
                }
                else
                {
                    funUpdate(lblStnChanges, string.Empty, Color.White);
                }
                //lblRightCmdSno.Text = value;
            }
        }

        /// <summary>
        /// Ready; 0:NO READY 1:入庫READY 2:出庫READY
        /// </summary>
        [Category("自訂屬性"), Description("Ready")]
        public enuReady Ready
        {
            get
            {
                return objReady;
            }
            set
            {
                objReady = value;
                if (((int)objReady) != 0)
                {
                    funUpdate(lblReady, ((int)objReady).ToString(), Color.Lime);
                }
                else
                {
                    funUpdate(lblReady,string.Empty , Color.White);
                }
                //lblReady.Text = ((int)objReady).ToString();
            }
        }

        /// <summary>
        /// 讀取通知; 0:無 , 1:通知PC讀取 , 2:板號正確 , 3:板號錯誤
        /// </summary>
        [Category("自訂屬性"), Description("讀取通知")]
        public enuReadNotice ReadNotice
        {
            get
            {
                return objReadNotice;
            }
            set
            {
                objReadNotice = value;
                if (((int)objReadNotice) == 1)//通知PC讀取
                {
                    funUpdate(lblReadNotice, "1", Color.Lime);
                }
                else if (((int)objReadNotice) == 2)//板號正確
                {
                    funUpdate(lblReadNotice, "2", Color.Lime);
                }
                else if (((int)objReadNotice) == 3)//板號錯誤
                {
                    funUpdate(lblReadNotice, "3", Color.Lime);
                }
                else
                {
                    funUpdate(lblReadNotice, string.Empty, Color.White);
                }
                //lblReadNotice.Text = ((int)objReadNotice).ToString();
            }
        }

        /// <summary>
        /// 功能通知; 0:無 1:棧板荷有
        /// </summary>
        [Category("自訂屬性"), Description("功能通知")]
        

        public bool FunNotice
        {
            get
            {
                return bolFunNotice;
            }
            set
            {
                bolFunNotice = value;
                if (bolFunNotice)
                {
                    funUpdate(lblFunNotice, "v", Color.Lime);
                }
                else
                {
                    funUpdate(lblFunNotice, string.Empty, Color.White);
                }
            }
        }


        /// <summary>
        /// 錯誤
        /// </summary>
        [Category("自訂屬性"), Description("Error")]
        public string Error
        {
            get
            {
                return strError;
            }
            set
            {
                strError = value;
                if (string.IsNullOrWhiteSpace(strError) || strError=="0")
                {
                    funUpdate(lblError, string.Empty, Color.FloralWhite);
                    BufferNameColor = Color.Green;

                    //lblError.Text = string.Empty;
                    //lblError.BackColor = Color.White;
                }
                else
                {
                    funUpdate(lblError, strError, Color.Red);
                    //lblError.Text = "X";
                    //lblError.BackColor = BufferNameColor = Color.Red;
                    
                }
            }
        }

        /// <summary>
        /// 站口模式碼:荷有(左)
        /// </summary>
        [Category("自訂屬性"), Description("荷有(左)")]
        public bool CargoLoad
        {
            get
            {
                return bolCargoLoad;
            }
            set
            {
                bolCargoLoad = value;
                if(bolCargoLoad)
                {
                    funUpdate(lblCargoLoad, "v", Color.Lime);
                    //lblCargoLoad.Text = "v";
                    //lblCargoLoad.BackColor = Color.Blue;
                }
                else
                {
                    funUpdate(lblCargoLoad, string.Empty, Color.White);
                    //lblCargoLoad.Text = string.Empty;
                    //lblCargoLoad.BackColor = Color.White;
                }
            }
        }

        /// <summary>
        /// 站口模式碼:荷有(右)
        /// </summary>
        [Category("自訂屬性"), Description("荷有(右)")]
        public bool RightLoad
        {
            get
            {
                return bolRightLoad;
            }
            set
            {
                bolRightLoad = value;
                if (bolRightLoad)
                {
                    funUpdate(lblAuto, "v", Color.Lime);
                    //lblAuto.Text = "v";
                    //lblRightLoad.BackColor = Color.Blue;
                }
                else
                {
                    funUpdate(lblAuto, string.Empty, Color.White);
                    //lblRightLoad.Text = string.Empty;
                    //lblRightLoad.BackColor = Color.White;
                }
            }
           
        }

        /// <summary>
        /// 荷姿超寬超高 
        /// </summary>
        [Category("自訂屬性"), Description("荷姿超寬超高")]
        public enuOverSize OverSize
        {
           get
            {
                return objOverSize;
            }
            set
            {
                objOverSize = value;
                if (((int)objOverSize) != 0)
                {
                    funUpdate(lblOverSize, ((int)objOverSize).ToString(), Color.Lime);
                }
                else
                {
                    funUpdate(lblOverSize, string.Empty, Color.White);
                }
            }
        }

        /// <summary>
        /// 自動 
        /// </summary>
        [Category("自訂屬性"), Description("自動")]
        public bool Auto
        {
            get
            {
                return bolAuto;
            }
            set
            {
                bolAuto = value;
                if (bolAuto)
                {
                    funUpdate(lblAuto, "v", Color.Lime);
                }
                else
                {
                    funUpdate(lblAuto, string.Empty, Color.White);
                }
            }

        }

        /// <summary>
        /// 手動 
        /// </summary>
        [Category("自訂屬性"), Description("手動")]
        public bool Manual
        {
            get
            {
                return bolManual;
            }
            set
            {
                bolManual = value;
                if (bolManual)
                {
                    funUpdate(lblManual, "v", Color.Lime);
                }
                else
                {
                    funUpdate(lblManual, string.Empty, Color.White);
                }
            }

        }

        #endregion 控制項文字

        #region 控制項背景顏色
        /// <summary>
        /// Buffer編號背景顏色
        /// </summary>
        [Category("自訂屬性"), Description("Buffer編號背景顏色")]
        public Color BufferNameColor
        {
            get
            {
                return lblBufferName.BackColor;
            }
            set
            {
                funUpdate(lblBufferName, value);
                //lblBufferName.BackColor = value;
            }
        }

        /// <summary>
        /// 站口模式背景顏色
        /// </summary>
        [Category("自訂屬性"), Description("站口模式背景顏色")]
        public Color StnModeColor
        {
            get
            {
                return lblStnMode.BackColor;
            }
            set
            {
                funUpdate(lblStnMode, value);
                //lblStnMode.BackColor = value;
            }
        }

        /// <summary>
        /// 命令模式背景顏色
        /// </summary>
        [Category("自訂屬性"), Description("命令模式背景顏色")]
        public Color CmdModeColor
        {
            get
            {
                return lblManual.BackColor;
            }
            set
            {
                funUpdate(lblManual, value);
                //lblCmdMode.BackColor = value;
            }
        }

        /// <summary>
        /// 左序號背景顏色
        /// </summary>
        [Category("自訂屬性"), Description("左序號背景顏色")]
        public Color LeftCmdSnoColor
        {
            get
            {
                return lblCmdSno.BackColor;
            }
            set
            {
                funUpdate(lblCmdSno, value);
                //lblLeftCmdSno.BackColor = value;
            }
        }

        /// <summary>
        /// 右序號背景顏色
        /// </summary>
        [Category("自訂屬性"), Description("右序號背景顏色")]
        public Color RightCmdSnoColor
        {
            get
            {
                return lblStnChanges.BackColor;
            }
            set
            {
                funUpdate(lblStnChanges, value);
                //lblRightCmdSno.BackColor = value;
            }
        }

        /// <summary>
        /// Ready背景顏色
        /// </summary>
        [Category("自訂屬性"), Description("Ready背景顏色")]
        public Color ReadyColor
        {
            get
            {
                return lblReady.BackColor;
            }
            set
            {
                funUpdate(lblReady, value);
                //lblReady.BackColor = value;
            }
        }

        /// <summary>
        /// 讀取通知背景顏色
        /// </summary>
        [Category("自訂屬性"), Description("讀取通知背景顏色")]
        public Color ReadNoticeColor
        {
            get
            {
                return lblReadNotice.BackColor;
            }
            set
            {
                funUpdate(lblReadNotice, value);
                //lblReadNotice.BackColor = value;
            }
        }

        /// <summary>
        /// PC初始通知背景顏色
        /// </summary>
        [Category("自訂屬性"), Description("PC初始通知背景顏色")]
        public Color FunNoticeColor
        {
            get
            {
                return lblFunNotice.BackColor;
            }
            set
            {
                funUpdate(lblFunNotice, value);
            }
        }
        #endregion 控制項背景顏色

        #endregion 屬性

        #region 建構函式
        /// <summary>
        /// 初始化 Mirle.WinPLCCommu.uclBuffer 類別的新執行個體
        /// </summary>
        public uclBuffer()
        {
            InitializeComponent();

            funInitToolTip();
            funInit();
        }
        #endregion 建構函式

        #region 事件
        /// <summary>
        /// 表示 uclBuffer 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uclBuffer_Click(object sender, EventArgs e)
        {
            if(uclBufferClick != null)
                uclBufferClick(this, e);
        }
        #endregion 事件

        #region 私用方法
        /// <summary>
        /// 初始化ToolTip
        /// </summary>
        private void funInitToolTip()
        {
            string strBufferName = "Buffer編號";
            string strStnMode = "站口模式:1入庫:2出庫";
            //string strCmdMode = "命令模式";
            string strLeftCmdSno = "序號";
            string strReady = "1入庫Ready:2出庫Ready";
            string strReadNotice = "讀取通知";
            string strFunNotice = "功能通知:棧板荷有";
            string strError = "Error Code";
            string strtLoad = "貨物荷有";
            string strOverSize = "荷姿超寬超高";
            string strStnChange = "站口模式切換";
            string strAuto = "自動";
            string strManual = "手動";

            ToolTip objToolTip = new ToolTip();
            objToolTip.AutoPopDelay = 5000;
            objToolTip.InitialDelay = 100;
            objToolTip.ReshowDelay = 100;
            objToolTip.UseAnimation = false;
            objToolTip.UseFading = false;
            objToolTip.ShowAlways = true;

            //-大立光--------------------------------------------
            objToolTip.SetToolTip(lblBufferName, strBufferName);
            objToolTip.SetToolTip(lblCmdSno, strLeftCmdSno);
            objToolTip.SetToolTip(lblStnMode,strStnMode);
            //objToolTip.SetToolTip(lblCmdMode, strCmdMode);
            objToolTip.SetToolTip(lblReady,strReady);
            objToolTip.SetToolTip(lblError, strError);
            objToolTip.SetToolTip(lblReadNotice, strReadNotice);
            objToolTip.SetToolTip(lblFunNotice, strFunNotice);
            objToolTip.SetToolTip(lblStnChanges, strStnChange);
            objToolTip.SetToolTip(lblOverSize, strOverSize);
            objToolTip.SetToolTip(lblCargoLoad, strtLoad);
            objToolTip.SetToolTip(lblAuto,strAuto);
            objToolTip.SetToolTip(lblManual,strManual);
            //---------------------------------------------------
            //objToolTip.SetToolTip(lblBufferName, strBufferName);
            //objToolTip.SetToolTip(lblStnMode, strStnMode);
            //objToolTip.SetToolTip(lblCmdMode, strCmdMode);
            //objToolTip.SetToolTip(lblLeftCmdSno, strLeftCmdSno);
            //objToolTip.SetToolTip(lblStnChanges, strRightCmdSno);
            //objToolTip.SetToolTip(lblReady, strReady);
            //objToolTip.SetToolTip(lblReadNotice, strReadNotice);
            //objToolTip.SetToolTip(lblFunNotice, strFunNotice);
            //objToolTip.SetToolTip(lblError, strError);
            //objToolTip.SetToolTip(lblCargoLoad, strCargoLoad);
            //objToolTip.SetToolTip(lblRightLoad, strRightLoad);
        }

        /// <summary>
        /// 初始化物件
        /// </summary>
        private void funInit()
        {
            lblBufferName.BackColor = Color.Green;
            lblStnChanges.BackColor = Color.White;
            lblCmdSno.BackColor = Color.White;
            lblStnMode.BackColor = Color.SpringGreen;
            lblManual.BackColor = Color.White;
            lblReady.BackColor = Color.LightSkyBlue;
            lblReadNotice.BackColor = Color.Gold;
            lblFunNotice.BackColor = Color.DarkGray;
            lblCargoLoad.BackColor = Color.White;
            lblAuto.BackColor = Color.White;
            lblError.BackColor = Color.White;

            lblBufferName.Text = "BufName";
            lblStnChanges.Text = string.Empty;
            lblCmdSno.Text = string.Empty;
            lblStnMode.Text = lblReady.Text = lblReadNotice.Text = lblFunNotice.Text = lblCargoLoad.Text = lblAuto.Text = "0";

            tlpBuffer.Size = new Size(this.Size.Width - 6, this.Size.Height - 6);
        }

        #region funUpdate
        private void funUpdate(Label label, string Value)
        {
            if(this.InvokeRequired)
            {
                delUpdate Update = new delUpdate(funUpdate);
                this.Invoke(Update, label, Value);
            }
            else
                label.Text = Value;
        }
        private void funUpdate(Label label, string Value, Color color)
        {
            if(this.InvokeRequired)
            {
                delUpdateWithColor Update = new delUpdateWithColor(funUpdate);
                this.Invoke(Update, label, Value, color);
            }
            else
            {
                label.Text = Value;
                label.BackColor = color;
            }
        }
        private void funUpdate(Label label, Color color)
        {
            if(this.InvokeRequired)
            {
                delUpdateOnlyColor Update = new delUpdateOnlyColor(funUpdate);
                this.Invoke(Update, label, color);
            }
            else
                label.BackColor = color;
        }
        #endregion funUpdate

        #endregion 私用方法

        #region 公用方法
        /// <summary>
        /// 當PLC讀取失敗或斷線時使用
        /// </summary>
        public void funReadPLCError()
        {
            StnMode = enuStnMode.None;
            //CmdMode = enuCmdMode.None;
            LeftCmdSno  = "XXXXX";
            Ready = enuReady.NoReady;
            ReadNotice = enuReadNotice.None;
            FunNotice = false;
            Error = "X";
            CargoLoad = RightLoad = false;
            Auto = false;
            Manual = false;
        }
        #endregion 公用方法
    }
}
