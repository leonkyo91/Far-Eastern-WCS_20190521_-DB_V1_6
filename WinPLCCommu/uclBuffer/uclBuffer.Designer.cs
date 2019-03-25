namespace Mirle.WinPLCCommu
{
    partial class uclBuffer
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBufferName = new System.Windows.Forms.Label();
            this.lblCmdSno = new System.Windows.Forms.Label();
            this.lblStnMode = new System.Windows.Forms.Label();
            this.lblReady = new System.Windows.Forms.Label();
            this.lblReadNotice = new System.Windows.Forms.Label();
            this.lblFunNotice = new System.Windows.Forms.Label();
            this.lblManual = new System.Windows.Forms.Label();
            this.lblAuto = new System.Windows.Forms.Label();
            this.lblLeftLoad = new System.Windows.Forms.Label();
            this.lblStnChanges = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnBuffer = new System.Windows.Forms.Button();
            this.tlpBuffer = new System.Windows.Forms.TableLayoutPanel();
            this.lblPalletNo = new System.Windows.Forms.Label();
            this.tlpBuffer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBufferName
            // 
            this.lblBufferName.BackColor = System.Drawing.Color.DimGray;
            this.lblBufferName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpBuffer.SetColumnSpan(this.lblBufferName, 4);
            this.lblBufferName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBufferName.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBufferName.ForeColor = System.Drawing.Color.White;
            this.lblBufferName.Location = new System.Drawing.Point(0, 0);
            this.lblBufferName.Margin = new System.Windows.Forms.Padding(0);
            this.lblBufferName.Name = "lblBufferName";
            this.lblBufferName.Size = new System.Drawing.Size(86, 14);
            this.lblBufferName.TabIndex = 480;
            this.lblBufferName.Text = "BufName";
            this.lblBufferName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBufferName.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // lblCmdSno
            // 
            this.lblCmdSno.BackColor = System.Drawing.Color.White;
            this.lblCmdSno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpBuffer.SetColumnSpan(this.lblCmdSno, 2);
            this.lblCmdSno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCmdSno.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCmdSno.Location = new System.Drawing.Point(0, 14);
            this.lblCmdSno.Margin = new System.Windows.Forms.Padding(0);
            this.lblCmdSno.Name = "lblCmdSno";
            this.lblCmdSno.Size = new System.Drawing.Size(40, 14);
            this.lblCmdSno.TabIndex = 473;
            this.lblCmdSno.Text = "99999";
            this.lblCmdSno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCmdSno.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // lblStnMode
            // 
            this.lblStnMode.BackColor = System.Drawing.Color.White;
            this.lblStnMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStnMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStnMode.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStnMode.Location = new System.Drawing.Point(0, 28);
            this.lblStnMode.Margin = new System.Windows.Forms.Padding(0);
            this.lblStnMode.Name = "lblStnMode";
            this.lblStnMode.Size = new System.Drawing.Size(20, 14);
            this.lblStnMode.TabIndex = 474;
            this.lblStnMode.Text = "0";
            this.lblStnMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStnMode.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // lblReady
            // 
            this.lblReady.BackColor = System.Drawing.Color.White;
            this.lblReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReady.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReady.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblReady.Location = new System.Drawing.Point(0, 42);
            this.lblReady.Margin = new System.Windows.Forms.Padding(0);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(20, 16);
            this.lblReady.TabIndex = 476;
            this.lblReady.Text = "0";
            this.lblReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReady.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // lblReadNotice
            // 
            this.lblReadNotice.BackColor = System.Drawing.Color.White;
            this.lblReadNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReadNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReadNotice.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblReadNotice.Location = new System.Drawing.Point(20, 42);
            this.lblReadNotice.Margin = new System.Windows.Forms.Padding(0);
            this.lblReadNotice.Name = "lblReadNotice";
            this.lblReadNotice.Size = new System.Drawing.Size(20, 16);
            this.lblReadNotice.TabIndex = 477;
            this.lblReadNotice.Text = "0";
            this.lblReadNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReadNotice.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // lblFunNotice
            // 
            this.lblFunNotice.BackColor = System.Drawing.Color.White;
            this.lblFunNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFunNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFunNotice.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblFunNotice.Location = new System.Drawing.Point(40, 28);
            this.lblFunNotice.Margin = new System.Windows.Forms.Padding(0);
            this.lblFunNotice.Name = "lblFunNotice";
            this.lblFunNotice.Size = new System.Drawing.Size(20, 14);
            this.lblFunNotice.TabIndex = 478;
            this.lblFunNotice.Text = "0";
            this.lblFunNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFunNotice.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // lblManual
            // 
            this.lblManual.BackColor = System.Drawing.Color.White;
            this.lblManual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblManual.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblManual.Location = new System.Drawing.Point(60, 42);
            this.lblManual.Margin = new System.Windows.Forms.Padding(0);
            this.lblManual.Name = "lblManual";
            this.lblManual.Size = new System.Drawing.Size(26, 16);
            this.lblManual.TabIndex = 475;
            this.lblManual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblManual.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // lblAuto
            // 
            this.lblAuto.BackColor = System.Drawing.Color.White;
            this.lblAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuto.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAuto.Location = new System.Drawing.Point(40, 42);
            this.lblAuto.Margin = new System.Windows.Forms.Padding(0);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(20, 16);
            this.lblAuto.TabIndex = 482;
            this.lblAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeftLoad
            // 
            this.lblLeftLoad.BackColor = System.Drawing.Color.White;
            this.lblLeftLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeftLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeftLoad.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLeftLoad.Location = new System.Drawing.Point(20, 28);
            this.lblLeftLoad.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeftLoad.Name = "lblLeftLoad";
            this.lblLeftLoad.Size = new System.Drawing.Size(20, 14);
            this.lblLeftLoad.TabIndex = 481;
            this.lblLeftLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStnChanges
            // 
            this.lblStnChanges.BackColor = System.Drawing.Color.White;
            this.lblStnChanges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStnChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStnChanges.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStnChanges.Location = new System.Drawing.Point(40, 14);
            this.lblStnChanges.Margin = new System.Windows.Forms.Padding(0);
            this.lblStnChanges.Name = "lblStnChanges";
            this.lblStnChanges.Size = new System.Drawing.Size(20, 14);
            this.lblStnChanges.TabIndex = 474;
            this.lblStnChanges.Text = "99999";
            this.lblStnChanges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStnChanges.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.White;
            this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblError.Location = new System.Drawing.Point(60, 28);
            this.lblError.Margin = new System.Windows.Forms.Padding(0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(26, 14);
            this.lblError.TabIndex = 479;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // btnBuffer
            // 
            this.btnBuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuffer.Location = new System.Drawing.Point(0, 0);
            this.btnBuffer.Name = "btnBuffer";
            this.btnBuffer.Padding = new System.Windows.Forms.Padding(3);
            this.btnBuffer.Size = new System.Drawing.Size(86, 58);
            this.btnBuffer.TabIndex = 483;
            this.btnBuffer.UseVisualStyleBackColor = true;
            // 
            // tlpBuffer
            // 
            this.tlpBuffer.BackColor = System.Drawing.Color.White;
            this.tlpBuffer.ColumnCount = 4;
            this.tlpBuffer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBuffer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBuffer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBuffer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBuffer.Controls.Add(this.lblPalletNo, 3, 1);
            this.tlpBuffer.Controls.Add(this.lblReady, 0, 3);
            this.tlpBuffer.Controls.Add(this.lblError, 3, 2);
            this.tlpBuffer.Controls.Add(this.lblReadNotice, 1, 3);
            this.tlpBuffer.Controls.Add(this.lblFunNotice, 2, 2);
            this.tlpBuffer.Controls.Add(this.lblStnMode, 0, 2);
            this.tlpBuffer.Controls.Add(this.lblLeftLoad, 1, 2);
            this.tlpBuffer.Controls.Add(this.lblAuto, 2, 3);
            this.tlpBuffer.Controls.Add(this.lblManual, 3, 3);
            this.tlpBuffer.Controls.Add(this.lblStnChanges, 2, 1);
            this.tlpBuffer.Controls.Add(this.lblBufferName, 0, 0);
            this.tlpBuffer.Controls.Add(this.lblCmdSno, 0, 1);
            this.tlpBuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBuffer.Location = new System.Drawing.Point(0, 0);
            this.tlpBuffer.Name = "tlpBuffer";
            this.tlpBuffer.RowCount = 4;
            this.tlpBuffer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBuffer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBuffer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBuffer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBuffer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBuffer.Size = new System.Drawing.Size(86, 58);
            this.tlpBuffer.TabIndex = 2;
            this.tlpBuffer.Click += new System.EventHandler(this.uclBuffer_Click);
            // 
            // lblPalletNo
            // 
            this.lblPalletNo.BackColor = System.Drawing.Color.White;
            this.lblPalletNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPalletNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPalletNo.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPalletNo.Location = new System.Drawing.Point(60, 14);
            this.lblPalletNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblPalletNo.Name = "lblPalletNo";
            this.lblPalletNo.Size = new System.Drawing.Size(26, 14);
            this.lblPalletNo.TabIndex = 483;
            this.lblPalletNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uclBuffer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tlpBuffer);
            this.Controls.Add(this.btnBuffer);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uclBuffer";
            this.Size = new System.Drawing.Size(86, 58);
            this.Click += new System.EventHandler(this.uclBuffer_Click);
            this.tlpBuffer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBufferName;
        private System.Windows.Forms.Label lblCmdSno;
        private System.Windows.Forms.Label lblStnMode;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Label lblReadNotice;
        private System.Windows.Forms.Label lblFunNotice;
        private System.Windows.Forms.Label lblManual;
        private System.Windows.Forms.Label lblStnChanges;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.Label lblLeftLoad;
        private System.Windows.Forms.Button btnBuffer;
        private System.Windows.Forms.TableLayoutPanel tlpBuffer;
        private System.Windows.Forms.Label lblPalletNo;
    }
}
