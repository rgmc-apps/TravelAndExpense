using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;

namespace MyRIS
{
    public partial class frmAddGroup : Form
    {
        private Function function = new Function();
        private Common common = new Common();

        const int IX_GRID_SEC_CODE = 0;
        const int IX_GRID_TYPE_CODE = 1;
        const int IX_GRID_NAME = 2;
        const int IX_GRID_PASSWORD = 3;
        const int IX_GRID_IS_ACTIVE = 4;

        int mvLastIndex = 0;

        string mvType = "";
        string mvCode = "";

        const string TYPE_GROUP = "GROUP";
        const string TYPE_USER = "USER";

        public frmAddGroup()
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

        private void LoadInfo()
        {                      
            DataTable dtUser = new DataTable();
            DataTable dtCostCenter = new DataTable();

            DataTable[] refDT = { dtUser, dtCostCenter };

            StringBuilder sSQL = new StringBuilder();

            try
            {
                //USER INFO
                sSQL.AppendLine("SELECT SU.secCode, SU.name, ISNULL(Head.employeeId, -1) AS headCode, Head.name AS headName ");
                sSQL.AppendLine("FROM SystemUser SU");
                sSQL.AppendLine("   LEFT JOIN CostCenter CC ON CC.costCenterCode = SU.secCode ");
                sSQL.AppendLine("   LEFT JOIN SystemUser Head ON Head.employeeId = CC.employeeId AND CC.employeeId <> -1 ");
                sSQL.AppendLine("WHERE SU.typeCode = " + mvType.sQuote());
                sSQL.AppendLine("   AND SU.secCode = " + mvCode.sQuote());


                using (SQLDB sql = new SQLDB())
                {
                    //SqlParameter pUser = new SqlParameter("@username", SqlDbType.VarChar, 20);
                    //pUser.Value = GlobalSettings.UserName;

                    sql.GetDT(ref refDT, sSQL.ToString(), CommandType.Text);
                }

                    txtCode.Text = dtUser.Rows[0]["secCode"].ToString();                
                    txtName.Text = dtUser.Rows[0]["name"].ToString();

                    txtGroupHead.Tag = dtUser.Rows[0]["headCode"].ToString();
                    txtGroupHead.Text = dtUser.Rows[0]["headName"].ToString();
            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
            }
            finally
            {
                dtUser.Dispose();
                dtCostCenter.Dispose();
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


        private void FormatObject()
        {
            if (mvCode != "")
            {
                txtCode.ReadOnly = true;
                //txtPassword.ReadOnly = true;
            }
        }

        private void LoadUsers()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            try
            {
                sSQL.AppendLine("SELECT SU.secCode, name AS [Users]");
                sSQL.AppendLine("FROM SystemUser SU");
                sSQL.AppendLine("WHERE typeCode = " + TYPE_USER.sQuote());
                
                using (SQLDB sql = new SQLDB())
                {
                    dt = sql.GetDT(sSQL.ToString(), CommandType.Text);
                }

                dgvUsers.DataSource = dt;
                dgvUsers.Columns[0].Visible = false;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { dt.Dispose(); }
        }

        private void  LoadMembers()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            try
            {
                sSQL.AppendLine("SELECT SU.secCode, name");
                sSQL.AppendLine("FROM SystemUser SU");
                sSQL.AppendLine("   INNER JOIN SystemMember SM ON SM.secCode = SU.secCode");
                sSQL.AppendLine("       AND SM.groupCode = " + mvCode.sQuote());
                sSQL.AppendLine("WHERE typeCode = " + TYPE_USER.sQuote());
                sSQL.AppendLine("GROUP BY SU.secCode, name");
                sSQL.AppendLine("ORDER BY name ");

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString(), CommandType.Text); }

                if (dt.Rows.Count == 0)
                { return; }

                dgvMembers.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                { dgvMembers.Rows.Add(row["secCode"], row["name"]); }
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { dt.Dispose(); }
        }

        #endregion

