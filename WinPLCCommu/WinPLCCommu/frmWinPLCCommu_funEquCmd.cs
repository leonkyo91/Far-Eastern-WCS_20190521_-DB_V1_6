


using Mirle.Library;
using System;
using System.Data;
using System.Reflection;

namespace Mirle.WinPLCCommu
{
    public partial class frmWinPLCCommu
    {

        /// <summary>
        /// 檢查儲位是否在同一條Crane上；同一條Crane傳回true，否則傳回false
        /// </summary>
        /// <param name="Loc"></param>
        /// <param name="CraneNo"></param>
        /// <returns></returns>
        private bool funCheckLocMatchCrane(string Loc, int CraneNo, string CmdSno)
        {
            try
            {
                string strRowX;
                if (Loc.Length ==6)           
                    strRowX = Loc.Substring(0, 1);
                else
                    strRowX = Loc.Substring(0, 2);

                int intRowX = (int.Parse(strRowX) + 1) / 2;
                if (CraneNo == intRowX)
                    return true;
                else
                {
                    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                    SystemTraceLog.LogMessage = "Cmd Format Error!";
                    SystemTraceLog.LeftCmdSno = CmdSno;
                    SystemTraceLog.LocID = Loc;
                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                    SystemTraceLog = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 由外側儲位取得內側儲位狀態
        /// </summary>
        /// <param name="OutsideLoc"></param>
        /// <param name="Loc_Row"></param>
        /// <returns></returns>
        private string funCheckInsideLocSts(string OutsideLoc, string Loc_Row)
        {
            string strInsideLoc = string.Empty;
            string strLocSts = string.Empty;
            string strSQL = string.Empty;
            string strEM = string.Empty;
            DataTable dtTmp = new DataTable();
            try
            {
                strInsideLoc = (clsTool.funConvertToInt(Loc_Row) - 2).ToString().PadLeft(2, '0') + OutsideLoc.Substring(2);
                strSQL = "SELECT LOC_STS FROM LOC_MST WHERE LOC='" + strInsideLoc + "'";
                if (clsSystem.gobjDB.funGetDT(strSQL, ref dtTmp, ref strEM) == ErrDef.ProcSuccess)
                {
                }
                strLocSts = dtTmp.Rows[0]["LOCSTS"].ToString();
                //clsSystem.gobjDB.funGetScalar(strSQL, ref strLocSts, ref strEM);
                return strLocSts;
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return strLocSts;
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

        /// <summary>
        /// 取得存取機編號
        /// </summary>
        /// <param name="Loc"></param>
        /// <returns></returns>
        private int funGetCraneRow(string Loc)
        {
            string strRow = Loc.Substring(0, 2);
            if(strRow == "01" || strRow == "05" || strRow == "09")
                return 1;
            else if(strRow == "02" || strRow == "06" || strRow == "10")
                return 2;
            else if(strRow == "03" || strRow == "07" || strRow == "11")
                return 3;
            else if(strRow == "04" || strRow == "08" || strRow == "12")
                return 4;
            else
                return 0;
        }

        /// <summary>
        /// 檢查Crane是否存在命令；存在命令傳回true，否則傳回false
        /// </summary>
        /// <param name="LocPort"></param>
        /// <param name="CraneNo"></param>
        /// <param name="CmdMode"></param>
        /// <returns></returns>
        private bool funCheckEquCmdRepeat(string LocPort, int CraneNo, string CmdMode)
        {
            DataTable objDataTable = new DataTable();
            string strSQL = string.Empty;
            string strLocPort = string.Empty;
            string strEM = string.Empty;
            int intCraneNo = 0;

            try
            {
                switch(CmdMode)
                {
                    case clsEquCmdMode.cstrInMode:
                        strSQL = "SELECT COUNT (*) AS ICOUNT FROM EQUCMD WHERE EQUNO='" + CraneNo + "' AND CmdSts IN ('0', '1')";
                        strSQL += " AND SOURCE IN ('" + clsStnNoDef.cstrCraneHP_2F_IN + "', '" + clsStnNoDef.cstrCraneHP_2F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_3F_IN + "', '" + clsStnNoDef.cstrCraneHP_3F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_4F_IN + "', '" + clsStnNoDef.cstrCraneHP_4F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_5F_IN + "', '" + clsStnNoDef.cstrCraneHP_5F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_6F_IN + "', '" + clsStnNoDef.cstrCraneHP_6F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_7F_IN + "', '" + clsStnNoDef.cstrCraneHP_7F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_8F_IN + "', '" + clsStnNoDef.cstrCraneHP_8F_OUT + "'";
                        strSQL += ")";
                        

                        //if(LocPort == clsStnNoDef.cstrCraneHPRight_Left ||
                        //    LocPort == clsStnNoDef.cstrCraneHPRight_Right ||
                        //    LocPort == clsStnNoDef.cstrCraneHPRight_Both)
                        //{
                        //    strSQL = "SELECT COUNT (*) AS ICOUNT FROM EQUCMD WHERE EQUNO='" + CraneNo + "' AND CmdSts IN ('0', '1')";
                        //    strSQL += " AND SOURCE IN ('" + clsStnNoDef.cstrCraneHPRight_Left + "', '" + clsStnNoDef.cstrCraneHPRight_Right + "',";
                        //    strSQL += " '" + clsStnNoDef.cstrCraneHPRight_Both + "')";
                        //}
                        //else if(LocPort == clsStnNoDef.cstrCraneOPLeft_Right ||
                        //    LocPort == clsStnNoDef.cstrCraneOPLeft_Left ||
                        //    LocPort == clsStnNoDef.cstrCraneOPLeft_Both)
                        //{
                        //    strSQL = "SELECT COUNT (*) AS ICOUNT FROM EQUCMD WHERE EQUNO='" + CraneNo + "' AND CmdSts IN ('0', '1')";
                        //    strSQL += " AND SOURCE IN ('" + clsStnNoDef.cstrCraneOPLeft_Right + "', '" + clsStnNoDef.cstrCraneOPLeft_Left + "',";
                        //    strSQL += " '" + clsStnNoDef.cstrCraneOPLeft_Both + "')";
                        //}
                        break;
                    case clsEquCmdMode.cstrOutMode:
                        strSQL = "SELECT COUNT (*) AS ICOUNT FROM EQUCMD WHERE EQUNO='" + CraneNo + "' AND CmdSts IN ('0', '1')";
                        strSQL += " AND Destination IN ('" + clsStnNoDef.cstrCraneHP_2F_IN + "', '" + clsStnNoDef.cstrCraneHP_2F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_3F_IN + "', '" + clsStnNoDef.cstrCraneHP_3F_OUT + "'";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_4F_IN + "', '" + clsStnNoDef.cstrCraneHP_4F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_5F_IN + "', '" + clsStnNoDef.cstrCraneHP_5F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_6F_IN + "', '" + clsStnNoDef.cstrCraneHP_6F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_7F_IN + "', '" + clsStnNoDef.cstrCraneHP_7F_OUT + "',";
                        strSQL += "'" + clsStnNoDef.cstrCraneHP_8F_IN + "', '" + clsStnNoDef.cstrCraneHP_8F_OUT + "'";
                        strSQL += ")";
                        
                        //if(LocPort == clsStnNoDef.cstrCraneHPLeft_Right ||
                        //    LocPort == clsStnNoDef.cstrCraneHPLeft_Left ||
                        //    LocPort == clsStnNoDef.cstrCraneHPLeft_Both)
                        //{
                        //    strSQL = "SELECT COUNT (*) AS ICOUNT FROM EQUCMD WHERE EQUNO='" + CraneNo + "' AND CmdSts IN ('0', '1')";
                        //    strSQL += " AND SOURCE IN ('" + clsStnNoDef.cstrCraneHPLeft_Right + "', '" + clsStnNoDef.cstrCraneHPLeft_Left + "',";
                        //    strSQL += " '" + clsStnNoDef.cstrCraneHPLeft_Both + "')";
                        //}
                        //else if(LocPort == clsStnNoDef.cstrCraneOPRight_Left ||
                        //    LocPort == clsStnNoDef.cstrCraneOPRight_Right ||
                        //    LocPort == clsStnNoDef.cstrCraneOPRight_Both)
                        //{
                        //    strSQL = "SELECT COUNT (*) AS ICOUNT FROM EQUCMD WHERE EQUNO='" + CraneNo + "' AND CmdSts IN ('0', '1')";
                        //    strSQL += " AND DESTINATION IN ('" + clsStnNoDef.cstrCraneOPRight_Left + "', '" + clsStnNoDef.cstrCraneOPRight_Right + "',";
                        //    strSQL += " '" + clsStnNoDef.cstrCraneOPRight_Both + "')";
                        //}
                        break;
                    case clsEquCmdMode.cstrStnToStn:
                    case clsEquCmdMode.cstrLocToLoc:
                        strSQL = "SELECT COUNT (*) AS ICOUNT FROM EQUCMD WHERE EQUNO='" + CraneNo + "' AND CMDMODE='" + CmdMode + "' AND CmdSts IN ('0', '1')";
                        break;
                    default:
                        break;
                }

                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    intCraneNo = int.Parse(objDataTable.Rows[0]["ICOUNT"].ToString());
                    return intCraneNo == 0 ? false : true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
            finally
            {
                if(objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
            }
        }

        /// <summary>
        /// 寫入入庫命令；成功傳回true，否則傳回false
        /// </summary>
        /// <param name="CraneNo"></param>
        /// <param name="CmdSno"></param>
        /// <param name="Loc"></param>
        /// <param name="CranePortNo"></param>
        /// <param name="Prt"></param>
        /// <returns></returns>
        private bool funInsertStockInEquCmd(int CraneNo, string CmdSno, string Loc, string CranePortNo, string Prt)
        {
            if(CraneNo == 0 || string.IsNullOrWhiteSpace(CmdSno) || string.IsNullOrWhiteSpace(Loc) || string.IsNullOrWhiteSpace(CranePortNo))
                return false;

            if(!funCheckExecutionEquCmd(CraneNo, CmdSno, clsEquCmdMode.cstrInMode, CranePortNo, Loc, Prt))
                return funInsertEquCmd(CraneNo, CmdSno, clsEquCmdMode.cstrInMode, CranePortNo, Loc, Prt);
            else
                return false;
        }

        private bool funInsertLocToLocEquCmd(int CraneNo, string CmdSno, string Source, string Destination, string Prt)
        {
            if(CraneNo == 0 || string.IsNullOrWhiteSpace(CmdSno) || string.IsNullOrWhiteSpace(Source) || string.IsNullOrWhiteSpace(Destination))
                return false;

            if(!funCheckExecutionEquCmd(CraneNo, CmdSno, clsEquCmdMode.cstrLocToLoc, Source, Destination, Prt))
                return funInsertEquCmd(CraneNo, CmdSno, clsEquCmdMode.cstrLocToLoc, Source, Destination, Prt);
            else
                return false;
        }

        private bool funInsertStockOutEquCmd(int CraneNo, string CmdSno, string Loc, string CranePortNo, string Prt)
        {
            string strRow = string.Empty;
            int intRow = 0;

            if(CraneNo == 0 || string.IsNullOrWhiteSpace(CmdSno) || string.IsNullOrWhiteSpace(Loc) || string.IsNullOrWhiteSpace(CranePortNo))
                return false;
           
            if (Loc.Length == 6)
                strRow = Loc.Substring(0, 1);
            else
                strRow = Loc.Substring(0, 2);

            intRow = (int.Parse(strRow) + 1) / 2;

            if(CraneNo != intRow)
                return false;

            if (!funCheckExecutionEquCmd(CraneNo, CmdSno, clsEquCmdMode.cstrOutMode, Loc, CranePortNo, Prt))
                return funInsertEquCmd(CraneNo, CmdSno, clsEquCmdMode.cstrOutMode, Loc, CranePortNo, Prt);
            else
                return false;
        }

        /// <summary>
        /// 寫入Crane命令；成功傳回true，否則傳回false
        /// </summary>
        /// <param name="CraneNo"></param>
        /// <param name="CmdSno"></param>
        /// <param name="CmdMode"></param>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        /// <param name="Prt"></param>
        /// <returns></returns>
        private bool funInsertEquCmd(int CraneNo, string CmdSno, string CmdMode, string Source, string Destination, string Prt)
        {
            if(CraneNo == 0 ||
                string.IsNullOrWhiteSpace(CmdSno) ||
                string.IsNullOrWhiteSpace(CmdMode) ||
                string.IsNullOrWhiteSpace(Source) ||
                string.IsNullOrWhiteSpace(Destination))
                return false;

            string strSQL = string.Empty;
            string strEM = string.Empty;
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);

            try
            {
                switch (CmdMode)
                {
                    case clsEquCmdMode.cstrInMode:
                    case clsEquCmdMode.cstrDeposite:
                        Source = funGetEquCraneStandardLocByStn(Source);
                        Destination = funGetEquCraneStandardLoc(Destination);
                        break;
                    case clsEquCmdMode.cstrOutMode:
                        Source = funGetEquCraneStandardLoc(Source);
                        Destination = funGetEquCraneStandardLocByStn(Destination);
                        break;
                    case clsEquCmdMode.cstrStnToStn:
                        Source = funGetEquCraneStandardLocByStn(Source);
                        Destination = funGetEquCraneStandardLocByStn(Destination);
                        break;
                    case clsEquCmdMode.cstrLocToLoc:
                        Source = funGetEquCraneStandardLoc(Source);
                        Destination = funGetEquCraneStandardLoc(Destination);
                        break;
                }
                strSQL = "INSERT INTO EquCmd(CmdSno, EquNo, CmdMode, CmdSts, Source, Destination, LocSize, Priority, RCVDT, SpeedLevel) Values ('";
                strSQL += CmdSno + "', '" + CraneNo + "', '" + CmdMode + "', '0', '" + Source + "', '" + Destination + "', '0', '";
                strSQL += Prt + "', '" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "', '0')";
                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                {
                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                    SystemTraceLog.LogMessage = "Create Crane Command Success!";
                    SystemTraceLog.LeftCmdSno = CmdSno;
                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                    SystemTraceLog.CmdMode = CmdMode;
                    SystemTraceLog.LocID = Source;
                    SystemTraceLog.NewLocID = Destination;
                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                    SystemTraceLog = null;
                    return true;
                }
                else
                {
                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                    SystemTraceLog.LogMessage = "Create Crane Command Fail!";
                    SystemTraceLog.LeftCmdSno = CmdSno;
                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                    SystemTraceLog.CmdMode = CmdMode;
                    SystemTraceLog.LocID = Source;
                    SystemTraceLog.NewLocID = Destination;
                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
            finally
            {
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }

        /// <summary>
        /// 產生庫對庫命令
        /// </summary>
        /// <param name="Source">來源</param>
        /// <param name="Destination">目的</param>
        /// <param name="IOType">作業業別</param>
        /// <param name="Prt">優先權</param>
        private void funInsertLocToLocCmd(string Source, string Destination, string IOType, string Prt)
        {
            DataTable objDataTable = new DataTable();
            DataTable objDataTable_Detail = new DataTable();
            DataTable dtTmp = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strLocID = string.Empty;
            string strLocSts = string.Empty;
            string strCmdSno = string.Empty;
            string strPltID = string.Empty;
            string strLotNo = string.Empty;
            string strInDate = string.Empty;
            string strInTktNo = string.Empty;
            string strTrnTktNo = string.Empty;

            try
            {
                string strRow_FromLoc = Source.Substring(0, 2);
                string strRow_ToLoc = Destination.Substring(0, 2);
                int intRow_FromLoc = (int.Parse(strRow_FromLoc) + 3) / 4;
                int intRow_ToLoc = (int.Parse(strRow_ToLoc) + 3) / 4;
                if (intRow_FromLoc != intRow_ToLoc)
                    return;

                if (string.IsNullOrWhiteSpace(Prt))
                    Prt = "4";

                strSQL = "SELECT * FROM LOC_MST WHERE LOC='" + Source + "'";
                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    strLocID = objDataTable.Rows[0]["LOC_ID"].ToString();
                    strLocSts = objDataTable.Rows[0]["LOC_STS"].ToString();


                    strSQL = "SELECT * FROM CMD_MST WHERE Cmd_Sno<>'' and PLT_ID ='" + objDataTable.Rows[0]["PLT_ID"].ToString() + "'AND CMD_Sts<'3'";
                    if (clsSystem.gobjDB.funGetDT(strSQL, ref dtTmp, ref strEM) == ErrDef.ProcSuccess)
                    {
                        return;
                    }
                    //v1.0.0.22 
                    //strSQL = "Select * From Loc_Dtl Where Loc='" + Source + "'";
                    //if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable_Detail, ref strEM) == ErrDef.ProcSuccess)
                    //{
                    //}
                    strCmdSno = funGetCmdSno();
                    if (!string.IsNullOrWhiteSpace(strCmdSno))
                    {
                        strSQL = "INSERT INTO CMD_MST (CMD_SNO,CMD_STS,PRTY,CMD_MODE,IO_TYPE,LOC,NEW_LOC,CRT_DATE,LOC_ID,TRACE,STN_NO,TRN_USER,PLT_COUNT,Plt_ID,WEIGHT,FUN_ID,Equ_No,WH_ID)VALUES";
                        //v1.0.0.22  命令產生時間改為24小時制
                        //v1.0.1.1  SQL Plt_Count 加入單引號
                        strSQL += "('" + strCmdSno + "','0',4,'5','" + IOType + "','" + Source + "','" + Destination + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','','0','0','WCS','" + objDataTable.Rows[0]["PLT_COUNT"].ToString() + "',";
                        strSQL += "'" + objDataTable.Rows[0]["PLT_ID"].ToString() + "','" + objDataTable.Rows[0]["WEIGHT"].ToString() + "','','" + objDataTable.Rows[0]["Equ_No"].ToString() + "','ASRS')";
                        
                           
                            #region 產生CMD_MST 庫對庫命令
                            if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin, ref strEM) == 0)
                            {
                                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                {
                                    //v1.0.0.23 
                                    strSQL = "UPDATE LOC_MST SET LOC_STS='O',OLD_STS='" + strLocSts + "',Trn_Date='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "',MEMO='WCS' ";
                                    strSQL += "WHERE LOC_STS IN ('S','E','H') AND LOC='" + Source + "'";

                                    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                    {
                                        //v1.0.0.23 
                                        strSQL = "UPDATE LOC_MST SET LOC_STS='I',OLD_STS='N',Trn_Date='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "',MEMO='WCS' ";
                                        strSQL += " WHERE LOC_STS='N' AND LOC='" + Destination + "'";
                                        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Create Loc To Loc Command Success!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                            SystemTraceLog.LocID = Source;
                                            SystemTraceLog.NewLocID = Destination;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                        else
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                            SystemTraceLog.LocID = Source;
                                            SystemTraceLog.NewLocID = Destination;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }

                                    }
                                    else
                                    {
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                        SystemTraceLog.LocID = Source;
                                        SystemTraceLog.NewLocID = Destination;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    //v1.0.0.22 移除產生cmd_dtl
                                    //for (int iRow = 0; iRow < objDataTable_Detail.Rows.Count; iRow++)
                                    //{
                                    //    strSQL = "Insert Into Cmd_Dtl(Cmd_Txno,Cmd_Sno,Plt_Qty,Loc,Plt_Id,Lot_No,In_Date,In_Tkt_No,Trn_Tkt_No,Item_No,Cust_No,Cust_Name,Uom,CAV_No,Prod_Type,Prod_Date,Memo,Trn_Qty)Values(";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Loc_Txno"].ToString() + "',";
                                    //    strSQL += "'" + strCmdSno + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Plt_Qty"].ToString() + "',";
                                    //    strSQL += "'" + Source + "',";
                                    //    strSQL += "'" + objDataTable.Rows[iRow]["Plt_ID"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Lot_No"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["In_Date"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["In_Tkt_No"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Trn_Tkt_No"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Item_No"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Cust_No"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Cust_Name"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Uom"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["CAV_No"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Prod_Type"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Prod_Date"].ToString() + "',";
                                    //    strSQL += "'" + objDataTable_Detail.Rows[iRow]["Memo"].ToString() + "',";
                                    //    //v1.0.0.20 庫對庫Trn_Qty=0
                                    //    strSQL += "0)";
                                    //    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                    //    {
                                    //        strSQL = "UPDATE LOC_MST SET LOC_STS='O',OLD_STS='" + strLocSts + "' WHERE LOC_STS IN ('S','E','H') AND LOC='" + Source + "'";
                                    //        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                    //        {
                                    //            strSQL = "UPDATE LOC_MST SET LOC_STS='I',OLD_STS='N' WHERE LOC_STS='N' AND LOC='" + Destination + "'";
                                    //            if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                    //            {
                                    //                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                    //                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    //                SystemTraceLog.LogMessage = "Create Loc To Loc Command Success!";
                                    //                SystemTraceLog.LeftCmdSno = strCmdSno;
                                    //                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                    //                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                    //                SystemTraceLog.LocID = Source;
                                    //                SystemTraceLog.NewLocID = Destination;
                                    //                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    //            }
                                    //            else
                                    //            {
                                    //                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                    //                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    //                SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                    //                SystemTraceLog.LeftCmdSno = strCmdSno;
                                    //                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                    //                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                    //                SystemTraceLog.LocID = Source;
                                    //                SystemTraceLog.NewLocID = Destination;
                                    //                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    //            }

                                    //        }
                                    //        else
                                    //        {
                                    //            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                    //            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    //            SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                    //            SystemTraceLog.LeftCmdSno = strCmdSno;
                                    //            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                    //            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                    //            SystemTraceLog.LocID = Source;
                                    //            SystemTraceLog.NewLocID = Destination;
                                    //            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                    //    }

                                    //}           

                                }
                                else
                                {
                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    SystemTraceLog.LogMessage = "Create Loc To Loc Command Fail!";
                                    SystemTraceLog.LeftCmdSno = strCmdSno;
                                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                    SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                    SystemTraceLog.LocID = Source;
                                    SystemTraceLog.NewLocID = Destination;
                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                }
                            }
                            else
                            {
                                //v1.0.0.21 Begin 失敗 寫Log
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Begin DB Fail! " + strEM;
                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                SystemTraceLog.LocID = Source;
                                SystemTraceLog.NewLocID = Destination;
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            }

                            #endregion 產生CMD_MST 庫對庫命令
                        
                    }
                    else
                    {
                        
                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        SystemTraceLog.LogMessage = "Create Loc To Loc Command Fail!";
                        SystemTraceLog.LeftCmdSno = "Can't Get Cmd Sno!";
                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                    }
                }
            }
            catch (Exception ex)
            {
                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message+":"+ex.Data);
            }
            finally
            {
                if (objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
                if (objDataTable_Detail != null)
                {
                    objDataTable_Detail.Clear();
                    objDataTable_Detail.Dispose();
                    objDataTable_Detail = null;
                }
                if (dtTmp != null)
                {
                    dtTmp.Clear();
                    dtTmp.Dispose();
                    dtTmp = null;
                }
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }

        /// <summary>
        /// 產生空棧板入庫命令
        /// </summary>
        /// <param name="CMDSNO">命令序號</param>
        /// <param name="STNNO">站口編號</param>
        /// <param name="EQU_NO">CRANE編號</param>
        private void funInsertEmptyPltInCmd(string CMDSNO, string STNNO, string EQU_NO)
        {
            DataTable objDataTable = new DataTable();
            DataTable objDataTable_Detail = new DataTable();
            DataTable dtTmp = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            string strSQL = string.Empty;
            string strEM = string.Empty;
            
            string PLT_ID = "E" + CMDSNO;

            try
            {
                strSQL = "INSERT INTO CMD_MST (CMD_SNO,CMD_STS,PRTY,CMD_MODE,IO_TYPE,WH_ID,CRT_DATE,TRACE,Plt_Count,STN_NO,TRN_USER,Plt_ID,Equ_No,Mix_qty,Avail,Weight)VALUES";
                strSQL += "('" + CMDSNO + "','0',5,'1','14','ASRS','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','0','1','" + STNNO + "','WCS',";
                strSQL += "'" + PLT_ID + "','" + EQU_NO + "','1','100','1')";

                #region 產生CMD_MST 棧板入庫命令
                        
                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                {
                                
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Create Empty Pallets Stock In Success!";
                                        SystemTraceLog.LeftCmdSno = CMDSNO;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                }
                else
                {
                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Create Empty Pallets Stock In Command Fail!";
                                SystemTraceLog.LeftCmdSno = CMDSNO;
                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                }


                #endregion 產生CMD_MST 庫對庫命令
                
            }
            catch (Exception ex)
            {
                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message + ":" + ex.Data);
            }
            finally
            {
                if (objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
                if (objDataTable_Detail != null)
                {
                    objDataTable_Detail.Clear();
                    objDataTable_Detail.Dispose();
                    objDataTable_Detail = null;
                }
                if (dtTmp != null)
                {
                    dtTmp.Clear();
                    dtTmp.Dispose();
                    dtTmp = null;
                }
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }

        }


        /// <summary>
        /// 產生庫對庫命令
        /// </summary>
        /// <param name="FromLoc_L"></param>
        /// <param name="FromLoc_R"></param>
        /// <param name="ToLoc_L"></param>
        /// <param name="ToLoc_R"></param>
        /// <param name="LocSts"></param>
        private void funInsertLocToLocCmd(string FromLoc_L, string FromLoc_R, string ToLoc_L, string ToLoc_R, string LocSts)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strLocID_L = string.Empty;
            string strLocID_R = string.Empty;
            string strIOType = string.Empty;
            string strCmdSno = string.Empty;
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);

            try
            {
                if (LocSts == clsLocSts.cstrEmptyStored)
                    strIOType = clsIOType.cstrRtoR;
                else if (LocSts == clsLocSts.cstrStored)
                    strIOType = clsIOType.cstrRtoR;
                else if (LocSts == clsLocSts.cstrRevision)
                    strIOType = clsIOType.cstrRtoR;

                strSQL = "SELECT LOCID FROM LOC_MST WHERE LOC='" + FromLoc_L + "'";
                clsSystem.gobjDB.funGetScalar(strSQL, ref strLocID_L, ref strEM);
                strSQL = "SELECT LOCID FROM LOC_MST WHERE LOC='" + FromLoc_R + "'";
                clsSystem.gobjDB.funGetScalar(strSQL, ref strLocID_R, ref strEM);
                strCmdSno = funGetCmdSno();

                if (!string.IsNullOrWhiteSpace(strCmdSno))
                {
                    strSQL = "INSERT INTO CMD_MST (CMDSNO, SNO, CMDSTS, PRT, CMDMODE, IOTYP, LOC, NEWLOC,";
                    strSQL += " TRNDATE, ACTTIME, PROGID, LOCID, TRACE, STNNO)";
                    strSQL += " VALUES ('" + strCmdSno + "', '1', '0', '5', '5', '" + strIOType + "', '" + FromLoc_L + "', '" + ToLoc_L + "',";
                    strSQL += " '" + DateTime.Now.ToString("yyyy/MM/dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "', 'MainControl',";
                    strSQL += " '" + strLocID_L + "', '0', '')";
                    #region 產生庫對庫命令 CMD_MST
                    if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin) == ErrDef.ProcSuccess)
                    {
                        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                        {
                            strSQL = "UPDATE LOC_MST SET LOCSTS='O',OLDSTS='" + LocSts + "' WHERE LOCSTS='" + LocSts + "' AND LOC='" + FromLoc_L + "'";
                            if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                            {
                                strSQL = "UPDATE LOC_MST SET LOCSTS='I',OLDSTS='N' WHERE LOCSTS='N' AND LOC='" + ToLoc_L + "'";
                                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                {
                                    strSQL = "INSERT INTO CMD_MST (CMDSNO, SNO, CMDSTS, PRT, CMDMODE, IOTYP, LOC, NEWLOC, TRNDATE, ACTTIME,";
                                    strSQL += " PROGID, LOCID, TRACE, STNNO) VALUES ('" + strCmdSno + "', '2', '0', '5', '5', '" + strIOType + "',";
                                    strSQL += " '" + FromLoc_R + "', '" + ToLoc_R + "', '" + DateTime.Now.ToString("yyyy/MM/dd") + "',";
                                    strSQL += " '" + DateTime.Now.ToString("HH:mm:ss") + "', 'MainControl', '" + strLocID_R + "', '0','')";
                                    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                    {
                                        strSQL = "UPDATE LOC_MST SET LOCSTS='O',OLDSTS='" + LocSts + "' WHERE LOCSTS='" + LocSts + "' AND LOC='" + FromLoc_R + "'";
                                        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                        {
                                            strSQL = "UPDATE LOC_MST SET LOCSTS='I',OLDSTS='N' WHERE LOCSTS='N' AND LOC='" + ToLoc_R + "'";
                                            if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                            {
                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "Create Loc To Loc Command Success!";
                                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                                SystemTraceLog.LocID = FromLoc_R;
                                                SystemTraceLog.NewLocID = ToLoc_R;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                            else
                                            {
                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                                SystemTraceLog.LocID = FromLoc_R;
                                                SystemTraceLog.NewLocID = ToLoc_R;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                        }
                                        else
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                            SystemTraceLog.LocID = FromLoc_R;
                                            SystemTraceLog.NewLocID = ToLoc_R;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    else
                                    {
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Create Command Fail!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.SNO = "2";
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                        SystemTraceLog.LocID = FromLoc_L;
                                        SystemTraceLog.NewLocID = ToLoc_L;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                }
                                else
                                {
                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                    SystemTraceLog.LeftCmdSno = strCmdSno;
                                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                    SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                    SystemTraceLog.LocID = FromLoc_L;
                                    SystemTraceLog.NewLocID = ToLoc_L;
                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                }
                            }
                            else
                            {
                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                SystemTraceLog.LocID = FromLoc_L;
                                SystemTraceLog.NewLocID = ToLoc_L;
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            }
                        }
                        else
                        {
                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            SystemTraceLog.LogMessage = "Create Command Fail!";
                            SystemTraceLog.LeftCmdSno = strCmdSno;
                            SystemTraceLog.SNO = "1";
                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                            SystemTraceLog.LocID = FromLoc_L;
                            SystemTraceLog.NewLocID = ToLoc_L;
                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                        }
                    }
                    
                    #endregion
                }
                else
                {
                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                    SystemTraceLog.LogMessage = "Create Command Fail!";
                    SystemTraceLog.LeftCmdSno = "Can't Get Cmd Sno!";
                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                }
            
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

        /// <summary>
        /// 產生庫對庫命令
        /// </summary>
        /// <param name="Source">來源</param>
        /// <param name="Destination">目的</param>
        /// <param name="IOType">作業業別</param>
        /// <param name="Prt">優先權</param>
        /// <param name="InsideLoc"></param>
        /// <param name="OldInsideLocSts"></param>
        /// <param name="NewInsideLocSts"></param>
        private void funInsertLocToLocCmd(
            string Source, string Destination, string IOType, string Prt, string InsideLoc, string OldInsideLocSts, string NewInsideLocSts)
        {
            DataTable objDataTable = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strLocID = string.Empty;
            string strLocSts = string.Empty;
            string strCmdSno = string.Empty;

            try
            {
                string strRow_FromLoc = Source.Substring(0, 2);
                string strRow_ToLoc = Destination.Substring(0, 2);
                int intRow_FromLoc = (int.Parse(strRow_FromLoc) + 3) / 4;
                int intRow_ToLoc = (int.Parse(strRow_ToLoc) + 3) / 4;
                if(intRow_FromLoc != intRow_ToLoc)
                    return;

                if(string.IsNullOrWhiteSpace(Prt))
                    Prt = "5";

                strSQL = "SELECT LOCID,LOCSTS FROM LOC_MST WHERE LOC='" + Source + "'";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    strLocID = objDataTable.Rows[0]["LOCID"].ToString();
                    strLocSts = objDataTable.Rows[0]["LOCSTS"].ToString();
                    strCmdSno = funGetCmdSno();

                    if(!string.IsNullOrWhiteSpace(strCmdSno))
                    {
                        strSQL = "INSERT INTO CMD_MST (CMDSNO, SNO, CMDSTS, PRT, CMDMODE, IOTYP, LOC, NEWLOC, TRNDATE, ACTTIME, PROGID, LOCID, TRACE, STNNO) VALUES";
                        strSQL += " ('" + strCmdSno + "', '1', '0', '" + Prt + "', '5', '" + IOType + "',";
                        strSQL += " '" + Source + "', '" + Destination + "', '" + DateTime.Now.ToString("yyyy/MM/dd") + "',";
                        strSQL += " '" + DateTime.Now.ToString("HH:mm:ss") + "', 'MainControl', '" + strLocID + "', '0','')";
                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
                        if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                        {
                            strSQL = "UPDATE LOC_MST SET LOCSTS='O',OLDSTS='" + strLocSts + "' WHERE LOCSTS IN ('S','E','H') AND LOC='" + Source + "'";
                            if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                            {
                                strSQL = "UPDATE LOC_MST SET LOCSTS='I',OLDSTS='N' WHERE LOCSTS='N' AND LOC='" + Destination + "'";
                                if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                {
                                    if(!string.IsNullOrWhiteSpace(InsideLoc) &&
                                        !string.IsNullOrWhiteSpace(NewInsideLocSts) &&
                                        !string.IsNullOrWhiteSpace(OldInsideLocSts))
                                    {
                                        strSQL = "UPDATE LOC_MST SET LOCSTS='" + NewInsideLocSts + "'";
                                        strSQL += " WHERE LOCSTS='" + OldInsideLocSts + "' AND LOC='" + InsideLoc + "'";
                                        if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Create Loc To Loc Command Success!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                            SystemTraceLog.LocID = Source;
                                            SystemTraceLog.NewLocID = Destination;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                        else
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                            SystemTraceLog.LocID = InsideLoc;
                                            SystemTraceLog.LocSts = NewInsideLocSts;
                                            SystemTraceLog.OldLocSts = OldInsideLocSts;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    else
                                    {
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Create Loc To Loc Command Success!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                        SystemTraceLog.LocID = Source;
                                        SystemTraceLog.NewLocID = Destination;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                }
                                else
                                {
                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                    SystemTraceLog.LeftCmdSno = strCmdSno;
                                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                    SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                    SystemTraceLog.LocID = Source;
                                    SystemTraceLog.NewLocID = Destination;
                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                }
                            }
                            else
                            {
                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                SystemTraceLog.LocID = Source;
                                SystemTraceLog.NewLocID = Destination;
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            }
                        }
                        else
                        {
                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            SystemTraceLog.LogMessage = "Create Loc To Loc Command Fail!";
                            SystemTraceLog.LeftCmdSno = strCmdSno;
                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                            SystemTraceLog.LocID = Source;
                            SystemTraceLog.NewLocID = Destination;
                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                        }
                    }
                    else
                    {
                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        SystemTraceLog.LogMessage = "Create Loc To Loc Command Fail!";
                        SystemTraceLog.LeftCmdSno = "Can't Get Cmd Sno!";
                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                    }
                }
            }
            catch(Exception ex)
            {
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
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }

        /// <summary>
        /// 產生庫對庫命令
        /// </summary>
        /// <param name="Source">來源</param>
        /// <param name="Destination">目的</param>
        /// <param name="IOType">作業業別</param>
        /// <param name="Prt">優先權</param>
        /// <param name="InsideLoc"></param>
        /// <param name="OldLocSts"></param>
        /// <param name="NewLocSts"></param>
        /// <param name="ToInsideLoc"></param>
        /// <param name="OldToInsideLocSts"></param>
        /// <param name="NewToInsideLocSts"></param>
        private void funInsertLocToLocEquCmd(
            string Source, string Destination, string IOType, string Prt,
            string InsideLoc, string ToInsideLoc, string OldLocSts, string NewLocSts)
        {
            DataTable objDataTable = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strLocID = string.Empty;
            string strLocSts = string.Empty;
            string strCmdSno = string.Empty;

            try
            {
                string strRow_FromLoc = Source.Substring(0, 2);
                string strRow_ToLoc = Destination.Substring(0, 2);
                int intRow_FromLoc = (int.Parse(strRow_FromLoc) + 3) / 4;
                int intRow_ToLoc = (int.Parse(strRow_ToLoc) + 3) / 4;
                if(intRow_FromLoc != intRow_ToLoc)
                    return;

                if(string.IsNullOrWhiteSpace(Prt))
                    Prt = "5";

                strSQL = "SELECT LOCID,LOCSTS FROM LOC_MST WHERE LOC='" + Source + "'";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    strLocID = objDataTable.Rows[0]["LOCID"].ToString();
                    strLocSts = objDataTable.Rows[0]["LOCSTS"].ToString();
                    strCmdSno = funGetCmdSno();

                    if(!string.IsNullOrWhiteSpace(strCmdSno))
                    {
                        strSQL = "INSERT INTO CMD_MST (CMDSNO, SNO, CMDSTS, PRT, CMDMODE, IOTYP, LOC, NEWLOC, TRNDATE, ACTTIME, PROGID, LOCID, TRACE, STNNO) VALUES";
                        strSQL += " ('" + strCmdSno + "', '1', '0', '" + Prt + "', '5', '" + IOType + "',";
                        strSQL += " '" + Source + "', '" + Destination + "', '" + DateTime.Now.ToString("yyyy/MM/dd") + "',";
                        strSQL += " '" + DateTime.Now.ToString("HH:mm:ss") + "', 'MainControl', '" + strLocID + "', '0','')";
                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
                        if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                        {
                            strSQL = "UPDATE LOC_MST SET LOCSTS='O',OLDSTS='" + strLocSts + "' WHERE LOCSTS IN ('S','E','H') AND LOC='" + Source + "'";
                            if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                            {
                                strSQL = "UPDATE LOC_MST SET LOCSTS='I',OLDSTS='N' WHERE LOCSTS='N' AND LOC='" + Destination + "'";
                                if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                {
                                    if(!string.IsNullOrWhiteSpace(InsideLoc) && !string.IsNullOrWhiteSpace(NewLocSts) &&
                                        !string.IsNullOrWhiteSpace(OldLocSts) && !string.IsNullOrWhiteSpace(ToInsideLoc))
                                    {
                                        strSQL = "UPDATE LOC_MST SET LOCSTS='" + NewLocSts + "'";
                                        strSQL += " WHERE LOCSTS='" + OldLocSts + "'";
                                        strSQL += " AND LOC IN ('" + InsideLoc + "', '" + ToInsideLoc + "')";
                                        if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Create Command Success!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                            SystemTraceLog.LocID = Source;
                                            SystemTraceLog.NewLocID = Destination;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                        else
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                            SystemTraceLog.LocID = InsideLoc + ">, <" + ToInsideLoc;
                                            SystemTraceLog.LocSts = NewLocSts;
                                            SystemTraceLog.OldLocSts = OldLocSts;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    else
                                    {
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Create Command Success!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                        SystemTraceLog.LocID = Source;
                                        SystemTraceLog.NewLocID = Destination;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                }
                                else
                                {
                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                    SystemTraceLog.LeftCmdSno = strCmdSno;
                                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                    SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                    SystemTraceLog.LocID = Source;
                                    SystemTraceLog.NewLocID = Destination;
                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                }
                            }
                            else
                            {
                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Reserve Loc Fail!";
                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                                SystemTraceLog.LocID = Source;
                                SystemTraceLog.NewLocID = Destination;
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            }
                        }
                        else
                        {
                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            SystemTraceLog.LogMessage = "Create Command Fail!";
                            SystemTraceLog.LeftCmdSno = strCmdSno;
                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrLocToLoc;
                            SystemTraceLog.LocID = Source;
                            SystemTraceLog.NewLocID = Destination;
                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                        }
                    }
                    else
                    {
                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        SystemTraceLog.LogMessage = "Create Command Fail!";
                        SystemTraceLog.LeftCmdSno = "Can't Get Cmd Sno!";
                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                    }
                }
            }
            catch(Exception ex)
            {
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
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }

        


        /// <summary>
        /// 取得命令序號(21000~29997 為WCS自行產生的---ex:出庫時需庫對庫)
        /// </summary>
        /// <returns></returns>
        private string funGetCmdSno()
        {
            int intGetCnt = 0;
            long lngSeq1 = 0;
            long lngSeq2 = 0;
            string strSql = string.Empty;
            string strEM = string.Empty;
            string strMonthFlag = string.Empty;     //月異動 Y/N
            int intSnoLen = 0;                      //Sno_Len 序號長度


            string strSQL = string.Empty;
            string strCmdSno = string.Empty;
            string strNewCmdSno = string.Empty;
            DataTable dtTmp = new DataTable();
            try
            {
            ProNext:
                
                strSql = "SELECT C.SNO_TYPE,C.TRN_MONTH,C.SNO,M.MONTH_FLAG,M.INIT_SNO,M.MAX_SNO,M.SNO_LEN";
                strSql += " FROM SNO_CTL C,SNO_MAX M WHERE C.SNO_TYPE=M.SNO_TYPE(+)";
                strSql += " AND C.SNO_TYPE='CMDSNO'";
                string strGetYearMonth = DateTime.Now.ToString("yyMM");
                int intRtn = clsSystem.gobjDB.funGetDT(strSql, ref dtTmp, ref strEM);
                if (intRtn == ErrDef.ProcSuccess)
                {
                    lngSeq2 = int.Parse(dtTmp.Rows[0]["SNO"].ToString());
                    strMonthFlag = dtTmp.Rows[0]["MONTH_FLAG"].ToString();
                    intSnoLen = int.Parse(dtTmp.Rows[0]["SNO_LEN"].ToString());

                    if (lngSeq2 >= int.Parse(dtTmp.Rows[0]["MAX_SNO"].ToString()))
                    {
                        lngSeq1 = int.Parse(dtTmp.Rows[0]["INIT_SNO"].ToString());
                    }
                    else
                    {
                        lngSeq1 = lngSeq2 + 1;
                    }

                    strSql = "UPDATE SNO_CTL SET SNO = " + lngSeq1;
                    if (strMonthFlag == "Y")
                    {
                        strSql += ",TRN_MONTH = '" + strGetYearMonth + "'";
                    }
                    strSql += " WHERE SNO_TYPE = 'CMDSNO'";
                    strSql += " AND SNO = " + lngSeq2;
                }
                else if (intRtn == 110002)      //No Data Selected
                {
                    if (strMonthFlag == "Y")
                    {
                        strSql = "INSERT INTO SNO_CTL (SNO_TYPE,TRN_MONTH,SNO) VALUES ('CMDSNO','" + strGetYearMonth + "',1)";
                    }
                    else
                    {
                        strSql = "INSERT INTO SNO_CTL (SNO_TYPE,TRN_MONTH,SNO) VALUES ('CMDSNO','" + DateTime.Now.ToString("yyMM") + "',1)";
                    }
                    intSnoLen = 5;
                    lngSeq1 = 1;
                }
                else
                {
                    return "";
                }

                if (clsSystem.gobjDB.funExecSql(strSql, ref strEM) != ErrDef.ProcSuccess)
                {
                    //讀取Count
                    if (intGetCnt >= 5)
                    {
                        return "";
                    }
                    else
                    {
                        goto ProNext;
                    }
                }
                return lngSeq1.ToString().PadLeft(intSnoLen, '0');
                


            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// 取得命令序號(WCS自動產生---ex:空棧板入庫用)
        /// </summary>
        /// <returns></returns>
        private string funGetEmptyPltCmdSno()
        {
            int intGetCnt = 0;
            long lngSeq1 = 0;
            long lngSeq2 = 0;
            string strSql = string.Empty;
            string strEM = string.Empty;
            string strMonthFlag = string.Empty;     //月異動 Y/N
            int intSnoLen = 0;                      //Sno_Len 序號長度


            string strSQL = string.Empty;
            string strCmdSno = string.Empty;
            string strNewCmdSno = string.Empty;
            DataTable dtTmp = new DataTable();
            try
            {
            ProNext:

                strSql = "SELECT C.SNO_TYPE,C.TRN_MONTH,C.SNO,M.MONTH_FLAG,M.INIT_SNO,M.MAX_SNO,M.SNO_LEN";
                strSql += " FROM SNO_CTL C,SNO_MAX M WHERE C.SNO_TYPE=M.SNO_TYPE";
                strSql += " AND C.SNO_TYPE='CMDSNO'";
                string strGetYearMonth = DateTime.Now.ToString("yyMM");
                int intRtn = clsSystem.gobjDB.funGetDT(strSql, ref dtTmp, ref strEM);
                if (intRtn == ErrDef.ProcSuccess)
                {
                    lngSeq2 = int.Parse(dtTmp.Rows[0]["SNO"].ToString());
                    strMonthFlag = dtTmp.Rows[0]["MONTH_FLAG"].ToString();
                    intSnoLen = int.Parse(dtTmp.Rows[0]["SNO_LEN"].ToString());

                    if (lngSeq2 >= int.Parse(dtTmp.Rows[0]["MAX_SNO"].ToString()))
                    {
                        lngSeq1 = int.Parse(dtTmp.Rows[0]["INIT_SNO"].ToString());
                    }
                    else
                    {
                        lngSeq1 = lngSeq2 + 1;
                    }

                    strSql = "UPDATE SNO_CTL SET SNO = " + lngSeq1;
                    if (strMonthFlag == "Y")
                    {
                        strSql += ",TRN_MONTH = '" + strGetYearMonth + "'";
                    }
                    strSql += " WHERE SNO_TYPE = 'CMDSNO'";
                    strSql += " AND SNO = " + lngSeq2;
                }
                else if (intRtn == 110002)      //No Data Selected
                {
                    if (strMonthFlag == "Y")
                    {
                        strSql = "INSERT INTO SNO_CTL (SNO_TYPE,TRN_MONTH,SNO) VALUES ('CMDSNO_WCS','" + strGetYearMonth + "',1)";
                    }
                    else
                    {
                        strSql = "INSERT INTO SNO_CTL (SNO_TYPE,TRN_MONTH,SNO) VALUES ('CMDSNO_WCS','" + DateTime.Now.ToString("yyMM") + "',1)";
                    }
                    intSnoLen = 5;
                    lngSeq1 = 1;
                }
                else
                {
                    return "";
                }

                if (clsSystem.gobjDB.funExecSql(strSql, ref strEM) != ErrDef.ProcSuccess)
                {
                    //讀取Count
                    if (intGetCnt >= 5)
                    {
                        return "";
                    }
                    else
                    {
                        goto ProNext;
                    }
                }
                return lngSeq1.ToString().PadLeft(intSnoLen, '0');



            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// 取得CMD_DTL命令序號(WCS自動產生---ex:空棧板入庫用)
        /// </summary>
        /// <returns></returns>
        private string funGetEmptyPltLocTXNO()
        {
            int intGetCnt = 0;
            long lngSeq1 = 0;
            long lngSeq2 = 0;
            string strSql = string.Empty;
            string strEM = string.Empty;
            string strMonthFlag = string.Empty;     //月異動 Y/N
            int intSnoLen = 0;                      //Sno_Len 序號長度

            DataTable dtSno = new DataTable();
            int intRtn;

            try
            {

            ProNext:

                intGetCnt = intGetCnt + 1;

                strSql = "SELECT C.SNO_TYPE,C.TRN_MONTH,C.SNO,M.MONTH_FLAG,M.INIT_SNO,M.MAX_SNO,M.SNO_LEN";
                strSql += " FROM SNO_CTL C LEFT JOIN SNO_MAX M ON C.SNO_TYPE=M.SNO_TYPE";
                strSql += " WHERE C.SNO_TYPE='LOCTXNO'";
                string strGetYearMonth = DateTime.Now.ToString("yyMM");
                
                intRtn = clsSystem.gobjDB.funGetDT(strSql, ref dtSno, ref strEM);
                if (intRtn == ErrDef.ProcSuccess)
                {
                    lngSeq2 = int.Parse(dtSno.Rows[0]["SNO"].ToString());
                    strMonthFlag = dtSno.Rows[0]["MONTH_FLAG"].ToString();
                    intSnoLen = int.Parse(dtSno.Rows[0]["SNO_LEN"].ToString());

                    if (lngSeq2 >= int.Parse(dtSno.Rows[0]["MAX_SNO"].ToString()))
                    {
                        lngSeq1 = int.Parse(dtSno.Rows[0]["INIT_SNO"].ToString());
                    }
                    else
                    {
                        lngSeq1 = lngSeq2 + 1;
                    }

                    strSql = "UPDATE SNO_CTL SET SNO = " + lngSeq1;
                    if (strMonthFlag == "Y")
                    {
                        strSql += ",TRN_MONTH = '" + strGetYearMonth + "'";
                    }
                    strSql += " WHERE SNO_TYPE = 'LOCTXNO'";
                    strSql += " AND SNO = " + lngSeq2;
                }
                else if (intRtn == 110002)      //No Data Selected
                {
                    if (strMonthFlag == "Y")
                    {
                        strSql = "INSERT INTO SNO_CTL (SNO_TYPE,TRN_MONTH,SNO) VALUES ('LOCTXNO','" + strGetYearMonth + "',1)";
                    }
                    else
                    {
                        strSql = "INSERT INTO SNO_CTL (SNO_TYPE,TRN_MONTH,SNO) VALUES ('LOCTXNO','" + DateTime.Now.ToString("yyMM") + "',1)";
                    }
                    intSnoLen = 5;
                    lngSeq1 = 1;
                }
                else
                {
                    return "";
                }

                if (clsSystem.gobjDB.funExecSql(strSql, ref strEM) != ErrDef.ProcSuccess)
                {
                    //讀取Count
                    if (intGetCnt >= 5)
                    {
                        return "";
                    }
                    else
                    {
                        goto ProNext;
                    }
                }
                return DateTime.Now.ToString("yyyyMMdd") + lngSeq1.ToString().PadLeft(intSnoLen, '0');
                 
            }
            catch (Exception ex)
            {
                //var cmet = System.Reflection.MethodBase.GetCurrentMethod();
                //clsInitSys.subWriteExLog(cmet.DeclaringType.FullName + "." + cmet.Name, ex.Message);
                return string.Empty;
            }
            finally
            {
                dtSno.Dispose();
            }
        }

        /// <summary>
        /// 檢查是否有執行中命令；有執行中命令傳回true，否則傳回false
        /// </summary>
        /// <param name="CraneNo"></param>
        /// <param name="CmdSno"></param>
        /// <param name="CmdMode"></param>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        /// <param name="Prt"></param>
        /// <returns></returns>
        private bool funCheckExecutionEquCmd(int CraneNo, string CmdSno, string CmdMode, string Source, string Destination, string Prt)
        {
            if(CraneNo == 0 ||
                string.IsNullOrWhiteSpace(CmdSno) ||
                string.IsNullOrWhiteSpace(CmdMode) ||
                string.IsNullOrWhiteSpace(Source) ||
                string.IsNullOrWhiteSpace(Destination))
                return false;

            DataTable objDataTable = new DataTable();
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                strSQL = "SELECT * FROM EQUCMD WHERE CMDSNO='" + CmdSno + "'";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    string strCmdSts = objDataTable.Rows[0]["CMDSTS"].ToString();
                    if(strCmdSts == clsCmdSts.cstrCmdSts_Init || strCmdSts == clsCmdSts.cstrCmdSts_Start)
                        return true;
                }

                bool bolFlag = true;
                switch(CmdMode)
                {
                    case clsEquCmdMode.cstrInMode:
                        Source = funGetEquCraneStandardLocByStn(Source);
                        bolFlag = funCheckExecutionEquCmdByCrane(CraneNo, CmdSno, CmdMode, Source, Destination);
                        break;
                    case clsEquCmdMode.cstrOutMode:
                        Destination = funGetEquCraneStandardLocByStn(Destination);
                        bolFlag = funCheckExecutionEquCmdByCrane(CraneNo, CmdSno, CmdMode, Source, Destination);
                        break;
                    case clsEquCmdMode.cstrLocToLoc:
                        Source = funGetEquCraneStandardLocByStn(Source);
                        Destination = funGetEquCraneStandardLocByStn(Destination);

                        if(bolFlag)
                            bolFlag = funCheckExecutionEquCmdByCrane(CraneNo, CmdSno, clsEquCmdMode.cstrInMode, Source, Destination);
                        if(bolFlag)
                            bolFlag = funCheckExecutionEquCmdByCrane(CraneNo, CmdSno, clsEquCmdMode.cstrOutMode, Source, Destination);
                        break;
                    case clsEquCmdMode.cstrStnToStn:
                        strSQL = "SELECT COUNT(*) AS CNT FROM EQUCMD WHERE CMDMODE='5' AND CMDSTS IN ('0', '1') AND EQUNO='" + CraneNo + "'";
                        if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                        {
                            int intCount = int.Parse(objDataTable.Rows[0]["CNT"].ToString());
                            if(intCount > 0)
                                return false;
                            else
                                return true;
                        }
                        break;
                }
                return bolFlag;
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
            finally
            {
                if(objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
            }
        }

        /// <summary>
        /// 檢查Crane是否有命令；有命令傳回true，否則傳回false
        /// </summary>
        /// <param name="CraneNo"></param>
        /// <param name="CmdSno"></param>
        /// <param name="CmdMode"></param>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        /// <returns></returns>
        private bool funCheckExecutionEquCmdByCrane(int CraneNo, string CmdSno, string CmdMode, string Source, string Destination)
        {
            DataTable objDataTable = new DataTable();
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                if(CmdMode == clsEquCmdMode.cstrInMode)
                {
                    strSQL = "SELECT * FROM EQUCMD WHERE EQUNO='" + CraneNo + "' AND CMDMODE IN ('1', '4') ";
                    strSQL += "AND SOURCE='" + Source + "'";
                }
                else if(CmdMode == clsEquCmdMode.cstrOutMode)
                {
                    strSQL = "SELECT * FROM EQUCMD WHERE EQUNO='" + CraneNo + "' AND CMDMODE IN ('2', '4') ";
                    strSQL += "AND DESTINATION='" + Destination + "'";
                }
                else
                    return false;

                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    for(int intCount = 0; intCount < objDataTable.Rows.Count; intCount++)
                    {
                        switch(objDataTable.Rows[intCount]["CMDSTS"].ToString())
                        {
                            case "0":
                                return false;
                            case "1":
                                if(string.IsNullOrWhiteSpace(objDataTable.Rows[intCount]["COMPLETECODE"].ToString()))
                                    return false;
                                break;
                            default:
                                break;
                        }
                    }
                }

                return false;
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
            finally
            {
                if(objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
            }
        }

        /// <summary>
        /// 將站口編號轉成儲位編號
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        private string funGetEquCraneStandardLocByStn(string Data)
        {
            string strStn = string.Empty;
            int iStn = clsTool.funConvertToInt(Data) % 2;
            int iLevel = (clsTool.funConvertToInt(Data)) / 22;
            int iLevel_re = (clsTool.funConvertToInt(Data)) % 22;
            if (iLevel_re == 0)
            {
                iLevel = iLevel - 1;
            }
            
            
            if (iStn == 0) iStn = 2;
            else if (iStn == 1) iStn = 1;
            strStn = (iStn + iLevel * 2).ToString();
            //switch (iStn)
            //{
            //    case 0:
            //        strStn = "2";
            //        break;
            //    case 1:
            //        strStn = "1";
            //        break;
            //}

            return strStn.PadLeft(7, '0');
        }

        private string funGetEquCraneStandardLoc(string Data)
        {
            int intRow = 0;
            int intTmp = 0;
            string strLoc = Data;

            if (Data.Length == 6)
                intRow = int.Parse(strLoc.Substring(0, 1));
            else
                intRow = int.Parse(strLoc.Substring(0, 2));

            intTmp = intRow % 2;
            switch(intTmp)
            {
                // 暫時修改成單儲位 By Leon 
                case 0:
                    return "02" + strLoc.Substring(2);
                case 1:
                    return "01" + strLoc.Substring(2);
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 檢查是否為外儲位，並檢查內儲位是否為空儲位；
        /// 若為內儲位回傳true；
        /// 若為外儲位時且內儲位為空儲位，更新空儲位狀態為L並回傳true；
        /// 若為外儲位時且內儲位為庫存儲位，則回傳false
        /// </summary>
        /// <param name="Loc"></param>
        /// <returns></returns>
        private bool funCheckInsideLocIsEmpty(string Loc,string Prty,ref bool bolOutReserved)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strInsideLoc = string.Empty;
            DataTable objDataTable = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);

            try
            {
                if(Loc.Substring(0, 2) == "01" || Loc.Substring(0, 2) == "02" ||
                    Loc.Substring(0, 2) == "05" || Loc.Substring(0, 2) == "06" ||
                    Loc.Substring(0, 2) == "09" || Loc.Substring(0, 2) == "10")
                    return true;
                else if(Loc.Substring(0, 2) == "03" || Loc.Substring(0, 2) == "04")
                {
                    if(Loc.Substring(0, 2) == "03")
                    {
                        strInsideLoc = "01"+Loc.Substring(2,5);
                    }
                    else
                    {
                        strInsideLoc = "02"+Loc.Substring(2,5);
                    }
                }
                    //strInsideLoc = Loc.Replace(Loc.Substring(0, 2), Loc.Substring(0, 2) == "03" ? "01" : "02");
                else if(Loc.Substring(0, 2) == "07" || Loc.Substring(0, 2) == "08")
                {
                     if(Loc.Substring(0, 2) == "07")
                    {
                        strInsideLoc = "05"+Loc.Substring(2,5);
                    }
                    else
                    {
                        strInsideLoc = "06"+Loc.Substring(2,5);
                    }
                }

                else if (Loc.Substring(0, 2) == "11" || Loc.Substring(0, 2) == "12")
                {
                    if (Loc.Substring(0, 2) == "11")
                    {
                        strInsideLoc = "09" + Loc.Substring(2, 5);
                    }
                    else
                    {
                        strInsideLoc = "10" + Loc.Substring(2, 5);
                    }
                }

                strSQL = "SELECT LOC_STS FROM LOC_MST WHERE LOC='" + strInsideLoc + "'";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    switch(objDataTable.Rows[0]["LOC_STS"].ToString())
                    {
                        case clsLocSts.cstrEmpty:
                            bolOutReserved = false;
                            strSQL = "UPDATE LOC_MST SET LOC_STS='L', OLD_STS='N' WHERE LOC_STS='N' AND LOC='" + strInsideLoc + "'";
                            if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                            {
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Update LocSts Success!";
                                SystemTraceLog.LocID = strInsideLoc;
                                SystemTraceLog.LocSts = clsLocSts.cstrEmpty;
                                SystemTraceLog.OldLocSts = clsLocSts.cstrRevisionReserved;
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                return true;
                            }
                            else
                            {
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Update LocSts Fail!";
                                SystemTraceLog.LocID = strInsideLoc;
                                SystemTraceLog.LocSts = clsLocSts.cstrEmpty;
                                SystemTraceLog.OldLocSts = clsLocSts.cstrRevisionReserved;
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                return false;
                            }
                        case clsLocSts.cstrRevisionReserved:    // cstrRevisionReserved = "L";
                            bolOutReserved = false;
                            return true;
                        case clsLocSts.cstrStorageOutReserved: //cstrStorageOutReserved = "O";
                            //v1.0.1.4 修改內儲位命令優先權
                            //v1.0.1.7 應包含  cmd_mode in ('2','3')  
                            //v1.0.1.7  strSQL = "Update Cmd_Mst Set Prty=" + (clsTool.funConvertToInt(Prty) - 1) + " Where Cmd_Sts<='3' and Loc='" + strInsideLoc+"' AND CMD_Mode ='2' ";
                            strSQL = "Update Cmd_Mst Set Prty=" + (clsTool.funConvertToInt(Prty) - 1) + " Where Cmd_Sno<>'' and Cmd_Sts<='3' and Loc='" + strInsideLoc + "' AND CMD_Mode in ('2','3') ";
                            if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                            {
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Update Cmd_Mst Prty='" + (clsTool.funConvertToInt(Prty) - 1) + "' Success!";
                                SystemTraceLog.LocID = strInsideLoc;
                                
                                SystemTraceLog.OldLocSts = clsLocSts.cstrRevisionReserved;
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            }
                            bolOutReserved = true;
                            return false;
                        default:
                            bolOutReserved = false;
                            return false;
                    }
                }
                else
                    return true;
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return false;
            }
            finally
            {
                if(objDataTable != null)
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

        /// <summary>
        /// 將內儲位進行庫對庫作業
        /// </summary>
        /// <param name="CraneNo"></param>
        /// <param name="OutsideLoc"></param>
        /// <param name="CmdSno"></param>
        private void funMoveInsideLoc(int CraneNo, string OutsideLoc, string CmdSno)
        {
            if(OutsideLoc.Substring(0, 2) == "01" || OutsideLoc.Substring(0, 2) == "02" ||
                OutsideLoc.Substring(0, 2) == "05" || OutsideLoc.Substring(0, 2) == "06" ||
                OutsideLoc.Substring(0, 2) == "09" || OutsideLoc.Substring(0, 2) == "10")
                return;

            if(!funCheckLocMatchCrane(OutsideLoc, CraneNo, CmdSno))
                return;
            
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strNewLoc = string.Empty;
            string strIOType = string.Empty;
            string strInsideLoc = string.Empty;
            int intCraneRow = 0;
            DataTable objDataTable = new DataTable();

            try
            {
                intCraneRow = funGetCraneRow(OutsideLoc);

                strInsideLoc = funGetInsideLoc(intCraneRow, OutsideLoc);

                strSQL = "SELECT LOC_STS,Loc_Size FROM LOC_MST WHERE LOC='" + strInsideLoc + "'";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    string strLocSts = objDataTable.Rows[0]["LOC_STS"].ToString();
                    string strLocSize = objDataTable.Rows[0]["LOC_Size"].ToString();
                    if(strLocSts == clsLocSts.cstrEmptyStored)     // cstrEmptyStored = "E";
                    {
                        strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_ENNE, false, true, strLocSize,ref strSQL);
                        if(string.IsNullOrWhiteSpace(strNewLoc))
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_NNNN, false, true, strLocSize, ref strSQL); 
                        if (string.IsNullOrWhiteSpace(strNewLoc))   //v1.0.2.0
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_XNNX, false, true, strLocSize, ref strSQL); 
                        if(string.IsNullOrWhiteSpace(strNewLoc))
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_ENNE, true, true, strLocSize, ref strSQL);
                        if(string.IsNullOrWhiteSpace(strNewLoc))
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_NNNN, true, true, strLocSize, ref strSQL);
                        if (string.IsNullOrWhiteSpace(strNewLoc))  //v1.0.1.9    Julia  找儲位條件,找 HNNH. (柱位的儲位,內儲位也要可以被找到)
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_HNNH, true, true, strLocSize, ref strSQL);

                        strIOType = clsIOType.cstrRtoR;
                    }
                    else if(strLocSts == clsLocSts.cstrStored)   //cstrStored = "S";
                    {                  
                        strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_SNNS, false, true, strLocSize, ref strSQL);
                        if(string.IsNullOrWhiteSpace(strNewLoc))
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_NNNN, false, true, strLocSize, ref strSQL);
                        if (string.IsNullOrWhiteSpace(strNewLoc))   //v1.0.2.0
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_XNNX, false, true, strLocSize, ref strSQL); 
                        if(string.IsNullOrWhiteSpace(strNewLoc))
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_SNNS, true, true, strLocSize, ref strSQL);
                        if(string.IsNullOrWhiteSpace(strNewLoc))
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_NNNN, true, true, strLocSize, ref strSQL);
                        if(string.IsNullOrWhiteSpace(strNewLoc))  //v1.0.1.8    Julia  找儲位條件,找 HNNH. (柱位的儲位,內儲位也要可以被找到)
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_HNNH, true, true, strLocSize, ref strSQL);

                        strIOType = clsIOType.cstrRtoR;
                    }
                    else if (strLocSts == clsLocSts.cstrRevision)   //cstrRevision = "H";
                    {
                        strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_HNNH, true, true, strLocSize, ref strSQL);
                        if(string.IsNullOrWhiteSpace(strNewLoc))
                            strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_NNNN, true, true, strLocSize, ref strSQL);
                        strIOType = clsIOType.cstrRtoR;
                    }

                    if (strInsideLoc != OutsideLoc && !string.IsNullOrWhiteSpace(strNewLoc) && !string.IsNullOrWhiteSpace(strIOType))
                    {
                        funInsertLocToLocCmd(strInsideLoc, strNewLoc, strIOType, "4");
                    }
                        //funInsertLocToLocCmd(strInsideLoc, strNewLoc, strIOType, "4");
                }
            }
            catch(Exception ex)
            {
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
            }
        }

        /// <summary>
        /// 取得外儲位對應之內儲位
        /// </summary>
        /// <param name="CraneRow"></param>
        /// <param name="OutsideLoc"></param>
        /// <returns></returns>
        private string funGetInsideLoc(int CraneRow, string OutsideLoc)
        {
            switch(CraneRow)
            {
                default:
                case 2:
                case 1:
                    return OutsideLoc;
                case 3:
                case 4:
                    return (clsTool.funConvertToInt(OutsideLoc.Substring(0, 2)) - 2).ToString().PadLeft(2, '0') + OutsideLoc.Substring(2);
            }
        }

        /// <summary>
        /// 尋找空儲位
        /// </summary>
        /// <param name="CraneNo">Crane 編號</param>
        /// <param name="CraneRow">Crane的左右側編號</param>
        /// <param name="LocSts">儲位狀態</param>
        /// <param name="NeedTempLoc">是否為暫存儲位</param>
        /// <param name="NeedRow">是否參考CraneRow</param>
        /// <param name="LocSize">是否參考LocSize</param>
        /// <returns></returns>
        ///     strNewLoc = funGetEmptyLoc(CraneNo, intCraneRow, clsLocSts.cstrLoc_HNNH, true, true, strLocSize, ref strSQL);
        private string funGetEmptyLoc(int CraneNo, int CraneRow, string LocSts, bool NeedTempLoc, bool NeedRow,string LocSize,ref string  strSql)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strNewLoc = string.Empty;
            DataTable dtTmp = new DataTable();
            try
            {

                //2019 v1.0.2.0 Julia


                ////For 大立光 Oracle
                //strSQL = "SELECT LOC FROM (";
                //strSQL += "SELECT LOC FROM LOC_MST WHERE LOC_STS = 'N' AND EQU_NO ='" + CraneNo + "' "; 
                //if (NeedRow)
                //{
                //    if (CraneRow == 1 || CraneRow == 3)
                //        strSQL += " AND Equ_RowNo IN (1, 3)";                    
                //    else
                //        strSQL += " AND Equ_RowNo IN (1, 2)";  //V1.0.2.0 Julia Modify , 因為左列有N, 右列無法庫對庫.修改這個bug.   equ_no 設定, 1,2 
                //        //strSQL += " AND Equ_RowNo IN (2, 4)";  //V1.0.2.0 Julia Mark
                //}
                //if (LocSts == clsLocSts.cstrLoc_NNNN)
                //    strSQL += " AND LOC IN (SELECT Loc_DD FROM LOC_MST WHERE LOC_STS='N' AND Equ_RowNo IN (1,2) )";
                //else if (LocSts == clsLocSts.cstrLoc_SNNS)
                //    strSQL += " AND LOC IN (SELECT Loc_DD FROM LOC_MST WHERE LOC_STS='S' AND Equ_RowNo IN (3,4) )";
                //else if (LocSts == clsLocSts.cstrLoc_ENNE)
                //    strSQL += " AND LOC IN (SELECT Loc_DD FROM LOC_MST WHERE LOC_STS='E' AND Equ_RowNo IN (3,4) )";
                //else if (LocSts == clsLocSts.cstrLoc_HNNH)
                //    strSQL += " AND LOC IN (SELECT Loc_DD FROM LOC_MST WHERE LOC_STS='H' AND Equ_RowNo IN (3,4) )";

                //if (NeedTempLoc)
                //    strSQL += " AND Storage_Type = 'T' ";
                //else
                //    strSQL += " AND Storage_Type <> 'T' ";
                //strSQL += " AND Loc_Size ='" + LocSize + "' ";
                //strSQL += " ORDER BY BAY_Y, LVL_Z, ROW_X ";
                //strSQL += ") A WHERE (ROWNUM < 2)";


                //For 遠紡
                
                //strSQL = "SELECT LOC FROM LOC_MST WHERE LOC_STS = 'N' AND EQU_NO ='" + CraneNo + "' ";

                // 給客戶看的見貨，先以深度取向。正式上線得修改回來 BY Leon
                strSQL = "SELECT LOC FROM LOC_MST WHERE LOC_STS = 'N' AND EQU_NO ='" + CraneNo + "' ";
                strSQL += " ORDER BY LVL_Z, BAY_Y, ROW_X ";
                
                //clsSystem.gobjDB.funGetScalar(strSQL, ref strNewLoc, ref strEM);
                if (clsSystem.gobjDB.funGetDT(strSQL, ref dtTmp, ref strEM) == ErrDef.ProcSuccess)
                {
                    strNewLoc = dtTmp.Rows[0]["LOC"].ToString();
                }
                return strNewLoc;
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return string.Empty;
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

        private int funCheckCmdSnoCount(string Plt_Id)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strCount = string.Empty;
            try
            {
                //strSQL = "SELECT COUNT (*) AS ICOUNT FROM CMD_MST WHERE CMDSTS < '3' AND  ";
                //strSQL += " CMDSNO IN (SELECT CMDSNO FROM CMD_MST WHERE CMDSTS < '3' AND LOCID='" + Plt_Id + "')";
                //Update for 大立光
                strSQL = "SELECT COUNT(*) AS ICOUNT FROM CMD_MST WHERE Cmd_Sno<>'' and CMD_STS <'3' AND ";
                strSQL = "CMD_SNO IN (SELECT CMD_SNO FROM CMD_MST WHERE Cmd_Sno<>'' and CMD_STS <'3' AND PLT_ID=' " + Plt_Id +"')";
                if(clsSystem.gobjDB.funGetScalar(strSQL, ref strCount, ref strEM) == ErrDef.ProcSuccess)
                    return int.Parse(strCount);
                else
                    return 0;
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return 0;
            }
        }
    }
}
