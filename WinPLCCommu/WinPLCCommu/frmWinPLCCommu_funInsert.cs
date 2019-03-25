using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mirle.Library;

namespace Mirle.WinPLCCommu
{
    public partial class frmWinPLCCommu
    {
        /// <summary>
        /// Insert BCR Log
        /// </summary>
        /// <param name="strBCRNo">條碼機編號</param>
        /// <param name="strBCRID">讀到的資料</param>
        /// <param name="strSts">狀態 0:初始狀態;1:PLC通知BCR讀取條碼;2:BCR己讀取條碼;E:Error</param>
        /// <param name="strBCRType">BCR類型 Fixed:固定式,PDA:PDA </param>
        /// <param name="?"></param>
        private void funInsetBCRLOG(string strBCRNo,string strBCRID,string strSts,string strBCRType)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            try
            {
                strSQL = "Insert Into Barcode_log(event_time,BCR_No,BCR_TYPE,BARCODE_NO,LABEL_TYPE,BCR_Sts)Values(";
                strSQL += "'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "',";
                strSQL += "'" + strBCRNo + "',";
                strSQL += "'Fixed',";//Fixed:固定式,PDA:PDA
                strSQL += "'" + strBCRID + "',";//讀到的資料
                strSQL += "'',";
                strSQL += "'" + strSts+"')";
                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                {
                    //寫入DBLOG
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void funInsertWeightLog(string strWTNo,string strWTData,string strWTSts)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            try
            {
                strSQL = "Insert Into Weight_log(event_time,Weight_No,Weight_Data,Weight_Sts)values(";
                strSQL += "'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "',";
                strSQL += "'" + strWTNo + "',";
                strSQL += "'" + strWTData + "',";
                strSQL += "'" + strWTSts+"')";
                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
        
        
    }
}
