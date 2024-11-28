using Microsoft.Reporting.WinForms;
using MyCommon;
using MyCommon.Data;
using MyCommon.Settings;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace MyRIS
{
    public partial class frmEPVMonitoring : Form
    {

        private Common common = new Common();
        private Function function = new Function();

        public frmEPVMonitoring()
        {
            InitializeComponent();
        }
        
        private void ExecuteReport(ref LocalReport report)
        {
            DataTable dt = new DataTable();

            string sSQL = "proc_RPT06EPVMonitoring";

            try
            {
                Cursor = Cursors.WaitCursor;

                using (SQLDB sql = new SQLDB())
                {
                    System.Data.SqlClient.SqlParameter pStartDate = new System.Data.SqlClient.SqlParameter("@startDate", SqlDbType.Date);
                    pStartDate.Value = dtpStartDate.Value;

                    System.Data.SqlClient.SqlParameter pEndDate = new System.Data.SqlClient.SqlParameter("@endDate", SqlDbType.Date);
                    pEndDate.Value = dtpEndDate.Value.AddDays(1);
                    
                    System.Data.SqlClient.SqlParameter pMode = new System.Data.SqlClient.SqlParameter("@mode", SqlDbType.Int);
                    pMode.Value = radReleasedDate.Checked ? radReleasedDate.Tag : radBatchDate.Tag;

                    dt = sql.GetDT(sSQL.ToString(), CommandType.StoredProcedure, pStartDate, pEndDate, pMode);
                }

                if (dt.Rows.Count == 0)
                {
                    report = null;
                    throw new Exception("Nothing to Print.");
                }
                
                report.DataSources.Clear(); //clear report
                report.ReportEmbeddedResource = "MyRIS.Reports.rptEPVMonitoring.rdlc"; // bind reportviewer with .rdlc  
                report.DisplayName = "EPV Monitoring";

                ReportDataSource ds = new ReportDataSource("EPVMonitoring", dt); // set the datasource
                report.DataSources.Add(ds);

                report.Refresh();

                ReportParameter p = new
                ReportParameter("PrintedBy", "Printed By: " + GlobalSettings.UserFullName + " | " + string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", DateTime.Now) + " | " + report.DisplayName);
                report.SetParameters(new ReportParameter[] { p });

                p = new
                ReportParameter("Period", dtpStartDate.Text + " - " + dtpEndDate.Text);
                report.SetParameters(new ReportParameter[] { p });
            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
            }
            finally
            {
                dt.Dispose();
                Cursor = Cursors.Default;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            { 
                frmPreview frm = new frmPreview();
                LocalReport report = frm.rpvPreview.LocalReport;
                ExecuteReport(ref report);

                if (report == null)
                { return; }

                report.Refresh();
                frm.Text = this.Text;
                frm.ShowDialog();
            }
            catch
            { }
        }

        private void frmEPVMonitoring_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = dtpStartDate.Value.AddMonths(-6);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            LocalReport report = new LocalReport();
            ExecuteReport(ref report);

            if (report == null)
            { return; }

            Byte[] bytes = report.Render("EXCEL");
            FileStream fs = new FileStream(Path.GetTempPath() + @"\EPVMonitoring_" + DateTime.Today.ToString("MMddyy") + ".xls", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            System.Diagnostics.Process.Start(Path.GetTempPath() + @"\EPVMonitoring_" + DateTime.Today.ToString("MMddyy") + ".xls");
        }
    }
}
