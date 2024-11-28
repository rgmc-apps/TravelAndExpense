using System;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Settings;

namespace MyRIS
{
    public partial class frmLogin : Form
    {
        private string STR_LAST_PASS = "lastPass";

        private Function function = new Function();

        private Common common = new Common();

        public frmLogin()
        {
            InitializeComponent();
        }

        #region Procedure
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }

            string strResult = "";

            if (keyData == (Keys.Control | Keys.Shift | Keys.Alt | Keys.P))
            {
                GlobalSettings.DBServer = "localhost";
                GlobalSettings.DBDatabase = "rgmcAccountingDB";
                GlobalSettings.DBUserName = "sa";
                GlobalSettings.DBPassword = "@MyRUnway";

                GlobalSettings.OpenSystemConnection();

                strResult = Setting.InitializeSetting();
                ValidateUser();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OpenConnection()
        {
            string strResult = "";

            try
            {
                GlobalSettings.DBServer = "124.106.235.29";
                GlobalSettings.DBDatabase = "rgmcAccountingDB";
                GlobalSettings.DBUserName = "sa";
                GlobalSettings.DBPassword = "@MyRunway";

                strResult = Setting.InitializeSetting();
                
            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
            }
        }

        private void ValidateUser()
        {
            try
            {
                function.BusyShow(this);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect using a timeout (5 seconds)

                IAsyncResult result = socket.BeginConnect(GlobalSettings.DBServer, 1433, null, null);

                bool success = result.AsyncWaitHandle.WaitOne(5000, true);

                if (!success)
                {
                    socket.Close();
                    GlobalSettings.DBServer = "192.168.88.8";
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    result = socket.BeginConnect(GlobalSettings.DBServer, 1433, null, null);

                    success = result.AsyncWaitHandle.WaitOne(5000, true);
                }

                if (success)
                {
                    GlobalSettings.OpenSystemConnection();

                    if (function.ValidUser(txtUser.Text, txtPassword.Text.Encrypt(), ref GlobalSettings.UserFullName) == true)
                    {
                        if (common.CheckIfGeneralUser(txtUser.Text)) {
                            function.MsgBoxInfo("Login Failed", "Please use the RGMC Portal for filing \n\rReimbursement/Liquidation and Cash Advances.\n\r\n\r" +
                                "Please visit: http://portal.rgmcgroup.com to Login." +
                                "\n\r\n\rUsername: " + txtUser.Text + "\n\rDefault Password: 123456789" +
                                "\n\r\n\rClick OK to redirect to RGMC Portal Website.");
                            System.Diagnostics.Process.Start("http://portal.rgmcgroup.com");
                            return;
                        }
                        
                        GlobalSettings.UserName = txtUser.Text.ToLower();

                        if (function.HasAccess(Declaration.MODULE_CODE, GlobalSettings.ACCESS_READ) == true)
                        {
                            common.SetSetting(this.Text, GlobalSettings.REGISTRY_NAME_LAST_USER, GlobalSettings.UserName);

                            common.CreateLoginLog();

                            common.GetUserType();

                            //if (Declaration.USER_TYPE.Contains(Declaration.GROUP_APPROVER))
                            //{ common.SetSetting(this.Text, STR_LAST_PASS, txtPassword.Text); }

                            Setting.InitializeSetting();

                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        { throw new Exception("Sorry you have no access in this module."); }

                    }
                    else
                    {
                        function.MsgBoxInfo(this.Text, "Incorrect username or password.");

                        txtUser.Focus();
                        txtUser.SelectAll();
                    }

                    function.BusyHide(this);
                }
                else
                {
                    socket.Close();
                    throw new Exception("Failed to connect server.\n\rPlease contact a network administrator.\n\r");
                }

            }
            catch (Exception ex)
            {
                function.BusyHide(this);

                function.MsgBoxInfo(this.Text, ex.Message);
            }
        }

        #endregion

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                lblVersion.Text = "ver " + Declaration.SystemVersion;
                
                txtUser.Text = common.GetSetting(this.Text, GlobalSettings.REGISTRY_NAME_LAST_USER);
                txtPassword.Text = common.GetSetting(this.Text, STR_LAST_PASS);
                this.txtPassword.PasswordChar = '•';

                if (txtUser.Text == "")
                {
                    txtUser.ForeColor = Color.Gray;
                    txtUser.Text = "Username";
                }           
            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
                this.Dispose();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalSettings.CloseSystemConnection();

            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.ForeColor = Color.Black;
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtUser.ForeColor = Color.Black;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                ValidateUser();
            }catch{ }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.SelectAll();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }
        
    }
}
