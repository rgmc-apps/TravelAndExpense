using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;
using MyCommon.LViewSorter;

namespace MyRIS
{
    public partial class frmSearchBusinessPurpose : Form
    {
        private Function function = new Function();

        private string mvId = "-1";
        private string mvName = "";

        const int IX_DISPLAY_START = 2;

        public frmSearchBusinessPurpose()
        {
            InitializeComponent();
        }

        #region Property

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
                if (lvwList.SelectedItems.Count == 0)
                { throw new Exception("Select an item."); }

                mvId = lvwList.SelectedItems[0].Tag.ToString();
                mvName = lvwList.SelectedItems[0].Text;

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

                sSQL.AppendLine("SELECT businessPurposeId, businessPurposeName");
                sSQL.AppendLine("FROM BusinessPurpose");
                //sSQL.AppendLine("WHERE isActive = 1");

                if (strName != "")
                { sSQL.AppendLine("    WHERE businessPurposeName LIKE " + ("%" + strName + "%").sQuote()); }

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString()); }

                dt.DefaultView.Sort = "businessPurposeName";
                dt = dt.DefaultView.ToTable();

                function.PopulateListView(lvwList, dt, IX_DISPLAY_START);

                if (lvwList.Items.Count > 0)
                {
                    lvwList.Focus();
                    lvwList.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { dt.Dispose(); }
        }

        private void CreateListView()
        {
            lvwList.Columns.Add("Business Purpose", 250, HorizontalAlignment.Left);
            //lvwList.Columns.Add("Code", 100, HorizontalAlignment.Left);
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

        private void lvwList_MouseHover(object sender, EventArgs e)
        {
            if (lvwList.Items.Count > 0)
            { Cursor = Cursors.Hand; }
        }

        private void lvwList_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void frmSearchBusinessPurpose_Load(object sender, EventArgs e)
        {
            CreateListView();

            txtName.Text = mvName;

            btnGo.PerformClick();

            lvwList.ListViewItemSorter = new LViewSorter(0);
            lvwList_ColumnClick(null, new ColumnClickEventArgs(0));
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

        private void lvwList_DoubleClick(object sender, EventArgs e)
        {
            GetDetailInfo();
        }

        private void lvwList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { GetDetailInfo(); }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.SelectAll();
        }

        private void lvwList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            LViewSorter sorter = (LViewSorter)lvwList.ListViewItemSorter;

            if (e.Column == sorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (sorter.SortOrder == SortOrder.Ascending)
                { sorter.SortOrder = SortOrder.Descending; }
                else
                { sorter.SortOrder = SortOrder.Ascending; }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.SortColumn = e.Column;
                sorter.SortOrder = SortOrder.Ascending;
            }

            for (int intRow = 0; intRow < lvwList.Columns.Count; intRow++)
            { LViewColumnHeader.SetColumnHeaderSortIcon(lvwList, intRow, intRow == sorter.SortColumn ? sorter.SortOrder : SortOrder.None); }

            lvwList.Sort();
        }
    }
}
