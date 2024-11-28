using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;

namespace MyRIS
{
    public partial class frmUserRights : Form
    {
        private Function function = new Function();
        private Common common = new Common();

        private DataTable mvAllDT;
        private DataView mvDV;

        const int IX_GRID_RIGHTS = 0;
        const int IX_GRID_ACCESS = 1;
        const int IX_GRID_CATEGORY = 2;
        const int IX_GRID_PARENT = 3;
        const int IX_GRID_CODE = 4;
        const int IX_GRID_MODULE = 5;
        const int IX_GRID_READ = 6;
        const int IX_GRID_WRITE = 7;
        const int IX_GRID_CHECK = 8;
        const int IX_GRID_VALIDATE = 9;
        const int IX_GRID_POST = 10;
        const int IX_GRID_PRINT = 11;
        
        string mvType = "";
        string mvCode = "";

        const string TYPE_GROUP = "GROUP";
        const string TYPE_USER = "USER";

        public frmUserRights()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Property

        public string Type
        {
            set { mvType = value; }
        }

        public string Code
        {
            set { mvCode = value; }
        }

        #endregion
        
        #region Procedure

        private void LoadCategory()
        {                      
            DataTable dt = new DataTable();
            
            StringBuilder sSQL = new StringBuilder();

            try
            {
                sSQL.AppendLine("SELECT SM.catCode, SMC.name AS SMCATName, ISNULL(PCat.catCode, '-1') AS PCatCode, ISNULL(PCat.name, '') AS PCatName");
                sSQL.AppendLine("FROM SystemModule SM ");
                sSQL.AppendLine("   INNER JOIN SystemModuleCategory SMC");
                sSQL.AppendLine("   	ON SMC.catCode = SM.catCode AND SMC.parentCatCode = ''");
                sSQL.AppendLine("   LEFT JOIN SystemModuleCategory PCat");
                sSQL.AppendLine("		ON PCat.parentCatCode = SM.catCode");
                sSQL.AppendLine("			AND PCat.parentCatCode <> ''");
                sSQL.AppendLine("GROUP BY SM.catCode, SMC.name, PCat.catCode, PCat.name");

                using (SQLDB sql = new SQLDB())
                {
                    dt = sql.GetDT(sSQL.ToString(), CommandType.Text);
                }


                dt.DefaultView.Sort = "catCode";
                dt = dt.DefaultView.ToTable();

                DataColumnCollection columns = dt.Columns;
                DataRowCollection rows = dt.Rows;
                
                TreeNode parent = new TreeNode();
                parent.Name = "-1";
                parent.Text = "ALL";

                foreach (DataRow row in rows) 
                {
                    if (!parent.Nodes.ContainsKey(row["catCode"].ToString()))
                    {
                        parent.Nodes.Add(row["catCode"].ToString(), row["SMCATName"].ToString());
                    }                    
                }

                tvwSelect.Nodes.Add(parent);

                foreach (DataRow row in rows)
                {   
                    if (row["PCatCode"].ToString() == row["PCatCode"].ToString())
                    {
                        if (row["PCatCode"].ToString() != "-1")
                        {
                            tvwSelect.Nodes.Find(row["catCode"].ToString(),
                                true)[0].Nodes.Add(row["PCatCode"].ToString(), row["PCatName"].ToString());
                        }
                    }                                
                }

                tvwSelect.SelectedNode = tvwSelect.Nodes[0];

                tvwSelect.ExpandAll();

            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
            }
            finally
            {
                dt.Dispose();
            }
        }

