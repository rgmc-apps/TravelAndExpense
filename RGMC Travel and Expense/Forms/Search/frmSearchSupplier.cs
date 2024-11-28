using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;
using MyCommon.LViewSorter;

namespace MyRIS
{
    public partial class frmSearchSupplier : Form
    {
        private Function function = new Function();
        
        private bool mvIsNew = true;

        private string mvId = "-1";
        private string mvCode = "";
        private string mvName = "";
        private string mvAddress = "";

        DataTable mvDT = new DataTable();

        const int IX_ID = 0;
        const int IX_NAME = 1;
        const int IX_CODE = 2;
        const int IX_ADDRESS = 3;

        public frmSearchSupplier()
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

        public bool isNew
        {
            set { mvIsNew = value; }
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
        
        public string LUCode
        {
            get { return mvCode; }
        }
        
        public string LUAddress
        {
            get { return mvAddress; }
            set { mvAddress = value; }
        }

        #endregion

        #region Procedure

        private void GetDetailInfo()
        {
            try
            {
                if (dgrid.SelectedRows.Count == 0)
                { throw new Exception("Select an item."); }

                mvId = dgrid.SelectedRows[0].Cells[IX_ID].Value.ToString();
                mvName = dgrid.SelectedRows[0].Cells[IX_NAME].Value.ToString();
                mvCode = dgrid.SelectedRows[0].Cells[IX_CODE].Value.ToString();
                mvAddress = dgrid.SelectedRows[0].Cells[IX_ADDRESS].Value.ToString();

                DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void LoadDataGridView()
        {
            dgrid.DataSource = mvDT;

            dgrid.Columns[0].Visible = false;
            dgrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgrid.Rows.Count > 0)
            {
                dgrid.Focus();
                dgrid.Rows[0].Selected = true;
            }
        }

        private void LoadListView()
        {
            StringBuilder sSQL = new StringBuilder();

            string strName = txtName.Text.Trim();

            try
            {
                sSQL.AppendLine("SELECT vendorId AS [ID], vendorName AS [Name], tin AS [TIN], address AS [Address]");
                sSQL.AppendLine("FROM Vendor");

                //if (mvIsNew == false)
                //{
                    //sSQL.AppendLine("LEFT JOIN EPV R ON R.employeeId = E.employeeId");
                    //sSQL.AppendLine("   AND PDS.productDesignId = " + mvProductDesignId);
                //}

                //sSQL.AppendLine("WHERE isActive = 1");  

                if (strName != "")
                { sSQL.AppendLine("WHERE vendorName LIKE " + (strName + "%").sQuote()); }                
                
                using (SQLDB sql = new SQLDB())
                {   mvDT = sql.GetDT(sSQL.ToString());}

                mvDT.DefaultView.Sort = "Name";
                mvDT = mvDT.DefaultView.ToTable();

                LoadDataGridView();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
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

        private void frmSearchBrand_Load(object sender, EventArgs e)
        {
            txtName.Text = mvName;

            btnGo.PerformClick();

            dgrid.Focus();       
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
