using MyCommon;
using MyCommon.Data;
using MyCommon.Settings;
using System;
using System.Data;
using System.Windows.Forms;

namespace MyRIS
{
    public partial class frmCashAdvance : Form
    {
        private Common common = new Common();
        private Function function = new Function();

        private DataTable mvAllDT = new DataTable();
        private DataTable mvDT = new DataTable();

        private string mvFilterBy = "";
        private string mvFilterCaption = "";

        private string mvSortBy = "";
        private int mvStatusId = -1;

        public int StatusId
        {
            set { mvStatusId = value; }
        }

        public frmCashAdvance()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                txtSearch.Focus();
                txtSearch.SelectAll();
                return true;
            }

            if (keyData == (Keys.Control | Keys.D))
            {
                dtpStartDate.Focus();
                return true;
            }

            if (keyData == (Keys.Control | Keys.E))
            {
                txtEmployee.Focus();
                txtEmployee.SelectAll();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void FilterList()
        {
            try
            {
                if (mvFilterBy.Trim() != "")
                {
                    DataRow[] dr = mvAllDT.Select(mvFilterBy);

                    if (dr.Length > 0)
                    { mvDT = dr.CopyToDataTable(); }
                    else
                    { mvDT.Clear(); }
                    
                    lblHeader.Text = this.Text + " List [FILTERED: " + mvFilterCaption + "]";
                }
                else
                {
                    mvDT = mvAllDT.Copy();
                    lblHeader.Text = this.Text + " List";
                }   

                mvDT.DefaultView.Sort = mvSortBy;
                mvDT = mvDT.DefaultView.ToTable();

                dgvList.DataSource = mvDT;

                dgvList.Columns[0].Visible = false;
                dgvList.Columns[1].Visible = false;

                dgvList.Columns["Amount"].DefaultCellStyle.Format = "₱ ##,###.00";
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        public void ExecuteSQL()
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                function.MsgBoxInfo(this.Text, "Invalid Period.");
                return;
            }

            try
            {
                string sSQL = "proc_CashAdvanceList";

                System.Data.SqlClient.SqlParameter pChargeToId = new System.Data.SqlClient.SqlParameter("@chargeToId", SqlDbType.Int);
                pChargeToId.Value = cboCompany.SelectedValue;

                System.Data.SqlClient.SqlParameter pEmployeeId = new System.Data.SqlClient.SqlParameter("@employeeId", SqlDbType.Int);
                pEmployeeId.Value = txtEmployee.Tag;

                System.Data.SqlClient.SqlParameter pStartDate = new System.Data.SqlClient.SqlParameter("@startDate", SqlDbType.Date);
                pStartDate.Value = dtpStartDate.Value;

                System.Data.SqlClient.SqlParameter pEndDate = new System.Data.SqlClient.SqlParameter("@endDate", SqlDbType.Date);
                pEndDate.Value = dtpEndDate.Value;

                System.Data.SqlClient.SqlParameter pStatusId = new System.Data.SqlClient.SqlParameter("@statusId", SqlDbType.Int);
                pStatusId.Value = mvStatusId;

                System.Data.SqlClient.SqlParameter pHeadEmployeeId = new System.Data.SqlClient.SqlParameter("@headEmployeeId", SqlDbType.Int);
                pHeadEmployeeId.Value = common.GetEmployeeId();

                using (SQLDB sql = new SQLDB())
                { mvAllDT = sql.GetDT(sSQL, CommandType.StoredProcedure, pChargeToId, pEmployeeId, pStartDate, pEndDate, pStatusId, pHeadEmployeeId); }

                mvAllDT.TableName = "Cash Advance";

                mvSortBy = "[Date Needed]";

                FilterList();
                lblCount.Text = dgvList.Rows.Count.ToString();
            }
            catch 
            { function.MsgBoxInfo(this.Text, "Cash Advance Table is Missing"); }
        }

        public void CommandPass(string strCommand)
        {
            try
            {
                switch (strCommand)
                {
                    case Declaration.NEW_COMMAND:
                        ShowDetail(strCommand);
                        break;

                    case Declaration.EDIT_COMMAND:
                        ShowDetail(strCommand);
                        break;

                    case Declaration.REFRESH_COMMAND:
                        ExecuteSQL();
                        break;

                    case Declaration.SHOW_ALL_COMMAND:
                        mvFilterBy = "";
                        mvFilterCaption = "";
                        ExecuteSQL();
                        break;

                    case Declaration.FILTER_COMMAND:
                        ShowFilter();
                        break;

                    case Declaration.EXIT_COMMAND:
                        this.Close();
                        break;
                }
            }

            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }

        }

