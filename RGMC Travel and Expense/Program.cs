using System;
using System.Windows.Forms;
using System.Diagnostics;

using MyCommon;
using MyCommon.Settings;
using MyCommon.UDL;


namespace MyRIS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {
            Function function = new Function();

            try
            {
                //if (ApplicationRunningHelper.AlreadyRunning(Process.GetCurrentProcess()))
                //{ throw new Exception("This application is already running."); }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                             
                frmLogin frm = new frmLogin();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Dispose();
                    Application.Run(new frmMain());
                }
            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(Declaration.MODULE_TITLE, ex.Message);
                GlobalSettings.CloseSystemConnection();
                Application.Exit();
            }

        }
    }
}
