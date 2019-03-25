namespace Mirle.WinBCRRead
{
    partial class frmWinBCRRead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWinBCRRead));
            this.lblLastReadingTime = new System.Windows.Forms.Label();
            this.lblBCRReadID = new System.Windows.Forms.Label();
            this.lblBCRNo = new System.Windows.Forms.Label();
            this.lblBCRSts = new System.Windows.Forms.Label();
            this.lblDBStsLable = new System.Windows.Forms.Label();
            this.lblDBSts = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.tlpBCR = new System.Windows.Forms.TableLayoutPanel();
            this.nfiMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tslShowWinBCR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslCloseWinBCR = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.timUpdata = new System.Windows.Forms.Timer(this.components);
            this.tlpWT = new System.Windows.Forms.TableLayoutPanel();
            this.lblWTLastReadingTime = new System.Windows.Forms.Label();
            this.lblWTReadData = new System.Windows.Forms.Label();
            this.lblWTSts = new System.Windows.Forms.Label();
            this.lblWTNo = new System.Windows.Forms.Label();
            this.timSerialPortReopen = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tlpBCR.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.tlpWT.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLastReadingTime
            // 
            this.lblLastReadingTime.BackColor = System.Drawing.Color.Black;
            this.lblLastReadingTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastReadingTime.ForeColor = System.Drawing.Color.White;
            this.lblLastReadingTime.Location = new System.Drawing.Point(213, 1);
            this.lblLastReadingTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblLastReadingTime.Name = "lblLastReadingTime";
            this.lblLastReadingTime.Size = new System.Drawing.Size(120, 35);
            this.lblLastReadingTime.TabIndex = 3;
            this.lblLastReadingTime.Text = "Last Reading Time";
            this.lblLastReadingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRReadID
            // 
            this.lblBCRReadID.BackColor = System.Drawing.Color.Black;
            this.lblBCRReadID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRReadID.ForeColor = System.Drawing.Color.White;
            this.lblBCRReadID.Location = new System.Drawing.Point(142, 1);
            this.lblBCRReadID.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRReadID.Name = "lblBCRReadID";
            this.lblBCRReadID.Size = new System.Drawing.Size(70, 35);
            this.lblBCRReadID.TabIndex = 6;
            this.lblBCRReadID.Text = "BCR Read ID";
            this.lblBCRReadID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRNo
            // 
            this.lblBCRNo.BackColor = System.Drawing.Color.Black;
            this.lblBCRNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRNo.ForeColor = System.Drawing.Color.White;
            this.lblBCRNo.Location = new System.Drawing.Point(1, 1);
            this.lblBCRNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRNo.Name = "lblBCRNo";
            this.lblBCRNo.Size = new System.Drawing.Size(46, 35);
            this.lblBCRNo.TabIndex = 1;
            this.lblBCRNo.Text = "BCR No";
            this.lblBCRNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRSts
            // 
            this.lblBCRSts.BackColor = System.Drawing.Color.Black;
            this.tlpBCR.SetColumnSpan(this.lblBCRSts, 2);
            this.lblBCRSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRSts.ForeColor = System.Drawing.Color.White;
            this.lblBCRSts.Location = new System.Drawing.Point(48, 1);
            this.lblBCRSts.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRSts.Name = "lblBCRSts";
            this.lblBCRSts.Size = new System.Drawing.Size(93, 35);
            this.lblBCRSts.TabIndex = 2;
            this.lblBCRSts.Text = "BCR Sts";
            this.lblBCRSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDBStsLable
            // 
            this.lblDBStsLable.BackColor = System.Drawing.Color.Black;
            this.lblDBStsLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDBStsLable.ForeColor = System.Drawing.Color.White;
            this.lblDBStsLable.Location = new System.Drawing.Point(353, 1);
            this.lblDBStsLable.Margin = new System.Windows.Forms.Padding(0);
            this.lblDBStsLable.Name = "lblDBStsLable";
            this.lblDBStsLable.Size = new System.Drawing.Size(105, 30);
            this.lblDBStsLable.TabIndex = 5;
            this.lblDBStsLable.Text = "DB Sts";
            this.lblDBStsLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDBSts
            // 
            this.lblDBSts.BackColor = System.Drawing.Color.Red;
            this.lblDBSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDBSts.Location = new System.Drawing.Point(459, 1);
            this.lblDBSts.Margin = new System.Windows.Forms.Padding(0);
            this.lblDBSts.Name = "lblDBSts";
            this.lblDBSts.Size = new System.Drawing.Size(105, 30);
            this.lblDBSts.TabIndex = 17;
            this.lblDBSts.Text = "未連線";
            this.lblDBSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(565, 1);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(142, 30);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.White;
            this.tlpTop.SetColumnSpan(this.lblDateTime, 3);
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateTime.Location = new System.Drawing.Point(353, 32);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(354, 30);
            this.lblDateTime.TabIndex = 19;
            this.lblDateTime.Text = "yyyy-MM-dd HH:mm:ss";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.DarkGray;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(1, 1);
            this.picLogo.Margin = new System.Windows.Forms.Padding(0);
            this.picLogo.Name = "picLogo";
            this.tlpTop.SetRowSpan(this.picLogo, 2);
            this.picLogo.Size = new System.Drawing.Size(351, 61);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // tlpBCR
            // 
            this.tlpBCR.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpBCR.ColumnCount = 5;
            this.tlpBCR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBCR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBCR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBCR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.42857F));
            this.tlpBCR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.tlpBCR.Controls.Add(this.lblLastReadingTime, 4, 0);
            this.tlpBCR.Controls.Add(this.lblBCRReadID, 3, 0);
            this.tlpBCR.Controls.Add(this.lblBCRSts, 1, 0);
            this.tlpBCR.Controls.Add(this.lblBCRNo, 0, 0);
            this.tlpBCR.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpBCR.Location = new System.Drawing.Point(0, 63);
            this.tlpBCR.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBCR.Name = "tlpBCR";
            this.tlpBCR.RowCount = 12;
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBCR.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBCR.Size = new System.Drawing.Size(334, 377);
            this.tlpBCR.TabIndex = 20;
            // 
            // nfiMain
            // 
            this.nfiMain.ContextMenuStrip = this.cmsMain;
            this.nfiMain.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiMain.Icon")));
            this.nfiMain.Text = "Mirle WinBCR(A01)";
            this.nfiMain.DoubleClick += new System.EventHandler(this.nfiMain_DoubleClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslShowWinBCR,
            this.toolStripSeparator1,
            this.tslCloseWinBCR});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(154, 54);
            // 
            // tslShowWinBCR
            // 
            this.tslShowWinBCR.Name = "tslShowWinBCR";
            this.tslShowWinBCR.Size = new System.Drawing.Size(153, 22);
            this.tslShowWinBCR.Text = "Show WinBCR";
            this.tslShowWinBCR.Click += new System.EventHandler(this.tslShowWinBCR_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // tslCloseWinBCR
            // 
            this.tslCloseWinBCR.Name = "tslCloseWinBCR";
            this.tslCloseWinBCR.Size = new System.Drawing.Size(153, 22);
            this.tslCloseWinBCR.Text = "Close WinBCR";
            this.tslCloseWinBCR.Click += new System.EventHandler(this.tslCloseWinBCR_Click);
            // 
            // tlpTop
            // 
            this.tlpTop.AutoSize = true;
            this.tlpTop.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpTop.ColumnCount = 4;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTop.Controls.Add(this.picLogo, 0, 0);
            this.tlpTop.Controls.Add(this.lblDBSts, 2, 0);
            this.tlpTop.Controls.Add(this.lblDBStsLable, 1, 0);
            this.tlpTop.Controls.Add(this.lblDateTime, 1, 1);
            this.tlpTop.Controls.Add(this.btnExit, 3, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTop.Location = new System.Drawing.Point(0, 0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 2;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTop.Size = new System.Drawing.Size(708, 63);
            this.tlpTop.TabIndex = 21;
            // 
            // timUpdata
            // 
            this.timUpdata.Tick += new System.EventHandler(this.timUpdata_Tick);
            // 
            // tlpWT
            // 
            this.tlpWT.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpWT.ColumnCount = 5;
            this.tlpWT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpWT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpWT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpWT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.42857F));
            this.tlpWT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.tlpWT.Controls.Add(this.lblWTLastReadingTime, 4, 0);
            this.tlpWT.Controls.Add(this.lblWTReadData, 3, 0);
            this.tlpWT.Controls.Add(this.lblWTSts, 1, 0);
            this.tlpWT.Controls.Add(this.lblWTNo, 0, 0);
            this.tlpWT.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlpWT.Location = new System.Drawing.Point(374, 63);
            this.tlpWT.Margin = new System.Windows.Forms.Padding(0);
            this.tlpWT.Name = "tlpWT";
            this.tlpWT.RowCount = 12;
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpWT.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpWT.Size = new System.Drawing.Size(334, 377);
            this.tlpWT.TabIndex = 22;
            // 
            // lblWTLastReadingTime
            // 
            this.lblWTLastReadingTime.BackColor = System.Drawing.Color.Black;
            this.lblWTLastReadingTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWTLastReadingTime.ForeColor = System.Drawing.Color.White;
            this.lblWTLastReadingTime.Location = new System.Drawing.Point(213, 1);
            this.lblWTLastReadingTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblWTLastReadingTime.Name = "lblWTLastReadingTime";
            this.lblWTLastReadingTime.Size = new System.Drawing.Size(120, 35);
            this.lblWTLastReadingTime.TabIndex = 3;
            this.lblWTLastReadingTime.Text = "Last Reading Time";
            this.lblWTLastReadingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWTReadData
            // 
            this.lblWTReadData.BackColor = System.Drawing.Color.Black;
            this.lblWTReadData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWTReadData.ForeColor = System.Drawing.Color.White;
            this.lblWTReadData.Location = new System.Drawing.Point(142, 1);
            this.lblWTReadData.Margin = new System.Windows.Forms.Padding(0);
            this.lblWTReadData.Name = "lblWTReadData";
            this.lblWTReadData.Size = new System.Drawing.Size(70, 35);
            this.lblWTReadData.TabIndex = 6;
            this.lblWTReadData.Text = "WT Read Data";
            this.lblWTReadData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWTSts
            // 
            this.lblWTSts.BackColor = System.Drawing.Color.Black;
            this.tlpWT.SetColumnSpan(this.lblWTSts, 2);
            this.lblWTSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWTSts.ForeColor = System.Drawing.Color.White;
            this.lblWTSts.Location = new System.Drawing.Point(48, 1);
            this.lblWTSts.Margin = new System.Windows.Forms.Padding(0);
            this.lblWTSts.Name = "lblWTSts";
            this.lblWTSts.Size = new System.Drawing.Size(93, 35);
            this.lblWTSts.TabIndex = 2;
            this.lblWTSts.Text = "WT Sts";
            this.lblWTSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWTNo
            // 
            this.lblWTNo.BackColor = System.Drawing.Color.Black;
            this.lblWTNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWTNo.ForeColor = System.Drawing.Color.White;
            this.lblWTNo.Location = new System.Drawing.Point(1, 1);
            this.lblWTNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblWTNo.Name = "lblWTNo";
            this.lblWTNo.Size = new System.Drawing.Size(46, 35);
            this.lblWTNo.TabIndex = 1;
            this.lblWTNo.Text = "WT No";
            this.lblWTNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timSerialPortReopen
            // 
            this.timSerialPortReopen.Interval = 10000;
            this.timSerialPortReopen.Tick += new System.EventHandler(this.timSerialPortReopen_Tick);
            // 
            // frmWinBCRRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 440);
            this.Controls.Add(this.tlpWT);
            this.Controls.Add(this.tlpBCR);
            this.Controls.Add(this.tlpTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 44);
            this.Name = "frmWinBCRRead";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWinBCRRead_FormClosing);
            this.Load += new System.EventHandler(this.frmWinBCRRead_Load);
            this.Resize += new System.EventHandler(this.frmWinBCRRead_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tlpBCR.ResumeLayout(false);
            this.cmsMain.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.tlpWT.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastReadingTime;
        private System.Windows.Forms.TableLayoutPanel tlpBCR;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblBCRReadID;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblBCRSts;
        private System.Windows.Forms.Label lblBCRNo;
        private System.Windows.Forms.Label lblDBStsLable;
        private System.Windows.Forms.Label lblDBSts;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NotifyIcon nfiMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tslShowWinBCR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tslCloseWinBCR;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.Timer timUpdata;
        private System.Windows.Forms.TableLayoutPanel tlpWT;
        private System.Windows.Forms.Label lblWTLastReadingTime;
        private System.Windows.Forms.Label lblWTReadData;
        private System.Windows.Forms.Label lblWTSts;
        private System.Windows.Forms.Label lblWTNo;
        private System.Windows.Forms.Timer timSerialPortReopen;
    }
}

