using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mirle.Library;

namespace Mirle.WinPLCCommu
{
    public partial class frmPLCModify : Form
    {
        private string[] strarrCmdMode = new string[] { "0:無", "1:左", "2:右", "3:左右" };
        private string[] strarrStnMode = new string[] { "0:無", "1:入庫", "2:出庫", "3:撿料" };
        private string[] strarrIniNotice = new string[] { "0:無", "1:通知初始" };
        private string[] strarrFunNotice1 = new string[] { "0:無", "1:檢查無誤放行", "2:檢查有問題退出站口"};
        private string[] strarrFunNotice2 = new string[] { "0:站口無模式", "1:站口入庫模式", "2:站口出庫模式", " " };
        private string[] strarrFunNotice3 = new string[] { "0:無", "1:無命令", "2:條碼讀不到", "3:超重","4:儲位不符" };
        private delegate void delBufferIndexChange(int BufferIndex);
        private clsBufferData objBufferData;
        private Timer timRefresh = new Timer();

        public delegate void delShowSystemTraceEventHandler(object sender, clsTraceLogEventArgs e);
        public event delShowSystemTraceEventHandler ShowSystemTrace;

        private frmPLCModify()
        {
            InitializeComponent();
        }

        public frmPLCModify(clsBufferData BufferData)
            : this()
        {
            objBufferData = BufferData;
            cboBufferName.DisplayMember = "Key";
            cboBufferName.ValueMember = "Value";
            cboBufferName.DataSource = new BindingSource(clsSystem.gdicBufferIndex, null);

            timRefresh.Stop();
            timRefresh.Tick += new EventHandler(timRefresh_Tick);
            timRefresh.Interval = 1000;
            timRefresh.Start();
        }

        private void frmPLCModify_Load(object sender, EventArgs e)
        {
            txtPC2PLC_CmdSno.MaxLength = 5;
            txtPC2PLC_Mode.MaxLength = 5;

            cboPC2PLC_IniNotice.Items.AddRange(strarrIniNotice);
            cboPC2PLC_FunNotice1.Items.AddRange(strarrFunNotice1);
            cboPC2PLC_FunNotice2.Items.AddRange(strarrFunNotice2);
            cboPC2PLC_FunNotice3.Items.AddRange(strarrFunNotice3);
            //cboPC2PLC_PathNotice.Items.AddRange(strarrPathNotice);
        }

        private void timRefresh_Tick(object sender, EventArgs e)
        {
            if(cboBufferName.SelectedIndex >= 0)
            {
                int intIndex = (int)cboBufferName.SelectedValue;

                lblPLC2PC_CmdSno.Text =
                    string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[intIndex].LeftCmdSno) ? "0" : objBufferData.PLC2PCBuffer[intIndex].LeftCmdSno;
                lblPLC2PC_Mode.Text =
                    string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[intIndex].StnMode.ToString()) ? "0" : objBufferData.PLC2PCBuffer[intIndex].StnMode.ToString();
                lblPLC2PC_Ready.Text = objBufferData.PLC2PCBuffer[intIndex].Ready.ToString();
                lblPLC2PC_StnChange.Text = objBufferData.PLC2PCBuffer[intIndex].StnChange.ToString();
                lblPLC2PC_FunNotice.Text = objBufferData.PLC2PCBuffer[intIndex].FunNotice.ToString();
                lblPLC2PC_ReadNotice.Text = objBufferData.PLC2PCBuffer[intIndex].ReadNotice.ToString();
                lblPLC2PC_Avail.Text = objBufferData.PLC2PCBuffer[intIndex].Avail.ToString();
                lblPLC2PC_ErroeCode.Text = objBufferData.PLC2PCBuffer[intIndex].Error.ToString();

