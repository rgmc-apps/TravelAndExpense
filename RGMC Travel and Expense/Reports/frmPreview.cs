using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace MyRIS
{
    public partial class frmPreview : Form
    {
        public frmPreview()
        {
            InitializeComponent();
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            this.rpvPreview.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvPreview.RefreshReport();
            this.rpvPreview.RefreshReport();
            this.rpvPreview.ShowExportButton = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            rpvPreview.PrintDialog();
        }
    }
}
