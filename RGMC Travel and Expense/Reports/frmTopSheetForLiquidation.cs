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
    public partial class frmTopSheetForLiquidation : Form
    {
        private Common common = new Common();
        private Function function = new Function();

        string FileName = "TopSheetLiquidation_" + string.Format("{0:MMddyy}", DateTime.Now);

        public frmTopSheetForLiquidation()
        {
            InitializeComponent();
        }

        private void ExecuteReport(ref LocalReport report)
        {
            DataTable dt = new DataTable();

            string sSQL = "proc_RPT09TopSheetLiquidation";

            try
            {
                Cursor = Cursors.WaitCursor;

                using (SQLDB sql = new SQLDB())
                {
                    System.Data.SqlClient.SqlParameter pBatchDate = new System.Data.SqlClient.SqlParameter("@batchDate", SqlDbType.Date);
                    pBatchDate.Value = dtpBatchDate.Value;

                    System.Data.SqlClient.SqlParameter pModeOfPayment = new System.Data.SqlClient.SqlParameter("@modeOfPaymentId", SqlDbType.Int);
                    pModeOfPayment.Value = cboModeOfPayment.SelectedValue;

                    dt = sql.GetDT(sSQL.ToString(), CommandType.StoredProcedure, pBatchDate, pModeOfPayment);
                }

                int rowCount = dt.Rows.Count;

                if (rowCount == 0)
                {
                    throw new Exception("Nothing to Print.");
                }

                int maxRowPerPage = 30;
                int rowPerPage = 24;
                int rowToAdd = 0;
                if (rowCount > maxRowPerPage)
                {
                    for (rowToAdd = rowCount; rowToAdd >= rowPerPage;)
                    {
                        rowToAdd = rowToAdd - maxRowPerPage;
                    }

                    rowToAdd = rowPerPage - rowToAdd;
                }
                else if (rowCount < rowPerPage)
                {
                    rowToAdd = rowPerPage - rowCount;
                }

                for (int i = 1; i <= rowToAdd; i++)
                {
                    dt.Rows.Add(rowCount + i, "-", DateTime.Today, DateTime.Today, "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", 0, 0, 0);
                }
                
                report.DataSources.Clear(); //clear report
                report.ReportEmbeddedResource = "MyRIS.Reports.rptTopSheetLiquidation.rdlc"; // bind reportviewer with .rdlc  
                report.DisplayName = "Top Sheet Liquidation";                              
              
                ReportDataSource ds = new ReportDataSource("TopSheetLiquidation", dt); // set the datasource
                report.DataSources.Add(ds);

                report.Refresh();

                ReportParameter p = new
                ReportParameter("PrintedBy", "Printed By: " + GlobalSettings.UserFullName + " | " + string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", DateTime.Now) + " | " + report.DisplayName);
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
                if (cboModeOfPayment.Text == "")
                {
                    cboModeOfPayment.Focus();
                    throw new Exception("Please select a mode of payment");
                }

                frmPreview frm = new frmPreview();
                LocalReport report = frm.rpvPreview.LocalReport;
                ExecuteReport(ref report);

                if (report == null)
                { return; }

                report.Refresh();
                frm.Text = this.Text;
                frm.rpvPreview.ShowExportButton = true;
                frm.ShowDialog();
            }
            catch(Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboModeOfPayment.Text == "")
                { throw new Exception("Please select a mode of payment"); }

                LocalReport report = new LocalReport();
                ExecuteReport(ref report);

                if (report == null)
                { return; }

                Byte[] bytes = report.Render("EXCEL");
                //Byte[] mybytes = report.Render("PDF"); for exporting to PDF
                FileStream fs = new FileStream(Path.GetTempPath() + @"\" + FileName + ".xls", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                System.Diagnostics.Process.Start(Path.GetTempPath() + @"\" + FileName + ".xls");
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void frmTopSheetForLiquidation_Load(object sender, EventArgs e)
        {
            common.LoadComboModeOfPayment(ref cboModeOfPayment, true);
        }
    }
}
