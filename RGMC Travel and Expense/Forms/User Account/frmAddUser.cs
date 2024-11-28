using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;

namespace MyRIS
{
    public partial class frmAddUser : Form
    {
        private Function function = new Function();
        private Common common = new Common();

        const int IX_GRID_SEC_CODE = 0;
        const int IX_GRID_TYPE_CODE = 1;
        const int IX_GRID_NAME = 2;
        const int IX_GRID_PASSWORD = 3;
        const int IX_GRID_IS_ACTIVE = 4;

        string mvType = "";
        string mvCode = "";

        const string TYPE_GROUP = "GROUP";
        const string TYPE_USER = "USER";

        public frmAddUser()
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

            if (keyData == (Keys.Control | Keys.Shift | Keys.P ))
            {
                function.MsgBoxInfo(this.Text, txtPassword.Text);
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

        private void LoadUserAccount()
        {                      
            DataTable dtUser = new DataTable();

            DataTable[] refDT = { dtUser };

            StringBuilder sSQL = new StringBuilder();

            try
            {
                //USER INFO
                sSQL.AppendLine("SELECT secCode, email, lastName, firstName, middleName, name, password, costCenterId, isActive ");
                sSQL.AppendLine("FROM SystemUser ");
                sSQL.AppendLine("WHERE typeCode = " + mvType.sQuote());
                sSQL.AppendLine("   AND secCode = " + mvCode.sQuote());


                using (SQLDB sql = new SQLDB())
                {
                    //SqlParameter pUser = new SqlParameter("@username", SqlDbType.VarChar, 20);
                    //pUser.Value = GlobalSettings.UserName;

                    sql.GetDT(ref refDT, sSQL.ToString(), CommandType.Text);
                }

                foreach (DataRow dr in dtUser.Rows)
                {
                    txtCode.Text = dr["secCode"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    txtLastName.Text = dr["lastName"].ToString();
                    txtFirstName.Text = dr["firstName"].ToString();
                    txtMiddleName.Text = dr["middleName"].ToString();
                    txtName.Text = dr["name"].ToString();
                    txtPassword.Text = dr["password"].ToString().Decrypt();
                    txtPassConfirm.Text = dr["password"].ToString().Decrypt();
                    cboDepartment.SelectedValue = dr["costCenterId"];
                    //dtpExpirationDate.Value = Convert.ToDateTime(dr[IX_GRID_EXPIRATION_DATE]);
                    //txtGraceLogin.Text = dr[IX_GRID_LOGIN_LEFT].ToString();
                    //chkActive.Checked = Convert.ToBoolean(dr[IX_GRID_IS_ACTIVE]);
                }

            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
            }
            finally
            {
                dtUser.Dispose();
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
                btnRight.Enabled = true;
            }
        }

        private void LoadMembersOf()
        {
            DataTable dt = new DataTable();
            DataTable subdt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            try
            {
                sSQL.AppendLine("SELECT SU.secCode AS groupCode, typeCode, name AS groupName, password, isActive, SM.secCode ");
                sSQL.AppendLine("FROM SystemUser SU");
                sSQL.AppendLine("   LEFT JOIN SystemMember SM ON SM.groupCode = SU.secCode");
                sSQL.AppendLine("	    AND SM.secCode = " + mvCode.sQuote());
                sSQL.AppendLine("WHERE typeCode = " + TYPE_GROUP.sQuote());
                sSQL.AppendLine("	AND SU.secCode != " + mvCode.sQuote());

                using (SQLDB sql = new SQLDB())
                {
                    dt = sql.GetDT(sSQL.ToString(), CommandType.Text);
                }

                DataColumnCollection columns = dt.Columns;
                DataRowCollection rows = dt.Rows;

                TreeNode parent = new TreeNode();
                parent.Name = "-1";
                parent.Text = "ALL";

                foreach (DataRow row in rows)
                {
                    if (!parent.Nodes.ContainsKey(row["groupCode"].ToString()))
                    {
                        parent.Nodes.Add(row["groupCode"].ToString(), row["groupName"].ToString());
                    }

                    if (row["secCode"].ToString() != "")
                    {
                        parent.Nodes.Find(row["groupCode"].ToString(),
                            true)[0].Checked = true;
                    }
                }


                //foreach (DataRow row in rows)
                //{
                //    if (!tvwMembersOf.Nodes.ContainsKey(row["groupCode"].ToString()))
                //    {
                //        tvwMembersOf.Nodes.Add(row["groupCode"].ToString(), row["groupName"].ToString());
                //    }

                //    if (row["secCode"].ToString() != "")
                //    {
                //        tvwMembersOf.Nodes.Find(row["groupCode"].ToString(),
                //            true)[0].Checked = true;
                //    }

                //    //if (row["sdsCode"].ToString() == row["dsCode"].ToString())
                //    //{
                //    //    tvwMembers.Nodes.Find(row["dsCode"].ToString(),
                //    //        true)[0].Nodes.Add(row["subDesignepvStatusId"].ToString(), row["subDesignStatusName"].ToString());
                //    //}
                //}

                tvwMembersOf.Nodes.Add(parent);
                tvwMembersOf.ExpandAll();

                //tvwDesignStatus.SelectedNode = tvwDesignStatus.Nodes[0];

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { dt.Dispose(); }
        }

        #endregion

        private void LoadComboDepartment()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            try
            {
                dt.Columns.Add("costCenterId");
                dt.Columns.Add("costCenterName");

                sSQL.AppendLine("SELECT [costCenterId], [costCenterName] FROM CostCenter");

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString()); }

                dt.DefaultView.Sort = "costCenterName";
                dt = dt.DefaultView.ToTable();

                cboDepartment.DataSource = dt;
                cboDepartment.DisplayMember = "costCenterName";
                cboDepartment.ValueMember = "costCenterId";

                cboDepartment.SelectedIndex = -1;

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void frmUserAccount_Load(object sender, EventArgs e)
        {
            FormatObject();

            LoadComboDepartment();

            if (mvType == TYPE_GROUP)
            {
                this.Text = "ADD GROUP";
                txtName.ReadOnly = true;
                txtPassword.ReadOnly = true;               
                //txtGraceLogin.ReadOnly = true;
            }
            else
            { this.Text = "ADD USER"; }

            if (mvCode != "")
            {
                LoadUserAccount();
                LoadMembersOf();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strCode = txtCode.Text.Trim();
                string strLastName = txtLastName.Text.Trim();
                string strFirstName = txtFirstName.Text.Trim();
                string strMiddleName = txtMiddleName.Text.Trim();
                string strName = strLastName + ", " + strFirstName + " " + strMiddleName;
                string strEmail = txtEmail.Text.Trim();
                string strPassword = txtPassword.Text.Trim().Encrypt();
                string strConfirmPassword = txtPassConfirm.Text.Encrypt();

                //string GraceLogin = txtGraceLogin.Text.Trim();
                //string ExpirationDate = dtpExpirationDate.Value.ToShortDateString();
                //int isActive = Convert.ToInt32(chkActive.CheckState);

                if (mvCode == "")
                {
                    if (cboDepartment.SelectedValue == null)
                    {
                        cboDepartment.Focus();
                        throw new Exception("Department is required");
                    }

                    if (strCode == "")
                    {
                        txtCode.Focus();
                        throw new Exception("Code is required");
                    }
                    
                    if (strLastName == "")
                    {
                        txtLastName.Focus();
                        throw new Exception("Last Name is required");
                    }

                    if (strFirstName == "")
                    {
                        txtFirstName.Focus();
                        throw new Exception("First Name is required");
                    }                    

                    if (strName == "")
                    {
                        txtName.Focus();
                        throw new Exception("Name is required");
                    }                    
                }         

                if (!strConfirmPassword.Equals(strPassword))
                {
                    txtPassConfirm.Focus();
                    throw new Exception("Password doest not match");
                }
                
                StringBuilder sSQL = new StringBuilder();
                sSQL.AppendLine("DECLARE @employeeId INT ");
                sSQL.AppendLine("DECLARE @costCenterId INT = " + cboDepartment.SelectedValue);
                sSQL.AppendLine("DECLARE @secCode VARCHAR(50) = " + strCode.sQuote());
                sSQL.AppendLine("DECLARE @lastName VARCHAR(50) = " + strLastName.sQuote());
                sSQL.AppendLine("DECLARE @firstName VARCHAR(50) = " + strFirstName.sQuote());
                sSQL.AppendLine("DECLARE @middleName VARCHAR(50) = " + strMiddleName.sQuote());
                sSQL.AppendLine("DECLARE @typeCode VARCHAR(50) = " + mvType.sQuote());
                sSQL.AppendLine("DECLARE @name VARCHAR(100) = " + strName.sQuote());
                sSQL.AppendLine("DECLARE @email VARCHAR(60) = " + strEmail.sQuote());
                sSQL.AppendLine("DECLARE @errorMessage VARCHAR(250)");

                if (mvCode == "")
                {
                    sSQL.AppendLine("SELECT secCode");
                    sSQL.AppendLine("FROM SystemUser");
                    sSQL.AppendLine("WHERE secCode = @secCode");

                    sSQL.AppendLine("");

                    sSQL.AppendLine("IF @@ROWCOUNT > 0");
                    sSQL.AppendLine("    BEGIN");
                    sSQL.AppendLine("        SELECT @errorMessage = ' " + strCode + " already exist.'");
                    sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                    sSQL.AppendLine("        ROLLBACK TRANSACTION");
                    sSQL.AppendLine("        RETURN");
                    sSQL.AppendLine("    END");
                    
                    sSQL.AppendLine(function.GenerateIdScript("employeeId"));

                    sSQL.AppendLine("INSERT INTO SystemUser(employeeId, secCode, typeCode, email, lastName, firstName, middleName, name, password, costCenterId)");
                    sSQL.AppendLine("VALUES(@employeeId, @secCode, @typeCode, @email, @lastName, @firstName, @middleName, @name, " + strPassword.sQuote() + ", @costCenterId)");
                }
                else
                {
                    sSQL.AppendLine("UPDATE SystemUser");
                    sSQL.AppendLine("   SET name = @name");
                    sSQL.AppendLine("   , secCode = " + mvCode.sQuote());
                    sSQL.AppendLine("   , email = @email");
                    sSQL.AppendLine("   , lastName = @lastName");
                    sSQL.AppendLine("   , firstName = @firstName");
                    sSQL.AppendLine("   , middleName = @middleName");
                    sSQL.AppendLine("   , costCenterId = @costCenterId");
                    sSQL.AppendLine("   , [password] = " + strPassword.sQuote());
                    sSQL.AppendLine("WHERE secCode = " + mvCode.sQuote());


                    sSQL.AppendLine("DELETE");
                    sSQL.AppendLine("FROM SystemMember");
                    sSQL.AppendLine("WHERE secCode = " + mvCode.sQuote());
                    
                    for (int i = 0; i < tvwMembersOf.Nodes[0].Nodes.Count; i++)
                    {
                        if (tvwMembersOf.Nodes[0].Nodes[i].Checked)
                        {
                            sSQL.AppendLine("INSERT INTO SystemMember(secCode, groupCode)");
                            sSQL.AppendLine("VALUES(@secCode, " + tvwMembersOf.Nodes[0].Nodes[i].Name.sQuote() + ")");
                        }
                    }
                }

                using (SQLDB sql = new SQLDB())
                {
                    sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text);
                }

                function.MsgBoxInfo(this.Text, "Save Successful.");
                txtCode.ReadOnly = true;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mvType == TYPE_GROUP)
            {
                txtName.Text = txtCode.Text;
                txtPassword.Text = txtCode.Text;
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            frmUserRights frm = new frmUserRights();
            frm.Code = mvCode;
            frm.txtName.Text = txtName.Text;
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
    }
}
