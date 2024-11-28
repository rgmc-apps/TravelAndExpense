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
    public partial class frmExpenseReport : Form
    {

        private Common common = new Common();
        private Function function = new Function();

        public frmExpenseReport()
        {
            InitializeComponent();
        }

        private LocalReport ExecuteReport()
        {
            DataTable dt = new DataTable();

            string sSQL = "proc_RPT01ExpenseReport";

            try
            {
                Cursor = Cursors.WaitCursor;

                using (SQLDB sql = new SQLDB())
                {
                    System.Data.SqlClient.SqlParameter pStartDate = new System.Data.SqlClient.SqlParameter("@startDate", SqlDbType.Date);
                    pStartDate.Value = dtpStartDate.Value;

                    System.Data.SqlClient.SqlParameter pEndDate = new System.Data.SqlClient.SqlParameter("@endDate", SqlDbType.Date);
                    pEndDate.Value = dtpEndDate.Value.AddDays(1);


                    dt = sql.GetDT(sSQL.ToString(), CommandType.StoredProcedure, pStartDate, pEndDate);
                }

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Nothing to Print.");
                }

                ReportViewer rv = new ReportViewer();
                LocalReport report = rv.LocalReport;

                report.DataSources.Clear(); //clear report
                report.ReportEmbeddedResource = "MyRIS.Reports.rptExpenseReport.rdlc"; // bind reportviewer with .rdlc  
                report.DisplayName = "Employee Expense Report";

                ReportDataSource ds = new ReportDataSource("ExpenseReport", dt); // set the datasource
                report.DataSources.Add(ds);

                report.Refresh();

                ReportParameter p = new
                ReportParameter("PrintedBy", "Printed By: " + GlobalSettings.UserFullName + " | " + string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", DateTime.Now) + " | " + report.DisplayName);
                report.SetParameters(new ReportParameter[] { p });

                p = new
                ReportParameter("Period", dtpStartDate.Text + " - " + dtpEndDate.Text);
                report.SetParameters(new ReportParameter[] { p });

                return report;
            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
                return null;
            }
            finally
            {
                dt.Dispose();

                Cursor = Cursors.Default;
            }
        }

        private void frmExpenseReport_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = dtpStartDate.Value.AddMonths(-6);
        }
        
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                LocalReport report = ExecuteReport();

                if (report == null)
                { return; }

                Byte[] bytes = report.Render("EXCEL");
                //Byte[] mybytes = report.Render("PDF"); for exporting to PDF
                FileStream fs = new FileStream(Path.GetTempPath() + @"\ExpenseReport_" + DateTime.Today.ToString("MMddyy") + ".xls", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                System.Diagnostics.Process.Start(Path.GetTempPath() + @"\ExpenseReport_" + DateTime.Today.ToString("MMddyy") + ".xls");
            }
            catch
            { }
        }
    }
}
