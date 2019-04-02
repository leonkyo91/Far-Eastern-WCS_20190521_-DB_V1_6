using System;
using System.Collections.Generic;
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
        /// 寫入PC To PLC HandShaking
        /// </summary>
        /// <param name="HandShake_Address">交握訊號位置</param>
        /// <param name="SetData">寫入PLC資料</param>
        /// <returns></returns>
        private void funWritePC2PLC_HandShake(string str,int iPLCNo)
        {
            string strAddress = string.Empty;
            //if(funGetWritePC2PLCAddress("System", ref strAddress))
            //{
            //    if(!clsSystem.gobjPLC.funWritePLC(strAddress, str))
            //    {
            //        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
            //        SystemTraceLog.LogMessage = "Write PLC HandShaking Fail!";
            //        SystemTraceLog.BufferName = "System";
            //        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
            //    }
            //}
            switch (iPLCNo)
            {
                case 1:

                    if (!clsSystem.gobjPLC.funWritePLC("D3000", str))
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Write PLC1 HandShaking Fail!";
                        SystemTraceLog.BufferName = "System";
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                    }
                    break;
                case 2:
                    if (!clsSystem.gobjPLC2.funWritePLC("D100", str))
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Write PLC2 HandShaking Fail!";
                        SystemTraceLog.BufferName = "System";
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                    }
                    break;
                case 3:
                    if (!clsSystem.gobjPLC3.funWritePLC("D100", str))
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Write PLC3 HandShaking Fail!";
                        SystemTraceLog.BufferName = "System";
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                    }
                    break;
            }
            
           
        }

        /// <summary>
        /// 寫入PLC時間
        /// </summary>
        /// <returns></returns>
        private void funWritePLCSetDateTime(int iPLCNo)
        {
            string strYear = DateTime.Now.ToString("yy");
            string strMon = DateTime.Now.ToString("MM");
            string strDay = DateTime.Now.ToString("dd");
            string strHour = DateTime.Now.ToString("HH");
            string strMin = DateTime.Now.ToString("mm");
            string strAddress = string.Empty;

            if(funGetWritePC2PLCAddress("System", clsPLC.enuAddressSection.DataTime, ref strAddress))
            {
                switch (iPLCNo)
                {
                    case 1:
                        if (!clsSystem.gobjPLC.funWritePLC(strAddress, strYear, strMon, strDay, strHour, strMin))
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                            SystemTraceLog.LogMessage = "Write PLC1 DateTime Fail!";
                            SystemTraceLog.BufferName = "System";
                            funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                            SystemTraceLog = null;
                        }
                        break;
                    case 2:
                        if (!clsSystem.gobjPLC2.funWritePLC(strAddress, strYear, strMon, strDay, strHour, strMin))
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                            SystemTraceLog.LogMessage = "Write PLC2 DateTime Fail!";
                            SystemTraceLog.BufferName = "System";
                            funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                            SystemTraceLog = null;
                        }
                        break;
                    case 3:
                        if (!clsSystem.gobjPLC3.funWritePLC(strAddress, strYear, strMon, strDay, strHour, strMin))
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                            SystemTraceLog.LogMessage = "Write PLC3 DateTime Fail!";
                            SystemTraceLog.BufferName = "System";
                            funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                            SystemTraceLog = null;
                        }
                        break;
                }
                
            }
        }

        /// <summary>
        /// 清除 PC->PLC 的PLC Singel
        /// </summary>
        /// <param name="BufferName"></param>
        private void funRefreshPC2PLCSingel(string BufferName)
        {
            string strAddress = string.Empty;
            if(funGetWritePC2PLCAddress(BufferName, ref strAddress))
            {
                string[] strarrValues = new string[] { "0", "0", "0"};
                if (BufferName.Substring(0, 1) == "A" || BufferName.Substring(0, 1) == "B")
                {
                    if (clsSystem.gobjPLC.funWritePLC(strAddress, strarrValues))
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Refresh PLC Success!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = strarrValues;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                    }
                    else
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Refresh PLC Fail!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = strarrValues;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                    }
                }
                if (BufferName.Substring(0, 1) == "C" || BufferName.Substring(0, 1) == "D" || BufferName.Substring(0, 1) == "E")
                {
                    if (clsSystem.gobjPLC2.funWritePLC(strAddress, strarrValues))
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Refresh PLC Success!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = strarrValues;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                    }
                    else
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Refresh PLC Fail!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = strarrValues;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                    }
                }
                else
                {
                    if (clsSystem.gobjPLC3.funWritePLC(strAddress, strarrValues))
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Refresh PLC Success!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = strarrValues;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                    }
                    else
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Refresh PLC Fail!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = strarrValues;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                    }
                }
                
                strarrValues = null;
            }
        }

        #region funWritePLCSingel
        /// <summary>
        /// 寫入 PC->PLC 
        /// </summary>
        /// <param name="BufferName"></param>
        /// <param name="Values"></param>
        /// <returns></returns>
        private bool funWritePC2PLCSingel(string BufferName, params string[] Values)
        {
            string strAddress = string.Empty;
            if(funGetWritePC2PLCAddress(BufferName, ref strAddress))
            {
                if (BufferName.Substring(0, 1) == "A" || BufferName.Substring(0, 1) == "B")
                {
                    if (clsSystem.gobjPLC.funWritePLC(strAddress, Values))
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Write PLC Success!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = Values;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                        return true;
                    }
                    else
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Write PLC Fail!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = Values;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                        return false;
                    }
                }
                else if (BufferName.Substring(0, 1) == "C" || BufferName.Substring(0, 1) == "D" || BufferName.Substring(0, 1) == "E")
                {
                    if (clsSystem.gobjPLC2.funWritePLC(strAddress, Values))
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Write PLC Success!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = Values;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                        return true;
                    }
                    else
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Write PLC Fail!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = Values;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                        return false;
                    }
                }
                else
                {
                    if (clsSystem.gobjPLC3.funWritePLC(strAddress, Values))
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Write PLC Success!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = Values;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                        return true;
                    }
                    else
                    {
                        clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                        SystemTraceLog.LogMessage = "Write PLC Fail!";
                        SystemTraceLog.BufferName = BufferName;
                        SystemTraceLog.PLCValues = Values;
                        funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                        SystemTraceLog = null;
                        return false;
                    }
                }
                
            }
            else
                return false;
        }

        /// <summary>
        /// 從特定位置寫入 PC->PLC
        /// </summary>
        /// <param name="BufferName"></param>
        /// <param name="Section"></param>
        /// <param name="PLCValues"></param>
        /// <returns></returns>
        private bool funWritePC2PLCSingel(int iPLCNo, string BufferName, clsPLC.enuAddressSection Section, params string[] PLCValues)
        {
            string strAddress = string.Empty;
            if(funGetWritePC2PLCAddress(BufferName, Section, ref strAddress))
            {
                switch(iPLCNo)
                {
                    case 1:
                        if(clsSystem.gobjPLC.funWritePLC(strAddress, PLCValues))
                {
                    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                    SystemTraceLog.LogMessage = "Write PLC Success!";
                    SystemTraceLog.BufferName = BufferName;
                    SystemTraceLog.AddressSection = Section.ToString();
                    SystemTraceLog.PLCValues = PLCValues;
                    funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                    SystemTraceLog = null;
                    return true;
                }
                else
                {
                    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                    SystemTraceLog.LogMessage = "Write PLC Fail!";
                    SystemTraceLog.BufferName = BufferName;
                    SystemTraceLog.AddressSection = Section.ToString();
                    SystemTraceLog.PLCValues = PLCValues;
                    funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                    SystemTraceLog = null;
                    return false;
                }
                        break;
                    case 2:
                        if(clsSystem.gobjPLC2.funWritePLC(strAddress, PLCValues))
                {
                    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                    SystemTraceLog.LogMessage = "Write PLC Success!";
                    SystemTraceLog.BufferName = BufferName;
                    SystemTraceLog.AddressSection = Section.ToString();
                    SystemTraceLog.PLCValues = PLCValues;
                    funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                    SystemTraceLog = null;
                    return true;
                }
                else
                {
                    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                    SystemTraceLog.LogMessage = "Write PLC Fail!";
                    SystemTraceLog.BufferName = BufferName;
                    SystemTraceLog.AddressSection = Section.ToString();
                    SystemTraceLog.PLCValues = PLCValues;
                    funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                    SystemTraceLog = null;
                    return false;
                }
                        break;
                    case 3:
                        if(clsSystem.gobjPLC3.funWritePLC(strAddress, PLCValues))
                {
                    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                    SystemTraceLog.LogMessage = "Write PLC Success!";
                    SystemTraceLog.BufferName = BufferName;
                    SystemTraceLog.AddressSection = Section.ToString();
                    SystemTraceLog.PLCValues = PLCValues;
                    funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                    SystemTraceLog = null;
                    return true;
                }
                else
                {
                    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                    SystemTraceLog.LogMessage = "Write PLC Fail!";
                    SystemTraceLog.BufferName = BufferName;
                    SystemTraceLog.AddressSection = Section.ToString();
                    SystemTraceLog.PLCValues = PLCValues;
                    funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                    SystemTraceLog = null;
                    return false;
                }
                        break;
                }
                return false;
            }
            else
                return false;
        }

        private bool funWriteAutoRunBit(string StnNo, bool Enable)
        {
           return clsSystem.gobjPLC.funWritePLCBit(StnNo, Enable);
        }
        #endregion funWritePLCSingel

        #region Get Write PC->PLC Address
        

        /// <summary>
        /// 取得 PC->PLC 寫入位置
        /// </summary>
        /// <param name="BufferName">PLC位置</param>
        /// <returns></returns>
        private bool funGetWritePC2PLCAddress(string BufferName, ref string Address)
        {
            if(clsSystem.gdicPC2PLCMap.ContainsKey(BufferName))
            {
                Address = "D" + clsSystem.gdicPC2PLCMap[BufferName].ToString();
                return true;
            }
            else
            {
                Address = string.Empty;
                clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                SystemTraceLog.LogMessage = "Get Write PLC Address Fail!";
                SystemTraceLog.BufferName = BufferName;
                funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                SystemTraceLog = null;
                return false;
            }
        }

        /// <summary>
        /// 取得 PC->PLC 特定寫入位置
        /// </summary>
        /// <param name="BufferName">PLC位置</param>
        /// <param name="Section">特定位置</param>
        /// <returns></returns>
        private bool funGetWritePC2PLCAddress(string BufferName, clsPLC.enuAddressSection Section, ref string Address)
        {
            if(clsSystem.gdicPC2PLCMap.ContainsKey(BufferName))
            {
                Address = "D" + (clsSystem.gdicPC2PLCMap[BufferName] + (int)Section).ToString();
                return true;
            }
            else
            {
                Address = string.Empty;
                clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                SystemTraceLog.LogMessage = "Get Write PLC Address Fail!..";
                SystemTraceLog.BufferName = BufferName;
                SystemTraceLog.AddressSection = Section.ToString();
                funShowSystemTrace(lsbMPLC, SystemTraceLog, true);
                SystemTraceLog = null;
                return false;
            }
        }
        #endregion Get Read/Write PLC Address
    }
}
