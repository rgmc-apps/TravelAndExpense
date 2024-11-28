using System;
using MyCommon.Settings;
using System.Data.SqlClient;

public static class Declaration
{
    public const string COMPANY_NAME = "Richfield Garments Manufacturing Corporation";
    public const string COMPANY_CODE = "RGMC";
    public const string SYSTEM_NAME = "MyRIS";

    public const string NAME_SPACE = "MyRIS";

    public const string APP_TYPE = "UTILITY";
    public const string PARENT_CAT_CODE = "UTILITY";
    
    public const long OTHER_ID = -8281976;    

    public const long SITE_VERIZON = 1;
    public const long SITE_SUNTREE = 2;

    public const int CHARGE_TO_ID_MULTIPLE = 11;

    public const int EPV_STATUS_ID_ALL = -1;
    public const int EPV_STATUS_ID_NEW = 0;
    public const int EPV_STATUS_ID_SAVED = 1;
    public const int EPV_STATUS_ID_FOR_APPROVAL = 2;
    public const int EPV_STATUS_ID_APPROVED = 3;
    public const int EPV_STATUS_ID_FOR_AUDIT = 4;
    public const int EPV_STATUS_ID_FOR_RELEASING = 5;
    public const int EPV_STATUS_ID_UPLOADED = 6;
    public const int EPV_STATUS_ID_RELEASED = 7;
    public const int EPV_STATUS_ID_REJECTED = 8;
    public const int EPV_STATUS_ID_RECEIVED = 9;

    public const int CA_STATUS_ID_ALL = -1;
    public const int CA_STATUS_ID_NEW = 0;
    public const int CA_STATUS_ID_SAVED = 1;
    public const int CA_STATUS_ID_FOR_APPROVAL = 2;
    public const int CA_STATUS_ID_APPROVED = 3;
    public const int CA_STATUS_ID_FOR_AUDIT = 8;
    public const int CA_STATUS_ID_FOR_RELEASING = 9;
    public const int CA_STATUS_ID_UPLOADED = 4;
    public const int CA_STATUS_ID_RELEASED = 5;
    public const int CA_STATUS_ID_LIQUIDATED = 6;
    public const int CA_STATUS_ID_REJECTED = 7;
    public const int CA_STATUS_ID_RECEIVED = 10;

    public const string GROUP_APPROVER = "APPROVER";
    public const string GROUP_ACCOUNTING = "ACTG";
    public const string GROUP_ALL_DEPARTMENT = "ALL";
    public const string GROUP_ADMINISTRATIVE = "ADMN";
    public const string GROUP_CREATIVE = "CRTV";
    public const string GROUP_HR = "HR";
    public const string GROUP_IT = "IT";
    public const string GROUP_MARKETING = "MKTG";
    public const string GROUP_MERCHANDISING = "MRCH";
    public const string GROUP_OPERATIONS = "OPS";
    public const string GROUP_PRODUCTION = "PROD";
    public const string GROUP_RAD = "R&D";
    public const string GROUP_SALES = "SALES";
    public const string GROUP_TREASURY = "TREASURY";
    public const string GROUP_VISUAL_MERCHANDISE = "VM";
    public const string GROUP_WAREHOUSE = "WH/LOG";
    public const string GROUP_UPLOADER_RELEASER = "UR";
    public const string GROUP_APPROVER_RECEIVER = "AR";
    public const string GROUP_AUDITOR = "AUD";
    //MOD CODES
    //*********** 
    public const string MODULE_CODE = "TES";
    public const string MOD_CODE_UTILITY = "UTILITY";
    public const string MOD_CODE_REPORT = "REPORT";
    public const string MOD_CODE_EPV = "EPV";

    public const string MOD_CODE_FOR_SAVED = "SAVED";
    public const string MOD_CODE_FOR_APPROVAL = "FOR_APPROVAL";
    public const string MOD_CODE_FOR_RECEIVING = "FOR_RECEIVING";
    public const string MOD_CODE_FOR_AUDIT = "FOR_AUDIT";
    public const string MOD_CODE_FOR_RELEASING = "FOR_RELEASING";
    public const string MOD_CODE_UPLOADED = "UPLOADED";
    public const string MOD_CODE_RELEASED = "RELEASED";
    public const string MOD_CODE_REJECTED = "REJECTED";

    public const string MOD_CODE_CASH_ADVANCE = "CA";
    public const string MOD_CODE_CASH_ADVANCE_ADMIN = "CA_ADMIN";
    public const string MOD_CODE_USER_ACCOUNT = "USERACCOUNT";
    public const string MOD_CODE_USER_ACTIVITY = "USER_ACTIVITY";
    public const string MOD_CODE_SUPPLIER = "SUPPLIER";
    public const string MOD_CODE_NATURE_OF_EXPENSE = "NATURE_OF_EXPENSE";
    public const string MOD_CODE_BUSINESS_PURPOSE = "BUSINESS_PURPOSE";
    public const string MOD_CODE_COST_CENTER = "COST_CENTER";
    public const string MOD_CODE_MODE_OF_PAYMENT = "MODE_OF_PAYMENT";
    public const string MOD_CODE_MODE_OF_TRANSPO = "MODE_OF_TRANSPO";
    public const string MOD_CODE_STORES = "STORES";
    