        private void frmUserAccount_Load(object sender, EventArgs e)
        {
            FormatObject();

            this.Text = "ADD GROUP";
            //txtCode.ReadOnly = true;
            //txtGraceLogin.ReadOnly = true;
            
            if (mvCode != "")
            {
                LoadInfo();
                LoadUsers();
                LoadMembers();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strCode = txtCode.Text.Trim();
                string strName = txtName.Text.Trim();
                //string GraceLogin = txtGraceLogin.Text.Trim();
                //string ExpirationDate = dtpExpirationDate.Value.ToShortDateString();
                //int isActive = Convert.ToInt32(chkActive.CheckState);

                if (mvCode == "")
                {
                    if (strCode == "")
                    {
                        txtCode.Focus();
                        throw new Exception("Code is required");
                    }

                    if (strName == "")
                    {
                        txtName.Focus();
                        throw new Exception("Name is required");
                    }

                }
                //if (GraceLogin == "")
                //{
                //    txtGraceLogin.Focus();
                //    throw new Exception("Login Attempts is required");
                //}

                StringBuilder sSQL = new StringBuilder();

                sSQL.AppendLine("DECLARE @secCode VARCHAR(50) = " + strCode.sQuote());
                sSQL.AppendLine("DECLARE @typeCode VARCHAR(50) = " + mvType.sQuote());
                sSQL.AppendLine("DECLARE @name VARCHAR(100) = " + strName.sQuote());
                sSQL.AppendLine("DECLARE @password VARCHAR(50) = " + strCode.sQuote());
                sSQL.AppendLine("DECLARE @errorMessage VARCHAR(250)");
                //sSQL.AppendLine("DECLARE @expirationDate DATE = ");
                //sSQL.AppendLine("DECLARE @graceLoginLeft INT = ");
                //sSQL.AppendLine("DECLARE @isActive BIT = ";

                if (mvCode == "")
                {

                    sSQL.AppendLine("SELECT secCode");
                    sSQL.AppendLine("FROM SystemUser");
                    sSQL.AppendLine("WHERE secCode = @secCode");

                    sSQL.AppendLine("");

                    sSQL.AppendLine("IF @@ROWCOUNT > 0");
                    sSQL.AppendLine("    BEGIN");
                    sSQL.AppendLine("        SELECT @errorMessage = " + mvType.sQuote() + "' already exist.'");
                    sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                    sSQL.AppendLine("        ROLLBACK TRANSACTION");
                    sSQL.AppendLine("        RETURN");
                    sSQL.AppendLine("    END");

                    sSQL.AppendLine("INSERT INTO SystemUser(secCode, typeCode, name, password)");
                    sSQL.AppendLine("VALUES(@secCode, @typeCode, @name, @password)");
                }
                else
                {
                    sSQL.AppendLine("UPDATE SystemUser");
                    sSQL.AppendLine("   SET name = @name");
                    sSQL.AppendLine("WHERE secCode = @secCode");


                    sSQL.AppendLine("DELETE");
                    sSQL.AppendLine("FROM SystemMember");
                    sSQL.AppendLine("WHERE groupCode = @secCode");

                    for (int i = 0; i < dgvMembers.Rows.Count; i++)
                    {
                            sSQL.AppendLine("INSERT INTO SystemMember(secCode, groupCode)");
                            sSQL.AppendLine("VALUES(" + dgvMembers[0, i].Value.ToString().sQuote() + ", @secCode)");
                    }
                }

                sSQL.AppendLine("UPDATE CostCenter");
                sSQL.AppendLine("   SET employeeId = " + txtGroupHead.Tag);
                sSQL.AppendLine("WHERE costCenterCode = @secCode");


                using (SQLDB sql = new SQLDB())
                {
                    sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text);
                }

                function.MsgBoxInfo(this.Text, "Save Successful.");
                txtCode.ReadOnly = true;

                LoadInfo();
                LoadUsers();
                LoadMembers();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }        
        
        private void btnRight_Click(object sender, EventArgs e)
        {
            frmUserRights frm = new frmUserRights();
            frm.txtName.Text = txtName.Text;
            frm.Code = mvCode;
            frm.ShowDialog();
            frm.Dispose();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvUsers.Focus();

                String searchValue = txtMember.Text;

                if (mvLastIndex == -1)
                { mvLastIndex = 0; }
                else
                { mvLastIndex += 1; }

                for (int i = mvLastIndex; i < dgvUsers.Rows.Count; i++)
                {
                    if (dgvUsers[1, i].Value.ToString().Contains(searchValue))
                    {
                        mvLastIndex = i;
                        break;
                    }
                    else if (i == (dgvUsers.Rows.Count - 1))
                    {
                        mvLastIndex = 0;
                        break;
                    }
                }

                if (mvLastIndex != -1)
                {
                    dgvUsers[1, mvLastIndex].Selected = true;
                }

            } catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void txtMember_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (mvType == TYPE_GROUP)
            { txtName.Text = txtCode.Text; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvMembers.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Contains(dgvUsers.SelectedCells[0].Value.ToString()))
                        { throw new Exception("User is already a Member"); }
                    }

                    for (int i = 0; i < dgvUsers.SelectedCells.Count; i++)
                    {
                        dgvMembers.Rows.Add(dgvUsers[0, dgvUsers.SelectedCells[i].RowIndex].Value, dgvUsers[1, dgvUsers.SelectedCells[i].RowIndex].Value);
                    }
                }

            } catch(Exception ex) 
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedCells.Count > 0)
            { dgvMembers.Rows.RemoveAt(dgvMembers.SelectedCells[0].RowIndex); }
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();
            
            //frm.LUName = txtApproved.Text;

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtGroupHead.Tag = frm.LUId;
                txtGroupHead.Text = frm.LUName;
            }
        }

        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void dgvMembers_DoubleClick(object sender, EventArgs e)
        {
            btnRemove.PerformClick();
        }

        private void dgvUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvMembers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnRemove.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
