using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mirle.Library;

namespace Mirle.WinPLCCommu
{
    public partial class frmEquCmd : Form
    {
        public delegate void delShowSystemTraceEventHandler(object sender, clsTraceLogEventArgs e);
        public event delShowSystemTraceEventHandler ShowSystemTrace;

        public frmEquCmd()
        {
            InitializeComponent();
        }

        #region 事件
        private void frmEquCmd_Load(object sender, EventArgs e)
        {
            funInitDataGridViewHeader();
            funQuery();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            funQuery();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strCmdSno = string.Empty;

            try
            {
                strCmdSno = dgvCmdList.SelectedRows[0].Cells["Command"].Value.ToString();
                strSQL = "UPDATE EQUCMD SET CMDSTS='0' WHERE CMDSNO='" + strCmdSno + "'";

                if(MessageBox.Show("Retry Crane CmdSno:<" + strCmdSno + "> ?", "Retry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                    {
                        if(ShowSystemTrace != null)
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            SystemTraceLog.LogMessage = "User Retry Equ Cmd!";
                            SystemTraceLog.LeftCmdSno = strCmdSno;
                            ShowSystemTrace(this, SystemTraceLog);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            string strCmdSno = string.Empty;

            try
            {
                strCmdSno = dgvCmdList.SelectedRows[0].Cells["Command"].Value.ToString();
                strSQL = "UPDATE EQUCMD SET RENEWFLAG='F' WHERE CMDSNO='" + strCmdSno + "'";
                if(MessageBox.Show("Delete Crane CmdSno:<" + strCmdSno + "> ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(clsSystem.gobjDB.funExecSql(strSQL, ref strEM) == ErrDef.ProcSuccess)
                    {
                        if(ShowSystemTrace != null)
                        {
                            clsTraceLogEventArgs SystemTraceLog = new clsTraceLogEventArgs(enuTraceLog.System);
                            SystemTraceLog.LogMessage = "User Delete Equ Cmd!";
                            SystemTraceLog.LeftCmdSno = strCmdSno;
                            ShowSystemTrace(this, SystemTraceLog);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 事件

        #region 私用方法
        private void funInitDataGridViewHeader()
        {
            dgvCmdList.Columns.Add("Command", "Command");
            dgvCmdList.Columns.Add("EquNo", "Equ No");
            dgvCmdList.Columns.Add("Mode", "Mode");
            dgvCmdList.Columns.Add("Status", "Status");
            dgvCmdList.Columns.Add("Source", "Source");
            dgvCmdList.Columns.Add("Deatination", "Deatination");
            dgvCmdList.Columns.Add("CompleteCode", "Complete Code");

            dgvCmdList.Columns[0].Width = 75;
            dgvCmdList.Columns[1].Width = 75;
            dgvCmdList.Columns[2].Width = 75;
            dgvCmdList.Columns[3].Width = 75;
            dgvCmdList.Columns[4].Width = 75;
            dgvCmdList.Columns[5].Width = 75;
            dgvCmdList.Columns[6].Width = 125;

            dgvCmdList.RowHeadersWidth = 50;
            dgvCmdList.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCmdList.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCmdList.DefaultCellStyle.ForeColor = Color.Black;
            dgvCmdList.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        private void funWriteDataGridView(DataTable Data)
        {
            if(Data == null)
                return;

            try
            {
                if(dgvCmdList.RowCount > 0)
                    dgvCmdList.Rows.Clear();

                for(int intRow = 0; intRow < Data.Rows.Count; intRow++)
                {
                    dgvCmdList.Rows.Add();
                    dgvCmdList.Rows[intRow].HeaderCell.Value = (intRow + 1).ToString();

                    for(int intColumn = 0; intColumn < Data.Columns.Count; intColumn++)
                    {
                        switch(Data.Columns[intColumn].ColumnName)
                        {
                            case "CMDMODE":
                                #region CMDMODE
                                if(Data.Rows[intRow][intColumn].ToString() == "1")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":入庫";
                                else if(Data.Rows[intRow][intColumn].ToString() == "2")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":出庫";
                                else if(Data.Rows[intRow][intColumn].ToString() == "3")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":撿料";
                                else if(Data.Rows[intRow][intColumn].ToString() == "4")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":站對站";
                                else if(Data.Rows[intRow][intColumn].ToString() == "5")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":庫對庫";
                                else if(Data.Rows[intRow][intColumn].ToString() == "6")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":移動";
                                else if(Data.Rows[intRow][intColumn].ToString() == "7")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":掃描";
                                else if(Data.Rows[intRow][intColumn].ToString() == "8")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":取物";
                                else if(Data.Rows[intRow][intColumn].ToString() == "9")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":置物";
                                else if(Data.Rows[intRow][intColumn].ToString() == "10")
                                    dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString() + ":回原點";
                                #endregion CMDMODE
                                break;
                            case "CMDSTS":
                                dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString();
                                break;
                            default:
                                dgvCmdList.Rows[intRow].Cells[intColumn].Value = Data.Rows[intRow][intColumn].ToString();
                                break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var varObject = MethodBase.GetCurrentMethod();
                clsSystem.funWriteExceptionLog(varObject.DeclaringType.FullName, varObject.Name, ex.Message);
            }
        }

        private void funQuery()
        {
            string strSQL = string.Empty;
            string strEM = string.Empty;
            DataTable objDataTable = new DataTable();

            try
            {
                strSQL = "SELECT CMDSNO, EQUNO, CMDMODE, CMDSTS, SOURCE, DESTINATION, COMPLETECODE FROM EQUCMD ORDER BY EQUNO";
                if(clsSystem.gobjDB.funGetDT(strSQL, ref objDataTable, ref strEM) == ErrDef.ProcSuccess)
                    funWriteDataGridView(objDataTable);
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
            }
        }
        #endregion 私用方法
    }
}
