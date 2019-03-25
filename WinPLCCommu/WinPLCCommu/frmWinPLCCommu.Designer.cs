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
            this.tbpASRS_B = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.uclBuffer_B01_1_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_B01_1_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_B01_2_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_B01_2_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_B01_3_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_B01_3_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.label5 = new System.Windows.Forms.Label();
            this.uclBuffer_B01_4_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_B01_4_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbB02 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_B01_5_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_B01_5_L = new Mirle.WinPLCCommu.uclBuffer();
            this.label4 = new System.Windows.Forms.Label();
            this.uclBuffer_B01_6_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_B01_6_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbB04 = new System.Windows.Forms.PictureBox();
            this.ptbB06 = new System.Windows.Forms.PictureBox();
            this.ptbB01 = new System.Windows.Forms.PictureBox();
            this.ptbB03 = new System.Windows.Forms.PictureBox();
            this.ptbB05 = new System.Windows.Forms.PictureBox();
            this.tbpASRS_C = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.uclBuffer_C01_1_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_C01_1_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbC02 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_C01_2_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_C01_2_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_C01_3_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_C01_3_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbC04 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_C01_4_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_C01_4_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_C01_5_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_C01_5_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbC06 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_C01_6_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_C01_6_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbC01 = new System.Windows.Forms.PictureBox();
            this.ptbC03 = new System.Windows.Forms.PictureBox();
            this.ptbC05 = new System.Windows.Forms.PictureBox();
            this.tbpASRS_D = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uclBuffer_D01_2_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_D01_1_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_D01_1_L = new Mirle.WinPLCCommu.uclBuffer();
            this.label9 = new System.Windows.Forms.Label();
            this.uclBuffer_D01_2_L = new Mirle.WinPLCCommu.uclBuffer();
            this.label8 = new System.Windows.Forms.Label();
            this.uclBuffer_D01_3_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_D01_3_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_D01_4_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_D01_4_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbD02 = new System.Windows.Forms.PictureBox();
            this.ptbD04 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_D01_5_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_D01_5_L = new Mirle.WinPLCCommu.uclBuffer();
            this.label7 = new System.Windows.Forms.Label();
            this.uclBuffer_D01_6_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_D01_6_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbD06 = new System.Windows.Forms.PictureBox();
            this.ptbD01 = new System.Windows.Forms.PictureBox();
            this.ptbD03 = new System.Windows.Forms.PictureBox();
            this.ptbD05 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.uclBuffer_E01_1_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_E01_1_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_E01_2_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_E01_2_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_E01_3_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_E01_3_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbE02 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.uclBuffer_E01_4_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_E01_4_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbE04 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_E01_5_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_E01_5_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.label12 = new System.Windows.Forms.Label();
            this.uclBuffer_E01_6_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_E01_6_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbE06 = new System.Windows.Forms.PictureBox();
            this.ptbE01 = new System.Windows.Forms.PictureBox();
            this.ptbE03 = new System.Windows.Forms.PictureBox();
            this.ptbE05 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ptbF04 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_F01_1_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_F01_1_L = new Mirle.WinPLCCommu.uclBuffer();
            this.label20 = new System.Windows.Forms.Label();
            this.uclBuffer_F01_2_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_F01_2_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_F01_3_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_F01_3_L = new Mirle.WinPLCCommu.uclBuffer();
            this.label19 = new System.Windows.Forms.Label();
            this.uclBuffer_F01_4_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_F01_4_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.label18 = new System.Windows.Forms.Label();
            this.uclBuffer_F01_6_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_F01_6_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbF02 = new System.Windows.Forms.PictureBox();
            this.ptbF06 = new System.Windows.Forms.PictureBox();
            this.ptbF01 = new System.Windows.Forms.PictureBox();
            this.ptbF03 = new System.Windows.Forms.PictureBox();
            this.ptbF05 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_F01_5_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_F01_5_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.uclBuffer_G01_1_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_G01_1_L = new Mirle.WinPLCCommu.uclBuffer();
            this.label23 = new System.Windows.Forms.Label();
            this.uclBuffer_G01_2_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_G01_2_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_G01_3_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_G01_3_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.label22 = new System.Windows.Forms.Label();
            this.ptbG02 = new System.Windows.Forms.PictureBox();
            this.ptbG04 = new System.Windows.Forms.PictureBox();
            this.uclBuffer_G01_4_L = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_G01_4_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_G01_5_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_G01_5_L = new Mirle.WinPLCCommu.uclBuffer();
            this.label21 = new System.Windows.Forms.Label();
            this.uclBuffer_G01_6_1 = new Mirle.WinPLCCommu.uclBuffer();
            this.uclBuffer_G01_6_L = new Mirle.WinPLCCommu.uclBuffer();
            this.ptbG06 = new System.Windows.Forms.PictureBox();
            this.ptbG01 = new System.Windows.Forms.PictureBox();
            this.ptbG03 = new System.Windows.Forms.PictureBox();
            this.ptbG05 = new System.Windows.Forms.PictureBox();
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
            this.tbpASRS_B.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB05)).BeginInit();
            this.tbpASRS_C.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC05)).BeginInit();
            this.tbpASRS_D.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD05)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE05)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF05)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG05)).BeginInit();
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
            this.btnExit.Location = new System.Drawing.Point(681, 0);
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
            this.lblMPLC1Sts.Size = new System.Drawing.Size(131, 29);
            this.lblMPLC1Sts.TabIndex = 6;
            this.lblMPLC1Sts.Text = "None";
            this.lblMPLC1Sts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMainTop
            // 
            this.tlpMainTop.AutoSize = true;
            this.tlpMainTop.ColumnCount = 3;
            this.tlpMainTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMainTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMainTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMainTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.tlpMainTop.Size = new System.Drawing.Size(1008, 87);
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
            this.tlpCraneSts.Size = new System.Drawing.Size(484, 58);
            this.tlpCraneSts.TabIndex = 0;
            // 
            // lblCrane1Sts
            // 
            this.lblCrane1Sts.AutoSize = true;
            this.lblCrane1Sts.BackColor = System.Drawing.Color.Red;
            this.lblCrane1Sts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCrane1Sts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrane1Sts.ForeColor = System.Drawing.Color.Black;
            this.lblCrane1Sts.Location = new System.Drawing.Point(242, 29);
            this.lblCrane1Sts.Margin = new System.Windows.Forms.Padding(0);
            this.lblCrane1Sts.Name = "lblCrane1Sts";
            this.lblCrane1Sts.Size = new System.Drawing.Size(242, 29);
            this.lblCrane1Sts.TabIndex = 11;
            this.lblCrane1Sts.Text = "X:未連線";
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
            this.lblCrane1Mode.Size = new System.Drawing.Size(242, 29);
            this.lblCrane1Mode.TabIndex = 10;
            this.lblCrane1Mode.Text = "X:未連線";
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
            this.lblCrane1StsLable.Size = new System.Drawing.Size(484, 29);
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
            this.tlpPLCSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpPLCSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tlpPLCSts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPLCSts.Controls.Add(this.lblMPLC3Sts, 2, 1);
            this.tlpPLCSts.Controls.Add(this.lblMPLC2Sts, 1, 1);
            this.tlpPLCSts.Controls.Add(this.label11, 2, 0);
            this.tlpPLCSts.Controls.Add(this.label10, 1, 0);
            this.tlpPLCSts.Controls.Add(this.lblMPLC1Sts, 0, 1);
            this.tlpPLCSts.Controls.Add(this.lblMPLC1StsLable, 0, 0);
            this.tlpPLCSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPLCSts.Location = new System.Drawing.Point(684, 0);
            this.tlpPLCSts.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPLCSts.Name = "tlpPLCSts";
            this.tlpPLCSts.RowCount = 2;
            this.tlpMainTop.SetRowSpan(this.tlpPLCSts, 2);
            this.tlpPLCSts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPLCSts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPLCSts.Size = new System.Drawing.Size(324, 58);
            this.tlpPLCSts.TabIndex = 13;
            // 
            // lblMPLC3Sts
            // 
            this.lblMPLC3Sts.AutoSize = true;
            this.lblMPLC3Sts.BackColor = System.Drawing.Color.Red;
            this.lblMPLC3Sts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMPLC3Sts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMPLC3Sts.Location = new System.Drawing.Point(229, 29);
            this.lblMPLC3Sts.Margin = new System.Windows.Forms.Padding(0);
            this.lblMPLC3Sts.Name = "lblMPLC3Sts";
            this.lblMPLC3Sts.Size = new System.Drawing.Size(95, 29);
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
            this.lblMPLC2Sts.Location = new System.Drawing.Point(131, 29);
            this.lblMPLC2Sts.Margin = new System.Windows.Forms.Padding(0);
            this.lblMPLC2Sts.Name = "lblMPLC2Sts";
            this.lblMPLC2Sts.Size = new System.Drawing.Size(98, 29);
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
            this.label11.Location = new System.Drawing.Point(229, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 29);
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
            this.label10.Location = new System.Drawing.Point(131, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 29);
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
            this.lblMPLC1StsLable.Size = new System.Drawing.Size(131, 29);
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
            this.tlpMainSts.Size = new System.Drawing.Size(808, 29);
            this.tlpMainSts.TabIndex = 14;
            // 
            // btnPLCModify
            // 
            this.btnPLCModify.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPLCModify.Location = new System.Drawing.Point(421, 0);
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
            this.txtBuffrtInfo.Location = new System.Drawing.Point(551, 0);
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
            this.tbcMain.Controls.Add(this.tbpASRS_B);
            this.tbcMain.Controls.Add(this.tbpASRS_C);
            this.tbcMain.Controls.Add(this.tbpASRS_D);
            this.tbcMain.Controls.Add(this.tabPage1);
            this.tbcMain.Controls.Add(this.tabPage2);
            this.tbcMain.Controls.Add(this.tabPage3);
            this.tbcMain.Controls.Add(this.tbpSystem);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcMain.Location = new System.Drawing.Point(0, 87);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1008, 503);
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
            this.tbpASRS_A.Size = new System.Drawing.Size(1000, 472);
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
            this.tlpASRS_A.Size = new System.Drawing.Size(990, 462);
            this.tlpASRS_A.TabIndex = 0;
            // 
            // uclBuffer_A01_1_1
            // 
            this.uclBuffer_A01_1_1.Auto = false;
            this.uclBuffer_A01_1_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_1_1.Location = new System.Drawing.Point(129, 210);
            this.uclBuffer_A01_1_1.Manual = false;
            this.uclBuffer_A01_1_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_1_1.Name = "uclBuffer_A01_1_1";
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
            this.uclBuffer_A01_1_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_1_L.Location = new System.Drawing.Point(129, 142);
            this.uclBuffer_A01_1_L.Manual = false;
            this.uclBuffer_A01_1_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_1_L.Name = "uclBuffer_A01_1_L";
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
            this.uclBuffer_A01_2_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_2_L.Location = new System.Drawing.Point(260, 142);
            this.uclBuffer_A01_2_L.Manual = false;
            this.uclBuffer_A01_2_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_2_L.Name = "uclBuffer_A01_2_L";
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
            this.uclBuffer_A01_2_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_2_1.Location = new System.Drawing.Point(260, 210);
            this.uclBuffer_A01_2_1.Manual = false;
            this.uclBuffer_A01_2_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_2_1.Name = "uclBuffer_A01_2_1";
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
            this.uclBuffer_A01_3_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_3_L.Location = new System.Drawing.Point(376, 142);
            this.uclBuffer_A01_3_L.Manual = false;
            this.uclBuffer_A01_3_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_3_L.Name = "uclBuffer_A01_3_L";
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
            this.uclBuffer_A01_3_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_3_1.Location = new System.Drawing.Point(376, 210);
            this.uclBuffer_A01_3_1.Manual = false;
            this.uclBuffer_A01_3_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_3_1.Name = "uclBuffer_A01_3_1";
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
            this.uclBuffer_A01_4_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_4_L.Location = new System.Drawing.Point(507, 142);
            this.uclBuffer_A01_4_L.Manual = false;
            this.uclBuffer_A01_4_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_4_L.Name = "uclBuffer_A01_4_L";
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
            this.uclBuffer_A01_4_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_4_1.Location = new System.Drawing.Point(507, 210);
            this.uclBuffer_A01_4_1.Manual = false;
            this.uclBuffer_A01_4_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_4_1.Name = "uclBuffer_A01_4_1";
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
            this.ptbA02.Location = new System.Drawing.Point(260, 278);
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
            this.ptbA04.Location = new System.Drawing.Point(507, 278);
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
            this.uclBuffer_A01_5_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_5_1.Location = new System.Drawing.Point(623, 210);
            this.uclBuffer_A01_5_1.Manual = false;
            this.uclBuffer_A01_5_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_5_1.Name = "uclBuffer_A01_5_1";
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
            this.uclBuffer_A01_5_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_5_L.Location = new System.Drawing.Point(623, 142);
            this.uclBuffer_A01_5_L.Manual = false;
            this.uclBuffer_A01_5_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_5_L.Name = "uclBuffer_A01_5_L";
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
            this.uclBuffer_A01_6_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_6_1.Location = new System.Drawing.Point(754, 210);
            this.uclBuffer_A01_6_1.Manual = false;
            this.uclBuffer_A01_6_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_6_1.Name = "uclBuffer_A01_6_1";
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
            this.uclBuffer_A01_6_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
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
            this.uclBuffer_A01_6_L.Location = new System.Drawing.Point(754, 142);
            this.uclBuffer_A01_6_L.Manual = false;
            this.uclBuffer_A01_6_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_A01_6_L.Name = "uclBuffer_A01_6_L";
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
            this.ptbA06.Location = new System.Drawing.Point(754, 278);
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
            this.label3.Location = new System.Drawing.Point(215, 74);
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
            this.label2.Location = new System.Drawing.Point(462, 74);
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
            this.label1.Location = new System.Drawing.Point(709, 74);
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
            this.ptbA01.Location = new System.Drawing.Point(129, 278);
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
            this.ptbA03.Location = new System.Drawing.Point(376, 278);
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
            this.ptbA05.Location = new System.Drawing.Point(623, 278);
            this.ptbA05.Margin = new System.Windows.Forms.Padding(0);
            this.ptbA05.Name = "ptbA05";
            this.ptbA05.Size = new System.Drawing.Size(86, 41);
            this.ptbA05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbA05.TabIndex = 68;
            this.ptbA05.TabStop = false;
            this.ptbA05.Tag = "OUT";
            this.ptbA05.DoubleClick += new System.EventHandler(this.ptbA05_DoubleClick);
            // 
            // tbpASRS_B
            // 
            this.tbpASRS_B.AutoScroll = true;
            this.tbpASRS_B.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpASRS_B.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpASRS_B.Controls.Add(this.tableLayoutPanel1);
            this.tbpASRS_B.Location = new System.Drawing.Point(4, 27);
            this.tbpASRS_B.Name = "tbpASRS_B";
            this.tbpASRS_B.Padding = new System.Windows.Forms.Padding(3);
            this.tbpASRS_B.Size = new System.Drawing.Size(1000, 472);
            this.tbpASRS_B.TabIndex = 1;
            this.tbpASRS_B.Text = "ASRS 3F(B區)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.55F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_1_1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_1_L, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_2_1, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_2_L, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_3_L, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_3_1, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_4_L, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_4_1, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.ptbB02, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_5_1, 9, 3);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_5_L, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 10, 1);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_6_1, 11, 3);
            this.tableLayoutPanel1.Controls.Add(this.uclBuffer_B01_6_L, 11, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptbB04, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this.ptbB06, 11, 4);
            this.tableLayoutPanel1.Controls.Add(this.ptbB01, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ptbB03, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.ptbB05, 9, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(990, 462);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Yellow;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(215, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.tableLayoutPanel1.SetRowSpan(this.label6, 2);
            this.label6.Size = new System.Drawing.Size(45, 136);
            this.label6.TabIndex = 65;
            this.label6.Text = "Crane 1";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_B01_1_1
            // 
            this.uclBuffer_B01_1_1.Auto = false;
            this.uclBuffer_B01_1_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_1_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_1_1.BufferName = "B01-1-1";
            this.uclBuffer_B01_1_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_1_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_1_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_1_1.Error = "";
            this.uclBuffer_B01_1_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_1_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_1.LeftCmdSno = "";
            this.uclBuffer_B01_1_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_1.LeftLoad = false;
            this.uclBuffer_B01_1_1.Location = new System.Drawing.Point(129, 210);
            this.uclBuffer_B01_1_1.Manual = false;
            this.uclBuffer_B01_1_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_1_1.Name = "uclBuffer_B01_1_1";
            this.uclBuffer_B01_1_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_1_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_1_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_1.RightLoad = false;
            this.uclBuffer_B01_1_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_1_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_1_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_1_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_1.TabIndex = 0;
            // 
            // uclBuffer_B01_1_L
            // 
            this.uclBuffer_B01_1_L.Auto = false;
            this.uclBuffer_B01_1_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_1_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_1_L.BufferName = "B01-1-L";
            this.uclBuffer_B01_1_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_1_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_1_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_1_L.Error = "";
            this.uclBuffer_B01_1_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_1_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_L.LeftCmdSno = "";
            this.uclBuffer_B01_1_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_L.LeftLoad = false;
            this.uclBuffer_B01_1_L.Location = new System.Drawing.Point(129, 142);
            this.uclBuffer_B01_1_L.Manual = false;
            this.uclBuffer_B01_1_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_1_L.Name = "uclBuffer_B01_1_L";
            this.uclBuffer_B01_1_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_1_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_1_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_L.RightLoad = false;
            this.uclBuffer_B01_1_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_1_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_1_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_1_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_1_L.TabIndex = 1;
            // 
            // uclBuffer_B01_2_1
            // 
            this.uclBuffer_B01_2_1.Auto = false;
            this.uclBuffer_B01_2_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_2_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_2_1.BufferName = "B01-2-1";
            this.uclBuffer_B01_2_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_2_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_2_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_2_1.Error = "";
            this.uclBuffer_B01_2_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_2_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_1.LeftCmdSno = "";
            this.uclBuffer_B01_2_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_1.LeftLoad = false;
            this.uclBuffer_B01_2_1.Location = new System.Drawing.Point(260, 210);
            this.uclBuffer_B01_2_1.Manual = false;
            this.uclBuffer_B01_2_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_2_1.Name = "uclBuffer_B01_2_1";
            this.uclBuffer_B01_2_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_2_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_2_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_1.RightLoad = false;
            this.uclBuffer_B01_2_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_2_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_2_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_2_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_1.TabIndex = 10;
            // 
            // uclBuffer_B01_2_L
            // 
            this.uclBuffer_B01_2_L.Auto = false;
            this.uclBuffer_B01_2_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_2_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_2_L.BufferName = "B01-2-L";
            this.uclBuffer_B01_2_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_2_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_2_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_2_L.Error = "";
            this.uclBuffer_B01_2_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_2_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_L.LeftCmdSno = "";
            this.uclBuffer_B01_2_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_L.LeftLoad = false;
            this.uclBuffer_B01_2_L.Location = new System.Drawing.Point(260, 142);
            this.uclBuffer_B01_2_L.Manual = false;
            this.uclBuffer_B01_2_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_2_L.Name = "uclBuffer_B01_2_L";
            this.uclBuffer_B01_2_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_2_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_2_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_L.RightLoad = false;
            this.uclBuffer_B01_2_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_2_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_2_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_2_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_2_L.TabIndex = 9;
            // 
            // uclBuffer_B01_3_L
            // 
            this.uclBuffer_B01_3_L.Auto = false;
            this.uclBuffer_B01_3_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_3_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_3_L.BufferName = "B01-3-L";
            this.uclBuffer_B01_3_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_3_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_3_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_3_L.Error = "";
            this.uclBuffer_B01_3_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_3_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_L.LeftCmdSno = "";
            this.uclBuffer_B01_3_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_L.LeftLoad = false;
            this.uclBuffer_B01_3_L.Location = new System.Drawing.Point(376, 142);
            this.uclBuffer_B01_3_L.Manual = false;
            this.uclBuffer_B01_3_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_3_L.Name = "uclBuffer_B01_3_L";
            this.uclBuffer_B01_3_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_3_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_3_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_L.RightLoad = false;
            this.uclBuffer_B01_3_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_3_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_3_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_3_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_L.TabIndex = 12;
            // 
            // uclBuffer_B01_3_1
            // 
            this.uclBuffer_B01_3_1.Auto = false;
            this.uclBuffer_B01_3_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_3_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_3_1.BufferName = "B01-3-1";
            this.uclBuffer_B01_3_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_3_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_3_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_3_1.Error = "";
            this.uclBuffer_B01_3_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_3_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_1.LeftCmdSno = "";
            this.uclBuffer_B01_3_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_1.LeftLoad = false;
            this.uclBuffer_B01_3_1.Location = new System.Drawing.Point(376, 210);
            this.uclBuffer_B01_3_1.Manual = false;
            this.uclBuffer_B01_3_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_3_1.Name = "uclBuffer_B01_3_1";
            this.uclBuffer_B01_3_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_3_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_3_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_1.RightLoad = false;
            this.uclBuffer_B01_3_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_3_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_3_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_3_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_3_1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(462, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.tableLayoutPanel1.SetRowSpan(this.label5, 2);
            this.label5.Size = new System.Drawing.Size(45, 136);
            this.label5.TabIndex = 64;
            this.label5.Text = "Crane 2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_B01_4_L
            // 
            this.uclBuffer_B01_4_L.Auto = false;
            this.uclBuffer_B01_4_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_4_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_4_L.BufferName = "B01-4-L";
            this.uclBuffer_B01_4_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_4_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_4_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_4_L.Error = "";
            this.uclBuffer_B01_4_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_4_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_L.LeftCmdSno = "";
            this.uclBuffer_B01_4_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_L.LeftLoad = false;
            this.uclBuffer_B01_4_L.Location = new System.Drawing.Point(507, 142);
            this.uclBuffer_B01_4_L.Manual = false;
            this.uclBuffer_B01_4_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_4_L.Name = "uclBuffer_B01_4_L";
            this.uclBuffer_B01_4_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_4_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_4_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_L.RightLoad = false;
            this.uclBuffer_B01_4_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_4_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_4_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_4_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_L.TabIndex = 20;
            // 
            // uclBuffer_B01_4_1
            // 
            this.uclBuffer_B01_4_1.Auto = false;
            this.uclBuffer_B01_4_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_4_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_4_1.BufferName = "B01-4-1";
            this.uclBuffer_B01_4_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_4_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_4_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_4_1.Error = "";
            this.uclBuffer_B01_4_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_4_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_1.LeftCmdSno = "";
            this.uclBuffer_B01_4_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_1.LeftLoad = false;
            this.uclBuffer_B01_4_1.Location = new System.Drawing.Point(507, 210);
            this.uclBuffer_B01_4_1.Manual = false;
            this.uclBuffer_B01_4_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_4_1.Name = "uclBuffer_B01_4_1";
            this.uclBuffer_B01_4_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_4_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_4_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_1.RightLoad = false;
            this.uclBuffer_B01_4_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_4_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_4_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_4_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_4_1.TabIndex = 21;
            // 
            // ptbB02
            // 
            this.ptbB02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbB02.Image = ((System.Drawing.Image)(resources.GetObject("ptbB02.Image")));
            this.ptbB02.Location = new System.Drawing.Point(260, 278);
            this.ptbB02.Margin = new System.Windows.Forms.Padding(0);
            this.ptbB02.Name = "ptbB02";
            this.ptbB02.Size = new System.Drawing.Size(86, 41);
            this.ptbB02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbB02.TabIndex = 60;
            this.ptbB02.TabStop = false;
            this.ptbB02.Tag = "IN";
            this.ptbB02.DoubleClick += new System.EventHandler(this.ptbB02_DoubleClick);
            // 
            // uclBuffer_B01_5_1
            // 
            this.uclBuffer_B01_5_1.Auto = false;
            this.uclBuffer_B01_5_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_5_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_5_1.BufferName = "B01-5-1";
            this.uclBuffer_B01_5_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_5_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_5_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_5_1.Error = "";
            this.uclBuffer_B01_5_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_5_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_1.LeftCmdSno = "";
            this.uclBuffer_B01_5_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_1.LeftLoad = false;
            this.uclBuffer_B01_5_1.Location = new System.Drawing.Point(623, 210);
            this.uclBuffer_B01_5_1.Manual = false;
            this.uclBuffer_B01_5_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_5_1.Name = "uclBuffer_B01_5_1";
            this.uclBuffer_B01_5_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_5_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_5_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_1.RightLoad = false;
            this.uclBuffer_B01_5_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_5_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_5_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_5_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_1.TabIndex = 26;
            // 
            // uclBuffer_B01_5_L
            // 
            this.uclBuffer_B01_5_L.Auto = false;
            this.uclBuffer_B01_5_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_5_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_5_L.BufferName = "B01-5-L";
            this.uclBuffer_B01_5_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_5_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_5_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_5_L.Error = "";
            this.uclBuffer_B01_5_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_5_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_L.LeftCmdSno = "";
            this.uclBuffer_B01_5_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_L.LeftLoad = false;
            this.uclBuffer_B01_5_L.Location = new System.Drawing.Point(623, 142);
            this.uclBuffer_B01_5_L.Manual = false;
            this.uclBuffer_B01_5_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_5_L.Name = "uclBuffer_B01_5_L";
            this.uclBuffer_B01_5_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_5_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_5_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_L.RightLoad = false;
            this.uclBuffer_B01_5_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_5_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_5_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_5_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_5_L.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(709, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.tableLayoutPanel1.SetRowSpan(this.label4, 2);
            this.label4.Size = new System.Drawing.Size(45, 136);
            this.label4.TabIndex = 63;
            this.label4.Text = "Crane 3";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_B01_6_1
            // 
            this.uclBuffer_B01_6_1.Auto = false;
            this.uclBuffer_B01_6_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_6_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_6_1.BufferName = "B01-6-1";
            this.uclBuffer_B01_6_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_6_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_6_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_6_1.Error = "";
            this.uclBuffer_B01_6_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_6_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_1.LeftCmdSno = "";
            this.uclBuffer_B01_6_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_1.LeftLoad = false;
            this.uclBuffer_B01_6_1.Location = new System.Drawing.Point(754, 210);
            this.uclBuffer_B01_6_1.Manual = false;
            this.uclBuffer_B01_6_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_6_1.Name = "uclBuffer_B01_6_1";
            this.uclBuffer_B01_6_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_6_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_6_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_1.RightLoad = false;
            this.uclBuffer_B01_6_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_6_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_6_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_6_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_1.TabIndex = 27;
            // 
            // uclBuffer_B01_6_L
            // 
            this.uclBuffer_B01_6_L.Auto = false;
            this.uclBuffer_B01_6_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_B01_6_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_B01_6_L.BufferName = "B01-6-L";
            this.uclBuffer_B01_6_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_B01_6_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_B01_6_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_B01_6_L.Error = "";
            this.uclBuffer_B01_6_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_B01_6_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_L.LeftCmdSno = "";
            this.uclBuffer_B01_6_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_L.LeftLoad = false;
            this.uclBuffer_B01_6_L.Location = new System.Drawing.Point(754, 142);
            this.uclBuffer_B01_6_L.Manual = false;
            this.uclBuffer_B01_6_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_B01_6_L.Name = "uclBuffer_B01_6_L";
            this.uclBuffer_B01_6_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_B01_6_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_B01_6_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_L.RightLoad = false;
            this.uclBuffer_B01_6_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_B01_6_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_B01_6_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_B01_6_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_B01_6_L.TabIndex = 28;
            // 
            // ptbB04
            // 
            this.ptbB04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbB04.Image = ((System.Drawing.Image)(resources.GetObject("ptbB04.Image")));
            this.ptbB04.Location = new System.Drawing.Point(507, 278);
            this.ptbB04.Margin = new System.Windows.Forms.Padding(0);
            this.ptbB04.Name = "ptbB04";
            this.ptbB04.Size = new System.Drawing.Size(86, 41);
            this.ptbB04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbB04.TabIndex = 61;
            this.ptbB04.TabStop = false;
            this.ptbB04.Tag = "IN";
            this.ptbB04.DoubleClick += new System.EventHandler(this.ptbB04_DoubleClick);
            // 
            // ptbB06
            // 
            this.ptbB06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbB06.Image = ((System.Drawing.Image)(resources.GetObject("ptbB06.Image")));
            this.ptbB06.Location = new System.Drawing.Point(754, 278);
            this.ptbB06.Margin = new System.Windows.Forms.Padding(0);
            this.ptbB06.Name = "ptbB06";
            this.ptbB06.Size = new System.Drawing.Size(86, 41);
            this.ptbB06.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbB06.TabIndex = 62;
            this.ptbB06.TabStop = false;
            this.ptbB06.Tag = "IN";
            this.ptbB06.DoubleClick += new System.EventHandler(this.ptbB06_DoubleClick);
            // 
            // ptbB01
            // 
            this.ptbB01.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbB01.Location = new System.Drawing.Point(129, 278);
            this.ptbB01.Margin = new System.Windows.Forms.Padding(0);
            this.ptbB01.Name = "ptbB01";
            this.ptbB01.Size = new System.Drawing.Size(86, 41);
            this.ptbB01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbB01.TabIndex = 67;
            this.ptbB01.TabStop = false;
            this.ptbB01.Tag = "OUT";
            this.ptbB01.DoubleClick += new System.EventHandler(this.ptbB01_DoubleClick);
            // 
            // ptbB03
            // 
            this.ptbB03.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbB03.Location = new System.Drawing.Point(376, 278);
            this.ptbB03.Margin = new System.Windows.Forms.Padding(0);
            this.ptbB03.Name = "ptbB03";
            this.ptbB03.Size = new System.Drawing.Size(86, 41);
            this.ptbB03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbB03.TabIndex = 68;
            this.ptbB03.TabStop = false;
            this.ptbB03.Tag = "OUT";
            this.ptbB03.DoubleClick += new System.EventHandler(this.ptbB03_DoubleClick);
            // 
            // ptbB05
            // 
            this.ptbB05.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbB05.Location = new System.Drawing.Point(623, 278);
            this.ptbB05.Margin = new System.Windows.Forms.Padding(0);
            this.ptbB05.Name = "ptbB05";
            this.ptbB05.Size = new System.Drawing.Size(86, 41);
            this.ptbB05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbB05.TabIndex = 69;
            this.ptbB05.TabStop = false;
            this.ptbB05.Tag = "OUT";
            this.ptbB05.DoubleClick += new System.EventHandler(this.ptbB05_DoubleClick);
            // 
            // tbpASRS_C
            // 
            this.tbpASRS_C.AutoScroll = true;
            this.tbpASRS_C.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpASRS_C.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpASRS_C.Controls.Add(this.tableLayoutPanel2);
            this.tbpASRS_C.Location = new System.Drawing.Point(4, 27);
            this.tbpASRS_C.Name = "tbpASRS_C";
            this.tbpASRS_C.Padding = new System.Windows.Forms.Padding(3);
            this.tbpASRS_C.Size = new System.Drawing.Size(1000, 472);
            this.tbpASRS_C.TabIndex = 2;
            this.tbpASRS_C.Text = "ASRS 4F(C區)";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 13;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.55F));
            this.tableLayoutPanel2.Controls.Add(this.label16, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label15, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.label14, 10, 1);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_1_1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_1_L, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.ptbC02, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_2_1, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_2_L, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_3_1, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_3_L, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.ptbC04, 7, 4);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_4_1, 7, 3);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_4_L, 7, 2);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_5_1, 9, 3);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_5_L, 9, 2);
            this.tableLayoutPanel2.Controls.Add(this.ptbC06, 11, 4);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_6_1, 11, 3);
            this.tableLayoutPanel2.Controls.Add(this.uclBuffer_C01_6_L, 11, 2);
            this.tableLayoutPanel2.Controls.Add(this.ptbC01, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.ptbC03, 5, 4);
            this.tableLayoutPanel2.Controls.Add(this.ptbC05, 9, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(990, 462);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Yellow;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(215, 74);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.tableLayoutPanel2.SetRowSpan(this.label16, 2);
            this.label16.Size = new System.Drawing.Size(45, 136);
            this.label16.TabIndex = 65;
            this.label16.Text = "Crane 1";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Yellow;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(462, 74);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.tableLayoutPanel2.SetRowSpan(this.label15, 2);
            this.label15.Size = new System.Drawing.Size(45, 136);
            this.label15.TabIndex = 64;
            this.label15.Text = "Crane 2";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Yellow;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(709, 74);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.tableLayoutPanel2.SetRowSpan(this.label14, 2);
            this.label14.Size = new System.Drawing.Size(45, 136);
            this.label14.TabIndex = 63;
            this.label14.Text = "Crane 3";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_C01_1_1
            // 
            this.uclBuffer_C01_1_1.Auto = false;
            this.uclBuffer_C01_1_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_1_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_1_1.BufferName = "C01-1-1";
            this.uclBuffer_C01_1_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_1_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_1_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_1_1.Error = "";
            this.uclBuffer_C01_1_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_1_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_1.LeftCmdSno = "";
            this.uclBuffer_C01_1_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_1.LeftLoad = false;
            this.uclBuffer_C01_1_1.Location = new System.Drawing.Point(129, 210);
            this.uclBuffer_C01_1_1.Manual = false;
            this.uclBuffer_C01_1_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_1_1.Name = "uclBuffer_C01_1_1";
            this.uclBuffer_C01_1_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_1_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_1_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_1.RightLoad = false;
            this.uclBuffer_C01_1_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_1_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_1_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_1_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_1.TabIndex = 0;
            // 
            // uclBuffer_C01_1_L
            // 
            this.uclBuffer_C01_1_L.Auto = false;
            this.uclBuffer_C01_1_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_1_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_1_L.BufferName = "C01-1-L";
            this.uclBuffer_C01_1_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_1_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_1_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_1_L.Error = "";
            this.uclBuffer_C01_1_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_1_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_L.LeftCmdSno = "";
            this.uclBuffer_C01_1_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_L.LeftLoad = false;
            this.uclBuffer_C01_1_L.Location = new System.Drawing.Point(129, 142);
            this.uclBuffer_C01_1_L.Manual = false;
            this.uclBuffer_C01_1_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_1_L.Name = "uclBuffer_C01_1_L";
            this.uclBuffer_C01_1_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_1_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_1_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_L.RightLoad = false;
            this.uclBuffer_C01_1_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_1_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_1_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_1_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_1_L.TabIndex = 1;
            // 
            // ptbC02
            // 
            this.ptbC02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbC02.Image = ((System.Drawing.Image)(resources.GetObject("ptbC02.Image")));
            this.ptbC02.Location = new System.Drawing.Point(260, 278);
            this.ptbC02.Margin = new System.Windows.Forms.Padding(0);
            this.ptbC02.Name = "ptbC02";
            this.ptbC02.Size = new System.Drawing.Size(86, 41);
            this.ptbC02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbC02.TabIndex = 60;
            this.ptbC02.TabStop = false;
            this.ptbC02.Tag = "IN";
            this.ptbC02.DoubleClick += new System.EventHandler(this.ptbC02_DoubleClick);
            // 
            // uclBuffer_C01_2_1
            // 
            this.uclBuffer_C01_2_1.Auto = false;
            this.uclBuffer_C01_2_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_2_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_2_1.BufferName = "C01-2-1";
            this.uclBuffer_C01_2_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_2_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_2_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_2_1.Error = "";
            this.uclBuffer_C01_2_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_2_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_1.LeftCmdSno = "";
            this.uclBuffer_C01_2_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_1.LeftLoad = false;
            this.uclBuffer_C01_2_1.Location = new System.Drawing.Point(260, 210);
            this.uclBuffer_C01_2_1.Manual = false;
            this.uclBuffer_C01_2_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_2_1.Name = "uclBuffer_C01_2_1";
            this.uclBuffer_C01_2_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_2_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_2_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_1.RightLoad = false;
            this.uclBuffer_C01_2_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_2_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_2_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_2_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_1.TabIndex = 10;
            // 
            // uclBuffer_C01_2_L
            // 
            this.uclBuffer_C01_2_L.Auto = false;
            this.uclBuffer_C01_2_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_2_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_2_L.BufferName = "C01-2-L";
            this.uclBuffer_C01_2_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_2_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_2_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_2_L.Error = "";
            this.uclBuffer_C01_2_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_2_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_L.LeftCmdSno = "";
            this.uclBuffer_C01_2_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_L.LeftLoad = false;
            this.uclBuffer_C01_2_L.Location = new System.Drawing.Point(260, 142);
            this.uclBuffer_C01_2_L.Manual = false;
            this.uclBuffer_C01_2_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_2_L.Name = "uclBuffer_C01_2_L";
            this.uclBuffer_C01_2_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_2_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_2_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_L.RightLoad = false;
            this.uclBuffer_C01_2_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_2_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_2_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_2_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_2_L.TabIndex = 9;
            // 
            // uclBuffer_C01_3_1
            // 
            this.uclBuffer_C01_3_1.Auto = false;
            this.uclBuffer_C01_3_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_3_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_3_1.BufferName = "C01-3-1";
            this.uclBuffer_C01_3_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_3_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_3_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_3_1.Error = "";
            this.uclBuffer_C01_3_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_3_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_1.LeftCmdSno = "";
            this.uclBuffer_C01_3_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_1.LeftLoad = false;
            this.uclBuffer_C01_3_1.Location = new System.Drawing.Point(376, 210);
            this.uclBuffer_C01_3_1.Manual = false;
            this.uclBuffer_C01_3_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_3_1.Name = "uclBuffer_C01_3_1";
            this.uclBuffer_C01_3_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_3_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_3_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_1.RightLoad = false;
            this.uclBuffer_C01_3_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_3_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_3_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_3_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_1.TabIndex = 11;
            // 
            // uclBuffer_C01_3_L
            // 
            this.uclBuffer_C01_3_L.Auto = false;
            this.uclBuffer_C01_3_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_3_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_3_L.BufferName = "C01-3-L";
            this.uclBuffer_C01_3_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_3_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_3_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_3_L.Error = "";
            this.uclBuffer_C01_3_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_3_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_L.LeftCmdSno = "";
            this.uclBuffer_C01_3_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_L.LeftLoad = false;
            this.uclBuffer_C01_3_L.Location = new System.Drawing.Point(376, 142);
            this.uclBuffer_C01_3_L.Manual = false;
            this.uclBuffer_C01_3_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_3_L.Name = "uclBuffer_C01_3_L";
            this.uclBuffer_C01_3_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_3_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_3_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_L.RightLoad = false;
            this.uclBuffer_C01_3_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_3_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_3_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_3_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_3_L.TabIndex = 12;
            // 
            // ptbC04
            // 
            this.ptbC04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbC04.Image = ((System.Drawing.Image)(resources.GetObject("ptbC04.Image")));
            this.ptbC04.Location = new System.Drawing.Point(507, 278);
            this.ptbC04.Margin = new System.Windows.Forms.Padding(0);
            this.ptbC04.Name = "ptbC04";
            this.ptbC04.Size = new System.Drawing.Size(86, 41);
            this.ptbC04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbC04.TabIndex = 61;
            this.ptbC04.TabStop = false;
            this.ptbC04.Tag = "IN";
            this.ptbC04.DoubleClick += new System.EventHandler(this.ptbC04_DoubleClick);
            // 
            // uclBuffer_C01_4_1
            // 
            this.uclBuffer_C01_4_1.Auto = false;
            this.uclBuffer_C01_4_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_4_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_4_1.BufferName = "C01-4-1";
            this.uclBuffer_C01_4_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_4_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_4_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_4_1.Error = "";
            this.uclBuffer_C01_4_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_4_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_1.LeftCmdSno = "";
            this.uclBuffer_C01_4_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_1.LeftLoad = false;
            this.uclBuffer_C01_4_1.Location = new System.Drawing.Point(507, 210);
            this.uclBuffer_C01_4_1.Manual = false;
            this.uclBuffer_C01_4_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_4_1.Name = "uclBuffer_C01_4_1";
            this.uclBuffer_C01_4_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_4_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_4_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_1.RightLoad = false;
            this.uclBuffer_C01_4_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_4_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_4_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_4_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_1.TabIndex = 21;
            // 
            // uclBuffer_C01_4_L
            // 
            this.uclBuffer_C01_4_L.Auto = false;
            this.uclBuffer_C01_4_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_4_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_4_L.BufferName = "C01-4-L";
            this.uclBuffer_C01_4_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_4_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_4_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_4_L.Error = "";
            this.uclBuffer_C01_4_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_4_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_L.LeftCmdSno = "";
            this.uclBuffer_C01_4_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_L.LeftLoad = false;
            this.uclBuffer_C01_4_L.Location = new System.Drawing.Point(507, 142);
            this.uclBuffer_C01_4_L.Manual = false;
            this.uclBuffer_C01_4_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_4_L.Name = "uclBuffer_C01_4_L";
            this.uclBuffer_C01_4_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_4_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_4_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_L.RightLoad = false;
            this.uclBuffer_C01_4_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_4_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_4_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_4_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_4_L.TabIndex = 20;
            // 
            // uclBuffer_C01_5_1
            // 
            this.uclBuffer_C01_5_1.Auto = false;
            this.uclBuffer_C01_5_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_5_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_5_1.BufferName = "C01-5-1";
            this.uclBuffer_C01_5_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_5_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_5_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_5_1.Error = "";
            this.uclBuffer_C01_5_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_5_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_1.LeftCmdSno = "";
            this.uclBuffer_C01_5_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_1.LeftLoad = false;
            this.uclBuffer_C01_5_1.Location = new System.Drawing.Point(623, 210);
            this.uclBuffer_C01_5_1.Manual = false;
            this.uclBuffer_C01_5_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_5_1.Name = "uclBuffer_C01_5_1";
            this.uclBuffer_C01_5_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_5_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_5_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_1.RightLoad = false;
            this.uclBuffer_C01_5_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_5_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_5_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_5_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_1.TabIndex = 26;
            // 
            // uclBuffer_C01_5_L
            // 
            this.uclBuffer_C01_5_L.Auto = false;
            this.uclBuffer_C01_5_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_5_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_5_L.BufferName = "C01-5-L";
            this.uclBuffer_C01_5_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_5_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_5_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_5_L.Error = "";
            this.uclBuffer_C01_5_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_5_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_L.LeftCmdSno = "";
            this.uclBuffer_C01_5_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_L.LeftLoad = false;
            this.uclBuffer_C01_5_L.Location = new System.Drawing.Point(623, 142);
            this.uclBuffer_C01_5_L.Manual = false;
            this.uclBuffer_C01_5_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_5_L.Name = "uclBuffer_C01_5_L";
            this.uclBuffer_C01_5_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_5_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_5_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_L.RightLoad = false;
            this.uclBuffer_C01_5_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_5_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_5_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_5_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_5_L.TabIndex = 25;
            // 
            // ptbC06
            // 
            this.ptbC06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbC06.Image = ((System.Drawing.Image)(resources.GetObject("ptbC06.Image")));
            this.ptbC06.Location = new System.Drawing.Point(754, 278);
            this.ptbC06.Margin = new System.Windows.Forms.Padding(0);
            this.ptbC06.Name = "ptbC06";
            this.ptbC06.Size = new System.Drawing.Size(86, 41);
            this.ptbC06.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbC06.TabIndex = 62;
            this.ptbC06.TabStop = false;
            this.ptbC06.Tag = "IN";
            this.ptbC06.DoubleClick += new System.EventHandler(this.ptbC06_DoubleClick);
            // 
            // uclBuffer_C01_6_1
            // 
            this.uclBuffer_C01_6_1.Auto = false;
            this.uclBuffer_C01_6_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_6_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_6_1.BufferName = "C01-6-1";
            this.uclBuffer_C01_6_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_6_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_6_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_6_1.Error = "";
            this.uclBuffer_C01_6_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_6_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_1.LeftCmdSno = "";
            this.uclBuffer_C01_6_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_1.LeftLoad = false;
            this.uclBuffer_C01_6_1.Location = new System.Drawing.Point(754, 210);
            this.uclBuffer_C01_6_1.Manual = false;
            this.uclBuffer_C01_6_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_6_1.Name = "uclBuffer_C01_6_1";
            this.uclBuffer_C01_6_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_6_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_6_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_1.RightLoad = false;
            this.uclBuffer_C01_6_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_6_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_6_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_6_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_1.TabIndex = 27;
            // 
            // uclBuffer_C01_6_L
            // 
            this.uclBuffer_C01_6_L.Auto = false;
            this.uclBuffer_C01_6_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_C01_6_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_C01_6_L.BufferName = "C01-6-L";
            this.uclBuffer_C01_6_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_C01_6_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_C01_6_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_C01_6_L.Error = "";
            this.uclBuffer_C01_6_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_C01_6_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_L.LeftCmdSno = "";
            this.uclBuffer_C01_6_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_L.LeftLoad = false;
            this.uclBuffer_C01_6_L.Location = new System.Drawing.Point(754, 142);
            this.uclBuffer_C01_6_L.Manual = false;
            this.uclBuffer_C01_6_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_C01_6_L.Name = "uclBuffer_C01_6_L";
            this.uclBuffer_C01_6_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_C01_6_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_C01_6_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_L.RightLoad = false;
            this.uclBuffer_C01_6_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_C01_6_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_C01_6_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_C01_6_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_C01_6_L.TabIndex = 28;
            // 
            // ptbC01
            // 
            this.ptbC01.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbC01.Location = new System.Drawing.Point(129, 278);
            this.ptbC01.Margin = new System.Windows.Forms.Padding(0);
            this.ptbC01.Name = "ptbC01";
            this.ptbC01.Size = new System.Drawing.Size(86, 41);
            this.ptbC01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbC01.TabIndex = 68;
            this.ptbC01.TabStop = false;
            this.ptbC01.Tag = "OUT";
            this.ptbC01.DoubleClick += new System.EventHandler(this.ptbC01_DoubleClick);
            // 
            // ptbC03
            // 
            this.ptbC03.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbC03.Location = new System.Drawing.Point(376, 278);
            this.ptbC03.Margin = new System.Windows.Forms.Padding(0);
            this.ptbC03.Name = "ptbC03";
            this.ptbC03.Size = new System.Drawing.Size(86, 41);
            this.ptbC03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbC03.TabIndex = 69;
            this.ptbC03.TabStop = false;
            this.ptbC03.Tag = "OUT";
            this.ptbC03.DoubleClick += new System.EventHandler(this.ptbC03_DoubleClick);
            // 
            // ptbC05
            // 
            this.ptbC05.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbC05.Location = new System.Drawing.Point(623, 278);
            this.ptbC05.Margin = new System.Windows.Forms.Padding(0);
            this.ptbC05.Name = "ptbC05";
            this.ptbC05.Size = new System.Drawing.Size(86, 41);
            this.ptbC05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbC05.TabIndex = 70;
            this.ptbC05.TabStop = false;
            this.ptbC05.Tag = "OUT";
            this.ptbC05.DoubleClick += new System.EventHandler(this.ptbC05_DoubleClick);
            // 
            // tbpASRS_D
            // 
            this.tbpASRS_D.AutoScroll = true;
            this.tbpASRS_D.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbpASRS_D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpASRS_D.Controls.Add(this.tableLayoutPanel3);
            this.tbpASRS_D.Location = new System.Drawing.Point(4, 27);
            this.tbpASRS_D.Name = "tbpASRS_D";
            this.tbpASRS_D.Padding = new System.Windows.Forms.Padding(3);
            this.tbpASRS_D.Size = new System.Drawing.Size(1000, 472);
            this.tbpASRS_D.TabIndex = 3;
            this.tbpASRS_D.Text = "ASRS 5F(D區)";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 13;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.55F));
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_2_1, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_1_1, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_1_L, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_2_L, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.label8, 6, 1);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_3_1, 5, 3);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_3_L, 5, 2);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_4_L, 7, 2);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_4_1, 7, 3);
            this.tableLayoutPanel3.Controls.Add(this.ptbD02, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.ptbD04, 7, 4);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_5_1, 9, 3);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_5_L, 9, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 10, 1);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_6_1, 11, 3);
            this.tableLayoutPanel3.Controls.Add(this.uclBuffer_D01_6_L, 11, 2);
            this.tableLayoutPanel3.Controls.Add(this.ptbD06, 11, 4);
            this.tableLayoutPanel3.Controls.Add(this.ptbD01, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.ptbD03, 5, 4);
            this.tableLayoutPanel3.Controls.Add(this.ptbD05, 9, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(990, 462);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // uclBuffer_D01_2_1
            // 
            this.uclBuffer_D01_2_1.Auto = false;
            this.uclBuffer_D01_2_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_2_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_2_1.BufferName = "D01-2-1";
            this.uclBuffer_D01_2_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_2_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_2_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_2_1.Error = "";
            this.uclBuffer_D01_2_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_2_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_1.LeftCmdSno = "";
            this.uclBuffer_D01_2_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_1.LeftLoad = false;
            this.uclBuffer_D01_2_1.Location = new System.Drawing.Point(260, 210);
            this.uclBuffer_D01_2_1.Manual = false;
            this.uclBuffer_D01_2_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_2_1.Name = "uclBuffer_D01_2_1";
            this.uclBuffer_D01_2_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_2_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_2_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_1.RightLoad = false;
            this.uclBuffer_D01_2_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_2_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_2_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_2_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_1.TabIndex = 10;
            // 
            // uclBuffer_D01_1_1
            // 
            this.uclBuffer_D01_1_1.Auto = false;
            this.uclBuffer_D01_1_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_1_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_1_1.BufferName = "D01-1-1";
            this.uclBuffer_D01_1_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_1_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_1_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_1_1.Error = "";
            this.uclBuffer_D01_1_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_1_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_1.LeftCmdSno = "";
            this.uclBuffer_D01_1_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_1.LeftLoad = false;
            this.uclBuffer_D01_1_1.Location = new System.Drawing.Point(129, 210);
            this.uclBuffer_D01_1_1.Manual = false;
            this.uclBuffer_D01_1_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_1_1.Name = "uclBuffer_D01_1_1";
            this.uclBuffer_D01_1_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_1_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_1_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_1.RightLoad = false;
            this.uclBuffer_D01_1_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_1_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_1_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_1_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_1.TabIndex = 0;
            // 
            // uclBuffer_D01_1_L
            // 
            this.uclBuffer_D01_1_L.Auto = false;
            this.uclBuffer_D01_1_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_1_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_1_L.BufferName = "D01-1-L";
            this.uclBuffer_D01_1_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_1_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_1_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_1_L.Error = "";
            this.uclBuffer_D01_1_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_1_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_L.LeftCmdSno = "";
            this.uclBuffer_D01_1_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_L.LeftLoad = false;
            this.uclBuffer_D01_1_L.Location = new System.Drawing.Point(129, 142);
            this.uclBuffer_D01_1_L.Manual = false;
            this.uclBuffer_D01_1_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_1_L.Name = "uclBuffer_D01_1_L";
            this.uclBuffer_D01_1_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_1_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_1_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_L.RightLoad = false;
            this.uclBuffer_D01_1_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_1_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_1_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_1_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_1_L.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Yellow;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(215, 74);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.tableLayoutPanel3.SetRowSpan(this.label9, 2);
            this.label9.Size = new System.Drawing.Size(45, 136);
            this.label9.TabIndex = 65;
            this.label9.Text = "Crane 1";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_D01_2_L
            // 
            this.uclBuffer_D01_2_L.Auto = false;
            this.uclBuffer_D01_2_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_2_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_2_L.BufferName = "D01-2-L";
            this.uclBuffer_D01_2_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_2_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_2_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_2_L.Error = "";
            this.uclBuffer_D01_2_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_2_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_L.LeftCmdSno = "";
            this.uclBuffer_D01_2_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_L.LeftLoad = false;
            this.uclBuffer_D01_2_L.Location = new System.Drawing.Point(260, 142);
            this.uclBuffer_D01_2_L.Manual = false;
            this.uclBuffer_D01_2_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_2_L.Name = "uclBuffer_D01_2_L";
            this.uclBuffer_D01_2_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_2_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_2_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_L.RightLoad = false;
            this.uclBuffer_D01_2_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_2_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_2_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_2_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_2_L.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Yellow;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(462, 74);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.tableLayoutPanel3.SetRowSpan(this.label8, 2);
            this.label8.Size = new System.Drawing.Size(45, 136);
            this.label8.TabIndex = 64;
            this.label8.Text = "Crane 2";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_D01_3_1
            // 
            this.uclBuffer_D01_3_1.Auto = false;
            this.uclBuffer_D01_3_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_3_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_3_1.BufferName = "D01-3-1";
            this.uclBuffer_D01_3_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_3_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_3_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_3_1.Error = "";
            this.uclBuffer_D01_3_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_3_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_1.LeftCmdSno = "";
            this.uclBuffer_D01_3_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_1.LeftLoad = false;
            this.uclBuffer_D01_3_1.Location = new System.Drawing.Point(376, 210);
            this.uclBuffer_D01_3_1.Manual = false;
            this.uclBuffer_D01_3_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_3_1.Name = "uclBuffer_D01_3_1";
            this.uclBuffer_D01_3_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_3_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_3_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_1.RightLoad = false;
            this.uclBuffer_D01_3_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_3_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_3_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_3_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_1.TabIndex = 11;
            // 
            // uclBuffer_D01_3_L
            // 
            this.uclBuffer_D01_3_L.Auto = false;
            this.uclBuffer_D01_3_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_3_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_3_L.BufferName = "D01-3-L";
            this.uclBuffer_D01_3_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_3_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_3_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_3_L.Error = "";
            this.uclBuffer_D01_3_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_3_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_L.LeftCmdSno = "";
            this.uclBuffer_D01_3_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_L.LeftLoad = false;
            this.uclBuffer_D01_3_L.Location = new System.Drawing.Point(376, 142);
            this.uclBuffer_D01_3_L.Manual = false;
            this.uclBuffer_D01_3_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_3_L.Name = "uclBuffer_D01_3_L";
            this.uclBuffer_D01_3_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_3_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_3_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_L.RightLoad = false;
            this.uclBuffer_D01_3_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_3_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_3_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_3_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_3_L.TabIndex = 12;
            // 
            // uclBuffer_D01_4_L
            // 
            this.uclBuffer_D01_4_L.Auto = false;
            this.uclBuffer_D01_4_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_4_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_4_L.BufferName = "D01-4-L";
            this.uclBuffer_D01_4_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_4_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_4_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_4_L.Error = "";
            this.uclBuffer_D01_4_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_4_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_L.LeftCmdSno = "";
            this.uclBuffer_D01_4_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_L.LeftLoad = false;
            this.uclBuffer_D01_4_L.Location = new System.Drawing.Point(507, 142);
            this.uclBuffer_D01_4_L.Manual = false;
            this.uclBuffer_D01_4_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_4_L.Name = "uclBuffer_D01_4_L";
            this.uclBuffer_D01_4_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_4_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_4_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_L.RightLoad = false;
            this.uclBuffer_D01_4_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_4_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_4_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_4_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_L.TabIndex = 20;
            // 
            // uclBuffer_D01_4_1
            // 
            this.uclBuffer_D01_4_1.Auto = false;
            this.uclBuffer_D01_4_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_4_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_4_1.BufferName = "D01-4-1";
            this.uclBuffer_D01_4_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_4_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_4_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_4_1.Error = "";
            this.uclBuffer_D01_4_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_4_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_1.LeftCmdSno = "";
            this.uclBuffer_D01_4_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_1.LeftLoad = false;
            this.uclBuffer_D01_4_1.Location = new System.Drawing.Point(507, 210);
            this.uclBuffer_D01_4_1.Manual = false;
            this.uclBuffer_D01_4_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_4_1.Name = "uclBuffer_D01_4_1";
            this.uclBuffer_D01_4_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_4_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_4_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_1.RightLoad = false;
            this.uclBuffer_D01_4_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_4_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_4_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_4_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_4_1.TabIndex = 21;
            // 
            // ptbD02
            // 
            this.ptbD02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbD02.Image = ((System.Drawing.Image)(resources.GetObject("ptbD02.Image")));
            this.ptbD02.Location = new System.Drawing.Point(260, 278);
            this.ptbD02.Margin = new System.Windows.Forms.Padding(0);
            this.ptbD02.Name = "ptbD02";
            this.ptbD02.Size = new System.Drawing.Size(86, 41);
            this.ptbD02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbD02.TabIndex = 60;
            this.ptbD02.TabStop = false;
            this.ptbD02.Tag = "IN";
            this.ptbD02.DoubleClick += new System.EventHandler(this.ptbD02_DoubleClick);
            // 
            // ptbD04
            // 
            this.ptbD04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbD04.Image = ((System.Drawing.Image)(resources.GetObject("ptbD04.Image")));
            this.ptbD04.Location = new System.Drawing.Point(507, 278);
            this.ptbD04.Margin = new System.Windows.Forms.Padding(0);
            this.ptbD04.Name = "ptbD04";
            this.ptbD04.Size = new System.Drawing.Size(86, 41);
            this.ptbD04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbD04.TabIndex = 61;
            this.ptbD04.TabStop = false;
            this.ptbD04.Tag = "IN";
            this.ptbD04.DoubleClick += new System.EventHandler(this.ptbD04_DoubleClick);
            // 
            // uclBuffer_D01_5_1
            // 
            this.uclBuffer_D01_5_1.Auto = false;
            this.uclBuffer_D01_5_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_5_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_5_1.BufferName = "D01-5-1";
            this.uclBuffer_D01_5_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_5_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_5_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_5_1.Error = "";
            this.uclBuffer_D01_5_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_5_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_1.LeftCmdSno = "";
            this.uclBuffer_D01_5_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_1.LeftLoad = false;
            this.uclBuffer_D01_5_1.Location = new System.Drawing.Point(623, 210);
            this.uclBuffer_D01_5_1.Manual = false;
            this.uclBuffer_D01_5_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_5_1.Name = "uclBuffer_D01_5_1";
            this.uclBuffer_D01_5_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_5_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_5_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_1.RightLoad = false;
            this.uclBuffer_D01_5_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_5_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_5_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_5_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_1.TabIndex = 26;
            // 
            // uclBuffer_D01_5_L
            // 
            this.uclBuffer_D01_5_L.Auto = false;
            this.uclBuffer_D01_5_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_5_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_5_L.BufferName = "D01-5-L";
            this.uclBuffer_D01_5_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_5_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_5_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_5_L.Error = "";
            this.uclBuffer_D01_5_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_5_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_L.LeftCmdSno = "";
            this.uclBuffer_D01_5_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_L.LeftLoad = false;
            this.uclBuffer_D01_5_L.Location = new System.Drawing.Point(623, 142);
            this.uclBuffer_D01_5_L.Manual = false;
            this.uclBuffer_D01_5_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_5_L.Name = "uclBuffer_D01_5_L";
            this.uclBuffer_D01_5_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_5_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_5_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_L.RightLoad = false;
            this.uclBuffer_D01_5_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_5_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_5_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_5_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_5_L.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Yellow;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(709, 74);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.tableLayoutPanel3.SetRowSpan(this.label7, 2);
            this.label7.Size = new System.Drawing.Size(45, 136);
            this.label7.TabIndex = 63;
            this.label7.Text = "Crane 3";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_D01_6_1
            // 
            this.uclBuffer_D01_6_1.Auto = false;
            this.uclBuffer_D01_6_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_6_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_6_1.BufferName = "D01-6-1";
            this.uclBuffer_D01_6_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_6_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_6_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_6_1.Error = "";
            this.uclBuffer_D01_6_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_6_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_1.LeftCmdSno = "";
            this.uclBuffer_D01_6_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_1.LeftLoad = false;
            this.uclBuffer_D01_6_1.Location = new System.Drawing.Point(754, 210);
            this.uclBuffer_D01_6_1.Manual = false;
            this.uclBuffer_D01_6_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_6_1.Name = "uclBuffer_D01_6_1";
            this.uclBuffer_D01_6_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_6_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_6_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_1.RightLoad = false;
            this.uclBuffer_D01_6_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_6_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_6_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_6_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_1.TabIndex = 27;
            // 
            // uclBuffer_D01_6_L
            // 
            this.uclBuffer_D01_6_L.Auto = false;
            this.uclBuffer_D01_6_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_D01_6_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_D01_6_L.BufferName = "D01-6-L";
            this.uclBuffer_D01_6_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_D01_6_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_D01_6_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_D01_6_L.Error = "";
            this.uclBuffer_D01_6_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_D01_6_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_L.LeftCmdSno = "";
            this.uclBuffer_D01_6_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_L.LeftLoad = false;
            this.uclBuffer_D01_6_L.Location = new System.Drawing.Point(754, 142);
            this.uclBuffer_D01_6_L.Manual = false;
            this.uclBuffer_D01_6_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_D01_6_L.Name = "uclBuffer_D01_6_L";
            this.uclBuffer_D01_6_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_D01_6_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_D01_6_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_L.RightLoad = false;
            this.uclBuffer_D01_6_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_D01_6_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_D01_6_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_D01_6_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_D01_6_L.TabIndex = 28;
            // 
            // ptbD06
            // 
            this.ptbD06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbD06.Image = ((System.Drawing.Image)(resources.GetObject("ptbD06.Image")));
            this.ptbD06.Location = new System.Drawing.Point(754, 278);
            this.ptbD06.Margin = new System.Windows.Forms.Padding(0);
            this.ptbD06.Name = "ptbD06";
            this.ptbD06.Size = new System.Drawing.Size(86, 41);
            this.ptbD06.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbD06.TabIndex = 62;
            this.ptbD06.TabStop = false;
            this.ptbD06.Tag = "IN";
            this.ptbD06.DoubleClick += new System.EventHandler(this.ptbD06_DoubleClick);
            // 
            // ptbD01
            // 
            this.ptbD01.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbD01.Location = new System.Drawing.Point(129, 278);
            this.ptbD01.Margin = new System.Windows.Forms.Padding(0);
            this.ptbD01.Name = "ptbD01";
            this.ptbD01.Size = new System.Drawing.Size(86, 41);
            this.ptbD01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbD01.TabIndex = 69;
            this.ptbD01.TabStop = false;
            this.ptbD01.Tag = "OUT";
            this.ptbD01.DoubleClick += new System.EventHandler(this.ptbD01_DoubleClick);
            // 
            // ptbD03
            // 
            this.ptbD03.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbD03.Location = new System.Drawing.Point(376, 278);
            this.ptbD03.Margin = new System.Windows.Forms.Padding(0);
            this.ptbD03.Name = "ptbD03";
            this.ptbD03.Size = new System.Drawing.Size(86, 41);
            this.ptbD03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbD03.TabIndex = 70;
            this.ptbD03.TabStop = false;
            this.ptbD03.Tag = "OUT";
            this.ptbD03.DoubleClick += new System.EventHandler(this.ptbD03_DoubleClick);
            // 
            // ptbD05
            // 
            this.ptbD05.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbD05.Location = new System.Drawing.Point(623, 278);
            this.ptbD05.Margin = new System.Windows.Forms.Padding(0);
            this.ptbD05.Name = "ptbD05";
            this.ptbD05.Size = new System.Drawing.Size(86, 41);
            this.ptbD05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbD05.TabIndex = 71;
            this.ptbD05.TabStop = false;
            this.ptbD05.Tag = "OUT";
            this.ptbD05.DoubleClick += new System.EventHandler(this.ptbD05_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.tableLayoutPanel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 472);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "ASRS 6F(E區)";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 13;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.33F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.55F));
            this.tableLayoutPanel4.Controls.Add(this.label17, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_1_1, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_1_L, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_2_1, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_2_L, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_3_1, 5, 3);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_3_L, 5, 2);
            this.tableLayoutPanel4.Controls.Add(this.ptbE02, 3, 4);
            this.tableLayoutPanel4.Controls.Add(this.label13, 6, 1);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_4_1, 7, 3);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_4_L, 7, 2);
            this.tableLayoutPanel4.Controls.Add(this.ptbE04, 7, 4);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_5_L, 9, 2);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_5_1, 9, 3);
            this.tableLayoutPanel4.Controls.Add(this.label12, 10, 1);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_6_L, 11, 2);
            this.tableLayoutPanel4.Controls.Add(this.uclBuffer_E01_6_1, 11, 3);
            this.tableLayoutPanel4.Controls.Add(this.ptbE06, 11, 4);
            this.tableLayoutPanel4.Controls.Add(this.ptbE01, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.ptbE03, 5, 4);
            this.tableLayoutPanel4.Controls.Add(this.ptbE05, 9, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(994, 466);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Yellow;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(217, 76);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.tableLayoutPanel4.SetRowSpan(this.label17, 2);
            this.label17.Size = new System.Drawing.Size(45, 136);
            this.label17.TabIndex = 65;
            this.label17.Text = "Crane 1";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_E01_1_1
            // 
            this.uclBuffer_E01_1_1.Auto = false;
            this.uclBuffer_E01_1_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_1_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_1_1.BufferName = "E01-1-1";
            this.uclBuffer_E01_1_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_1_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_1_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_1.Error = "";
            this.uclBuffer_E01_1_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_1_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_1.LeftCmdSno = "";
            this.uclBuffer_E01_1_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_1.LeftLoad = false;
            this.uclBuffer_E01_1_1.Location = new System.Drawing.Point(131, 212);
            this.uclBuffer_E01_1_1.Manual = false;
            this.uclBuffer_E01_1_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_1_1.Name = "uclBuffer_E01_1_1";
            this.uclBuffer_E01_1_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_1_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_1_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_1.RightLoad = false;
            this.uclBuffer_E01_1_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_1_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_1_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_1_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_1.TabIndex = 0;
            // 
            // uclBuffer_E01_1_L
            // 
            this.uclBuffer_E01_1_L.Auto = false;
            this.uclBuffer_E01_1_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_1_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_1_L.BufferName = "E01-1-L";
            this.uclBuffer_E01_1_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_1_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_1_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_L.Error = "";
            this.uclBuffer_E01_1_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_1_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_L.LeftCmdSno = "";
            this.uclBuffer_E01_1_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_L.LeftLoad = false;
            this.uclBuffer_E01_1_L.Location = new System.Drawing.Point(131, 144);
            this.uclBuffer_E01_1_L.Manual = false;
            this.uclBuffer_E01_1_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_1_L.Name = "uclBuffer_E01_1_L";
            this.uclBuffer_E01_1_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_1_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_1_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_L.RightLoad = false;
            this.uclBuffer_E01_1_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_1_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_1_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_1_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_1_L.TabIndex = 1;
            // 
            // uclBuffer_E01_2_1
            // 
            this.uclBuffer_E01_2_1.Auto = false;
            this.uclBuffer_E01_2_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_2_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_2_1.BufferName = "E01-2-1";
            this.uclBuffer_E01_2_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_2_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_2_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_1.Error = "";
            this.uclBuffer_E01_2_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_2_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_1.LeftCmdSno = "";
            this.uclBuffer_E01_2_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_1.LeftLoad = false;
            this.uclBuffer_E01_2_1.Location = new System.Drawing.Point(262, 212);
            this.uclBuffer_E01_2_1.Manual = false;
            this.uclBuffer_E01_2_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_2_1.Name = "uclBuffer_E01_2_1";
            this.uclBuffer_E01_2_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_2_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_2_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_1.RightLoad = false;
            this.uclBuffer_E01_2_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_2_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_2_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_2_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_1.TabIndex = 10;
            // 
            // uclBuffer_E01_2_L
            // 
            this.uclBuffer_E01_2_L.Auto = false;
            this.uclBuffer_E01_2_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_2_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_2_L.BufferName = "E01-2-L";
            this.uclBuffer_E01_2_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_2_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_2_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_L.Error = "";
            this.uclBuffer_E01_2_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_2_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_L.LeftCmdSno = "";
            this.uclBuffer_E01_2_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_L.LeftLoad = false;
            this.uclBuffer_E01_2_L.Location = new System.Drawing.Point(262, 144);
            this.uclBuffer_E01_2_L.Manual = false;
            this.uclBuffer_E01_2_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_2_L.Name = "uclBuffer_E01_2_L";
            this.uclBuffer_E01_2_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_2_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_2_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_L.RightLoad = false;
            this.uclBuffer_E01_2_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_2_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_2_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_2_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_2_L.TabIndex = 9;
            // 
            // uclBuffer_E01_3_1
            // 
            this.uclBuffer_E01_3_1.Auto = false;
            this.uclBuffer_E01_3_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_3_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_3_1.BufferName = "E01-3-1";
            this.uclBuffer_E01_3_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_3_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_3_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_1.Error = "";
            this.uclBuffer_E01_3_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_3_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_1.LeftCmdSno = "";
            this.uclBuffer_E01_3_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_1.LeftLoad = false;
            this.uclBuffer_E01_3_1.Location = new System.Drawing.Point(379, 212);
            this.uclBuffer_E01_3_1.Manual = false;
            this.uclBuffer_E01_3_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_3_1.Name = "uclBuffer_E01_3_1";
            this.uclBuffer_E01_3_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_3_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_3_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_1.RightLoad = false;
            this.uclBuffer_E01_3_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_3_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_3_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_3_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_1.TabIndex = 11;
            // 
            // uclBuffer_E01_3_L
            // 
            this.uclBuffer_E01_3_L.Auto = false;
            this.uclBuffer_E01_3_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_3_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_3_L.BufferName = "E01-3-L";
            this.uclBuffer_E01_3_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_3_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_3_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_L.Error = "";
            this.uclBuffer_E01_3_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_3_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_L.LeftCmdSno = "";
            this.uclBuffer_E01_3_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_L.LeftLoad = false;
            this.uclBuffer_E01_3_L.Location = new System.Drawing.Point(379, 144);
            this.uclBuffer_E01_3_L.Manual = false;
            this.uclBuffer_E01_3_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_3_L.Name = "uclBuffer_E01_3_L";
            this.uclBuffer_E01_3_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_3_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_3_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_L.RightLoad = false;
            this.uclBuffer_E01_3_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_3_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_3_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_3_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_3_L.TabIndex = 12;
            // 
            // ptbE02
            // 
            this.ptbE02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbE02.Image = ((System.Drawing.Image)(resources.GetObject("ptbE02.Image")));
            this.ptbE02.Location = new System.Drawing.Point(262, 280);
            this.ptbE02.Margin = new System.Windows.Forms.Padding(0);
            this.ptbE02.Name = "ptbE02";
            this.ptbE02.Size = new System.Drawing.Size(86, 41);
            this.ptbE02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbE02.TabIndex = 60;
            this.ptbE02.TabStop = false;
            this.ptbE02.Tag = "IN";
            this.ptbE02.DoubleClick += new System.EventHandler(this.ptbE02_DoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Yellow;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(465, 76);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.tableLayoutPanel4.SetRowSpan(this.label13, 2);
            this.label13.Size = new System.Drawing.Size(45, 136);
            this.label13.TabIndex = 64;
            this.label13.Text = "Crane 2";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_E01_4_1
            // 
            this.uclBuffer_E01_4_1.Auto = false;
            this.uclBuffer_E01_4_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_4_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_4_1.BufferName = "E01-4-1";
            this.uclBuffer_E01_4_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_4_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_4_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_1.Error = "";
            this.uclBuffer_E01_4_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_4_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_1.LeftCmdSno = "";
            this.uclBuffer_E01_4_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_1.LeftLoad = false;
            this.uclBuffer_E01_4_1.Location = new System.Drawing.Point(510, 212);
            this.uclBuffer_E01_4_1.Manual = false;
            this.uclBuffer_E01_4_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_4_1.Name = "uclBuffer_E01_4_1";
            this.uclBuffer_E01_4_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_4_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_4_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_1.RightLoad = false;
            this.uclBuffer_E01_4_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_4_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_4_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_4_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_1.TabIndex = 21;
            // 
            // uclBuffer_E01_4_L
            // 
            this.uclBuffer_E01_4_L.Auto = false;
            this.uclBuffer_E01_4_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_4_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_4_L.BufferName = "E01-4-L";
            this.uclBuffer_E01_4_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_4_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_4_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_L.Error = "";
            this.uclBuffer_E01_4_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_4_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_L.LeftCmdSno = "";
            this.uclBuffer_E01_4_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_L.LeftLoad = false;
            this.uclBuffer_E01_4_L.Location = new System.Drawing.Point(510, 144);
            this.uclBuffer_E01_4_L.Manual = false;
            this.uclBuffer_E01_4_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_4_L.Name = "uclBuffer_E01_4_L";
            this.uclBuffer_E01_4_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_4_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_4_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_L.RightLoad = false;
            this.uclBuffer_E01_4_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_4_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_4_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_4_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_4_L.TabIndex = 20;
            // 
            // ptbE04
            // 
            this.ptbE04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbE04.Image = ((System.Drawing.Image)(resources.GetObject("ptbE04.Image")));
            this.ptbE04.Location = new System.Drawing.Point(510, 280);
            this.ptbE04.Margin = new System.Windows.Forms.Padding(0);
            this.ptbE04.Name = "ptbE04";
            this.ptbE04.Size = new System.Drawing.Size(86, 41);
            this.ptbE04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbE04.TabIndex = 61;
            this.ptbE04.TabStop = false;
            this.ptbE04.Tag = "IN";
            this.ptbE04.DoubleClick += new System.EventHandler(this.ptbE04_DoubleClick);
            // 
            // uclBuffer_E01_5_L
            // 
            this.uclBuffer_E01_5_L.Auto = false;
            this.uclBuffer_E01_5_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_5_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_5_L.BufferName = "E01-5-L";
            this.uclBuffer_E01_5_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_5_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_5_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_L.Error = "";
            this.uclBuffer_E01_5_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_5_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_L.LeftCmdSno = "";
            this.uclBuffer_E01_5_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_L.LeftLoad = false;
            this.uclBuffer_E01_5_L.Location = new System.Drawing.Point(627, 144);
            this.uclBuffer_E01_5_L.Manual = false;
            this.uclBuffer_E01_5_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_5_L.Name = "uclBuffer_E01_5_L";
            this.uclBuffer_E01_5_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_5_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_5_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_L.RightLoad = false;
            this.uclBuffer_E01_5_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_5_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_5_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_5_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_L.TabIndex = 25;
            // 
            // uclBuffer_E01_5_1
            // 
            this.uclBuffer_E01_5_1.Auto = false;
            this.uclBuffer_E01_5_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_5_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_5_1.BufferName = "E01-5-1";
            this.uclBuffer_E01_5_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_5_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_5_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_1.Error = "";
            this.uclBuffer_E01_5_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_5_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_1.LeftCmdSno = "";
            this.uclBuffer_E01_5_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_1.LeftLoad = false;
            this.uclBuffer_E01_5_1.Location = new System.Drawing.Point(627, 212);
            this.uclBuffer_E01_5_1.Manual = false;
            this.uclBuffer_E01_5_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_5_1.Name = "uclBuffer_E01_5_1";
            this.uclBuffer_E01_5_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_5_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_5_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_1.RightLoad = false;
            this.uclBuffer_E01_5_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_5_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_5_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_5_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_5_1.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Yellow;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(713, 76);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.tableLayoutPanel4.SetRowSpan(this.label12, 2);
            this.label12.Size = new System.Drawing.Size(45, 136);
            this.label12.TabIndex = 63;
            this.label12.Text = "Crane 3";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_E01_6_L
            // 
            this.uclBuffer_E01_6_L.Auto = false;
            this.uclBuffer_E01_6_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_6_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_6_L.BufferName = "E01-6-L";
            this.uclBuffer_E01_6_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_6_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_6_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_L.Error = "";
            this.uclBuffer_E01_6_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_6_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_L.LeftCmdSno = "";
            this.uclBuffer_E01_6_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_L.LeftLoad = false;
            this.uclBuffer_E01_6_L.Location = new System.Drawing.Point(758, 144);
            this.uclBuffer_E01_6_L.Manual = false;
            this.uclBuffer_E01_6_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_6_L.Name = "uclBuffer_E01_6_L";
            this.uclBuffer_E01_6_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_6_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_6_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_L.RightLoad = false;
            this.uclBuffer_E01_6_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_6_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_6_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_6_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_L.TabIndex = 28;
            // 
            // uclBuffer_E01_6_1
            // 
            this.uclBuffer_E01_6_1.Auto = false;
            this.uclBuffer_E01_6_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_E01_6_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_E01_6_1.BufferName = "E01-6-1";
            this.uclBuffer_E01_6_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_E01_6_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_E01_6_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_1.Error = "";
            this.uclBuffer_E01_6_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_E01_6_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_1.LeftCmdSno = "";
            this.uclBuffer_E01_6_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_1.LeftLoad = false;
            this.uclBuffer_E01_6_1.Location = new System.Drawing.Point(758, 212);
            this.uclBuffer_E01_6_1.Manual = false;
            this.uclBuffer_E01_6_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_E01_6_1.Name = "uclBuffer_E01_6_1";
            this.uclBuffer_E01_6_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_E01_6_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_E01_6_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_1.RightLoad = false;
            this.uclBuffer_E01_6_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_E01_6_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_E01_6_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_E01_6_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_E01_6_1.TabIndex = 27;
            // 
            // ptbE06
            // 
            this.ptbE06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbE06.Image = ((System.Drawing.Image)(resources.GetObject("ptbE06.Image")));
            this.ptbE06.Location = new System.Drawing.Point(758, 280);
            this.ptbE06.Margin = new System.Windows.Forms.Padding(0);
            this.ptbE06.Name = "ptbE06";
            this.ptbE06.Size = new System.Drawing.Size(86, 41);
            this.ptbE06.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbE06.TabIndex = 62;
            this.ptbE06.TabStop = false;
            this.ptbE06.Tag = "IN";
            this.ptbE06.DoubleClick += new System.EventHandler(this.ptbE06_DoubleClick);
            // 
            // ptbE01
            // 
            this.ptbE01.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbE01.Location = new System.Drawing.Point(131, 280);
            this.ptbE01.Margin = new System.Windows.Forms.Padding(0);
            this.ptbE01.Name = "ptbE01";
            this.ptbE01.Size = new System.Drawing.Size(86, 41);
            this.ptbE01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbE01.TabIndex = 72;
            this.ptbE01.TabStop = false;
            this.ptbE01.Tag = "OUT";
            this.ptbE01.DoubleClick += new System.EventHandler(this.ptbE01_DoubleClick);
            // 
            // ptbE03
            // 
            this.ptbE03.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbE03.Location = new System.Drawing.Point(379, 280);
            this.ptbE03.Margin = new System.Windows.Forms.Padding(0);
            this.ptbE03.Name = "ptbE03";
            this.ptbE03.Size = new System.Drawing.Size(86, 41);
            this.ptbE03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbE03.TabIndex = 73;
            this.ptbE03.TabStop = false;
            this.ptbE03.Tag = "OUT";
            this.ptbE03.DoubleClick += new System.EventHandler(this.ptbE03_DoubleClick);
            // 
            // ptbE05
            // 
            this.ptbE05.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbE05.Location = new System.Drawing.Point(627, 280);
            this.ptbE05.Margin = new System.Windows.Forms.Padding(0);
            this.ptbE05.Name = "ptbE05";
            this.ptbE05.Size = new System.Drawing.Size(86, 41);
            this.ptbE05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbE05.TabIndex = 74;
            this.ptbE05.TabStop = false;
            this.ptbE05.Tag = "OUT";
            this.ptbE05.DoubleClick += new System.EventHandler(this.ptbE05_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.tableLayoutPanel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1000, 472);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "ASRS 7F(F區)";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 13;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.33767F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.051811F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.051811F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.55871F));
            this.tableLayoutPanel5.Controls.Add(this.ptbF04, 7, 4);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_1_1, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_1_L, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.label20, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_2_1, 3, 3);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_2_L, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_3_1, 5, 3);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_3_L, 5, 2);
            this.tableLayoutPanel5.Controls.Add(this.label19, 6, 1);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_4_L, 7, 2);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_4_1, 7, 3);
            this.tableLayoutPanel5.Controls.Add(this.label18, 10, 1);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_6_L, 11, 2);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_6_1, 11, 3);
            this.tableLayoutPanel5.Controls.Add(this.ptbF02, 3, 4);
            this.tableLayoutPanel5.Controls.Add(this.ptbF06, 11, 4);
            this.tableLayoutPanel5.Controls.Add(this.ptbF01, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.ptbF03, 5, 4);
            this.tableLayoutPanel5.Controls.Add(this.ptbF05, 9, 4);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_5_L, 9, 2);
            this.tableLayoutPanel5.Controls.Add(this.uclBuffer_F01_5_1, 9, 3);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 7;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(996, 468);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // ptbF04
            // 
            this.ptbF04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbF04.Image = ((System.Drawing.Image)(resources.GetObject("ptbF04.Image")));
            this.ptbF04.Location = new System.Drawing.Point(511, 281);
            this.ptbF04.Margin = new System.Windows.Forms.Padding(0);
            this.ptbF04.Name = "ptbF04";
            this.ptbF04.Size = new System.Drawing.Size(86, 41);
            this.ptbF04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbF04.TabIndex = 60;
            this.ptbF04.TabStop = false;
            this.ptbF04.Tag = "IN";
            this.ptbF04.DoubleClick += new System.EventHandler(this.ptbF04_DoubleClick);
            // 
            // uclBuffer_F01_1_1
            // 
            this.uclBuffer_F01_1_1.Auto = false;
            this.uclBuffer_F01_1_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_1_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_1_1.BufferName = "F01-1-1";
            this.uclBuffer_F01_1_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_1_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_1_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_F01_1_1.Error = "";
            this.uclBuffer_F01_1_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_1_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_1.LeftCmdSno = "";
            this.uclBuffer_F01_1_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_1.LeftLoad = false;
            this.uclBuffer_F01_1_1.Location = new System.Drawing.Point(132, 213);
            this.uclBuffer_F01_1_1.Manual = false;
            this.uclBuffer_F01_1_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_1_1.Name = "uclBuffer_F01_1_1";
            this.uclBuffer_F01_1_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_1_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_1_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_1.RightLoad = false;
            this.uclBuffer_F01_1_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_1_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_1_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_1_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_1.TabIndex = 0;
            // 
            // uclBuffer_F01_1_L
            // 
            this.uclBuffer_F01_1_L.Auto = false;
            this.uclBuffer_F01_1_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_1_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_1_L.BufferName = "F01-1-L";
            this.uclBuffer_F01_1_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_1_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_1_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_F01_1_L.Error = "";
            this.uclBuffer_F01_1_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_1_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_L.LeftCmdSno = "";
            this.uclBuffer_F01_1_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_L.LeftLoad = false;
            this.uclBuffer_F01_1_L.Location = new System.Drawing.Point(132, 145);
            this.uclBuffer_F01_1_L.Manual = false;
            this.uclBuffer_F01_1_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_1_L.Name = "uclBuffer_F01_1_L";
            this.uclBuffer_F01_1_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_1_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_1_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_L.RightLoad = false;
            this.uclBuffer_F01_1_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_1_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_1_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_1_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_1_L.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Yellow;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(218, 77);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.tableLayoutPanel5.SetRowSpan(this.label20, 2);
            this.label20.Size = new System.Drawing.Size(45, 136);
            this.label20.TabIndex = 65;
            this.label20.Text = "Crane 1";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_F01_2_1
            // 
            this.uclBuffer_F01_2_1.Auto = false;
            this.uclBuffer_F01_2_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_2_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_2_1.BufferName = "F01-2-1";
            this.uclBuffer_F01_2_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_2_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_2_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_1.Error = "";
            this.uclBuffer_F01_2_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_2_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_1.LeftCmdSno = "";
            this.uclBuffer_F01_2_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_1.LeftLoad = false;
            this.uclBuffer_F01_2_1.Location = new System.Drawing.Point(263, 213);
            this.uclBuffer_F01_2_1.Manual = false;
            this.uclBuffer_F01_2_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_2_1.Name = "uclBuffer_F01_2_1";
            this.uclBuffer_F01_2_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_2_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_2_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_1.RightLoad = false;
            this.uclBuffer_F01_2_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_2_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_2_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_2_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_1.TabIndex = 10;
            // 
            // uclBuffer_F01_2_L
            // 
            this.uclBuffer_F01_2_L.Auto = false;
            this.uclBuffer_F01_2_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_2_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_2_L.BufferName = "F01-2-L";
            this.uclBuffer_F01_2_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_2_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_2_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_L.Error = "";
            this.uclBuffer_F01_2_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_2_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_L.LeftCmdSno = "";
            this.uclBuffer_F01_2_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_L.LeftLoad = false;
            this.uclBuffer_F01_2_L.Location = new System.Drawing.Point(263, 145);
            this.uclBuffer_F01_2_L.Manual = false;
            this.uclBuffer_F01_2_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_2_L.Name = "uclBuffer_F01_2_L";
            this.uclBuffer_F01_2_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_2_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_2_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_L.RightLoad = false;
            this.uclBuffer_F01_2_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_2_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_2_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_2_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_2_L.TabIndex = 9;
            // 
            // uclBuffer_F01_3_1
            // 
            this.uclBuffer_F01_3_1.Auto = false;
            this.uclBuffer_F01_3_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_3_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_3_1.BufferName = "F01-3-1";
            this.uclBuffer_F01_3_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_3_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_3_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_1.Error = "";
            this.uclBuffer_F01_3_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_3_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_1.LeftCmdSno = "";
            this.uclBuffer_F01_3_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_1.LeftLoad = false;
            this.uclBuffer_F01_3_1.Location = new System.Drawing.Point(380, 213);
            this.uclBuffer_F01_3_1.Manual = false;
            this.uclBuffer_F01_3_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_3_1.Name = "uclBuffer_F01_3_1";
            this.uclBuffer_F01_3_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_3_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_3_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_1.RightLoad = false;
            this.uclBuffer_F01_3_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_3_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_3_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_3_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_1.TabIndex = 11;
            // 
            // uclBuffer_F01_3_L
            // 
            this.uclBuffer_F01_3_L.Auto = false;
            this.uclBuffer_F01_3_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_3_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_3_L.BufferName = "F01-3-L";
            this.uclBuffer_F01_3_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_3_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_3_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_L.Error = "";
            this.uclBuffer_F01_3_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_3_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_L.LeftCmdSno = "";
            this.uclBuffer_F01_3_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_L.LeftLoad = false;
            this.uclBuffer_F01_3_L.Location = new System.Drawing.Point(380, 145);
            this.uclBuffer_F01_3_L.Manual = false;
            this.uclBuffer_F01_3_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_3_L.Name = "uclBuffer_F01_3_L";
            this.uclBuffer_F01_3_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_3_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_3_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_L.RightLoad = false;
            this.uclBuffer_F01_3_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_3_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_3_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_3_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_3_L.TabIndex = 12;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Yellow;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(466, 77);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.tableLayoutPanel5.SetRowSpan(this.label19, 2);
            this.label19.Size = new System.Drawing.Size(45, 136);
            this.label19.TabIndex = 64;
            this.label19.Text = "Crane 2";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_F01_4_L
            // 
            this.uclBuffer_F01_4_L.Auto = false;
            this.uclBuffer_F01_4_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_4_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_4_L.BufferName = "F01-4-L";
            this.uclBuffer_F01_4_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_4_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_4_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_F01_4_L.Error = "";
            this.uclBuffer_F01_4_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_4_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_L.LeftCmdSno = "";
            this.uclBuffer_F01_4_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_L.LeftLoad = false;
            this.uclBuffer_F01_4_L.Location = new System.Drawing.Point(511, 145);
            this.uclBuffer_F01_4_L.Manual = false;
            this.uclBuffer_F01_4_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_4_L.Name = "uclBuffer_F01_4_L";
            this.uclBuffer_F01_4_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_4_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_4_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_L.RightLoad = false;
            this.uclBuffer_F01_4_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_4_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_4_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_4_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_L.TabIndex = 20;
            // 
            // uclBuffer_F01_4_1
            // 
            this.uclBuffer_F01_4_1.Auto = false;
            this.uclBuffer_F01_4_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_4_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_4_1.BufferName = "F01-4-1";
            this.uclBuffer_F01_4_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_4_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_4_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_F01_4_1.Error = "";
            this.uclBuffer_F01_4_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_4_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_1.LeftCmdSno = "";
            this.uclBuffer_F01_4_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_1.LeftLoad = false;
            this.uclBuffer_F01_4_1.Location = new System.Drawing.Point(511, 213);
            this.uclBuffer_F01_4_1.Manual = false;
            this.uclBuffer_F01_4_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_4_1.Name = "uclBuffer_F01_4_1";
            this.uclBuffer_F01_4_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_4_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_4_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_1.RightLoad = false;
            this.uclBuffer_F01_4_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_4_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_4_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_4_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_4_1.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Yellow;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(714, 77);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.tableLayoutPanel5.SetRowSpan(this.label18, 2);
            this.label18.Size = new System.Drawing.Size(45, 136);
            this.label18.TabIndex = 63;
            this.label18.Text = "Crane 3";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_F01_6_L
            // 
            this.uclBuffer_F01_6_L.Auto = false;
            this.uclBuffer_F01_6_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_6_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_6_L.BufferName = "F01-6-L";
            this.uclBuffer_F01_6_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_6_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_6_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_F01_6_L.Error = "";
            this.uclBuffer_F01_6_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_6_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_L.LeftCmdSno = "";
            this.uclBuffer_F01_6_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_L.LeftLoad = false;
            this.uclBuffer_F01_6_L.Location = new System.Drawing.Point(759, 145);
            this.uclBuffer_F01_6_L.Manual = false;
            this.uclBuffer_F01_6_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_6_L.Name = "uclBuffer_F01_6_L";
            this.uclBuffer_F01_6_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_6_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_6_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_L.RightLoad = false;
            this.uclBuffer_F01_6_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_6_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_6_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_6_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_L.TabIndex = 28;
            // 
            // uclBuffer_F01_6_1
            // 
            this.uclBuffer_F01_6_1.Auto = false;
            this.uclBuffer_F01_6_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_6_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_6_1.BufferName = "F01-6-1";
            this.uclBuffer_F01_6_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_6_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_6_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_F01_6_1.Error = "";
            this.uclBuffer_F01_6_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_6_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_1.LeftCmdSno = "";
            this.uclBuffer_F01_6_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_1.LeftLoad = false;
            this.uclBuffer_F01_6_1.Location = new System.Drawing.Point(759, 213);
            this.uclBuffer_F01_6_1.Manual = false;
            this.uclBuffer_F01_6_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_6_1.Name = "uclBuffer_F01_6_1";
            this.uclBuffer_F01_6_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_6_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_6_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_1.RightLoad = false;
            this.uclBuffer_F01_6_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_6_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_6_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_6_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_6_1.TabIndex = 27;
            // 
            // ptbF02
            // 
            this.ptbF02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbF02.Image = ((System.Drawing.Image)(resources.GetObject("ptbF02.Image")));
            this.ptbF02.Location = new System.Drawing.Point(263, 281);
            this.ptbF02.Margin = new System.Windows.Forms.Padding(0);
            this.ptbF02.Name = "ptbF02";
            this.ptbF02.Size = new System.Drawing.Size(86, 41);
            this.ptbF02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbF02.TabIndex = 62;
            this.ptbF02.TabStop = false;
            this.ptbF02.Tag = "IN";
            this.ptbF02.DoubleClick += new System.EventHandler(this.ptbF02_DoubleClick);
            // 
            // ptbF06
            // 
            this.ptbF06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbF06.Image = ((System.Drawing.Image)(resources.GetObject("ptbF06.Image")));
            this.ptbF06.Location = new System.Drawing.Point(759, 281);
            this.ptbF06.Margin = new System.Windows.Forms.Padding(0);
            this.ptbF06.Name = "ptbF06";
            this.ptbF06.Size = new System.Drawing.Size(86, 41);
            this.ptbF06.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbF06.TabIndex = 61;
            this.ptbF06.TabStop = false;
            this.ptbF06.Tag = "IN";
            this.ptbF06.DoubleClick += new System.EventHandler(this.ptbF06_DoubleClick);
            // 
            // ptbF01
            // 
            this.ptbF01.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbF01.Location = new System.Drawing.Point(132, 281);
            this.ptbF01.Margin = new System.Windows.Forms.Padding(0);
            this.ptbF01.Name = "ptbF01";
            this.ptbF01.Size = new System.Drawing.Size(86, 41);
            this.ptbF01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbF01.TabIndex = 72;
            this.ptbF01.TabStop = false;
            this.ptbF01.Tag = "OUT";
            this.ptbF01.DoubleClick += new System.EventHandler(this.ptbF01_DoubleClick);
            // 
            // ptbF03
            // 
            this.ptbF03.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbF03.Location = new System.Drawing.Point(380, 281);
            this.ptbF03.Margin = new System.Windows.Forms.Padding(0);
            this.ptbF03.Name = "ptbF03";
            this.ptbF03.Size = new System.Drawing.Size(86, 41);
            this.ptbF03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbF03.TabIndex = 73;
            this.ptbF03.TabStop = false;
            this.ptbF03.Tag = "OUT";
            this.ptbF03.DoubleClick += new System.EventHandler(this.ptbF03_DoubleClick);
            // 
            // ptbF05
            // 
            this.ptbF05.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbF05.Location = new System.Drawing.Point(628, 281);
            this.ptbF05.Margin = new System.Windows.Forms.Padding(0);
            this.ptbF05.Name = "ptbF05";
            this.ptbF05.Size = new System.Drawing.Size(86, 41);
            this.ptbF05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbF05.TabIndex = 74;
            this.ptbF05.TabStop = false;
            this.ptbF05.Tag = "OUT";
            this.ptbF05.DoubleClick += new System.EventHandler(this.ptbF05_DoubleClick);
            // 
            // uclBuffer_F01_5_L
            // 
            this.uclBuffer_F01_5_L.Auto = false;
            this.uclBuffer_F01_5_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_5_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_5_L.BufferName = "F01-5-L";
            this.uclBuffer_F01_5_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_5_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_5_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_F01_5_L.Error = "";
            this.uclBuffer_F01_5_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_5_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_L.LeftCmdSno = "";
            this.uclBuffer_F01_5_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_L.LeftLoad = false;
            this.uclBuffer_F01_5_L.Location = new System.Drawing.Point(628, 145);
            this.uclBuffer_F01_5_L.Manual = false;
            this.uclBuffer_F01_5_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_5_L.Name = "uclBuffer_F01_5_L";
            this.uclBuffer_F01_5_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_5_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_5_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_L.RightLoad = false;
            this.uclBuffer_F01_5_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_5_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_5_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_5_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_L.TabIndex = 25;
            // 
            // uclBuffer_F01_5_1
            // 
            this.uclBuffer_F01_5_1.Auto = false;
            this.uclBuffer_F01_5_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_F01_5_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_F01_5_1.BufferName = "F01-5-1";
            this.uclBuffer_F01_5_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_F01_5_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_F01_5_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclBuffer_F01_5_1.Error = "";
            this.uclBuffer_F01_5_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_F01_5_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_1.LeftCmdSno = "";
            this.uclBuffer_F01_5_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_1.LeftLoad = false;
            this.uclBuffer_F01_5_1.Location = new System.Drawing.Point(628, 213);
            this.uclBuffer_F01_5_1.Manual = false;
            this.uclBuffer_F01_5_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_F01_5_1.Name = "uclBuffer_F01_5_1";
            this.uclBuffer_F01_5_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_F01_5_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_F01_5_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_1.RightLoad = false;
            this.uclBuffer_F01_5_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_F01_5_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_F01_5_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_F01_5_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_F01_5_1.TabIndex = 26;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage3.Controls.Add(this.tableLayoutPanel6);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(1000, 472);
            this.tabPage3.TabIndex = 7;
            this.tabPage3.Text = "ASRS 8F(G區)";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 13;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.33F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.06F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.55F));
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_1_1, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_1_L, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.label23, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_2_L, 3, 2);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_2_1, 3, 3);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_3_L, 5, 2);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_3_1, 5, 3);
            this.tableLayoutPanel6.Controls.Add(this.label22, 6, 1);
            this.tableLayoutPanel6.Controls.Add(this.ptbG02, 3, 4);
            this.tableLayoutPanel6.Controls.Add(this.ptbG04, 7, 4);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_4_L, 7, 2);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_4_1, 7, 3);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_5_1, 9, 3);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_5_L, 9, 2);
            this.tableLayoutPanel6.Controls.Add(this.label21, 10, 1);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_6_1, 11, 3);
            this.tableLayoutPanel6.Controls.Add(this.uclBuffer_G01_6_L, 11, 2);
            this.tableLayoutPanel6.Controls.Add(this.ptbG06, 11, 4);
            this.tableLayoutPanel6.Controls.Add(this.ptbG01, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.ptbG03, 5, 4);
            this.tableLayoutPanel6.Controls.Add(this.ptbG05, 9, 4);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 7;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(996, 468);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // uclBuffer_G01_1_1
            // 
            this.uclBuffer_G01_1_1.Auto = false;
            this.uclBuffer_G01_1_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_1_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_1_1.BufferName = "G01-1-1";
            this.uclBuffer_G01_1_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_1_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_1_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_1.Error = "";
            this.uclBuffer_G01_1_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_1_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_1.LeftCmdSno = "";
            this.uclBuffer_G01_1_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_1.LeftLoad = false;
            this.uclBuffer_G01_1_1.Location = new System.Drawing.Point(132, 213);
            this.uclBuffer_G01_1_1.Manual = false;
            this.uclBuffer_G01_1_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_1_1.Name = "uclBuffer_G01_1_1";
            this.uclBuffer_G01_1_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_1_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_1_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_1.RightLoad = false;
            this.uclBuffer_G01_1_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_1_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_1_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_1_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_1.TabIndex = 0;
            // 
            // uclBuffer_G01_1_L
            // 
            this.uclBuffer_G01_1_L.Auto = false;
            this.uclBuffer_G01_1_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_1_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_1_L.BufferName = "G01-1-L";
            this.uclBuffer_G01_1_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_1_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_1_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_L.Error = "";
            this.uclBuffer_G01_1_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_1_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_L.LeftCmdSno = "";
            this.uclBuffer_G01_1_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_L.LeftLoad = false;
            this.uclBuffer_G01_1_L.Location = new System.Drawing.Point(132, 145);
            this.uclBuffer_G01_1_L.Manual = false;
            this.uclBuffer_G01_1_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_1_L.Name = "uclBuffer_G01_1_L";
            this.uclBuffer_G01_1_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_1_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_1_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_L.RightLoad = false;
            this.uclBuffer_G01_1_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_1_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_1_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_1_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_1_L.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Yellow;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Location = new System.Drawing.Point(218, 77);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.tableLayoutPanel6.SetRowSpan(this.label23, 2);
            this.label23.Size = new System.Drawing.Size(45, 136);
            this.label23.TabIndex = 65;
            this.label23.Text = "Crane 1";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_G01_2_L
            // 
            this.uclBuffer_G01_2_L.Auto = false;
            this.uclBuffer_G01_2_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_2_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_2_L.BufferName = "G01-2-L";
            this.uclBuffer_G01_2_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_2_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_2_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_L.Error = "";
            this.uclBuffer_G01_2_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_2_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_L.LeftCmdSno = "";
            this.uclBuffer_G01_2_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_L.LeftLoad = false;
            this.uclBuffer_G01_2_L.Location = new System.Drawing.Point(263, 145);
            this.uclBuffer_G01_2_L.Manual = false;
            this.uclBuffer_G01_2_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_2_L.Name = "uclBuffer_G01_2_L";
            this.uclBuffer_G01_2_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_2_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_2_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_L.RightLoad = false;
            this.uclBuffer_G01_2_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_2_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_2_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_2_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_L.TabIndex = 9;
            // 
            // uclBuffer_G01_2_1
            // 
            this.uclBuffer_G01_2_1.Auto = false;
            this.uclBuffer_G01_2_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_2_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_2_1.BufferName = "G01-2-1";
            this.uclBuffer_G01_2_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_2_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_2_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_1.Error = "";
            this.uclBuffer_G01_2_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_2_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_1.LeftCmdSno = "";
            this.uclBuffer_G01_2_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_1.LeftLoad = false;
            this.uclBuffer_G01_2_1.Location = new System.Drawing.Point(263, 213);
            this.uclBuffer_G01_2_1.Manual = false;
            this.uclBuffer_G01_2_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_2_1.Name = "uclBuffer_G01_2_1";
            this.uclBuffer_G01_2_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_2_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_2_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_1.RightLoad = false;
            this.uclBuffer_G01_2_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_2_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_2_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_2_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_2_1.TabIndex = 10;
            // 
            // uclBuffer_G01_3_L
            // 
            this.uclBuffer_G01_3_L.Auto = false;
            this.uclBuffer_G01_3_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_3_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_3_L.BufferName = "G01-3-L";
            this.uclBuffer_G01_3_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_3_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_3_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_L.Error = "";
            this.uclBuffer_G01_3_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_3_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_L.LeftCmdSno = "";
            this.uclBuffer_G01_3_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_L.LeftLoad = false;
            this.uclBuffer_G01_3_L.Location = new System.Drawing.Point(380, 145);
            this.uclBuffer_G01_3_L.Manual = false;
            this.uclBuffer_G01_3_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_3_L.Name = "uclBuffer_G01_3_L";
            this.uclBuffer_G01_3_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_3_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_3_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_L.RightLoad = false;
            this.uclBuffer_G01_3_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_3_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_3_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_3_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_L.TabIndex = 12;
            // 
            // uclBuffer_G01_3_1
            // 
            this.uclBuffer_G01_3_1.Auto = false;
            this.uclBuffer_G01_3_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_3_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_3_1.BufferName = "G01-3-1";
            this.uclBuffer_G01_3_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_3_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_3_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_1.Error = "";
            this.uclBuffer_G01_3_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_3_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_1.LeftCmdSno = "";
            this.uclBuffer_G01_3_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_1.LeftLoad = false;
            this.uclBuffer_G01_3_1.Location = new System.Drawing.Point(380, 213);
            this.uclBuffer_G01_3_1.Manual = false;
            this.uclBuffer_G01_3_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_3_1.Name = "uclBuffer_G01_3_1";
            this.uclBuffer_G01_3_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_3_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_3_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_1.RightLoad = false;
            this.uclBuffer_G01_3_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_3_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_3_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_3_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_3_1.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Yellow;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Location = new System.Drawing.Point(466, 77);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.Name = "label22";
            this.tableLayoutPanel6.SetRowSpan(this.label22, 2);
            this.label22.Size = new System.Drawing.Size(45, 136);
            this.label22.TabIndex = 64;
            this.label22.Text = "Crane 2";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbG02
            // 
            this.ptbG02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbG02.Image = ((System.Drawing.Image)(resources.GetObject("ptbG02.Image")));
            this.ptbG02.Location = new System.Drawing.Point(263, 281);
            this.ptbG02.Margin = new System.Windows.Forms.Padding(0);
            this.ptbG02.Name = "ptbG02";
            this.ptbG02.Size = new System.Drawing.Size(86, 41);
            this.ptbG02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbG02.TabIndex = 60;
            this.ptbG02.TabStop = false;
            this.ptbG02.Tag = "IN";
            this.ptbG02.DoubleClick += new System.EventHandler(this.ptbG02_DoubleClick);
            // 
            // ptbG04
            // 
            this.ptbG04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbG04.Image = ((System.Drawing.Image)(resources.GetObject("ptbG04.Image")));
            this.ptbG04.Location = new System.Drawing.Point(511, 281);
            this.ptbG04.Margin = new System.Windows.Forms.Padding(0);
            this.ptbG04.Name = "ptbG04";
            this.ptbG04.Size = new System.Drawing.Size(86, 41);
            this.ptbG04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbG04.TabIndex = 61;
            this.ptbG04.TabStop = false;
            this.ptbG04.Tag = "IN";
            this.ptbG04.DoubleClick += new System.EventHandler(this.ptbG04_DoubleClick);
            // 
            // uclBuffer_G01_4_L
            // 
            this.uclBuffer_G01_4_L.Auto = false;
            this.uclBuffer_G01_4_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_4_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_4_L.BufferName = "G01-4-L";
            this.uclBuffer_G01_4_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_4_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_4_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_L.Error = "";
            this.uclBuffer_G01_4_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_4_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_L.LeftCmdSno = "";
            this.uclBuffer_G01_4_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_L.LeftLoad = false;
            this.uclBuffer_G01_4_L.Location = new System.Drawing.Point(511, 145);
            this.uclBuffer_G01_4_L.Manual = false;
            this.uclBuffer_G01_4_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_4_L.Name = "uclBuffer_G01_4_L";
            this.uclBuffer_G01_4_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_4_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_4_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_L.RightLoad = false;
            this.uclBuffer_G01_4_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_4_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_4_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_4_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_L.TabIndex = 20;
            // 
            // uclBuffer_G01_4_1
            // 
            this.uclBuffer_G01_4_1.Auto = false;
            this.uclBuffer_G01_4_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_4_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_4_1.BufferName = "G01-4-1";
            this.uclBuffer_G01_4_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_4_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_4_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_1.Error = "";
            this.uclBuffer_G01_4_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_4_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_1.LeftCmdSno = "";
            this.uclBuffer_G01_4_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_1.LeftLoad = false;
            this.uclBuffer_G01_4_1.Location = new System.Drawing.Point(511, 213);
            this.uclBuffer_G01_4_1.Manual = false;
            this.uclBuffer_G01_4_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_4_1.Name = "uclBuffer_G01_4_1";
            this.uclBuffer_G01_4_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_4_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_4_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_1.RightLoad = false;
            this.uclBuffer_G01_4_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_4_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_4_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_4_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_4_1.TabIndex = 21;
            // 
            // uclBuffer_G01_5_1
            // 
            this.uclBuffer_G01_5_1.Auto = false;
            this.uclBuffer_G01_5_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_5_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_5_1.BufferName = "G01-5-1";
            this.uclBuffer_G01_5_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_5_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_5_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_1.Error = "";
            this.uclBuffer_G01_5_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_5_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_1.LeftCmdSno = "";
            this.uclBuffer_G01_5_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_1.LeftLoad = false;
            this.uclBuffer_G01_5_1.Location = new System.Drawing.Point(628, 213);
            this.uclBuffer_G01_5_1.Manual = false;
            this.uclBuffer_G01_5_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_5_1.Name = "uclBuffer_G01_5_1";
            this.uclBuffer_G01_5_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_5_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_5_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_1.RightLoad = false;
            this.uclBuffer_G01_5_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_5_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_5_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_5_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_1.TabIndex = 26;
            // 
            // uclBuffer_G01_5_L
            // 
            this.uclBuffer_G01_5_L.Auto = false;
            this.uclBuffer_G01_5_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_5_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_5_L.BufferName = "G01-5-L";
            this.uclBuffer_G01_5_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_5_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_5_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_L.Error = "";
            this.uclBuffer_G01_5_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_5_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_L.LeftCmdSno = "";
            this.uclBuffer_G01_5_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_L.LeftLoad = false;
            this.uclBuffer_G01_5_L.Location = new System.Drawing.Point(628, 145);
            this.uclBuffer_G01_5_L.Manual = false;
            this.uclBuffer_G01_5_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_5_L.Name = "uclBuffer_G01_5_L";
            this.uclBuffer_G01_5_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_5_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_5_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_L.RightLoad = false;
            this.uclBuffer_G01_5_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_5_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_5_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_5_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_5_L.TabIndex = 25;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Yellow;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Location = new System.Drawing.Point(714, 77);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.tableLayoutPanel6.SetRowSpan(this.label21, 2);
            this.label21.Size = new System.Drawing.Size(45, 136);
            this.label21.TabIndex = 63;
            this.label21.Text = "Crane 3";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer_G01_6_1
            // 
            this.uclBuffer_G01_6_1.Auto = false;
            this.uclBuffer_G01_6_1.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_6_1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_6_1.BufferName = "G01-6-1";
            this.uclBuffer_G01_6_1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_6_1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_6_1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_1.Error = "";
            this.uclBuffer_G01_6_1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_6_1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_1.LeftCmdSno = "";
            this.uclBuffer_G01_6_1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_1.LeftLoad = false;
            this.uclBuffer_G01_6_1.Location = new System.Drawing.Point(759, 213);
            this.uclBuffer_G01_6_1.Manual = false;
            this.uclBuffer_G01_6_1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_6_1.Name = "uclBuffer_G01_6_1";
            this.uclBuffer_G01_6_1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_6_1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_6_1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_1.RightLoad = false;
            this.uclBuffer_G01_6_1.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_6_1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_6_1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_6_1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_1.TabIndex = 27;
            // 
            // uclBuffer_G01_6_L
            // 
            this.uclBuffer_G01_6_L.Auto = false;
            this.uclBuffer_G01_6_L.Avail = Mirle.WinPLCCommu.uclBuffer.enuAvail.None;
            this.uclBuffer_G01_6_L.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer_G01_6_L.BufferName = "G01-6-L";
            this.uclBuffer_G01_6_L.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer_G01_6_L.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer_G01_6_L.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_L.Error = "";
            this.uclBuffer_G01_6_L.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer_G01_6_L.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_L.LeftCmdSno = "";
            this.uclBuffer_G01_6_L.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_L.LeftLoad = false;
            this.uclBuffer_G01_6_L.Location = new System.Drawing.Point(759, 145);
            this.uclBuffer_G01_6_L.Manual = false;
            this.uclBuffer_G01_6_L.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer_G01_6_L.Name = "uclBuffer_G01_6_L";
            this.uclBuffer_G01_6_L.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer_G01_6_L.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_L.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer_G01_6_L.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_L.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_L.RightLoad = false;
            this.uclBuffer_G01_6_L.Size = new System.Drawing.Size(86, 68);
            this.uclBuffer_G01_6_L.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer_G01_6_L.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer_G01_6_L.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer_G01_6_L.TabIndex = 28;
            // 
            // ptbG06
            // 
            this.ptbG06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbG06.Image = ((System.Drawing.Image)(resources.GetObject("ptbG06.Image")));
            this.ptbG06.Location = new System.Drawing.Point(759, 281);
            this.ptbG06.Margin = new System.Windows.Forms.Padding(0);
            this.ptbG06.Name = "ptbG06";
            this.ptbG06.Size = new System.Drawing.Size(86, 41);
            this.ptbG06.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbG06.TabIndex = 62;
            this.ptbG06.TabStop = false;
            this.ptbG06.Tag = "IN";
            this.ptbG06.DoubleClick += new System.EventHandler(this.ptbG06_DoubleClick);
            // 
            // ptbG01
            // 
            this.ptbG01.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbG01.Location = new System.Drawing.Point(132, 281);
            this.ptbG01.Margin = new System.Windows.Forms.Padding(0);
            this.ptbG01.Name = "ptbG01";
            this.ptbG01.Size = new System.Drawing.Size(86, 41);
            this.ptbG01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbG01.TabIndex = 73;
            this.ptbG01.TabStop = false;
            this.ptbG01.Tag = "OUT";
            this.ptbG01.DoubleClick += new System.EventHandler(this.ptbG01_DoubleClick);
            // 
            // ptbG03
            // 
            this.ptbG03.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbG03.Location = new System.Drawing.Point(380, 281);
            this.ptbG03.Margin = new System.Windows.Forms.Padding(0);
            this.ptbG03.Name = "ptbG03";
            this.ptbG03.Size = new System.Drawing.Size(86, 41);
            this.ptbG03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbG03.TabIndex = 74;
            this.ptbG03.TabStop = false;
            this.ptbG03.Tag = "OUT";
            this.ptbG03.DoubleClick += new System.EventHandler(this.ptbG03_DoubleClick);
            // 
            // ptbG05
            // 
            this.ptbG05.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
            this.ptbG05.Location = new System.Drawing.Point(628, 281);
            this.ptbG05.Margin = new System.Windows.Forms.Padding(0);
            this.ptbG05.Name = "ptbG05";
            this.ptbG05.Size = new System.Drawing.Size(86, 41);
            this.ptbG05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbG05.TabIndex = 75;
            this.ptbG05.TabStop = false;
            this.ptbG05.Tag = "OUT";
            this.ptbG05.DoubleClick += new System.EventHandler(this.ptbG05_DoubleClick);
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
            this.ClientSize = new System.Drawing.Size(1008, 590);
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
            this.tbpASRS_B.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbB05)).EndInit();
            this.tbpASRS_C.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbC05)).EndInit();
            this.tbpASRS_D.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbD05)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbE05)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbF05)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbG05)).EndInit();
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
        private System.Windows.Forms.TabPage tbpASRS_B;
        private System.Windows.Forms.TabPage tbpASRS_C;
        private System.Windows.Forms.TabPage tbpASRS_D;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private uclBuffer uclBuffer_B01_1_1;
        private uclBuffer uclBuffer_B01_1_L;
        private uclBuffer uclBuffer_B01_2_L;
        private uclBuffer uclBuffer_B01_2_1;
        private uclBuffer uclBuffer_B01_3_1;
        private uclBuffer uclBuffer_B01_3_L;
        private uclBuffer uclBuffer_B01_4_L;
        private uclBuffer uclBuffer_B01_4_1;
        private uclBuffer uclBuffer_B01_5_L;
        private uclBuffer uclBuffer_B01_5_1;
        private uclBuffer uclBuffer_B01_6_1;
        private uclBuffer uclBuffer_B01_6_L;
        private System.Windows.Forms.PictureBox ptbB02;
        private System.Windows.Forms.PictureBox ptbB04;
        private System.Windows.Forms.PictureBox ptbB06;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private uclBuffer uclBuffer_C01_1_1;
        private uclBuffer uclBuffer_C01_1_L;
        private uclBuffer uclBuffer_C01_2_L;
        private uclBuffer uclBuffer_C01_2_1;
        private uclBuffer uclBuffer_C01_3_1;
        private uclBuffer uclBuffer_C01_3_L;
        private uclBuffer uclBuffer_C01_4_L;
        private uclBuffer uclBuffer_C01_4_1;
        private System.Windows.Forms.PictureBox ptbC02;
        private System.Windows.Forms.PictureBox ptbC04;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private uclBuffer uclBuffer_D01_1_1;
        private uclBuffer uclBuffer_D01_1_L;
        private uclBuffer uclBuffer_D01_2_L;
        private uclBuffer uclBuffer_D01_2_1;
        private uclBuffer uclBuffer_D01_3_1;
        private uclBuffer uclBuffer_D01_3_L;
        private uclBuffer uclBuffer_D01_4_L;
        private uclBuffer uclBuffer_D01_4_1;
        private uclBuffer uclBuffer_D01_5_L;
        private uclBuffer uclBuffer_D01_5_1;
        private uclBuffer uclBuffer_D01_6_1;
        private uclBuffer uclBuffer_D01_6_L;
        private System.Windows.Forms.PictureBox ptbD02;
        private System.Windows.Forms.PictureBox ptbD04;
        private System.Windows.Forms.PictureBox ptbD06;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private uclBuffer uclBuffer_E01_1_1;
        private uclBuffer uclBuffer_E01_1_L;
        private uclBuffer uclBuffer_E01_2_L;
        private uclBuffer uclBuffer_E01_2_1;
        private uclBuffer uclBuffer_E01_3_1;
        private uclBuffer uclBuffer_E01_3_L;
        private uclBuffer uclBuffer_E01_4_L;
        private uclBuffer uclBuffer_E01_4_1;
        private uclBuffer uclBuffer_E01_5_L;
        private uclBuffer uclBuffer_E01_5_1;
        private uclBuffer uclBuffer_E01_6_1;
        private uclBuffer uclBuffer_E01_6_L;
        private System.Windows.Forms.PictureBox ptbE02;
        private System.Windows.Forms.PictureBox ptbE04;
        private System.Windows.Forms.PictureBox ptbE06;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private uclBuffer uclBuffer_F01_1_1;
        private uclBuffer uclBuffer_F01_1_L;
        private uclBuffer uclBuffer_F01_2_L;
        private uclBuffer uclBuffer_F01_2_1;
        private uclBuffer uclBuffer_F01_3_1;
        private uclBuffer uclBuffer_F01_3_L;
        private uclBuffer uclBuffer_F01_4_L;
        private uclBuffer uclBuffer_F01_4_1;
        private uclBuffer uclBuffer_F01_5_L;
        private uclBuffer uclBuffer_F01_5_1;
        private uclBuffer uclBuffer_F01_6_1;
        private uclBuffer uclBuffer_F01_6_L;
        private System.Windows.Forms.PictureBox ptbF04;
        private System.Windows.Forms.PictureBox ptbF06;
        private System.Windows.Forms.PictureBox ptbF02;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private uclBuffer uclBuffer_G01_1_1;
        private uclBuffer uclBuffer_G01_1_L;
        private uclBuffer uclBuffer_G01_2_L;
        private uclBuffer uclBuffer_G01_2_1;
        private uclBuffer uclBuffer_G01_3_1;
        private uclBuffer uclBuffer_G01_3_L;
        private uclBuffer uclBuffer_G01_4_L;
        private uclBuffer uclBuffer_G01_4_1;
        private uclBuffer uclBuffer_G01_5_L;
        private uclBuffer uclBuffer_G01_5_1;
        private uclBuffer uclBuffer_G01_6_1;
        private uclBuffer uclBuffer_G01_6_L;
        private System.Windows.Forms.PictureBox ptbG02;
        private System.Windows.Forms.PictureBox ptbG04;
        private System.Windows.Forms.PictureBox ptbG06;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBCR;
        private System.Windows.Forms.CheckBox chkWeight;
        private System.Windows.Forms.CheckBox chkBCR;
        private uclBuffer uclBuffer_C01_5_1;
        private uclBuffer uclBuffer_C01_5_L;
        private System.Windows.Forms.Label label14;
        private uclBuffer uclBuffer_C01_6_1;
        private uclBuffer uclBuffer_C01_6_L;
        private System.Windows.Forms.PictureBox ptbC06;
        private System.Windows.Forms.Button btnReconnectWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox ptbA01;
        private System.Windows.Forms.PictureBox ptbA03;
        private System.Windows.Forms.PictureBox ptbA05;
        private System.Windows.Forms.PictureBox ptbB01;
        private System.Windows.Forms.PictureBox ptbB03;
        private System.Windows.Forms.PictureBox ptbB05;
        private System.Windows.Forms.PictureBox ptbC01;
        private System.Windows.Forms.PictureBox ptbC03;
        private System.Windows.Forms.PictureBox ptbC05;
        private System.Windows.Forms.PictureBox ptbD01;
        private System.Windows.Forms.PictureBox ptbD03;
        private System.Windows.Forms.PictureBox ptbD05;
        private System.Windows.Forms.PictureBox ptbE01;
        private System.Windows.Forms.PictureBox ptbE03;
        private System.Windows.Forms.PictureBox ptbE05;
        private System.Windows.Forms.PictureBox ptbF01;
        private System.Windows.Forms.PictureBox ptbF03;
        private System.Windows.Forms.PictureBox ptbF05;
        private System.Windows.Forms.PictureBox ptbG01;
        private System.Windows.Forms.PictureBox ptbG03;
        private System.Windows.Forms.PictureBox ptbG05;
    }
}

