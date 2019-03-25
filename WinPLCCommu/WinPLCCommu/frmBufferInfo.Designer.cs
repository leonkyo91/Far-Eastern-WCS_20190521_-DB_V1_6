namespace Mirle.WinPLCCommu
{
    partial class frmBufferInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uclBuffer1 = new Mirle.WinPLCCommu.uclBuffer();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.uclBuffer1);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 168);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(123, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 48);
            this.label2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "手動";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(127, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 60);
            this.label1.TabIndex = 3;
            // 
            // uclBuffer1
            // 
            this.uclBuffer1.Auto = false;
            this.uclBuffer1.PalletNo = Mirle.WinPLCCommu.uclBuffer.enuPalletNo.None;
            this.uclBuffer1.BackColor = System.Drawing.Color.Transparent;
            this.uclBuffer1.BufferName = "BufName";
            this.uclBuffer1.BufferNameColor = System.Drawing.Color.Green;
            this.uclBuffer1.CmdMode = Mirle.WinPLCCommu.uclBuffer.enuCmdMode.None;
            this.uclBuffer1.CmdModeColor = System.Drawing.Color.White;
            this.uclBuffer1.Error = "";
            this.uclBuffer1.FunNotice = Mirle.WinPLCCommu.uclBuffer.enuFunNotice.None;
            this.uclBuffer1.FunNoticeColor = System.Drawing.Color.White;
            this.uclBuffer1.LeftCmdSno = "";
            this.uclBuffer1.LeftCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer1.LeftLoad = false;
            this.uclBuffer1.Location = new System.Drawing.Point(80, 43);
            this.uclBuffer1.Manual = false;
            this.uclBuffer1.Margin = new System.Windows.Forms.Padding(0);
            this.uclBuffer1.Name = "uclBuffer1";
            this.uclBuffer1.ReadNotice = Mirle.WinPLCCommu.uclBuffer.enuReadNotice.None;
            this.uclBuffer1.ReadNoticeColor = System.Drawing.Color.White;
            this.uclBuffer1.Ready = Mirle.WinPLCCommu.uclBuffer.enuReady.NoReady;
            this.uclBuffer1.ReadyColor = System.Drawing.Color.White;
            this.uclBuffer1.RightCmdSnoColor = System.Drawing.Color.White;
            this.uclBuffer1.RightLoad = false;
            this.uclBuffer1.Size = new System.Drawing.Size(80, 56);
            this.uclBuffer1.StnChange = Mirle.WinPLCCommu.uclBuffer.enuStnChange.None;
            this.uclBuffer1.StnMode = Mirle.WinPLCCommu.uclBuffer.enuStnMode.None;
            this.uclBuffer1.StnModeColor = System.Drawing.Color.White;
            this.uclBuffer1.TabIndex = 25;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(57, 123);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 24;
            this.label22.Text = "讀取通知";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(77, 5);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 23;
            this.label21.Text = "站口切換";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(101, 138);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 22;
            this.label20.Text = "功能通知";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 87);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 12);
            this.label18.TabIndex = 20;
            this.label18.Text = "Ready";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 19;
            this.label17.Text = "模式";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(193, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 12);
            this.label15.TabIndex = 17;
            this.label15.Text = "Error";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "序號";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(193, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "使用率";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(135, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "Buffer Name";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(145, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(2, 30);
            this.label11.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(153, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 2);
            this.label10.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(42, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 2);
            this.label9.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(153, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 2);
            this.label8.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(40, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 2);
            this.label7.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(52, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 2);
            this.label6.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(102, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 30);
            this.label4.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(156, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 2);
            this.label3.TabIndex = 26;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(8, 181);
            this.label23.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(270, 84);
            this.label23.TabIndex = 2;
            this.label23.Text = "站口模式 => 1:入庫 2:出庫\r\n\r\n使用率=>1:25%  2:50%  3:75%  4:100%\r\n\r\n命令模式 => 1:入 2:出\r\n\r\nReady => 0:NO READY 1:入庫READY 2:出庫READY\r\n" +
    "\r\n讀取通知 => 1:可讀取\r\n";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(348, 270);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 29);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(135, 87);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(2, 30);
            this.label16.TabIndex = 28;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(131, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 29;
            this.label19.Text = "自動";
            // 
            // frmBufferInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(434, 310);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label23);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 349);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 349);
            this.Name = "frmBufferInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buffer Info";
            this.Load += new System.EventHandler(this.frmBufferInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnExit;
        private uclBuffer uclBuffer1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
    }
}