using System;
using System.Text;
using System.Windows.Forms;
using System.Data;

using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using MyCommon;
using MyCommon.Data;
using MyCommon.Settings;
using System.Net;

public class Common
{
    private Function function = new Function();

    private string applicationName = Declaration.MODULE_CODE;
    private string companyCode = Declaration.COMPANY_CODE;
    private const string SOFTWARE = "SOFTWARE";
    Microsoft.Win32.RegistryKey regkey;

    public string SaveActiviyLog(string module, string action, string detail)
    {
        StringBuilder sSQL = new StringBuilder();

        sSQL.AppendLine("DECLARE @detail VARCHAR(50) = " + detail);
        sSQL.AppendLine("DECLARE @module VARCHAR(50) = " + module.sQuote());
        sSQL.AppendLine("DECLARE @action VARCHAR(50) = " + action.sQuote());
        sSQL.AppendLine("DECLARE @pcUser VARCHAR(50) = " + System.Environment.UserName.sQuote());
        sSQL.AppendLine("DECLARE @pcName VARCHAR(50) = " + System.Environment.MachineName.sQuote());
        sSQL.AppendLine("DECLARE @secCode VARCHAR(50) = " + GlobalSettings.UserFullName.sQuote());

        sSQL.AppendLine("INSERT INTO UserActivityLog(detail, module, action, pcUser, pcName, secCode)");
        sSQL.AppendLine("   VALUES(@detail, @module, @action, @pcUser, @pcName, @secCode)");
        
        return sSQL.ToString();
    }

