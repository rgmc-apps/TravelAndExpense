using System;
using System.Text;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Data;
using MyCommon.Settings;

namespace MyRIS
{
    public partial class frmChangePassword : Form
    {
        private Function function = new Function();

        const int PASSWORD_LENGTH = 8;
        
        public frmChangePassword()
        {
            InitializeComponent();
        }        

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

        private string SaveInfo()
        {
            StringBuilder sSQL = new StringBuilder();

            string strReturn = "";
            
            string strUserName = GlobalSettings.UserName;
            string strPassword = txtNewPassword.Text.Trim().Encrypt();

            try
            {
                sSQL.AppendLine("UPDATE SystemUser SET");
                sSQL.AppendLine("    [password] = " + strPassword.sQuote());
                sSQL.AppendLine("WHERE secCode = " + strUserName.sQuote());

                sSQL.AppendLine("");               

                using (SQLDB sql = new SQLDB())
                { sql.ExecuteNonQuery(sSQL.ToString()); }
                
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
                if (function.ValidUser(GlobalSettings.UserName, txtCurrentPassword.Text.Encrypt(), ref GlobalSettings.UserFullName) == false)
                {
                    txtCurrentPassword.Focus();
                    throw new Exception("Incorrect password.");
                }                

                if (txtNewPassword.Text.Trim() == "")
                {
                    txtNewPassword.Focus();
                    throw new Exception("New password is required."); 
                }

                if (txtNewPassword.Text.Trim().Length < PASSWORD_LENGTH )
                {
                    txtNewPassword.Focus();
                    throw new Exception("New password should be atleast " + PASSWORD_LENGTH + " characters."); 
                }

                if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    txtNewPassword.Focus();
                    throw new Exception("The passwords you entered did not match."); 
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strResult = "";

            try
            {
                strResult = ValidateInfo();

                if (strResult != "")
                { throw new Exception(strResult); }

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to save your new password?");

                if (strAnswer == DialogResult.No)
                { return; }

                strResult = SaveInfo();

                if (strResult != "")
                { throw new Exception(strResult); }

                function.MsgBoxInfo(this.Text, "Saving of new password was successful.");                

                this.Close();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "UID: " + GlobalSettings.UserName;
        }

        private void txtCurrentPassword_Enter(object sender, EventArgs e)
        {
            txtCurrentPassword.SelectAll();
        }

        private void txtNewPassword_Enter(object sender, EventArgs e)
        {
            txtNewPassword.SelectAll();
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            txtConfirmPassword.SelectAll();
        }               
    }
}
