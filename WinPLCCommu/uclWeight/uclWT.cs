using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Mirle.WinPLCCommu
{
    public partial class uclWT : UserControl
    {
        private Color Color_SignOn = Color.Blue;
        private Color Color_SignOff = Color.Red;

        private DateTime dt_DelLog1;      // For Del 

        private string _sTimer = "";
        public string sTimer
        {
            get { return _sTimer; }
        }

        private System.Timers.Timer timRead = new System.Timers.Timer();

        private string WeightName = "";
        public string Weight_NAME
        {
            get { return WeightName; }
            set { WeightName = value; }
        }

        //COM Port
        private string gsCom = "";
        public string ComPort
        {
            get { return gsCom; }
            set { gsCom = value; }
        }

        //iSendReq == 1 ,  Ask Read By Host
        //iSendReq == 2 ,  Ask Read Finish By Host.
        //iSendReq == 0 ,  Initial.
        private int iSendReq = 0;
        public int SendReq
        {
            get { return iSendReq; }
            set { iSendReq = value; }
        }

        //Retrun Data
        private string sRetData = "";
        public string ReturnData
        {
            get { return sRetData; }
            set { sRetData = value; }
        }

        private string sRetWeightValue = "";
        public string ReturnWeigtData
        {
            get { return sRetWeightValue; }
            set { sRetWeightValue = value; }
        }

        //COM Port Connection Status
        private bool bConn = false;
        public bool Conn
        {
            get { return bConn; }
        }

        //ERROR MESSAGE
        private string sErrorMsgValue = string.Empty;
        public string ErrorMSG
        {
            get { return sErrorMsgValue; }
            set { sErrorMsgValue = value; }
        }

        //Weight Parameter
        SerialPort serialport;
        byte[] m_buffer = new byte[20];
        char[] m_bufferChar = new char[20];
        //string strSendCommand = "";
        //int intReceiveLength = 16;


        public uclWT()
        {
            InitializeComponent();
            timRead.Elapsed += new System.Timers.ElapsedEventHandler(timRead_Elapsed);
            timRead.Enabled = false; timRead.Interval = 500;
        }

        private void UC_WT_Load(object sender, EventArgs e)
        {
            lblConn_Name.BackColor = (bConn == true ? Color_SignOn : Color_SignOff);
        }

        public void subStart()
        {
            serialport = new SerialPort();
            serialport.BaudRate = 9600;
            serialport.DataBits = 7;
            serialport.Parity = Parity.Odd;
            serialport.StopBits = StopBits.One;
            serialport.Handshake = Handshake.None;
            serialport.Encoding = new ASCIIEncoding();
            serialport.ReceivedBytesThreshold = 1;
            serialport.RtsEnable = true;
            serialport.DtrEnable = true;

            // Set the read/write timeout
            serialport.ReadTimeout = 1000;
            serialport.WriteTimeout = 1000;
            serialport.DataReceived += DataReceivedEvent;//COMPort資料接收事件

            OpenComPort();
            //timer1.Enabled = true;
            timRead.Enabled = true;
        }

        private void OpenComPort()
        {
            
            OpenComPort_Weight(ref serialport, gsCom);
        }

        private bool OpenComPort_Weight(ref System.IO.Ports.SerialPort objCom, string sComName)
        {
            try
            {
                //if (!serialport.IsOpen)
                //{
                //    serialport.Close();
                //}
                //else
                //    throw new Exception();
                serialport.Close();
                serialport.PortName = sComName;
                serialport.Open();
                //serialport.
                bConn = true;
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                sErrorMsgValue = ex.Message;
                serialport.Close();
                bConn = false;
                return false;
            }
        }

        //Colse Port
        public void CloseComPort()
        {
            //if (!serialport.IsOpen) return;
            try
            {
                serialport.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timRead_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timRead.Enabled = false;
                _sTimer = System.DateTime.Now.ToString("HH:mm:ss");
                
                if (bConn == true)
                {
                    SubReadBcrProcess();
                }

                pfunUpdateFormMsg(sRetData);
                pfunUpdateConn(bConn);

                SubDelLog();
            }
            catch (Exception ex)
            {
                FunWriteLog(ex.ToString());
            }
            finally
            {
                timRead.Enabled = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    timer1.Enabled = false;
            //    _sTimer = System.DateTime.Now.ToString("HH:mm:ss");

            //    lblConn_WT.BackColor = (bConn == true ? Color_SignOn : Color_SignOff);

            //    txtWT.Text = sRetData;
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    timer1.Enabled = true;
            //}
        }

        delegate void degUpdateFormMsg(string sValue);
        public void pfunUpdateFormMsg(string sValue)
        {
            string strHeader1 = string.Empty;
            string strHeader2 = string.Empty;
            string sUnit = string.Empty;//單位
            double dblWeight = 0;
            try
            {
                if (InvokeRequired)
                {
                    degUpdateFormMsg obj = new degUpdateFormMsg(pfunUpdateFormMsg);
                    this.Invoke(obj, sValue);
                }
                else
                {
                    //txtWeight.Text = sValue.ToString();
                    FunSpiltStrToGetWeight(sValue, ref strHeader1, ref strHeader2, ref dblWeight,ref sUnit);
                    lblWeight.Text = dblWeight.ToString();
                }
            }
            catch
            {

            }
        }

        delegate void degUpdateConn(bool bConn);
        public void pfunUpdateConn(bool bConn)
        {
            try
            {
                if (InvokeRequired)
                {
                    degUpdateConn obj = new degUpdateConn(pfunUpdateConn);
                    this.Invoke(obj, bConn);
                }
                else
                {
                    lblConn_Name.BackColor = (bConn == true ? Color_SignOn : Color_SignOff);
                }
            }
            catch
            {

            }
        }

        private void SubReadBcrProcess()
        {
            if (iSendReq == 1)
            {
                sRetData = "";
                sRetWeightValue = "";
                //txtWT.Text = sRetData;

                SubSendCommand();   //Send Read Weight
            }
            else if (iSendReq == 0)
            {
                sRetData = "";
            }
        }



        private void SubSendCommand()
        {
            try
            {
                string strSendCommand = "RW" + "\r\n";   // 命令結束字元: \r=Enter & \n=NewLine
                byte[] r_bytes = Encoding.ASCII.GetBytes(strSendCommand);
                serialport.Write(r_bytes, 0, r_bytes.Length);       //將指定的位元組數目寫入序列埠
                iSendReq = 2;       //Action
                FunWriteLog("Send Data:" + strSendCommand + "  (iSendReq = 2)");         //Log
                FunWriteLog("Read Weight. (iSendReq = 2) ");      //Write log  
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataReceivedEvent(object sender, SerialDataReceivedEventArgs args)
        {
            System.Threading.Thread.Sleep(800);     //避免資料接收未完成

            try
            {
                Invoke(new EventHandler(DoUpdate));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoUpdate(object s, EventArgs e)
        {
            for (int num = 0; num < m_buffer.Length; num++)
            {
                m_buffer[num] = 0;  //Data Read前先將buffer清空
            }
            try
            {
                serialport.Read(m_buffer, 0, m_buffer.Length);      //從SerialPort 緩衝區讀取Data
                string sData = Encoding.ASCII.GetString(m_buffer, 0, m_buffer.Length);
                FunWriteLog("Receive Data:" + sData);               //Log

                // 解析 
                string sHeader1 = ""; string sHeader2 = ""; double dWeight = 0; string sUnit = "";

                sRetData = sData;
                sRetWeightValue = "";
                if (FunSpiltStrToGetWeight(sData, ref  sHeader1, ref  sHeader2, ref dWeight, ref sUnit) == true)
                {
                    sRetWeightValue = dWeight.ToString();
                    FunWriteLog("Spilt Weight Data. Header1(" + sHeader1 + ") ,Header2(" + sHeader2 + "), Weight(" + dWeight.ToString() + "), UNIT(" + sUnit + ")");      //Write log 
                }

                //txtWT.Text = sRetData;

                iSendReq = 9;
                FunWriteLog("Read Weight Finish. (iSendReq = 9) ");      //Write log 

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                FunWriteLog(ex.Message);    //V.0.1.6
            }
        }




        //***************************************************************************************************
        //Function: Write Log Function
        //***************************************************************************************************
        private void FunWriteLog(string sTemp)
        {
            try
            {
                string sFileName = null;

                sFileName = System.AppDomain.CurrentDomain.BaseDirectory;
                sFileName = sFileName + "\\log";
                if (System.IO.Directory.Exists(sFileName) == false)
                {
                    System.IO.Directory.CreateDirectory(sFileName);
                }

                sFileName = sFileName + "\\" + WeightName;
                if (System.IO.Directory.Exists(sFileName) == false)
                {
                    System.IO.Directory.CreateDirectory(sFileName);
                }

                string sFile = "";
                sFile = System.DateTime.Now.ToString("yyyyMMdd") + ".log";
                sFileName = sFileName + "\\" + sFile;

                sTemp = "[" + System.DateTime.Now.ToString("HH:mm:ss") + "] " + sTemp;
                if (System.IO.File.Exists(sFileName) == false)
                {
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(sFileName))
                    {
                        sw.WriteLine(sTemp);
                        sw.Close();
                    }
                }
                else
                {
                    using (System.IO.StreamWriter sw = System.IO.File.AppendText(sFileName))
                    {
                        sw.WriteLine(sTemp);
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {

            }
        }

        private void FunWriteLog(string sFolderName, string sTemp)
        {
            try
            {
                string sFileName = null;

                sFileName = System.AppDomain.CurrentDomain.BaseDirectory;
                //sFileName = sFileName + "\\log";
                sFileName = sFileName + "\\" + sFolderName;
                if (System.IO.Directory.Exists(sFileName) == false)
                {
                    System.IO.Directory.CreateDirectory(sFileName);
                }

                string sFile = "";
                sFile = System.DateTime.Now.ToString("yyyyMMdd") + ".log";
                sFileName = sFileName + "\\" + sFile;

                sTemp = "[" + System.DateTime.Now.ToString("HH:mm:ss") + "] " + sTemp;
                if (System.IO.File.Exists(sFileName) == false)
                {
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(sFileName))
                    {
                        sw.WriteLine(sTemp);
                        sw.Close();
                    }
                }
                else
                {
                    using (System.IO.StreamWriter sw = System.IO.File.AppendText(sFileName))
                    {
                        sw.WriteLine(sTemp);
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {

            }
        }


        private bool FunSpiltStrToGetWeight(string sData, ref string sHeader1, ref string sHeader2, ref double iWeight, ref string sUnit)
        {
            //1234567890123456
            //ST,NT,0001.230kg

            iWeight = 0; sUnit = "";
            if (sData.Length <= 16) { return false; }

            string[] aValue = new string[0];
            aValue = sData.Split(',');

            if (aValue.Length < 3) { return false; }
            sHeader1 = aValue[0];           //OL,ST,US
            sHeader2 = aValue[1];           //NT,GS,TR

            string sWeight = aValue[2].Substring(0, 8);
            iWeight = Double(sWeight);
            sUnit = aValue[2].Substring(8, 2); //g,kg

            return true;
        }

        private double Double(string sData)
        {
            double dValue = 0;

            try
            {
                int n;
                if (int.TryParse(sData, out n))
                {
                    //iValue = int.Parse(sData);    // 取數值
                    dValue = double.Parse(sData);
                }
                else
                {
                    double n1;
                    if (double.TryParse(sData, out n1))
                    {
                        dValue = double.Parse(sData);     // 取Double                          
                    }
                    else
                    {
                        dValue = 0;
                    }
                }
            }
            catch
            {

            }
            return dValue;
        }


        private int INT(string sData)
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

        private void SubDelLog()
        {
            try
            {
                TimeSpan ts1 = new TimeSpan(dt_DelLog1.Ticks);
                TimeSpan ts2 = new TimeSpan(System.DateTime.Now.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();

                string A1 = ts.TotalHours.ToString();
                if (INT(A1) >= 24)  //超過1天才處理刪除動作
                {
                    dt_DelLog1 = System.DateTime.Now;

                    FunDelLog(30);  //只保留30天
                }
            }
            catch
            {

            }
        }

        private void FunDelLog(int iDay)
        {
            try
            {
                string sFileName = null;
                sFileName = System.Windows.Forms.Application.StartupPath;
                sFileName = sFileName + "\\log";
                if (System.IO.Directory.Exists(sFileName) == false)
                {
                    return;
                }

                sFileName = sFileName + "\\" + WeightName;
                if (System.IO.Directory.Exists(sFileName) == false)
                {
                    return;
                }

                int iLen = sFileName.Length + 1;

                //保留 iDay 天                
                string sNowDate = System.DateTime.Now.AddDays(-1 * iDay).ToString("yyyyMMdd");
                int iNowDate = INT(sNowDate);

                //foreach (string fname in System.IO.Directory.GetFileSystemEntries(sFileName))
                foreach (string fname in System.IO.Directory.GetFiles(sFileName))
                {
                    string A1 = fname.Substring(iLen);
                    int iLen1 = A1.IndexOf(".", 0);
                    if (iLen1 > 1)
                    {
                        A1 = A1.Substring(0, iLen1);    //yyyyMMdd

                        if (iNowDate > INT(A1))         //超過 iDay 天則刪除檔案
                        {
                            if (System.IO.File.Exists(fname))
                            {
                                System.IO.File.Delete(fname);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        
       
    }
}