    public bool CheckIfGeneralUser(string userCode)
    {
        DataTable dt = new DataTable();
        StringBuilder sSQL = new StringBuilder();
        bool result = false;
        try
        {
            sSQL.AppendLine("SELECT groupCode");
            sSQL.AppendLine("FROM SystemMember");
            sSQL.AppendLine("WHERE secCode = " + userCode.sQuote());

            using (SQLDB sQLDB = new SQLDB())
            {
                dt = sQLDB.GetDT(sSQL.ToString());
            }

            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["groupCode"].ToString() == "GU")
                {
                    result = true;
                }
            }
        }
        catch
        {
            result = false;
        }

        return result;
    }


    public string GetEmail(int employeeId)
    {
        SqlParameter pEmail = new SqlParameter("@email", SqlDbType.VarChar, 50);
        pEmail.Direction = ParameterDirection.Output;

        StringBuilder sSQL = new StringBuilder();

        try
        {            
            sSQL.AppendLine("SELECT @email = email");
            sSQL.AppendLine("FROM SystemUser");
            sSQL.AppendLine("WHERE employeeId = " + employeeId);
         
            using (SQLDB sql = new SQLDB())
            { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pEmail); }

            if (pEmail.Value != null)
            { return Convert.ToString(pEmail.Value); }
            else
            { return ""; }
        }
        catch
        { return ""; }
    }

    public void SendEmail(string subject, string body, string email)
    {
        try
        {
            string senderServer = "smtpout.secureserver.net";
            int senderPort = 587;
            string senderEmail = "travelandexpense@rgmcgroup.com";
            string senderPassword = "P@ssw0rd";

            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient(senderServer);

            //string semail = "rgmctesnotify@gmail.com";
            //string password = "NWwe@re1t";

            mail.From = new MailAddress(senderEmail, "RGMC Travel and Expense Notification");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtp.EnableSsl = true;
            smtp.Port = senderPort;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential(senderEmail, senderPassword);
            smtp.Credentials = nc;
            smtp.Send(mail);             

            function.MsgBoxInfo("Email Send", "Email Send Successfully");
        }
        catch (Exception ex)
        {
            function.MsgBoxInfo("Sending Email Failed: ", ex.Message);
        }
    }

    public int GetReferenceID(string refNumber, bool isEPV)
    {
        SqlParameter pId = new SqlParameter("@referenceId", SqlDbType.Int);
        pId.Direction = ParameterDirection.Output;

        StringBuilder sSQL = new StringBuilder();

        try
        {
            if (isEPV)
            {
                sSQL.AppendLine("SELECT @referenceId = epvId");
                sSQL.AppendLine("FROM EPV");
                sSQL.AppendLine("WHERE formNumber = " + refNumber.sQuote());

            }
            else
            {
                sSQL.AppendLine("SELECT @referenceId = caId");
                sSQL.AppendLine("FROM CashAdvance");
                sSQL.AppendLine("WHERE caNumber = " + refNumber.sQuote());
            }
            using (SQLDB sql = new SQLDB())
            { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pId); }

            if (pId.Value != null)
            { return Convert.ToInt32(pId.Value); }
            else
            { return -1; }
        }
        catch
        { return -1; }
    }


    public int GetDepartmentId()
    {
        SqlParameter pId = new SqlParameter("@costCenterId", SqlDbType.Int);
        pId.Direction = ParameterDirection.Output;

        StringBuilder sSQL = new StringBuilder();

        try
        {
            sSQL.AppendLine("SELECT @costCenterId = costCenterId");
            sSQL.AppendLine("FROM SystemUser");
            sSQL.AppendLine("WHERE employeeId = " + GetEmployeeId());

            using (SQLDB sql = new SQLDB())
            { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pId); }

            if (pId.Value != null)
            { return Convert.ToInt32(pId.Value); }
            else
            { return -1; }
        }
        catch
        { return -1; }
    }

    public bool ModeOfPaymentUploading(int modeOfPaymentId)
    { 
        StringBuilder sSQL = new StringBuilder();

        try
        {
            SqlParameter pIsUploaded = new SqlParameter("@isUploaded", SqlDbType.Bit);
            pIsUploaded.Direction = ParameterDirection.Output;

            sSQL.AppendLine("SELECT @isUploaded = isUploaded FROM ModeOfPayment WHERE modeOfPaymentId = " + modeOfPaymentId);             
             
            using (SQLDB sql = new SQLDB())
            { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pIsUploaded); }

            return Convert.ToBoolean(pIsUploaded.Value);
        }

        catch
        { return false; }
    }


    public void LoadComboModeOfPayment(ref ComboBox cbo, bool isCA = false)
    {
        DataTable dt = new DataTable();
        StringBuilder sSQL = new StringBuilder();

        try
        {
            dt.Columns.Add("modeOfPaymentId");
            dt.Columns.Add("modeOfPaymentCode");

            sSQL.AppendLine("SELECT [modeOfPaymentId], [modeOfPaymentCode] FROM ModeOfPayment");

            if (isCA)
            {
                sSQL.AppendLine("WHERE modeOfPaymentId <> 4");
                sSQL.AppendLine("AND modeOfPaymentId <> 5");
                sSQL.AppendLine("AND isActive = 1");
            }
            else
            {
                sSQL.AppendLine("WHERE isActive = 1");
            }

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            dt.DefaultView.Sort = "modeOfPaymentCode";
            dt = dt.DefaultView.ToTable();

            cbo.DataSource = dt;
            cbo.DisplayMember = "modeOfPaymentCode";
            cbo.ValueMember = "modeOfPaymentId";

            cbo.SelectedIndex = -1;
        }

        catch (Exception ex)
        { function.MsgBoxInfo("Mode of Settlement", ex.Message); }
    }

    public void LoadComboStore(ref ComboBox cbo, ref DataTable dt, bool withALL = false)
    {
        StringBuilder sSQL = new StringBuilder();

        try
        {
            if (withALL)
            {
                sSQL.AppendLine("SELECT -1 AS storeId, 'ALL' AS storeName");
                sSQL.AppendLine("UNION ALL");
            }
            sSQL.AppendLine("SELECT storeId, storeName");
            sSQL.AppendLine("FROM Stores");
            sSQL.AppendLine("WHERE isActive = 1");

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            dt.DefaultView.Sort = "storeName";
            dt = dt.DefaultView.ToTable();

            cbo.DataSource = dt;
            cbo.DisplayMember = "storeName";
            cbo.ValueMember = "storeId";

        }
        catch (Exception ex)
        { function.MsgBoxInfo("Store", ex.Message); }
    }

    public void LoadComboBusinessPurpose(ref ComboBox cbo)
    {
        try
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            sSQL.AppendLine("SELECT [businessPurposeId], [businessPurposeName] FROM BusinessPurpose");
            sSQL.AppendLine("WHERE isActive = 1");

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            dt.DefaultView.Sort = "businessPurposeName";
            dt = dt.DefaultView.ToTable();

            cbo.DataSource = dt;
            cbo.DisplayMember = "businessPurposeName";
            cbo.ValueMember = "businessPurposeId";
        }
        catch 
        {  }
    }
    
    public void ExportDataTableCSV(DataTable dt)
    {
        //datatable does not contain definition for ExportTo
        try
        {
            if (dt == null || dt.Columns.Count == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\EXCEL FILES";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\EXCEL FILES\\" + dt.TableName + DateTime.Today.ToString("yyyyMMdd") + ".csv";
            var lines = new List<string>();

            string[] columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();

            var header = string.Join(",", columnNames);
            lines.Add(header);

            var valueLines = dt.AsEnumerable()
                               .Select(row => string.Join(",", (string[])row.ItemArray.Select(s => s.ToString().IndexOf(',') < 0 ? s : String.Format("\"{0}\"", s))));
            lines.AddRange(valueLines);

            File.WriteAllLines(filepath, lines);

            System.Diagnostics.Process.Start(filepath); 
            System.Diagnostics.Process.Start(path);

        }
        catch (Exception ex)
        {
            throw new Exception("ExportToExcel: \n" + ex.Message);
        }
    }

    public int GetStatusCount(int modeId, int statusId)
    {
        DataTable dt = new DataTable();
        string sSQL = "proc_StatusCount";

        try
        {
            SqlParameter pId = new SqlParameter("@employeeId", SqlDbType.Int);
            pId.Value = GetEmployeeId();

            SqlParameter pModeId = new SqlParameter("@modeId", SqlDbType.Int);
            pModeId.Value = modeId;

            SqlParameter pStatusId = new SqlParameter("@statusId", SqlDbType.Int);
            pStatusId.Value = statusId;

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString(), CommandType.StoredProcedure, pId, pModeId, pStatusId); }
            
            return Convert.ToInt32(dt.Rows[0]["statusCount"]);
        }
        catch
        {
            return 0;
        }                 
    }

    public string CheckActualDate(string actualDate)
    {
        StringBuilder sSQL = new StringBuilder();

        sSQL.AppendLine("");

        sSQL.AppendLine("DECLARE @elapseDays INT = 0 ");
        sSQL.AppendLine("DECLARE @lastDate DATE  ");
        sSQL.AppendLine("DECLARE @lastActivity VARCHAR(50)");
        sSQL.AppendLine("");
        sSQL.AppendLine("SELECT  TOP 1 @lastDate = actualDate, @lastActivity = designStatusName FROM ProductDesignActionHistory WHERE productDesignId = @productDesignId ORDER BY actualDate DESC ");
        sSQL.AppendLine("");
        sSQL.AppendLine("SELECT @elapseDays = DATEDIFF(d, @lastDate, " + actualDate.sQuote() + ") ");
        sSQL.AppendLine("");
        sSQL.AppendLine("IF @elapseDays < 0  ");
        sSQL.AppendLine("BEGIN  ");
        sSQL.AppendLine("        SELECT @errorMessage = 'Invalid Date. Last Activity (DATE|ACTION) ' + CHAR(10) + CHAR(13) + CAST(@lastDate AS VARCHAR(50)) + '|' + @lastActivity");
        sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
        sSQL.AppendLine("        ROLLBACK TRANSACTION");
        sSQL.AppendLine("        RETURN");
        sSQL.AppendLine("END ");

        sSQL.AppendLine("");

        return sSQL.ToString();

    }
    public void LoadComboChargeTo(ref ComboBox cbo)
    {
        DataTable dt = new DataTable();
        StringBuilder sSQL = new StringBuilder();

        try
        {
            dt.Columns.Add("chargeToId");
            dt.Columns.Add("chargeToName");

            sSQL.AppendLine("SELECT -1 AS chargeToId, 'ALL' AS chargeToName");
            sSQL.AppendLine("UNION ALL");
            sSQL.AppendLine("SELECT chargeToId, chargeToName AS name ");
            sSQL.AppendLine("FROM ChargeTo");
            //sSQL.AppendLine("WHERE isActive = 1");

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            dt.DefaultView.Sort = "chargeToName";
            dt = dt.DefaultView.ToTable();

            cbo.DataSource = dt;
            cbo.DisplayMember = "chargeToName";
            cbo.ValueMember = "chargeToId";

            cbo.SelectedValue = -1;
        }

        catch
        { }
    }

    public void LoadComboPeriod(ref ComboBox cbo, string year = "ALL")
    {
        DataTable dt = new DataTable();
        StringBuilder sSQL = new StringBuilder();

        try
        {
            dt.Columns.Add("periodId");
            dt.Columns.Add("periodName");

            sSQL.AppendLine("SELECT -1 AS periodId, '' AS periodCode, 'ALL' AS periodName");
            sSQL.AppendLine("UNION ALL");
            sSQL.AppendLine("SELECT periodId, periodCode, ");
            sSQL.AppendLine("    name AS periodName");
            sSQL.AppendLine("FROM Period");
            sSQL.AppendLine("WHERE isActive = 1");

            if (year != "ALL")
            {
                sSQL.AppendLine("   AND [year] = " + year);
            }

            sSQL.AppendLine("ORDER BY periodCode");

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            //dt.DefaultView.Sort = "seasonName";
            //dt = dt.DefaultView.ToTable();

            cbo.DataSource = dt;
            cbo.DisplayMember = "periodName";
            cbo.ValueMember = "periodCode";
        }
        catch
        { }
    }

    public void LoadComboYear(ref ComboBox cbo)
    {
        DataTable dt = new DataTable();
        StringBuilder sSQL = new StringBuilder();

        try
        {
            dt.Columns.Add("yearId");
            dt.Columns.Add("yearName");

            sSQL.AppendLine("SELECT -1 AS yearId, 'ALL' AS yearName");
            sSQL.AppendLine("UNION ALL");
            sSQL.AppendLine("SELECT [year] yearId, CAST([year] AS VARCHAR(10)) AS yearName ");
            sSQL.AppendLine("FROM Period");
            sSQL.AppendLine("WHERE [year] >= DATEPART(YEAR, GETDATE())");
            sSQL.AppendLine("	AND [year] <= DATEPART(YEAR, DATEADD(YEAR, 2, GETDATE()))");
            sSQL.AppendLine("GROUP BY [year]");

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            //dt.DefaultView.Sort = "seasonName";
            //dt = dt.DefaultView.ToTable();

            cbo.DataSource = dt;
            cbo.DisplayMember = "yearName";
            cbo.ValueMember = "yearId";
        }
        catch
        { }
    }

    public void LoadComboTransactionType(ref ComboBox cbo)
    {
        DataTable dt = new DataTable();
        StringBuilder sSQL = new StringBuilder();

        try
        {
            dt.Columns.Add("transactionTypeId");
            dt.Columns.Add("transactionTypeName");

            sSQL.AppendLine("SELECT -1 AS transactionTypeId, 'ALL' AS transactionTypeName");
            sSQL.AppendLine("UNION ALL");
            sSQL.AppendLine("SELECT transactionTypeId, transactionTypeName AS name");
            sSQL.AppendLine("FROM TransactionType");

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            dt.DefaultView.Sort = "transactionTypeId";
            dt = dt.DefaultView.ToTable();

            cbo.DataSource = dt;
            cbo.DisplayMember = "transactionTypeName";
            cbo.ValueMember = "transactionTypeId";

        }
        catch
        { }
    }

    public void LoadEmployeeName(ref ComboBox cbo)
    {
        DataTable dt = new DataTable();

        try
        {
            StringBuilder sSQL = new StringBuilder();

            dt.Columns.Add("employeeId");
            dt.Columns.Add("employeeName");

            sSQL.AppendLine("DECLARE @employeeId INT");

            sSQL.AppendLine(" ");
            sSQL.AppendLine("SELECT @employeeId = employeeId ");
            sSQL.AppendLine("FROM SystemUser ");
            sSQL.AppendLine("WHERE secCode = " + GlobalSettings.UserName.sQuote());
            sSQL.AppendLine(" ");

            sSQL.AppendLine("SELECT -1 AS employeeId, 'ALL' AS employeName");

            sSQL.AppendLine("UNION ALL");

            sSQL.AppendLine("SELECT SystemUser.employeeId, ");
            sSQL.AppendLine("   CASE WHEN middleName <> '' THEN CONCAT(lastName, ', ', firstName, ' ', LEFT(middleName, 1), '.')  ");
            sSQL.AppendLine("	   ELSE CONCAT(lastName, ', ', firstName) END AS employeeName ");
            sSQL.AppendLine("FROM SystemUser ");
            sSQL.AppendLine("   LEFT JOIN EPV ON SystemUser.employeeId = EPV.employeeId");
            sSQL.AppendLine("WHERE SystemUser.employeeId = @employeeId");
            //sSQL.AppendLine("	OR headDesignerId = @designerId");

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            dt.DefaultView.Sort = "employeeName";
            dt = dt.DefaultView.ToTable();

            cbo.DataSource = dt;
            cbo.DisplayMember = "employeeName";
            cbo.ValueMember = "employeeId";
        }
        catch
        { }
    }

    public void LoadComboDepartment(ref ComboBox cbo, bool withAll = false)
    {
        DataTable dt = new DataTable();
        StringBuilder sSQL = new StringBuilder();

        try
        {
            dt.Columns.Add("costCenterId");
            dt.Columns.Add("costCenterName");

            if (withAll)
            {
                sSQL.AppendLine("SELECT -1 AS costCenterId, 'ALL' AS costCenterName");
                sSQL.AppendLine("UNION ALL");
            }
            sSQL.AppendLine("SELECT costCenterId, costCenterName AS costCenterName");
            sSQL.AppendLine("FROM CostCenter");
            sSQL.AppendLine("WHERE isActive = 1");

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            dt.DefaultView.Sort = "costCenterName";
            dt = dt.DefaultView.ToTable();

            cbo.DataSource = dt;
            cbo.DisplayMember = "costCenterName";
            cbo.ValueMember = "costCenterId";

            cbo.SelectedIndex = -1;
        }
        catch
        { }
    }
    
    public void ExportDataTableFlatFile(DataTable dt, string outputFilePath)
    {
        int[] maxLengths = new int[dt.Columns.Count];

        for (int i = 0; i < dt.Columns.Count; i++)
        {
            maxLengths[i] = dt.Columns[i].ColumnName.Length;

            foreach (DataRow row in dt.Rows)
            {
                if (!row.IsNull(i))
                {
                    int length = row[i].ToString().Length;

                    if (length > maxLengths[i])
                    {
                        maxLengths[i] = length;
                    }
                }
            }
        }

        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(outputFilePath, false))
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
            }

            sw.WriteLine();

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!row.IsNull(i))
                    {
                        //if (i == 2)
                        //{ sw.R}
                        //else
                        { sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2)); }
                    }
                    else
                    {
                        sw.Write(new string(' ', maxLengths[i] + 2));
                    }
                }

                sw.WriteLine();
            }

            sw.Close();
        }
    }

    public string CheckLatestVersion()
    {
        try
        {
            StringBuilder sSQL = new StringBuilder();

            sSQL.AppendLine("DECLARE @currentVersion VARCHAR(50) = " + Declaration.SystemVersion.sQuote());

            SqlParameter pLatestVersion = new SqlParameter("@latestVersion", SqlDbType.VarChar, 25);
            pLatestVersion.Direction = ParameterDirection.Output;

            SqlParameter pLatestLink = new SqlParameter("@latestLink", SqlDbType.VarChar, 250);
            pLatestLink.Direction = ParameterDirection.Output;

            sSQL.AppendLine("DECLARE @errorMessage VARCHAR(250)");

            sSQL.AppendLine("SELECT @latestVersion = setValue");
            sSQL.AppendLine("FROM SystemSetting");
            sSQL.AppendLine("WHERE setCode = 'LATEST_VERSION'");

            sSQL.AppendLine("SELECT @latestLink = setValue");
            sSQL.AppendLine("FROM SystemSetting WHERE setCode = 'LATEST_VERSION_LINK'");

            sSQL.AppendLine("IF @latestVersion IS NULL AND @latestLink IS NULL");
            sSQL.AppendLine("    BEGIN");
            sSQL.AppendLine("        RAISERROR ('ERROR', 16, 1)  WITH NOWAIT");
            sSQL.AppendLine("    END");
            using (SQLDB sql = new SQLDB())
            { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pLatestVersion, pLatestLink); }

            return pLatestVersion.Value.ToString() + GlobalSettings.DELIMITER + pLatestLink.Value.ToString();
        }
        catch 
        { return ""; }
    }

    public void CreateLoginLog()
    {
        StringBuilder sSQL = new StringBuilder();

        sSQL.AppendLine("DECLARE @lastAction VARCHAR(250) = 'LOGIN'");
        sSQL.AppendLine("DECLARE @secCode VARCHAR(50) = " + GlobalSettings.UserName.sQuote());

        sSQL.AppendLine("UPDATE ActivityLog");
        sSQL.AppendLine("SET ");
        sSQL.AppendLine("   lastLogin = GETDATE()");
        sSQL.AppendLine("WHERE secCode = @secCode");

        sSQL.AppendLine("");

        sSQL.AppendLine("IF @@ROWCOUNT = 0");
        sSQL.AppendLine("    BEGIN");
        sSQL.AppendLine("        INSERT INTO ActivityLog(secCode, lastLogin, lastAction, lastActivity)");
        sSQL.AppendLine("        VALUES(@secCode, GETDATE(), @lastAction, GETDATE())");
        sSQL.AppendLine("    END");

        using (SQLDB sql = new SQLDB())
        { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text); }
    }

    public string CreateActivityLog(string lastAction)
    {
        StringBuilder sSQL = new StringBuilder();

        sSQL.AppendLine("DECLARE @lastAction VARCHAR(250) = " + lastAction.sQuote());
        sSQL.AppendLine("DECLARE @secCode VARCHAR(50) = " + GlobalSettings.UserName.sQuote());


        sSQL.AppendLine("UPDATE ActivityLog");
        sSQL.AppendLine("   SET lastAction = @lastAction,");
        sSQL.AppendLine("   lastActivity = GETDATE()");
        sSQL.AppendLine("WHERE secCode = @secCode");

        return sSQL.ToString();
    }
    
    public void GetUserType()
    {
        SqlParameter pUserType = new SqlParameter("@userType", SqlDbType.VarChar, 50);
        pUserType.Direction = ParameterDirection.Output;

        StringBuilder strSQL = new StringBuilder();

        strSQL.AppendLine("SELECT @userType = (SELECT STUFF((SELECT ' | ' + groupCode ");
        strSQL.AppendLine("FROM SystemMember");
        strSQL.AppendLine("WHERE secCode = " + GlobalSettings.UserName.Trim().sQuote());
        strSQL.AppendLine("FOR XML PATH(''), TYPE ");
        strSQL.AppendLine("     ).value('.', 'NVARCHAR(MAX)')");
        strSQL.AppendLine(", 1, 1, '')) ");
        strSQL.AppendLine("FROM SystemMember");

        using (SQLDB sql = new SQLDB())
        { sql.ExecuteNonQuery(strSQL.ToString(), CommandType.Text, pUserType); }

        if (pUserType != null)
            Declaration.USER_TYPE = pUserType.Value.ToString();
        else
            Declaration.USER_TYPE = "REQUESTER";
    }

    public int GetEmployeeId()
    {
        SqlParameter pId = new SqlParameter("@employeeId", SqlDbType.Int);
        pId.Direction = ParameterDirection.Output;

        StringBuilder strSQL = new StringBuilder();

        strSQL.AppendLine("SELECT @employeeId = employeeId");
        strSQL.AppendLine("FROM SystemUser");
        strSQL.AppendLine("WHERE secCode = " + GlobalSettings.UserName.Trim().sQuote());

        using (SQLDB sql = new SQLDB())
        { sql.ExecuteNonQuery(strSQL.ToString(), CommandType.Text, pId); }

        if (pId != null)
            return Convert.ToInt32(pId.Value);
        else
            return -1;
    }

    public int GetIdScript(string counterName)
    {
        StringBuilder sSQL = new StringBuilder();

        SqlParameter pId = new SqlParameter("@counterValue", SqlDbType.Int);
        pId.Direction = ParameterDirection.Output;

        sSQL.AppendLine("DECLARE @" + counterName + " VARCHAR(50)");

        sSQL.AppendLine("SELECT @" + counterName + " = value, @counterValue = value");
        sSQL.AppendLine("FROM Counter");
        sSQL.AppendLine("WHERE name = " + counterName.sQuote());

        sSQL.AppendLine("");

        sSQL.AppendLine("IF @@ROWCOUNT = 0");
        sSQL.AppendLine("    BEGIN");
        sSQL.AppendLine("        SELECT @counterValue = 1");
        sSQL.AppendLine("        INSERT INTO Counter(name, value)");
        sSQL.AppendLine("        VALUES(" + counterName.sQuote() + ", 2)");
        sSQL.AppendLine("        SELECT @" + counterName + " = 1");
        sSQL.AppendLine("    END");
        sSQL.AppendLine("ELSE");
        sSQL.AppendLine("    BEGIN");
        sSQL.AppendLine("        SELECT @counterValue = @counterValue + 1");
        sSQL.AppendLine("        UPDATE Counter SET");
        sSQL.AppendLine("            value = value + 1");
        sSQL.AppendLine("        WHERE name = " + counterName.sQuote());
        sSQL.AppendLine("    END");

        using (SQLDB sql = new SQLDB())
        { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pId); }

        return Convert.ToInt32(pId.Value);
    }

    //\\HKEY_LOCAL_MACHINE\SOFTWARE\COMPANY\APPLICATION \ SUBKEY
    public string SetSetting(string subKey, string name, string value)
    {
        try
        {
            if (subKey != "")
            { subKey = "\\" + subKey; }

            regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(companyCode + "\\" + applicationName + subKey, true);

            if (regkey == null)
            {
                //regkey = Registry.LocalMachine.OpenSubKey(SOFTWARE, true);
                regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(companyCode + "\\" + applicationName + subKey);
                regkey.SetValue(name, value);
            }
            else
            {
                regkey.SetValue(name, value);

            }

            regkey.Close();
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
            throw new Exception(ex.Message.ToString());
        }
    }

    public string GetSetting(string subKey, string name, string defaultValue)
    {
        string strReturn = "";

        try
        {
            if (subKey != "")
            { subKey = "\\" + subKey; }

            regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(companyCode + "\\" + applicationName + subKey, true);
            strReturn = regkey.GetValue(name, defaultValue).ToString();

            if (strReturn == "")
            { strReturn = defaultValue; }

            return strReturn;
        }
        catch
        { return defaultValue; }
    }

    public void GetDesignStatusInfo(ref DataTable dtStatus, string designepvStatusId)
    {
        try
        {
            StringBuilder sSQL = new StringBuilder();

            sSQL.Clear();
            sSQL.AppendLine("SELECT name, action, lineNumber, isActive, localSupplier, foreignSupplier");
            sSQL.AppendLine("FROM DesignStatus");
            sSQL.AppendLine("WHERE designepvStatusId = " + designepvStatusId.sQuote());

            using (SQLDB sql = new SQLDB())
            { dtStatus = sql.GetDT(sSQL.ToString()); }

            if (dtStatus.Rows.Count == 0)
            {
                throw new Exception("Design Status not found");
            }

        }
        catch (Exception ex)
        {
            function.MsgBoxInfo("Design Status", ex.Message);
        }
    }

    public DataTable GetImageInfo(int productDesignId)
    {
        try
        {
            StringBuilder sSQL = new StringBuilder();
            DataTable dtImage = new DataTable();

            sSQL.Clear();

            sSQL.AppendLine("IF NOT OBJECT_ID ('tempdb..#tmpColor') IS NULL DROP TABLE #tmpColor ");
            sSQL.AppendLine("SELECT STUFF((SELECT ' | ' + name ");
            sSQL.AppendLine("            from Color C ");
            sSQL.AppendLine("		        INNER JOIN ProductDesignColor PDC ON PDC.colorId = C.colorId AND PDC.productDesignId = " + productDesignId);
            sSQL.AppendLine("	        GROUP BY PDC.lineNumber, C.colorId, name ");
            sSQL.AppendLine("	        ORDER BY PDC.lineNumber ");
            sSQL.AppendLine("    FOR XML PATH(''), TYPE ");
            sSQL.AppendLine("    ).value('.', 'NVARCHAR(MAX)') ");
            sSQL.AppendLine(",1,1,'') AS colorList, " + productDesignId + " AS productDesignId");
            sSQL.AppendLine("INTO #tmpColor ");

            sSQL.AppendLine("SELECT productDesignId, imageData, designStatus, designepvStatusId, actualDate, hasCollection, remark, itemGroupId");
            sSQL.AppendLine("FROM (SELECT PD.productDesignId,  ");
            sSQL.AppendLine("   CASE WHEN PD.designepvStatusId = 'OGP' ");
            sSQL.AppendLine("       OR PD.designepvStatusId = 'ONT' ");
            sSQL.AppendLine("       OR PD.designepvStatusId = 'DELIVERED' ");
            sSQL.AppendLine("       OR PD.designepvStatusId = 'ONH' ");
            sSQL.AppendLine("       THEN POP.imageData ELSE PDP.imageData END AS imageData, DesignStatus.name AS designStatus, PD.designepvStatusId, AH.actualDate,");
            sSQL.AppendLine("   CASE WHEN (SELECT TOP 1 productDesignId FROM POCollection POCol WHERE POCol.productDesignId = " + productDesignId + ") IS NULL THEN 'NO' ELSE 'YES' END AS hasCollection,");
            sSQL.AppendLine("	CONCAT('PO # : ', POB.poNumber, CHAR(13), CHAR(10),  ");
            sSQL.AppendLine("	'ITEM ID : ', productDesignCode, CHAR(13), CHAR(10),  ");
            sSQL.AppendLine("	'STOCK NO : ', POB.stockNumber, CHAR(13), CHAR(10),  ");
            sSQL.AppendLine("	'SEASON : ', Season.name, CHAR(13), CHAR(10), ");
            sSQL.AppendLine("	'VENDOR : ', Supplier.name, CHAR(13), CHAR(10), ");
            sSQL.AppendLine("	'VENDOR STOCK #: ', supplierStockNo, CHAR(13), CHAR(10), ");
            sSQL.AppendLine("	'MATERIAL : ', Fabric.name, CHAR(13), CHAR(10),  ");
            sSQL.AppendLine("	'COLORS : ', colorList, CHAR(13), CHAR(10), ");
            sSQL.AppendLine("	'STATUS : ', DesignStatus.name) ");
            sSQL.AppendLine("	AS remark,  ");
            sSQL.AppendLine("	row_number() OVER(PARTITION BY PDP.productDesignId ORDER BY PDP.createDate desc) as rn, itemGroupId ");
            sSQL.AppendLine("      FROM ProductDesign PD ");
            sSQL.AppendLine("    INNER JOIN ProductDesignPicture PDP ON PD.productDesignId = PDP.productDesignId ");
            sSQL.AppendLine("    LEFT JOIN ProductDesignPOBrand POB ON POB.productDesignId = PD.productDesignId ");
            sSQL.AppendLine("       AND POB.brandId = PD.brandId");
            sSQL.AppendLine("    LEFT JOIN POPicture POP ON POP.productDesignId = PD.productDesignId AND POP.lineNumber = 1 ");
            sSQL.AppendLine("    LEFT JOIN Season ON PD.seasonId = Season.seasonId ");
            sSQL.AppendLine("    LEFT JOIN ProductDesignSupplier PDS ON PDS.productDesignId = PD.productDesignId ");
            sSQL.AppendLine("    LEFT JOIN Supplier ON PDS.supplierId = Supplier.supplierId ");
            sSQL.AppendLine("    LEFT JOIN ProductDesignCharacteristic PDC ON PDC.productDesignId = PD.productDesignId ");
            sSQL.AppendLine("    LEFT JOIN Fabric ON Fabric.fabricId = PDC.fabricId ");
            sSQL.AppendLine("    LEFT JOIN #tmpColor C ON C.productDesignId = PD.productDesignId ");
            sSQL.AppendLine("	 LEFT JOIN DesignStatus ON PD.designepvStatusId = DesignStatus.designepvStatusId ");
            sSQL.AppendLine("	 LEFT JOIN ProductDesignActionHistory AH ON AH.productDesignId = PD.productDesignId ");
            sSQL.AppendLine("	                    AND AH.designepvStatusId = PD.designepvStatusId ");
            sSQL.AppendLine("WHERE PDP.productDesignId = " + productDesignId + ") as T ");
            sSQL.AppendLine("WHERE rn = 1       ");

            using (SQLDB sql = new SQLDB())
            { return dtImage = sql.GetDT(sSQL.ToString()); }
        }
        catch
        { return null; }
    }

    public string GetDesignStatusInfo(string designepvStatusId, string columnName)
    {
        try
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            sSQL.Clear();
            sSQL.AppendLine("SELECT name, action, lineNumber, isActive, localSupplier, foreignSupplier");
            sSQL.AppendLine("FROM DesignStatus");
            sSQL.AppendLine("WHERE designepvStatusId = " + designepvStatusId.sQuote());

            using (SQLDB sql = new SQLDB())
            { dt = sql.GetDT(sSQL.ToString()); }

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Design Status not found");
            }

            return dt.Rows[0][@columnName].ToString();
        }
        catch (Exception ex)
        {
            function.MsgBoxInfo("Design Status", ex.Message);
            return "";
        }
    }

    public string GetSetting(string subKey, string name)
    {
        string strReturn = "";

        try
        {
            if (subKey != "")
            { subKey = "\\" + subKey; }

            regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(companyCode + "\\" + applicationName + subKey, true);
            strReturn = Convert.ToString(regkey.GetValue(name));

            return strReturn;
        }
        catch
        { return strReturn; }
    }


    public void GetPicture(ref DataTable dtImage, long mvProductDesignId)
    {
        StringBuilder sSQL = new StringBuilder();

        sSQL.Clear();
        sSQL.AppendLine("SELECT id, imageData, remark, actualDate, createDate");
        sSQL.AppendLine("FROM ProductDesignPicture");
        sSQL.AppendLine("WHERE productDesignId = " + mvProductDesignId);

        using (SQLDB sql = new SQLDB())
        { dtImage = sql.GetDT(sSQL.ToString()); }
    }

    public string GetExeParameter(string commandLine, string option)
    {
        string strReturn = "";

        Int32 firstPos = 0;
        Int32 lastPos = 0;
        Int32 paramLen = 0;
        Int32 optionLen = 0;

        String strValue = "";

        if (commandLine.Contains(option) == true)
        {
            firstPos = commandLine.IndexOf(option);

            optionLen = option.Length;

            lastPos = commandLine.IndexOf(GlobalSettings.DELIMITER, firstPos + optionLen);

            if (lastPos == -1)
            { paramLen = commandLine.Length - firstPos - optionLen; }
            else
            { paramLen = lastPos - firstPos - optionLen; }

            strValue = commandLine.Substring(firstPos + optionLen, paramLen).Trim();
        }

        strReturn = strValue;

        return strReturn;
    }

    public byte[] ConvertToByte(Image imageFile)
    {
        try
        {
            byte[] byteArray = new byte[0];

            Bitmap Image = new Bitmap(imageFile, 360, 360);
            Image.SetResolution(20, 20);

            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byteArray = stream.ToArray();
                stream.Close();
            }

            return byteArray;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void SavePicture(Image imageData, string productDesignId, DateTime actualDate, string epvStatusId, string statusAction)
    {
        string sSQL = "";

        try
        {
            sSQL = "proc_SaveProductDesignPicture";

            using (SQLDB sql = new SQLDB())
            {
                SqlParameter pProductDesignId = new SqlParameter("@productDesignId", SqlDbType.Int);
                pProductDesignId.Value = productDesignId;

                SqlParameter pImageData = new SqlParameter("@imageData", SqlDbType.VarBinary);
                pImageData.Value = ConvertToByte(imageData);

                SqlParameter pImageType = new SqlParameter("@imageType", SqlDbType.VarChar, 20);
                pImageType.Value = epvStatusId;

                SqlParameter pActualDate = new SqlParameter("@actualDate", SqlDbType.VarChar, 250);
                pActualDate.Value = actualDate.ToShortDateString();

                SqlParameter pRemark = new SqlParameter("@remark", SqlDbType.VarChar, 250);
                pRemark.Value = statusAction;

                SqlParameter pUsername = new SqlParameter("@username", SqlDbType.VarChar, 50);
                pUsername.Value = GlobalSettings.UserName;

                sql.ExecuteNonQuery(sSQL, CommandType.StoredProcedure, pProductDesignId, pImageData, pImageType, pActualDate, pRemark, pUsername);
            }

        }
        catch (Exception ex)
        { function.MsgBoxInfo("Save Picture", "Saving Failed!\n" + ex.Message.ToString()); }

    }

    public string GetItemID(string ItemId)
    {
        StringBuilder sSQL = new StringBuilder();

        string value = "";
        string ErrorMessage = "";

        try
        {

            SqlParameter pProductDesignId = new SqlParameter("@productDesignId", SqlDbType.Int);
            pProductDesignId.Direction = ParameterDirection.Output;

            using (SQLDB sql = new SQLDB())
            {

                sSQL.AppendLine("SELECT @productDesignId = productDesignId");
                sSQL.AppendLine("FROM ProductDesign");
                sSQL.AppendLine("WHERE productDesignCode = " + ItemId.sQuote());

                sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pProductDesignId);
            }

            value = pProductDesignId.Value.ToString();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message.ToString();
            throw new Exception(ErrorMessage);
        }

        return value;
    }

    public bool HasItemAccess(string ItemId)
    {
        DataTable dt = new DataTable();
        string sSQL = "";

        bool bolReturn = false;
        string ErrorMessage = "";

        try
        {
            sSQL = "proc_DesignerGetRight";

            using (SQLDB sql = new SQLDB())
            {
                SqlParameter pProductDesignCode = new SqlParameter("@productDesignCode", SqlDbType.VarChar, 15);
                pProductDesignCode.Value = ItemId;

                SqlParameter pSecCode = new SqlParameter("@secCode", SqlDbType.VarChar, 50);
                pSecCode.Value = GlobalSettings.UserName;

                dt = sql.GetDT(sSQL, CommandType.StoredProcedure, pProductDesignCode, pSecCode);
            }

            if (dt.Rows.Count != 0)
            {
                bolReturn = true;
            }

        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message.ToString();
            throw new Exception(ErrorMessage);
        }
        finally
        { dt.Dispose(); }

        return bolReturn;
    }

    public string SplitText(string text, int position)
    {
        string strReturn = "";
        try
        {
            char[] delimiter = { Convert.ToChar("("), Convert.ToChar(")") };
            string[] value = text.Split(delimiter);

            strReturn = value[position - 1];

            return strReturn;
        }
        catch
        {
            strReturn = "";
            return strReturn;
        }

    }

    public string AddOrdinal(int num)
    {
        if (num <= 0) return num.ToString();

        switch (num % 100)
        {
            case 11:
            case 12:
            case 13:
                return num + "th";
        }

        switch (num % 10)
        {
            case 1:
                return num + "st";
            case 2:
                return num + "nd";
            case 3:
                return num + "rd";
            default:
                return num + "th";
        }

    }

    public string CreateActionHistory(string designepvStatusId, string designStatusName, string designStatusAction, string actionRemark, string actualDate,
          string actionStartDate)
    {
        StringBuilder sReturn = new StringBuilder();

        sReturn.AppendLine("INSERT INTO ProductDesignActionHistory(productDesignId, brandId, ");
        sReturn.AppendLine("    designepvStatusId, designStatusName, [action], actualDate, elapseDays, secCode, secName, remark,");
        sReturn.AppendLine("    createDate)");
        sReturn.AppendLine("VALUES(@productDesignId, @brandId, " + designepvStatusId.sQuote() + ", " + designStatusName.sQuote()
            + "," + designStatusAction.sQuote() + "," + actualDate.sQuote() + ", ");
        sReturn.AppendLine("ISNULL(DATEDIFF(day, (SELECT TOP 1 actualDate FROM ProductDesignActionHistory AH ");
        sReturn.AppendLine("WHERE AH.productDesignId = @productDesignId ORDER BY actualDate DESC), " + actualDate.sQuote() + " ), 0), ");
        sReturn.AppendLine(GlobalSettings.UserName.sQuote() + ", " + GlobalSettings.UserFullName.sQuote() + ", ");
        sReturn.AppendLine("    " + actionRemark.sQuote() + "," + actionStartDate.sQuote() + ")");

        sReturn.AppendLine(CreateActivityLog(designStatusAction));

        return sReturn.ToString();
    }

    public string CreateActionHistory(string designepvStatusId, string designStatusName, string subDesignepvStatusId, string subDesignStatusAction, string actionRemark, string actualDate,
      string actionStartDate)
    {
        StringBuilder sReturn = new StringBuilder();

        sReturn.AppendLine("INSERT INTO ProductDesignActionHistory(productDesignId, brandId, ");
        sReturn.AppendLine("    designepvStatusId, designStatusName, subDesignepvStatusId, [action], actualDate, elapseDays, secCode, secName, remark,");
        sReturn.AppendLine("    createDate)");
        sReturn.AppendLine("VALUES(@productDesignId, @brandId, " + designepvStatusId.sQuote() + ", " + designStatusName.sQuote() + "," + subDesignepvStatusId.sQuote() + "," + subDesignStatusAction.sQuote() + ",");
        sReturn.AppendLine("    " + actualDate.sQuote() + ", ");
        sReturn.AppendLine("ISNULL(DATEDIFF(day, (SELECT TOP 1 actualDate FROM ProductDesignActionHistory AH ");
        sReturn.AppendLine("WHERE AH.productDesignId = @productDesignId ORDER BY actualDate DESC), " + actualDate.sQuote() + " ), 0), ");
        sReturn.AppendLine(GlobalSettings.UserName.sQuote() + ", " + GlobalSettings.UserFullName.sQuote() + ", ");
        sReturn.AppendLine("    " + actionRemark.sQuote() + "," + actionStartDate.sQuote() + ")");

        sReturn.AppendLine(CreateActivityLog(subDesignStatusAction));

        return sReturn.ToString();
    }

    public int GetAge(DateTime Now, DateTime BirthDay)
    {
        int intAge = Convert.ToInt32(Now.Year - BirthDay.Year);

        if (Now < BirthDay.AddYears(intAge))
        {
            intAge--;
        }

        return intAge;
    }

    public string GetDays(DateTime startDate, DateTime endDate)
    {
        decimal decBase = Convert.ToDecimal(((endDate - startDate).TotalDays + 1) / 365);
        decimal decYears = Math.Truncate(decBase);
        decimal decMonths = ((decBase - decYears) * 365) / 31;
        decimal decDays = (decMonths - Math.Truncate(decMonths)) * 31;

        return decYears.ToString("0#") + "." + Math.Truncate(decMonths).ToString("0#") + "." + Math.Round(decDays).ToString("0#");
    }

    public bool IsValidEmail(string eMail)
    {
        var r = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

        return !string.IsNullOrEmpty(eMail) && r.IsMatch(eMail);
    }

    public string SSISConnectionString(string dataSource, string userName, string password, string database)
    {
        return "Provider = SQLNCLI11; Auto Translate = false;" +
                "Data Source= " + dataSource + "; User ID = " + userName + ";" +
                "Password = " + password + "; Initial Catalog = " + database + ";";
    }
}
