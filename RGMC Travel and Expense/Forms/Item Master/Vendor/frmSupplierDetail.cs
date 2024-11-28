using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;
using MyCommon.Settings;

namespace MyRIS
{
    public partial class frmSupplierDetail : Form
    {
        private Function function = new Function();
        private Common common = new Common();

        private DialogResult dr = new DialogResult();

        private long mvSupplierId = -1;
        private string mvSupplierName = "";        

        public frmSupplierDetail()
        {
            InitializeComponent();
        }

        #region Property

        public long SupplierId
        {
            set { mvSupplierId = value; }
        }

        public string SupplierName
        {
            get { return mvSupplierName; }
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
                sSQL.AppendLine("SELECT vendorId, tin, vendorName, address, remark, isActive");
                sSQL.AppendLine("FROM Vendor");
                sSQL.AppendLine("WHERE vendorId = " + mvSupplierId);

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString()); }

                if (dt.Rows.Count != 0)
                {
                    mvSupplierId = Convert.ToInt64(dt.Rows[0]["vendorId"]);
                    txtTIN.Text = dt.Rows[0]["tin"].ToString();
                    txtName.Text = dt.Rows[0]["vendorName"].ToString();
                    txtAddress.Text = dt.Rows[0]["address"].ToString();                  
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

            if (mvSupplierId == -1)
            {
                txtTIN.BackColor = Declaration.reqBackColor;
                txtName.BackColor = Declaration.reqBackColor;
                
                chkActive.Enabled = false; 
            }
            else
            {
                //    txtTIN.BackColor = DefaultBackColor;
                //    txtName.BackColor = DefaultBackColor;

                //txtTIN.ReadOnly = true;
                //txtName.ReadOnly = true;

                chkActive.Enabled = true;

                btnSave.Text = "&Update";
            }
        }

