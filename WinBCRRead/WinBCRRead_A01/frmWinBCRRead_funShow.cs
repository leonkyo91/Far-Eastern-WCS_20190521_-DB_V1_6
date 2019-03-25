using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.WinBCRRead
{
    public partial class frmWinBCRRead
    {
        /// <summary>
        /// 更新 DB 連線狀態
        /// </summary>
        /// <param name="Connect"></param>
        /// <param name="lblConnect"></param>
        private void funShowConnect(bool Connect, ref Label lblConnect)
        {
            switch(Connect)
            {
                case true:
                    lblConnect.Text = "已連線";
                    lblConnect.BackColor = Color.Lime;
                    break;
                case false:
                default:
                    lblConnect.Text = "未連線";
                    lblConnect.BackColor = Color.Red;
                    break;
            }
        }

        /// <summary>
        /// 更新 BCR 讀取狀態
        /// </summary>
        /// <param name="BCRSts"></param>
        /// <param name="lblBCRSts2"></param>
        private void funShowBCRSts(string BCRSts, ref Label lblBCRSts2)
        {
            switch(BCRSts)
            {
                default:
                case cstrBCRNone:
                    lblBCRSts2.Text = "未讀取";
                    lblBCRSts2.BackColor = Color.Lime;
                    break;
                case cstrBCRReading:
                    lblBCRSts2.Text = "讀取中";
                    lblBCRSts2.BackColor = Color.Yellow;
                    break;
                case cstrBCRReadFinish:
                    lblBCRSts2.Text = "已讀取";
                    lblBCRSts2.BackColor = Color.Blue;
                    break;
            }
        }
    }
}
