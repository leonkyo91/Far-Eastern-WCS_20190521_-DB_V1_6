using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using Mirle.Library;

namespace Mirle.WinPLCCommu
{
    public partial class frmWinPLCCommu
    {
        /// <summary>
        /// 儲位自動整併
        /// </summary>
        private void funAutoMoveLoc()
        {
            for(int intCraneNo = 1; intCraneNo <= 3; intCraneNo++)
            {
                for(int intCraneRow = 1; intCraneRow <= 4; intCraneRow++)
                {
                    funAutoMoveLoc_ReleaseCmdWhenTemporaryIsFull(intCraneNo, intCraneRow);
                    funAutoMoveLoc_ReleaseCmdToTemporary(intCraneNo, intCraneRow);
                    funAutoMoveLoc_ReleaseCmdToNormal(intCraneNo, intCraneRow);
                }
            }
        }

        /// <summary>
        /// 儲位自動整併-將儲位狀態為H之儲位搬至週轉儲位
        /// </summary>
        /// <param name="CraneNo"></param>
        private void funAutoMoveLoc_ReleaseCmdToTemporary(int CraneNo, int CraneRow)
        {
            string strSQL = string.Empty;
            string strCount = string.Empty;
            string strEM = string.Empty;
            string strLoc = string.Empty;
            string strLocSts = string.Empty;
            string strLoc_Row = string.Empty;
            string strNewLoc = string.Empty;
            string strInsideLoc = string.Empty;
            string strToInsideLoc = string.Empty;
            string strIOType = string.Empty;
            string strLocSize = string.Empty;
            DataTable objLoc = new DataTable();

            try
            {
                strSQL = "SELECT LOC FROM LOC_MST WHERE LOCSTS='H' AND StorageTyp <> 'T'";
                strSQL += " AND LOC IN (SELECT LOC1 FROM LOC_MST WHERE LOCSTS <>'H')";
                switch(CraneNo)
                {
                    #region Crane儲位範圍
                    case 1:
                        strSQL += " AND LOC < '050000' AND CRANE_ROW='" + CraneRow + "'";
                        break;
                    case 2:
                        strSQL += " AND LOC > '050000' AND LOC < '090000'AND CRANE_ROW='" + CraneRow + "'";
                        break;
                    case 3:
                        strSQL += " AND LOC > '090000'AND CRANE_ROW='" + CraneRow + "'";
                        break;
                    default:
                        return;
                    #endregion Crane儲位範圍
                }
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objLoc, ref strEM) == ErrDef.ProcSuccess)
                {
                    objLoc = new DataTable();
                    strSQL = "SELECT COUNT(LOC) AS COUNT FROM CMD_MST WHERE CMDSTS < 9 AND IOTYP='" + clsIOType.cstrRtoR + "'";
                    switch(CraneNo)
                    {
                        #region Crane儲位範圍
                        case 1:
                            strSQL += " AND LOC < '050000'";
                            break;
                        case 2:
                            strSQL += " AND LOC > '050000'";
                            break;
                        case 3:
                            strSQL += " AND LOC > '090000'";
                            break;
                        default:
                            return;
                        #endregion Crane儲位範圍
                    }
                    if(clsSystem.gobjDB.funGetScalar(strSQL, ref strCount, ref strEM) == ErrDef.ProcSuccess)
                    {
                        if(int.Parse(strCount) == 0)
                        {
                            objLoc = new DataTable();
                            strSQL = "SELECT TOP 1 LOC, LOC_STS,Loc_Size FROM LOC_MST WHERE LOCSTS ='H' AND StorageTyp <> 'T'";
                            switch(CraneNo)
                            {
                                #region Crane儲位範圍
                                case 1:
                                    strSQL += " AND LOC < '050000' AND CRANE_ROW='" + CraneRow + "'";
                                    break;
                                case 2:
                                    strSQL += " AND LOC > '050000' AND LOC < '090000'AND CRANE_ROW='" + CraneRow + "'";
                                    break;
                                case 3:
                                    strSQL += " AND LOC > '090000'AND CRANE_ROW='" + CraneRow + "'";
                                    break;
                                default:
                                    return;
                                #endregion Crane儲位範圍
                            }
                            if(clsSystem.gobjDB.funGetDT(strSQL, ref objLoc, ref strEM) == ErrDef.ProcSuccess)
                            {
                                strLoc = objLoc.Rows[0]["LOC"].ToString();
                                strLocSts = objLoc.Rows[0]["LOC_STS"].ToString();
                                strLocSize = objLoc.Rows[0]["LOC_Size"].ToString();
                                strLoc_Row = strLoc.Substring(0, 2);

                                switch(CraneRow)
                                {
                                    #region 內儲位->直接庫對庫
                                    case 1:
                                    case 2:
                                        strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_HNNH, true, true, strLocSize,ref strSQL);
                                        if(string.IsNullOrWhiteSpace(strNewLoc))
                                        {
                                            strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, true, true, strLocSize,ref strSQL);
                                            if(!string.IsNullOrWhiteSpace(strNewLoc))
                                            {
                                                strToInsideLoc = (clsTool.funConvertToInt(strNewLoc.Substring(0, 2)) - 2).ToString().PadLeft(2, '0');
                                                strToInsideLoc += strNewLoc.Substring(2);
                                            }
                                        }
                                        if(!string.IsNullOrWhiteSpace(strNewLoc) && strLoc.Substring(2) != strNewLoc.Substring(2))
                                        {
                                            if(strLocSts == clsLocSts.cstrEmptyStored)
                                                strIOType = clsIOType.cstrRtoR;
                                            else if(strLocSts == clsLocSts.cstrStored)
                                                strIOType = clsIOType.cstrRtoR;
                                            else if(strLocSts == clsLocSts.cstrRevision)
                                                strIOType = clsIOType.cstrRtoR;
                                            else
                                                break;

                                            funInsertLocToLocCmd(strLoc, strNewLoc, strIOType, "5",
                                                strToInsideLoc, clsLocSts.cstrEmpty, clsLocSts.cstrRevisionReserved);
                                        }
                                        break;
                                    #endregion 內儲位->直接庫對庫

                                    #region 外儲位->先搬內儲位再搬外儲位
                                    case 3:
                                    case 4:
                                        strInsideLoc = (clsTool.funConvertToInt(strLoc_Row) - 2).ToString().PadLeft(2, '0');
                                        strInsideLoc += strLoc.Substring(2);

                                        string strInsideLocSts = funCheckInsideLocSts(strLoc, strLoc_Row);

                                        if(strInsideLocSts == clsLocSts.cstrEmptyStored || strInsideLocSts == clsLocSts.cstrStored)
                                        {
                                            #region 內儲位有物
                                            if(strInsideLocSts == clsLocSts.cstrStored)
                                                strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_SNNS, true, true,strLocSize,ref strSQL);
                                            else if(strInsideLocSts == clsLocSts.cstrEmptyStored)
                                                strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_ENNE, true, true,strLocSize,ref strSQL);
                                            if(string.IsNullOrWhiteSpace(strNewLoc))
                                            {
                                                strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, true, true,strLocSize,ref strSQL);
                                                if(!string.IsNullOrWhiteSpace(strNewLoc))
                                                {
                                                    strToInsideLoc = (clsTool.funConvertToInt(strNewLoc.Substring(0, 2)) - 2).ToString().PadLeft(2, '0');
                                                    strToInsideLoc += strNewLoc.Substring(2);
                                                }
                                            }

                                            if(!string.IsNullOrWhiteSpace(strNewLoc) && strLoc.Substring(2) != strNewLoc.Substring(2))
                                            {
                                                if(strInsideLocSts == clsLocSts.cstrEmptyStored)
                                                    strIOType = clsIOType.cstrRtoR;
                                                else if(strInsideLocSts == clsLocSts.cstrStored)
                                                    strIOType = clsIOType.cstrRtoR;
                                                else if(strInsideLocSts == clsLocSts.cstrRevision)
                                                    strIOType = clsIOType.cstrRtoR;
                                                else
                                                    break;

                                                funInsertLocToLocCmd(strInsideLoc, strNewLoc, strIOType, "5",
                                                    strToInsideLoc, clsLocSts.cstrEmpty, clsLocSts.cstrRevisionReserved);
                                            }
                                            #endregion 內儲位有物
                                        }
                                        else if(strInsideLocSts == clsLocSts.cstrEmpty)
                                        {
                                            #region 內儲位無物
                                            strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_HNNH, true, true, strLocSize, ref strSQL);
                                            if(string.IsNullOrWhiteSpace(strNewLoc))
                                            {
                                                strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, true, true, strLocSize, ref strSQL);
                                                if(!string.IsNullOrWhiteSpace(strNewLoc))
                                                {
                                                    strToInsideLoc = (clsTool.funConvertToInt(strNewLoc.Substring(0, 2)) - 2).ToString().PadLeft(2, '0');
                                                    strToInsideLoc += strNewLoc.Substring(2);
                                                }
                                            }

