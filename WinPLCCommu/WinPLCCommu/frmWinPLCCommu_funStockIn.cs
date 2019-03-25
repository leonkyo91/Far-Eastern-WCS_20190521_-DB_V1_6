﻿#region Header
///----------------------------------------------------------------------------------------------------------------------
///
/// FILE NAME: 入庫流程
///
///	DESCRIPTION:
///	
///    History
///	**********************************************************************************************************************
///     Date            Editor      Version         Description
///	**********************************************************************************************************************
///     2017/02/21      Kuei        v1.01           Fix:一開始不看Ready訊號，等下給周邊PLC後，電控才會ON Ready訊號，我們再派給Crane
///     2018/01/17      Kuei        v1.02           Add:新增盤點入庫條件IO_Type = 63
///     2018/05/24      Kuei        v1.03           Fix:預約入庫時更新Old_Sts
///     2018/05/30      Kuei        v1.04           Fix: IO_Type=11, Mode=3 加料入庫時, trace =23 時要找儲位並派命令.
///-----------------------------------------------------------------------------------------------------------------------
///           

#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mirle.Library;
using System.Windows.Forms;

namespace Mirle.WinPLCCommu
{
    public partial class frmWinPLCCommu
    {
        /// <summary>
        /// 入庫流程
        /// </summary>
        private void funStockIn(int intPLCIndex)
        {
            funStockIn_CheckSign(intPLCIndex);
            funStockIn_ReleaseEquPLCCmd(intPLCIndex);
            funStockIn_ReleaseEquPLCCmdFinish();
            funStockIn_ItemOnStn();
            funStockIn_ReleaseCraneCmd(intPLCIndex);
            funStockIn_CraneCmdFinish();
        }

