using Microsoft.Reporting.WinForms;
using MyCommon;
using MyCommon.Data;
using MyCommon.Settings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace MyRIS
{
    public partial class frmSummaryOfLiquidations : Form
    {

        private Common common = new Common();
        private Function function = new Function();

        public frmSummaryOfLiquidations()
        {
            InitializeComponent();
        }

        #region Procedure


        private void ExecuteReport(ref LocalReport report)
        { 
            DataTable dt = new DataTable();

            string sSQL = "proc_RPT03SummaryOfLiquidations";

            try
            {
                Cursor = Cursors.WaitCursor;

                using (SQLDB sql = new SQLDB())
                {
                    //SqlParameter pBrandId = new SqlParameter("@brandId", SqlDbType.Int);
                    //pBrandId.Value = cboBrand.SelectedValue;

                    System.Data.SqlClient.SqlParameter pBatchDate = new System.Data.SqlClient.SqlParameter("@batchDate", SqlDbType.Date);
                    pBatchDate.Value = dtpStartDate.Value;


                    dt = sql.GetDT(sSQL.ToString(), CommandType.StoredProcedure, pBatchDate);
                }

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Nothing to Print.");
                }
                
                report.DataSources.Clear(); //clear report
                report.ReportEmbeddedResource = "MyRIS.Reports.rptSummaryOfLiquidations.rdlc"; // bind reportviewer with .rdlc  
                report.DisplayName = "Liquidation Summary";

                ReportDataSource ds = new ReportDataSource("SummaryOfLiquidations", dt); // set the datasource
                report.DataSources.Add(ds);

                report.Refresh();

                ReportParameter p = new
                ReportParameter("PrintedBy", "Printed By: " + GlobalSettings.UserFullName + " | " + string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", DateTime.Now) + " | " + report.DisplayName);
                report.SetParameters(new ReportParameter[] { p });

                p = new
                ReportParameter("BatchDate", dtpStartDate.Text);
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


        #endregion

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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                LocalReport report = new LocalReport();
                ExecuteReport(ref report);

                if (report == null)
                { return; }

                Byte[] bytes = report.Render("EXCEL");
                //Byte[] mybytes = report.Render("PDF"); for exporting to PDF
                FileStream fs = new FileStream(Path.GetTempPath() + @"\SummaryofLiquidations_" + DateTime.Today.ToString("MMddyy") + ".xls", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                System.Diagnostics.Process.Start(Path.GetTempPath() + @"\SummaryofLiquidations_" + DateTime.Today.ToString("MMddyy") + ".xls");
            }
            catch
            { }
        }
    }
}
