using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mirle.WinBCRRead
{
    public class clsWTSerialPort : SerialPort
    {
        private string strWTNo = string.Empty;
        private string strWTPortName = string.Empty;
        public clsWTSerialPort(string WTNo, string WTPortName)
        {
            strWTNo = WTNo;
            strWTPortName = WTPortName;
            this.PortName = strWTPortName;
            this.BaudRate = 9600;
            this.Parity = Parity.Odd;
            this.DataBits = 7;
            this.StopBits = StopBits.One;
            this.Handshake = Handshake.None;
            this.Encoding = new ASCIIEncoding();
            this.ReceivedBytesThreshold = 1;
            this.RtsEnable = true;
            this.DtrEnable = true;
            this.ReadTimeout = 2000;
            this.WriteTimeout = 2000;
            //this.DataReceived += new SerialDataReceivedEventHandler(clsWTSerialPort_DataReceived);
            this.DataReceived += clsWTSerialPort_DataReceived;
        }
        private void clsWTSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string strWTData = string.Empty;
            string strSQL = string.Empty;
            string strEM = string.Empty;
            try
            {
                //this.Write("RW" + "\r\n");
                strWTData = this.ReadExisting().Replace("\r\n","");
                strWTData = strWTData.Replace("ST,GS,", "").Replace("kg","");
                if (strWTData.Substring(0, 1) == "+")
                {
                    strSQL = "Update In_Weight Set Weight_Data ='" + INT(strWTData.Replace("+", "")).ToString() + "',";
                    strSQL += "Weight_sts ='2'";
                    strSQL += "WHERE Weight_No='" + strWTNo + "'";
                    clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                    clsSystem.funWriteWTReadLog("Read Finish! " + strWTNo + ":重量為:" + strWTData);
                }

                string strInt = strWTData.Remove(0, 1);
                int n;
                if (int.TryParse(strInt, out n))//判斷是否為數字
                {
                    strSQL = "Insert Into Weight_log(event_time,Weight_No,Weight_Data,Weight_Sts)values(";
                    strSQL += "'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "',";
                    strSQL += "'" + strWTNo + "',";
                    strSQL += "'" + strWTData + "'";
                    strSQL += "'2')";
                    clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                }
                else
                {
                    //非數字代表讀取失敗
                    strSQL = "Insert Into Weight_log(event_time,Weight_No,Weight_Data,Weight_Sts)values(";
                    strSQL += "'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "',";
                    strSQL += "'" + strWTNo + "',";
                    strSQL += "'" + strWTData + "'";
                    strSQL += "'E2')";
                    clsSystem.gobjDB.funExecSql(strSQL, ref strEM);
                }
               
            }
            catch (Exception ex)
            {
            }
        }
        public string WTNo
        {
            get
            {
                return strWTNo;
            }
        }
        /// <summary>
        /// 字串轉數字
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public int INT(string sData)
        {
            int iValue = 0;
            double dValue = 0;
            string sValue = "";
            int n;

            try
            {
                if (int.TryParse(sData, out n))
                {
                    iValue = int.Parse(sData);    // 取數值
                }
                else
                {
                    double n1;
                    if (double.TryParse(sData, out n1))
                    {
                        dValue = double.Parse(sData);     // 取Double                    
                        //dValue = Math.Floor(dValue + 0.5);  // 四捨五入
                        dValue = Math.Floor(dValue);  // 無條件捨去
                        sValue = dValue.ToString();         // 轉字串
                        if (int.TryParse(sValue, out n))
                        {
                            iValue = int.Parse(sValue);     // 取整數
                        }
                        else
                        {
                            iValue = 0;
                        }
                    }
                    else
                    {
                        iValue = 0;
                    }
                }

            }
            catch
            {

            }
            return iValue;
        }

    }
}
