namespace Mirle.WinPLCCommu
{
    partial class frmEquCmd
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
            this.tlpEquCmd = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.dgvCmdList = new System.Windows.Forms.DataGridView();
            this.tlpEquCmd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdList)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpEquCmd
            // 
            this.tlpEquCmd.AutoSize = true;
            this.tlpEquCmd.ColumnCount = 5;
            this.tlpEquCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpEquCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpEquCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpEquCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEquCmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpEquCmd.Controls.Add(this.btnRefresh, 0, 0);
            this.tlpEquCmd.Controls.Add(this.btnDelete, 1, 0);
            this.tlpEquCmd.Controls.Add(this.btnExit, 4, 0);
            this.tlpEquCmd.Controls.Add(this.btnRetry, 2, 0);
            this.tlpEquCmd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpEquCmd.Location = new System.Drawing.Point(0, 226);
            this.tlpEquCmd.Name = "tlpEquCmd";
            this.tlpEquCmd.RowCount = 1;
            this.tlpEquCmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpEquCmd.Size = new System.Drawing.Size(634, 35);
            this.tlpEquCmd.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 29);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Location = new System.Drawing.Point(83, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 29);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(557, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRetry.Location = new System.Drawing.Point(163, 3);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(74, 29);
            this.btnRetry.TabIndex = 3;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // dgvCmdList
            // 
            this.dgvCmdList.AllowUserToAddRows = false;
            this.dgvCmdList.AllowUserToDeleteRows = false;
            this.dgvCmdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCmdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCmdList.Location = new System.Drawing.Point(0, 0);
            this.dgvCmdList.MultiSelect = false;
            this.dgvCmdList.Name = "dgvCmdList";
            this.dgvCmdList.ReadOnly = true;
            this.dgvCmdList.RowTemplate.Height = 24;
            this.dgvCmdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCmdList.Size = new System.Drawing.Size(634, 226);
            this.dgvCmdList.TabIndex = 1;
            // 
            // frmEquCmd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(634, 261);
            this.Controls.Add(this.dgvCmdList);
            this.Controls.Add(this.tlpEquCmd);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 300);
            this.Name = "frmEquCmd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipment Command";
            this.Load += new System.EventHandler(this.frmEquCmd_Load);
            this.tlpEquCmd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmdList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpEquCmd;
        private System.Windows.Forms.DataGridView dgvCmdList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRetry;
    }
}