        private void TextBoxIntLeave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox txt = (TextBox)sender;
                if (txt.Text == "")
                {
                    txt.Text = "0";
                }
                else
                { txt.Text = function.FormatInteger(txt.Text); }
            }
        }

        private void TextBoxIntKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = function.IntegerOnly(e.KeyChar);
        }

        private void LoadModules()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            try
            {
                if (tvwSelect.SelectedNode.Name == "")
                { return; }

                //MODULE INFO
                sSQL.AppendLine("SELECT supportedRight, accessRight, SM.catCode, SMC.parentCatCode, SM.modCode AS Code, SM.name AS Module, CAST(0 AS BIT) AS [Read], CAST(0 AS BIT) AS Write, ");
                sSQL.AppendLine("   CAST(0 AS BIT) AS Checked, CAST(0 AS BIT) AS Validate, CAST(0 AS BIT) AS Post, CAST(0 AS BIT) AS [Print]");
                sSQL.AppendLine("FROM SystemModule SM ");
                sSQL.AppendLine("   LEFT JOIN SystemAccess SA ");
                sSQL.AppendLine("       ON SA.modCode = SM.modCode");
                sSQL.AppendLine("           AND SA.secCode = " + mvCode.sQuote());
                sSQL.AppendLine("   LEFT JOIN SystemModuleCategory SMC ");
                sSQL.AppendLine("       ON SMC.catCode = SM.catCode");
                sSQL.AppendLine("ORDER BY SM.sequenceNumber");
                
                using (SQLDB sql = new SQLDB())
                {
                    dt = sql.GetDT(sSQL.ToString(), CommandType.Text);
                }

                mvAllDT = dt.Clone();
                mvAllDT.Columns[IX_GRID_RIGHTS].ReadOnly = true;
                mvAllDT.Columns[IX_GRID_ACCESS].ReadOnly = true;
                mvAllDT.Columns[IX_GRID_CATEGORY].ReadOnly = true;
                mvAllDT.Columns[IX_GRID_PARENT].ReadOnly = true;                
                mvAllDT.Columns[IX_GRID_CODE].ReadOnly = true;
                mvAllDT.Columns[IX_GRID_MODULE].ReadOnly = true;

                for (int i = IX_GRID_READ; i < dt.Columns.Count; i++)
                {
                    mvAllDT.Columns[i].ReadOnly = false;
                }

                foreach (DataRow row in dt.Rows)
                {
                    mvAllDT.ImportRow(row);
                }

                dgvModules.DataSource = mvAllDT;

                FormatDGV();

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { dt.Dispose(); }
        }


        // Updates all child tree nodes recursively.
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        // NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
        // After a tree node's Checked property is changed, all its child nodes are updated to the same value.
        private void node_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        private void FormatDGV()
        {
            dgvModules.Columns[IX_GRID_PARENT].Visible = false;
            dgvModules.Columns[IX_GRID_RIGHTS].Visible = false;
            dgvModules.Columns[IX_GRID_ACCESS].Visible = false;
            dgvModules.Columns[IX_GRID_CATEGORY].Visible = false;

            dgvModules.Columns[IX_GRID_READ].Name = "R";
            dgvModules.Columns[IX_GRID_WRITE].Name = "W";
            dgvModules.Columns[IX_GRID_CHECK].Name = "C";
            dgvModules.Columns[IX_GRID_VALIDATE].Name = "V";
            dgvModules.Columns[IX_GRID_POST].Name = "P";
            dgvModules.Columns[IX_GRID_PRINT].Name = "T";

            foreach (DataGridViewRow dgvRows in dgvModules.Rows)
            {
                foreach (DataGridViewColumn dgvCols in dgvModules.Columns)
                {
                    if (dgvCols.Index > IX_GRID_MODULE)
                    {
                        if (dgvModules.Rows[dgvRows.Index].Cells[IX_GRID_RIGHTS].Value.ToString().Contains(dgvModules.Columns[dgvCols.Index].Name.ToString()))
                        {
                            dgvRows.Cells[dgvCols.Index].ReadOnly = false;
                            if (dgvModules.Rows[dgvRows.Index].Cells[IX_GRID_ACCESS].Value.ToString().Contains(dgvModules.Columns[dgvCols.Index].Name.ToString()))
                            { dgvRows.Cells[dgvCols.Index].Value = true; }
                            else
                            { dgvRows.Cells[dgvCols.Index].Value = false; }
                        }
                        else
                        {
                            dgvRows.Cells[dgvCols.Index].ReadOnly = true;
                        }
                    }
                }
            }

            foreach (DataGridViewColumn column in dgvModules.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        
        #endregion

        private void frmUserAccount_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadModules();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sSQL = new StringBuilder();

                sSQL.AppendLine("DECLARE @typeCode VARCHAR(50) = " + mvType.sQuote());
                sSQL.AppendLine("");   

                sSQL.AppendLine("DELETE");
                sSQL.AppendLine("FROM SystemAccess");
                sSQL.AppendLine("WHERE secCode = " + mvCode.sQuote());

                DataColumnCollection columns = mvAllDT.Columns;
                DataRowCollection rows = mvAllDT.Rows;

                foreach (DataRow dRow in rows)
                {
                    string strRights = "";

                    foreach (DataColumn dCol in columns)
                    {
                        if (dCol.Ordinal > IX_GRID_MODULE)
                        {
                            if (dRow[dCol.ColumnName].ToString() != "")
                            {
                                if (dRow[dCol.ColumnName].ToString() == "True")
                                {
                                    strRights += dgvModules.Columns[dCol.Ordinal].Name;
                                }
                            }
                        }
                    }

                    if (strRights != "")
                    {
                        sSQL.AppendLine("");    

                        sSQL.AppendLine("INSERT INTO SystemAccess(modCode, secCode, accessRight)");
                        sSQL.AppendLine("VALUES(" + dRow[IX_GRID_CODE].ToString().sQuote() + ", " + mvCode.sQuote() + ", " + strRights.sQuote() + ")");
                    }
                }


                using (SQLDB sql = new SQLDB())
                {
                    sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text);
                }

                function.MsgBoxInfo(this.Text, "Save Successful.");
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void tvwSelect_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string ModCode = tvwSelect.SelectedNode.Name;

                if (ModCode != "-1")
                {
                    mvDV = new DataView(mvAllDT);

                    if (tvwSelect.SelectedNode.Nodes.Count > 0)
                    {
                        mvDV.RowFilter = "parentCatCode = " + ModCode.sQuote();
                    }
                    else
                    {
                         mvDV.RowFilter = "catCode = " + ModCode.sQuote();
                    }
                }
                else
                {
                    if (tvwSelect.SelectedNode.Text == "ALL" && mvAllDT != null)
                    {
                        mvDV = new DataView(mvAllDT);
                    }

                }

                if (mvDV != null)
                {

                    dgvModules.DataSource = mvDV;

                    dgvModules.Columns[IX_GRID_READ].Name = "R";
                    dgvModules.Columns[IX_GRID_WRITE].Name = "W";
                    dgvModules.Columns[IX_GRID_CHECK].Name = "C";
                    dgvModules.Columns[IX_GRID_VALIDATE].Name = "V";
                    dgvModules.Columns[IX_GRID_POST].Name = "P";
                    dgvModules.Columns[IX_GRID_PRINT].Name = "T";

                    foreach (DataGridViewRow dgvRows in dgvModules.Rows)
                    {
                        foreach (DataGridViewColumn dgvCols in dgvModules.Columns)
                        {
                            if (dgvCols.Index > IX_GRID_MODULE)
                            {
                                if (dgvModules.Rows[dgvRows.Index].Cells[IX_GRID_RIGHTS].Value.ToString().Contains(dgvModules.Columns[dgvCols.Index].Name.ToString()))
                                {
                                    dgvRows.Cells[dgvCols.Index].ReadOnly = false;
                                }
                                else
                                {
                                    dgvRows.Cells[dgvCols.Index].ReadOnly = true;
                                }
                            }
                        }
                    }

                }                
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void tvwSelect_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            { 
                cmsCategory.Show(Cursor.Position);
            }
        }

        private void mnuFullRights_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgridRow in dgvModules.Rows)
            {
                foreach (DataGridViewCell dgridCell in dgridRow.Cells)
                {
                    if (!dgridCell.ReadOnly)
                    {
                        dgridCell.Value = true;
                    }
                }
            }
        }

        private void dgvModules_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > IX_GRID_MODULE && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (!dgvModules.Rows[e.RowIndex].Cells[IX_GRID_RIGHTS].Value.ToString().Contains(dgvModules.Columns[e.ColumnIndex].Name.ToString()))
                {
                    e.PaintBackground(e.ClipBounds, true);
                    e.Handled = true;
                }
            }
        }

        private void mnuRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgridRow in dgvModules.Rows)
            {
                foreach (DataGridViewCell dgridCell in dgridRow.Cells)
                {
                    if (!dgridCell.ReadOnly)
                    {
                        dgridCell.Value = false;
                    }
                }
            }
        }

        private void dgvModules_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > IX_GRID_MODULE)
            {
                foreach (DataGridViewRow dgridRow in dgvModules.Rows)
                {
                    if (Convert.ToBoolean(dgridRow.Cells[e.ColumnIndex].Value) == false)
                    { dgridRow.Cells[e.ColumnIndex].Value = true; }
                    else
                    { dgridRow.Cells[e.ColumnIndex].Value = false; }
                }
            }
        }
    }
}
