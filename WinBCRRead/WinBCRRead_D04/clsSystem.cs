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
        /// <summary>
        /// BCR站口名稱
        /// </summary>
        public const string cstrStnNo = "D04";
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
        /// <summary>
        /// 左邊BCR的序列埠名稱
        /// </summary>
        public static string gstrLeftBCRPortName = string.Empty;
        /// <summary>
        /// 右邊BCR的序列埠名稱
        /// </summary>
        public static string gstrRightBCRPortName = string.Empty;
        /// <summary>
        /// 左邊BCR的序列埠
        /// </summary>
        public static SerialPort gobjLeftBCR = new SerialPort();
        /// <summary>
        /// 右邊BCR的序列埠
        /// </summary>
        public static SerialPort gobjRightBCR = new SerialPort();
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
        #endregion 靜態方法
    }
}
