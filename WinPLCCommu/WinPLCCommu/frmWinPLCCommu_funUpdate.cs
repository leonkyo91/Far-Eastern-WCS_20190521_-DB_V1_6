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
        /// 設定BCR Data
        /// </summary>
        /// <param name="BCRSts">BCR狀態</param>
        /// <param name="BCRNo">BCR編號</param>
        /// <param name="BCRData">BCR ID</param>
        /// <returns></returns>
        private bool funUpdateBCRSts(clsBCR.enuBCRSts BCRSts, string BCRNo, string BCRData)
        {
            string strEM = string.Empty;
            string strSQL = string.Empty;

            try
            {
                strSQL = "UPDATE IN_BUF SET BCR_STS='" + (int)BCRSts + "', BCR_DATA='" + BCRData + "' WHERE BCR_NO='" + BCRNo + "'";
                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
        }

        #region funUpdateCmdTrace
        /// <summary>
        /// 更新命令Trace
        /// </summary>
        /// <param name="CmdSno">命令序號</param>
        /// <param name="SetCmdSts">命令狀態</param>
        /// <param name="SetTrace">時序</param>
        /// <param name="SetStnNo">站口</param>
        /// <param name="Plt_Id">棧板ID</param>
        /// <returns></returns>
        private bool funUpdateCmdTrace(string CmdSno, string Plt_Id, string SetCmdSts, string SetTrace, string SetStnNo)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(CmdSno) ||
                    string.IsNullOrWhiteSpace(SetCmdSts) ||
                    string.IsNullOrWhiteSpace(SetTrace)
                    || string.IsNullOrWhiteSpace(SetStnNo)
                    )
                    return false;

                strSQL = "UPDATE CMD_MST SET CMDSTS='" + SetCmdSts + "', ";
                strSQL += " TRACE='" + SetTrace + "', ";
                strSQL += " STNNO='" + SetStnNo.Substring(0, 3) + "', ";
                strSQL += " SNO='" + (SetStnNo.Substring(SetStnNo.Length - 1) == "L" ? "1" : "2") + "' ,";
                strSQL += " EXPTIME='" + System.DateTime.Now.ToString("HH:mm:ss") + "' ";
                strSQL += " WHERE CMDSNO='" + CmdSno + "' AND CMDSTS <= '1' AND LOCID='" + Plt_Id + "'";

                //大立光
                strSQL = "UPDATE CMD_MST SET CMD_STS= '" + SetCmdSts + "', ";
                strSQL += " TRACE='" + SetTrace + "', ";
                strSQL += " STN_NO='" + SetStnNo.Substring(0, 3) + "', ";
                //strSQL += " SNO='" + (SetStnNo.Substring(SetStnNo.Length - 1) == "L" ? "1" : "2") + "' ,";
                strSQL += " EXP_DATE='" + System.DateTime.Now.ToString("HH:mm:ss") + "' ";
                strSQL += " WHERE CMD_SNO='" + CmdSno + "' AND CMD_STS <= '1' AND Plt_ID='" + Plt_Id + "'";
                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新命令Trace
        /// </summary>
        /// <param name="CmdSno"></param>
        /// <param name="SetCmdSts"></param>
        /// <param name="SetTrace"></param>
        /// <returns></returns>
        private bool funUpdateCmdTrace(string CmdSno, string SetCmdSts, string SetTrace)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(CmdSno) ||
                    string.IsNullOrWhiteSpace(SetCmdSts) ||
                    string.IsNullOrWhiteSpace(SetTrace))
                    return false;

                strSQL = "UPDATE CMD_MST SET CMD_STS= '" + SetCmdSts + "', TRACE='" + SetTrace + "', ";
                if (SetCmdSts == clsCmdSts.cstrCmdSts_CompletedWaitPost)
                    strSQL += "END_Date='" + System.DateTime.Now.ToString("HH:mm:ss") + "' ";
                else
                    strSQL += "EXP_Date='" + System.DateTime.Now.ToString("HH:mm:ss") + "' ";
                strSQL += "WHERE CMD_SNO='" + CmdSno + "' AND CMD_STS <= '1'";
                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
        }


        private bool funUpdateCmdTrace_Abnormal(string CmdSno, string SetCmdSts, string SetTrace, string Abnormal)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(CmdSno) ||
                    string.IsNullOrWhiteSpace(SetCmdSts) ||
                    string.IsNullOrWhiteSpace(SetTrace))
                    return false;

                strSQL = "UPDATE CMD_MST SET CMD_STS= '" + SetCmdSts + "', TRACE='" + SetTrace + "', ";
                strSQL += "Cmd_Abnormal='" + Abnormal + "',";
                if (SetCmdSts == clsCmdSts.cstrCmdSts_CompletedWaitPost)
                    strSQL += "END_Date='" + System.DateTime.Now.ToString("HH:mm:ss") + "' ";
                else
                    strSQL += "EXP_Date='" + System.DateTime.Now.ToString("HH:mm:ss") + "' ";
                strSQL += "WHERE CMD_SNO='" + CmdSno + "' AND CMD_STS <= '1'";
                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
        }
        #endregion funUpdateCmdTrace

        /// <summary>
        /// 移除已完成Equ Cmd
        /// </summary>
        /// <param name="strCmdSno"></param>
        private void funDeleteEquCmd(string strCmdSno)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);

            try
            {
                strSQL = "UPDATE EQUCMD SET RENEWFLAG='F' WHERE CMDSTS='9' AND RENEWFLAG='Y' AND CMDSNO='" + strCmdSno + "'";
                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                {
                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                    SystemTraceLog.LogMessage = "Delete Equ Cmd Success!";
                    SystemTraceLog.LeftCmdSno = strCmdSno;
                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                }
                else
                {
                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                    SystemTraceLog.LogMessage = "Delete Equ Cmd Fail!";
                    SystemTraceLog.LeftCmdSno = strCmdSno;
                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                }

                strSQL = "UPDATE EQUCMD SET RENEWFLAG='F' WHERE CMDSTS='9' AND RENEWFLAG='Y'";
                strSQL += " AND CMDSNO NOT IN (SELECT CMD_SNO FROM CMD_MST WHERE CMD_STS < '7')";
                clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }
        //private bool bolMVS_Update(string strDsp_Flag, string strCmdSno, string strStnNo, string strErrFlag, string strMsg)
        //{
        //    string strSql = string.Empty;
        //    string strEM = string.Empty;
        //    try
        //    {
        //        strSql = "UPDATE MVS_MST SET DSP_FLAG = '" + strDsp_Flag + "', ";
        //        strSql += "CMD_SNO ='" + strCmdSno + "' ";
        //        strSql += "WHERE STN_NO ='" + strStnNo + "' ";
        //        if (clsSystem.gobjDB.funExecSql(strSql, ref strEM) == ErrDef.ProcSuccess)
        //        {
        //            return true;
        //        }
        //        else
        //            return false;

        //    }
        //    catch (Exception ex)
        //    {
        //        var varObject = MethodBase.GetCurrentMethod();
        //        clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
        //        return false;
        //    }

        //}
        //private bool bolChkMVS_CMD()
        //{
        //    string strSQL = string.Empty;
        //    string strEM = string.Empty;
        //    DataTable dtTmp = new DataTable();
        //    DataTable dtTmp_Cmd = new DataTable();
        //    try
        //    {
        //        strSQL = "SELECT * FROM MVS_MST WHERE 1=1 ";
        //        strSQL += "AND Dsp_Flag ='2' ";
        //        if (clsSystem.gobjDB.funGetDT(strSQL, ref dtTmp, ref strEM) == ErrDef.ProcSuccess)
        //        {
        //            for (int i = 0; i < dtTmp.Rows.Count; i++)
        //            {
        //                strSQL = "SELECT * FROM CMD_MST WHERE CMD_SNO ='"+dtTmp.Rows[i]["CMD_SNO"].ToString();
        //                if (clsSystem.gobjDB.funGetDT(strSQL, ref dtTmp, ref strEM) == ErrDef.ProcSuccess)
        //                {

        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        var varObject = MethodBase.GetCurrentMethod();
        //        clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
        //        return false;
        //    }
        //}

        private bool funUpdateWTSts(clsWT.enuWTSts WTSts, string WTNo, string WTData)
        {
            string strSql = string.Empty;
            string strEM = string.Empty;
            try
            {
                strSql = "UPDATE IN_Weight SET Weight_STS='" + (int)WTSts + "', Weight_DATA='" + WTData + "' WHERE Weight_NO='" + WTNo + "'";
                if (clsSystem.gobjDB.funExecSql(strSql, ref strEM) == ErrDef.ProcSuccess)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
        }
        private void funNewCmdForPickup(string strCmdSno)
        {
            string strSql = string.Empty;
            string strEM = string.Empty;
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);
            try
            {
                //須確認Update CMd_MST 時不影響過帳
                strSql = "Update ";
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }
    }
}