                lblPC2PLC_CmdSno.Text =
                    string.IsNullOrWhiteSpace(objBufferData.PC2PLCBuffer[intIndex].CmdSno) ? "0" : objBufferData.PC2PLCBuffer[intIndex].CmdSno;
                //lblPC2PLC_RightCmdSno.Text =
                //    string.IsNullOrWhiteSpace(objBufferData.PC2PLCBuffer[intIndex].RightCmdSno) ? "0" : objBufferData.PC2PLCBuffer[intIndex].RightCmdSno;
                lblPC2PLC_Mode.Text = objBufferData.PC2PLCBuffer[intIndex].StnMode.ToString();
                lblPC2PLC_IniNotice.Text = objBufferData.PC2PLCBuffer[intIndex].IniNotice.ToString();
                lblPC2PLC_FunNotice1.Text = objBufferData.PC2PLCBuffer[intIndex].FunNotice_1.ToString();
                lblPC2PLC_FunNotice2.Text = objBufferData.PC2PLCBuffer[intIndex].FunNotice_2.ToString();
                lblPC2PLC_FunNotice3.Text = objBufferData.PC2PLCBuffer[intIndex].FunNotice_3.ToString();
                //lblPC2PLC_CmdMode.Text = objBufferData.PC2PLCBuffer[intIndex].StnMode.ToString();
                //lblPC2PLC_StnMode.Text = objBufferData.PC2PLCBuffer[intIndex].StnMode.ToString();
                //lblPC2PLC_FunNotice.Text = objBufferData.PC2PLCBuffer[intIndex].FunNotice.ToString();
                //lblPC2PLC_ReadNotice.Text = objBufferData.PC2PLCBuffer[intIndex].ReadNotice.ToString();
                //lblPC2PLC_PathNotice.Text = objBufferData.PC2PLCBuffer[intIndex].PathNotice.ToString();
                if(objBufferData.PLC2PCBuffer[intIndex].FunNotice.ToString() == "1")
                    funWritePC2PLCSingel(cboBufferName.Text, clsPLC.enuAddressSection.InitialNotice, "0");
            }
        }

        private void cboBufferName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboBufferName.SelectedIndex >= 0)
            {
                int intIndex = (int)cboBufferName.SelectedValue;

                lblPLC2PC_CmdSno.Text =
                    string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[intIndex].LeftCmdSno) ? "0" : objBufferData.PLC2PCBuffer[intIndex].LeftCmdSno;
                lblPLC2PC_Mode.Text =
                    string.IsNullOrWhiteSpace(objBufferData.PLC2PCBuffer[intIndex].StnMode.ToString()) ? "0" : objBufferData.PLC2PCBuffer[intIndex].StnMode.ToString();
                lblPLC2PC_Ready.Text = objBufferData.PLC2PCBuffer[intIndex].Ready.ToString();
                lblPLC2PC_StnChange.Text = objBufferData.PLC2PCBuffer[intIndex].StnChange.ToString();
                lblPLC2PC_FunNotice.Text = objBufferData.PLC2PCBuffer[intIndex].FunNotice.ToString();
                lblPLC2PC_ReadNotice.Text = objBufferData.PLC2PCBuffer[intIndex].ReadNotice.ToString();
                lblPLC2PC_Avail.Text = objBufferData.PLC2PCBuffer[intIndex].Avail.ToString();
                lblPLC2PC_ErroeCode.Text = objBufferData.PLC2PCBuffer[intIndex].Error.ToString();

                lblPC2PLC_CmdSno.Text =
                    string.IsNullOrWhiteSpace(objBufferData.PC2PLCBuffer[intIndex].CmdSno) ? "0" : objBufferData.PC2PLCBuffer[intIndex].CmdSno;
                //lblPC2PLC_RightCmdSno.Text =
                //    string.IsNullOrWhiteSpace(objBufferData.PC2PLCBuffer[intIndex].RightCmdSno) ? "0" : objBufferData.PC2PLCBuffer[intIndex].RightCmdSno;
                lblPC2PLC_Mode.Text = objBufferData.PC2PLCBuffer[intIndex].StnMode.ToString();
                lblPC2PLC_IniNotice.Text = objBufferData.PC2PLCBuffer[intIndex].IniNotice.ToString();
                lblPC2PLC_FunNotice1.Text = objBufferData.PC2PLCBuffer[intIndex].FunNotice_1.ToString();
                lblPC2PLC_FunNotice2.Text = objBufferData.PC2PLCBuffer[intIndex].FunNotice_2.ToString();
                lblPC2PLC_FunNotice3.Text = objBufferData.PC2PLCBuffer[intIndex].FunNotice_3.ToString();
                //lblPC2PLC_CmdMode.Text = objBufferData.PC2PLCBuffer[intIndex].StnMode.ToString();
                //lblPC2PLC_StnMode.Text = objBufferData.PC2PLCBuffer[intIndex].StnMode.ToString();
                //lblPC2PLC_FunNotice.Text = objBufferData.PC2PLCBuffer[intIndex].FunNotice.ToString();
                //lblPC2PLC_ReadNotice.Text = objBufferData.PC2PLCBuffer[intIndex].ReadNotice.ToString();
                //lblPC2PLC_PathNotice.Text = objBufferData.PC2PLCBuffer[intIndex].PathNotice.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWrite_CmdSno_Click(object sender, EventArgs e)
        {
            funWritePC2PLCSingel(cboBufferName.Text, clsPLC.enuAddressSection.Cmdsno, txtPC2PLC_CmdSno.Text.Trim());
        }

        private void btnWrite_Mode_Click(object sender, EventArgs e)
        {
            funWritePC2PLCSingel(cboBufferName.Text, clsPLC.enuAddressSection.RightCmdSno, txtPC2PLC_Mode.Text.Trim());
        }

        private void btnWrite_IniNotice_Click(object sender, EventArgs e)
        {
            funWritePC2PLCSingel(cboBufferName.Text, clsPLC.enuAddressSection.CmdMode, clsTool.funGetComboxValue(cboPC2PLC_IniNotice.Text));
        }

        private void btnWrite_FunNotice1_Click(object sender, EventArgs e)
        {
            funWritePC2PLCSingel(cboBufferName.Text, clsPLC.enuAddressSection.StnMode, clsTool.funGetComboxValue(cboPC2PLC_FunNotice1.Text));
        }

        private void btnWrite_FunNotice2_Click(object sender, EventArgs e)
        {
            funWritePC2PLCSingel(cboBufferName.Text, clsPLC.enuAddressSection.InitialNotice, clsTool.funGetComboxValue(cboPC2PLC_FunNotice2.Text));
        }

        private void btnWrite_FunNotice3_Click(object sender, EventArgs e)
        {
            funWritePC2PLCSingel(cboBufferName.Text, clsPLC.enuAddressSection.ReadNotice, clsTool.funGetComboxValue(cboPC2PLC_FunNotice3.Text));
        }

        private void btnWrite_PathNotice_Click(object sender, EventArgs e)
        {
            funWritePC2PLCSingel(cboBufferName.Text, clsPLC.enuAddressSection.PathNotice, clsTool.funGetComboxValue(cboPC2PLC_PathNotice.Text));
        }

        private void txtPC2PLC_CmdSno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void funBufferIndexChange(int BufferIndex)
        {
            if(this.InvokeRequired)
            {
                delBufferIndexChange BufferIndexChange = new delBufferIndexChange(funBufferIndexChange);
                this.Invoke(BufferIndexChange, BufferIndex);
            }
            else
                cboBufferName.SelectedIndex = BufferIndex;
        }

        /// <summary>
        /// 從特定位置寫入PLC
        /// </summary>
        /// <param name="BufferName"></param>
        /// <param name="Section"></param>
        /// <param name="PLCValues"></param>
        /// <returns></returns>
        private bool funWritePC2PLCSingel(string BufferName, clsPLC.enuAddressSection Section, params string[] PLCValues)
        {
            string strAddress = string.Empty;
            if(funGetWritePC2PLCAddress(BufferName, Section, ref strAddress))
            {
                if (BufferName.Substring(0, 1) == "C" || BufferName.Substring(0, 1) == "D" || BufferName.Substring(0, 1) == "E")
                {
                    if (clsSystem.gobjPLC2.funWritePLC(strAddress, PLCValues))
                    {
                        if (ShowSystemTrace != null)
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                            SystemTraceLog.LogMessage = "User Write PLC Success!";
                            SystemTraceLog.BufferName = BufferName;
                            SystemTraceLog.AddressSection = Section.ToString();
                            SystemTraceLog.PLCValues = PLCValues;
                            ShowSystemTrace(this, SystemTraceLog);
                            SystemTraceLog = null;
                        }
                        return true;
                    }
                    else
                    {
                        if (ShowSystemTrace != null)
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                            SystemTraceLog.LogMessage = "Write PLC Fail!";
                            SystemTraceLog.BufferName = BufferName;
                            SystemTraceLog.AddressSection = Section.ToString();
                            SystemTraceLog.PLCValues = PLCValues;
                            ShowSystemTrace(this, SystemTraceLog);
                            SystemTraceLog = null;
                        }
                        return false;
                    }
                }
                else if (BufferName.Substring(0, 1) == "F" || BufferName.Substring(0, 1) == "G")
                {
                    if (clsSystem.gobjPLC3.funWritePLC(strAddress, PLCValues))
                    {
                        if (ShowSystemTrace != null)
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                            SystemTraceLog.LogMessage = "User Write PLC Success!";
                            SystemTraceLog.BufferName = BufferName;
                            SystemTraceLog.AddressSection = Section.ToString();
                            SystemTraceLog.PLCValues = PLCValues;
                            ShowSystemTrace(this, SystemTraceLog);
                            SystemTraceLog = null;
                        }
                        return true;
                    }
                    else
                    {
                        if (ShowSystemTrace != null)
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                            SystemTraceLog.LogMessage = "Write PLC Fail!";
                            SystemTraceLog.BufferName = BufferName;
                            SystemTraceLog.AddressSection = Section.ToString();
                            SystemTraceLog.PLCValues = PLCValues;
                            ShowSystemTrace(this, SystemTraceLog);
                            SystemTraceLog = null;
                        }
                        return false;
                    }
                }
                else
                {
                    if (clsSystem.gobjPLC.funWritePLC(strAddress, PLCValues))
                    {
                        if (ShowSystemTrace != null)
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                            SystemTraceLog.LogMessage = "User Write PLC Success!";
                            SystemTraceLog.BufferName = BufferName;
                            SystemTraceLog.AddressSection = Section.ToString();
                            SystemTraceLog.PLCValues = PLCValues;
                            ShowSystemTrace(this, SystemTraceLog);
                            SystemTraceLog = null;
                        }
                        return true;
                    }
                    else
                    {
                        if (ShowSystemTrace != null)
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                            SystemTraceLog.LogMessage = "Write PLC Fail!";
                            SystemTraceLog.BufferName = BufferName;
                            SystemTraceLog.AddressSection = Section.ToString();
                            SystemTraceLog.PLCValues = PLCValues;
                            ShowSystemTrace(this, SystemTraceLog);
                            SystemTraceLog = null;
                        }
                        return false;
                    }
                }
            }
            else
                return false;
        }

        /// <summary>
        /// 取得PLC特定寫入位置
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
                if(ShowSystemTrace != null)
                {
                    clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.MPLC);
                    SystemTraceLog.LogMessage = "User Get Write PLC Address Fail!";
                    SystemTraceLog.BufferName = BufferName;
                    SystemTraceLog.AddressSection = Section.ToString();
                    ShowSystemTrace(this, SystemTraceLog);
                    SystemTraceLog = null;
                }
                return false;
            }
        }
    }
}
