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
        /// 自動搬送測試 (撿料模式)
        /// </summary>
        /// <param name="StnIndex">站口編號</param>
        private void funAutoRunTest1(int StnIndex)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strCNTS = string.Empty;
            string strOutSideLoc = string.Empty;
            string strInSideLoc = string.Empty;
            string strSNO_I = string.Empty;
            string strSNO_O = string.Empty;
            string strOutSideLocID = string.Empty;
            string strInSideLocID = string.Empty;
            string strCmdSno = string.Empty;
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            clsStnDef StnDef = new clsStnDef();

            try
            {
                if(lstOutModeStnDef.Count <= StnIndex && StnIndex <= 0)
                    return;

                if(!lstOutModeStnDef.Exists(p => p.StnIndex == StnIndex))
                    return;
                else
                    StnDef = lstOutModeStnDef.Find(p => p.StnIndex == StnIndex);

                if(!objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_CargoLoad &&
                    //!objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_RightLoad &&
                    objBufferData.PLC2PCBuffer[StnDef.BufferIndex].Ready == (int)clsPLC2PCBuffer.enuReady.OutReady &&
                    string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno) &&
                    string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].RightCmdSno) &&
                    objBufferData.PLC2PCBuffer[StnDef.BufferIndex].CmdMode == (int)clsPLC2PCBuffer.enuCmdMode.None)
                {
                    strSQL = "SELECT TOP 1 LOC FROM LOC_MST WHERE LOCSTS='E'";
                    strSQL += " AND LOC IN (SELECT LOC1 FROM LOC_MST WHERE LOCSTS='E')";
                    strSQL += " AND CRANE_NO='" + StnDef.CraneNo + "' AND CRANE_ROW IN (3,4)";
                    strSQL += " ORDER BY TRNDATE";
                    if(clsSystem.gobjDB.funGetScalar(strSQL, ref strOutSideLoc, ref strEM) == ErrDef.ProcSuccess)
                    {
                        strSQL = "SELECT COUNT(*) AS CNTS FROM CMD_MST WHERE CMDSTS='0' AND STNNO='" + StnDef.StnNo + "'";
                        switch(StnDef.CraneNo)
                        {
                            case 1:
                                strSQL += " AND LOC <'050000'";
                                break;
                            case 2:
                                strSQL += " AND LOC >'050000' AND LOC < '090000'";
                                break;
                            case 3:
                                strSQL += " AND LOC >'090000'";
                                break;
                        }

                        if(clsSystem.gobjDB.funGetScalar(strSQL, ref strCNTS, ref strEM) == ErrDef.ProcSuccess)
                        {
                            if(int.Parse(strCNTS) == 0)
                            {
                                switch(StnIndex)
                                {
                                    case 1:
                                    case 4:
                                        strInSideLoc = (strOutSideLoc.Substring(0, 2) == "03" ? "01" : "02") + strOutSideLoc.Substring(2, 4);
                                        strSNO_I = strInSideLoc.Substring(0, 2) == "01" ? "2" : "1";
                                        strSNO_O = strInSideLoc.Substring(0, 2) == "01" ? "1" : "2";
                                        break;
                                    case 2:
                                    case 5:
                                        strInSideLoc = (strOutSideLoc.Substring(0, 2) == "07" ? "05" : "06") + strOutSideLoc.Substring(2, 4);
                                        strSNO_I = (strInSideLoc.Substring(0, 2) == "05" ? "2" : "1");
                                        strSNO_O = (strInSideLoc.Substring(0, 2) == "05" ? "1" : "2");
                                        break;
                                    case 3:
                                    case 6:
                                        strInSideLoc = (strOutSideLoc.Substring(0, 2) == "11" ? "09" : "10") + strOutSideLoc.Substring(2, 4);
                                        strSNO_I = (strInSideLoc.Substring(0, 2) == "09" ? "2" : "1");
                                        strSNO_O = (strInSideLoc.Substring(0, 2) == "09" ? "1" : "2");
                                        break;
                                }

                                strSQL = "SELECT LOCID FROM LOC_MST WHERE LOC='" + strOutSideLoc + "'";
                                if(clsSystem.gobjDB.funGetScalar(strSQL, ref strOutSideLocID, ref strEM) == ErrDef.ProcSuccess)
                                {
                                    strSQL = "SELECT LOCID FROM LOC_MST WHERE LOC='" + strInSideLoc + "'";
                                    if(clsSystem.gobjDB.funGetScalar(strSQL, ref strInSideLocID, ref strEM) == ErrDef.ProcSuccess)
                                    {
                                        strCmdSno = funGetCmdSno();
                                        if(!string.IsNullOrWhiteSpace(strCmdSno))
                                        {
                                            strSQL = "INSERT INTO CMD_MST (CMDSNO, SNO, CMDSTS, PRT, CMDMODE, IOTYP, LOC, TRNDATE,";
                                            strSQL += " ACTTIME, PROGID, LOCID, TRACE, STNNO,SCAN) VALUES (";
                                            strSQL += "'" + strCmdSno + "', '" + strSNO_I + "', '0', '5', '3', '33', '" + strInSideLoc + "', ";
                                            strSQL += "'" + DateTime.Now.ToString("yyyy/MM/dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "', ";
                                            strSQL += "'MainControl', '" + strInSideLocID + "', '0','" + StnDef.StnNo + "','Y')";
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
                                            if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                            {
                                                strSQL = "INSERT INTO CMD_MST (CMDSNO, SNO, CMDSTS, PRT, CMDMODE, IOTYP ,LOC, TRNDATE,";
                                                strSQL += " ACTTIME,PROGID,LOCID,TRACE,STNNO,SCAN) VALUES (";
                                                strSQL += "'" + strCmdSno + "', '" + strSNO_O + "', '0', '5', '3', '33', '" + strOutSideLoc + "', ";
                                                strSQL += "'" + DateTime.Now.ToString("yyyy/MM/dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "', ";
                                                strSQL += "'MainControl', '" + strOutSideLocID + "', '0','" + StnDef.StnNo + "','Y')";
                                                if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                                {
                                                    strSQL = "UPDATE LOC_MST SET LOCSTS='C', OLDSTS='E' WHERE LOCSTS='E' AND";
                                                    strSQL += " LOC IN ('" + strInSideLoc + "', '" + strOutSideLoc + "')";
                                                    if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                                    {
                                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                        SystemTraceLog.LogMessage = "Create Auto Run Command Success!";
                                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                                        SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                                        SystemTraceLog.LocID = strInSideLoc;
                                                        SystemTraceLog.LocID += ", " + strOutSideLoc;
                                                        SystemTraceLog.StnNo = StnDef.StnNo;
                                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                        SystemTraceLog.LogMessage = "Reserve Auto Run Loc Success!";
                                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                                        SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                                        SystemTraceLog.LocID = strInSideLoc;
                                                        SystemTraceLog.LocID += ", " + strOutSideLoc;
                                                        SystemTraceLog.StnNo = StnDef.StnNo;
                                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                    }
                                                    else
                                                    {
                                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                        SystemTraceLog.LogMessage = "Reserve Auto Run Loc Fail!";
                                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                                        SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                                        SystemTraceLog.LocID = strInSideLoc;
                                                        SystemTraceLog.LocID += ", " + strOutSideLoc;
                                                        SystemTraceLog.StnNo = StnDef.StnNo;
                                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                    }
                                                }
                                                else
                                                {
                                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                    SystemTraceLog.LogMessage = "Create Auto Run Command Fail!";
                                                    SystemTraceLog.LeftCmdSno = strCmdSno;
                                                    SystemTraceLog.SNO = strSNO_O;
                                                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                                    SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                                    SystemTraceLog.LocID = strInSideLoc;
                                                    SystemTraceLog.LocID += ", " + strOutSideLoc;
                                                    SystemTraceLog.StnNo = StnDef.StnNo;
                                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                }
                                            }
                                            else
                                            {
                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "Create Auto Run Command Fail!";
                                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                                SystemTraceLog.SNO = strSNO_I;
                                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                                SystemTraceLog.LocID = strInSideLoc;
                                                SystemTraceLog.LocID += ", " + strOutSideLoc;
                                                SystemTraceLog.StnNo = StnDef.StnNo;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                        }
                                        else
                                        {
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Create Auto Run Command Fail!";
                                            SystemTraceLog.LeftCmdSno = "Can't Get Cmd Sno!";
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Create Auto Run Command Fail!";
                                        SystemTraceLog.LeftCmdSno = "Can't Get InSideLoc!";
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                }
                                else
                                {
                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    SystemTraceLog.LogMessage = "Create Auto Run Command Fail!";
                                    SystemTraceLog.LeftCmdSno = "Can't Get OutSideLocID!";
                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }

        /// <summary>
        /// 自動搬送測試 (庫對庫模式)
        /// </summary>
        /// <param name="StnIndex"></param>
        private void funAutoRunTest2(int CraneNo)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strCNTS = string.Empty;
            string strLoc = string.Empty;
            string strLocID = string.Empty;
            string strNewLoc = string.Empty;
            string strCmdSno = string.Empty;
            string strLocSize = string.Empty;
            int intLocRow = 0;
            DataTable objLoc = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);

            try
            {
                if(CraneNo <= 0 && CraneNo > 3)
                    return;

                strSQL = "SELECT COUNT(*) AS CNTS FROM CMD_MST WHERE CMDSTS='0'";
                switch(CraneNo)
                {
                    #region Crane儲位範圍
                    case 1:
                        strSQL += " AND LOC <'050000'";
                        break;
                    case 2:
                        strSQL += " AND LOC >'050000' AND LOC < '090000'";
                        break;
                    case 3:
                        strSQL += " AND LOC >'090000'";
                        break;
                    #endregion Crane儲位範圍
                }
                if(clsSystem.gobjDB.funGetScalar(strSQL, ref strCNTS, ref strEM) == ErrDef.ProcSuccess)
                {
                    if(int.Parse(strCNTS) == 0)
                    {
                        strSQL = "SELECT TOP 1 LOC, LocID, CRANE_ROW,Loc_Size FROM LOC_MST WHERE LOCSTS='E'";
                        switch(CraneNo)
                        {
                            #region Crane儲位範圍
                            case 1:
                                strSQL += " AND LOC <'050000'";
                                break;
                            case 2:
                                strSQL += " AND LOC >'050000' AND LOC < '090000'";
                                break;
                            case 3:
                                strSQL += " AND LOC >'090000'";
                                break;
                            default:
                                return;
                            #endregion Crane儲位範圍
                        }
                        strSQL += " ORDER BY TRNDATE";
                        if(clsSystem.gobjDB.funGetDT(strSQL, ref objLoc, ref strEM) == ErrDef.ProcSuccess)
                        {
                            strLoc = objLoc.Rows[0]["LOC"].ToString();
                            strLocID = objLoc.Rows[0]["LocID"].ToString();
                            intLocRow = int.Parse(objLoc.Rows[0]["CRANE_ROW"].ToString());
                            strNewLoc = funGetEmptyLoc(CraneNo, intLocRow, clsLocSts.cstrLoc_ENNE, true, true, strLocSize,ref strSQL);
                            if(string.IsNullOrWhiteSpace(strNewLoc))
                                strNewLoc = funGetEmptyLoc(CraneNo, intLocRow, clsLocSts.cstrLoc_NNNN, false, true, strLocSize,ref strSQL);

                            if(!string.IsNullOrWhiteSpace(strNewLoc))
                            {
                                //strCmdSno = funGetCmdSno();
                                //if(!string.IsNullOrWhiteSpace(strCmdSno))
                                //{
                                //    strSQL = "UPDATE LOC_MST SET LOCSTS = 'O',OLDSTS = 'E'  WHERE LOC = '" + strLoc + "' AND LOCSTS = 'E'";
                                //    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
                                //    if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                //    {
                                //        strSQL = "UPDATE LOC_MST SET LOCSTS = 'I',OLDSTS = 'N' WHERE LOC = '" + strNewLoc + "' AND LOCSTS = 'N' ";
                                //        if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                //        {                        
                                //            strSQL = "INSERT INTO CMD_MST (CMDSNO, SNO, CMDSTS, PRT, CMDMODE, IOTYP, LOC, TRNDATE,";
                                //            strSQL += " ACTTIME, PROGID, LOCID, TRACE, STNNO,SCAN) VALUES (";
                                //            strSQL += "'" + strCmdSno + "1', '0', '5', '3', '33', '" + strLoc + "', ";
                                //            strSQL += "'" + DateTime.Now.ToString("yyyy/MM/dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "', ";
                                //            strSQL += "'MainControl', '" + strLocID + "', '0','','Y')";
                                //            if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                //            {
                                //            }
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                //    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                //    SystemTraceLog.LogMessage = "Create Auto Run Command Fail!";
                                //    SystemTraceLog.LeftCmdSno = "Can't Get Cmd Sno!";
                                //    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                //}
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }
    }
}
