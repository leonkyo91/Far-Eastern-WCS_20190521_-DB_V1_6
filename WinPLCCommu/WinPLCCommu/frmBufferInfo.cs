using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.WinPLCCommu
{
    public partial class frmBufferInfo : Form
    {
        public frmBufferInfo()
        {
            InitializeComponent();
        }

        private void frmBufferInfo_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
