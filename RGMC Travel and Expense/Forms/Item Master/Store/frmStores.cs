using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;
using MyCommon.LViewSorter;
using MyCommon.Settings;

namespace MyRIS
{
    public partial class frmStores : Form
    {
        private Common common = new Common();
        private Function function = new Function();

        private DataTable mvAllDT = new DataTable();
        private DataTable mvDT = new DataTable();

        private string mvFilterBy = "";
        private string mvFilterCaption = "";

        private string mvSortBy = "";

        public frmStores()
        {
            InitializeComponent();
        }

        #region Procedure

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

                dgrid.DataSource = mvDT;
                lblCount.Text = function.FormatInteger(mvDT.Rows.Count.ToString());
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void DataGridViewColumnFormat(DataGridView dgv, int colIndex, string headerText, int colWidth, bool isVisible = true, bool isReadOnly = true)
        {
            dgv.Columns[colIndex].HeaderText = headerText;
            dgv.Columns[colIndex].Width = colWidth;
            dgv.Columns[colIndex].Visible = isVisible;
            dgv.Columns[colIndex].ReadOnly = isReadOnly;
        }

        private void ExecuteSQL()
        {
            StringBuilder sSQL = new StringBuilder();

            try
            {
                sSQL.AppendLine("SELECT storeId [Store ID], storeName AS Name, storeCode AS Code, navCode AS [Nav Code], remark AS Remark,");
                sSQL.AppendLine("    CASE");
                sSQL.AppendLine("    WHEN isActive = 1 THEN");
                sSQL.AppendLine("        'Y'");
                sSQL.AppendLine("    ELSE");
                sSQL.AppendLine("        'N'");
                sSQL.AppendLine("    END AS [Is Active?],");
                sSQL.AppendLine("    updateBy AS [Updated By], updateDate AS [Updated Date]");
                sSQL.AppendLine("FROM Stores");

                using (SQLDB sql = new SQLDB())
                { mvAllDT = sql.GetDT(sSQL.ToString()); }

                mvSortBy = "Name";

                dgrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                FilterList();
                dgrid.Columns[0].Visible = false;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        public void CommandPass(string strCommand)
        {
            try
            {
                switch (strCommand)
                {
                    case Declaration.NEW_COMMAND:
                        if (function.HasAccess(Declaration.MOD_CODE_NATURE_OF_EXPENSE, GlobalSettings.ACCESS_WRITE) == false)
                        { throw new Exception("Sorry you have no access in this module."); }

                        ShowDetail(strCommand);
                        break;

                    case Declaration.OPEN_COMMAND:
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

            for (int intColumn = 0; intColumn < dgrid.Columns.Count; intColumn++)
            {
                strName = dgrid.Columns[intColumn].HeaderText.ToUpper();
                strTag = mvAllDT.Columns[intColumn].ColumnName;

                if (dgrid.Columns[intColumn].Visible != false)
                {
                    strTag = strTag + GlobalSettings.DELIMITER + GlobalSettings.TEXT;

                    dt.Rows.Add(strTag, strName);
                }
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
            long lngId = -1;

            try
            {
                if (strCommand == Declaration.OPEN_COMMAND)
                {
                    if (dgrid.SelectedRows.Count == 0)
                    { throw new Exception("Select an item to edit."); }

                    lngId = Convert.ToInt64(dgrid.SelectedRows[0].Cells[0].Value);
                }

                frmStoresDetail frm = new frmStoresDetail();

                frm.StoreId = lngId;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ExecuteSQL();
                    findDgridItem(frm.StoreName);
                }

                frm.Dispose();
            }

            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void findDgridItem(string storeName)
        {
            foreach (DataGridViewRow row in dgrid.Rows)
            {
                // 0 is the column index
                if (row.Cells[1].Value.ToString().Equals(storeName))
                {
                    dgrid.ClearSelection();
                    row.Selected = true;
                    dgrid.Focus();
                    break;
                }
            }
        }

        #endregion

        private void dgrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            { ShowDetail(Declaration.NEW_COMMAND); }

            if (e.KeyCode == Keys.Enter)
            {
                ShowDetail(Declaration.OPEN_COMMAND);
                e.SuppressKeyPress = true;
            }
        }

        private void dgrid_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void dgrid_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void dgrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            { ShowDetail(Declaration.OPEN_COMMAND); }
        }

        private void frmStore_Load(object sender, EventArgs e)
        {
            ExecuteSQL();
        }

        private void btnSearchItemID_Click(object sender, EventArgs e)
        {
            string strData = txtSearch.Text.Trim();

            string filterData = "Name LIKE " + ("%" + strData + "%").sQuote()
                    + " OR Code LIKE " + ("%" + strData + "%").sQuote();

            mvFilterBy = filterData;

            FilterList();

            txtSearch.SelectAll();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmStoresDetail frm = new frmStoresDetail();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                ExecuteSQL();
                findDgridItem(frm.StoreName);
            }

            frm.Dispose();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = mvAllDT.Copy();

                foreach (DataGridViewColumn col in dgrid.Columns)
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
            { btnSearchItemID.PerformClick(); }
        }
    }
}