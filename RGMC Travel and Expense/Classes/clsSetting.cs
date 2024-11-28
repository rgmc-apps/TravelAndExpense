using System;

using MyCommon;
using MyCommon.Settings;


public class Setting
{
    public static string InitializeSetting()    
    {
        Function function = new Function();

        string strReturn = "";

        try
        {
            GlobalSettings.CompanyName = Declaration.COMPANY_NAME;
            GlobalSettings.SystemName = Declaration.SYSTEM_NAME;

            //Declaration.EmpCL = Convert.ToDouble(function.GetDBSetting("EmployeeCL", "0"));

            //Declaration.MWIP = function.GetDBSetting("MWIP", "");

            //Declaration.MWDB = function.GetDBSetting("MWDB", "");

            Declaration.AMOUNT_LIMIT = Convert.ToDecimal(function.GetDBSetting("AMOUNT_LIMIT", "-1")); 

             GlobalSettings.WarehouseId = Convert.ToInt64(function.GetDBSetting("CurrentWarehouseId", "-1"));
            if (GlobalSettings.WarehouseId == -1)
            { throw new Exception("Warehouse id is not properly set-up."); }
            
        }
        catch (Exception ex)
        { strReturn = ex.Message; }

        return strReturn;
    }
}