        private string SaveInfo()
        {
            StringBuilder sSQL = new StringBuilder();

            string strReturn = "";
            
            string strCode = txtTIN.Text.Trim();
            string strName = txtName.Text.Trim();        
            string strAddress = txtAddress.Text.Trim();
            string strRemark = txtRemark.Text.Trim();
            int intIsActive = Convert.ToInt32(chkActive.Checked);
            
            string strUserName = GlobalSettings.UserName;            

            try
            {
                // declare variable
                // **************************
                System.Data.SqlClient.SqlParameter pSupplierId = new System.Data.SqlClient.SqlParameter("@vendorId", SqlDbType.Int);
                pSupplierId.Direction = ParameterDirection.Output;


                sSQL.AppendLine("");

                sSQL.AppendLine("DECLARE @errorMessage VARCHAR(250)");

                sSQL.AppendLine("\r");
                // **************************  
                
                // **************************
                // new record
                if (mvSupplierId == -1)
                {
                    sSQL.AppendLine(function.GenerateIdScript("vendorId"));

                    sSQL.AppendLine("");

                    sSQL.AppendLine("SELECT vendorId");
                    sSQL.AppendLine("FROM Vendor");
                    sSQL.AppendLine("WHERE vendorId = @vendorId");

                    sSQL.AppendLine("");

                    sSQL.AppendLine("IF @@ROWCOUNT > 0");
                    sSQL.AppendLine("    BEGIN");
                    sSQL.AppendLine("        SELECT @errorMessage = 'Vendor id already exist.'");
                    sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                    sSQL.AppendLine("        ROLLBACK TRANSACTION");
                    sSQL.AppendLine("        RETURN");
                    sSQL.AppendLine("    END");

                    sSQL.AppendLine("");

                    sSQL.AppendLine("SELECT tin");
                    sSQL.AppendLine("FROM Vendor");
                    sSQL.AppendLine("WHERE tin = " + strCode.sQuote());

                    sSQL.AppendLine("");

                    sSQL.AppendLine("IF @@ROWCOUNT > 0");
                    sSQL.AppendLine("    BEGIN");
                    sSQL.AppendLine("        SELECT @errorMessage = 'TIN already exist.'");
                    sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                    sSQL.AppendLine("        ROLLBACK TRANSACTION");
                    sSQL.AppendLine("        RETURN");
                    sSQL.AppendLine("    END");

                    sSQL.AppendLine("INSERT INTO Vendor(vendorId, tin, vendorName, address, remark, isActive,");
                    sSQL.AppendLine("    createBy, createDate, updateBy, updateDate)");
                    sSQL.AppendLine("VALUES(@vendorId, " + strCode.sQuote() + ", " + strName.sQuote() + ",");
                    sSQL.AppendLine("    " + strAddress.sQuote() + ", " + strRemark.sQuote() + ", " + intIsActive 
                        + "," + strUserName.sQuote() + ", GETDATE(), " + strUserName.sQuote() + ", GETDATE())");
                    sSQL.AppendLine("");
                }
                // existing record
                else if (mvSupplierId != -1)
                {
                    sSQL.AppendLine("SELECT @vendorId = " + mvSupplierId);

                    sSQL.AppendLine("");

                    sSQL.AppendLine("SELECT tin");
                    sSQL.AppendLine("FROM Vendor");
                    sSQL.AppendLine("WHERE vendorId <> @vendorId ");
                    sSQL.AppendLine("   AND tin = " + strCode.sQuote());

                    sSQL.AppendLine("");

                    sSQL.AppendLine("IF @@ROWCOUNT > 0");
                    sSQL.AppendLine("    BEGIN");
                    sSQL.AppendLine("        SELECT @errorMessage = 'TIN already exist.'");
                    sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                    sSQL.AppendLine("        ROLLBACK TRANSACTION");
                    sSQL.AppendLine("        RETURN");
                    sSQL.AppendLine("    END");

                    sSQL.AppendLine("");

                    sSQL.AppendLine("UPDATE Vendor SET");
                    sSQL.AppendLine("    tin = " + strCode.sQuote() + ",");
                    sSQL.AppendLine("    vendorName = " + strName.sQuote() + ",");
                    sSQL.AppendLine("    address = " + strAddress.sQuote() + ",");
                    sSQL.AppendLine("    remark = " + strRemark.sQuote() + ",");
                    sSQL.AppendLine("    isActive = " + intIsActive + ",");
                    sSQL.AppendLine("    updateBy = " + strUserName.sQuote() + ",");
                    sSQL.AppendLine("    updateDate = GETDATE()");
                    sSQL.AppendLine("WHERE vendorId = @vendorId");

                    sSQL.AppendLine("");
                }

                using (SQLDB sql = new SQLDB())
                { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pSupplierId); }

                mvSupplierId = Convert.ToInt64(pSupplierId.Value.ToString());
                mvSupplierName = txtName.Text.Trim();
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
                if (txtTIN.Text.Trim() == "")
                {
                    txtTIN.Focus();
                    throw new Exception("TIN is required."); 
                }

                if (txtName.Text.Trim() == "")
                {
                    txtName.Focus();
                    throw new Exception("Name is required."); 
                }

                if (txtAddress.Text.Trim() == "")
                {
                    txtAddress.Focus();
                    throw new Exception("Address is required.");
                }

                // ******************************

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
            txtTIN.SelectAll();
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
                if (function.HasAccess(Declaration.MOD_CODE_SUPPLIER, GlobalSettings.ACCESS_WRITE) == false)
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
                
                dr = DialogResult.OK;

                FormatObjects();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }
              

        private void frmSupplierDetail_Load(object sender, EventArgs e)
        {
            FormatObjects();

            if (mvSupplierId != -1)
            { LoadDetail(); }
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { e.SuppressKeyPress = true; }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            txtAddress.SelectAll();
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { e.SuppressKeyPress = true; }
        }        
        
        private void txtLoadCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { e.Handled = true; }
        }
        
        private void frmSupplierDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dr == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
