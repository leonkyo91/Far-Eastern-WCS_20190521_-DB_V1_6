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
        /// 出庫流程
        /// </summary>
        private void funStockOut()
        {
            if (clsSystem.intBegin == 0)
            {
                clsSystem.intBegin = 1;
                funStockOut_ReleaseEquPLCCmd();
                clsSystem.intBegin = 0;
            }
            funStockOut_ReleaseEquPLCCmdFinish();
            if (clsSystem.intBegin == 0)
            {
                clsSystem.intBegin = 1;
                funStockOut_ReleaseCraneCmd();
                clsSystem.intBegin = 0;
            }
            if (clsSystem.intBegin == 0)
            {
                clsSystem.intBegin = 1;
                funStockOut_CraneCmdFinish();
                clsSystem.intBegin = 0;
            }
        }

        /// <summary>
        /// 出庫-取得BCR ID並取得命令序號寫入周邊PLC與更新Trace
        /// </summary>
        private void funStockOut_ReleaseEquPLCCmd()
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            DataTable objCmdSno = new DataTable();
            DataTable objDataTable = new DataTable();
            DataTable objCheckCMD = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            clsCmdSno CmdSno = new clsCmdSno();
            bool bolOut =false;
            foreach (clsStnDef StnDef in lstOutModeStnDef)
            {
                objCmdSno = null;
                try
                {
                    #region 暫存資料初始
                    if (objCmdSno != null)
                    {
                        objCmdSno.Clear();
                        objCmdSno.Dispose();
                        objCmdSno = null;
                    }
                    if (objDataTable != null)
                    {
                        objDataTable.Clear();
                        objDataTable.Dispose();
                        objDataTable = null;
                    }
                    if (objCheckCMD != null)
                    {
                        objCheckCMD.Clear();
                        objCheckCMD.Dispose();
                        objCheckCMD = null;
                    }
                    if (CmdSno != null)
                    {
                        CmdSno = null;
                    }
                    if (SystemTraceLog != null)
                    {
                        SystemTraceLog = null;
                    } 
                    #endregion

                    if (string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno) &&
                        objBufferData.PC2PLCBuffer[StnDef.BufferIndex].StnMode == 0)
                    {
                        #region 大立光 Select
                        strSQL = "SELECT Distinct LOC,CMD_SNO,CMD_MODE,Prty From CMD_MST ";
                        strSQL += "WHERE Cmd_Sno<>'' and CMD_STS='0' AND CMD_MODE IN ('2','3') AND STN_NO ='" + StnDef.StnNo + "'";
                        strSQL += "";
                        switch (StnDef.CraneNo)
                        {
                            case 1:
                                strSQL += " AND LOC <'0300000'";
                                break;
                            case 2:
                                strSQL += " AND LOC >'0300000' AND LOC < '0500000'";
                                break;
                            case 3:
                                strSQL += " AND LOC >'0500000' AND LOC < '0700000'";
                                break;
                            case 4:
                                strSQL += " AND LOC >'0700000' AND LOC < '0900000'";
                                break;
                            case 5:
                                strSQL += " AND LOC >'0900000' AND LOC < '1100000'";
                                break;
                            case 6:
                                strSQL += " AND LOC >'1100000' AND LOC < '1300000'";
                                break;
                            case 7:
                                strSQL += " AND LOC >'1300000' AND LOC < '1500000'";
                                break;
                            case 8:
                                strSQL += " AND LOC >'1500000' AND LOC < '1700000'";
                                break;
                            case 9:
                                strSQL += " AND LOC >'1700000' AND LOC < '1900000'";
                                break;
                            case 10:
                                strSQL += " AND LOC >'1900000' AND LOC < '2100000'";
                                break;
                            case 11:
                                strSQL += " AND LOC >'2100000'";
                                break;
                            default:
                                break;
                        }
                        strSQL += " ORDER BY Prty,CMD_SNO";
                        #endregion

                        if (clsSystem.gobjDB.funGetDT(strSQL, ref objCmdSno, ref strEM) == ErrDef.ProcSuccess)
                        {
                            #region 取得站口命令
                            bool bolCheckLoc = false;
                            bool bolRight = false;
                            bool bolLeft = false;
                            int intCmdMode = int.Parse(objCmdSno.Rows[0]["CMD_MODE"].ToString());
                            string strCmdSno = objCmdSno.Rows[0]["CMD_SNO"].ToString();
                            string strOutsideLoc = objCmdSno.Rows[0]["LOC"].ToString();
                            //string strPrty = objCmdSno.Rows[0]["Prty"].ToString();
                            CmdSno = new clsCmdSno();
                            objDataTable = new DataTable();
                            strSQL = "SELECT COUNT(CMD_SNO) AS CNTS FROM CMD_MST";
                            strSQL += " WHERE CMD_SNO='" + strCmdSno + "'";
                            strSQL += " AND CMD_STS='0' AND TRACE='0'";
                            if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                            {
                                int intCNTS = int.Parse(objDataTable.Rows[0]["CNTS"].ToString());
                                if (intCNTS == 1)
                                {
                                    CmdSno.CmdSno = strCmdSno;
                                    CmdSno.CmdMode = 2;
                                    bolRight = true;
                                    bolCheckLoc = true;
                                    strOutsideLoc = objCmdSno.Rows[0]["Loc"].ToString();
                                }

                            }

                            if ((!objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_CargoLoad ||
                                !objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_PalletLoad )&&
                                objBufferData.PLC2PCBuffer[StnDef.BufferIndex].Ready == (int)clsPLC2PCBuffer.enuReady.OutReady &&
                                string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno) &&
                                objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnMode == (int)clsPLC2PCBuffer.enuStnMode.None)
                            {
                                if (bolCheckLoc && !string.IsNullOrWhiteSpace(strOutsideLoc))
                                {
                                    //// 遠紡single deep 不需庫對庫
                                    #region 檢查內儲位是否需要進行庫對庫作業
                                    //if (!funCheckInsideLocIsEmpty(strOutsideLoc, strPrty, ref bolOut))
                                    //{
                                    //    if (bolOut)
                                    //        continue;
                                    //    funMoveInsideLoc(StnDef.CraneNo, strOutsideLoc, strCmdSno);

                                    //    continue;
                                    //}

                                    //else
                                    //{
                                        if (bolRight)
                                        {
                                            //檢查該站口命令，若有則退出，避免Update Trace
                                            strSQL = "SELECT Count(*) as CmdCount FROM CMD_MST WHERE Cmd_Sno<>'' and CMD_STS<'3' AND TRACE='" + clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd + "' AND STN_NO='" + StnDef.StnNo + "' ";

                                            if (clsSystem.gobjDB.funGetDT(strSQL, ref objCheckCMD, ref strEM) == ErrDef.ProcSuccess)
                                            {
                                                int iCMDCount = int.Parse(objCheckCMD.Rows[0]["CmdCount"].ToString());
                                                if (iCMDCount > 0)
                                                {
                                                    //Update多餘Trace
                                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.Alarm);
                                                    SystemTraceLog.LogMessage = "相同站口 CMDSTS和TRACE被更新多筆，命令殘留";
                                                    SystemTraceLog.StnNo = StnDef.StnNo;
                                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                    continue;
                                                }
                                            }

                                        #region 在Crane左HP側站口出庫
                                        clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "在Crane左HP側站口出庫 [Begin-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                        if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin) == ErrDef.ProcSuccess)
                                            {
                                                if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd))
                                                {
                                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                    SystemTraceLog.LogMessage = "Update CMD Trace Sucess! [" + CmdSno.CmdSno + "]";
                                                    SystemTraceLog.CmdSno = CmdSno.CmdSno;
                                                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                    SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd;
                                                    SystemTraceLog.StnNo = StnDef.StnNo;
                                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                    //寫入PLC
                                                    if (funWritePC2PLCSingel(
                                                       StnDef.Buffer,
                                                       CmdSno.CmdSno,
                                                       CmdSno.CmdMode.ToString(),
                                                       CmdSno.IniNotice.ToString()

                                                       ))
                                                    {
                                                        clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "在Crane左HP側站口出庫 [Commit-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                        SystemTraceLog.LogMessage = "Write PLC Sucess!";
                                                        SystemTraceLog.CmdSno = CmdSno.CmdSno;
                                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                        SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd;
                                                        SystemTraceLog.StnNo = StnDef.StnNo;
                                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                                                        //v1.0.0.20 不Return 直接continue
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "在Crane左HP側站口出庫 [Rollback-Start] Write PLC Fail!", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);

                                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                        SystemTraceLog.LogMessage = "Write PLC Fail!";
                                                        SystemTraceLog.CmdSno = CmdSno.CmdSno;
                                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                        SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd;
                                                        SystemTraceLog.StnNo = StnDef.StnNo;
                                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                                                        //v1.0.0.20 不Return 直接continue
                                                        continue;
                                                    }
                                                }
                                                else
                                                {
                                                    clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "在Crane左HP側站口出庫 [Rollback-Start] Update Cmd Trace Fail!", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                    SystemTraceLog.LogMessage = "Update Cmd Trace Fail!";
                                                    SystemTraceLog.RightCmdSno = CmdSno.CmdSno_R;
                                                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                    SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd;
                                                    SystemTraceLog.StnNo = StnDef.StnNo;
                                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                                                    //v1.0.0.20 不Return 直接continue
                                                    continue;
                                                }
                                            }
                                            #endregion 在Crane左HP側站口出庫


                                        }
                                        else if (bolLeft)
                                        {
                                        #region 在Crane右OP側站口出庫
                                        clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "在Crane右OP側站口出庫 [Begin-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
                                            if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd))
                                            {
                                                if (funWritePC2PLCSingel(
                                                    StnDef.Buffer,
                                                    CmdSno.CmdSno_L,
                                                    CmdSno.CmdSno_R,
                                                    CmdSno.CmdMode_L.ToString(),
                                                    CmdSno.StnMode_L.ToString(),
                                                    CmdSno.FunNotice_L.ToString(),
                                                    CmdSno.ReadNotice_L.ToString(),
                                                    CmdSno.PathNotice_L.ToString()))
                                                {
                                                    clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "在Crane右OP側站口出庫 [Commit-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                    SystemTraceLog.LogMessage = "Left Stock Out Cmd Initiated!";
                                                    SystemTraceLog.LeftCmdSno = CmdSno.CmdSno_L;
                                                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                    SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd;
                                                    SystemTraceLog.StnNo = StnDef.StnNo;
                                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                }
                                                else
                                                {
                                                clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "在Crane右OP側站口出庫 [Rollback-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                }
                                            }
                                            else
                                            {
                                                clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "在Crane右OP側站口出庫 [Rollback-Start] Update Left Cmd Trace Fail!", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "Update Left Cmd Trace Fail!";
                                                SystemTraceLog.LeftCmdSno = CmdSno.CmdSno_L;
                                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd;
                                                SystemTraceLog.StnNo = StnDef.StnNo;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                            #endregion 在Crane右OP側站口出庫
                                        }
                                    //}
                                    #endregion 檢查內儲位是否需要進行庫對庫作業
                                }
                                else if (bolCheckLoc && string.IsNullOrWhiteSpace(strOutsideLoc))
                                {

                                    #region Update Trace寫入PLC
                                    clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "Update Trace寫入PLC [Begin-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                    if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin) == ErrDef.ProcSuccess)
                                    {
                                        if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd))
                                        {
                                            if (funWritePC2PLCSingel(
                                                StnDef.Buffer,
                                                CmdSno.CmdSno_L,
                                                CmdSno.CmdSno_R,
                                                CmdSno.CmdMode_L.ToString(),
                                                CmdSno.StnMode_L.ToString(),
                                                CmdSno.FunNotice_L.ToString(),
                                                CmdSno.ReadNotice_L.ToString(),
                                                CmdSno.PathNotice_L.ToString()))
                                            {
                                                clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "Update Trace寫入PLC [Commit-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "Both Stock Out Cmd Initiated!";
                                                SystemTraceLog.LeftCmdSno = CmdSno.CmdSno_L;
                                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd;
                                                SystemTraceLog.StnNo = StnDef.StnNo;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                            else
                                            {
                                                clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "Update Trace寫入PLC [Rollback-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));
                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            }
                                        }
                                        else
                                        {
                                            clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "Update Trace寫入PLC [Rollback-Start] Update Both Cmd Trace Fail!", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Update Both Cmd Trace Fail!";
                                            SystemTraceLog.LeftCmdSno = CmdSno.CmdSno_L;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                            SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd;
                                            SystemTraceLog.StnNo = StnDef.StnNo;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    #endregion 兩板出庫

                                }
                            }
                            #endregion 取得站口命令
                        }
                    }
                }
                catch (Exception ex)
                {
                    var varObject = MethodBase.GetCurrentMethod();
                    clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                }
                finally
                {
                    if (objCmdSno != null)
                    {
                        objCmdSno.Clear();
                        objCmdSno.Dispose();
                        objCmdSno = null;
                    }
                    if (objDataTable != null)
                    {
                        objDataTable.Clear();
                        objDataTable.Dispose();
                        objDataTable = null;
                    }
                    if (objCheckCMD != null)
                    {
                        objCheckCMD.Clear();
                        objCheckCMD.Dispose();
                        objCheckCMD = null;
                    }
                    if (CmdSno != null)
                    {
                        CmdSno = null;
                    }
                    if (SystemTraceLog != null)
                    {
                        SystemTraceLog = null;
                    }
                }
            }
        }

        /// <summary>
        /// 出庫-寫入周邊PLC成功後清除 PC->PLC 的PLC值
        /// </summary>
        private void funStockOut_ReleaseEquPLCCmdFinish()
        {
            foreach (clsStnDef StnDef in lstOutModeStnDef)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno) &&
                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno ==objBufferData.PC2PLCBuffer[StnDef.BufferIndex].CmdSno &&
                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnMode ==objBufferData.PC2PLCBuffer[StnDef.BufferIndex].StnMode)
                    {
                        funRefreshPC2PLCSingel(StnDef.Buffer);
                    }
                    if ((!string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno) ||
                        !string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].RightCmdSno)) &&
                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno ==
                        objBufferData.PC2PLCBuffer[StnDef.BufferIndex].CmdSno &&

                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].CmdMode ==
                        objBufferData.PC2PLCBuffer[StnDef.BufferIndex].StnMode
                        )
                    {
                        funRefreshPC2PLCSingel(StnDef.Buffer);
                    }
                }
                catch (Exception ex)
                {
                    clsSystem.funWriteExceptionLog("[funStockOut_ReleaseEquPLCCmd]", "Exception [Rollback-Start] ", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                    var varObject = MethodBase.GetCurrentMethod();
                    clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                }
            }
        }

        /// <summary>
        /// 出庫-寫入Crane命令
        /// </summary>
        private void funStockOut_ReleaseCraneCmd()
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strCmdSno = string.Empty;
            string strRightCmdSno = string.Empty;
            DataTable objDataTable = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);

            foreach (clsStnDef StnDef in lstOutModeStnDef)
            {
                if (objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
                try
                {
                    if ((!objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_CargoLoad ||
                        !objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_PalletLoad) &&
                        !string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno))

                        //大立光--------------------------------------------------------
                        if ((!objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_CargoLoad ||
                             !objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_PalletLoad) &&
                            !string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno) &&
                            objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnMode == 2)
                        {
                            #region Crane出庫
                            strCmdSno = objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0');



                            strSQL = "SELECT TOP(1) LOC,PRTY,STN_NO FROM CMD_MST WHERE CMD_STS<'3' AND CMD_SNO='" + strCmdSno + "' AND CMD_MODE IN ('2', '3')";
                            strSQL += " AND TRACE='" + clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd + "' ORDER BY LOC DESC";
                            if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                            {
                                string strLoc = objDataTable.Rows[0]["LOC"].ToString();
                                string strPrt = objDataTable.Rows[0]["PRTY"].ToString();
                                string strStn_No = objDataTable.Rows[0]["STN_NO"].ToString();

                                if (funCheckLocMatchCrane(strLoc, StnDef.CraneNo, strCmdSno) &&
                                    !funCheckEquCmdRepeat(StnDef.PortNo, StnDef.CraneNo, clsEquCmdMode.cstrOutMode))
                                {

                                    #region 更新Trace 和 新增EQUCMD
                                    clsSystem.funWriteExceptionLog("[funStockOut_ReleaseCraneCmd]", "更新Trace 和 新增EQUCMD [Begin-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                    if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin, ref strEM) == ErrDef.ProcSuccess)
                                    {
                                        if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrStoreOutTrace_ReleaseCraneCmd))
                                        {
                                            if (funInsertStockOutEquCmd(StnDef.CraneNo, strCmdSno, strLoc, StnDef.PortNo, strPrt))
                                            {
                                                //更新字幕機 出庫顯示
                                                funMvsData(strStn_No, strCmdSno, "1", "0", "", true);

                                                clsSystem.funWriteExceptionLog("[funStockOut_ReleaseCraneCmd]", "更新Trace 和 新增EQUCMD [Commit-Start]", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "Stock Out Transferring!";
                                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseCraneCmd;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                        }
                                        else
                                        {
                                            clsSystem.funWriteExceptionLog("[funStockOut_ReleaseCraneCmd]", "更新Trace 和 新增EQUCMD [Rollback-Start]Update Cmd Trace Fail!", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Update Cmd Trace Fail!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                            SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseCraneCmd;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "[Begin Fail]:[funStockOut_ReleaseCraneCmd()]" + strEM;
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }

                                    #endregion 更新Trace 和 新增EQUCMD

                                }
                            }
                            #endregion Crane出庫
                        }
                    //--------------------------------------------------------------

                }
                catch (Exception ex)
                {
                    clsSystem.funWriteExceptionLog("[funStockOut_ReleaseCraneCmd]", "Exception [Rollback-Start]Update Cmd Trace Fail!", " CmdSno=" + objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0'));

                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                    var varObject = MethodBase.GetCurrentMethod();
                    clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                }
                finally
                {
                    if (objDataTable != null)
                    {
                        objDataTable.Clear();
                        objDataTable.Dispose();
                        objDataTable = null;
                    }
                    if (SystemTraceLog != null)
                    {
                        SystemTraceLog = null;
                    }
                }
            }
        }

        /// <summary>
        /// 出庫-判斷Crane命令是否完成，並更新Trace
        /// </summary>
        private void funStockOut_CraneCmdFinish()
        {
            DataTable objDataTable = new DataTable();
            DataTable objCmd = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                strSQL = "SELECT DISTINCT CMD_SNO, CMD_MODE, TRACE FROM CMD_MST WHERE Cmd_Sno<>'' and CMD_MODE IN ('2', '3')";
                strSQL += " AND CMD_STS='1' AND TRACE='" + clsTrace.cstrStoreOutTrace_ReleaseCraneCmd + "'";
                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    for (int intCount1 = 0; intCount1 < objDataTable.Rows.Count; intCount1++)
                    {
                        if (objCmd != null)
                        {
                            objCmd.Clear();
                            objCmd.Dispose();
                            objCmd = null;
                        }
                        string strCmdSno = objDataTable.Rows[intCount1]["CMD_SNO"].ToString();
                        string strCmdMode = objDataTable.Rows[intCount1]["CMD_MODE"].ToString();

                        strSQL = "SELECT * FROM EQUCMD WHERE CMDSNO='" + strCmdSno + "'";
                        strSQL += " AND RENEWFLAG <> 'F' AND CMDSTS in ('8','9')";
                        if (clsSystem.gobjDB.funGetDT(strSQL, ref objCmd, ref strEM) == ErrDef.ProcSuccess)
                        {
                            for (int intCount2 = 0; intCount2 < objCmd.Rows.Count; intCount2++)
                            {
                                string strCmdSts = objCmd.Rows[intCount2]["CmdSts"].ToString();
                                string strCompleteCode = objCmd.Rows[intCount2]["CompleteCode"].ToString();

                                //if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode.Substring(0, 1) == "W")
                                if (strCompleteCode.Substring(0, 1) == "W")
                                {
                                    #region Update Equ Cmd CmdSts
                                    strSQL = "UPDATE EQUCMD SET CMDSTS='0' , CompleteCode=' ' WHERE CMDSNO='" + strCmdSno + "'";
                                    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "(W1) Crane Stock Out Cmd Retry Success!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "(W1) Crane Stock Out Cmd Retry Fail!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Equ Cmd CmdSts
                                }
                                else if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "E2")
                                {
                                    #region Update Cmd Trace 空出庫 強制過帳
                                    //v1.0.0.18 -1
                                    if (funUpdateCmdTrace_Abnormal(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrStoreOutTrace_ReleaseCraneCmd, clsCmdAbnormal.cstrEmptyOut))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Stock Out Cmd Finish![空出庫]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Stock Out Cmd Trace Fail![空出庫]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                                else if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "EF")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    //v1.0.0.18 -2
                                    if (funUpdateCmdTrace_Abnormal(strCmdSno, clsCmdSts.cstrCmdSts_CancelWaitPost, clsTrace.cstrStoreOutTrace_ReleaseCraneCmd,clsCmdAbnormal.cstrEF))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Stock Out Cmd Finish![地上盤強制取消]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CancelWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Stock Out Cmd Trace Fail![地上盤強制取消]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CancelWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                                else if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "FF")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    //v1.0.0.18 -2
                                    if (funUpdateCmdTrace_Abnormal(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrStoreOutTrace_ReleaseCraneCmd, clsCmdAbnormal.cstrFF))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Stock Out Cmd Finish![地上盤強制完成]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Stock Out Cmd Trace Fail![地上盤強制完成]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                                else if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "92")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    if (strCmdMode == "3")
                                    {
                                        #region 撿料命令-當作正常出庫，由過帳產生新的入庫命令
                                        if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrStoreOutTrace_CraneCmdFinish))
                                        //if(funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrStoreOutTrace_CraneCmdFinish))
                                        {
                                            funDeleteEquCmd(strCmdSno);
                                            funNewCmdForPickup(strCmdSno);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "盤點/檢料 Cmd Finish!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                            SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_CraneCmdFinish;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                        else
                                        {
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Update 盤點/檢料 Cmd Trace Fail!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                            SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_CraneCmdFinish;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                        #endregion 撿料命令
                                    }
                                    else
                                    {
                                        #region 出庫命令
                                        if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrStoreOutTrace_CraneCmdFinish))
                                        {
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Stock Out Cmd Finish!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                            SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_CraneCmdFinish;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                        else
                                        {
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Update Stock Out Cmd Trace Fail!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                            SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_CraneCmdFinish;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                        #endregion 出庫命令
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                if (objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
                if (objCmd != null)
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
    }
}
