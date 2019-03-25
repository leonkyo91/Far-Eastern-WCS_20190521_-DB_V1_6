using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.WinBCRRead
{
    public class clsSystem
    {
        private clsSystem()
        {
        }

        #region 常數
        /// <summary>
        /// Ini檔名稱
        /// </summary>
        public const string cstrIniFileName = "WinPLCCommu.ini";
        #endregion 常數

        #region 全域變數
        /// <summary>
        /// IniFile物件
        /// </summary>
        public static clsIniFile gobjIniFile = new clsIniFile();
        /// <summary>
        /// DB連線物件
        /// </summary>
        public static DB gobjDB = new DB();
        /// <summary>
        /// Log物件
        /// </summary>
        public static Log gobjLog = new Log(Application.StartupPath + @"\Log\WinBCRRead\");
        /// <summary>
        /// 文字檔Log壓縮時間
        /// </summary>
        public static int gintTxtLogCompressDay = 30;
        /// <summary>
        /// 文字檔Log刪除時間
        /// </summary>
        public static int gintTxtLogDeleteDay = 180;

        public static int gintBCRQty = 0;
        public static string[] gstrarrBCRID = new string[0];
        public static string[] gstrarrPortName = new string[0];
        public static List<clsCustomSerialPort> glstBCRMap = new List<clsCustomSerialPort>();

        //秤重機參數
        public static int gintWTQty = 0;
        public static string[] gstrarrWTID = new string[0];
        public static string[] gstrarrWTPortName = new string[0];
        public static List<clsWTSerialPort> glstWTMap = new List<clsWTSerialPort>();

        public static int intBCRCount = 0;
        public static int intWTCount = 0;
        #endregion 全域變數

        #region 靜態方法
        /// <summary>
        /// 寫入Exception Log
        /// </summary>
        /// <param name="FunName">組件名稱</param>
        /// <param name="FunctionName">方法名稱</param>
        /// <param name="Message">訊息</param>
        public static void funWriteExceptionLog(string FunName, string FunctionName, string Message)
        {
            try
            {
                gobjLog.funWriteLogFile(
                       DateTime.Now.ToString("yyyyMMdd") + "_Exception.log",
                       FunName.Trim() + "." + FunctionName.Trim() + "|" + Message,
                       Mirle.Log.enuTitleType.TimeMS);
            }
            catch(FieldAccessException exFile)
            {
                var varObject = MethodBase.GetCurrentMethod();
                MessageBox.Show(varObject.DeclaringType.FullName + "." + varObject.Name + " Exception:" + exFile.Message);
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                MessageBox.Show(varObject.DeclaringType.FullName + "." + varObject.Name + " Exception:" + ex.Message);
            }
        }

        /// <summary>
        /// 寫入BCRRead Log
        /// </summary>
        /// <param name="BCRNo"></param>
        /// <param name="BCRLog"></param>
        public static void funWriteBCRReadLog(string BCRLog)
        {
            try
            {
                gobjLog.funWriteLogFile(DateTime.Now.ToString("yyyyMMdd") + "_BCRData.log", BCRLog, Mirle.Log.enuTitleType.TimeMS);
            }
            catch(FieldAccessException exFile)
            {
                var varObject = MethodBase.GetCurrentMethod();
                MessageBox.Show(varObject.DeclaringType.FullName + "." + varObject.Name + " Exception:" + exFile.Message);
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                MessageBox.Show(varObject.DeclaringType.FullName + "." + varObject.Name + " Exception:" + ex.Message);
            }
        }
        /// <summary>
        /// 寫入秤重Log
        /// </summary>
        /// <param name="WTLog"></param>
        public static void funWriteWTReadLog(string WTLog)
        {
            try
            {
                gobjLog.funWriteLogFile(DateTime.Now.ToString("yyyyMMdd") + "_WTData.log", WTLog, Mirle.Log.enuTitleType.TimeMS);
            }
            catch (FieldAccessException exFile)
            {
                var varObject = MethodBase.GetCurrentMethod();
                MessageBox.Show(varObject.DeclaringType.FullName + "." + varObject.Name + " Exception:" + exFile.Message);
            }
            catch (Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                MessageBox.Show(varObject.DeclaringType.FullName + "." + varObject.Name + " Exception:" + ex.Message);
            }
        }
        #endregion 靜態方法
    }
}