    public const string STR_LAST_SERVER = "SUNTREE";

    public const string MODULE_TITLE = "Travel and Expense System";

    public const string UTI_APP_TYPE = "UTILITY";
    public const string UTI_PARENT_CAT_CODE = "UTILITY";

    public const string RPT_APP_TYPE = "REPORT";
    public const string RPT_PARENT_CAT_CODE = "REPORT";

    public const string UDL_PATH = "C:\\Program Files\\MRDS\\Data\\RGMCCreative.udl";

    public const string NEW_COMMAND = "NEW";
    public const string OPEN_COMMAND = "OPEN";
    public const string EDIT_COMMAND = "EDIT";
    public const string REFRESH_COMMAND = "REFRESH";
    public const string SHOW_ALL_COMMAND = "SHOW ALL";
    public const string FILTER_COMMAND = "FILTER";
    public const string EXIT_COMMAND = "EXIT";
    public const string PRINT_COMMAND = "PRINT";

    public const string TYPE_SUPPLIER = "SUPPLIER";
    public const string TYPE_BRANCH = "BRANCH";
    public const string TYPE_WAREHOUSE = "WAREHOUSE";

    public const string TYPE_SUMMARY = "SUMMARY";
    public const string TYPE_DETAIL = "DETAIL";

    public const int TRANSACT_TYPE_REIMBURSEMENT_ID = 1;
    public const int TRANSACT_TYPE_LIQUIDATED_ID = 2;

    public const int TRANS_MODE_EPV = 1;
    public const int TRANS_MODE_CA = 2;

    public static string USER_TYPE = "REQUESTER";
    
    private static double EMP_CL = 2500;

    private static string mvSystemVersion = "1.0.0.888";

    public static string PORT_CHAT = "8000";
 
    // ssis source
    // **********************
    public const int SSIS_SRC_MODE_TBL = 0;
    public const int SSIS_SRC_MODE_VAR = 1;
    public const int SSIS_SRC_MODE_SQL = 2;
    public const int SSIS_SRC_MODE_SQLVAR = 3;

    public const string SSIS_SRC_PROP_TBL = "OpenRowset";
    public const string SSIS_SRC_PROP_VAR = "OpenRowsetVariable";
    public const string SSIS_SRC_PROP_SQL = "SqlCommand";
    public const string SSIS_SRC_PROP_SQLVAR = "SqlCommandVariable";
    // **********************

    // ssis destination
    // **********************
    public const int SSIS_DEST_MODE_TBL = 0;
    public const int SSIS_DEST_MODE_VAR = 1;
    public const int SSIS_DEST_MODE_SQL = 2;
    public const int SSIS_DEST_MODE_TBL_FAST = 3;
    public const int SSIS_DEST_MODE_VAR_FAST = 4;

    public const string SSIS_DEST_PROP_TBL = "OpenRowset";
    public const string SSIS_DEST_PROP_VAR = "OpenRowsetVariable";
    public const string SSIS_DEST_PROP_SQL = "SqlCommand";
    public const string SSIS_DEST_PROP_TBL_FAST = "OpenRowset";
    public const string SSIS_DEST_PROP_VAR_FAST = "OpenRowsetVariable";
    // **********************

    public static System.Drawing.Color failedForeColor = System.Drawing.Color.Red;
    public static System.Drawing.Color successForeColor = System.Drawing.Color.Green;
    public static System.Drawing.Color reqBackColor = System.Drawing.Color.Pink;
    public static System.Drawing.Brush reqBackBrush = System.Drawing.Brushes.Gold;

    private static SqlConnection otherConnection;      

    public static decimal AMOUNT_LIMIT = 0;

    #region Property

    #region OtherConnection

    public static SqlConnection OtherConnection(string Server, string Database)
    {

        otherConnection = new SqlConnection();

        string strConnectionString = @"Data Source=" + Server
                        + ";Initial Catalog=" + Database
                        + ";User ID=" + GlobalSettings.DBUserName
                        + ";Password=" + GlobalSettings.DBPassword
                        + ";Integrated Security=False";

        if (otherConnection.State == System.Data.ConnectionState.Closed)
        {
            otherConnection.ConnectionString = strConnectionString;
            otherConnection.Open();
        }

        return otherConnection;
    }

    public static string CloseOtherConnection()
    {
        string strReturn = "";

        try
        {
            if (otherConnection.State == System.Data.ConnectionState.Open)
            {
                otherConnection.Close();
                otherConnection.Dispose();
            }
        }
        catch (Exception ex)
        { strReturn = ex.Message.ToString(); }

        return strReturn;
    }

    #endregion

    public static string SystemVersion
    {
        get
        {
            string version = mvSystemVersion;

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                version = ad.CurrentVersion.ToString();
            }
            return version;
        }
    }
    
    public static double EmpCL
    {
        get
        { return EMP_CL; }

        set
        { EMP_CL = value; }
    }

    //public static string MWIP
    //{
    //    get
    //    { return MW_IP; }

    //    set
    //    { MW_IP = value; }
    //}

    //public static string MWDB
    //{
    //    get
    //    { return MW_DB; }

    //    set
    //    { MW_DB = value; }
    //}

    #endregion 
   
}
