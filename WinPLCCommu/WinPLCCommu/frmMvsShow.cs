using Mirle.Library;
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
    public partial class frmWinPLCCommu
    {
        /// <summary>
        /// 更新Mvs_Mst Table(字幕機);站號,命令序號,DspFlag,ErrorFlag,異常訊息
        /// </summary>
        /// <param name="strBuffer">BufferName</param>
        /// <param name="strCmdSno">命令序號</param>
        /// <param name="strDsp_Falg">是否顯示</param>
        /// <param name="strErrorFlag">是否異常</param>
        /// <param name="strErrorMsg">異常訊息</param>
        private void funMvsData(string BufferName,string strCmdSno, string strDsp_Falg,string strErrorFlag,string strErrorMsg,bool bolBuffer)
        {
            string strSql = string.Empty;
            string strEM = string.Empty;
            string strStnNo = string.Empty;
            string strStnNoE = string.Empty;
            try
            {
                //v1.0.0.24
                switch (BufferName.Substring(0, 1))
                {
                    case"A":
                        strStnNoE = "1";
                        break;
                    case "B":
                        strStnNoE = "2";
                        break;
                    case "C":
                        strStnNoE = "3";
                        break;
                    case "D":
                        strStnNoE = "4";
                        break;
                    case "E":
                        strStnNoE = "5";
                        break;
                    case "F":
                        strStnNoE = "6";
                        break;
                    case "G":
                        strStnNoE = "7";
                        break;
                }
                strStnNo = BufferName.Substring(0, 1) + strStnNoE + "0" + BufferName.Substring(4, 1);

                strSql = "UPDATE Mvs_Mst Set ";
                strSql += "CMD_SNO ='" + strCmdSno + "' ,";
                strSql += "DSP_FLAG ='" + strDsp_Falg + "' ,";
                strSql += "Error_Flag ='" + strErrorFlag + "' ,";
                strSql += "Error_Msg ='" + strErrorMsg + "' ";
                strSql += "Where STN_NO ='" + strStnNo + "' ";
                if (clsSystem.gobjDB.funExecSql(strSql, ref strEM) == ErrDef.ProcSuccess)
                {
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 更新Mvs_Mst Table(字幕機);站號,命令序號,DspFlag,ErrorFlag,異常訊息
        /// </summary>
        /// <param name="strBuffer">BufferName</param>
        /// <param name="strCmdSno">命令序號</param>
        /// <param name="strDsp_Falg">是否顯示</param>
        /// <param name="strErrorFlag">是否異常</param>
        /// <param name="strErrorMsg">異常訊息</param>
        private void funMvsData(string strStnNo, string strCmdSno, string strDsp_Falg, string strErrorFlag, string strErrorMsg)
        {
            string strSql = string.Empty;
            string strEM = string.Empty;
            try
            {
                

                strSql = "UPDATE Mvs_Mst Set ";
                strSql += "CMD_SNO ='" + strCmdSno + "' ,";
                strSql += "DSP_FLAG ='" + strDsp_Falg + "' ,";
                strSql += "Error_Flag ='" + strErrorFlag + "' ,";
                strSql += "Error_Msg ='" + strErrorMsg + "' ";
                strSql += "Where STN_NO ='" + strStnNo + "' ";
                if (clsSystem.gobjDB.funExecSql(strSql, ref strEM) == ErrDef.ProcSuccess)
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