        /// <summary>
        /// 入庫-讀取BCR與秤重機
        /// </summary>
        private void funStockIn_CheckSign(int intPLCIndex)
        {
            string strStnNo = string.Empty;
            string strSQL = string.Empty;
            string strEM = string.Empty;
            bool bolGo = false;
            DataTable objDataTable = new DataTable();
            DataTable objWTDataTable = new DataTable();
            DataTable dtTmp = new DataTable();
            DataTable dtStnNo = new DataTable();
            DataTable dtCheckCMD = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);
            try
            {
                
                for (int intStn = 0; intStn < objBCRData.StnCount; intStn++)
                {
                    bool bolChk = true;
                    bool bolChkWeight = false;

                    #region 清除暫存值
                    if (objDataTable != null)
                    {
                        objDataTable.Clear();
                        objDataTable.Dispose();
                        objDataTable = null;
                    }
                    if (dtTmp != null)
                    {
                        dtTmp.Clear();
                        dtTmp.Dispose();
                        dtTmp = null;
                    }
                    if (dtStnNo != null)
                    {
                        dtStnNo.Clear();
                        dtStnNo.Dispose();
                        dtStnNo = null;
                    }
                    if (objWTDataTable != null)
                    {
                        objWTDataTable.Clear();
                        objWTDataTable.Dispose();
                        objWTDataTable = null;
                    }
                    if (SystemTraceLog != null)
                    {
                        SystemTraceLog = null;
                    } 
                    #endregion

                    //string strWeight = string.Empty;
                    try
                    {
                        #region 大立光-訊號判斷
                        if (objBCRData[intStn] == null || objBCRData[intStn] == null)
                            continue;
                        if (intPLCIndex.ToString() != objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLCIndex)
                            continue;


                        #region 更改站口方向
                        Control[] result = this.Controls.Find("ptb" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo, true);
                        if (result.Length == 0) continue;
                        if (!(result[0] is PictureBox)) continue;
                        PictureBox ptb = result[0] as PictureBox;
                        if (ptb == null) continue;//v1.0.0.17 
                        //switch (objBufferData.PC2PLCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].FunNotice_2)
                        if (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnChange == 1)
                        {
                            switch (ptb.Tag.ToString())
                            {
                                case "IN":
                                    funWritePC2PLCSingel(intPLCIndex, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                            clsPLC.enuAddressSection.FunNotice_2, clsInOutMode.cstrInMode);
                                    funWritePC2PLCSingel(intPLCIndex, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName.Replace("L", "1"),
                                            clsPLC.enuAddressSection.FunNotice_2, clsInOutMode.cstrInMode);
                                    break;
                                case "OUT":
                                    funWritePC2PLCSingel(intPLCIndex, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                            clsPLC.enuAddressSection.FunNotice_2, clsInOutMode.cstrOutMode);
                                    funWritePC2PLCSingel(intPLCIndex, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName.Replace("L", "1"),
                                            clsPLC.enuAddressSection.FunNotice_2, clsInOutMode.cstrOutMode);
                                    break;
                                default:
                                    funWritePC2PLCSingel(intPLCIndex, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                            clsPLC.enuAddressSection.FunNotice_2, clsInOutMode.cstrNone);
                                    funWritePC2PLCSingel(intPLCIndex, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName.Replace("L", "1"),
                                            clsPLC.enuAddressSection.FunNotice_2, clsInOutMode.cstrNone);
                                    ptb.Image = global::Mirle.WinPLCCommu.Properties.Resources.Bottom;
                                    break;
                            }
                        }
                        #endregion 更改站口方向

                        //檢查該站口荷無時，BCR和秤重是否為已讀取，若是自動更新為未讀取
                        if (!objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnModeCode_Load)
                        {
                            objDataTable = null;
                            strSQL = "SELECT BCR_Sts FROM IN_BUF WHERE BCR_NO IN";
                            strSQL += " ('" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "')";
                            if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                            {

                                if (objDataTable.Rows[0]["BCR_Sts"].ToString() == "2")
                                {
                                    
                                    strSQL = "Update In_Buf Set BCR_Sts='0' Where Bcr_No='"+ objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo+"'";
                                    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == 0)
                                    {
                                        //更新In_Buf成功
                                    }

                                }
                            }
                            if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                            {

                                objDataTable = null;
                                strSQL = "SELECT Weight_Sts From In_Weight Where Weight_No='" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "'";
                                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                                {
                                    if (objDataTable.Rows[0]["Weight_Sts"].ToString() == "2")
                                    {
                                        strSQL = "Update In_Weight Set Weight_Sts='0',Weight_Data='n/a' Where Weight_No='" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "'";
                                        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == 0)
                                        {
                                            //更新In_Weight成功
                                        }

                                    }
                                }
                            }


                        }

                        strSQL = "";
                        if (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnModeCode_Load &&
                            objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].ReadNotice ==
                            (int)clsPLC2PCBuffer.enuReadNotice.Read &&
                            //v1.01 
                            objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].Ready ==
                            (int)clsPLC2PCBuffer.enuReady.NoReady &&
                            string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].LeftCmdSno) &&
                            objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].FunNotice !=
                            (int)clsPLC2PCBuffer.enuFunNotice.None &&
                            objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnModeCode_Auto &&
                            objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnMode == (int)clsPLC2PCBuffer.enuStnMode.None
                            )
                        #endregion 大立光-訊號判斷
                       {
                            #region 讀取BarCode For 大立光
                            if (chkBCR.Checked && !string.IsNullOrEmpty(txtBCR.Text))
                            {
                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = txtBCR.Text;
                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.ReadFinish;
                            }
                            else
                            {
                                objDataTable = new DataTable();
                                strSQL = "SELECT * FROM IN_BUF WHERE BCR_NO IN";
                                strSQL += " ('" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "')";
                                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                                {
                                    foreach (DataRow drTmp in objDataTable.Rows)
                                    {
                                        switch (drTmp["BCR_STS"].ToString())
                                        {
                                            case clsBCRSts.cstrReadFinish:
                                                if (drTmp["BCR_No"].ToString() == objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo)
                                                {
                                                    if (objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID != drTmp["BCR_DATA"].ToString())
                                                    {
                                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts =
                                                            clsTool.funGetEnumValue<clsBCR.enuBCRSts>(drTmp["BCR_STS"].ToString());
                                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = drTmp["BCR_DATA"].ToString();
                                                        strSQL = "Insert Into Barcode_log (event_time,Bcr_No,Bcr_Type,barcode_no,Bcr_sts)Values(";
                                                        strSQL += "'" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "',";
                                                        strSQL += "'" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "',";
                                                        strSQL += "'Fixd'," + "'" + drTmp["BCR_DATA"].ToString()+"',";
                                                        strSQL += "'" + clsBCRSts.cstrReadFinish+"')";
                                                        clsSystem.gobjDB.funExecSql(strSQL ,ref strEM);

                                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                        SystemTraceLog.LogMessage = "BCR Read Success!";
                                                        SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                                        SystemTraceLog.BCRID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
                                                        SystemTraceLog.StnNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo;
                                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                                                    }
                                                }
                                                break;
                                            case clsBCRSts.cstrNone:
                                                strSQL = "Insert Into Barcode_log (event_time,Bcr_No,Bcr_Type,barcode_no,Bcr_sts)Values(";
                                                strSQL += "'" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "',";
                                                strSQL += "'" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "',";
                                                strSQL += "'Fixd'," + "'" + drTmp["BCR_DATA"].ToString() + "',";
                                                strSQL += "'" + clsBCRSts.cstrNone + "')";
                                                clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                                if (clsSystem.intBegin == 0)
                                                {
                                                    clsSystem.intBegin = 1;
                                                    #region 啟動BCR
                                                    if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin, ref strEM) == ErrDef.ProcSuccess)
                                                    {

                                                        if (funUpdateBCRSts(clsBCR.enuBCRSts.Reading, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo, clsReBCRID.cstrBCRDataInit))
                                                        {

                                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.Reading;
                                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;


                                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                            SystemTraceLog.LogMessage = "Update Both BCR Sts Success!";
                                                            SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.Reading).ToString();
                                                            SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                                            funInsetBCRLOG(objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo, clsReBCRID.cstrBCRDataInit, "1", "Fixd");
                                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                        }
                                                        else
                                                        {
                                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                            SystemTraceLog.LogMessage = "Update Both BCR Sts Fail!";
                                                            SystemTraceLog.BCRSts = clsBCR.enuBCRSts.Reading.ToString();
                                                            SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                        SystemTraceLog.LogMessage = "[Begin Fail]:[funStockIn_CheckSign]:[BCR]" + strEM;
                                                        SystemTraceLog.BCRSts = clsBCR.enuBCRSts.Reading.ToString();
                                                        SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                    }
                                                    #endregion 啟動BCR
                                                    clsSystem.intBegin = 0;
                                                }
                                                break;

                                            default:

                                                break;
                                        }
                                    }
                                }
                            }
                            #endregion
                            if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                            {
                                #region 讀取秤重機---For大立光
                                if (chkWeight.Checked)
                                {
                                    //strWeight = "0";
                                    objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data = "25";
                                    objWTData[intStn, clsWT.enuWTLoc.Once].bolWTSts = true;
                                    bolChkWeight = true;
                                }
                                else
                                {
                                    objWTData[intStn, clsWT.enuWTLoc.Once].bolWTSts = false;
                                    //bolChkWeight = bolWeightRead(objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex, ref strWeight);
                                }

                                objWTDataTable = new DataTable();
                                objWTDataTable = null;
                                strSQL = "SELECT * FROM IN_WEIGHT WHERE Weight_No IN";
                                strSQL += " ('" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "')";
                                //strSQL += " ('" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.ToString().Remove(1,1) + "')";
                                if (clsSystem.gobjDB.funGetDT(strSQL, ref objWTDataTable, ref strEM) == ErrDef.ProcSuccess)
                                {
                                    
                                    switch (objWTDataTable.Rows[0]["WEIGHT_STS"].ToString())
                                    {

                                        case clsWTSts.cstrReadFinish:
                                            objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data = "0";
                                            if (objWTDataTable.Rows[0]["WEIGHT_No"].ToString() == objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo.ToString())
                                            {
                                                strSQL = "Insert Into Weight_log (event_time,Weight_No,Weight_Data,Weight_Sts)Values(";
                                                strSQL += "'" + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "',";
                                                strSQL += "'" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "',";
                                                strSQL += "'" + objWTDataTable.Rows[0]["WEIGHT_Data"].ToString() + "',";
                                                strSQL += "'" + clsWTSts.cstrReadFinish + "')";
                                                clsSystem.gobjDB.funExecSql(strSQL, ref strEM);

                                                if (objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data != objWTDataTable.Rows[0]["Weight_Data"].ToString())
                                                {
                                                    objWTData[intStn, clsWT.enuWTLoc.Once].WTSts =
                                                        clsTool.funGetEnumValue<clsWT.enuWTSts>(objWTDataTable.Rows[0]["Weight_STS"].ToString());
                                                    objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data = objWTDataTable.Rows[0]["Weight_Data"].ToString();
                                                    bolChkWeight = true;
                                                    objWTData[intStn, clsWT.enuWTLoc.Once].bolWTSts = true;
                                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                    SystemTraceLog.LogMessage = "Weight Read Success! " + objWTData[intStn, clsWT.enuWTLoc.Once].StnNo + ":" + objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data + "kg" + "DatatTable=" + objWTDataTable.Rows[0]["Weight_Data"].ToString();
                                                    SystemTraceLog.WTNo = objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo;
                                                    SystemTraceLog.WTData = objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data;
                                                    SystemTraceLog.StnNo = objWTData[intStn, clsWT.enuWTLoc.Once].StnNo;
                                                    //strWeight = objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data;
                                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                                                }
                                            }
                                            break;
                                        case clsWTSts.cstrNone:
                                            if (clsSystem.intBegin == 0)
                                            {
                                                clsSystem.intBegin = 1;
                                                #region 啟動秤重機
                                                if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin, ref strEM) == ErrDef.ProcSuccess)
                                                {
                                                    if (funUpdateWTSts(clsWT.enuWTSts.Reading, objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo, clsReWTID.cstrWTDataInit))
                                                    {

                                                        objWTData[intStn, clsWT.enuWTLoc.Once].WTSts = clsWT.enuWTSts.Reading;
                                                        objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data = clsReWTID.cstrWTDataInit;
                                                        objWTData[intStn, clsWT.enuWTLoc.Once].bolWTSts = false;
                                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                        SystemTraceLog.LogMessage = "Update Weight Sts Success!";
                                                        SystemTraceLog.WTSts = ((int)clsWT.enuWTSts.Reading).ToString();
                                                        SystemTraceLog.WTNo = objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo;
                                                        funInsertWeightLog(objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo, clsReWTID.cstrWTDataInit, clsWT.enuWTSts.Reading.ToString());
                                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                    }
                                                    else
                                                    {
                                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                        SystemTraceLog.LogMessage = "Update Weight Sts Fail!";
                                                        //SystemTraceLog.WTSts = ((int)clsWT.enuWTSts.Reading).ToString();
                                                        //SystemTraceLog.WTNo = objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo;
                                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                    }
                                                }
                                                else
                                                {
                                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                    SystemTraceLog.LogMessage = "[Begin Fail]:[funStockIn_CheckSign]:[Weight]" + strEM;
                                                    SystemTraceLog.BCRSts = clsBCR.enuBCRSts.Reading.ToString();
                                                    SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                                }
                                                #endregion 啟動秤重機
                                                clsSystem.intBegin = 0;
                                            }
                                            break;

                                        default:

                                            break;
                                    }
                                



                                    //foreach (DataRow drTmp in objWTDataTable.Rows)
                                    //{
                                        
                                        
                                        
                                    //}
                                }
                                #endregion 讀取秤重機

                                if (objWTData[intStn, clsWT.enuWTLoc.Once].WTSts == clsWT.enuWTSts.ReadFinish)
                                {
                                    //判斷是否超重
                                    double dWeight = clsTool.Double(objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data);

                                    if (dWeight > clsSystem.gstrWeightOver)
                                    {
                                        objWTData[intStn, clsWT.enuWTLoc.Once].bolWTSts = false;
                                        //寫入PLC 通知超重---退出站口
                                        if (funWritePC2PLCSingel(intPLCIndex, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                        clsPLC.enuAddressSection.FunNotice_1, clsReBCRSts.cstrNG))
                                        {
                                            funWritePC2PLCSingel(intPLCIndex,
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                            clsPLC.enuAddressSection.FunNotice_3,
                                            clsPC2PLC_Sts.cstrOverWeight);
                                            //通知退出站口
                                            if (funWritePC2PLCSingel(intPLCIndex,
                                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                                clsPLC.enuAddressSection.FunNotice_1,
                                                clsPC2PLC_Sts.cstrCheckNG))
                                            {

                                                #region 字幕機顯示--異常情況
                                                strSQL = "Select StnNo From stndef where buffer ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName + "'";
                                                clsSystem.gobjSystemDB.funGetDT(strSQL, ref dtStnNo);
                                                funMvsData(dtStnNo.Rows[0]["StnNo"].ToString(), "", "1", "1", "重量超重:1000kg");

                                                #endregion

                                            }
                                        }
                                        SystemTraceLog.Weight = "";
                                        bolChk = false;
                                        bolChkWeight = false;
                                    }
                                    else
                                    {
                                        //確認重量無超重
                                        bolChkWeight = true;
                                        objWTData[intStn, clsWT.enuWTLoc.Once].bolWTSts = true;
                                    }
                                }
                                else
                                {
                                    objWTData[intStn, clsWT.enuWTLoc.Once].bolWTSts = false;
                                    bolChkWeight = false;
                                }
                            }
                            else //無秤重的站口
                            {
                                //strWeight = "25";
                                objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data = "25";
                                bolChkWeight = true;
                                objWTData[intStn, clsWT.enuWTLoc.Once].bolWTSts = true;
                            }
                            



                            #region 確認BCR讀取是否有誤 For 大立光
                            //讀取成功但BCR 回傳ERROR
                            if ((objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts == clsBCR.enuBCRSts.ReadFinish &&
                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID == clsReBCRID.cstrBCRError))
                            {
                                if (clsSystem.intBegin == 0)
                                {
                                    clsSystem.intBegin = 1;
                                    #region 回傳ERROR 退出站口
                                    if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin, ref strEM) == ErrDef.ProcSuccess)
                                    {
                                        if (funUpdateBCRSts(clsBCR.enuBCRSts.None, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo, clsReBCRID.cstrBCRDataInit))
                                        {
                                            funWritePC2PLCSingel(intPLCIndex,
                                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                                clsPLC.enuAddressSection.FunNotice_3,
                                                clsPC2PLC_Sts.cstrBCRReadFail);
                                            //通知退出站口
                                            if (funWritePC2PLCSingel(intPLCIndex,
                                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                                clsPLC.enuAddressSection.FunNotice_1,
                                                clsPC2PLC_Sts.cstrCheckNG))
                                            {
                                                bolChk = false;
                                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.None;
                                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;

                                                #region 字幕機顯示--異常情況
                                                dtStnNo = null;
                                                strSQL = "Select StnNo From stndef where buffer ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName + "'";
                                                clsSystem.gobjSystemDB.funGetDT(strSQL, ref dtStnNo);
                                                funMvsData(dtStnNo.Rows[0]["StnNo"].ToString(), "", "1", "1", "BCR 讀取失敗");

                                                #endregion
                                                #region 更新BCR和秤重機狀態=0
                                                strSQL = "UPDATE IN_BUF SET BCR_DATA='n/a', BCR_STS='0' where BCR_STS='2' AND BCR_NO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "'";
                                                clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                                if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                                                {
                                                    strSQL = "UPDATE IN_Weight SET Weight_DATA='n/a', Weight_STS='0' where Weight_STS='2' AND Weight_No='" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "'";
                                                    clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                                }

                                                #endregion

                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "BCR Read Fail!";
                                                SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                                                SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                            else
                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                        }
                                        else
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Update BCR Sts Fail!";
                                            SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                                            SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "[Begin Fail]" + strEM;
                                        SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                                        SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion 回傳ERROR 退出站口
                                    clsSystem.intBegin = 0;
                                }
                                bolChk = false;
                            }
                            #endregion 確認讀取是否有誤

                            #region 若BCR與秤重無誤，預約儲位並更新Cmd_Mst和Cmd_Dtl

                            if ((objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts == clsBCR.enuBCRSts.ReadFinish &&
                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID != clsReBCRID.cstrBCRError) &&
                                !string.IsNullOrEmpty(objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID) && (objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data != "0" || string.IsNullOrEmpty(objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data))
                                &&objWTData[intStn, clsWT.enuWTLoc.Once].bolWTSts)
                            {
                                objDataTable = new DataTable();
                                string strLoc = string.Empty;
                                string strMessge = string.Empty;
                                int iBuffindex = objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex;
                                if (iBuffindex > 12) iBuffindex = iBuffindex - 12;
                                if (iBuffindex > 12) iBuffindex = iBuffindex - 12;
                                if (iBuffindex > 12) iBuffindex = iBuffindex - 12;
                                if (iBuffindex > 12) iBuffindex = iBuffindex - 12;
                                if (iBuffindex > 12) iBuffindex = iBuffindex - 12;
                                if (iBuffindex > 12) iBuffindex = iBuffindex - 12;
                                if (iBuffindex > 12) iBuffindex = iBuffindex - 12;
                                int intCraneNo = (iBuffindex / 4) + 1;


                                //找尋棧板ID是否有命令，若無擇退出
                                dtTmp = null;
                                strSQL = "SELECT COUNT(*) as iCount FROM CMD_MST WHERE PLT_ID ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' AND CMD_STS <'3' ";
                                //strSQL += "AND Stn_No='"+objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo+"' ";
                                //strSQL += " GROUP BY CMD_SNO";
                                if (clsSystem.gobjDB.funGetDT(strSQL, ref dtTmp, ref strEM) == ErrDef.ProcSuccess)
                                {
                                   
                                    

                                    if (dtTmp.Rows[0]["iCount"].ToString() == "0")
                                    {
                                        //無命令退出站口 發訊息
                                        funWritePC2PLCSingel(intPLCIndex,
                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                        clsPLC.enuAddressSection.FunNotice_3,
                                        clsPC2PLC_Sts.cstrNoCMD);

                                        funWritePC2PLCSingel(intPLCIndex,
                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                        clsPLC.enuAddressSection.FunNotice_1,
                                        clsPC2PLC_Sts.cstrCheckNG);
                                        bolChk = false;
                                        #region 更新BCR和秤重機狀態=0
                                        strSQL = "UPDATE IN_BUF SET BCR_DATA='n/a', BCR_STS='0' where BCR_STS='2' AND BCR_NO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "'";
                                        clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                        if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                                        {
                                            strSQL = "UPDATE IN_Weight SET Weight_DATA='n/a', Weight_STS='0' where Weight_STS='2' AND Weight_No='" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "'";
                                            clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                        }
                                        #endregion
                                        #region 字幕機顯示--異常情況
                                        dtStnNo = null;
                                        strSQL = "Select StnNo From stndef where buffer ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName + "'";
                                        clsSystem.gobjSystemDB.funGetDT(strSQL, ref dtStnNo);
                                        funMvsData(dtStnNo.Rows[0]["StnNo"].ToString(), "", "1", "1", "棧板ID:" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + " 無命令!");

                                        #endregion
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "棧板ID:" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + " 無命令退出站口!";
                                        SystemTraceLog.StnNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName;
                                        SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        return;//v1.0.0.17 
                                    }
                                    else
                                    {
                                        
                                        //有命令判斷是入庫還是庫對庫
                                        dtTmp = null;
                                        strSQL = "SELECT * FROM CMD_MST WHERE PLT_ID ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' AND CMD_STS <'3'";
                                        if (clsSystem.gobjDB.funGetDT(strSQL, ref dtTmp, ref strEM) == ErrDef.ProcSuccess)
                                        {
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdSno = dtTmp.Rows[0]["Cmd_Sno"].ToString();
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdMode = dtTmp.Rows[0]["Cmd_Mode"].ToString();
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].Trace = dtTmp.Rows[0]["Trace"].ToString();
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType = dtTmp.Rows[0]["Io_Type"].ToString();
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    //查詢命令ERROR 退出站口
                                    funWritePC2PLCSingel(intPLCIndex,
                                    objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                    clsPLC.enuAddressSection.FunNotice_3,
                                    clsPC2PLC_Sts.cstrNoCMD);

                                    funWritePC2PLCSingel(intPLCIndex,
                                    objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                    clsPLC.enuAddressSection.FunNotice_1,
                                    clsPC2PLC_Sts.cstrCheckNG);
                                    #region 更新BCR和秤重機狀態=0
                                    strSQL = "UPDATE IN_BUF SET BCR_DATA='n/a', BCR_STS='0' where BCR_STS='2' AND BCR_NO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "'";
                                    clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                    if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                                    {
                                        strSQL = "UPDATE IN_Weight SET Weight_DATA='n/a', Weight_STS='0' where Weight_STS='2' AND Weight_No='" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "'";
                                        clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                    }
                                    #endregion
                                    bolChk = false;
                                }
                                dtTmp = null;
                                strSQL = "SELECT * FROM Loc_MST WHERE PLT_ID ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "'";
                                if (clsSystem.gobjDB.funGetDT(strSQL, ref dtTmp, ref strEM) == ErrDef.ProcSuccess)
                                {
                                    bolChk = false;
                                    //已有相同棧板ID，退出站口
                                    //退出站口 發訊息
                                    funWritePC2PLCSingel(intPLCIndex,
                                    objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                    clsPLC.enuAddressSection.FunNotice_3,
                                    clsPC2PLC_Sts.cstrLocFail);

                                    funWritePC2PLCSingel(intPLCIndex,
                                    objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                    clsPLC.enuAddressSection.FunNotice_1,
                                    clsPC2PLC_Sts.cstrCheckNG);
                                    #region 更新BCR和秤重機狀態=0
                                    strSQL = "UPDATE IN_BUF SET BCR_DATA='n/a', BCR_STS='0' where BCR_STS='2' AND BCR_NO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "'";
                                    clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                    if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                                    {
                                        strSQL = "UPDATE IN_Weight SET Weight_DATA='n/a', Weight_STS='0' where Weight_STS='2' AND Weight_No='" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "'";
                                        clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                    }
                                    #endregion
                                    #region 字幕機顯示--異常情況
                                    dtStnNo = null;
                                    strSQL = "Select StnNo From stndef where buffer ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName + "'";
                                    clsSystem.gobjSystemDB.funGetDT(strSQL, ref dtStnNo);
                                    funMvsData(dtStnNo.Rows[0]["StnNo"].ToString(), "", "1", "1", "棧板ID:" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + " 重複!");

                                    #endregion
                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                    SystemTraceLog.LogMessage = "棧板ID:" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + " 重複退出站口!";
                                    SystemTraceLog.StnNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName;
                                    SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    return;//v1.0.0.17 
                                }

                                //strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_NNNN, false, false);

                                //if (string.IsNullOrEmpty(strLoc))
                                //{
                                //    strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_SNNS, false, false);
                                //    if (string.IsNullOrEmpty(strLoc))
                                //    {
                                //        strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_ENNE, false, false);
                                //        if (string.IsNullOrEmpty(strLoc))
                                //        {
                                //            strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_HNNH, false, false);
                                //        }
                                //    }
                                //}
                                if (objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdMode == "1"
                                    || ((objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdMode == "3" && (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "11") 
                                    || (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "12") || (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "13")
                                    || (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "62")
                                    //v1.02 
                                    || (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "63")
                                    )
                                    && (objBCRData[intStn, clsBCR.enuBCRLoc.Once].Trace =="23")))
                                {
                                    string strLocSize = string.Empty;
                                    if (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].FunNotice == 1)
                                    {
                                        strLocSize = "H";

                                    }
                                    else if (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].FunNotice == 2)
                                    {
                                        strLocSize = "S";
                                    }
                                    #region 尋找空儲位
                                    strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_NNNN, false, false, strLocSize, ref strSQL);

                                    if (string.IsNullOrEmpty(strLoc))
                                    {
                                        strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_SNNS, false, false, strLocSize, ref strSQL);
                                        if (string.IsNullOrEmpty(strLoc))
                                        {
                                            strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_ENNE, false, false, strLocSize, ref strSQL);
                                            if (string.IsNullOrEmpty(strLoc))
                                            {
                                                strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_HNNH, false, false, strLocSize, ref strSQL);
                                            }
                                        }
                                    }
                                    #endregion

                                    #region 確認有儲位可放，通知放行
                                    if (!string.IsNullOrWhiteSpace(strLoc) && bolChk)
                                    {

                                        #region 更新BCR和秤重機狀態=0
                                        strSQL = "UPDATE IN_BUF SET BCR_DATA='n/a', BCR_STS='0' where BCR_STS='2' AND BCR_NO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo+"'";
                                        clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                        if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                                        {
                                            strSQL = "UPDATE IN_Weight SET Weight_DATA='n/a', Weight_STS='0' where Weight_STS='2' AND Weight_No='" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "'";
                                            clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                        }
                                        #endregion
                                        //找到有命令先更新CMD_MST.STNNO
                                        strSQL = "Update CMD_MST SET STN_NO ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo + "' WHERE PLT_ID ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' AND CMD_STS<'3'";
                                        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == 0)
                                        {
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "找到命令、有儲位放，更新CMD_MST.STN_NO [" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "]";
                                            SystemTraceLog.StnNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName;
                                            SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                        else
                                        {
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "沒有找到命令 SQL=["+strSQL+"]";
                                            SystemTraceLog.StnNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName;
                                            SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            continue;
                                        }
                                        //有儲位可放，通知放行

                                        funWritePC2PLCSingel(intPLCIndex,
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                            clsPLC.enuAddressSection.FunNotice_1,
                                            clsPC2PLC_Sts.cstrCheckOK);
                                        funWritePC2PLCSingel(intPLCIndex,
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                            clsPLC.enuAddressSection.Cmdsno,
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdSno);
                                        funWritePC2PLCSingel(intPLCIndex,
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                            clsPLC.enuAddressSection.Mode,
                                            clsPC2PLC_Sts.cstrStnInMode);
                                        #region 更新Trace
                                        //判斷使用率
                                        int iAvail = 0;
                                        switch (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].Avail)
                                        {
                                            case 1:
                                                iAvail = 25;
                                                break;
                                            case 2:
                                                iAvail = 50;
                                                break;
                                            case 3:
                                                iAvail = 75;
                                                break;
                                            case 4:
                                                iAvail = 100;
                                                break;
                                            default:
                                                iAvail = 0;
                                                break;
                                        }

                                        if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                                        {
                                            //檢查有秤重機的站口
                                            //strSQL = "UPDATE CMD_MST SET LOC = '" + strLoc + "',Weight='" + objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data + "' ,EQU_NO='" + intCraneNo + "' ";
                                            strSQL = "UPDATE CMD_MST SET Weight='" + objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data + "' ,EQU_NO='" + intCraneNo + "' ";
                                        }
                                        else
                                        {
                                            //無秤重機的站口(重量為25)
                                            //strSQL = "UPDATE CMD_MST SET LOC = '" + strLoc + "',Weight='" + "25" + "' ,EQU_NO='" + intCraneNo + "' ";
                                            strSQL = "UPDATE CMD_MST SET Weight='" + "25" + "' ,EQU_NO='" + intCraneNo + "' ";
                                        }
                                        strSQL += ",Avail=" + iAvail + "";
                                        strSQL += ",TRACE ='" + clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd + "' ";
                                        //strSQL += ",CMD_STS = '1' ";
                                        strSQL += " WHERE 1=1 ";
                                        strSQL += "AND Plt_Id ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' ";
                                        strSQL += " AND CMD_SNO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdSno + "' ";
					                    //20180530 Kuei  //v1.04
					                    if(objBCRData[intStn, clsBCR.enuBCRLoc.Once].Trace =="23")
						                    strSQL += " AND TRACE ='23'";
					                    else
                                        	strSQL += " AND TRACE ='0'";

                                        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                        {
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "更新Trace成功! Trace=11 StnNo=" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo;
                                            SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                                            SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.None;
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;
                                            objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data = "0";
                                            objWTData[intStn, clsWT.enuWTLoc.Once].WTSts = clsWT.enuWTSts.None;
                                        }
                                        #endregion


                                    }
                                    else
                                    {
                                        //無空儲位，退出站口
                                        funWritePC2PLCSingel(intPLCIndex,
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                            clsPLC.enuAddressSection.FunNotice_3,
                                            clsPC2PLC_Sts.cstrNoCMD);
                                        //通知退出站口
                                        if (funWritePC2PLCSingel(intPLCIndex,
                                            objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                            clsPLC.enuAddressSection.FunNotice_1,
                                            clsPC2PLC_Sts.cstrCheckNG))
                                        {
                                            bolChk = false;
                                            #region 更新BCR和秤重機狀態=0
                                            strSQL = "UPDATE IN_BUF SET BCR_DATA='n/a', BCR_STS='0' where BCR_STS='2' AND BCR_NO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "'";
                                            clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                            if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                                            {
                                                strSQL = "UPDATE IN_Weight SET Weight_DATA='n/a', Weight_STS='0' where Weight_STS='2' AND Weight_No='" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "'";
                                                clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                            }
                                            #endregion
                                            #region 字幕機顯示--異常情況
                                            dtStnNo = null;
                                            strSQL = "Select StnNo From stndef where buffer ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName + "'";
                                            clsSystem.gobjSystemDB.funGetDT(strSQL, ref dtStnNo);
                                            funMvsData(dtStnNo.Rows[0]["StnNo"].ToString(), "", "1", "1", "無空儲位!");

                                            #endregion
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "無空儲位! StnNo=" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo;
                                            SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                                            SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            return;//v1.0.0.17 
                                        }
                                    }
                                    #endregion 確認有儲位可放，通知放行
                                }
                                else if (objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdMode == "4")//站對站
                                {
                                    //通知放行 並更新TRACE為11
                                    #region 更新BCR和秤重機狀態=0
                                    strSQL = "UPDATE IN_BUF SET BCR_DATA='n/a', BCR_STS='0' where BCR_STS='2' AND BCR_NO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "'";
                                    clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                    if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                                    {
                                        strSQL = "UPDATE IN_Weight SET Weight_DATA='n/a', Weight_STS='0' where Weight_STS='2' AND Weight_No='" + objWTData[intStn, clsWT.enuWTLoc.Once].WeightNo + "'";
                                        clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                                    }
                                    #endregion
                                    clsSystem.gobjDB.funExecSql(strSQL, ref strEM);

                                    funWritePC2PLCSingel(intPLCIndex,
                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                        clsPLC.enuAddressSection.FunNotice_1,
                                        clsPC2PLC_Sts.cstrCheckOK);
                                    funWritePC2PLCSingel(intPLCIndex,
                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                        clsPLC.enuAddressSection.Cmdsno,
                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdSno);
                                    funWritePC2PLCSingel(intPLCIndex,
                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                                        clsPLC.enuAddressSection.Mode,
                                        clsPC2PLC_Sts.cstrStnInMode);

                                    #region 更新Trace
                                    //判斷使用率
                                    int iAvail = 0;
                                    switch (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].Avail)
                                    {
                                        case 1:
                                            iAvail = 25;
                                            break;
                                        case 2:
                                            iAvail = 50;
                                            break;
                                        case 3:
                                            iAvail = 75;
                                            break;
                                        case 4:
                                            iAvail = 100;
                                            break;
                                        default:
                                            iAvail = 0;
                                            break;
                                    }

                                    if (clsTool.funConvertToInt(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Substring(objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo.Length - 1, 1)) % 2 == 0)
                                    {
                                        //檢查有秤重機的站口
                                        //strSQL = "UPDATE CMD_MST SET LOC = '" + strLoc + "',Weight='" + objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data + "' ,EQU_NO='" + intCraneNo + "' ";
                                        strSQL = "UPDATE CMD_MST SET Weight='" + objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data + "' ,EQU_NO='" + intCraneNo + "' ";
                                    }
                                    else
                                    {
                                        //無秤重機的站口(重量為25)
                                        //strSQL = "UPDATE CMD_MST SET LOC = '" + strLoc + "',Weight='" + "25" + "' ,EQU_NO='" + intCraneNo + "' ";
                                        strSQL = "UPDATE CMD_MST SET Weight='" + "25" + "' ,EQU_NO='" + intCraneNo + "' ";
                                    }
                                    strSQL += ",Avail=" + iAvail + "";
                                    strSQL += ",CMD_STS ='1'";
                                    strSQL += ",TRACE ='" + clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd + "' ";
                                    strSQL += " WHERE 1=1 ";
                                    strSQL += "AND Plt_Id ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' ";
                                    strSQL += " AND CMD_SNO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdSno + "' ";
                                    strSQL += " AND TRACE ='0'";

                                    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "更新Trace成功! Trace=11 StnNo=" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo;
                                        SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
                                        SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.None;
                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;
                                        objWTData[intStn, clsWT.enuWTLoc.Once].WT_Data = "0";
                                        objWTData[intStn, clsWT.enuWTLoc.Once].WTSts = clsWT.enuWTSts.None;

                                    }
                                    #endregion

                                }
                            }
                            #endregion

                        }
                        #region v1.0.1.0 註解
                        //else if (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnModeCode_Load &&
                        //    //objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].ReadNotice ==
                        //    //(int)clsPLC2PCBuffer.enuReadNotice.Read &&
                        //    //v1.01 
                        //    objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].Ready ==
                        //    (int)clsPLC2PCBuffer.enuReady.InReady &&
                        //    !string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].LeftCmdSno) &&
                        //    objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].FunNotice !=
                        //    (int)clsPLC2PCBuffer.enuFunNotice.None &&
                        //    objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnModeCode_Auto &&
                        //    objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnMode == (int)clsPLC2PCBuffer.enuStnMode.InMode
                        //    )
                        //{
                        //    //收到Ready訊號，預約儲位 更新CMD
                        //    string strLoc = string.Empty;
                        //    string strMessge = string.Empty;
                        //    int iCrn = objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex;
                        //    string strCmdSno = objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].LeftCmdSno.PadLeft(5, '0'); ;
                        //    if (objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdMode == "1"
                        //            || ((objBCRData[intStn, clsBCR.enuBCRLoc.Once].CmdMode == "3" && (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "11")
                        //            || (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "12") || (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "13")
                        //            || (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "62")
                        //        //v1.02 
                        //            || (objBCRData[intStn, clsBCR.enuBCRLoc.Once].IOType == "63")
                        //            )
                        //          ))
                        //    {
                        //        if (iCrn > 11)
                        //        {
                        //            iCrn = iCrn - 11;

                        //            if (iCrn > 11)
                        //            {
                        //                iCrn = iCrn - 11;
                        //            }
                        //        }
                        //        int intCraneNo = ((iCrn) / 5) + 1;
                        //        string strCrn = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo.Substring(2, 1);
                        //        switch (strCrn)
                        //        {
                        //            case "1":
                        //            case "2":
                        //                intCraneNo = 1;
                        //                break;
                        //            case "3":
                        //            case "4":
                        //                intCraneNo = 2;
                        //                break;
                        //            case "5":
                        //            case "6":
                        //                intCraneNo = 3;
                        //                break;
                        //        }

                        //        //預約儲位前檢察是否已被更新
                        //        strSQL = "SELECT Loc FROM CMD_MST WHERE CMD_SNO ='" + strCmdSno + "' ";
                        //        if (clsSystem.gobjDB.funGetDT(strSQL, ref dtCheckCMD, ref strEM) == ErrDef.ProcSuccess)
                        //        {
                        //            if (!string.IsNullOrWhiteSpace(dtCheckCMD.Rows[0]["Loc"].ToString()))
                        //            {
                        //                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        //                SystemTraceLog.LogMessage = "命令已更新過 跳出迴圈 [Cmd_Mst.Loc='" + dtCheckCMD.Rows[0]["Loc"].ToString() + "]";
                        //                SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
                        //                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                        //                continue;//命令已更新過 跳出迴圈
                        //            }
                        //            if (dtCheckCMD.Rows[0]["Loc"].ToString().Length > 6)
                        //            {
                        //                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        //                SystemTraceLog.LogMessage = "命令已更新過 跳出迴圈 [Cmd_Mst.Loc='" + dtCheckCMD.Rows[0]["Loc"].ToString() + "]";
                        //                SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
                        //                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                        //                continue;
                        //            }

                        //        }

                        //        string strLocSize = string.Empty;
                        //        if (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].FunNotice == 1)
                        //        {
                        //            strLocSize = "H";

                        //        }
                        //        else if (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].FunNotice == 2)
                        //        {
                        //            strLocSize = "S";
                        //        }


                        //        #region 尋找空儲位

                        //        strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_NNNN, false, false, strLocSize, ref strSQL);

                        //        if (string.IsNullOrEmpty(strLoc))
                        //        {
                        //            strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_SNNS, false, false, strLocSize, ref strSQL);
                        //            if (string.IsNullOrEmpty(strLoc))
                        //            {
                        //                strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_ENNE, false, false, strLocSize, ref strSQL);
                        //                if (string.IsNullOrEmpty(strLoc))
                        //                {
                        //                    strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_HNNH, false, false, strLocSize, ref strSQL);
                        //                }
                        //            }
                        //        }


                        //        #endregion

                        //        #region 預約儲位&命令
                        //        if (!string.IsNullOrWhiteSpace(strLoc))
                        //        {

                        //            if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin, ref strEM) == ErrDef.ProcSuccess)
                        //            {


                        //                //預約儲位
                        //                strSQL = "UPDATE Loc_Mst Set Loc_Sts = 'I',Trn_Date='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "',MEMO='WCS' ";
                        //                //v1.0.0.25 新增更新Loc_Mst判斷條件 Loc_Sts='N'
                        //                strSQL += " Where Loc = '" + strLoc + "' AND LOC_STS='N' ";
                        //                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                        //                {

                        //                    //更新CMD_DTL
                        //                    strSQL = "UPDATE CMD_MST SET LOC='" + strLoc + "' ";
                        //                    strSQL += "WHERE Plt_Id ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' ";
                        //                    strSQL += " AND CMD_SNO='" + strCmdSno + "' ";
                        //                    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                        //                    {

                        //                        strSQL = "UPDATE CMD_DTL SET LOC = '" + strLoc + "' ";
                        //                        strSQL += "WHERE Plt_Id ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' ";
                        //                        strSQL += " AND CMD_SNO='" + strCmdSno + "' ";
                        //                        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                        //                        {

                        //                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                        //                            strMessge = "預約儲位-Success!";
                        //                            bolChk = true;
                        //                            return;//v1.0.0.17 
                        //                            #region 字幕機顯示--正常情況--註解(移到更新Trace時Update)
                        //                            //string strCMDSNO = string.Empty;
                        //                            //dtStnNo = null;
                        //                            //strSQL = "Select StnNo From stndef where buffer ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName + "'";
                        //                            //clsSystem.gobjSystemDB.funGetDT(strSQL, ref dtStnNo);
                        //                            //strSQL = "SELECT CMD_Sno From CMD_Mst  EQU_NO='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRLoc + "' ";
                        //                            //strSQL += "AND Plt_Id ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' ";
                        //                            //clsSystem.gobjDB.funGetScalar(strSQL, ref strCMDSNO,ref strEM);
                        //                            //funMvsData(dtStnNo.Rows[0]["StnNo"].ToString(), strCMDSNO, "1", "0", "");

                        //                            #endregion
                        //                        }
                        //                        else
                        //                        {
                        //                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                        //                            strMessge = "預約儲位-更新Cmd_Dtl 失敗!";
                        //                        }
                        //                    }
                        //                    else
                        //                    {
                        //                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                        //                        strMessge = "預約儲位-更新CMD_Mst 失敗!";
                        //                    }
                        //                }
                        //                else
                        //                {
                        //                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                        //                    strMessge = "預約儲位-更新Loc_Mst 失敗!";
                        //                }
                        //                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        //                SystemTraceLog.LogMessage = strMessge;
                        //                SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
                        //                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                        //            }
                        //            else
                        //            {
                        //                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        //                SystemTraceLog.LogMessage = "[Begin Fail]" + strEM;
                        //                SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
                        //                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            //funWritePC2PLCSingel(intPLCIndex,
                        //            //objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                        //            //clsPLC.enuAddressSection.FunNotice_3,
                        //            //clsPC2PLC_Sts.cstrNoCMD);
                        //            ////如果沒有儲位，則通知退出
                        //            //if (funWritePC2PLCSingel(intPLCIndex,
                        //            //objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                        //            //clsPLC.enuAddressSection.FunNotice_1,
                        //            //clsPC2PLC_Sts.cstrCheckNG))
                        //            //{
                        //            //    #region 字幕機顯示--異常情況
                        //            //    dtStnNo = null;
                        //            //    strSQL = "Select StnNo From stndef where buffer ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName + "'";
                        //            //    clsSystem.gobjSystemDB.funGetDT(strSQL, ref dtStnNo);
                        //            //    funMvsData(dtStnNo.Rows[0]["StnNo"].ToString(), "", "1", "1", "無空儲位!");

                        //            //    #endregion
                        //            //    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                        //            //    SystemTraceLog.LogMessage = "無空儲位!";
                        //            //    SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
                        //            //    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                        //            //}
                        //        }

                        //        #endregion 預約儲位命令
                        //    }
                        //}
                        #endregion v1.0.1.0註解

                    }
                    catch (Exception ex)
                    {
                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                        clsSystem.intBegin = 0;
                        throw new System.Exception(ex.Message);
                        //var varObject = MethodBase.GetCurrentMethod();
                        //clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
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
                if (dtTmp != null)
                {
                    dtTmp.Clear();
                    dtTmp.Dispose();
                    dtTmp = null;
                }
                if (dtStnNo != null)
                {
                    dtStnNo.Clear();
                    dtStnNo.Dispose();
                    dtStnNo = null;
                }
                if (objWTDataTable != null)
                {
                    objWTDataTable.Clear();
                    objWTDataTable.Dispose();
                    objWTDataTable = null;
                }
                if (SystemTraceLog != null)
                {
                    SystemTraceLog = null;
                }
            }
        }

        /// <summary>
        /// 入庫-取得BCR ID並取得命令序號寫入周邊PLC與更新Trace
        /// </summary>
        private void funStockIn_ReleaseEquPLCCmd(int intPLCIndex)
        {
            #region 註解
            //string strStnNo = string.Empty;
            //string strSQL = string.Empty;
            //string strEM = string.Empty;

            //DataTable objDataTable = new DataTable();
            //clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);

            //for (int intStn = 0; intStn < objBCRData.StnCount; intStn++)
            //{
            //    bool bolChk = false;
            //    bool bolChkWeight = false;
            //    string strWeight = string.Empty;
            //    try
            //    {
            //        #region 大立光-訊號判斷
            //        if (objBCRData[intStn] == null || objBCRData[intStn] == null)
            //            continue;
            //        if (intPLCIndex.ToString() != objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLCIndex)
            //            continue;

            //        if (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnModeCode_Load &&
            //            objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].ReadNotice ==
            //            (int)clsPLC2PCBuffer.enuReadNotice.Read &&
            //            //v1.01 
            //            //objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].Ready ==
            //            //(int)clsPLC2PCBuffer.enuReady.InReady &&
            //            string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].LeftCmdSno) &&
            //            objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].FunNotice !=
            //            (int)clsPLC2PCBuffer.enuFunNotice.None &&
            //            objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnModeCode_Auto &&
            //            objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnMode == (int)clsPLC2PCBuffer.enuStnMode.InMode
            //            )
            //        #endregion 大立光-訊號判斷


            //        {
            //            #region 讀取BarCode For 大立光
            //            if (chkBCR.Checked && !string.IsNullOrEmpty(txtBCR.Text))
            //            {
            //                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = txtBCR.Text;
            //                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.ReadFinish;
            //            }
            //            else
            //            {
            //                objDataTable = new DataTable();
            //                strSQL = "SELECT * FROM IN_BUF WHERE BCR_NO IN";
            //                strSQL += " ('" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo + "')";
            //                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
            //                {
            //                    foreach (DataRow drTmp in objDataTable.Rows)
            //                    {
            //                        switch (drTmp["BCR_STS"].ToString())
            //                        {
            //                            case clsBCRSts.cstrReadFinish:
            //                                if (drTmp["BCR_No"].ToString() == objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo)
            //                                {
            //                                    if (objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID != drTmp["BCR_DATA"].ToString())
            //                                    {
            //                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts =
            //                                            clsTool.funGetEnumValue<clsBCR.enuBCRSts>(drTmp["BCR_STS"].ToString());
            //                                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = drTmp["BCR_DATA"].ToString();

            //                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                                        SystemTraceLog.LogMessage = "BCR Read Success!";
            //                                        SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
            //                                        SystemTraceLog.BCRID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
            //                                        SystemTraceLog.StnNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo;
            //                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

            //                                    }
            //                                }
            //                                break;
            //                            case clsBCRSts.cstrNone:
            //                                #region 啟動BCR
            //                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
            //                                if (funUpdateBCRSts(clsBCR.enuBCRSts.Reading, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo, clsReBCRID.cstrBCRDataInit))
            //                                {
            //                                    objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.Reading;
            //                                    objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;

            //                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
            //                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                                    SystemTraceLog.LogMessage = "Update Both BCR Sts Success!";
            //                                    SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.Reading).ToString();
            //                                    SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;

            //                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
            //                                }
            //                                else
            //                                {
            //                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
            //                                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                                    SystemTraceLog.LogMessage = "Update Both BCR Sts Fail!";
            //                                    SystemTraceLog.BCRSts = clsBCR.enuBCRSts.Reading.ToString();
            //                                    SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
            //                                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
            //                                }
            //                                #endregion 啟動BCR
            //                                break;

            //                            default:

            //                                break;
            //                        }
            //                    }
            //                }
            //            }
            //            #endregion

            //            #region 讀取秤重機---For大立光 尚未寫
            //            if (chkWeight.Checked)
            //            {
            //                strWeight = "0";
            //                bolChkWeight = true;
            //            }
            //            else
            //            {
            //                bolChkWeight = bolWeightRead(objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex, ref strWeight);
            //            }

            //            #endregion 讀取秤重機
            //            if (bolChkWeight)
            //            {
            //                //確認是否超重
            //                double dWeight = clsTool.Double(strWeight);
            //                if (dWeight > clsSystem.gstrWeightOver)
            //                {
            //                    //寫入PLC 通知超重---退出站口
            //                    if (funWritePC2PLCSingel(objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
            //                    clsPLC.enuAddressSection.FunNotice_1, clsReBCRSts.cstrNG))
            //                    {
            //                    }
            //                    SystemTraceLog.Weight = "";
            //                    bolChkWeight = false;
            //                }
            //            }

            //            #region 確認BCR讀取是否有誤 For 大立光
            //            //讀取成功但BCR 回傳ERROR
            //            if ((objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts == clsBCR.enuBCRSts.ReadFinish &&
            //                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID == clsReBCRID.cstrBCRError))
            //            {
            //                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
            //                if (funUpdateBCRSts(clsBCR.enuBCRSts.None, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo, clsReBCRID.cstrBCRDataInit))
            //                {
            //                    funWritePC2PLCSingel(
            //                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
            //                        clsPLC.enuAddressSection.FunNotice_3,
            //                        clsPC2PLC_Sts.cstrBCRReadFail);
            //                    //通知退出站口
            //                    if (funWritePC2PLCSingel(
            //                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
            //                        clsPLC.enuAddressSection.FunNotice_2,
            //                        clsPC2PLC_Sts.cstrCheckNG))
            //                    {
            //                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.None;
            //                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;

            //                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
            //                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                        SystemTraceLog.LogMessage = "BCR Read Fail!";
            //                        SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
            //                        SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
            //                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
            //                    }
            //                    else
            //                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
            //                }
            //                else
            //                {
            //                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
            //                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                    SystemTraceLog.LogMessage = "Update BCR Sts Fail!";
            //                    SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
            //                    SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
            //                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
            //                }
            //                bolChk = false;
            //            }
            //            #endregion 確認讀取是否有誤

            //            #region 若BCR與秤重無誤，預約儲位並更新Cmd_Mst和Cmd_Dtl

            //            if ((objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts == clsBCR.enuBCRSts.ReadFinish &&
            //                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID != clsReBCRID.cstrBCRError) &&
            //                !string.IsNullOrEmpty(objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID) && !bolChkWeight)
            //            {
            //                objDataTable = new DataTable();
            //                string strLoc = string.Empty;
            //                string strMessge = string.Empty;
            //                int intCraneNo = (objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex) / 12 + 1;

            //                strSQL = "SELECT COUNT(*) AS iCOUNT FROM LOC_MST WHERE LOC_STS='N' AND Equ_No='" + intCraneNo + "' AND Storage_Type <> 'T'";
            //                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
            //                {
            //                    if (objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].Ready ==
            //        (int)clsPLC2PCBuffer.enuReady.InReady)
            //                    {
            //                    }

            //                    #region 預約儲位&命令
            //                    if (objDataTable.Rows[0]["iCOUNT"].ToString() != "0")
            //                    {
            //                        #region 尋找空儲位
            //                        strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_NNNN, false, false);

            //                        if (string.IsNullOrEmpty(strLoc))
            //                        {
            //                            strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_SNNS, false, false);
            //                            if (string.IsNullOrEmpty(strLoc))
            //                            {
            //                                strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_ENNE, false, false);
            //                                if (string.IsNullOrEmpty(strLoc))
            //                                {
            //                                    strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_HNNH, false, false);
            //                                }
            //                            }
            //                        }
            //                        #endregion
            //                        //找尋棧板ID是否重複(CMD_MST&LOC_MST)


            //                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
            //                        //預約儲位
            //                        strSQL = "UPDATE Loc_Mst Set Loc_Sts = 'I' Where Loc = '" + strLoc + "'";
            //                        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
            //                        {
            //                            //更新CMD_MST
            //                            strSQL = "UPDATE CMD_MST SET LOC = '" + strLoc + "',Weight='" + strWeight + "' ,EQU_NO='" + intCraneNo + "' ";
            //                            strSQL += " WHERE EQU_NO='0' ";
            //                            strSQL += "AND Plt_Id ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' ";

            //                            if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
            //                            {
            //                                //更新CMD_DTL
            //                                strSQL = "UPDATE CMD_DTL SET LOC = '" + strLoc + "' ";
            //                                strSQL += "WHERE Plt_Id ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "' ";
            //                                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
            //                                {

            //                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
            //                                    strMessge = "預約儲位-Success!";
            //                                    bolChk = true;
            //                                }
            //                                else
            //                                {
            //                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
            //                                    strMessge = "預約儲位-更新Cmd_Dtl 失敗!";
            //                                }

            //                            }
            //                            else
            //                            {
            //                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
            //                                strMessge = "預約儲位-更新Cmd_Mst 失敗!";
            //                            }
            //                        }
            //                        else
            //                        {
            //                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
            //                            strMessge = "預約儲位-更新Loc_Mst 失敗!";
            //                        }
            //                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                        SystemTraceLog.LogMessage = strMessge;
            //                        SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
            //                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);


            //                    }
            //                    else
            //                    {
            //                        funWritePC2PLCSingel(
            //                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
            //                        clsPLC.enuAddressSection.FunNotice_3,
            //                        clsPC2PLC_Sts.cstrNoCMD);
            //                        //如果沒有儲位，則通知退出
            //                        if (funWritePC2PLCSingel(
            //                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
            //                        clsPLC.enuAddressSection.FunNotice_2,
            //                        clsPC2PLC_Sts.cstrCheckNG))
            //                        {
            //                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                            SystemTraceLog.LogMessage = "無空儲位!";
            //                            SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
            //                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
            //                        }
            //                    }

            //                    #endregion 預約儲位命令
            //                }

            //            }
            //            #endregion
            //            clsCmdSno CmdSno = new clsCmdSno();
            //            //確定有預約儲位再寫入周邊PLC---大立光
            //            if (bolChk)
            //            {
            //                #region 判斷命令是否相符、Update Cmd Trace
            //                #region 異常時 寫給PLC 並產生TraceLog在畫面上-For 大立光---已註解
            //                //if (funWritePC2PLCSingel(
            //                //                                objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
            //                //                                clsPLC.enuAddressSection.ReadNotice,
            //                //                                clsReBCRSts.cstrCmdErr))
            //                //{
            //                //    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                //    SystemTraceLog.LogMessage = "Find Cmd Error!";
            //                //    SystemTraceLog.LeftCmdSno = "CmdSnoError";
            //                //    SystemTraceLog.StnNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo;
            //                //    SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
            //                //    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
            //                //} 
            //                #endregion
            //                objDataTable = new DataTable();
            //                strSQL = "SELECT * FROM CMD_MST WHERE PLT_ID ='" + objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID + "'";
            //                if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
            //                {
            //                    CmdSno.CmdSno = objDataTable.Rows[0]["CMD_SNO"].ToString();
            //                }

            //                #region Update Cmd Trace + 寫入PLC
            //                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin);
            //                if (funUpdateCmdTrace(CmdSno.CmdSno,
            //                                     objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID,
            //                                     clsCmdSts.cstrCmdSts_Start,
            //                                     clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd,
            //                                     objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo) &&
            //                    funUpdateBCRSts(clsBCR.enuBCRSts.None, objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo, clsReBCRID.cstrBCRDataInit))
            //                {
            //                    if (funWritePC2PLCSingel(
            //                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
            //                        CmdSno.CmdSno,//序號
            //                        "1", //模式
            //                        "0",//初始通知
            //                        clsFunNotice1.CMD_OK,
            //                        clsFunNotice2.StnInMode,
            //                        clsFunNotice3.None
            //                        ))
            //                    {
            //                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
            //                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                        SystemTraceLog.LogMessage = "Stock In Cmd Initiated!";
            //                        SystemTraceLog.CmdSno = CmdSno.CmdSno;
            //                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
            //                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd;
            //                        SystemTraceLog.StnNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo;
            //                        SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
            //                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

            //                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRSts = clsBCR.enuBCRSts.None;
            //                        objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID = clsReBCRID.cstrBCRDataInit;

            //                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                        SystemTraceLog.LogMessage = "Update Both BCR Sts Success!";
            //                        SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
            //                        SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
            //                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
            //                    }
            //                    else
            //                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
            //                }
            //                else
            //                {
            //                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
            //                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                    SystemTraceLog.LogMessage = "UpdateCmd Trace Fail!";
            //                    SystemTraceLog.CmdSno = CmdSno.CmdSno_L;
            //                    SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
            //                    SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd;
            //                    SystemTraceLog.StnNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].StnNo;
            //                    SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
            //                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

            //                    SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
            //                    SystemTraceLog.LogMessage = "Update BCR Sts Fail!";
            //                    SystemTraceLog.BCRSts = ((int)clsBCR.enuBCRSts.None).ToString();
            //                    SystemTraceLog.BCRNo = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRNo;
            //                    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
            //                }
            //                #endregion Update Cmd Trace

            //                #endregion 判斷命令是否相符、Update Cmd Trace
            //            }

            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
            //        var varObject = MethodBase.GetCurrentMethod();
            //        clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            //    }
            //    finally
            //    {
            //        if (objDataTable != null)
            //        {
            //            objDataTable.Clear();
            //            objDataTable.Dispose();
            //            objDataTable = null;
            //        }
            //    }
            //} 
            #endregion


        }

        /// <summary>
        /// 入庫-寫入周邊PLC成功後清除 PC->PLC 的PLC值
        /// </summary>
        private void funStockIn_ReleaseEquPLCCmdFinish()
        {
            for(int intStn = 0; intStn < objBCRData.StnCount; intStn++)
            {
                try
                {
                    if(objBCRData[intStn, clsBCR.enuBCRLoc.Once] == null)
                        continue;

                    if((!string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].LeftCmdSno)) &&
                        objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].LeftCmdSno ==
                        objBufferData.PC2PLCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].CmdSno &&
                        objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnMode ==
                        objBufferData.PC2PLCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].StnMode 
                        )
                    {
                        funRefreshPC2PLCSingel(objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName);
                    }

                    if(objBufferData.PLC2PCBuffer[objBCRData[intStn, clsBCR.enuBCRLoc.Once].PLC2PCBufferIndex].ReadNotice ==
                        (int)clsPLC2PCBuffer.enuReadNotice.None 
                        )
                    {
                        //20170616將站口模式設為NONE
                        //funWritePC2PLCSingel(
                        //    objBCRData[intStn, clsBCR.enuBCRLoc.Once].BufferName,
                        //    clsPLC.enuAddressSection.ReadNotice,
                        //    ((int)clsPC2PLCBuffer.enuReadNotice.None).ToString());
                    }
                }
                catch(Exception ex)
                {
                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                    var varObject = MethodBase.GetCurrentMethod();
                    clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                }
            }
        }

        /// <summary>
        /// 入庫-棧板到達站口後預約儲位並更新Trace
        /// </summary>
        private void funStockIn_ItemOnStn()
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
           
            
            string strMessage = string.Empty;

            foreach(clsStnDef StnDef in lstInModeStnDef)
            {
                DataTable objDataTable = new DataTable();
                clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);

                try
                {
                    #region 大立光-訊號條件
                    if (objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_Load &&
                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].Ready == (int)clsPLC2PCBuffer.enuReady.InReady &&
                        !string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno) &&
                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnMode == (int)clsPLC2PCBuffer.enuStnMode.InMode &&
                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].FunNotice !=(int)clsPLC2PCBuffer.enuFunNotice.None &&
                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_Auto
                        )
                    #endregion 大立光-訊號條件
                    {
                        //int iCrn = StnDef.BufferIndex;
                        string strCmdSno = objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0');

                        #region v1.0.1.0
                        strSQL = "SELECT * FROM CMD_MST WHERE CMD_STS<'3' AND TRACE ='" + clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd + "' ";
                        strSQL += "AND CMD_MODE IN ('1','3') AND CMD_SNO ='" + strCmdSno + "'";
                        if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                        {
                            for (int iRow = 0; iRow < objDataTable.Rows.Count; iRow++)
                            {
                                string strLocSize = string.Empty;
                                string strLoc = string.Empty;
                                string strCmdMode = string.Empty;
                                string strIOType = string.Empty;
                                strCmdMode = objDataTable.Rows[iRow]["Cmd_Mode"].ToString();
                                strIOType = objDataTable.Rows[iRow]["Io_Type"].ToString();
                                strLoc = objDataTable.Rows[iRow]["Loc"].ToString();
                                if (!string.IsNullOrEmpty(strLoc))
                                    break;
                                if (strCmdMode == clsInOutMode.cstrInMode || ((strCmdMode==clsInOutMode.cstrBoth) &&
                                    strIOType == "11" || strIOType == "12" || strIOType == "13" || strIOType == "62") || strIOType == "63")
                                {
                                    //if (iCrn > 11)
                                    //{
                                    //    iCrn = iCrn - 11;

                                    //    if (iCrn > 11)
                                    //    {
                                    //        iCrn = iCrn - 11;
                                    //    }
                                    //}
                                    int intCraneNo = 0;
                                    string strCrn = StnDef.Buffer.Substring(4, 1);
                                    switch (strCrn)
                                    {
                                        case "1":
                                        case "2":
                                            intCraneNo = 1;
                                            break;
                                        case "3":
                                        case "4":
                                            intCraneNo = 2;
                                            break;
                                        case "5":
                                        case "6":
                                            intCraneNo = 3;
                                            break;
                                    }

                                    if (objBufferData.PLC2PCBuffer[StnDef.BufferIndex].FunNotice == 1)
                                    {
                                        strLocSize = "H";

                                    }
                                    else if (objBufferData.PLC2PCBuffer[StnDef.BufferIndex].FunNotice == 2)
                                    {
                                        strLocSize = "S";
                                    }
                                    #region 尋找空儲位

                                    strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_NNNN, false, false, strLocSize, ref strSQL);

                                    if (string.IsNullOrEmpty(strLoc))
                                    {
                                        strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_SNNS, false, false, strLocSize, ref strSQL);
                                        if (string.IsNullOrEmpty(strLoc))
                                        {
                                            strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_ENNE, false, false, strLocSize, ref strSQL);
                                            if (string.IsNullOrEmpty(strLoc))
                                            {
                                                strLoc = funGetEmptyLoc(intCraneNo, 0, clsLocSts.cstrLoc_HNNH, false, false, strLocSize, ref strSQL);
                                            }
                                        }
                                    }


                                    #endregion

                                    #region 預約儲位&命令
                                    if (!string.IsNullOrWhiteSpace(strLoc))
                                    {
                                        if (clsSystem.intBegin == 0)
                                        {
                                            clsSystem.intBegin = 1;
                                            #region 預約儲位 、 更新CMD
                                            if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin, ref strEM) == ErrDef.ProcSuccess)
                                            {
                                                //預約儲位並更新trace
                                                //v1.03 
                                                strSQL = "UPDATE Loc_Mst Set Loc_Sts = 'I',Old_sts = loc_sts , Trn_Date='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'";
                                                strSQL += ",MEMO='WCS'";
                                                strSQL += " Where Loc = '" + strLoc + "' AND LOC_STS='N' ";
                                                if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                                {
                                                    //更新CMD_MST
                                                    strSQL = "UPDATE CMD_MST SET LOC='" + strLoc + "',TRACE='" + clsTrace.cstrStoreInTrace_ItemOnStn + "'";
                                                    strSQL += " WHERE CMD_SNO='" + strCmdSno + "' AND TRACE='" + clsTrace.cstrStoreInTrace_ReleaseEquPLCCmd + "'";
                                                    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                                    {
                                                        //更新CMD_DTL
                                                        strSQL = "UPDATE CMD_DTL SET LOC = '" + strLoc + "' ";
                                                        strSQL += " WHERE CMD_SNO='" + strCmdSno + "' ";

                                                        if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                                                        {
                                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                            strMessage = "預約儲位-Success! Trace[" + clsTrace.cstrStoreInTrace_ItemOnStn + "]";
                                                        }
                                                        else
                                                        {
                                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                            strMessage = "預約儲位-更新Cmd_Dtl 失敗!";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                        strMessage = "預約儲位-更新CMD_Mst 失敗!";
                                                    }
                                                }
                                                else
                                                {
                                                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                    strMessage = "預約儲位-更新Loc_Mst 失敗!";
                                                }
                                                
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = strMessage;
                                                SystemTraceLog.CmdSno = strCmdSno;
                                                //SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                            else
                                            {
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "[Begin Fail]" + strEM;
                                                SystemTraceLog.CmdSno = strCmdSno;
                                                //SystemTraceLog.LocID = objBCRData[intStn, clsBCR.enuBCRLoc.Once].BCRID;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                            #endregion 預約儲位 、 更新CMD
                                            clsSystem.intBegin = 0;
                                        }
                                    }
                                    #endregion 預約儲位&命令
                                }
                                
                            }
                           
                            
                        }
                        #endregion 有物
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
        }

        /// <summary>
        /// 入庫-棧板到達站口寫入Crane命令
        /// </summary>
        private void funStockIn_ReleaseCraneCmd(int intPLCIndex)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            //string strPortNo = string.Empty;
            DataTable objDataTable = new DataTable();
            DataTable objDataTable_EquCmd = new DataTable();

            foreach(clsStnDef StnDef in lstInModeStnDef)
            {
                if (objDataTable != null)
                {
                    objDataTable.Clear();
                    objDataTable.Dispose();
                    objDataTable = null;
                }
                if (objDataTable_EquCmd != null)
                {
                    objDataTable_EquCmd.Clear();
                    objDataTable_EquCmd.Dispose();
                    objDataTable_EquCmd = null;
                }


                if ((intPLCIndex == 1 && StnDef.BufferIndex>24)||
                    (intPLCIndex == 2 && ((StnDef.BufferIndex <24) || (StnDef.BufferIndex > 60))) ||
                    (intPLCIndex == 3 && (StnDef.BufferIndex < 60)))
                {
                    continue;
                }

                
                clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);
                try
                {
                    
                    //大立光
                    if (objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnModeCode_Load &&
                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].Ready == (int)clsPLC2PCBuffer.enuReady.InReady &&
                        !string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno) &&
                        objBufferData.PLC2PCBuffer[StnDef.BufferIndex].StnMode == (int)clsPLC2PCBuffer.enuStnMode.InMode)
                    {
                        string strCmdSno = objBufferData.PLC2PCBuffer[StnDef.BufferIndex].LeftCmdSno.PadLeft(5, '0');
                        //v1.0.0.15
                        strSQL = "SELECT count(*) iCount FROM EQUCMD WHERE CMDSNO ='" + strCmdSno+"' AND CmdSts<'3'";
                        if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable_EquCmd, ref strEM) == ErrDef.ProcSuccess)
                        {
                            if (clsTool.funConvertToInt(objDataTable_EquCmd.Rows[0]["iCount"].ToString()) > 0)
                            {
                                continue;//命令已存在於EquCmd中跳出迴圈
                            }
                        }
                        #region Crane入庫
                        strSQL = "SELECT LOC,PRTY FROM CMD_MST WHERE CMD_STS<'3' AND (ROWNUM<2) AND CMD_SNO ='" + strCmdSno + "' AND CMD_MODE IN ('1', '3')";
                        strSQL += " AND TRACE = '" + clsTrace.cstrStoreInTrace_ItemOnStn + "' ORDER BY LOC DESC";
                        if (clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                        {
                            string strLoc = objDataTable.Rows[0]["LOC"].ToString();
                            string strPrt = objDataTable.Rows[0]["PRTY"].ToString();
                            string strPortno = StnDef.PortNo;
                            //if (strPortno.Length == 7)
                            //    strPortno = strPortno.Replace("0","");
                            //string strEquPort = (clsTool.Double(strPortno) / 3).ToString(); ;
                            //v1.0.0.16若Loc不足7碼就continue
                            if (strLoc.Length != 7)
                            {
                                continue;
                            }
                            if (funCheckLocMatchCrane(strLoc, StnDef.CraneNo, strCmdSno) &&
                                !funCheckEquCmdRepeat(StnDef.PortNo, StnDef.CraneNo, clsEquCmdMode.cstrInMode))
                            {
                                if (clsSystem.intBegin == 0)
                                {
                                    clsSystem.intBegin = 1;
                                    #region 更新Trace 和 新增EQUCMD
                                    if (clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Begin, ref strEM) == ErrDef.ProcSuccess)
                                    {
                                        if (funUpdateCmdTrace(strCmdSno, clsCmdSts.cstrCmdSts_Start, clsTrace.cstrStoreInTrace_ReleaseCraneCmd))
                                        {
                                            if (funInsertStockInEquCmd(StnDef.CraneNo, strCmdSno, strLoc, StnDef.PortNo, strPrt))
                                            {
                                                //更新字幕機Table
                                                //funMvsData(StnDef.StnNo, strCmdSno, "1", "1", "");
                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Commit);
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "Update Cmd Trace Success!";
                                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                            else
                                            {
                                                clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                                SystemTraceLog.LogMessage = "Release Equ Cmd Fail!";
                                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                                SystemTraceLog.CmdMode = clsEquCmdMode.cstrInMode;
                                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                            }
                                        }
                                        else
                                        {
                                            clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                            SystemTraceLog.LogMessage = "Update Cmd Trace Fail!";
                                            SystemTraceLog.LeftCmdSno = strCmdSno;
                                            SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                            SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                        }
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "[Begin Fail]:[funStockIn_ReleaseCraneCmd]" + strEM;
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }

                                    #endregion 更新Trace 和 新增EQUCMD
                                    clsSystem.intBegin = 0;
                                }

                            }
                            else
                            {
                                //更新EQUCMD失敗
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Update EquCmd  Fail!";
                                SystemTraceLog.LeftCmdSno = strCmdSno;
                                SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Start;
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                            }
                        }
                        #endregion Crane入庫
                    }
                    
                }
                catch(Exception ex)
                {
                    if (clsSystem.intBegin == 1)
                        clsSystem.intBegin = 0;
                    clsSystem.gobjDB.funCommitCtrl(DB.enuTrnType.Rollback);
                    var varObject = MethodBase.GetCurrentMethod();
                    clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Data.ToString());
                }
                finally
                {
                    if(objDataTable != null)
                    {
                        objDataTable.Clear();
                        objDataTable.Dispose();
                        objDataTable = null;
                    }
                    if (objDataTable_EquCmd != null)
                    {
                        objDataTable_EquCmd.Clear();
                        objDataTable_EquCmd.Dispose();
                        objDataTable_EquCmd = null;
                    }
                    if (SystemTraceLog != null)
                    {
                        SystemTraceLog = null;
                    }
                }
            }
        }

        /// <summary>
        /// 入庫-判斷Crane命令是否完成，並更新Trace
        /// </summary>
        private void funStockIn_CraneCmdFinish()
        {
            DataTable objDataTable = new DataTable();
            DataTable objCmd = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);
            string strSQL = string.Empty;
            string strEM = string.Empty;

            try
            {
                strSQL = "SELECT DISTINCT CMD_SNO , TRACE FROM CMD_MST WHERE CMD_MODE IN ('1','3') ";
                strSQL += "AND CMD_STS ='1' AND TRACE = '" + clsTrace.cstrStoreInTrace_ReleaseCraneCmd + "'";
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
                        if (SystemTraceLog != null)
                        {
                            SystemTraceLog = null;
                        }

                        string strCmdSno = objDataTable.Rows[intCount1]["CMD_SNO"].ToString();
                        objCmd = null;
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
                                        SystemTraceLog.LogMessage = "Crane Stock In Cmd Retry Success!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Crane Stock In Cmd Retry Fail!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_Init;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Equ Cmd CmdSts
                                }
                                else if(strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "EF")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    //v1.0.0.18 -2
                                    if (funUpdateCmdTrace_Abnormal(strCmdSno, clsCmdSts.cstrCmdSts_CancelWaitPost, clsTrace.cstrStoreInTrace_ReleaseCraneCmd,clsCmdAbnormal.cstrEF))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Stock In Cmd Finish![地上盤強制取消]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CancelWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Stock In Cmd Trace Fail![地上盤強制取消]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CancelWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    #endregion Update Cmd Trace CompletedWaitPost
                                }
                                else if (strCmdSts == clsCmdSts.cstrCmdSts_Completed && strCompleteCode == "FF")
                                {
                                    #region Update Cmd Trace CompletedWaitPost
                                    //v1.0.0.18 -2
                                    if (funUpdateCmdTrace_Abnormal(strCmdSno, clsCmdSts.cstrCmdSts_CompletedWaitPost, clsTrace.cstrStoreInTrace_ReleaseCraneCmd, clsCmdAbnormal.cstrFF))
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Stock In Cmd Finish![地上盤強制完成]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_ReleaseCraneCmd;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Stock In Cmd Trace Fail![地上盤強制完成]";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
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
                                        SystemTraceLog.LogMessage = "Stock In Cmd Finish!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_CraneCmdFinish;
                                        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                                    }
                                    else
                                    {
                                        SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                        SystemTraceLog.LogMessage = "Update Stock In Cmd Trace Fail!";
                                        SystemTraceLog.LeftCmdSno = strCmdSno;
                                        SystemTraceLog.CmdSts = clsCmdSts.cstrCmdSts_CompletedWaitPost;
                                        SystemTraceLog.Trace = clsTrace.cstrStoreInTrace_CraneCmdFinish;
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

        //private bool bolWeightRead(int BufferIndex, ref string strResult)
        //{
        //    strResult = "";
        //    uclWT objWeight;
        //    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);
        //    int intTimeOut = 0;
        //    switch (BufferIndex)
        //    {
        //        case 3: objWeight = uclWT_A_2L; break;
        //        case 7: objWeight = uclWT_A_4L; break;
        //        case 11: objWeight = uclWT_A_6L; break;
        //        default: return false;
        //    }
        //    bool bol = true;
        //    while (bol)
        //    {
        //        //if (objWeight.SendReq == 0)         //未通知讀取
        //        //{
        //        //    objWeight.SendReq = 1;
        //        //    SystemTraceLog.Weight = "己通知秤重機讀取重量";
        //        //    funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
        //        //    //SubWriTraceLog(true, "Crane(" + iCrn.ToString() + ") 己通知秤重機讀取重量 !! ");
        //        //    return false;
        //        //}
        //        if (objWeight.SendReq == 0)
        //        {
        //            objWeight.SendReq = 1;

        //            SystemTraceLog.Weight = "己通知秤重機讀取重量";
        //            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
        //        }

        //        if (objWeight.SendReq == 9)
        //        {
        //            strResult = objWeight.ReturnWeigtData;
        //            return true;
        //        }
        //        if (intTimeOut >= 10)
        //        {
        //            SystemTraceLog.Weight = "秤重機讀取失敗!";
        //            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
        //            return false;
        //        }
        //        intTimeOut++;
        //    }
        //    if (objWeight.SendReq == 0)         //未通知讀取
        //    {
        //        objWeight.SendReq = 1;
        //        SystemTraceLog.Weight = "己通知秤重機讀取重量";
        //        funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
        //        //SubWriTraceLog(true, "Crane(" + iCrn.ToString() + ") 己通知秤重機讀取重量 !! ");
        //        return false;
        //    }
        //    else if (objWeight.SendReq == 1)    //己通知讀取
        //    {
        //        return false;
        //    }
        //    else if (objWeight.SendReq == 9)
        //    {
        //        strResult = objWeight.ReturnWeigtData;
        //        return true;
        //    }
        //    return false;
        //}

        
        
    }
}

                       