using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Mirle.Library;

namespace Mirle.WinPLCCommu
{
    public partial class frmWinPLCCommu
    {
        /// <summary>
        /// 站對站流程
        /// </summary>
        private void funStnToStn()
        {

            funStnToStnEquPLCCmd();
            funStnToStn_CraneCmdFinish();
        }
        /// <summary>
        /// 檢查站口訊號是否正確-站對站
        /// </summary>
        private void funStnToStnCheck(string StnNo,string NewStnNo)
        {
            string strStnNo = string.Empty;
            string strSQL = string.Empty;
            string strEM = string.Empty;

            DataTable objDataTable = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);
            try
            {
                strSQL = "SELECT * FROM StnDef WHERE StnNo IN ('" + StnNo + "','" + NewStnNo + "') ORDER BY ";
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
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }
        /// <summary>
        /// 寫入周邊PLC-站對站
        /// </summary>
        private void funStnToStnWrite()
        {
        }

        /// <summary>
        /// 寫入Crane命令-站對站
        /// </summary>
        private void funStnToStnEquPLCCmd()
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            
            DataTable objDataTable = new DataTable();
            Dictionary<string, clsCmdSno> dicCmdSno = new Dictionary<string, clsCmdSno>();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            try
            {
                strSQL = "SELECT * FROM CMD_MST WHERE CMD_MODE = '4' AND CMD_STS ='1' AND TRACE ='" + clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd + "' ORDER BY CMD_SNO,LOC,PRTY,Crt_Date";
                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    #region 取得命令
                    for (int intCount = 0; intCount < objDataTable.Rows.Count; intCount++)
                    {
                        if (dicCmdSno.ContainsKey(objDataTable.Rows[intCount]["CMD_SNO"].ToString()))
                        {
                            string strCmdSno = objDataTable.Rows[intCount]["CMD_SNO"].ToString();
                            dicCmdSno[strCmdSno].CmdSno = objDataTable.Rows[intCount]["CMD_SNO"].ToString();
                            dicCmdSno[strCmdSno].Stn_No = objDataTable.Rows[intCount]["Stn_No"].ToString();
                            dicCmdSno[strCmdSno].NewLoc = objDataTable.Rows[intCount]["New_Loc"].ToString();
                            dicCmdSno[strCmdSno].CmdMode = 2;
                        }
                        else
                        {
                            clsCmdSno CmdSno = new clsCmdSno();
                            CmdSno.CmdSno = objDataTable.Rows[intCount]["CMD_SNO"].ToString();
                            CmdSno.Stn_No = objDataTable.Rows[intCount]["Stn_No"].ToString();
                            CmdSno.NewLoc = objDataTable.Rows[intCount]["New_Loc"].ToString();
                            CmdSno.Priority = int.Parse(objDataTable.Rows[intCount]["PRTY"].ToString());
                            CmdSno.CmdMode = 2;
                            dicCmdSno.Add(CmdSno.CmdSno, CmdSno);
                        }
                    }
                    #endregion 取得命令



                    foreach (clsCmdSno CmdSno in dicCmdSno.Values)
                    {
                        if (funStnNo2Crane(CmdSno.Stn_No) != funStnNo2Crane(CmdSno.NewLoc))
                            continue;


                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        SystemTraceLog.LogMessage = "Find Transfer Cmd Success!";
                        SystemTraceLog.CmdSno = CmdSno.CmdSno;
                        SystemTraceLog.StnNo = CmdSno.Stn_No;
                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                        int intBufferIndex, intBufferIndex_Out;
                        #region 寫入PLC
                        
                        objDataTable = new DataTable();
                        strSQL = "SELECT * FROM StnDef WHERE StnNo IN ('" + CmdSno.Stn_No + "') ORDER BY STNNO";
                        if (clsSystem.gobjSystemDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                        {
                            intBufferIndex = clsTool.funConvertToInt(objDataTable.Rows[0]["BufferIndex"].ToString());

                            #region 註解
                            //if (objBufferData.PLC2PCBuffer[intBufferIndex].StnModeCode_Load &&
                            //    objBufferData.PLC2PCBuffer[intBufferIndex].ReadNotice == (int)clsPLC2PCBuffer.enuReadNotice.Read &&
                            //    objBufferData.PLC2PCBuffer[intBufferIndex].Ready == (int)clsPLC2PCBuffer.enuReady.InReady &&
                            //    string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[intBufferIndex].LeftCmdSno)
                            //    )
                            //{
                            //    #region 讀取BCR

                            //    objDataTable = new DataTable();
                            //    strSQL = "SELECT * FROM IN_BUF WHERE BCR_NO IN";
                            //    strSQL += " ('" + objBCRData[(intBufferIndex+1)/2, clsBCR.enuBCRLoc.Once].BCRNo + "')";
                            //    if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                            //    {
                            //        foreach (DataRow drTmp in objDataTable.Rows)
                            //        {
                            //            switch (drTmp["BCR_STS"].ToString())
                            //            {
                            //                case clsBCRSts.cstrReadFinish:
                            //                    if (drTmp["BCR_No"].ToString() == objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo)
                            //                    {
                            //                        if (objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID != drTmp["BCR_DATA"].ToString())
                            //                        {
                            //                            objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRSts =
                            //                                clsTool.funGetEnumValue<clsBCR.enuBCRSts>(drTmp["BCR_STS"].ToString());
                            //                            objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID = drTmp["BCR_DATA"].ToString();

                            //                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            //                            SystemTraceLog.LogMessage = "BCR Read Success!";
                            //                            SystemTraceLog.BCRNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo;
                            //                            SystemTraceLog.BCRID = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID;
                            //                            SystemTraceLog.StnNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].StnNo;
                            //                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                            //                        }
                            //                    }
                            //                    break;
                            //                case clsBCRSts.cstrNone:
                            //                    #region 啟動BCR
                            //                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
                            //                    if (funUpdateBCRSts(clsBCR.enuBCRSts.Reading, objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo, clsReBCRID.cstrBCRDataInit))
                            //                    {
                            //                        objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.Reading;
                            //                        objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;

                            //                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                            //                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            //                        SystemTraceLog.LogMessage = "Update Both BCR Sts Success!";
                            //                        SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.Reading).ToString();
                            //                        SystemTraceLog.BCRNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo;

                            //                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            //                    }
                            //                    else
                            //                    {
                            //                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                            //                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            //                        SystemTraceLog.LogMessage = "Update Both BCR Sts Fail!";
                            //                        SystemTraceLog.BCRSts = clsBCR.enuBCRSts.Reading.ToString();
                            //                        SystemTraceLog.BCRNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo;
                            //                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            //                    }
                            //                    #endregion 啟動BCR
                            //                    break;

                            //                default:

                            //                    break;
                            //            }
                            //        }
                            //}
                            //    #endregion 讀取BCR

                            //#region 確認BCR讀取是否有誤 For 大立光
                            //if ((objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRSts == clsBCR.enuBCRSts.ReadFinish &&
                            //    objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID == clsReBCRID.cstrBCRError))
                            //{
                            //    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
                            //    if (funUpdateBCRSts(clsBCR.enuBCRSts.None, objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo, clsReBCRID.cstrBCRDataInit))
                            //    {
                            //        if (funWritePC2PLCSingel(
                            //            1,
                            //            objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BufferName,

                            //            clsPLC.enuAddressSection.ReadNotice,
                            //            clsReBCRSts.cstrNG))
                            //        {
                            //            objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.None;
                            //            objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;

                            //            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                            //            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            //            SystemTraceLog.LogMessage = "BCR Read Fail!";
                            //            SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                            //            SystemTraceLog.BCRNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo;
                            //            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            //        }
                            //        else
                            //            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                            //    }
                            //    else
                            //    {
                            //        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                            //        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            //        SystemTraceLog.LogMessage = "Update BCR Sts Fail!";
                            //        SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                            //        SystemTraceLog.BCRNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo;
                            //        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            //    }
                            //}
                            //#endregion 確認讀取是否有誤

                            //#region Update Cmd Trace + 寫入PLC
                            //clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
                            //if (funUpdateCmdTrace(CmdSno.CmdSno,
                            //                     objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID,
                            //                     clsCmdSts.cstrCmdSts_Start,
                            //                     clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd,
                            //                     objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo) &&
                            //    funUpdateBCRSts(clsBCR.enuBCRSts.None, objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo, clsReBCRID.cstrBCRDataInit))
                            //{
                            //    if (funWritePC2PLCSingel(
                            //        objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BufferName,
                            //        CmdSno.CmdSno,//序號
                            //        "1", //模式
                            //        "0",//初始通知
                            //        clsFunNotice1.CMD_OK,
                            //        clsFunNotice2.StnInMode,
                            //        clsFunNotice3.None
                            //        ))
                            //    {
                            //        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                            //        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            //        SystemTraceLog.LogMessage = "Stock In Cmd Initiated!";
                            //        SystemTraceLog.CmdSno = CmdSno.CmdSno;
                            //        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                            //        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd;
                            //        SystemTraceLog.StnNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].StnNo;
                            //        SystemTraceLog.LocID = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID;
                            //        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                            //        objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.None;
                            //        objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;

                            //        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            //        SystemTraceLog.LogMessage = "Update Both BCR Sts Success!";
                            //        SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                            //        SystemTraceLog.BCRNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo;
                            //        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            //    }
                            //    else
                            //        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                            //}
                            //else
                            //{
                            //    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                            //    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            //    SystemTraceLog.LogMessage = "UpdateCmd Trace Fail!";
                            //    SystemTraceLog.CmdSno = CmdSno.CmdSno_L;
                            //    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                            //    SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd;
                            //    SystemTraceLog.StnNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].StnNo;
                            //    SystemTraceLog.LocID = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRID;
                            //    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                            //    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            //    SystemTraceLog.LogMessage = "Update BCR Sts Fail!";
                            //    SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                            //    SystemTraceLog.BCRNo = objBCRData[(intBufferIndex + 1) / 2, clsBCR.enuBCRLoc.Once].BCRNo;
                            //    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            //}
                            //#endregion Update Cmd Trace
                            //} 
                            #endregion 註解
                        #endregion 寫入PLC

                            //if (funUpdateCmdTrace(CmdSno.CmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd))
                            //{
                            //    //if (funWritePC2PLCSingel(
                            //    //                    StnDef.Buffer,
                            //    //                    CmdSno.CmdSno,
                            //    //                    CmdSno.CmdMode.ToString(),
                            //    //                    CmdSno.IniNotice.ToString()
                                                    
                            //    //                    ))
                            //}


                            //寫入出庫PLC
                            objDataTable = new DataTable();
                            strSQL = "SELECT * FROM StnDef WHERE StnNo IN ('" + CmdSno.NewLoc + "') ORDER BY STNNO";
                            if (clsSystem.gobjSystemDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                            {
                                intBufferIndex_Out = clsTool.funConvertToInt(objDataTable.Rows[0]["BufferIndex"].ToString());

                                if (!objBufferData.PLC2PCBuffer[intBufferIndex_Out].StnModeCode_CargoLoad &&
                                objBufferData.PLC2PCBuffer[intBufferIndex_Out].Ready == (int)clsPLC2PCBuffer.enuReady.OutReady &&
                                string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[intBufferIndex_Out].LeftCmdSno) &&
                                objBufferData.PLC2PCBuffer[intBufferIndex_Out].StnMode == (int)clsPLC2PCBuffer.enuStnMode.None)
                                {
                                    if (funUpdateCmdTrace(CmdSno.CmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd))
                                    {

                                        //if (funWritePC2PLCSingel(
                                        //    objBCRData[(intBufferIndex_Out + 1) / 2, clsBCR.enuBCRLoc.Once].BufferName,
                                        //    CmdSno.CmdSno,//序號
                                        //    "2", //模式
                                        //    "0",//初始通知
                                        //    clsFunNotice1.CMD_OK,
                                        //    clsFunNotice2.StnOutMode,
                                        //    clsFunNotice3.None
                                        //    ))
                                        if (funWritePC2PLCSingel(
                                                    objBCRData[(intBufferIndex_Out -1) / 2, clsBCR.enuBCRLoc.Once].BufferName,
                                                    CmdSno.CmdSno,
                                                    CmdSno.CmdMode.ToString(),
                                                    CmdSno.IniNotice.ToString()

                                                    ))
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Both Stock Out Cmd Initiated!";
                                            SystemTraceLog.LeftCmdSno = CmdSno.CmdSno_L;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                            SystemTraceLog.Trace = clsTrace.cstrStoreOutTrace_ReleaseEquPLCCmd;
                                            SystemTraceLog.StnNo = CmdSno.CmdSno;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    else
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                }
                                else
                                {
                                    continue;
                                }

                            }
                            if (clsSystem.intBegin == 0)
                            {
                                clsSystem.intBegin = 1;
                                #region 更新Trace 、新增EQUCMD
                                if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin) == ErrDef.ProcSuccess)
                                {
                                    if (funUpdateCmdTrace(CmdSno.CmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrStoreInTrace_ReleaseCraneCmd))
                                    {
                                        int intCrane = funStnNo2Crane(CmdSno.Stn_No);

                                        //將站口編號轉成Loc


                                        //將命令寫入EQUCMD
                                        if (funInsertEquCmd(intCrane, CmdSno.CmdSno, "4", funStnNo2Loc(CmdSno.Stn_No), funStnNo2Loc(CmdSno.NewLoc), CmdSno.Priority.ToString()))
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Transfer Cmd Initiated!";
                                            SystemTraceLog.CmdSno = CmdSno.CmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                            SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrStnToStn;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                        else
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Release Equ Cmd Fail!";
                                            SystemTraceLog.CmdSno = CmdSno.CmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                            SystemTraceLog.CmdMode = clsEquCmdMode.cstrStnToStn;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    else
                                    {
                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Transfer Cmd Trace Fail!";
                                        SystemTraceLog.CmdSno = CmdSno.CmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                }
                                #endregion 更新Trace 、新增EQUCMD
                                clsSystem.intBegin = 0;
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
            finally
            {
                if (objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
                if (dicCmdSno != null)
                {
                    dicCmdSno.Clear();
                    dicCmdSno = null;
                }
            }
        }
        /// <summary>
        /// 檢察Crane命令是否完成
        /// </summary>
        private void funStnToStn_CraneCmdFinish()
        {
            DataTable objDataTable = new DataTable();
            DataTable objCmd = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            string strSQL = string.Empty;
            string strEM = string.Empty;
            try
            {
                strSQL = "SELECT DISTINCT CMD_SNO, TRACE FROM CMD_MST WHERE CMD_MODE='4' AND CMD_STS='1'";
                strSQL += " AND TRACE='" + clsTrace.cstrStoreInTrace_ReleaseCraneCmd + "'";
                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    for (int intCount1 = 0; intCount1 < objDataTable.Rows.Count; intCount1++)
                    {
                        string strCmdSno = objDataTable.Rows[intCount1]["CMD_SNO"].ToString();
                        strSQL = "SELECT * FROM EQUCMD WHERE CMDSNO='" + strCmdSno + "'";
                        strSQL += " AND RENEWFLAG <> 'F' AND CMDSTS='9'";
                        if (clsSystem.gobjDB.funGetDT(strSQL, ref objCmd, ref strEM) == ErrDef.ProcSuccess)
                        {
                            for (int intCount2 = 0; intCount2 < objCmd.Rows.Count; intCount2++)
                            {
                                string strCmdSts = objCmd.Rows[intCount2]["CmdSts"].ToString();
                                string strCompleteCode = objCmd.Rows[intCount2]["CompleteCode"].ToString();

                                if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode.Substring(0, 1) == "W")
                                {
                                    #region Update Equ Cmd CmdSts
                                    strSQL = "UPDATE EQUCMD SET CMDSTS='0' WHERE CMDSNO='" + strCmdSno + "'";
                                    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
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
                                else if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "E2")//Crane空出庫
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrStoreInTrace_CraneCmdFinish))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Transfer Cmd Finish!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Transfer Cmd Trace Fail!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                                else if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "EF")//地上盤強制取消命令
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrStoreInTrace_CraneCmdFinish))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Transfer Cmd Finish!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Transfer Cmd Trace Fail!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                                else if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "92")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrStoreInTrace_CraneCmdFinish))
                                    {
                                        funDeleteEquCmd(strCmdSno);
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Transfer Cmd Finish!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Transfer Cmd Trace Fail!";
                                        SystemTraceLog.CmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
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
                 //objDataTable
                 //objCmd = new
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

        /// <summary>
        /// 根據站口編號輸出Crane編號
        /// </summary>
        /// <param name="strStnNo"></param>
        /// <returns></returns>
        private int funStnNo2Crane(string strStnNo)
        {
            string strSql = string.Empty;
            string strEM = string.Empty;
            DataTable objDataTable = new DataTable();
            int intEuqNo = 0;
            try
            {
                strSql = "SELECT * FROM WORK_STN WHERE STN_NO = '" + strStnNo + "'";
                if (clsSystem.gobjDB.funGetDT(strSql, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                {
                    intEuqNo = clsTool.funConvertToInt(objDataTable.Rows[0]["Equ_No"].ToString());
                }
                return intEuqNo;

            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                return 0;
            }
            finally
            {
                if (objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
            }
        }


        /// <summary>
        /// 根據站口編號輸出Loc編號
        /// </summary>
        /// <param name="strStnNo"></param>
        /// <returns></returns>
        private string funStnNo2Loc(string strStnNo)
        {
            string strSql = string.Empty;
            string strEM = string.Empty;
            string strPortNo = string.Empty;
            DataTable dtTmp = new DataTable();
            try
            {
                strSql = "Select *From StnDef Where StnNo ='"+strStnNo +"'";
                if (clsSystem.gobjSystemDB.funGetDT(strSql, ref dtTmp, ref strEM) == ErrDef.ProcSuccess)
                {
                    strPortNo = dtTmp.Rows[0]["PortNo"].ToString();
                }
                return strPortNo;

            }
            catch (Exception ex)
            {
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

        

    }
}
