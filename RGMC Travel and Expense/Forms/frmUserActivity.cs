using MyCommon;
using MyCommon.Data;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MyRIS
{
    public partial class frmUserActivity : Form
    {
        private Function function = new Function();

        private string mvFilterBy = "";

        private DataTable mvAllDT = new DataTable();
        private DataTable mvDT = new DataTable();

        public frmUserActivity()
        {
            InitializeComponent();
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

                }
                else
                {
                    mvDT = mvAllDT.Copy();
                }

                if (mvDT.Rows.Count == 0)
                { throw new Exception("User not found."); }

                mvDT.DefaultView.Sort = "[LAST LOGIN] DESC";
                mvDT = mvDT.DefaultView.ToTable();
                
                dgvActionHistory.DataSource = mvDT;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void LoadActionHistory()
        {
            StringBuilder sSQL = new StringBuilder();
            
            try
            {
                using (SQLDB sql = new SQLDB())
                {
                    sSQL.AppendLine("SELECT A.secCode AS USERNAME,  CONCAT(D.lastName, ', ', D.firstName) AS NAME, lastLogin AS 'LAST LOGIN', lastAction AS 'LAST ACTION', lastActivity AS 'LAST ACTIVITY'");
                    sSQL.AppendLine("FROM ActivityLog A");
                    sSQL.AppendLine("   INNER JOIN SystemUser D ON D.secCode = A.secCode");

                    mvAllDT = sql.GetDT(sSQL.ToString(), CommandType.Text);

                    FilterList();
                }
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void frmProductDesignHistory_Load(object sender, EventArgs e)
        {
            LoadActionHistory();
        }

        private void dgvActionHistory_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            btnFilter.PerformClick();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string strData = txtUser.Text.Trim();

            string filterData = "NAME LIKE " + ("%" + strData + "%").sQuote();

            mvFilterBy = filterData;

            FilterList();
        }
    }
}
