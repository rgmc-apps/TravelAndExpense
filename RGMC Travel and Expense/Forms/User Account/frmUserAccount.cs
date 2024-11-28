using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;

namespace MyRIS
{
    public partial class frmUserAccount : Form
    {
        private Function function = new Function();
        private Common common = new Common();

        const int IX_GRID_SEC_CODE = 0;
        const int IX_GRID_TYPE_CODE = 1;
        const int IX_GRID_NAME = 2;
        const int IX_GRID_PASSWORD = 3;
        const int IX_GRID_IS_ACTIVE = 4;

        const string TYPE_GROUP = "GROUP";
        const string TYPE_USER = "USER";

        int mvLastIndex = -1;

        public frmUserAccount()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.A))
            {
                if (tabUserAccount.SelectedTab == tabUser)
                {
                    btnAddUser.PerformClick();
                    return true;
                }
                else
                {
                    btnAddGroup.PerformClick();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        #region Procedure

        private void LoadUserAccount()
        {                      
            DataTable dtUser = new DataTable();

            DataTable[] refDT = { dtUser };

            StringBuilder sSQL = new StringBuilder();

            try
            {
                //sSQL = "proc_UserAccount";
                sSQL.AppendLine("SELECT secCode, typeCode, name, password, isActive FROM SystemUser ");

                using (SQLDB sql = new SQLDB())
                {
                    //SqlParameter pUser = new SqlParameter("@username", SqlDbType.VarChar, 20);
                    //pUser.Value = GlobalSettings.UserName;

                    sql.GetDT(ref refDT, sSQL.ToString(), CommandType.Text);
                }


                dgvGroup.Rows.Clear();
                dgvUser.Rows.Clear();

                foreach (DataRow dr in dtUser.Rows)
                {
                    if (dr[IX_GRID_TYPE_CODE].ToString() == TYPE_GROUP)
                    {
                        dgvGroup.Rows.Add("");
                        dgvGroup.Rows[dgvGroup.RowCount - 1].Cells[IX_GRID_SEC_CODE].Value = dr[IX_GRID_SEC_CODE];
                        dgvGroup.Rows[dgvGroup.RowCount - 1].Cells[IX_GRID_TYPE_CODE].Value = dr[IX_GRID_TYPE_CODE];
                        dgvGroup.Rows[dgvGroup.RowCount - 1].Cells[IX_GRID_NAME].Value = dr[IX_GRID_NAME];
                        dgvGroup.Rows[dgvGroup.RowCount - 1].Cells[IX_GRID_PASSWORD].Value = dr[IX_GRID_PASSWORD];
                        dgvGroup.Rows[dgvGroup.RowCount - 1].Cells[IX_GRID_IS_ACTIVE].Value = dr[IX_GRID_IS_ACTIVE];
                    }


                    if (dr[IX_GRID_TYPE_CODE].ToString() == TYPE_USER)
                    {
                        dgvUser.Rows.Add("");
                        dgvUser.Rows[dgvUser.RowCount - 1].Cells[IX_GRID_SEC_CODE].Value = dr[IX_GRID_SEC_CODE];
                        dgvUser.Rows[dgvUser.RowCount - 1].Cells[IX_GRID_TYPE_CODE].Value = dr[IX_GRID_TYPE_CODE];
                        dgvUser.Rows[dgvUser.RowCount - 1].Cells[IX_GRID_NAME].Value = dr[IX_GRID_NAME];
                        dgvUser.Rows[dgvUser.RowCount - 1].Cells[IX_GRID_PASSWORD].Value = dr[IX_GRID_PASSWORD];
                        dgvUser.Rows[dgvUser.RowCount - 1].Cells[IX_GRID_IS_ACTIVE].Value = dr[IX_GRID_IS_ACTIVE];
                    }
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

        private void CreateDGVGroup()
        {
            function.DataGridAddColumn(dgvGroup, IX_GRID_SEC_CODE, "secCode", "CODE", true, 150);
            function.DataGridAddColumn(dgvGroup, IX_GRID_TYPE_CODE, "typeCode", "TYPE", true, 0);
            function.DataGridAddColumn(dgvGroup, IX_GRID_NAME, "name", "NAME", true, 250);
            function.DataGridAddColumn(dgvGroup, IX_GRID_PASSWORD, "password", "PASSWORD", true, 0);
            function.DataGridAddColumn(dgvGroup, IX_GRID_IS_ACTIVE, "isActive", "IS ACTIVE?", true, 0);
        }

        private void CreateDGVUser()
        {
            function.DataGridAddColumn(dgvUser, IX_GRID_SEC_CODE, "secCode", "CODE", true, 150);
            function.DataGridAddColumn(dgvUser, IX_GRID_TYPE_CODE, "typeCode", "TYPE", true, 0);
            function.DataGridAddColumn(dgvUser, IX_GRID_NAME, "name", "NAME", true, 250);
            function.DataGridAddColumn(dgvUser, IX_GRID_PASSWORD, "password", "PASSWORD", true, 0);
            function.DataGridAddColumn(dgvUser, IX_GRID_IS_ACTIVE, "isActive", "IS ACTIVE?", true, 0);        
        }
        
        #endregion

        private void frmUserAccount_Load(object sender, EventArgs e)
        {
            CreateDGVGroup();
            CreateDGVUser();

            LoadUserAccount();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            frmAddGroup frm = new frmAddGroup();
            frm.Type = TYPE_GROUP;

            frm.ShowDialog();

            LoadUserAccount();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            frm.Type = TYPE_USER;
            frm.ShowDialog();

            LoadUserAccount();
        }
        
        private void dgvUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvUser_DoubleClick(null, null);
            }
        }

        private void dgvUser_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUser.SelectedCells.Count > 0)
            {
                frmAddUser frm = new frmAddUser();
                frm.Type = TYPE_USER;
                frm.Code = dgvUser.Rows[dgvUser.SelectedCells[0].RowIndex].Cells[IX_GRID_SEC_CODE].Value.ToString();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                { LoadUserAccount(); }

                frm.Dispose();
            }
        }

        private void dgvGroup_DoubleClick(object sender, EventArgs e)
        {
            if (dgvGroup.SelectedCells.Count > 0)
            {
                frmAddGroup frm = new frmAddGroup();
                frm.Type = TYPE_GROUP;
                frm.Code = dgvGroup.Rows[dgvGroup.SelectedCells[0].RowIndex].Cells[IX_GRID_SEC_CODE].Value.ToString();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                { LoadUserAccount(); }
            }
        }

        private void dgvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvGroup_DoubleClick(null, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvUser.Focus();

                String searchValue = txtUser.Text;

                if (mvLastIndex == -1)
                { mvLastIndex = 0; }
                else
                { mvLastIndex += 1; }

                for (int i = mvLastIndex; i < dgvUser.Rows.Count; i++)
                {
                    if (dgvUser[2, i].Value.ToString().Contains(searchValue))
                    {
                        mvLastIndex = i;
                        break;
                    }
                    else if (i == (dgvUser.Rows.Count - 1))
                    {
                        mvLastIndex = 0;
                        break;
                    }
                }

                if (mvLastIndex != -1)
                {
                    dgvUser[2, mvLastIndex].Selected = true;
                }
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnSearch.PerformClick(); }
        }
    }
}
