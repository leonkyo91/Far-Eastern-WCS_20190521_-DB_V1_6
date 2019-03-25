namespace Mirle.WinPLCCommu
{
    partial class frmWinPLCCommu
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWinPLCCommu));
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblDBStsLable = new System.Windows.Forms.Label();
            this.lblMPLC1Sts = new System.Windows.Forms.Label();
            this.tlpMainTop = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCraneSts = new System.Windows.Forms.TableLayoutPanel();
            this.lblCrane1Sts = new System.Windows.Forms.Label();
            this.lblCrane1Mode = new System.Windows.Forms.Label();
            this.lblCrane1StsLable = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.tlpPLCSts = new System.Windows.Forms.TableLayoutPanel();
            this.lblMPLC3Sts = new System.Windows.Forms.Label();
            this.lblMPLC2Sts = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMPLC1StsLable = new System.Windows.Forms.Label();
            this.tlpMainSts = new System.Windows.Forms.TableLayoutPanel();
            this.btnPLCModify = new System.Windows.Forms.Button();
            this.txtBuffrtInfo = new System.Windows.Forms.Button();
            this.lblCmuSts = new System.Windows.Forms.Label();
            this.lblCmuStsLabel = new System.Windows.Forms.Label();
            this.lblDBSts = new System.Windows.Forms.Label();
            this.nfiMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tslShowASRSCommunication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslCloseASRSCommunication = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpASRS_A = new System.Windows.Forms.TabPage();
            this.tlpASRS_A = new System.Windows.Forms.TableLayoutPanel();
            this.uclBuffer_A01_1_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_1_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_2_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_2_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_3_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_3_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_4_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_4_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbA02 = new System.Windows.Forms.PictureBox();
            this.ptbA04 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_A01_5_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_5_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_6_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_A01_6_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbA06 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbA01 = new System.Windows.Forms.PictureBox();
            this.ptbA03 = new System.Windows.Forms.PictureBox();
            this.ptbA05 = new System.Windows.Forms.PictureBox();
            this.tbpSystem = new System.Windows.Forms.TabPage();
            this.sctSystem = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBCR = new System.Windows.Forms.TextBox();
            this.chkWeight = new System.Windows.Forms.CheckBox();
            this.chkBCR = new System.Windows.Forms.CheckBox();
            this.gpbCommand = new System.Windows.Forms.GroupBox();
            this.btnAutoPause = new System.Windows.Forms.Button();
            this.btnCraneCommand = new System.Windows.Forms.Button();
            this.gpbConnection = new System.Windows.Forms.GroupBox();
            this.btnReconnectWeight = new System.Windows.Forms.Button();
            this.chkAutoReconnect = new System.Windows.Forms.CheckBox();
            this.btnReconnectPLC = new System.Windows.Forms.Button();
            this.btnReconnectDB = new System.Windows.Forms.Button();
            this.tbcTrace = new System.Windows.Forms.TabControl();
            this.tbpSystemTrace = new System.Windows.Forms.TabPage();
            this.lsbSystemTrace = new System.Windows.Forms.ListBox();
            this.tbpMPLC = new System.Windows.Forms.TabPage();
            this.lsbMPLC = new System.Windows.Forms.ListBox();
            this.tbpAlarmList = new System.Windows.Forms.TabPage();
            this.lsbAlarmList = new System.Windows.Forms.ListBox();
            this.tlpMainTop.SuspendLayout();
            this.tlpCraneSts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tlpPLCSts.SuspendLayout();
            this.tlpMainSts.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tbpASRS_A.SuspendLayout();
            this.tlpASRS_A.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA05)).BeginInit();
            this.tbpSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sctSystem)).BeginInit();
            this.sctSystem.Panel1.SuspendLayout();
            this.sctSystem.Panel2.SuspendLayout();
            this.sctSystem.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpbCommand.SuspendLayout();
            this.gpbConnection.SuspendLayout();
            this.tbcTrace.SuspendLayout();
            this.tbpSystemTrace.SuspendLayout();
            this.tbpMPLC.SuspendLayout();
            this.tbpAlarmList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(1227, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(124, 29);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.White;
            this.lblDateTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(0, 58);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(200, 29);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "yyyy-MM-dd hh:mm:ss";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDBStsLable
            // 
            this.lblDBStsLable.AutoSize = true;
            this.lblDBStsLable.BackColor = System.Drawing.Color.Black;
            this.lblDBStsLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDBStsLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDBStsLable.ForeColor = System.Drawing.Color.White;
            this.lblDBStsLable.Location = new System.Drawing.Point(0, 0);
            this.lblDBStsLable.Margin = new System.Windows.Forms.Padding(0);
            this.lblDBStsLable.Name = "lblDBStsLable";
            this.lblDBStsLable.Size = new System.Drawing.Size(100, 29);
            this.lblDBStsLable.TabIndex = 1;
            this.lblDBStsLable.Text = "DB Sts";
            this.lblDBStsLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMPLC1Sts
            // 
            this.lblMPLC1Sts.AutoSize = true;
            this.lblMPLC1Sts.BackColor = System.Drawing.Color.Red;
            this.lblMPLC1Sts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMPLC1Sts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMPLC1Sts.Location = new System.Drawing.Point(0, 29);
            this.lblMPLC1Sts.Margin = new System.Windows.Forms.Padding(0);
            this.lblMPLC1Sts.Name = "lblMPLC1Sts";
            this.lblMPLC1Sts.Size = new System.Drawing.Size(118, 29);
            this.lblMPLC1Sts.TabIndex = 6;
            this.lblMPLC1Sts.Text = "None";
            this.lblMPLC1Sts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMainTop
            // 
            this.tlpMainTop.AutoSize = true;
            this.tlpMainTop.ColumnCount = 3;
            this.tlpMainTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMainTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tlpMainTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpMainTop.Controls.Add(this.tlpCraneSts, 1, 0);
            this.tlpMainTop.Controls.Add(this.picLogo, 0, 0);
            this.tlpMainTop.Controls.Add(this.tlpPLCSts, 2, 0);
            this.tlpMainTop.Controls.Add(this.lblDateTime, 0, 2);
            this.tlpMainTop.Controls.Add(this.tlpMainSts, 1, 2);
            this.tlpMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMainTop.Location = new System.Drawing.Point(0, 0);
            this.tlpMainTop.Name = "tlpMainTop";
            this.tlpMainTop.RowCount = 3;
            this.tlpMainTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpMainTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpMainTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpMainTop.Size = new System.Drawing.Size(1554, 87);
            this.tlpMainTop.TabIndex = 0;
            // 
            // tlpCraneSts
            // 
            this.tlpCraneSts.AutoSize = true;
            this.tlpCraneSts.ColumnCount = 2;
            this.tlpCraneSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCraneSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCraneSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCraneSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCraneSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCraneSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCraneSts.Controls.Add(this.lblCrane1Sts, 1, 1);
            this.tlpCraneSts.Controls.Add(this.lblCrane1Mode, 0, 1);
            this.tlpCraneSts.Controls.Add(this.lblCrane1StsLable, 0, 0);
            this.tlpCraneSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCraneSts.Location = new System.Drawing.Point(200, 0);
            this.tlpCraneSts.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCraneSts.Name = "tlpCraneSts";
            this.tlpCraneSts.RowCount = 2;
            this.tlpMainTop.SetRowSpan(this.tlpCraneSts, 2);
            this.tlpCraneSts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCraneSts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCraneSts.Size = new System.Drawing.Size(1259, 58);
            this.tlpCraneSts.TabIndex = 0;
            // 
            // lblCrane1Sts
            // 
            this.lblCrane1Sts.AutoSize = true;
            this.lblCrane1Sts.BackColor = System.Drawing.Color.Red;
            this.lblCrane1Sts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCrane1Sts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrane1Sts.ForeColor = System.Drawing.Color.Black;
            this.lblCrane1Sts.Location = new System.Drawing.Point(629, 29);
            this.lblCrane1Sts.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrane1Sts.Name = "lblCrane1Sts";
            this.lblCrane1Sts.Size = new System.Drawing.Size(630, 29);
            this.lblCrane1Sts.TabIndex = 11;
            this.lblCrane1Sts.Text = "X";
            this.lblCrane1Sts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCrane1Mode
            // 
            this.lblCrane1Mode.AutoSize = true;
            this.lblCrane1Mode.BackColor = System.Drawing.Color.Red;
            this.lblCrane1Mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCrane1Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrane1Mode.ForeColor = System.Drawing.Color.Black;
            this.lblCrane1Mode.Location = new System.Drawing.Point(0, 29);
            this.lblCrane1Mode.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrane1Mode.Name = "lblCrane1Mode";
            this.lblCrane1Mode.Size = new System.Drawing.Size(629, 29);
            this.lblCrane1Mode.TabIndex = 10;
            this.lblCrane1Mode.Text = "X";
            this.lblCrane1Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCrane1StsLable
            // 
            this.lblCrane1StsLable.AutoSize = true;
            this.lblCrane1StsLable.BackColor = System.Drawing.Color.Black;
            this.lblCrane1StsLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tlpCraneSts.SetColumnSpan(this.lblCrane1StsLable, 2);
            this.lblCrane1StsLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrane1StsLable.ForeColor = System.Drawing.Color.White;
            this.lblCrane1StsLable.Location = new System.Drawing.Point(0, 0);
            this.lblCrane1StsLable.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrane1StsLable.Name = "lblCrane1StsLable";
            this.lblCrane1StsLable.Size = new System.Drawing.Size(1259, 29);
            this.lblCrane1StsLable.TabIndex = 9;
            this.lblCrane1StsLable.Text = "Crane1 Sts";
            this.lblCrane1StsLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = global::Mirle.WinPLCCommu.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(0);
            this.picLogo.Name = "picLogo";
            this.tlpMainTop.SetRowSpan(this.picLogo, 2);
            this.picLogo.Size = new System.Drawing.Size(200, 58);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // tlpPLCSts
            // 
            this.tlpPLCSts.AutoSize = true;
            this.tlpPLCSts.ColumnCount = 3;
            this.tlpPLCSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPLCSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpPLCSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpPLCSts.Controls.Add(this.lblMPLC3Sts, 2, 1);
            this.tlpPLCSts.Controls.Add(this.lblMPLC2Sts, 1, 1);
            this.tlpPLCSts.Controls.Add(this.label11, 2, 0);
            this.tlpPLCSts.Controls.Add(this.label10, 1, 0);
            this.tlpPLCSts.Controls.Add(this.lblMPLC1Sts, 0, 1);
            this.tlpPLCSts.Controls.Add(this.lblMPLC1StsLable, 0, 0);
            this.tlpPLCSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPLCSts.Location = new System.Drawing.Point(1459, 0);
            this.tlpPLCSts.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPLCSts.Name = "tlpPLCSts";
            this.tlpPLCSts.RowCount = 2;
            this.tlpMainTop.SetRowSpan(this.tlpPLCSts, 2);
            this.tlpPLCSts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPLCSts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPLCSts.Size = new System.Drawing.Size(95, 58);
            this.tlpPLCSts.TabIndex = 13;
            // 
            // lblMPLC3Sts
            // 
            this.lblMPLC3Sts.AutoSize = true;
            this.lblMPLC3Sts.BackColor = System.Drawing.Color.Red;
            this.lblMPLC3Sts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMPLC3Sts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMPLC3Sts.Location = new System.Drawing.Point(123, 29);
            this.lblMPLC3Sts.Margin = new System.Windows.Forms.Padding(0);
            this.lblMPLC3Sts.Name = "lblMPLC3Sts";
            this.lblMPLC3Sts.Size = new System.Drawing.Size(5, 29);
            this.lblMPLC3Sts.TabIndex = 12;
            this.lblMPLC3Sts.Text = "None";
            this.lblMPLC3Sts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMPLC2Sts
            // 
            this.lblMPLC2Sts.AutoSize = true;
            this.lblMPLC2Sts.BackColor = System.Drawing.Color.Red;
            this.lblMPLC2Sts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMPLC2Sts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMPLC2Sts.Location = new System.Drawing.Point(118, 29);
            this.lblMPLC2Sts.Margin = new System.Windows.Forms.Padding(0);
            this.lblMPLC2Sts.Name = "lblMPLC2Sts";
            this.lblMPLC2Sts.Size = new System.Drawing.Size(5, 29);
            this.lblMPLC2Sts.TabIndex = 11;
            this.lblMPLC2Sts.Text = "None";
            this.lblMPLC2Sts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(123, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(5, 29);
            this.label11.TabIndex = 10;
            this.label11.Text = "MPLC3";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(118, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(5, 29);
            this.label10.TabIndex = 9;
            this.label10.Text = "MPLC2";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMPLC1StsLable
            // 
            this.lblMPLC1StsLable.AutoSize = true;
            this.lblMPLC1StsLable.BackColor = System.Drawing.Color.Black;
            this.lblMPLC1StsLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMPLC1StsLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMPLC1StsLable.ForeColor = System.Drawing.Color.White;
            this.lblMPLC1StsLable.Location = new System.Drawing.Point(0, 0);
            this.lblMPLC1StsLable.Margin = new System.Windows.Forms.Padding(0);
            this.lblMPLC1StsLable.Name = "lblMPLC1StsLable";
            this.lblMPLC1StsLable.Size = new System.Drawing.Size(118, 29);
            this.lblMPLC1StsLable.TabIndex = 8;
            this.lblMPLC1StsLable.Text = "MPLC1";
            this.lblMPLC1StsLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMainSts
            // 
            this.tlpMainSts.AutoSize = true;
            this.tlpMainSts.ColumnCount = 8;
            this.tlpMainTop.SetColumnSpan(this.tlpMainSts, 2);
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMainSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMainSts.Controls.Add(this.btnPLCModify, 5, 0);
            this.tlpMainSts.Controls.Add(this.txtBuffrtInfo, 6, 0);
            this.tlpMainSts.Controls.Add(this.btnExit, 7, 0);
            this.tlpMainSts.Controls.Add(this.lblCmuSts, 3, 0);
            this.tlpMainSts.Controls.Add(this.lblCmuStsLabel, 2, 0);
            this.tlpMainSts.Controls.Add(this.lblDBStsLable, 0, 0);
            this.tlpMainSts.Controls.Add(this.lblDBSts, 1, 0);
            this.tlpMainSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainSts.Location = new System.Drawing.Point(200, 58);
            this.tlpMainSts.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMainSts.Name = "tlpMainSts";
            this.tlpMainSts.RowCount = 1;
            this.tlpMainSts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainSts.Size = new System.Drawing.Size(1354, 29);
            this.tlpMainSts.TabIndex = 14;
            // 
            // btnPLCModify
            // 
            this.btnPLCModify.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPLCModify.Location = new System.Drawing.Point(967, 0);
            this.btnPLCModify.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnPLCModify.Name = "btnPLCModify";
            this.btnPLCModify.Size = new System.Drawing.Size(124, 29);
            this.btnPLCModify.TabIndex = 4;
            this.btnPLCModify.Text = "PLC Modify";
            this.btnPLCModify.UseVisualStyleBackColor = true;
            this.btnPLCModify.Click += new System.EventHandler(this.btnPLCModify_Click);
            // 
            // txtBuffrtInfo
            // 
            this.txtBuffrtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuffrtInfo.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBuffrtInfo.Location = new System.Drawing.Point(1097, 0);
            this.txtBuffrtInfo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtBuffrtInfo.Name = "txtBuffrtInfo";
            this.txtBuffrtInfo.Size = new System.Drawing.Size(124, 29);
            this.txtBuffrtInfo.TabIndex = 11;
            this.txtBuffrtInfo.Text = "Buffer Info";
            this.txtBuffrtInfo.UseVisualStyleBackColor = true;
            this.txtBuffrtInfo.Click += new System.EventHandler(this.btnBufferInfo_Click);
            // 
            // lblCmuSts
            // 
            this.lblCmuSts.AutoSize = true;
            this.lblCmuSts.BackColor = System.Drawing.Color.Lime;
            this.lblCmuSts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCmuSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCmuSts.ForeColor = System.Drawing.Color.Black;
            this.lblCmuSts.Location = new System.Drawing.Point(300, 0);
            this.lblCmuSts.Margin = new System.Windows.Forms.Padding(0);
            this.lblCmuSts.Name = "lblCmuSts";
            this.lblCmuSts.Size = new System.Drawing.Size(100, 29);
            this.lblCmuSts.TabIndex = 13;
            this.lblCmuSts.Text = "Auto";
            this.lblCmuSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCmuStsLabel
            // 
            this.lblCmuStsLabel.AutoSize = true;
            this.lblCmuStsLabel.BackColor = System.Drawing.Color.Black;
            this.lblCmuStsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCmuStsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCmuStsLabel.ForeColor = System.Drawing.Color.White;
            this.lblCmuStsLabel.Location = new System.Drawing.Point(200, 0);
            this.lblCmuStsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.lblCmuStsLabel.Name = "lblCmuStsLabel";
            this.lblCmuStsLabel.Size = new System.Drawing.Size(100, 29);
            this.lblCmuStsLabel.TabIndex = 10;
            this.lblCmuStsLabel.Text = "Cmu Sts";
            this.lblCmuStsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDBSts
            // 
            this.lblDBSts.AutoSize = true;
            this.lblDBSts.BackColor = System.Drawing.Color.Red;
            this.lblDBSts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDBSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDBSts.ForeColor = System.Drawing.Color.Black;
            this.lblDBSts.Location = new System.Drawing.Point(100, 0);
            this.lblDBSts.Margin = new System.Windows.Forms.Padding(0);
            this.lblDBSts.Name = "lblDBSts";
            this.lblDBSts.Size = new System.Drawing.Size(100, 29);
            this.lblDBSts.TabIndex = 12;
            this.lblDBSts.Text = "None";
            this.lblDBSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nfiMain
            // 
            this.nfiMain.ContextMenuStrip = this.cmsMain;
            this.nfiMain.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiMain.Icon")));
            this.nfiMain.Text = "Mirle AS/RS Communication";
            this.nfiMain.DoubleClick += new System.EventHandler(this.nfiMain_DoubleClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslShowASRSCommunication,
            this.toolStripSeparator1,
            this.tslCloseASRSCommunication});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(237, 54);
            // 
            // tslShowASRSCommunication
            // 
            this.tslShowASRSCommunication.Name = "tslShowASRSCommunication";
            this.tslShowASRSCommunication.Size = new System.Drawing.Size(236, 22);
            this.tslShowASRSCommunication.Text = "Show AS/RS Communication";
            this.tslShowASRSCommunication.Click += new System.EventHandler(this.tslShowASRSCommunication_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(233, 6);
            // 
            // tslCloseASRSCommunication
            // 
            this.tslCloseASRSCommunication.Name = "tslCloseASRSCommunication";
            this.tslCloseASRSCommunication.Size = new System.Drawing.Size(236, 22);
            this.tslCloseASRSCommunication.Text = "Close AS/RS Communication";
            this.tslCloseASRSCommunication.Click += new System.EventHandler(this.tslCloseASRSCommunication_Click);
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpASRS_A);
            this.tbcMain.Controls.Add(this.tbpSystem);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcMain.Location = new System.Drawing.Point(0, 87);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1554, 503);
            this.tbcMain.TabIndex = 1;
            // 
            // tbpASRS_A
            // 
            this.tbpASRS_A.AutoScroll = true;
            this.tbpASRS_A.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpASRS_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpASRS_A.Controls.Add(this.tlpASRS_A);
            this.tbpASRS_A.Location = new System.Drawing.Point(4, 27);
            this.tbpASRS_A.Name = "tbpASRS_A";
            this.tbpASRS_A.Padding = new System.Windows.Forms.Padding(3);
            this.tbpASRS_A.Size = new System.Drawing.Size(1546, 472);
            this.tbpASRS_A.TabIndex = 0;
            this.tbpASRS_A.Text = " ASRS 2F(A區)";
            // 
            // tlpASRS_A
            // 
            this.tlpASRS_A.ColumnCount = 13;
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.32753F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.059235F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.059235F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpASRS_A.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.554F));
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_1_1, 1, 3);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_1_L, 1, 2);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_2_L, 3, 2);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_2_1, 3, 3);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_3_L, 5, 2);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_3_1, 5, 3);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_4_L, 7, 2);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_4_1, 7, 3);
            this.tlpASRS_A.Controls.Add(this.ptbA02, 3, 4);
            this.tlpASRS_A.Controls.Add(this.ptbA04, 7, 4);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_5_1, 9, 3);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_5_L, 9, 2);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_6_1, 11, 3);
            this.tlpASRS_A.Controls.Add(this.uclBuffer_A01_6_L, 11, 2);
            this.tlpASRS_A.Controls.Add(this.ptbA06, 11, 4);
            this.tlpASRS_A.Controls.Add(this.label3, 2, 1);
            this.tlpASRS_A.Controls.Add(this.label2, 6, 1);
            this.tlpASRS_A.Controls.Add(this.label1, 10, 1);
            this.tlpASRS_A.Controls.Add(this.ptbA01, 1, 4);
            this.tlpASRS_A.Controls.Add(this.ptbA03, 5, 4);
            this.tlpASRS_A.Controls.Add(this.ptbA05, 9, 4);
            this.tlpASRS_A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpASRS_A.Location = new System.Drawing.Point(3, 3);
            this.tlpASRS_A.Name = "tlpASRS_A";
            this.tlpASRS_A.RowCount = 7;
            this.tlpASRS_A.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpASRS_A.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpASRS_A.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpASRS_A.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpASRS_A.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpASRS_A.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpASRS_A.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpASRS_A.Size = new System.Drawing.Size(1536, 462);
            this.tlpASRS_A.TabIndex = 0;
            // 
            // uclBuffer_A01_1_1
            // 
            this.uclBuffer_A01_1_1.Auto = false;
            this.uclBuffer_A01_1_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_1_1.BufferName = "A01-1-1";
            this.uclBuffer_A01_1_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_1_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_1_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_1_1.Error = "";
            this.uclBuffer_A01_1_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_1_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_1.LeftCmdSno = "";
            this.uclBuffer_A01_1_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_1.LeftLoad = false;
            this.uclBuffer_A01_1_1.Location = new System.Drawing.Point(339, 210);
            this.uclBuffer_A01_1_1.Manual = false;
            this.uclBuffer_A01_1_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_1_1.Name = "uclBuffer_A01_1_1";
            this.uclBuffer_A01_1_1.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_1_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_1_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_1_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_1.RightLoad = false;
            this.uclBuffer_A01_1_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_1_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_1_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_1_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_1.TabIndex = 0;
            // 
            // uclBuffer_A01_1_L
            // 
            this.uclBuffer_A01_1_L.Auto = false;
            this.uclBuffer_A01_1_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_1_L.BufferName = "A01-1-L";
            this.uclBuffer_A01_1_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_1_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_1_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_1_L.Error = "";
            this.uclBuffer_A01_1_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_1_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_L.LeftCmdSno = "";
            this.uclBuffer_A01_1_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_L.LeftLoad = false;
            this.uclBuffer_A01_1_L.Location = new System.Drawing.Point(339, 142);
            this.uclBuffer_A01_1_L.Manual = false;
            this.uclBuffer_A01_1_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_1_L.Name = "uclBuffer_A01_1_L";
            this.uclBuffer_A01_1_L.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_1_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_1_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_1_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_L.RightLoad = false;
            this.uclBuffer_A01_1_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_1_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_1_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_1_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_1_L.TabIndex = 1;
            // 
            // uclBuffer_A01_2_L
            // 
            this.uclBuffer_A01_2_L.Auto = false;
            this.uclBuffer_A01_2_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_2_L.BufferName = "A01-2-L";
            this.uclBuffer_A01_2_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_2_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_2_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_2_L.Error = "";
            this.uclBuffer_A01_2_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_2_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_L.LeftCmdSno = "";
            this.uclBuffer_A01_2_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_L.LeftLoad = false;
            this.uclBuffer_A01_2_L.Location = new System.Drawing.Point(470, 142);
            this.uclBuffer_A01_2_L.Manual = false;
            this.uclBuffer_A01_2_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_2_L.Name = "uclBuffer_A01_2_L";
            this.uclBuffer_A01_2_L.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_2_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_2_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_2_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_L.RightLoad = false;
            this.uclBuffer_A01_2_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_2_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_2_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_2_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_L.TabIndex = 9;
            // 
            // uclBuffer_A01_2_1
            // 
            this.uclBuffer_A01_2_1.Auto = false;
            this.uclBuffer_A01_2_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_2_1.BufferName = "A01-2-1";
            this.uclBuffer_A01_2_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_2_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_2_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_2_1.Error = "";
            this.uclBuffer_A01_2_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_2_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_1.LeftCmdSno = "";
            this.uclBuffer_A01_2_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_1.LeftLoad = false;
            this.uclBuffer_A01_2_1.Location = new System.Drawing.Point(470, 210);
            this.uclBuffer_A01_2_1.Manual = false;
            this.uclBuffer_A01_2_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_2_1.Name = "uclBuffer_A01_2_1";
            this.uclBuffer_A01_2_1.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_2_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_2_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_2_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_1.RightLoad = false;
            this.uclBuffer_A01_2_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_2_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_2_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_2_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_2_1.TabIndex = 10;
            // 
            // uclBuffer_A01_3_L
            // 
            this.uclBuffer_A01_3_L.Auto = false;
            this.uclBuffer_A01_3_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_3_L.BufferName = "A01-3-L";
            this.uclBuffer_A01_3_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_3_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_3_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_3_L.Error = "";
            this.uclBuffer_A01_3_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_3_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_L.LeftCmdSno = "";
            this.uclBuffer_A01_3_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_L.LeftLoad = false;
            this.uclBuffer_A01_3_L.Location = new System.Drawing.Point(636, 142);
            this.uclBuffer_A01_3_L.Manual = false;
            this.uclBuffer_A01_3_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_3_L.Name = "uclBuffer_A01_3_L";
            this.uclBuffer_A01_3_L.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_3_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_3_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_3_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_L.RightLoad = false;
            this.uclBuffer_A01_3_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_3_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_3_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_3_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_L.TabIndex = 12;
            // 
            // uclBuffer_A01_3_1
            // 
            this.uclBuffer_A01_3_1.Auto = false;
            this.uclBuffer_A01_3_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_3_1.BufferName = "A01-3-1";
            this.uclBuffer_A01_3_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_3_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_3_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_3_1.Error = "";
            this.uclBuffer_A01_3_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_3_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_1.LeftCmdSno = "";
            this.uclBuffer_A01_3_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_1.LeftLoad = false;
            this.uclBuffer_A01_3_1.Location = new System.Drawing.Point(636, 210);
            this.uclBuffer_A01_3_1.Manual = false;
            this.uclBuffer_A01_3_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_3_1.Name = "uclBuffer_A01_3_1";
            this.uclBuffer_A01_3_1.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_3_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_3_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_3_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_1.RightLoad = false;
            this.uclBuffer_A01_3_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_3_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_3_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_3_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_3_1.TabIndex = 11;
            // 
            // uclBuffer_A01_4_L
            // 
            this.uclBuffer_A01_4_L.Auto = false;
            this.uclBuffer_A01_4_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_4_L.BufferName = "A01-4-L";
            this.uclBuffer_A01_4_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_4_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_4_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_4_L.Error = "";
            this.uclBuffer_A01_4_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_4_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_L.LeftCmdSno = "";
            this.uclBuffer_A01_4_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_L.LeftLoad = false;
            this.uclBuffer_A01_4_L.Location = new System.Drawing.Point(767, 142);
            this.uclBuffer_A01_4_L.Manual = false;
            this.uclBuffer_A01_4_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_4_L.Name = "uclBuffer_A01_4_L";
            this.uclBuffer_A01_4_L.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_4_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_4_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_4_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_L.RightLoad = false;
            this.uclBuffer_A01_4_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_4_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_4_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_4_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_L.TabIndex = 20;
            // 
            // uclBuffer_A01_4_1
            // 
            this.uclBuffer_A01_4_1.Auto = false;
            this.uclBuffer_A01_4_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_4_1.BufferName = "A01-4-1";
            this.uclBuffer_A01_4_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_4_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_4_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_4_1.Error = "";
            this.uclBuffer_A01_4_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_4_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_1.LeftCmdSno = "";
            this.uclBuffer_A01_4_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_1.LeftLoad = false;
            this.uclBuffer_A01_4_1.Location = new System.Drawing.Point(767, 210);
            this.uclBuffer_A01_4_1.Manual = false;
            this.uclBuffer_A01_4_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_4_1.Name = "uclBuffer_A01_4_1";
            this.uclBuffer_A01_4_1.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_4_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_4_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_4_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_1.RightLoad = false;
            this.uclBuffer_A01_4_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_4_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_4_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_4_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_4_1.TabIndex = 21;
            // 
            // ptbA02
            // 
            this.ptbA02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbA02.Image = global::Mirle.WinPLCCommu.Properties.Resources.Top;
            this.ptbA02.Location = new System.Drawing.Point(470, 278);
            this.ptbA02.Margin = new System.Windows.Forms.Padding(0);
            this.ptbA02.Name = "ptbA02";
            this.ptbA02.Size = new System.Drawing.Size(86, 41);
            this.ptbA02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbA02.TabIndex = 60;
            this.ptbA02.TabStop = false;
            this.ptbA02.Tag = "IN";
            this.ptbA02.DoubleClick += new System.EventHandler(this.ptbA02_DoubleClick);
            // 
            // ptbA04
            // 
            this.ptbA04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbA04.Image = ((System.Drawing.Image)(resources.GetObject("ptbA04.Image")));
            this.ptbA04.Location = new System.Drawing.Point(767, 278);
            this.ptbA04.Margin = new System.Windows.Forms.Padding(0);
            this.ptbA04.Name = "ptbA04";
            this.ptbA04.Size = new System.Drawing.Size(86, 41);
            this.ptbA04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbA04.TabIndex = 61;
            this.ptbA04.TabStop = false;
            this.ptbA04.Tag = "IN";
            this.ptbA04.DoubleClick += new System.EventHandler(this.ptbA04_DoubleClick);
            // 
            // uclBuffer_A01_5_1
            // 
            this.uclBuffer_A01_5_1.Auto = false;
            this.uclBuffer_A01_5_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_5_1.BufferName = "A01-5-1";
            this.uclBuffer_A01_5_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_5_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_5_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_5_1.Error = "";
            this.uclBuffer_A01_5_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_5_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_1.LeftCmdSno = "";
            this.uclBuffer_A01_5_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_1.LeftLoad = false;
            this.uclBuffer_A01_5_1.Location = new System.Drawing.Point(933, 210);
            this.uclBuffer_A01_5_1.Manual = false;
            this.uclBuffer_A01_5_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_5_1.Name = "uclBuffer_A01_5_1";
            this.uclBuffer_A01_5_1.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_5_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_5_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_5_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_1.RightLoad = false;
            this.uclBuffer_A01_5_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_5_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_5_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_5_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_1.TabIndex = 26;
            // 
            // uclBuffer_A01_5_L
            // 
            this.uclBuffer_A01_5_L.Auto = false;
            this.uclBuffer_A01_5_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_5_L.BufferName = "A01-5-L";
            this.uclBuffer_A01_5_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_5_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_5_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_5_L.Error = "";
            this.uclBuffer_A01_5_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_5_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_L.LeftCmdSno = "";
            this.uclBuffer_A01_5_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_L.LeftLoad = false;
            this.uclBuffer_A01_5_L.Location = new System.Drawing.Point(933, 142);
            this.uclBuffer_A01_5_L.Manual = false;
            this.uclBuffer_A01_5_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_5_L.Name = "uclBuffer_A01_5_L";
            this.uclBuffer_A01_5_L.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_5_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_5_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_5_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_L.RightLoad = false;
            this.uclBuffer_A01_5_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_5_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_5_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_5_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_5_L.TabIndex = 25;
            // 
            // uclBuffer_A01_6_1
            // 
            this.uclBuffer_A01_6_1.Auto = false;
            this.uclBuffer_A01_6_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_6_1.BufferName = "A01-6-1";
            this.uclBuffer_A01_6_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_6_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_6_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_6_1.Error = "";
            this.uclBuffer_A01_6_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_6_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_1.LeftCmdSno = "";
            this.uclBuffer_A01_6_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_1.LeftLoad = false;
            this.uclBuffer_A01_6_1.Location = new System.Drawing.Point(1064, 210);
            this.uclBuffer_A01_6_1.Manual = false;
            this.uclBuffer_A01_6_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_6_1.Name = "uclBuffer_A01_6_1";
            this.uclBuffer_A01_6_1.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_6_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_6_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_6_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_1.RightLoad = false;
            this.uclBuffer_A01_6_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_6_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_6_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_6_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_1.TabIndex = 27;
            // 
            // uclBuffer_A01_6_L
            // 
            this.uclBuffer_A01_6_L.Auto = false;
            this.uclBuffer_A01_6_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_A01_6_L.BufferName = "A01-6-L";
            this.uclBuffer_A01_6_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_A01_6_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_A01_6_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_A01_6_L.Error = "";
            this.uclBuffer_A01_6_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_A01_6_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_L.LeftCmdSno = "";
            this.uclBuffer_A01_6_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_L.LeftLoad = false;
            this.uclBuffer_A01_6_L.Location = new System.Drawing.Point(1064, 142);
            this.uclBuffer_A01_6_L.Manual = false;
            this.uclBuffer_A01_6_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_6_L.Name = "uclBuffer_A01_6_L";
            this.uclBuffer_A01_6_L.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer_A01_6_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_A01_6_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_A01_6_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_L.RightLoad = false;
            this.uclBuffer_A01_6_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_A01_6_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_A01_6_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_A01_6_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_A01_6_L.TabIndex = 28;
            // 
            // ptbA06
            // 
            this.ptbA06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbA06.Image = ((System.Drawing.Image)(resources.GetObject("ptbA06.Image")));
            this.ptbA06.Location = new System.Drawing.Point(1064, 278);
            this.ptbA06.Margin = new System.Windows.Forms.Padding(0);
            this.ptbA06.Name = "ptbA06";
            this.ptbA06.Size = new System.Drawing.Size(86, 41);
            this.ptbA06.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbA06.TabIndex = 62;
            this.ptbA06.TabStop = false;
            this.ptbA06.Tag = "IN";
            this.ptbA06.DoubleClick += new System.EventHandler(this.ptbA06_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(425, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.tlpASRS_A.SetRowSpan(this.label3, 2);
            this.label3.Size = new System.Drawing.Size(45, 136);
            this.label3.TabIndex = 65;
            this.label3.Text = "Crane 1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(722, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.tlpASRS_A.SetRowSpan(this.label2, 2);
            this.label2.Size = new System.Drawing.Size(45, 136);
            this.label2.TabIndex = 64;
            this.label2.Text = "Crane 2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1019, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.tlpASRS_A.SetRowSpan(this.label1, 2);
            this.label1.Size = new System.Drawing.Size(45, 136);
            this.label1.TabIndex = 63;
            this.label1.Text = "Crane 3";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbA01
            // 
            this.ptbA01.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbA01.Location = new System.Drawing.Point(339, 278);
            this.ptbA01.Margin = new System.Windows.Forms.Padding(0);
            this.ptbA01.Name = "ptbA01";
            this.ptbA01.Size = new System.Drawing.Size(86, 41);
            this.ptbA01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbA01.TabIndex = 66;
            this.ptbA01.TabStop = false;
            this.ptbA01.Tag = "OUT";
            this.ptbA01.DoubleClick += new System.EventHandler(this.ptbA01_DoubleClick_1);
            // 
            // ptbA03
            // 
            this.ptbA03.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbA03.Location = new System.Drawing.Point(636, 278);
            this.ptbA03.Margin = new System.Windows.Forms.Padding(0);
            this.ptbA03.Name = "ptbA03";
            this.ptbA03.Size = new System.Drawing.Size(86, 41);
            this.ptbA03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbA03.TabIndex = 67;
            this.ptbA03.TabStop = false;
            this.ptbA03.Tag = "OUT";
            this.ptbA03.DoubleClick += new System.EventHandler(this.ptbA03_DoubleClick);
            // 
            // ptbA05
            // 
            this.ptbA05.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbA05.Location = new System.Drawing.Point(933, 278);
            this.ptbA05.Margin = new System.Windows.Forms.Padding(0);
            this.ptbA05.Name = "ptbA05";
            this.ptbA05.Size = new System.Drawing.Size(86, 41);
            this.ptbA05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbA05.TabIndex = 68;
            this.ptbA05.TabStop = false;
            this.ptbA05.Tag = "OUT";
            this.ptbA05.DoubleClick += new System.EventHandler(this.ptbA05_DoubleClick);
            // 
            // tbpSystem
            // 
            this.tbpSystem.AutoScroll = true;
            this.tbpSystem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpSystem.Controls.Add(this.sctSystem);
            this.tbpSystem.Location = new System.Drawing.Point(4, 27);
            this.tbpSystem.Name = "tbpSystem";
            this.tbpSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSystem.Size = new System.Drawing.Size(1000, 472);
            this.tbpSystem.TabIndex = 4;
            this.tbpSystem.Text = "System";
            // 
            // sctSystem
            // 
            this.sctSystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sctSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sctSystem.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sctSystem.IsSplitterFixed = true;
            this.sctSystem.Location = new System.Drawing.Point(3, 3);
            this.sctSystem.Name = "sctSystem";
            // 
            // sctSystem.Panel1
            // 
            this.sctSystem.Panel1.AutoScroll = true;
            this.sctSystem.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sctSystem.Panel1.Controls.Add(this.groupBox1);
            this.sctSystem.Panel1.Controls.Add(this.gpbCommand);
            this.sctSystem.Panel1.Controls.Add(this.gpbConnection);
            // 
            // sctSystem.Panel2
            // 
            this.sctSystem.Panel2.Controls.Add(this.tbcTrace);
            this.sctSystem.Size = new System.Drawing.Size(994, 466);
            this.sctSystem.SplitterDistance = 250;
            this.sctSystem.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBCR);
            this.groupBox1.Controls.Add(this.chkWeight);
            this.groupBox1.Controls.Add(this.chkBCR);
            this.groupBox1.Location = new System.Drawing.Point(9, 206);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(151, 115);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pass";
            // 
            // txtBCR
            // 
            this.txtBCR.Location = new System.Drawing.Point(26, 54);
            this.txtBCR.Margin = new System.Windows.Forms.Padding(2);
            this.txtBCR.Name = "txtBCR";
            this.txtBCR.Size = new System.Drawing.Size(76, 26);
            this.txtBCR.TabIndex = 6;
            // 
            // chkWeight
            // 
            this.chkWeight.AutoSize = true;
            this.chkWeight.Location = new System.Drawing.Point(26, 87);
            this.chkWeight.Margin = new System.Windows.Forms.Padding(2);
            this.chkWeight.Name = "chkWeight";
            this.chkWeight.Size = new System.Drawing.Size(76, 22);
            this.chkWeight.TabIndex = 5;
            this.chkWeight.Text = "WEIGHT";
            this.chkWeight.UseVisualStyleBackColor = true;
            // 
            // chkBCR
            // 
            this.chkBCR.AutoSize = true;
            this.chkBCR.Location = new System.Drawing.Point(26, 26);
            this.chkBCR.Margin = new System.Windows.Forms.Padding(2);
            this.chkBCR.Name = "chkBCR";
            this.chkBCR.Size = new System.Drawing.Size(51, 22);
            this.chkBCR.TabIndex = 4;
            this.chkBCR.Text = "BCR";
            this.chkBCR.UseVisualStyleBackColor = true;
            // 
            // gpbCommand
            // 
            this.gpbCommand.Controls.Add(this.btnAutoPause);
            this.gpbCommand.Controls.Add(this.btnCraneCommand);
            this.gpbCommand.Location = new System.Drawing.Point(11, 334);
            this.gpbCommand.Name = "gpbCommand";
            this.gpbCommand.Size = new System.Drawing.Size(142, 117);
            this.gpbCommand.TabIndex = 11;
            this.gpbCommand.TabStop = false;
            this.gpbCommand.Text = "Command";
            // 
            // btnAutoPause
            // 
            this.btnAutoPause.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAutoPause.Location = new System.Drawing.Point(6, 68);
            this.btnAutoPause.Name = "btnAutoPause";
            this.btnAutoPause.Size = new System.Drawing.Size(130, 30);
            this.btnAutoPause.TabIndex = 12;
            this.btnAutoPause.Text = "Pause";
            this.btnAutoPause.UseVisualStyleBackColor = true;
            this.btnAutoPause.Click += new System.EventHandler(this.btnAutoPause_Click);
            // 
            // btnCraneCommand
            // 
            this.btnCraneCommand.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCraneCommand.Location = new System.Drawing.Point(6, 30);
            this.btnCraneCommand.Name = "btnCraneCommand";
            this.btnCraneCommand.Size = new System.Drawing.Size(130, 30);
            this.btnCraneCommand.TabIndex = 5;
            this.btnCraneCommand.Text = "Crane Command";
            this.btnCraneCommand.UseVisualStyleBackColor = true;
            this.btnCraneCommand.Click += new System.EventHandler(this.btnCraneCommand_Click);
            // 
            // gpbConnection
            // 
            this.gpbConnection.AutoSize = true;
            this.gpbConnection.Controls.Add(this.btnReconnectWeight);
            this.gpbConnection.Controls.Add(this.chkAutoReconnect);
            this.gpbConnection.Controls.Add(this.btnReconnectPLC);
            this.gpbConnection.Controls.Add(this.btnReconnectDB);
            this.gpbConnection.Location = new System.Drawing.Point(10, 3);
            this.gpbConnection.Name = "gpbConnection";
            this.gpbConnection.Size = new System.Drawing.Size(168, 197);
            this.gpbConnection.TabIndex = 10;
            this.gpbConnection.TabStop = false;
            this.gpbConnection.Text = "Connection";
            // 
            // btnReconnectWeight
            // 
            this.btnReconnectWeight.AutoSize = true;
            this.btnReconnectWeight.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReconnectWeight.Location = new System.Drawing.Point(7, 136);
            this.btnReconnectWeight.Name = "btnReconnectWeight";
            this.btnReconnectWeight.Size = new System.Drawing.Size(155, 30);
            this.btnReconnectWeight.TabIndex = 10;
            this.btnReconnectWeight.Text = "Reconnect Weight";
            this.btnReconnectWeight.UseVisualStyleBackColor = true;
            this.btnReconnectWeight.Click += new System.EventHandler(this.btnReconnectWeight_Click);
            // 
            // chkAutoReconnect
            // 
            this.chkAutoReconnect.AutoSize = true;
            this.chkAutoReconnect.Checked = true;
            this.chkAutoReconnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoReconnect.Location = new System.Drawing.Point(6, 30);
            this.chkAutoReconnect.Name = "chkAutoReconnect";
            this.chkAutoReconnect.Size = new System.Drawing.Size(125, 22);
            this.chkAutoReconnect.TabIndex = 9;
            this.chkAutoReconnect.Text = "Auto Reconnect";
            this.chkAutoReconnect.UseVisualStyleBackColor = true;
            this.chkAutoReconnect.CheckedChanged += new System.EventHandler(this.chkAutoReconnect_CheckedChanged);
            // 
            // btnReconnectPLC
            // 
            this.btnReconnectPLC.AutoSize = true;
            this.btnReconnectPLC.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReconnectPLC.Location = new System.Drawing.Point(6, 62);
            this.btnReconnectPLC.Name = "btnReconnectPLC";
            this.btnReconnectPLC.Size = new System.Drawing.Size(135, 30);
            this.btnReconnectPLC.TabIndex = 2;
            this.btnReconnectPLC.Text = "Reconnect PLC";
            this.btnReconnectPLC.UseVisualStyleBackColor = true;
            this.btnReconnectPLC.Click += new System.EventHandler(this.btnReconnectPLC_Click);
            // 
            // btnReconnectDB
            // 
            this.btnReconnectDB.AutoSize = true;
            this.btnReconnectDB.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReconnectDB.Location = new System.Drawing.Point(7, 99);
            this.btnReconnectDB.Name = "btnReconnectDB";
            this.btnReconnectDB.Size = new System.Drawing.Size(135, 30);
            this.btnReconnectDB.TabIndex = 1;
            this.btnReconnectDB.Text = "Reconnect DB";
            this.btnReconnectDB.UseVisualStyleBackColor = true;
            this.btnReconnectDB.Click += new System.EventHandler(this.btnReconnectDB_Click);
            // 
            // tbcTrace
            // 
            this.tbcTrace.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbcTrace.Controls.Add(this.tbpSystemTrace);
            this.tbcTrace.Controls.Add(this.tbpMPLC);
            this.tbcTrace.Controls.Add(this.tbpAlarmList);
            this.tbcTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcTrace.HotTrack = true;
            this.tbcTrace.Location = new System.Drawing.Point(0, 0);
            this.tbcTrace.Multiline = true;
            this.tbcTrace.Name = "tbcTrace";
            this.tbcTrace.SelectedIndex = 0;
            this.tbcTrace.Size = new System.Drawing.Size(736, 462);
            this.tbcTrace.TabIndex = 0;
            // 
            // tbpSystemTrace
            // 
            this.tbpSystemTrace.BackColor = System.Drawing.Color.Transparent;
            this.tbpSystemTrace.Controls.Add(this.lsbSystemTrace);
            this.tbpSystemTrace.Location = new System.Drawing.Point(4, 30);
            this.tbpSystemTrace.Name = "tbpSystemTrace";
            this.tbpSystemTrace.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSystemTrace.Size = new System.Drawing.Size(728, 428);
            this.tbpSystemTrace.TabIndex = 0;
            this.tbpSystemTrace.Text = "System Trace";
            // 
            // lsbSystemTrace
            // 
            this.lsbSystemTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbSystemTrace.FormattingEnabled = true;
            this.lsbSystemTrace.HorizontalScrollbar = true;
            this.lsbSystemTrace.ItemHeight = 18;
            this.lsbSystemTrace.Location = new System.Drawing.Point(3, 3);
            this.lsbSystemTrace.Name = "lsbSystemTrace";
            this.lsbSystemTrace.Size = new System.Drawing.Size(722, 422);
            this.lsbSystemTrace.TabIndex = 0;
            // 
            // tbpMPLC
            // 
            this.tbpMPLC.Controls.Add(this.lsbMPLC);
            this.tbpMPLC.Location = new System.Drawing.Point(4, 30);
            this.tbpMPLC.Name = "tbpMPLC";
            this.tbpMPLC.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMPLC.Size = new System.Drawing.Size(728, 428);
            this.tbpMPLC.TabIndex = 1;
            this.tbpMPLC.Text = "MPLC";
            this.tbpMPLC.UseVisualStyleBackColor = true;
            // 
            // lsbMPLC
            // 
            this.lsbMPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbMPLC.FormattingEnabled = true;
            this.lsbMPLC.HorizontalScrollbar = true;
            this.lsbMPLC.ItemHeight = 18;
            this.lsbMPLC.Location = new System.Drawing.Point(3, 3);
            this.lsbMPLC.Name = "lsbMPLC";
            this.lsbMPLC.Size = new System.Drawing.Size(722, 422);
            this.lsbMPLC.TabIndex = 1;
            // 
            // tbpAlarmList
            // 
            this.tbpAlarmList.Controls.Add(this.lsbAlarmList);
            this.tbpAlarmList.Location = new System.Drawing.Point(4, 30);
            this.tbpAlarmList.Name = "tbpAlarmList";
            this.tbpAlarmList.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAlarmList.Size = new System.Drawing.Size(728, 428);
            this.tbpAlarmList.TabIndex = 2;
            this.tbpAlarmList.Text = "Alarm List";
            this.tbpAlarmList.UseVisualStyleBackColor = true;
            // 
            // lsbAlarmList
            // 
            this.lsbAlarmList.ColumnWidth = 200;
            this.lsbAlarmList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbAlarmList.FormattingEnabled = true;
            this.lsbAlarmList.ItemHeight = 18;
            this.lsbAlarmList.Location = new System.Drawing.Point(3, 3);
            this.lsbAlarmList.MultiColumn = true;
            this.lsbAlarmList.Name = "lsbAlarmList";
            this.lsbAlarmList.Size = new System.Drawing.Size(722, 422);
            this.lsbAlarmList.Sorted = true;
            this.lsbAlarmList.TabIndex = 0;
            // 
            // frmWinPLCCommu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 590);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.tlpMainTop);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmWinPLCCommu";
            this.Text = "Mirle AS/RS System Communication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWinPLCCommu_FormClosing);
            this.Load += new System.EventHandler(this.frmWinPLCCommu_Load);
            this.Resize += new System.EventHandler(this.frmWinPLCCommu_Resize);
            this.tlpMainTop.ResumeLayout(false);
            this.tlpMainTop.PerformLayout();
            this.tlpCraneSts.ResumeLayout(false);
            this.tlpCraneSts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tlpPLCSts.ResumeLayout(false);
            this.tlpPLCSts.PerformLayout();
            this.tlpMainSts.ResumeLayout(false);
            this.tlpMainSts.PerformLayout();
            this.cmsMain.ResumeLayout(false);
            this.tbcMain.ResumeLayout(false);
            this.tbpASRS_A.ResumeLayout(false);
            this.tlpASRS_A.ResumeLayout(false);
            this.tlpASRS_A.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbA05)).EndInit();
            this.tbpSystem.ResumeLayout(false);
            this.sctSystem.Panel1.ResumeLayout(false);
            this.sctSystem.Panel1.PerformLayout();
            this.sctSystem.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sctSystem)).EndInit();
            this.sctSystem.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbCommand.ResumeLayout(false);
            this.gpbConnection.ResumeLayout(false);
            this.gpbConnection.PerformLayout();
            this.tbcTrace.ResumeLayout(false);
            this.tbpSystemTrace.ResumeLayout(false);
            this.tbpMPLC.ResumeLayout(false);
            this.tbpAlarmList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDBStsLable;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TableLayoutPanel tlpMainTop;
        private System.Windows.Forms.Label lblMPLC1Sts;
        private System.Windows.Forms.Label lblDBSts;
        private System.Windows.Forms.Label lblCrane1Sts;
        private System.Windows.Forms.Label lblCrane1Mode;
        private System.Windows.Forms.Label lblCrane1StsLable;
        private System.Windows.Forms.TableLayoutPanel tlpCraneSts;
        private System.Windows.Forms.TableLayoutPanel tlpPLCSts;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NotifyIcon nfiMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tslShowASRSCommunication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tslCloseASRSCommunication;
        private System.Windows.Forms.TableLayoutPanel tlpMainSts;
        private System.Windows.Forms.Label lblCmuSts;
        private System.Windows.Forms.Label lblCmuStsLabel;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpASRS_A;
        private System.Windows.Forms.TableLayoutPanel tlpASRS_A;
        private uclBuffer uclBuffer_A01_1_1;
        private uclBuffer uclBuffer_A01_1_L;
        private uclBuffer uclBuffer_A01_2_L;
        private uclBuffer uclBuffer_A01_2_1;
        private uclBuffer uclBuffer_A01_3_1;
        private uclBuffer uclBuffer_A01_3_L;
        private uclBuffer uclBuffer_A01_4_L;
        private uclBuffer uclBuffer_A01_4_1;
        private uclBuffer uclBuffer_A01_5_L;
        private uclBuffer uclBuffer_A01_5_1;
        private uclBuffer uclBuffer_A01_6_1;
        private uclBuffer uclBuffer_A01_6_L;
        private System.Windows.Forms.PictureBox ptbA02;
        private System.Windows.Forms.PictureBox ptbA04;
        private System.Windows.Forms.PictureBox ptbA06;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tbpSystem;
        private System.Windows.Forms.SplitContainer sctSystem;
        private System.Windows.Forms.Button btnReconnectDB;
        private System.Windows.Forms.Button btnReconnectPLC;
        private System.Windows.Forms.CheckBox chkAutoReconnect;
        private System.Windows.Forms.TabControl tbcTrace;
        private System.Windows.Forms.TabPage tbpSystemTrace;
        private System.Windows.Forms.ListBox lsbSystemTrace;
        private System.Windows.Forms.TabPage tbpMPLC;
        private System.Windows.Forms.ListBox lsbMPLC;
        private System.Windows.Forms.GroupBox gpbConnection;
        private System.Windows.Forms.Button txtBuffrtInfo;
        private System.Windows.Forms.Button btnCraneCommand;
        private System.Windows.Forms.GroupBox gpbCommand;
        private System.Windows.Forms.Button btnAutoPause;
        private System.Windows.Forms.TabPage tbpAlarmList;
        private System.Windows.Forms.ListBox lsbAlarmList;
        private System.Windows.Forms.Button btnPLCModify;
        private System.Windows.Forms.Label lblMPLC3Sts;
        private System.Windows.Forms.Label lblMPLC2Sts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMPLC1StsLable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBCR;
        private System.Windows.Forms.CheckBox chkWeight;
        private System.Windows.Forms.CheckBox chkBCR;
        private System.Windows.Forms.Button btnReconnectWeight;
        private System.Windows.Forms.PictureBox ptbA01;
        private System.Windows.Forms.PictureBox ptbA03;
        private System.Windows.Forms.PictureBox ptbA05;
    }
}

