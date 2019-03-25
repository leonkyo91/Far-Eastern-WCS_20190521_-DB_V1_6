using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mirle.WinPLCCommu
{
    public partial class frmCloseProgram : Form
    {
        private double dobStart = 0;

        /// <summary>
        /// 初始化 Mirle.WinPLCCommu.frmCloseProgram 類別的新執行個體
        /// </summary>
        public frmCloseProgram()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表示 timTime 觸發 Tick 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timTime_Tick(object sender, EventArgs e)
        {
            txtPassword.Focus();

            if(this.BackColor == Color.Red)
            {
                this.BackColor = Color.White;
                Label1.ForeColor = Color.Red;
                lblSec.ForeColor = Color.Red;
                lblSec.ForeColor = Color.Red;
                btnOK.ForeColor = Color.Red;
                btnCancel.ForeColor = Color.Red;
            }
            else
            {
                this.BackColor = Color.Red;
                Label1.ForeColor = Color.White;
                lblSec.ForeColor = Color.White;
                btnOK.ForeColor = Color.White;
                btnCancel.ForeColor = Color.White;
            }

            if((DateTime.Now.TimeOfDay.TotalSeconds - dobStart) >= 30)
                this.DialogResult = DialogResult.Abort;
            else
                lblSec.Text = Convert.ToInt32((30 - (DateTime.Now.TimeOfDay.TotalSeconds - dobStart))).ToString();
        }

        /// <summary>
        /// 表示 frmCloseProgram 觸發 Load 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCloseProgram_Load(object sender, EventArgs e)
        {
            txtPassword.Text = string.Empty;
            dobStart = DateTime.Now.TimeOfDay.TotalSeconds;
            this.Text = "AS/RS System Communication";
            timTime.Interval = 1000;
            timTime.Enabled = true;
            txtPassword.Focus();
        }

        /// <summary>
        /// 表示 btnOK 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text.Trim() == DateTime.Now.ToString("MMddHHmm")||txtPassword.Text.Trim() == "5992")
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.No;
        }

        /// <summary>
        /// 表示 btnCancel 觸發 Click 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 表示 txtPassword 觸發 KeyDown 事件處理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnOK_Click(sender, e);
        }
    }
}
