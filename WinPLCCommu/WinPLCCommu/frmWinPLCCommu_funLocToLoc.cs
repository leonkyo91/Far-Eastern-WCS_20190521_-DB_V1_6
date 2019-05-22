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
        /// 庫對庫流程
        /// </summary>
        private void funLocToLoc()
        {
            
            funLocToLoc_ReleaseCraneCmd();
            funLocToLoc_CraneCmdFinish();
        }

        /// <summary>
        /// 庫對庫-寫入Crane命令
        /// </summary>
        private void funLocToLoc_ReleaseCraneCmd()
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            DataTable objDataTable = new DataTable();
            Dictionary<string, clsCmdSno> dicCmdSno = new Dictionary<string, clsCmdSno>();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);

            try
            {
                //strSQL = "SELECT * FROM CMD_MST WHERE CMDMODE='5' AND CMDSTS='0' AND TRACE='0' ORDER BY CMDSNO, LOC, PRT, TRNDATE DESC";
                strSQL = "SELECT * FROM CMD_MST WHERE Cmd_Sno<>'' and CMD_MODE ='5' AND CMD_STS = '0' AND TRACE ='0' ORDER BY CMD_SNO ,LOC,PRTY,Crt_Date DESC";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    #region 取得命令
                    for(int intCount = 0; intCount < objDataTable.Rows.Count; intCount++)
                    {


                        if(dicCmdSno.ContainsKey(objDataTable.Rows[intCount]["CMD_SNO"].ToString()))
                        {
                            string strCmdSno = objDataTable.Rows[intCount]["CMD_SNO"].ToString();
                            dicCmdSno[strCmdSno].CmdSno = objDataTable.Rows[intCount]["CMD_SNO"].ToString();
                            dicCmdSno[strCmdSno].Loc = objDataTable.Rows[intCount]["LOC"].ToString();
                            dicCmdSno[strCmdSno].NewLoc = objDataTable.Rows[intCount]["NEW_LOC"].ToString();

                        }
                        else
                        {
                            clsCmdSno CmdSno = new clsCmdSno();
                            CmdSno.CmdSno = objDataTable.Rows[intCount]["CMD_SNO"].ToString();
                            CmdSno.Loc = objDataTable.Rows[intCount]["LOC"].ToString();
                            CmdSno.NewLoc = objDataTable.Rows[intCount]["NEW_LOC"].ToString();
                            CmdSno.Priority = int.Parse(objDataTable.Rows[intCount]["PRTY"].ToString());
                            dicCmdSno.Add(CmdSno.CmdSno, CmdSno);
                        }
                    }
                    #endregion 取得命令

                    foreach(clsCmdSno CmdSno in dicCmdSno.Values)
                    {
                        #region 判斷是否為同Crane庫對庫命令
                        string strLoc_Row = CmdSno.Loc.Substring(0, 2);
                        //Leon  int intCrane = ((int.Parse(strLoc_Row) + 3) / 2);

                        int intCrane = ((int.Parse(strLoc_Row) - 1) / 2 + 1);
                        strLoc_Row = CmdSno.NewLoc.Substring(0, 2);
                         
                        //Leon int intNewCrane = ((int.Parse(strLoc_Row) + 3) / 4);
                        int intNewCrane = ((int.Parse(strLoc_Row) -1) / 2 +1);
                        string Source = string.Empty;

                        string Destination = string.Empty;
                        Source = CmdSno.Loc;
                        Destination = CmdSno.NewLoc;

                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        SystemTraceLog.LogMessage = "Find Transfer Cmd Success!";
                        SystemTraceLog.LeftCmdSno = CmdSno.CmdSno_L;
                        SystemTraceLog.LocID = Source;
                        SystemTraceLog.NewLocID = Destination;
                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                        if (clsSystem.intBegin == 0)
                        {
                            clsSystem.intBegin = 1;
                            #region 更新Trace 和 EQUCMD
                            clsSystem.funWriteExceptionLog("[funLocToLoc_ReleaseCraneCmd]", "更新Trace 和 EQUCMD [Begin-Start]", " CmdSno=" + CmdSno.CmdSno);

                            if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin) == ErrDef.ProcSuccess)
                            {
                                if (funUpdateCmdTrace(CmdSno.CmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrLocToLocTrace_ReleaseCraneCmd))
                                {
                                    //將命令寫入EQUCMD
                                    if (funInsertLocToLocEquCmd(intCrane, CmdSno.CmdSno, Source, Destination, CmdSno.Priority.ToString()))
                                    {
                                        clsSystem.funWriteExceptionLog("[funLocToLoc_ReleaseCraneCmd]", "更新Trace 和 EQUCMD [Commit-Start]", " CmdSno=" + CmdSno.CmdSno);
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Transfer Cmd Initiated!";
                                        SystemTraceLog.CmdSno = CmdSno.CmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                        SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        clsSystem.funWriteExceptionLog("[funLocToLoc_ReleaseCraneCmd]", "更新Trace 和 EQUCMD [Rollback-Start] Release Equ Cmd Fail!", " CmdSno=" + CmdSno.CmdSno);
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Release Equ Cmd Fail!";
                                        SystemTraceLog.CmdSno = CmdSno.CmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                        SystemTraceLog.CmdMode = clsEquCmdMode.cstrInMode;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                }
                                else
                                {
                                    clsSystem.funWriteExceptionLog("[funLocToLoc_ReleaseCraneCmd]", "更新Trace 和 EQUCMD [Rollback-Start] Update Transfer Cmd Trace Fail!", " CmdSno=" + CmdSno.CmdSno);

                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    SystemTraceLog.LogMessage = "Update Transfer Cmd Trace Fail!";
                                    SystemTraceLog.CmdSno = CmdSno.CmdSno;
                                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                    SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_ReleaseCraneCmd;
                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                }
                            }

                            #endregion 更新Trace 和 EQUCMD
                            clsSystem.intBegin = 0;
                        }
                        #endregion 判斷是否為同Crane庫對庫命令
                    }
                }
            }
            catch(Exception ex)
            {
                clsSystem.funWriteExceptionLog("[funLocToLoc_ReleaseCraneCmd]", "更新 Trace 和 EQUCMD Exception [Rollback-Start]", "");

                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                if(objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
                if(dicCmdSno != null)
                {
                    dicCmdSno.Clear();
                    dicCmdSno = null;
                }
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }

        /// <summary>
        /// 庫對庫-判斷Crane命令是否完成，並更新Trace
        /// </summary>
        private void funLocToLoc_CraneCmdFinish()
        {
            DataTable objDataTable = new DataTable();
            DataTable objCmd = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                strSQL = "SELECT DISTINCT CMD_SNO, TRACE FROM CMD_MST WHERE Cmd_Sno<>'' and CMD_MODE='5' AND CMD_STS='1'";
                strSQL += " AND TRACE='" + clsTrace.cstrLocToLocTrace_ReleaseCraneCmd + "'";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    for(int intCount1 = 0; intCount1 < objDataTable.Rows.Count; intCount1++)
                    {
                        if (objCmd != null)
                        {
                            objCmd.Clear();
                            objCmd.Dispose();
                            objCmd = null;
                        }
                        string strCmdSno = objDataTable.Rows[intCount1]["CMD_SNO"].ToString();

                        strSQL = "SELECT * FROM EQUCMD WHERE CMDSNO='" + strCmdSno + "'";
                        strSQL += " AND RENEWFLAG <> 'F' AND CMDSTS='9'";
                        if(clsSystem.gobjDB.funGetDT(strSQL, ref objCmd, ref strEM) == ErrDef.ProcSuccess)
                        {
                            for(int intCount2 = 0; intCount2 < objCmd.Rows.Count; intCount2++)
                            {
                                string strCmdSts = objCmd.Rows[intCount2]["CmdSts"].ToString();
                                string strCompleteCode = objCmd.Rows[intCount2]["CompleteCode"].ToString();

                                if(strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode.Substring(0, 1) == "W")
                                {
                                    #region Update Equ Cmd CmdSts
                                    strSQL = "UPDATE EQUCMD SET CMDSTS='0' WHERE CMDSNO='" + strCmdSno + "'";
                                    if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Crane Transfer Cmd Retry Success!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Crane Transfer Cmd Retry Fail!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Equ Cmd CmdSts
                                }
                                else if(strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "E2")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    //v1.0.0.18 -2
                                    if (funUpdateCmdTrace_Abnormal(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrStoreOutTrace_ReleaseCraneCmd, clsCmdAbnormal.cstrEmptyOut))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Transfer Cmd Finish!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Transfer Cmd Trace Fail!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                                else if(strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "EF")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    if (funUpdateCmdTrace_Abnormal(strCmdSno, clsCmdSts.cstrCmdSts_CancelWaitPost, clsTrace.cstrLocToLocTrace_CraneCmdFinish,clsCmdAbnormal.cstrEF))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Transfer Cmd Finish![地上盤強制取消]";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CancelWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Transfer Cmd Trace Fail![地上盤強制取消]";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                                else if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "FF")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    if (funUpdateCmdTrace_Abnormal(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrLocToLocTrace_CraneCmdFinish, clsCmdAbnormal.cstrFF))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Transfer Cmd Finish![地上盤強制完成]";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Transfer Cmd Trace Fail![地上盤強制完成]";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                                else if(strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "92")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    if(funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrLocToLocTrace_CraneCmdFinish))
                                    {
                                        funDeleteEquCmd(strCmdSno);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Transfer Cmd Finish!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Transfer Cmd Trace Fail!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrLocToLocTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                clsSystem.funWriteExceptionLog("[funLocToLoc_ReleaseCraneCmd]", "更新Trace 和 EQUCMD [Rollback-Start] Exception ", "");

                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                if(objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
                if(objCmd != null)
                {
                    objCmd.Clear();
                    objCmd.Dispose();
                    objCmd = null;
                }
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }

        /// <summary>
        /// 庫對庫-Release暫存儲位
        /// </summary>
        private void funLocToLoc_Release_T_Loc()
        {
            string strSql = string.Empty;
            string strEm = string.Empty;
            DataTable dtTmp = new DataTable();
            try
            {
                //找尋暫存儲位有物的
                strSql = "SELECT * FROM LOC_MST WHERE LOC_STS ='S' AND Storage_Type ='T' ";
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (dtTmp != null)
                {
                    dtTmp.Clear();
                    dtTmp.Dispose();
                    dtTmp = null;

                }
            }
        }

    }
}