        private void ShowFilter()
        {
            string strName = "";
            string strTag = "";

            frmFilter frm = new frmFilter();

            DataTable dt = new DataTable();
            dt.Columns.Add("tag", typeof(string));
            dt.Columns.Add("name", typeof(string));

            for (int intColumn = 0; intColumn < dgvList.Columns.Count; intColumn++)
            {
                strName = dgvList.Columns[intColumn].HeaderText.ToUpper();
                strTag = dgvList.Columns[intColumn].Name.ToString();

                if (dgvList.Columns[intColumn].Tag != null)
                { strTag = strTag + GlobalSettings.DELIMITER + dgvList.Columns[intColumn].Tag.ToString(); }
                else
                { strTag = strTag + GlobalSettings.DELIMITER + GlobalSettings.TEXT; }

                dt.Rows.Add(strTag, strName);
            }

            frm.ColumnHeader = dt;
            dt.Dispose();

            frm.ShowDialog();

            if (frm.FilterBy != "")
            {
                mvFilterBy = frm.FilterBy;
                mvFilterCaption = frm.FilterCaption;

                FilterList();
            }

            frm.Dispose();
        }

        private void ShowDetail(string strCommand)
        {
            int intId = -1;

            try
            {
                if (strCommand == Declaration.EDIT_COMMAND)
                {
                    if (dgvList.SelectedRows.Count == 0)
                    { throw new Exception("Select an item to edit."); }

                    intId = Convert.ToInt32(dgvList.SelectedRows[0].Tag);
                }

                frmCashAdvanceDetail frm = new frmCashAdvanceDetail();
                frm.CashAdvanceId = intId;
                frm.Show();

                if (frm.Save)
                {
                    ExecuteSQL();
                }

                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    ExecuteSQL();

                //    Form openfrm = Application.OpenForms["frmMain"];

                //    if (openfrm != null)
                //    {
                //        frmMain frmMain = (frmMain)openfrm;
                //        frmMain.CACountStatus();
                //    }
                //}
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void frmCashAdvanceList_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = dtpStartDate.Value.AddYears(-2);
            LoadComboList();    

            if (Declaration.USER_TYPE.Contains(Declaration.GROUP_ACCOUNTING)
                || Declaration.USER_TYPE.Contains(Declaration.GROUP_ALL_DEPARTMENT)
                || Declaration.USER_TYPE.Contains(Declaration.GROUP_TREASURY)
                || Declaration.USER_TYPE.Contains(Declaration.GROUP_APPROVER))
            {
                btnEmployee.Enabled = true;
                //mvFilterBy = "Status <> 'SAVED'";
                ExecuteSQL();
            }
            else
            {
                btnEmployee.Enabled = false;
                ExecuteSQL();
            }
        }

        private void LoadComboList()
        {
            //common.LoadComboYear(ref cboYear);
            //common.LoadComboPeriod(ref cboPeriod, cboYear.Text);
            common.LoadComboChargeTo(ref cboCompany);
            //common.LoadComboTransactionType(ref cboTransactionType);
            //common.LoadEmployeeName(ref cboName);
            //common.LoadComboDepartment(ref cboDepartment);
            //common.LoadComboStore(ref cboStore);
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.SelectedRows.Count == 0)
                { throw new Exception("Please select an entry."); }


                string strItemID = dgvList.SelectedRows[0].Cells[0].Value.ToString();
                string strChargeToId = dgvList.SelectedRows[0].Cells[1].Value.ToString();
                //string action = dgvList.Columns[dgvList.SelectedCells[0].ColumnIndex].Tag.ToString();

                frmCashAdvanceDetail frm = new frmCashAdvanceDetail();
                frm.CashAdvanceId = Convert.ToInt32(strItemID);
                frm.ChargeToId = Convert.ToInt32(strChargeToId);

                frm.ShowDialog();

                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                { ExecuteSQL(); }

                //txtSearchValue.Text = strItemID;
                //btnSearch.PerformClick();
                //txtSearchValue.Clear();
                //dgvDashboard.Focus();

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();

            frm.LUName = txtEmployee.Text;

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtEmployee.Tag = frm.LUId;
                txtEmployee.Text = frm.LUName;
                ExecuteSQL();
            }
        }
        
        private void btnGo_Click(object sender, EventArgs e)
        {
            ExecuteSQL();
        }

        private void cboCompany_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ExecuteSQL();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //datatable does not contain definition for ExportTo
            try
            {
                DataTable dt = mvAllDT.Copy();

                foreach (DataGridViewColumn col in dgvList.Columns)
                {
                    if (col.Visible == false)
                    { dt.Columns.RemoveAt(col.Index); }
                }

                common.ExportDataTableCSV(dt);
            }
            catch (Exception ex)
            {
               function.MsgBoxInfo(this.Text, "Export To Excel Failed: \n" + ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnSearch.PerformClick(); }
        }

        private void txtEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnEmployee.PerformClick(); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strData = txtSearch.Text.Trim();

            string filterData = "[CA #] LIKE " + ("%" + strData + "%").sQuote()
                    + " OR [Store] LIKE " + ("%" + strData + "%").sQuote()
                    + " OR [Department] LIKE " + ("%" + strData + "%").sQuote()
                    + " OR [Mode of Payment] LIKE " + ("%" + strData + "%").sQuote();
            //+ " OR [Mode of Payment] LIKE " + ("%" + strData + "%").sQuote();

            mvFilterBy = filterData;

            FilterList();

            txtSearch.SelectAll();

        }
    }
}
