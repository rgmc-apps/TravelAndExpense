using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;
using MyCommon.Settings;

namespace MyRIS
{
    public partial class frmCostCenterDetail : Form
    {
        private Function function = new Function();
        private Common common = new Common();

        private long mvCostCenterId = -1;
        private string mvCostCenterName = "";

        public frmCostCenterDetail()
        {
            InitializeComponent();
        }

        #region Property

        public long CostCenterId
        {
            set { mvCostCenterId = value; }
        }

        public string CostCenterName
        {
            get { return mvCostCenterName; }
        }

        #endregion


        #region Procedure

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadDetail()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            try
            {
                sSQL.AppendLine("SELECT costCenterId, costCenterCode, costCenterName,");
                sSQL.AppendLine("    remark, isActive");
                sSQL.AppendLine("FROM CostCenter");
                sSQL.AppendLine("WHERE costCenterId = " + mvCostCenterId);

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString()); }

                if (dt.Rows.Count != 0)
                {
                    mvCostCenterId = Convert.ToInt64(dt.Rows[0]["costCenterId"]);
                    txtCode.Text = dt.Rows[0]["costCenterCode"].ToString();
                    txtName.Text = dt.Rows[0]["costCenterName"].ToString();
                    txtRemark.Text = dt.Rows[0]["remark"].ToString();
                    chkActive.Checked = Convert.ToBoolean(dt.Rows[0]["isActive"]);
                }
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { dt.Dispose(); }
        }

        private void FormatObjects()
        {
            pnlRequired.BackColor = Declaration.reqBackColor;

            if (mvCostCenterId == -1)
            {
                txtCode.BackColor = Declaration.reqBackColor;
                txtName.BackColor = Declaration.reqBackColor;

                chkActive.Enabled = false;             
            }
            else
            {
                //txtCode.ReadOnly = true;

                //txtCode.TabStop = false;

                chkActive.Enabled = true;

                btnSave.Text = "&Update";
            }
        }

        private string CheckCodeName()
        {
            StringBuilder sSQL = new StringBuilder();

            sSQL.AppendLine("");

            sSQL.AppendLine("SELECT costCenterCode");
            sSQL.AppendLine("FROM CostCenter");
            sSQL.AppendLine("WHERE costCenterCode = @costCenterCode");
            sSQL.AppendLine("   AND costCenterId <> @costCenterId");

            sSQL.AppendLine("");

            sSQL.AppendLine("IF @@ROWCOUNT > 0");
            sSQL.AppendLine("    BEGIN");
            sSQL.AppendLine("        RAISERROR ('Code already exist.', 16, 1)  WITH NOWAIT");
            sSQL.AppendLine("        ROLLBACK TRANSACTION");
            sSQL.AppendLine("        RETURN");
            sSQL.AppendLine("    END");

            sSQL.AppendLine("");

            sSQL.AppendLine("SELECT costCenterName");
            sSQL.AppendLine("FROM CostCenter");
            sSQL.AppendLine("WHERE costCenterName = @costCenterName");
            sSQL.AppendLine("   AND costCenterId <> @costCenterId");

            sSQL.AppendLine("");

            sSQL.AppendLine("IF @@ROWCOUNT > 0");
            sSQL.AppendLine("    BEGIN");
            sSQL.AppendLine("        RAISERROR ('Name had been previously encoded.', 16, 1)  WITH NOWAIT");
            sSQL.AppendLine("        ROLLBACK TRANSACTION");
            sSQL.AppendLine("        RETURN");
            sSQL.AppendLine("    END");

            sSQL.AppendLine("");

            return sSQL.ToString();

        }

        private string SaveInfo()
        {
            StringBuilder sSQL = new StringBuilder();

            string strReturn = "";
            
            try
            {

                // declare variable
                // **************************
                sSQL.AppendLine("DECLARE @CostCenterId INT");

                sSQL.AppendLine("");

                sSQL.AppendLine("DECLARE @costCenterCode VARCHAR(10) = " + txtCode.Text.Trim().sQuote());
                sSQL.AppendLine("DECLARE @costCenterName VARCHAR(60) = " + txtName.Text.Trim().sQuote());
                sSQL.AppendLine("DECLARE @remark VARCHAR(250) = " + txtRemark.Text.Trim().sQuote());
                sSQL.AppendLine("DECLARE @isActive BIT = " + Convert.ToInt32(chkActive.Checked));
                sSQL.AppendLine("DECLARE @username VARCHAR(60) = " + GlobalSettings.UserName.sQuote());
                
                sSQL.AppendLine("\r");
                // **************************  


                // **************************
                // new record
                if (mvCostCenterId == -1)
                {
                    sSQL.AppendLine(function.GenerateIdScript("costCenterId"));

                    sSQL.AppendLine("");

                    sSQL.AppendLine("SELECT costCenterId");
                    sSQL.AppendLine("FROM CostCenter");
                    sSQL.AppendLine("WHERE costCenterId = @costCenterId");

                    sSQL.AppendLine("");

                    sSQL.AppendLine("IF @@ROWCOUNT > 0");
                    sSQL.AppendLine("    BEGIN");
                    sSQL.AppendLine("        RAISERROR ('Id already exist.', 16, 1)  WITH NOWAIT");
                    sSQL.AppendLine("        ROLLBACK TRANSACTION");
                    sSQL.AppendLine("        RETURN");
                    sSQL.AppendLine("    END");

                    sSQL.AppendLine("");
                    
                    sSQL.AppendLine(CheckCodeName());

                    sSQL.AppendLine("");

                    sSQL.AppendLine("INSERT INTO CostCenter(costCenterId, costCenterCode, costCenterName,");
                    sSQL.AppendLine("    remark, isActive,");
                    sSQL.AppendLine("    createBy, createDate, updateBy, updateDate)");
                    sSQL.AppendLine("VALUES(@costCenterId, @costCenterCode, @costCenterName,");
                    sSQL.AppendLine("    @remark, @isActive, @username, GETDATE(), @username, GETDATE())");

                    sSQL.AppendLine("");
                }
                // existing record
                else
                {
                    sSQL.AppendLine("SELECT @CostCenterId = " + mvCostCenterId);

                    sSQL.AppendLine("");

                    sSQL.AppendLine(CheckCodeName());

                    sSQL.AppendLine("");

                    sSQL.AppendLine("UPDATE CostCenter SET");
                    sSQL.AppendLine("    costCenterCode = @costCenterCode, ");
                    sSQL.AppendLine("    costCenterName = @costCenterName,");
                    sSQL.AppendLine("    remark = @remark,");
                    sSQL.AppendLine("    isActive = @isActive,");
                    sSQL.AppendLine("    updateBy = @username,");
                    sSQL.AppendLine("    updateDate = GETDATE()");
                    sSQL.AppendLine("WHERE costCenterId = @costCenterId");

                    sSQL.AppendLine("");
                }
                // **************************

                using (SQLDB sql = new SQLDB())
                { sql.ExecuteNonQuery(sSQL.ToString()); }

                mvCostCenterName = txtName.Text.Trim();
            }

            catch (Exception ex)
            { strReturn = ex.Message; }

            return strReturn;
        }

        private string ValidateInfo()
        {
            string strReturn = "";

            try
            {
                if (txtCode.Text.Trim() == "")
                {
                    txtCode.Focus();
                    throw new Exception("Code is required.");
                }

                if (txtName.Text.Trim() == "")
                {
                    txtName.Focus();
                    throw new Exception("Name is required.");
                }
            }
            catch (Exception ex)
            { strReturn = ex.Message; }

            return strReturn;
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtCode.SelectAll();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.SelectAll();
        }

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            txtRemark.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strResult = "";

            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_COST_CENTER, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }
                
                strResult = ValidateInfo();

                if (strResult != "")
                { throw new Exception(strResult); }

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to save the changes you've made?");

                if (strAnswer == DialogResult.No)
                { return; }

                strResult = SaveInfo();

                if (strResult != "")
                { throw new Exception(strResult); }

                function.MsgBoxInfo(this.Text, "Saving of record was successful.");

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void frmCostCenterDetail_Load(object sender, EventArgs e)
        {
            FormatObjects();

            if (mvCostCenterId != -1)
            { LoadDetail(); }
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { e.SuppressKeyPress = true; }
        }

        private void txtBusinessVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = function.IntegerOnly(e.KeyChar);
        }

        private void ValidateTextBox(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != "")
            {
                txt.BackColor = default(System.Drawing.Color);
            }
            else
            {
                { txt.BackColor = Declaration.reqBackColor; }
            }
        }
    }
}


