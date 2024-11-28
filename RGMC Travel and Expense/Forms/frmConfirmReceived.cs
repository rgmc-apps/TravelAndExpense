using MyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRIS
{
    public partial class frmConfirmReceived : Form
    {
        private string mvEmail = "";

        private Function function = new Function();

        public frmConfirmReceived()
        {
            InitializeComponent();
        }
        public string LUEmail
        {
            get { return mvEmail; }
            set { mvEmail = value; }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text == "")
                {
                    throw new Exception("Please enter an email address.");
                }

                mvEmail = txtEmail.Text;

                DialogResult = DialogResult.OK;

                this.Close();

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }
    }
}