                                            if(!string.IsNullOrWhiteSpace(strNewLoc) && strLoc.Substring(2) != strNewLoc.Substring(2))
                                            {
                                                if(strLocSts == clsLocSts.cstrEmptyStored)
                                                    strIOType = clsIOType.cstrRtoR;
                                                else if(strLocSts == clsLocSts.cstrStored)
                                                    strIOType = clsIOType.cstrRtoR;
                                                else if(strLocSts == clsLocSts.cstrRevision)
                                                    strIOType = clsIOType.cstrRtoR;
                                                else
                                                    break;

                                                funInsertLocToLocEquCmd(strLoc, strNewLoc, strIOType, "5",
                                                    strInsideLoc, strToInsideLoc, clsLocSts.cstrEmpty, clsLocSts.cstrRevisionReserved);
                                            }
                                            #endregion 內儲位無物
                                        }
                                        break;
                                    #endregion 外儲位->先搬內儲位再搬外儲位
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
                if(objLoc != null)
                {
                    objLoc.Clear();
                    objLoc.Dispose();
                    objLoc = null;
                }
            }
        }

        /// <summary>
        /// 儲位自動整併-將週轉儲位(兩板)搬至一般儲位
        /// </summary>
        /// <param name="CraneNo"></param>
        private void funAutoMoveLoc_ReleaseCmdToNormal(int CraneNo, int CraneRow)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strLoc = string.Empty;
            string strNewLoc = string.Empty;
            string strFromLoc_L = string.Empty;
            string strFromLoc_R = string.Empty;
            string strToLoc_L = string.Empty;
            string strToLoc_R = string.Empty;
            string strLocSize = string.Empty;
            DataTable objCmdSno = new DataTable();
            DataTable objLoc = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);

            try
            {
                strSQL = "SELECT LOC FROM CMD_MST WHERE CMD_MODE='5' AND CMD_STS < '9'";
                switch(CraneNo)
                {
                    #region Crane儲位範圍
                    case 1:
                        strSQL += " AND LOC < '050000'";
                        break;
                    case 2:
                        strSQL += " AND LOC > '050000'";
                        break;
                    case 3:
                        strSQL += " AND LOC > '090000'";
                        break;
                    default:
                        return;
                    #endregion Crane儲位範圍
                }
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objCmdSno, ref strEM) == (int)ErrDef.enuDBEC.NoDataSelect)
                {
                    strSQL = "SELECT TOP 1 LOC,Crane_No,Crane_Row,Loc_Size FROM LOC_MST WHERE LOC_STS='H'";
                    strSQL += " AND LOC IN (SELECT LOC FROM LOC_MST WHERE LOC_STS='H') AND Storage_Typ='T'";
                    switch(CraneNo)
                    {
                        #region Crane儲位範圍
                        case 1:
                            strSQL += " AND LOC < '050000'";
                            break;
                        case 2:
                            strSQL += " AND LOC > '050000' AND LOC < '090000'";
                            break;
                        case 3:
                            strSQL += " AND LOC > '090000'";
                            break;
                        default:
                            return;
                        #endregion Crane儲位範圍
                    }
                    if(clsSystem.gobjDB.funGetDT(strSQL, ref objLoc, ref strEM) == ErrDef.ProcSuccess)
                    {
                        strLoc = objLoc.Rows[0]["LOC"].ToString();
                        strLocSize = objLoc.Rows[0]["Loc_Size"].ToString();
                        strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, false, false, strLocSize,ref strSQL);
                        if(!string.IsNullOrWhiteSpace(strNewLoc))
                        {
                            #region 來源儲位
                            if(strLoc.Substring(0, 2) == "01")
                            {
                                strFromLoc_L = "03" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "02")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "04" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "03")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "01" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "04")
                            {
                                strFromLoc_L = "02" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "05")
                            {
                                strFromLoc_L = "07" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "06")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "08" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "07")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "05" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "08")
                            {
                                strFromLoc_L = "06" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "09")
                            {
                                strFromLoc_L = "11" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "10")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "12" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "11")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "09" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "12")
                            {
                                strFromLoc_L = "10" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            #endregion 來源儲位

                            #region 目的儲位
                            if(strNewLoc.Substring(0, 2) == "01")
                            {
                                strToLoc_L = "03" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "02")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "04" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "03")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "01" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "04")
                            {
                                strToLoc_L = "02" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "05")
                            {
                                strToLoc_L = "07" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "06")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "08" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "07")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "05" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "08")
                            {
                                strToLoc_L = "06" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "09")
                            {
                                strToLoc_L = "11" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "10")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "12" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "11")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "09" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "12")
                            {
                                strToLoc_L = "10" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            #endregion 目的儲位

                            if(!string.IsNullOrWhiteSpace(strFromLoc_L) && !string.IsNullOrWhiteSpace(strFromLoc_R) &&
                                !string.IsNullOrWhiteSpace(strToLoc_L) && !string.IsNullOrWhiteSpace(strToLoc_R))
                            {
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Moving Temporary Loc To Normal Loc!";
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                funInsertLocToLocCmd(strFromLoc_L, strFromLoc_R, strToLoc_L, strToLoc_R, clsLocSts.cstrRevision);
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
                if(objLoc != null)
                {
                    objLoc.Clear();
                    objLoc.Dispose();
                    objLoc = null;
                }
                if(objCmdSno != null)
                {
                    objCmdSno.Clear();
                    objCmdSno.Dispose();
                    objCmdSno = null;
                }
            }
        }

        private void funAutoMoveLoc_ReleaseCmdWhenTemporaryIsFull(int CraneNo, int CraneRow)
        {
            bool bolCmdFlag = false;
            bool bolLocCount = false;
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strCount = string.Empty;
            string strLoc = string.Empty;
            string strLoc_Row = string.Empty;
            string strCrane_Row = string.Empty;
            string strLocSts = string.Empty;
            string strNewLoc = string.Empty;
            string strInsideLoc = string.Empty;
            string strInsideLocSts = string.Empty;
            string strToInsideLoc = string.Empty;
            string strFromLoc_L = string.Empty;
            string strFromLoc_R = string.Empty;
            string strToLoc_L = string.Empty;
            string strToLoc_R = string.Empty;
            string strIOType = string.Empty;
            string strLocSize = string.Empty;
            DataTable objLoc = new DataTable();
            DataTable objCmdSno = new DataTable();
            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.None);

            try
            {
                strSQL = "SELECT LOC FROM CMD_MST WHERE CMDMODE='5' AND CMDSTS < '9'";
                switch(CraneNo)
                {
                    #region Crane儲位範圍
                    case 1:
                        strSQL += " AND LOC < '050000'";
                        break;
                    case 2:
                        strSQL += " AND LOC > '050000'";
                        break;
                    case 3:
                        strSQL += " AND LOC > '090000'";
                        break;
                    default:
                        return;
                    #endregion Crane儲位範圍
                }
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objCmdSno, ref strEM) == (int)ErrDef.enuDBEC.NoDataSelect)
                    bolCmdFlag = false;
                else
                    bolCmdFlag = true;

                strSQL = "SELECT COUNT(LOC) AS LOC FROM LOC_MST WHERE STORAGETYP='T' AND LOCSTS='N'";
                strSQL += " AND LOC IN (SELECT LOC1 FROM LOC_MST WHERE LOCSTS='N')";
                switch(CraneNo)
                {
                    #region Crane儲位範圍
                    case 1:
                        strSQL += " AND LOC < '050000' AND CRANE_ROW='" + CraneRow + "'";
                        break;
                    case 2:
                        strSQL += " AND LOC > '050000' AND LOC < '090000'AND CRANE_ROW='" + CraneRow + "'";
                        break;
                    case 3:
                        strSQL += " AND LOC > '090000'AND CRANE_ROW='" + CraneRow + "'";
                        break;
                    default:
                        return;
                    #endregion Crane儲位範圍
                }
                if(clsSystem.gobjDB.funGetScalar(strSQL, ref strCount, ref strEM) == ErrDef.ProcSuccess)
                {
                    if(int.Parse(strCount) > 0)
                        bolLocCount = true;
                    else
                        bolLocCount = false;
                }

                if(!bolCmdFlag || (bolCmdFlag && !bolLocCount))
                {
                    funRepairLocation(CraneNo, CraneRow);

                    #region 先找內外儲位為'S'
                    objLoc = new DataTable();
                    strSQL = "SELECT TOP 1 LOC, Crane_No, Crane_Row,Loc_Size FROM LOC_MST WHERE LOCSTS='S'";
                    strSQL += " AND LOC IN (SELECT LOC1 FROM LOC_MST WHERE LOCSTS='S') AND StorageTyp='T'";
                    switch(CraneNo)
                    {
                        #region Crane儲位範圍
                        case 1:
                            strSQL += " AND LOC < '050000' ORDER BY LOC ";
                            break;
                        case 2:
                            strSQL += " AND LOC > '050000' AND LOC < '090000' ORDER BY LOC ";
                            break;
                        case 3:
                            strSQL += " AND LOC > '090000' ORDER BY LOC ";
                            break;
                        default:
                            return;
                        #endregion Crane儲位範圍
                    }
                    if(clsSystem.gobjDB.funGetDT(strSQL, ref objLoc, ref strEM) == ErrDef.ProcSuccess)
                    {
                        strLoc = objLoc.Rows[0]["LOC"].ToString();
                        strLocSize = objLoc.Rows[0]["Loc_Size"].ToString();
                        strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, false, false, strLocSize, ref strSQL);

                        if(!string.IsNullOrWhiteSpace(strNewLoc))
                        {
                            #region 來源儲位
                            if(strLoc.Substring(0, 2) == "01")
                            {
                                strFromLoc_L = "03" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "02")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "04" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "03")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "01" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "04")
                            {
                                strFromLoc_L = "02" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "05")
                            {
                                strFromLoc_L = "07" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "06")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "08" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "07")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "05" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "08")
                            {
                                strFromLoc_L = "06" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "09")
                            {
                                strFromLoc_L = "11" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "10")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "12" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "11")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "09" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "12")
                            {
                                strFromLoc_L = "10" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            #endregion 來源儲位

                            #region 目的儲位
                            if(strNewLoc.Substring(0, 2) == "01")
                            {
                                strToLoc_L = "03" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "02")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "04" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "03")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "01" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "04")
                            {
                                strToLoc_L = "02" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "05")
                            {
                                strToLoc_L = "07" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "06")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "08" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "07")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "05" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "08")
                            {
                                strToLoc_L = "06" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "09")
                            {
                                strToLoc_L = "11" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "10")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "12" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "11")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "09" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "12")
                            {
                                strToLoc_L = "10" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            #endregion 目的儲位

                            if(!string.IsNullOrWhiteSpace(strFromLoc_L) && !string.IsNullOrWhiteSpace(strFromLoc_R) &&
                                !string.IsNullOrWhiteSpace(strToLoc_L) && !string.IsNullOrWhiteSpace(strToLoc_R))
                            {
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Moving Temporary Loc To Normal Loc!";
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                funInsertLocToLocCmd(strFromLoc_L, strFromLoc_R, strToLoc_L, strToLoc_R, clsLocSts.cstrStored);
                            }
                        }
                    }
                    #endregion 先找內外儲位為'S'

                    #region 在找內外儲位為'E'
                    objLoc = new DataTable();
                    strSQL = "SELECT TOP 1 LOC, Crane_No, Crane_Row,Loc_Size FROM LOC_MST WHERE LOCSTS='E'";
                    strSQL += " AND LOC IN (SELECT LOC1 FROM LOC_MST WHERE LOCSTS='E') AND StorageTyp='T'";
                    switch(CraneNo)
                    {
                        #region Crane儲位範圍
                        case 1:
                            strSQL += " AND LOC < '050000' AND CRANE_ROW='" + CraneRow + "'";
                            break;
                        case 2:
                            strSQL += " AND LOC > '050000' AND LOC < '090000'AND CRANE_ROW='" + CraneRow + "'";
                            break;
                        case 3:
                            strSQL += " AND LOC > '090000'AND CRANE_ROW='" + CraneRow + "'";
                            break;
                        default:
                            return;
                        #endregion Crane儲位範圍
                    }
                    if(clsSystem.gobjDB.funGetDT(strSQL, ref objLoc, ref strEM) == ErrDef.ProcSuccess)
                    {
                        strLoc = objLoc.Rows[0]["LOC"].ToString();
                        strLocSize = objLoc.Rows[0]["Loc_Size"].ToString();
                        strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, false, false, strLocSize, ref strSQL);
                        if(!string.IsNullOrWhiteSpace(strNewLoc))
                        {
                            #region 來源儲位
                            if(strLoc.Substring(0, 2) == "01")
                            {
                                strFromLoc_L = "03" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "02")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "04" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "03")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "01" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "04")
                            {
                                strFromLoc_L = "02" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "05")
                            {
                                strFromLoc_L = "07" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "06")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "08" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "07")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "05" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "08")
                            {
                                strFromLoc_L = "06" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "09")
                            {
                                strFromLoc_L = "11" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            else if(strLoc.Substring(0, 2) == "10")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "12" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "11")
                            {
                                strFromLoc_L = strLoc;
                                strFromLoc_R = "09" + strLoc.Substring(2, 4);
                            }
                            else if(strLoc.Substring(0, 2) == "12")
                            {
                                strFromLoc_L = "10" + strLoc.Substring(2, 4);
                                strFromLoc_R = strLoc;
                            }
                            #endregion 來源儲位

                            #region 目的儲位
                            if(strNewLoc.Substring(0, 2) == "01")
                            {
                                strToLoc_L = "03" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "02")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "04" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "03")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "01" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "04")
                            {
                                strToLoc_L = "02" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "05")
                            {
                                strToLoc_L = "07" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "06")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "08" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "07")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "05" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "08")
                            {
                                strToLoc_L = "06" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "09")
                            {
                                strToLoc_L = "11" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            else if(strNewLoc.Substring(0, 2) == "10")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "12" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "11")
                            {
                                strToLoc_L = strNewLoc;
                                strToLoc_R = "09" + strNewLoc.Substring(2, 4);
                            }
                            else if(strNewLoc.Substring(0, 2) == "12")
                            {
                                strToLoc_L = "10" + strNewLoc.Substring(2, 4);
                                strToLoc_R = strNewLoc;
                            }
                            #endregion 目的儲位

                            if(!string.IsNullOrWhiteSpace(strFromLoc_L) && !string.IsNullOrWhiteSpace(strFromLoc_R) &&
                                !string.IsNullOrWhiteSpace(strToLoc_L) && !string.IsNullOrWhiteSpace(strToLoc_R))
                            {
                                SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                                SystemTraceLog.LogMessage = "Moving Temporary Loc To Normal Loc!";
                                funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);
                                funInsertLocToLocCmd(strFromLoc_L, strFromLoc_R, strToLoc_L, strToLoc_R, clsLocSts.cstrEmptyStored);
                            }
                        }
                    }
                    #endregion 在找內外儲位為'E'

                    #region 一般區單一儲位移到一般區
                    objLoc = new DataTable();
                    strSQL = "SELECT TOP 1 LOC, LOC_STS, CRANE_ROW,Loc_Size FROM LOC_MST WHERE LOCSTS IN ('S','E')";
                    strSQL += " AND LOC IN (SELECT LOC1 FROM LOC_MST WHERE LOCSTS='N') AND StorageTyp <> 'T'";
                    switch(CraneNo)
                    {
                        #region Crane儲位範圍
                        case 1:
                            strSQL += " AND LOC < '050000' AND CRANE_ROW='" + CraneRow + "'";
                            break;
                        case 2:
                            strSQL += " AND LOC > '050000' AND LOC < '090000'AND CRANE_ROW='" + CraneRow + "'";
                            break;
                        case 3:
                            strSQL += " AND LOC > '090000'AND CRANE_ROW='" + CraneRow + "'";
                            break;
                        default:
                            return;
                        #endregion Crane儲位範圍
                    }
                    if(clsSystem.gobjDB.funGetDT(strSQL, ref objLoc, ref strEM) == ErrDef.ProcSuccess)
                    {
                        strLoc = objLoc.Rows[0]["LOC"].ToString();
                        strLocSts = objLoc.Rows[0]["LOC_STS"].ToString();
                        strLoc_Row = strLoc.Substring(0, 2);
                        strLocSize = objLoc.Rows[0]["LOC_Size"].ToString();
                        if(CraneRow == 3 || CraneRow == 4 || CraneRow == 7 || CraneRow == 8 || CraneRow == 11 | CraneRow == 12)
                        {
                            strInsideLoc = (clsTool.funConvertToInt(strLoc_Row) - 2).ToString().PadLeft(2, '0') + strLoc.Substring(2);
                            strInsideLocSts = funCheckInsideLocSts(strLoc, strLoc_Row);
                        }

                        if(strLocSts == clsLocSts.cstrStored)
                            strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_SNNS, false, true, strLocSize, ref strSQL);
                        else if(strLocSts == clsLocSts.cstrEmptyStored)
                            strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_ENNE, false, true, strLocSize, ref strSQL);

                        if(string.IsNullOrWhiteSpace(strNewLoc))
                        {
                            strNewLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, false, true, strLocSize, ref strSQL);
                            if(!string.IsNullOrWhiteSpace(strNewLoc))
                                strToInsideLoc = (clsTool.funConvertToInt(strNewLoc.Substring(0, 2)) - 2).ToString().PadLeft(2, '0') + strNewLoc.Substring(2);
                        }

                        if(!string.IsNullOrWhiteSpace(strNewLoc) && strLoc.Substring(2) != strNewLoc.Substring(2))
                        {
                            if(strLocSts == clsLocSts.cstrEmpty)
                                strIOType = clsIOType.cstrRtoR;
                            else if(strLocSts == clsLocSts.cstrStored)
                                strIOType = clsIOType.cstrRtoR;
                            else if(strLocSts == clsLocSts.cstrRevision)
                                strIOType = clsIOType.cstrRtoR;

                            SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            SystemTraceLog.LogMessage = "Auto Moving Single Loc To Normal Loc!";
                            funShowSystemTrace(lsbSystemTrace, SystemTraceLog, true);

                            funInsertLocToLocEquCmd(strLoc, strNewLoc, strIOType, "5", strInsideLoc,
                                strToInsideLoc, clsLocSts.cstrEmpty, clsLocSts.cstrRevisionReserved);
                        }
                    }
                    #endregion 一般區單一儲位移到一般區
                }
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                if(objCmdSno != null)
                {
                    objCmdSno.Clear();
                    objCmdSno.Dispose();
                    objCmdSno = null;
                }
                if(objLoc != null)
                {
                    objLoc.Clear();
                    objLoc.Dispose();
                    objLoc = null;
                }
            }
        }

        private void funRepairLocation(int CraneNo, int CraneRow)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            DataTable objLoc = new DataTable();

            try
            {
                strSQL = "SELECT LOC, LOC_STS,LOC_SIZE FROM LOC_MST";

                #region 確認CraneRow
                switch(CraneNo)
                {
                    case 1:
                        switch(CraneRow)
                        {
                            case 1:
                            case 3:
                                strSQL += " WHERE LOC ='" + clsSystem.gstrRepairLoc1 + "'";
                                break;
                            case 2:
                            case 4:
                                strSQL += " WHERE LOC ='" + clsSystem.gstrRepairLoc2 + "'";
                                break;
                            default:
                                return;
                        }
                        break;
                    case 2:
                        switch(CraneRow)
                        {
                            case 1:
                            case 3:
                                strSQL += " WHERE LOC ='" + clsSystem.gstrRepairLoc3 + "'";
                                break;
                            case 2:
                            case 4:
                                strSQL += " WHERE LOC ='" + clsSystem.gstrRepairLoc4 + "'";
                                break;
                            default:
                                return;
                        }
                        break;
                    case 3:
                        switch(CraneRow)
                        {
                            case 1:
                            case 3:
                                strSQL += " WHERE LOC ='" + clsSystem.gstrRepairLoc5 + "'";
                                break;
                            case 2:
                            case 4:
                                strSQL += " WHERE LOC ='" + clsSystem.gstrRepairLoc6 + "'";
                                break;
                            default:
                                return;
                        }
                        break;
                    default:
                        return;
                }
                #endregion 確認CraneRow

                if(clsSystem.gobjDB.funGetDT(strSQL, ref objLoc, ref strEM) == ErrDef.ProcSuccess)
                {
                    string strRepairLoc = objLoc.Rows[0]["LOC"].ToString();
                    string strLocSts = objLoc.Rows[0]["LOC_STS"].ToString();
                    string strLocSize = objLoc.Rows[0]["LOC_Size"].ToString();

                    if(strLocSts == clsLocSts.cstrEmptyStored || strLocSts == clsLocSts.cstrStored)
                        funRepairLocation(CraneNo, CraneRow, strRepairLoc, strLocSts,strLocSize);
                    else if(strLocSts == clsLocSts.cstrEmpty)
                        funRepairLocation(CraneNo, CraneRow, strRepairLoc, strLocSize, strLocSize);
                }
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
            finally
            {
                if(objLoc != null)
                {
                    objLoc.Clear();
                    objLoc.Dispose();
                    objLoc = null;
                }
            }
        }

     

        private void funRepairLocation(int CraneNo, int CraneRow, string RepairLoc, string LocSts,string LocSize)
        {
            string strRow_X = string.Empty;
            string strLoc = string.Empty;
            string strToInsideLoc = string.Empty;
            string strIoType = string.Empty;
            string sSQL = string.Empty;
            try
            {
                strRow_X = RepairLoc.Substring(0, 2);
                if(LocSts == clsLocSts.cstrStored)
                {
                    strLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_SNNS, true, true, LocSize, ref sSQL);
                    if(string.IsNullOrWhiteSpace(strLoc))
                        strLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, true, true, LocSize, ref sSQL);
                    if(string.IsNullOrWhiteSpace(strLoc))
                        strLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_SNNS, false, true, LocSize, ref sSQL);
                    if(string.IsNullOrWhiteSpace(strLoc))
                    {
                        strLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, false, true, LocSize, ref sSQL);
                        if(!string.IsNullOrWhiteSpace(strLoc))
                            strToInsideLoc = (clsTool.funConvertToInt(strLoc.Substring(0, 2)) - 2).ToString().PadLeft(2, '0') + strLoc.Substring(2);
                    }
                }
                else if(LocSts == clsLocSts.cstrEmptyStored)
                {
                    strLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_ENNE, true, true, LocSize, ref sSQL);
                    if(string.IsNullOrWhiteSpace(strLoc))
                        strLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, true, true, LocSize, ref sSQL);
                    if(string.IsNullOrWhiteSpace(strLoc))
                        strLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_ENNE, false, true, LocSize, ref sSQL);
                    if(string.IsNullOrWhiteSpace(strLoc))
                    {
                        strLoc = funGetEmptyLoc(CraneNo, CraneRow, clsLocSts.cstrLoc_NNNN, false, true, LocSize, ref sSQL);
                        if(!string.IsNullOrWhiteSpace(strLoc))
                            strToInsideLoc = (clsTool.funConvertToInt(strLoc.Substring(0, 2)) - 2).ToString().PadLeft(2, '0') + strLoc.Substring(2);
                    }
                }

                if(!string.IsNullOrWhiteSpace(strLoc) && RepairLoc.Substring(2) != strLoc.Substring(2))
                {
                    if(LocSts == clsLocSts.cstrEmptyStored)
                        strIoType = clsIOType.cstrRtoR;
                    else if(LocSts == clsLocSts.cstrStored)
                        strIoType = clsIOType.cstrRtoR;
                    else if(LocSts == clsLocSts.cstrRevision)
                        strIoType = clsIOType.cstrRtoR;
                    if(!string.IsNullOrWhiteSpace(strIoType))
                        funInsertLocToLocCmd(RepairLoc, strLoc, strIoType, "5", strToInsideLoc, clsLocSts.cstrEmpty, clsLocSts.cstrRevisionReserved);
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
