using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;
using MyCommon.LViewSorter;

namespace MyRIS
{
    public partial class frmSearchNatureOfExpense : Form
    {
        private Function function = new Function();

        private string mvId = "-1";
        private string mvName = "";

        private const int IX_GRID_ID = 0;
        private const int IX_GRID_NAME = 1;

        public frmSearchNatureOfExpense()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Property

        public string GROUP
        {
            set { mvName = value; }
        }

        public string LUId
        {
            get { return mvId; }
        }

        public string LUName
        {
            get { return mvName; }
            set { mvName = value; }
        }

        #endregion

        #region Procedure

        private void GetDetailInfo()
        {
            try
            {
                if (dgrid.SelectedRows.Count == 0)
                { throw new Exception("Select an item."); }

                mvId = dgrid.SelectedRows[0].Cells[IX_GRID_ID].Value.ToString();
                mvName = dgrid.SelectedRows[0].Cells[IX_GRID_NAME].Value.ToString();

                DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void LoadListView()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            string strName = txtName.Text.Trim();

            try
            {
                //if (strName == "")
                //{ throw new Exception("Name is required for searching."); }                

                sSQL.AppendLine("SELECT natureOfExpenseId AS [ID], natureOfExpenseName AS [Nature of Expense]");
                sSQL.AppendLine("FROM NatureOfExpense");
                //sSQL.AppendLine("WHERE isActive = 1");

                if (strName != "")
                { sSQL.AppendLine("    WHERE natureOfExpenseName LIKE " + ("%" + strName + "%").sQuote()); }

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString()); }

                dt.DefaultView.Sort = "[Nature of Expense]";
                dt = dt.DefaultView.ToTable();

                dgrid.DataSource = dt;

                dgrid.Columns[IX_GRID_ID].Visible = false;

                if (dgrid.Rows.Count > 0)
                {
                    dgrid.Focus();
                    dgrid.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { dt.Dispose(); }
        }
        
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GetDetailInfo();
        }

        private void dgrid_MouseHover(object sender, EventArgs e)
        {
            if (dgrid.Rows.Count > 0)
            { Cursor = Cursors.Hand; }
        }

        private void dgrid_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void frmSearchNatureOfExpense_Load(object sender, EventArgs e)
        {
            txtName.Text = mvName;

            btnGo.PerformClick();            
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { LoadListView(); }
        }

        private void dgrid_DoubleClick(object sender, EventArgs e)
        {
            GetDetailInfo();
        }

        private void dgrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { GetDetailInfo(); }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.SelectAll();
        }      
    }
}
