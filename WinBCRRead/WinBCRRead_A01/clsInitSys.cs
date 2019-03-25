using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.WinBCRRead
{
    public class clsInitSys
    {
        private clsInitSys()
        {
        }

        #region 靜態方法
        /// <summary>
        /// 檢查是否已重復開啟程式，若有重復開啟會將前一個程式關閉
        /// </summary>
        public static void funCheckProcess()
        {
            Process[] objarProcess = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if(objarProcess.Length > 1)
            {
                foreach(Process objProcess in objarProcess)
                {
                    try
                    {
                        Type ff = objProcess.GetType();
                        if(objProcess.Id != Process.GetCurrentProcess().Id)
                            objProcess.Kill();
                    }
                    catch(Exception ex)
                    {
                        var varObject = MethodBase.GetCurrentMethod();
                        clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化系統
        /// </summary>
        /// <param name="StnNo"></param>
        public static void funInitSystem()
        {
            if(!funCheckIniFile())
                Environment.Exit(0);

            funSetBCR(clsSystem.gobjIniFile);
            funSetSystemConfig(clsSystem.gobjIniFile);
            funSetDB(clsSystem.gobjIniFile);

            funSetLog();

            funOpendDB();
            //funOpenLeftBCR();
            //funOpenRightBCR();
        }

        /// <summary>
        /// Reconnection DB
        /// </summary>
        /// <returns>若資料庫皆連線成功傳回True，否則傳回false</returns>
        public static bool funReconnectionDB()
        {
            clsSystem.gobjDB.funCloseDB();

            string strEM = string.Empty;
            if(clsSystem.gobjDB.funOpenDB(ref strEM) != ErrDef.ProcSuccess)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Reconnection Left BCR
        /// </summary>
        public static void funReconnectionLeftBCR()
        {
            try
            {
                clsSystem.gobjLeftBCR.Close();
                clsSystem.gobjLeftBCR.Open();
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }

        /// <summary>
        /// Reconnection Right BCR
        /// </summary>
        public static void funReconnectionRightBCR()
        {
            try
            {
                clsSystem.gobjRightBCR.Close();
                clsSystem.gobjRightBCR.Open();
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }
        #endregion 靜態方法

        #region 私用靜態方法

        #region 讀取ini相關
        /// <summary>
        /// 檢查是否存在Ini檔
        /// </summary>
        /// <param name="IniFile">IniFile物件</param>
        /// <returns>若存在時傳回true，否則回false</returns>
        private static bool funCheckIniFile()
        {
            if(!File.Exists(Application.StartupPath + "\\" + clsSystem.cstrIniFileName))
            {
                MessageBox.Show(
                    "找不到" + clsSystem.cstrIniFileName + "，請洽系統管理人員 !!",
                    "WinPLCCommu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                clsSystem.gobjIniFile.gstrIniFilePath = Application.StartupPath + "\\" + clsSystem.cstrIniFileName;
                return true;
            }
        }

        /// <summary>
        /// 讀取Ini中BCR Config區塊相關設定
        /// </summary>
        /// <param name="IniFile"></param>
        private static void funSetBCR(clsIniFile IniFile)
        {
            string strSection = "BCR Config";
            string strKey = string.Empty;
            string strValues = string.Empty;


            strKey = clsSystem.cstrStnNo + "_L";
            clsSystem.gstrLeftBCRPortName = IniFile.funReadValue(strSection, strKey, "");
            strKey = clsSystem.cstrStnNo + "_R";
            clsSystem.gstrRightBCRPortName = IniFile.funReadValue(strSection, strKey, "");
        }

        /// <summary>
        /// 讀取Ini中System Config區塊相關設定
        /// </summary>
        /// <param name="IniFile">IniFile物件</param>
        private static void funSetSystemConfig(clsIniFile IniFile)
        {
            string strSection = "System Config";
            string strKey = string.Empty;
            string strValues = string.Empty;

            strKey = "CompressDay";
            clsSystem.gintTxtLogCompressDay = IniFile.funReadValue(strSection, strKey, 30);
            strKey = "DeleteDay";
            clsSystem.gintTxtLogDeleteDay = IniFile.funReadValue(strSection, strKey, 180);
        }

        /// <summary>
        /// 讀取Ini中Data Base區塊相關設定
        /// </summary>
        /// <param name="IniFile">IniFile物件</param>
        private static void funSetDB(clsIniFile IniFile)
        {
            string strSection = string.Empty;
            string strKey = string.Empty;
            string strValues = string.Empty;

            strSection = "Data Base";
            strKey = "DBMS";
            strValues = IniFile.funReadValue(strSection, strKey, "Oracle_OracleClient");
            clsSystem.gobjDB.DBType = funGetEnumValue<DB.enuDatabaseType>(strValues);
            strKey = "DbServer";
            clsSystem.gobjDB.DBServer = IniFile.funReadValue(strSection, strKey, ".");
            strKey = "FODbServer";
            clsSystem.gobjDB.FODBServer = IniFile.funReadValue(strSection, strKey, ".");
            strKey = "DataBase";
            clsSystem.gobjDB.DBName = IniFile.funReadValue(strSection, strKey, "");
            strKey = "DbUser";
            clsSystem.gobjDB.DBUser = IniFile.funReadValue(strSection, strKey, "");
            strKey = "DbPswd";
            clsSystem.gobjDB.DBPassword = IniFile.funReadValue(strSection, strKey, "");
        }
        #endregion 讀取ini相關

        /// <summary>
        /// Log壓縮與刪除設定
        /// </summary>
        private static void funSetLog()
        {
            if(clsSystem.gintTxtLogCompressDay > 0 || clsSystem.gintTxtLogDeleteDay > 0)
            {
                clsSystem.gobjLog.SetTimerEnable = false;
                clsSystem.gobjLog.SetAutoCompressReserveDay = clsSystem.gintTxtLogCompressDay;
                clsSystem.gobjLog.SetAutoCompressEnable = clsSystem.gintTxtLogCompressDay > 0 ? true : false;
                clsSystem.gobjLog.SetAutoDeleteReserveDay = clsSystem.gintTxtLogDeleteDay;
                clsSystem.gobjLog.SetAutoDeleteEnable = clsSystem.gintTxtLogDeleteDay > 0 ? true : false;
                clsSystem.gobjLog.SetTimerInterval = 86400000;
                clsSystem.gobjLog.SetTimerEnable = true;
            }
            else
                clsSystem.gobjLog.SetTimerEnable = false;
        }

        /// <summary>
        /// 與左邊BCR連線
        /// </summary>
        private static void funOpenLeftBCR()
        {
            try
            {
                clsSystem.gobjLeftBCR.PortName = clsSystem.gstrLeftBCRPortName;
                clsSystem.gobjLeftBCR.BaudRate = 9600;
                clsSystem.gobjLeftBCR.Parity = Parity.Even;
                clsSystem.gobjLeftBCR.DataBits = 7;
                clsSystem.gobjLeftBCR.StopBits = StopBits.One;
                clsSystem.gobjLeftBCR.Open();
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }

        /// <summary>
        /// 與右邊BCR連線
        /// </summary>
        private static void funOpenRightBCR()
        {
            try
            {
                clsSystem.gobjRightBCR.PortName = clsSystem.gstrRightBCRPortName;
                clsSystem.gobjRightBCR.BaudRate = 9600;
                clsSystem.gobjRightBCR.Parity = Parity.Even;
                clsSystem.gobjRightBCR.DataBits = 7;
                clsSystem.gobjRightBCR.StopBits = StopBits.One;
                clsSystem.gobjRightBCR.Open();
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }

        /// <summary>
        /// 進行資料庫連線
        /// </summary>
        /// <returns>若資料庫皆連線成功傳回True，否則傳回false</returns>
        private static void funOpendDB()
        {
            string strEM = string.Empty;
            clsSystem.gobjDB.funOpenDB(ref strEM);
            
        }

        /// <summary>
        /// 將字串轉成列舉值
        /// </summary>
        /// <typeparam name="TEnum">列舉Type</typeparam>
        /// <param name="EnumAsString">列舉字串</param>
        /// <returns>傳回列舉值</returns>
        private static TEnum funGetEnumValue<TEnum>(string EnumAsString) where TEnum : struct
        {
            TEnum enumType = (TEnum)Enum.GetValues(typeof(TEnum)).GetValue(0);
            Enum.TryParse<TEnum>(EnumAsString, out enumType);
            return enumType;
        }
        #endregion 私用靜態方法
    }
}
