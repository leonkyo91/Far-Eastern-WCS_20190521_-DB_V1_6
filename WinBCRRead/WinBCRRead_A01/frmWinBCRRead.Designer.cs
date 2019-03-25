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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblLastReadingTime = new System.Windows.Forms.Label();
            this.lblBCRReadID = new System.Windows.Forms.Label();
            this.lblBCRNo = new System.Windows.Forms.Label();
            this.lblBCRSts = new System.Windows.Forms.Label();
            this.lblBCRNo_L = new System.Windows.Forms.Label();
            this.lblBCRSts1_L = new System.Windows.Forms.Label();
            this.lblBCRSts2_L = new System.Windows.Forms.Label();
            this.lblBCRReadID_L = new System.Windows.Forms.Label();
            this.lblLastReadingTime_L = new System.Windows.Forms.Label();
            this.lblBCRNo_R = new System.Windows.Forms.Label();
            this.lblBCRSts1_R = new System.Windows.Forms.Label();
            this.lblBCRSts2_R = new System.Windows.Forms.Label();
            this.lblBCRReadID_R = new System.Windows.Forms.Label();
            this.lblLastReadingTime_R = new System.Windows.Forms.Label();
            this.lblDBStsLable = new System.Windows.Forms.Label();
            this.lblDBSts = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.nfiMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tslShowWinBCR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslCloseWinBCR = new System.Windows.Forms.ToolStripMenuItem();
            this.timUpdata = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.picLogo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLastReadingTime, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRReadID, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRSts, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRNo_L, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRSts1_L, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRSts2_L, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRReadID_L, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLastReadingTime_L, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRNo_R, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRSts1_R, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRSts2_R, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblBCRReadID_R, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLastReadingTime_R, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDBStsLable, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDBSts, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDateTime, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 81);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.DarkGray;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(1, 1);
            this.picLogo.Margin = new System.Windows.Forms.Padding(0);
            this.picLogo.Name = "picLogo";
            this.tableLayoutPanel1.SetRowSpan(this.picLogo, 2);
            this.picLogo.Size = new System.Drawing.Size(175, 51);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblLastReadingTime
            // 
            this.lblLastReadingTime.BackColor = System.Drawing.Color.Black;
            this.lblLastReadingTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastReadingTime.ForeColor = System.Drawing.Color.White;
            this.lblLastReadingTime.Location = new System.Drawing.Point(423, 1);
            this.lblLastReadingTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblLastReadingTime.Name = "lblLastReadingTime";
            this.lblLastReadingTime.Size = new System.Drawing.Size(132, 25);
            this.lblLastReadingTime.TabIndex = 3;
            this.lblLastReadingTime.Text = "Last Reading Time";
            this.lblLastReadingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRReadID
            // 
            this.lblBCRReadID.BackColor = System.Drawing.Color.Black;
            this.lblBCRReadID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRReadID.ForeColor = System.Drawing.Color.White;
            this.lblBCRReadID.Location = new System.Drawing.Point(334, 1);
            this.lblBCRReadID.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRReadID.Name = "lblBCRReadID";
            this.lblBCRReadID.Size = new System.Drawing.Size(88, 25);
            this.lblBCRReadID.TabIndex = 6;
            this.lblBCRReadID.Text = "BCR Read ID";
            this.lblBCRReadID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRNo
            // 
            this.lblBCRNo.BackColor = System.Drawing.Color.Black;
            this.lblBCRNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRNo.ForeColor = System.Drawing.Color.White;
            this.lblBCRNo.Location = new System.Drawing.Point(177, 1);
            this.lblBCRNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRNo.Name = "lblBCRNo";
            this.lblBCRNo.Size = new System.Drawing.Size(66, 25);
            this.lblBCRNo.TabIndex = 1;
            this.lblBCRNo.Text = "BCR No";
            this.lblBCRNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRSts
            // 
            this.lblBCRSts.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.lblBCRSts, 2);
            this.lblBCRSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRSts.ForeColor = System.Drawing.Color.White;
            this.lblBCRSts.Location = new System.Drawing.Point(244, 1);
            this.lblBCRSts.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRSts.Name = "lblBCRSts";
            this.lblBCRSts.Size = new System.Drawing.Size(89, 25);
            this.lblBCRSts.TabIndex = 2;
            this.lblBCRSts.Text = "BCR Sts";
            this.lblBCRSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRNo_L
            // 
            this.lblBCRNo_L.BackColor = System.Drawing.Color.White;
            this.lblBCRNo_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRNo_L.Location = new System.Drawing.Point(177, 27);
            this.lblBCRNo_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRNo_L.Name = "lblBCRNo_L";
            this.lblBCRNo_L.Size = new System.Drawing.Size(66, 25);
            this.lblBCRNo_L.TabIndex = 7;
            this.lblBCRNo_L.Text = "BCRNo_L";
            this.lblBCRNo_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRSts1_L
            // 
            this.lblBCRSts1_L.BackColor = System.Drawing.Color.Red;
            this.lblBCRSts1_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRSts1_L.Location = new System.Drawing.Point(244, 27);
            this.lblBCRSts1_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRSts1_L.Name = "lblBCRSts1_L";
            this.lblBCRSts1_L.Size = new System.Drawing.Size(44, 25);
            this.lblBCRSts1_L.TabIndex = 8;
            this.lblBCRSts1_L.Text = "未連線";
            this.lblBCRSts1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRSts2_L
            // 
            this.lblBCRSts2_L.BackColor = System.Drawing.Color.Lime;
            this.lblBCRSts2_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRSts2_L.Location = new System.Drawing.Point(289, 27);
            this.lblBCRSts2_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRSts2_L.Name = "lblBCRSts2_L";
            this.lblBCRSts2_L.Size = new System.Drawing.Size(44, 25);
            this.lblBCRSts2_L.TabIndex = 9;
            this.lblBCRSts2_L.Text = "未讀取";
            this.lblBCRSts2_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRReadID_L
            // 
            this.lblBCRReadID_L.BackColor = System.Drawing.Color.White;
            this.lblBCRReadID_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRReadID_L.Location = new System.Drawing.Point(334, 27);
            this.lblBCRReadID_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRReadID_L.Name = "lblBCRReadID_L";
            this.lblBCRReadID_L.Size = new System.Drawing.Size(88, 25);
            this.lblBCRReadID_L.TabIndex = 10;
            this.lblBCRReadID_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastReadingTime_L
            // 
            this.lblLastReadingTime_L.BackColor = System.Drawing.Color.White;
            this.lblLastReadingTime_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastReadingTime_L.Location = new System.Drawing.Point(423, 27);
            this.lblLastReadingTime_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblLastReadingTime_L.Name = "lblLastReadingTime_L";
            this.lblLastReadingTime_L.Size = new System.Drawing.Size(132, 25);
            this.lblLastReadingTime_L.TabIndex = 11;
            this.lblLastReadingTime_L.Text = "yyyy-MM-dd HH:mm:ss";
            this.lblLastReadingTime_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRNo_R
            // 
            this.lblBCRNo_R.BackColor = System.Drawing.Color.White;
            this.lblBCRNo_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRNo_R.Location = new System.Drawing.Point(177, 53);
            this.lblBCRNo_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRNo_R.Name = "lblBCRNo_R";
            this.lblBCRNo_R.Size = new System.Drawing.Size(66, 27);
            this.lblBCRNo_R.TabIndex = 12;
            this.lblBCRNo_R.Text = "BCRNo_R";
            this.lblBCRNo_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRSts1_R
            // 
            this.lblBCRSts1_R.BackColor = System.Drawing.Color.Red;
            this.lblBCRSts1_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRSts1_R.Location = new System.Drawing.Point(244, 53);
            this.lblBCRSts1_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRSts1_R.Name = "lblBCRSts1_R";
            this.lblBCRSts1_R.Size = new System.Drawing.Size(44, 27);
            this.lblBCRSts1_R.TabIndex = 13;
            this.lblBCRSts1_R.Text = "未連線";
            this.lblBCRSts1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRSts2_R
            // 
            this.lblBCRSts2_R.BackColor = System.Drawing.Color.Lime;
            this.lblBCRSts2_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRSts2_R.Location = new System.Drawing.Point(289, 53);
            this.lblBCRSts2_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRSts2_R.Name = "lblBCRSts2_R";
            this.lblBCRSts2_R.Size = new System.Drawing.Size(44, 27);
            this.lblBCRSts2_R.TabIndex = 14;
            this.lblBCRSts2_R.Text = "未讀取";
            this.lblBCRSts2_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBCRReadID_R
            // 
            this.lblBCRReadID_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBCRReadID_R.Location = new System.Drawing.Point(334, 53);
            this.lblBCRReadID_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblBCRReadID_R.Name = "lblBCRReadID_R";
            this.lblBCRReadID_R.Size = new System.Drawing.Size(88, 27);
            this.lblBCRReadID_R.TabIndex = 15;
            this.lblBCRReadID_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastReadingTime_R
            // 
            this.lblLastReadingTime_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastReadingTime_R.Location = new System.Drawing.Point(423, 53);
            this.lblLastReadingTime_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblLastReadingTime_R.Name = "lblLastReadingTime_R";
            this.lblLastReadingTime_R.Size = new System.Drawing.Size(132, 27);
            this.lblLastReadingTime_R.TabIndex = 16;
            this.lblLastReadingTime_R.Text = "yyyy-MM-dd HH:mm:ss";
            this.lblLastReadingTime_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDBStsLable
            // 
            this.lblDBStsLable.BackColor = System.Drawing.Color.Black;
            this.lblDBStsLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDBStsLable.ForeColor = System.Drawing.Color.White;
            this.lblDBStsLable.Location = new System.Drawing.Point(556, 1);
            this.lblDBStsLable.Margin = new System.Windows.Forms.Padding(0);
            this.lblDBStsLable.Name = "lblDBStsLable";
            this.lblDBStsLable.Size = new System.Drawing.Size(67, 25);
            this.lblDBStsLable.TabIndex = 5;
            this.lblDBStsLable.Text = "DB Sts";
            this.lblDBStsLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDBSts
            // 
            this.lblDBSts.BackColor = System.Drawing.Color.Red;
            this.lblDBSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDBSts.Location = new System.Drawing.Point(556, 27);
            this.lblDBSts.Margin = new System.Windows.Forms.Padding(0);
            this.lblDBSts.Name = "lblDBSts";
            this.lblDBSts.Size = new System.Drawing.Size(67, 25);
            this.lblDBSts.TabIndex = 17;
            this.lblDBSts.Text = "未連線";
            this.lblDBSts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(556, 53);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(67, 27);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.White;
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateTime.Location = new System.Drawing.Point(1, 53);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(175, 27);
            this.lblDateTime.TabIndex = 19;
            this.lblDateTime.Text = "yyyy-MM-dd HH:mm:ss";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // timUpdata
            // 
            this.timUpdata.Tick += new System.EventHandler(this.timUpdata_Tick);
            // 
            // frmWinBCRRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 81);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 120);
            this.Name = "frmWinBCRRead";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWinBCRRead_FormClosing);
            this.Load += new System.EventHandler(this.frmWinBCRRead_Load);
            this.Resize += new System.EventHandler(this.frmWinBCRRead_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblLastReadingTime;
        private System.Windows.Forms.Label lblBCRSts;
        private System.Windows.Forms.Label lblBCRNo;
        private System.Windows.Forms.Label lblDBStsLable;
        private System.Windows.Forms.Label lblBCRReadID;
        private System.Windows.Forms.Label lblBCRNo_L;
        private System.Windows.Forms.Label lblBCRSts1_L;
        private System.Windows.Forms.Label lblBCRSts2_L;
        private System.Windows.Forms.Label lblBCRReadID_L;
        private System.Windows.Forms.Label lblLastReadingTime_L;
        private System.Windows.Forms.Label lblBCRNo_R;
        private System.Windows.Forms.Label lblBCRSts1_R;
        private System.Windows.Forms.Label lblBCRSts2_R;
        private System.Windows.Forms.Label lblBCRReadID_R;
        private System.Windows.Forms.Label lblLastReadingTime_R;
        private System.Windows.Forms.Label lblDBSts;
        private System.Windows.Forms.NotifyIcon nfiMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tslShowWinBCR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tslCloseWinBCR;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timUpdata;
    }
}

