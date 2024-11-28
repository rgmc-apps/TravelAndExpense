using MyCommon;
using MyCommon.Data;
using MyCommon.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRIS
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        Common cn = new Common();
        Function function = new Function();
        private bool isEPV = true;
        private int mvLastRow = 0;
        private bool mvHasValue = false;

        Color backColor = Color.White;        

        Color criticalColor = Color.FromArgb(200, 88, 88);
        Color cautionColor = Color.FromArgb(255, 150, 0);
        Color neutralColor = Color.FromArgb(80, 150, 80);
        Color normalColor = Color.White;

        private void StatusDashboard(bool isEPV)
        {
            DataTable dtValue = new DataTable();

            DataTable[] refDT = { dtValue };

            string sSQL = "proc_Dashboard";

            try
            {
                using (SQLDB sql = new SQLDB())
                {
                    SqlParameter pId = new SqlParameter("@employeeId", SqlDbType.Int);
                    pId.Value = cn.GetEmployeeId();

                    SqlParameter pModeId = new SqlParameter("@modeId", SqlDbType.Bit);
                    pModeId.Value = isEPV;

                    sql.GetDT(ref refDT, sSQL, CommandType.StoredProcedure, pId, pModeId);
                }

                dgvDashboard.DataSource = null;                
                dgvDashboard.DataSource = dtValue;

                dgvDashboard.Columns[0].Visible = false;
                dgvDashboard.Refresh();                
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            {
                dtValue.Dispose();
            }
        }

        public void CommandPass(string strCommand)
        {
            try
            {
                switch (strCommand)
                {
                    case Declaration.REFRESH_COMMAND:
                        btnRefreshEPV.PerformClick();                                                
                        break;
                }
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        public void dashboardColors(int rowIndex, int colIndex, int elapseDays)
        {
            try
            {  
                if (elapseDays >= 0 && elapseDays < 8)
                    backColor = normalColor;
                if (elapseDays >= 8 && elapseDays < 16)
                    backColor = neutralColor;
                if (elapseDays >= 16 && elapseDays < 24)
                    backColor = cautionColor;
                if (elapseDays >= 24)
                    backColor = criticalColor;
                if (elapseDays < 0)
                { backColor = normalColor; }
                
                dgvDashboard.Rows[rowIndex].Cells[colIndex].Style.BackColor = backColor;
                dgvDashboard.Rows[rowIndex].Cells[colIndex].Style.ForeColor = Color.Black;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }


        private void frmDashboard_Load(object sender, EventArgs e)
        {
            StatusDashboard(isEPV);

            pnlCritical.BackColor = criticalColor;
            pnlCaution.BackColor = cautionColor;
            pnlNeutral.BackColor = neutralColor;
            pnlNormal.BackColor = normalColor;
        }
        
        private void btnRefreshEPV_Click(object sender, EventArgs e)
        {
            StatusDashboard(isEPV);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string strValue = "";
                string strSearch = txtFind.Text.Trim();
                for (int intRow = mvLastRow; intRow < dgvDashboard.RowCount; intRow++)
                {
                    for (int intCol = 1; intCol < dgvDashboard.ColumnCount; intCol++)
                    {
                        strValue = dgvDashboard[intCol, intRow].Value.ToString().Split('(')[0];
                        if (strValue.Contains(strSearch))
                        {
                            dgvDashboard[intCol, intRow].Selected = true;
                            mvHasValue = true;

                            if (mvLastRow == dgvDashboard.RowCount)
                            { mvLastRow = 0; }
                            else
                            { mvLastRow = intRow + 1; }

                            return;
                        }
                    }
                }

                if (mvHasValue == true)
                {
                    // to loop again in the list
                    mvLastRow = 0;
                }
                else
                {
                    txtFind.Focus();
                    throw new Exception("The specified text was not found.");
                }
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void dgvDashboard_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isEPV)
            {
                frmEPVDetail frm = new frmEPVDetail();
                frm.EPVId = cn.GetReferenceID(dgvDashboard.SelectedCells[0].Value.ToString().Split('(')[0], true);
                frm.Show();
            }
            else
            {
                frmCashAdvanceDetail frm = new frmCashAdvanceDetail();
                frm.CashAdvanceId = cn.GetReferenceID(dgvDashboard.SelectedCells[0].Value.ToString().Split('(')[0], false);
                frm.Show();
            }
        }

        private void dgvDashboard_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn col in dgvDashboard.Columns)
            {
                if (col.Index != 0)
                {
                    foreach (DataGridViewRow row in dgvDashboard.Rows)

                        if (dgvDashboard[col.Index, row.Index].Value.ToString() != "")
                        {
                            dashboardColors(row.Index, col.Index, Convert.ToInt32(dgvDashboard[col.Index, row.Index].Value.ToString().Split('(')[1].Split(')')[0].ToString()));
                        }
                }
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            mvHasValue = false;
            mvLastRow = 0;
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind.PerformClick();
            }
        }

        private void dgvDashboard_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            mvLastRow = dgvDashboard.CurrentCell.RowIndex;
        }

        private void btnCA_Click(object sender, EventArgs e)
        {
            lblMode.Text = "CA";
            btnEPV.BackColor = default(System.Drawing.Color);
            btnCA.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            isEPV = false;
            btnRefreshEPV.PerformClick();
            lblNote.Text = "CA #(Days Elapse since Needed Date)" + System.Environment.NewLine
                + "                        CA Amount";
        }

        private void btnEPV_Click(object sender, EventArgs e)
        {            
            lblMode.Text = "EPV";
            btnEPV.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            btnCA.BackColor = default(System.Drawing.Color); 
            isEPV = true;
            btnRefreshEPV.PerformClick();
            lblNote.Text = "EPV #(Days Elapse since Request Date)" + System.Environment.NewLine
                + "                        Total Expense";
        }
    }
}
