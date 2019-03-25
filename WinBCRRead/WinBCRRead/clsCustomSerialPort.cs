using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mirle.WinBCRRead
{
    public class clsCustomSerialPort : SerialPort
    {
        private string strBCRNo = string.Empty;
        private string strBCRPortName = string.Empty;

        public clsCustomSerialPort(string BCRNo, string BCRPortName)
        {
            strBCRNo = BCRNo;
            strBCRPortName = BCRPortName;

            this.PortName = strBCRPortName;
            this.BaudRate = 9600;
            this.Parity = Parity.Even;
            this.DataBits = 7;
            this.StopBits = StopBits.One;

            this.DataReceived += new SerialDataReceivedEventHandler(clsCustomSerialPort_DataReceived);
        }

        private void clsCustomSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string strBCRID = string.Empty;
            string strSQL = string.Empty;
            string strEM = string.Empty;
            try
            {
                this.Write("LOFF" + "\r");
                strBCRID = this.ReadExisting().Replace("\r", "");

                if(string.IsNullOrWhiteSpace(strBCRID))
                    strBCRID = "ERROR";

                strSQL = "UPDATE IN_BUF SET BCR_DATA='" + strBCRID + "', BCR_STS='2'";
                strSQL += " WHERE BCR_NO='" + strBCRNo + "'";

                if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                {
                    clsSystem.funWriteBCRReadLog(strBCRNo + ": <" + strBCRID + ">");

                    strSQL = "Insert Into Barcode_log(event_time,BCR_No,BCR_TYPE,BCRCODE_NO,Lable_Log,BCR_Sts)Values(";
                    strSQL += "'"+DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff")+"',";
                    strSQL += "'" + strBCRNo + "',";
                    strSQL += "'Fixed',";//Fixed:固定式,PDA:PDA
                    strSQL += "'" + strBCRID+"'.";//讀到的資料
                    strSQL += "'',";
                    strSQL += "'2')";
                    if (clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                    {
                        //寫入DBLOG
                    }
                }
                //else
                //{
                //}
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }

        public string BCRNo
        {
            get
            {
                return strBCRNo;
            }
        }
        
        
    }
}
