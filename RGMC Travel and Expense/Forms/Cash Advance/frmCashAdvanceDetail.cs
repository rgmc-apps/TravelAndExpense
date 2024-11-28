using Microsoft.Reporting.WinForms;
using MyCommon;
using MyCommon.Data;
using MyCommon.Settings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;

namespace MyRIS
{
    public partial class frmCashAdvanceDetail : Form
    {
        private Common common = new Common();
        Function function = new Function();
        private int mvCAId = -1;
        private int mvChargeToId = -1;
        DialogResult refresh = new DialogResult();
        private DataTable comboStores;
        private DataTable comboChargeTo;
        private DataTable mainDT = new DataTable();

        private static int IX_GRID_PARTICULARS = 0;
        private static int IX_GRID_CHARGE_TO_NAME = 1;
        private static int IX_GRID_AMOUNT = 2;
        private static int IX_GRID_IS_ACTIVE = 3;
        private static int IX_GRID_CHARGE_TO_ID = 4;

        private const int MODE_SUBMIT = 1;
        private const int MODE_SAVE = 2;
        private const int MODE_APPROVE = 3;
        private const int MODE_REJECT = 4;
        private const int MODE_RETURN = 5;
        private const int MODE_MODIFY = 6;

        private const string CODE_SUBMIT = "SUBMIT";
        private const string CODE_SAVE = "SAVE";
        private const string CODE_APPROVE = "APPROVE";
        private const string CODE_REJECT = "REJECT";
        private const string CODE_RETURN = "RETURN";

        private bool mvSave = false;

        private int lastIndex = -1;
        
        private bool isMultiple = false;


        #region Property

        public int CashAdvanceId
        {
            set { mvCAId = value; }
        }

        public int ChargeToId
        {
            set { mvChargeToId = value; }
        }

        public bool Save
        {
            set { mvSave = value; }
            get { return mvSave; }
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.T) && btnAccept.Visible)
            {
                btnAccept.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.D) && btnDecline.Visible)
            {
                btnDecline.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.R) && btnReturn.Visible)
            {
                btnReturn.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Shift | Keys.D))
            {
                btnSubmit.Visible = true;
                return true;
            }

            if (keyData == (Keys.Control | Keys.S) && btnSave.Visible)
            {
                btnSave.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.B) && btnSubmit.Visible)
            {
                btnSubmit.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P) && btnPrint.Visible)
            {
                btnPrint.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.A) && btnAdd.Visible)
            {
                btnAdd.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public frmCashAdvanceDetail()
        {
            InitializeComponent();
        }

        //private void ClearInfo()
        //{
        //    //txtInputCANumber.Clear();
        //    txtParticulars.Clear();
        //    txtAmount.Clear();
        //    txtApproved.Clear();
        //    txtRemarks.Clear();
        //    //txtReqBy.Clear();
        //}


        private void SaveInfo(int MODE)
        {
            StringBuilder sSQL = new StringBuilder();

            //string strRemark = txtRemark.Text.Trim();
            DataTable dt = new DataTable();
            string strUserName = GlobalSettings.UserName;

            try
            {
                int currentStatus = Convert.ToInt32(lblStatus.Tag);          

                switch (currentStatus)
                {
                    case Declaration.CA_STATUS_ID_FOR_APPROVAL:
                        if (!function.HasAccess(Declaration.MOD_CODE_FOR_APPROVAL, GlobalSettings.ACCESS_WRITE))
                        { throw new Exception("Sorry you have no access in this module."); }
                        break;
                    case Declaration.CA_STATUS_ID_APPROVED:
                        if (!function.HasAccess(Declaration.MOD_CODE_FOR_RECEIVING, GlobalSettings.ACCESS_WRITE))
                        { throw new Exception("Sorry you have no access in this module."); }
                        break;
                    case Declaration.CA_STATUS_ID_FOR_AUDIT:
                        if (!function.HasAccess(Declaration.MOD_CODE_FOR_AUDIT, GlobalSettings.ACCESS_WRITE))
                        { throw new Exception("Sorry you have no access in this module."); }
                        break;
                    case Declaration.CA_STATUS_ID_FOR_RELEASING:
                        if (!function.HasAccess(Declaration.MOD_CODE_FOR_RELEASING, GlobalSettings.ACCESS_WRITE))
                        { throw new Exception("Sorry you have no access in this module."); }
                        break;
                    case Declaration.CA_STATUS_ID_UPLOADED:
                        if (!function.HasAccess(Declaration.MOD_CODE_UPLOADED, GlobalSettings.ACCESS_WRITE))
                        { throw new Exception("Sorry you have no access in this module."); }
                        break;
                    default:
                        DisableALL();
                        break;
                }
                // declare variable
                // **************************
                mvChargeToId = Convert.ToInt32(cboChargeTo.SelectedValue);
                string chargeToFormat = "";

                System.Data.SqlClient.SqlParameter pCaId = new System.Data.SqlClient.SqlParameter("@caId", SqlDbType.Int);
                pCaId.Direction = ParameterDirection.Output;

                sSQL.AppendLine("DECLARE @dateNeeded DATE = " + dtpDateNeeded.Text.sQuote());
                sSQL.AppendLine("DECLARE @requestDate DATE = " + dtpRequested.Text.sQuote());
                sSQL.AppendLine("DECLARE @businessPurposeId INT = " + cboBusinessPurpose.SelectedValue);
                sSQL.AppendLine("DECLARE @bpOthers VARCHAR(250) = " + txtBusinessOthers.Text.sQuote());
                sSQL.AppendLine("DECLARE @employeeId INT = " + txtName.Tag);
                sSQL.AppendLine("DECLARE @chargeToId INT = " + cboChargeTo.SelectedValue);
                sSQL.AppendLine("DECLARE @costCenterId INT = " + cboDepartment.SelectedValue);
                sSQL.AppendLine("DECLARE @storeId INT = " + cboStores.SelectedValue);
                sSQL.AppendLine("DECLARE @modeOfPaymentId INT = " + (cboModeOfPayment.SelectedValue == null ? -1 : cboModeOfPayment.SelectedValue));
                sSQL.AppendLine("DECLARE @caNumber VARCHAR(15) = " + txtCANumber.Text.sQuote());
                sSQL.AppendLine("DECLARE @caAmount MONEY = " + decimal.Parse(txtCAAmount.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands));
                sSQL.AppendLine("DECLARE @headApprovedById INT = " + txtHeadApproved.Tag);
                sSQL.AppendLine("DECLARE @headApprovedDate DATE = " + dtpHeadApproved.Text.sQuote());
                sSQL.AppendLine("DECLARE @mgtApprovedById INT = " + txtMgtApproved.Tag);
                sSQL.AppendLine("DECLARE @mgtApprovedDate DATE = " + dtpMgtApproved.Text.sQuote());
                sSQL.AppendLine("DECLARE @receivedByAcctId INT = " + txtDocsReceivedBy.Tag);
                sSQL.AppendLine("DECLARE @receivedByAcctDate DATE = " + dtpDocsReceived.Text.sQuote());
                sSQL.AppendLine("DECLARE @auditedById INT = " + txtAuditedBy.Tag);
                sSQL.AppendLine("DECLARE @auditedDate DATE = " + dtpAudited.Text.sQuote());
                sSQL.AppendLine("DECLARE @uploadedById INT = " + txtUploadedBy.Tag);
                sSQL.AppendLine("DECLARE @uploadedDate DATE = " + dtpUploadedBy.Text.sQuote());
                sSQL.AppendLine("DECLARE @releasedByAcctId INT = " + txtReleasedBy.Tag);
                sSQL.AppendLine("DECLARE @releasedByAcctDate DATE = " + dtpCashReleasedBy.Text.sQuote());
                sSQL.AppendLine("DECLARE @username VARCHAR(50) = " + GlobalSettings.UserName.sQuote());
                sSQL.AppendLine("DECLARE @remarks VARCHAR(300) = " + txtRemarks.Text.sQuote());

                sSQL.AppendLine("DECLARE @errorMessage VARCHAR(250)");
                sSQL.AppendLine("DECLARE @cashAdvanceStatusId INT");

                sSQL.AppendLine("\r");

                string modeCode = "";

                switch (MODE)
                {
                    case MODE_SUBMIT:
                        modeCode = CODE_SUBMIT;
                        break;
                    case MODE_SAVE:
                        modeCode = CODE_SAVE;
                        break;
                    case MODE_APPROVE:
                        modeCode = CODE_APPROVE;
                        break;
                    case MODE_REJECT:
                        modeCode = CODE_REJECT;
                        break;
                    case MODE_RETURN:
                        modeCode = CODE_RETURN;
                        break;
                }

                // **************************
                // new record
                if (mvCAId == -1)
                {
                    chargeToFormat = System.Text.RegularExpressions.Regex.Replace(cboChargeTo.Text, @"[^0-9a-zA-Z]+", "");
                    sSQL.AppendLine(function.GenerateIdScript("caId"));

                    sSQL.AppendLine("SELECT caId");
                    sSQL.AppendLine("FROM CashAdvance");
                    sSQL.AppendLine("WHERE caId = @caId");

                    sSQL.AppendLine("");

                    sSQL.AppendLine("IF @@ROWCOUNT > 0");
                    sSQL.AppendLine("    BEGIN");
                    sSQL.AppendLine("        SELECT @errorMessage = 'CA ID already exist.'");
                    sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                    sSQL.AppendLine("        ROLLBACK TRANSACTION");
                    sSQL.AppendLine("        RETURN");
                    sSQL.AppendLine("    END");

                    decimal caAmount = 0;

                    if (isMultiple)
                    {
                        for (int i = 0; i < cboChargeTo.Items.Count; i++)
                        {
                            DataRowView x = (DataRowView)cboChargeTo.Items[i];

                            sSQL.AppendLine("SELECT @chargeToId = " + x["chargeToId"]);

                            caAmount = 0;

                            foreach (DataGridViewRow row in dgvList.Rows)
                            {
                                if (Convert.ToInt32(row.Cells[IX_GRID_CHARGE_TO_ID].Value) == Convert.ToInt32(x["chargeToId"]))
                                { caAmount += Convert.ToDecimal(row.Cells[IX_GRID_AMOUNT].Value); }
                            }

                            if (MODE == MODE_SUBMIT)
                            {
                                chargeToFormat = System.Text.RegularExpressions.Regex.Replace(x["chargeToName"].ToString(), @"[^0-9a-zA-Z]+", "");

                                sSQL.AppendLine("DECLARE @ca" + chargeToFormat + DateTime.Now.Year.ToString().Substring(2, 2) + "Id INT ");

                                sSQL.AppendLine(function.GenerateIdScript("ca" + chargeToFormat + DateTime.Now.Year.ToString().Substring(2, 2) + "Id"));

                                sSQL.AppendLine("");

                                sSQL.AppendLine("SELECT @caNumber =" + (chargeToFormat + DateTime.Now.Year.ToString().Substring(2, 2) + "-").sQuote() + " + FORMAT(@ca" + chargeToFormat + DateTime.Now.Year.ToString().Substring(2, 2) + "Id, '0000')");
                                sSQL.AppendLine("");

                                sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_FOR_APPROVAL);
                            }
                            else
                            {
                                sSQL.AppendLine(" SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_SAVED);
                                sSQL.AppendLine(" SELECT @caNumber = ''");
                            }

                            sSQL.AppendLine("");

                            sSQL.AppendLine("INSERT INTO CashAdvance(caId, chargeToId, requestDate, dateNeeded, businessPurposeId, bpOthers, employeeId, ");
                            sSQL.AppendLine("costCenterId, storeId, modeOfPaymentId, caNumber, caAmount, cashAdvanceStatusId, remarks, ");
                            sSQL.AppendLine("    createBy, createDate, updateBy, updateDate)");
                            sSQL.AppendLine("VALUES(@caId, @chargeToId, @requestDate, @dateNeeded, @businessPurposeId, @bpOthers, @employeeId, ");
                            sSQL.AppendLine("@costCenterId, @storeId, @modeOfPaymentId, @caNumber, " + caAmount + ", @cashAdvanceStatusId, @remarks, ");
                            sSQL.AppendLine(strUserName.sQuote() + ", GETDATE(), " + strUserName.sQuote() + ", GETDATE())");

                            sSQL.AppendLine("");
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgvList.Rows)
                        {
                            if (Convert.ToInt32(row.Cells[IX_GRID_CHARGE_TO_ID].Value) == Convert.ToInt32(cboChargeTo.SelectedValue))
                            { caAmount += Convert.ToDecimal(row.Cells[IX_GRID_AMOUNT].Value); }
                        }

                        sSQL.AppendLine("SELECT @chargeToId = " + cboChargeTo.SelectedValue);
                        sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_SAVED);

                        if (MODE == MODE_SUBMIT)
                        {
                            sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_FOR_APPROVAL);
                            sSQL.AppendLine("DECLARE @ca" + chargeToFormat + "Id INT ");

                            sSQL.AppendLine(function.GenerateIdScript("ca" + chargeToFormat + "Id"));

                            sSQL.AppendLine("");

                            sSQL.AppendLine("SELECT @caNumber =" + (chargeToFormat + DateTime.Now.Year.ToString().Substring(2, 2) + "-").sQuote() + " + FORMAT(@ca" + chargeToFormat + "Id, '0000')");
                            sSQL.AppendLine("");
                        }

                        sSQL.AppendLine("");

                        sSQL.AppendLine("INSERT INTO CashAdvance(caId, chargeToId, requestDate, dateNeeded, businessPurposeId, bpOthers, employeeId, ");
                        sSQL.AppendLine("costCenterId, storeId, modeOfPaymentId, caNumber, caAmount, cashAdvanceStatusId, remarks, ");
                        sSQL.AppendLine("   createBy, createDate, updateBy, updateDate)");
                        sSQL.AppendLine("VALUES(@caId, @chargeToId, @requestDate, @dateNeeded, @businessPurposeId, @bpOthers, @employeeId, ");
                        sSQL.AppendLine("@costCenterId, @storeId, @modeOfPaymentId, @caNumber, " + caAmount + ", @cashAdvanceStatusId, @remarks, ");
                        sSQL.AppendLine(strUserName.sQuote() + ", GETDATE(), " + strUserName.sQuote() + ", GETDATE())");

                        sSQL.AppendLine("");
                    }
                }
                else // if existing record
                {
                    sSQL.AppendLine("SELECT @caId = " + mvCAId);

                    if (MODE == MODE_APPROVE)
                    { sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_APPROVED); }    
                    else if (MODE == MODE_RETURN)
                    { sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_SAVED); }

                    decimal caAmount = 0;

                    //foreach (DataGridViewRow row in dgvList.Rows)
                    //{
                    //    if (Convert.ToInt32(row.Cells[IX_GRID_CHARGE_TO_ID].Value) == Convert.ToInt32(cboChargeTo.SelectedValue) && Convert.ToBoolean(row.Cells[IX_GRID_IS_ACTIVE].Value) == true)
                    //    { caAmount += Convert.ToDecimal(row.Cells[IX_GRID_AMOUNT].Value); }
                    //}

                    //sSQL.AppendLine("SELECT @caAmount = " + caAmount);

                    // UPDATE RECORD 
                    if (MODE != MODE_SAVE)
                    {         
                        switch (currentStatus)
                        {
                            case Declaration.CA_STATUS_ID_NEW:
                            case Declaration.CA_STATUS_ID_SAVED:
                                sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_FOR_APPROVAL);
                                break;
                            case Declaration.CA_STATUS_ID_FOR_APPROVAL:
                                sSQL.AppendLine("IF @headApprovedById <> -1");
                                sSQL.AppendLine("BEGIN");
                                if (MODE == MODE_RETURN)
                                {
                                    sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_SAVED);
                                }
                                else
                                {
                                    if (Convert.ToDecimal(txtTotalAmount.Text) > Declaration.AMOUNT_LIMIT && txtMgtApproved.Text.Trim() == "")
                                    {
                                        sSQL.AppendLine("    BEGIN");
                                        sSQL.AppendLine("        SELECT @errorMessage = 'Mgt Approved cannot be empty.'");
                                        sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                                        sSQL.AppendLine("        ROLLBACK TRANSACTION");
                                        sSQL.AppendLine("        RETURN");
                                        sSQL.AppendLine("    END");
                                    }

                                    sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_APPROVED);
                                    sSQL.AppendLine("UPDATE CashAdvance SET");
                                    sSQL.AppendLine("       headApprovedById = @headApprovedById");
                                    sSQL.AppendLine(",      headApprovedDate = @headApprovedDate");


                                    if (txtMgtApproved.Text.Trim() != "")
                                    {
                                        sSQL.AppendLine(",      mgtApprovedById = @mgtApprovedById");
                                        sSQL.AppendLine(",      mgtApprovedDate = @mgtApprovedDate");
                                    }
                                    sSQL.AppendLine("WHERE caId = @caId");
                                }
                                sSQL.AppendLine("END");
                                break;
                            case Declaration.CA_STATUS_ID_APPROVED:
                                if (MODE == MODE_RETURN)
                                {
                                    sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_FOR_APPROVAL);
                                    sSQL.AppendLine("UPDATE CashAdvance SET");
                                    sSQL.AppendLine("      headApprovedById = -1");
                                    sSQL.AppendLine(",     headApprovedDate = GETDATE()");
                                    sSQL.AppendLine(",     mgtApprovedById = -1");
                                    sSQL.AppendLine(",     mgtApprovedDate = GETDATE()");
                                    sSQL.AppendLine("WHERE caId = @caId");
                                }
                                else
                                {
                                    if (txtDocsReceivedBy.Text.Trim() != "")
                                    {
                                        sSQL.AppendLine("IF @receivedByAcctId <> -1 ");
                                        sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_FOR_AUDIT);
                                        sSQL.AppendLine("BEGIN");
                                        sSQL.AppendLine("UPDATE CashAdvance SET");
                                        sSQL.AppendLine("   receivedByAcctId = @receivedByAcctId,");
                                        sSQL.AppendLine("   receivedByAcctDate = @receivedByAcctDate,");
                                        sSQL.AppendLine("   modeOfPaymentId = @modeOfPaymentId");
                                        sSQL.AppendLine("WHERE caId = @caId");
                                        sSQL.AppendLine("END");
                                    }
                                }
                                break;
                            case Declaration.CA_STATUS_ID_FOR_AUDIT:
                                if (MODE == MODE_RETURN)
                                {
                                    sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_APPROVED);
                                    sSQL.AppendLine("UPDATE CashAdvance SET");
                                    sSQL.AppendLine(",      receivedByAcctId = -1");
                                    sSQL.AppendLine(",      receivedByAcctDate = GETDATE()");
                                    sSQL.AppendLine("WHERE caId = @caId");
                                }
                                else
                                {
                                    if (txtAuditedBy.Text.Trim() != "")
                                    {
                                        sSQL.AppendLine("IF @auditedById <> -1 ");
                                        sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_FOR_RELEASING);
                                        sSQL.AppendLine("BEGIN");
                                        sSQL.AppendLine("UPDATE CashAdvance");
                                        sSQL.AppendLine("SET auditedById = @auditedById");
                                        sSQL.AppendLine(",   auditedDate = @auditedDate");
                                        sSQL.AppendLine("WHERE caId = @caId");
                                        sSQL.AppendLine("END");
                                    }
                                }
                                break;
                            case Declaration.CA_STATUS_ID_FOR_RELEASING:
                                if (MODE == MODE_RETURN)
                                {
                                    sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_FOR_AUDIT);
                                    sSQL.AppendLine("UPDATE CashAdvance SET");
                                    sSQL.AppendLine("      auditedById = -1");
                                    sSQL.AppendLine(",     auditedByDate = GETDATE()");
                                    sSQL.AppendLine("WHERE caId = @caId");
                                }
                                else
                                {
                                    if (txtUploadedBy.Text.Trim() != "")
                                    {
                                        sSQL.AppendLine("IF @uploadedById <> -1");
                                        sSQL.AppendLine("BEGIN");
                                        sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_UPLOADED);
                                        sSQL.AppendLine(" ");
                                        sSQL.AppendLine("UPDATE CashAdvance");
                                        sSQL.AppendLine("SET uploadedById = @uploadedById");
                                        sSQL.AppendLine(",   uploadedDate = @uploadedDate");
                                        sSQL.AppendLine("WHERE caId = @caId");
                                        sSQL.AppendLine("END");
                                    }

                                    if (txtReleasedBy.Text.Trim() != "")
                                    {
                                        sSQL.AppendLine("IF @releasedByAcctId <> -1");
                                        sSQL.AppendLine("BEGIN");
                                        sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_RELEASED);
                                        sSQL.AppendLine(" ");
                                        sSQL.AppendLine("UPDATE CashAdvance");
                                        sSQL.AppendLine("SET releasedByAcctId = @releasedByAcctId");
                                        sSQL.AppendLine(",   releasedByAcctDate = @releasedByAcctDate");
                                        sSQL.AppendLine("WHERE caId = @caId");
                                        sSQL.AppendLine("END");

                                        sSQL.AppendLine("");
                                    }
                                }
                                break;
                            case Declaration.CA_STATUS_ID_UPLOADED:
                                if (MODE == MODE_RETURN)
                                {
                                    sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_FOR_AUDIT);
                                    sSQL.AppendLine("UPDATE CashAdvance SET");
                                    sSQL.AppendLine("      auditedById = -1");
                                    sSQL.AppendLine(",     auditedByDate = GETDATE()");
                                    sSQL.AppendLine("WHERE caId = @caId");
                                }
                                else
                                {
                                    if (txtReleasedBy.Text.Trim() != "")
                                    {
                                        sSQL.AppendLine("IF @releasedByAcctId <> -1");
                                        sSQL.AppendLine("BEGIN");
                                        sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_RELEASED);
                                        sSQL.AppendLine("UPDATE CashAdvance");
                                        sSQL.AppendLine("SET releasedByAcctId = @releasedByAcctId");
                                        sSQL.AppendLine(",   releasedByAcctDate = @releasedByAcctDate");
                                        sSQL.AppendLine("WHERE caId = @caId");
                                        sSQL.AppendLine("END");

                                        sSQL.AppendLine("");
                                    }
                                }
                                break;
                            case Declaration.CA_STATUS_ID_LIQUIDATED:
                            case Declaration.CA_STATUS_ID_RELEASED:
                                if (MODE == MODE_MODIFY)
                                {
                                    sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_FOR_AUDIT);
                                    sSQL.AppendLine("UPDATE CashAdvance SET");
                                    sSQL.AppendLine("   updateBy = " + strUserName.sQuote() + ",");
                                    sSQL.AppendLine("   updateDate = GETDATE()");
                                    sSQL.AppendLine("WHERE caId = @caId");
                                }
                                break;
                        }

                        if (MODE == MODE_REJECT)
                        { sSQL.AppendLine("SELECT @cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_REJECTED); }

                        sSQL.AppendLine("UPDATE CashAdvance");
                        sSQL.AppendLine("SET cashAdvanceStatusId = @cashAdvanceStatusId, ");
                        sSQL.AppendLine("   updateBy = " + strUserName.sQuote() + ",");
                        sSQL.AppendLine("   updateDate = GETDATE()");
                        sSQL.AppendLine("WHERE caId = @caId");
                    }


                    for (int i = 0; i < cboChargeTo.Items.Count; i++)
                    {
                        DataRowView x = (DataRowView)cboChargeTo.Items[i];

                        sSQL.AppendLine("SELECT @chargeToId = " + x["chargeToId"]);

                        if (MODE == MODE_SUBMIT && currentStatus == Declaration.CA_STATUS_ID_SAVED)
                        {
                            chargeToFormat = System.Text.RegularExpressions.Regex.Replace(x["chargeToName"].ToString(), @"[^0-9a-zA-Z]+", "");

                            sSQL.AppendLine("SELECT @caNumber = caNumber");
                            sSQL.AppendLine("FROM CashAdvance");
                            sSQL.AppendLine("WHERE caId = @caId");
                            sSQL.AppendLine("   AND chargeToId = @chargeToId");

                            sSQL.AppendLine("IF @caNumber = ''");

                            sSQL.AppendLine("BEGIN");

                            sSQL.AppendLine("DECLARE @ca" + chargeToFormat + "Id INT ");

                            sSQL.AppendLine(function.GenerateIdScript("ca" + chargeToFormat + "Id"));

                            sSQL.AppendLine("");

                            sSQL.AppendLine("SELECT @caNumber = " + (chargeToFormat + DateTime.Now.Year.ToString().Substring(2, 2) + "-").sQuote() + " + FORMAT(@ca" + chargeToFormat + "Id, '000')");
                            sSQL.AppendLine("");

                            sSQL.AppendLine("UPDATE CashAdvance");
                            sSQL.AppendLine("SET");
                            sSQL.AppendLine("   caNumber = @caNumber");
                            sSQL.AppendLine("WHERE caId = @caId");
                            sSQL.AppendLine("   AND chargeToId = @chargeToId");

                            sSQL.AppendLine("END");
                        }

                        caAmount = 0;

                        foreach (DataGridViewRow row in dgvList.Rows)
                        {
                            if (Convert.ToInt32(row.Cells[IX_GRID_CHARGE_TO_ID].Value) == Convert.ToInt32(x["chargeToId"]))
                            {
                                caAmount += Convert.ToDecimal(row.Cells[IX_GRID_AMOUNT].Value);
                            }
                        }

                        sSQL.AppendLine("UPDATE CashAdvance");
                        sSQL.AppendLine("SET");
                        sSQL.AppendLine("   caAmount = " + caAmount);
                        sSQL.AppendLine("WHERE caId = @caId");
                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                    }

                    sSQL.AppendLine("SELECT @chargeToId = " + cboChargeTo.SelectedValue);

                    sSQL.AppendLine("UPDATE CashAdvance");
                    sSQL.AppendLine("SET");
                    sSQL.AppendLine("   dateNeeded = @dateNeeded,");
                    sSQL.AppendLine("   requestDate = @requestDate,");
                    sSQL.AppendLine("   modeOfPaymentId = @modeOfPaymentId,");
                    sSQL.AppendLine("   businessPurposeId = @businessPurposeId,");
                    sSQL.AppendLine("   bpOthers = @bpOthers,");
                    sSQL.AppendLine("   costCenterId = @costCenterId,");
                    sSQL.AppendLine("   storeId = @storeId,");
                    sSQL.AppendLine("   remarks = @remarks,");
                    sSQL.AppendLine("   updateBy = " + strUserName.sQuote() + ",");
                    sSQL.AppendLine("   updateDate = GETDATE()");
                    sSQL.AppendLine("WHERE caId = @caId");
                    sSQL.AppendLine("   AND chargeToId = @chargeToId");
                } // END OF UPDATE OF EXISTING RECORD


                // START INSERT GRID DETAIL 

                int lineNumber = 0;
                decimal amount;

                sSQL.AppendLine("DECLARE @lineNumber INT");
                sSQL.AppendLine("DECLARE @particulars VARCHAR(250)");
                sSQL.AppendLine("DECLARE @isActive BIT");
                sSQL.AppendLine("DECLARE @amount DECIMAL(18, 2)");

                sSQL.AppendLine("DELETE FROM CashAdvanceDetail WHERE caId = @caId");

                foreach (DataGridViewRow row in dgvList.Rows)
                {
                    amount = decimal.Parse(row.Cells[IX_GRID_AMOUNT].Value.ToString(), System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                    lineNumber = lineNumber + 1;

                    sSQL.AppendLine("SELECT @lineNumber = " + lineNumber);
                    sSQL.AppendLine("SELECT @particulars = " + row.Cells[IX_GRID_PARTICULARS].Value.ToString().sQuote());
                    sSQL.AppendLine("SELECT @amount = " + amount);
                    sSQL.AppendLine("SELECT @isActive = " + Convert.ToInt32(row.Cells[IX_GRID_IS_ACTIVE].Value));
                    sSQL.AppendLine("SELECT @chargeToId = " + Convert.ToInt32(row.Cells[IX_GRID_CHARGE_TO_ID].Value));

                    sSQL.AppendLine("INSERT INTO CashAdvanceDetail(lineNumber, caId, chargeToId, particulars, amount, isActive)");
                    sSQL.AppendLine("VALUES(@lineNumber, @caId, @chargeToId, @particulars, @amount, @isActive)");

                    sSQL.AppendLine("");
                }

                // END INSERT GRID DETAIL

                sSQL.AppendLine(common.SaveActiviyLog("CA", "CURRENT STATUS : " + lblStatus.Text + " | MODE : " + modeCode, "@caNumber"));

                using (SQLDB sql = new SQLDB())
                { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pCaId); }

                mvCAId = Convert.ToInt32(pCaId.Value.ToString());
                mvSave = true;

                Form openfrm = Application.OpenForms["frmMain"];
                if (openfrm != null)
                {
                    frmMain frm = (frmMain)openfrm;
                    frm.CACountStatus();
                }

            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
            finally
            {
                FormatObjects();
                LoadDetail();
            }
        }

        private void ValidateInfo()
        {
            try
            {
                string modeOfPayment = cboModeOfPayment.Text;
                int currentStatus = Convert.ToInt32(lblStatus.Tag);

                if (cboDepartment.Text.Trim() == "")
                {
                    cboDepartment.Focus();
                    throw new Exception("Department is required.");
                }

                if (cboBusinessPurpose.Text.Trim() == "")
                {
                    cboBusinessPurpose.Focus();
                    throw new Exception("Business Purpose is required.");
                }

                if (cboStores.Text.Trim() == "")
                {
                    txtStore.Focus();
                    throw new Exception("Store is required.");
                }

                if (btnSaveMultiple.Visible)
                {
                    btnSaveMultiple.Focus();
                    throw new Exception("Please set Charge To first.");
                }

                if (currentStatus == Declaration.CA_STATUS_ID_APPROVED && cboModeOfPayment.Text == "")
                {
                    cboModeOfPayment.Focus();
                    throw new Exception("Mode of Payment required.");
                }

                if (dgvList.RowCount == 0)
                {
                    dgvList.Focus();
                    throw new Exception("Please add Cash Advance Details.");
                }

                if (lblOthers.BackColor == Declaration.reqBackColor && txtBusinessOthers.Text.Trim() == "")
                {
                    txtBusinessOthers.Focus();
                    throw new Exception("Other Details required.");
                }
            }
            catch (Exception ex)
            { throw new Exception (ex.Message); }
        }

        private void LoadComboChargeTo()
        {
            try
            {
                StringBuilder sSQL = new StringBuilder();

                sSQL.AppendLine("SELECT [chargeToId], [chargeToName] FROM ChargeTo");

                using (SQLDB sql = new SQLDB())
                {
                    comboChargeTo = sql.GetDT(sSQL.ToString());
                }

                cboChargeTo.DataSource = comboChargeTo;
                cboChargeTo.DisplayMember = "chargeToName";
                cboChargeTo.ValueMember = "chargeToId";

                //to set the first index as blank
                cboChargeTo.SelectedIndex = -1;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void LoadDetail()
        {
            DataTable detailDT = new DataTable();

            DataTable[] listTable = { mainDT, detailDT };

            mainDT.Rows.Clear();

            try
            {
                string sSQL = "proc_CashAdvanceDetail";

                SqlParameter pCAId = new SqlParameter("@caId", SqlDbType.Int);
                pCAId.Value = mvCAId;

                using (SQLDB sql = new SQLDB())
                { sql.GetDT(ref listTable, sSQL, CommandType.StoredProcedure, pCAId); }
                           
                dgvList.Rows.Clear();

                var strChargeToId = "";

                if (mainDT.Rows.Count > 1)
                { isMultiple = true; }

                for (int i = 0; i < mainDT.Rows.Count; i++)
                {
                    if (strChargeToId != "")
                    { strChargeToId = strChargeToId + ", " + mainDT.Rows[i]["chargeToId"].ToString(); }
                    else
                    { strChargeToId = mainDT.Rows[i]["chargeToId"].ToString(); }

                    cboChargeTo.DataSource = comboChargeTo.Select("chargeToId IN ( " + strChargeToId + ")").CopyToDataTable();
                }

                cboChargeTo.DataSource = comboChargeTo.Select("chargeToId IN ( " + strChargeToId + ")").CopyToDataTable();
                cboChargeTo.DisplayMember = "chargeToName";
                cboChargeTo.ValueMember = "chargeToId";
                if (mvChargeToId == -1)
                { cboChargeTo.SelectedIndex = 0; }
                else
                { cboChargeTo.SelectedValue = mvChargeToId; }

                if (cboChargeTo.Items.Count > 1)
                {
                    dgvList.Columns["chargeToName"].Visible = true;
                    dgvList.Columns["Description"].Width = 300;
                    txtParticulars.Width = 274;
                    chkPartChargeTo.Visible = true;
                    lblPartChargeTo.Visible = true;         
                    chkPartChargeTo.DataSource = comboChargeTo.Select("chargeToId IN ( " + strChargeToId + ")").CopyToDataTable();
                    chkPartChargeTo.DisplayMember = "chargeToName";
                    chkPartChargeTo.ValueMember = "chargeToId";
                }

                SelectChargeTo();

                foreach (DataRow dr in detailDT.Rows)
                {
                    dgvList.Rows.Add("");
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_PARTICULARS].Value = dr["particulars"].ToString();
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_CHARGE_TO_NAME].Value = dr["chargeToName"].ToString();
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_AMOUNT].Value = function.FormatDouble(dr["amount"].ToString());
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_IS_ACTIVE].Value = Convert.ToInt32(dr["isActive"]);
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_CHARGE_TO_ID].Value = dr["chargeToId"];
                }

                ComputeTotalAmount();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void SelectChargeTo()
        {
            if (mainDT.Rows.Count != 0)
            {
                DataTable filteredMainDT = mainDT.Select("chargeToId = " + cboChargeTo.SelectedValue).CopyToDataTable();

                lblStatus.Tag = filteredMainDT.Rows[0]["cashAdvanceStatusId"].ToString();
                lblStatus.Text = filteredMainDT.Rows[0]["caStatus"].ToString();
                txtCANumber.Text = filteredMainDT.Rows[0]["caNumber"].ToString();
                txtCAAmount.Text = function.FormatDouble(filteredMainDT.Rows[0]["caAmount"].ToString());
                dtpRequested.Text = filteredMainDT.Rows[0]["requestDate"].ToString();
                dtpDateNeeded.Text = filteredMainDT.Rows[0]["dateNeeded"].ToString();
                txtName.Tag = filteredMainDT.Rows[0]["employeeId"].ToString();
                txtName.Text = filteredMainDT.Rows[0]["employeeName"].ToString();

                txtBusinessOthers.Text = filteredMainDT.Rows[0]["bpOthers"].ToString();
                cboBusinessPurpose.SelectedValue = filteredMainDT.Rows[0]["businessPurposeId"].ToString();
                cboChargeTo.SelectedValue = filteredMainDT.Rows[0]["chargeToId"].ToString();
                cboDepartment.SelectedValue = filteredMainDT.Rows[0]["costCenterId"].ToString();
                cboStores.SelectedValue = filteredMainDT.Rows[0]["storeId"].ToString();
                cboModeOfPayment.Tag = filteredMainDT.Rows[0]["modeOfPaymentId"].ToString();
                cboModeOfPayment.Text = filteredMainDT.Rows[0]["modeOfPaymentCode"].ToString();

                txtHeadApproved.Tag = filteredMainDT.Rows[0]["headApprovedById"].ToString();
                txtHeadApproved.Text = filteredMainDT.Rows[0]["headApprovedByName"].ToString();
                txtMgtApproved.Tag = filteredMainDT.Rows[0]["mgtApprovedById"].ToString();
                txtMgtApproved.Text = filteredMainDT.Rows[0]["mgtApprovedByName"].ToString();                
                if (txtHeadApproved.Text != "")
                { dtpHeadApproved.Text = filteredMainDT.Rows[0]["headApprovedDate"].ToString(); }
                if (txtMgtApproved.Text != "")
                { dtpMgtApproved.Text = filteredMainDT.Rows[0]["mgtApprovedDate"].ToString(); }

                txtDocsReceivedBy.Tag = filteredMainDT.Rows[0]["receivedByAcctId"].ToString();
                txtDocsReceivedBy.Text = filteredMainDT.Rows[0]["receivedByAcct"].ToString();
                if (txtDocsReceivedBy.Text != "")
                { dtpDocsReceived.Text = filteredMainDT.Rows[0]["receivedByAcctDate"].ToString(); }

                txtAuditedBy.Tag = filteredMainDT.Rows[0]["auditedById"].ToString();
                txtAuditedBy.Text = filteredMainDT.Rows[0]["auditedBy"].ToString();
                if (txtAuditedBy.Text != "")
                { dtpAudited.Text = filteredMainDT.Rows[0]["auditedDate"].ToString(); }

                txtUploadedBy.Tag = filteredMainDT.Rows[0]["uploadedById"].ToString();
                txtUploadedBy.Text = filteredMainDT.Rows[0]["uploadedBy"].ToString();
                if (txtUploadedBy.Text != "")
                { dtpUploadedBy.Text = filteredMainDT.Rows[0]["uploadedDate"].ToString(); }

                txtReleasedBy.Tag = filteredMainDT.Rows[0]["releasedByAcctId"].ToString();
                txtReleasedBy.Text = filteredMainDT.Rows[0]["releasedBy"].ToString();
                if (txtReleasedBy.Text != "")
                { dtpCashReleasedBy.Text = filteredMainDT.Rows[0]["releasedDate"].ToString(); }

                txtRemarks.Text = filteredMainDT.Rows[0]["remarks"].ToString();
                txtFormNumber.Text = filteredMainDT.Rows[0]["formNumber"].ToString();  
            }
        }
        
        private void ToggleGeneralInfo(bool r)
        {
            cboDepartment.Enabled = r;
            cboBusinessPurpose.Enabled = r;
            txtBusinessOthers.ReadOnly = !r;
            txtStore.ReadOnly = !r;
            cboStores.Enabled = r;
            dtpDateNeeded.Enabled = r;

            lblDoubleClick.Visible = r;
            txtParticulars.ReadOnly = !r;
            txtAmount.ReadOnly = !r;

            btnAdd.Visible = r;
            btnDelete.Visible = r;      
        }

        private void DisableALL()
        {
            txtStore.Clear();

            ToggleGeneralInfo(false);
            
            dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = true;
            dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;

            btnAccept.Visible = false;
            btnDecline.Visible = false;
            btnSubmit.Visible = false;
            btnSave.Visible = false;
            btnReturn.Visible = false;
        }

        private void EnableControls(bool t)
        {
            btnSave.Visible = t;
            btnSubmit.Visible = t;
            btnAccept.Visible = t;
            btnDecline.Visible = t;
            btnReturn.Visible = t;

            cboModeOfPayment.Enabled = t;
            dtpDocsReceived.Enabled = t;
            dtpHeadApproved.Enabled = t;
            dtpMgtApproved.Enabled = t;
            dtpAudited.Enabled = t;
            dtpUploadedBy.Enabled = t;
            dtpCashReleasedBy.Enabled = t;

            btnSearchHeadApprover.Visible = t;
            btnSearchMgtApprover.Visible = t;
            btnSearchDocsReceived.Visible = t;
            btnAuditedBy.Visible = t;
            btnUploadedBy.Visible = t;
            btnCashReleasedBy.Visible = t;
        }

        private void FormatObjects()
        {
            int currentStatus = Convert.ToInt32(lblStatus.Tag);

            txtHeadApproved.BackColor = default(System.Drawing.Color);
            txtMgtApproved.BackColor = default(System.Drawing.Color);
            txtDocsReceivedBy.BackColor = default(System.Drawing.Color);
            txtAuditedBy.BackColor = default(System.Drawing.Color);
            txtUploadedBy.BackColor = default(System.Drawing.Color);
            txtReleasedBy.BackColor = default(System.Drawing.Color);
            
            lblModeOfPayment.BackColor = default(System.Drawing.Color);

            //btnSubmit.Location = new Point(657, 299);
            //btnDecline.Location = new Point(657, 299);
            EnableControls(false);

            switch (currentStatus)
            {
                case Declaration.CA_STATUS_ID_NEW:
                case Declaration.CA_STATUS_ID_SAVED:
                    if (Convert.ToInt32(txtName.Tag) == common.GetEmployeeId())
                    {
                        lblDepartment.BackColor = Declaration.reqBackColor;
                        lblBusiness.BackColor = Declaration.reqBackColor;
                        lblStore.BackColor = Declaration.reqBackColor;
                        lblChargeTo.BackColor = Declaration.reqBackColor;
                        cboModeOfPayment.Enabled = false;
                        btnPrint.Visible = false;
                        btnSubmit.Visible = true;
                        btnSave.Visible = true;

                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = false;
                    }
                    else
                    {
                        DisableALL();
                        btnPrint.Visible = false;
                    }
                    break;
                case Declaration.CA_STATUS_ID_FOR_APPROVAL:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_APPROVAL, GlobalSettings.ACCESS_WRITE))
                    {
                        btnDecline.Visible = true;
                        btnAccept.Visible = true;
                        cboModeOfPayment.Enabled = false;
                        btnReturn.Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;

                        btnSearchHeadApprover.Visible = true;
                        txtHeadApproved.Text = GlobalSettings.UserFullName;
                        txtHeadApproved.Tag = common.GetEmployeeId();
                        txtHeadApproved.BackColor = Declaration.reqBackColor;
                        dtpHeadApproved.Enabled = true;         

                        if (Convert.ToDecimal(txtTotalAmount.Text) > Declaration.AMOUNT_LIMIT
                            && (Declaration.USER_TYPE.Contains(Declaration.GROUP_ACCOUNTING)
                            || Declaration.USER_TYPE.Contains(Declaration.GROUP_TREASURY)))
                        {                           
                            btnSearchMgtApprover.Visible = true;
                            dtpMgtApproved.Enabled = true;
                            txtMgtApproved.BackColor = Declaration.reqBackColor;
                        }

                        if (Convert.ToDecimal(txtTotalAmount.Text) > Declaration.AMOUNT_LIMIT
                            && Declaration.USER_TYPE.Contains(Declaration.GROUP_ALL_DEPARTMENT))
                        {
                            btnSearchHeadApprover.Visible = true;
                            txtMgtApproved.Text = GlobalSettings.UserFullName;
                            txtMgtApproved.Tag = common.GetEmployeeId();
                            dtpMgtApproved.Enabled = true;
                            txtMgtApproved.BackColor = Declaration.reqBackColor;
                        }
                    }
                    break;
                case Declaration.CA_STATUS_ID_APPROVED:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_RECEIVING, GlobalSettings.ACCESS_WRITE))
                    {
                        btnReturn.Visible = true;
                        btnSave.Visible = true;
                        btnSubmit.Location = new Point(605, 299); 
                        btnSubmit.Visible = true;
                        btnDecline.Location = new Point(657, 299);
                        btnDecline.Visible = true;

                        lblModeOfPayment.BackColor = Declaration.reqBackColor;
                        cboModeOfPayment.Enabled = true;

                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = true;
         
                        txtDocsReceivedBy.Text = GlobalSettings.UserFullName;
                        txtDocsReceivedBy.Tag = common.GetEmployeeId();
                        txtDocsReceivedBy.BackColor = Declaration.reqBackColor;
                        dtpDocsReceived.Enabled = true;
                        btnSearchDocsReceived.Visible = true;             

                        toolTip.SetToolTip(btnSubmit, "Receive Docs");                        
                    }
                    else
                    { DisableALL(); }
                    break;
                case Declaration.CA_STATUS_ID_FOR_AUDIT:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_AUDIT, GlobalSettings.ACCESS_WRITE))
                    {
                        btnSave.Visible = true;
                        btnReturn.Visible = true;
                        txtAuditedBy.Text = GlobalSettings.UserFullName;
                        txtAuditedBy.Tag = common.GetEmployeeId();
                        txtAuditedBy.BackColor = Declaration.reqBackColor;
                        dtpAudited.Enabled = true;
                        btnAuditedBy.Visible = true;

                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;

                        cboModeOfPayment.Enabled = true;
                        btnPrint.Visible = true;
                        btnAccept.Visible = true;
                        btnDecline.Visible = true;
                        btnReturn.Visible = true;
                        ToggleGeneralInfo(true);
                    }
                    else
                    { DisableALL(); }
                    break;
                case Declaration.CA_STATUS_ID_FOR_RELEASING:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_RELEASING, GlobalSettings.ACCESS_WRITE))
                    {
                        btnSubmit.Visible = true;
                        btnReturn.Visible = true;
                        btnSave.Visible = true;
                        cboModeOfPayment.Enabled = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;
                        btnSubmit.Location = new Point(607, 299);
                        btnDecline.Visible = true;


                        if (common.ModeOfPaymentUploading(Convert.ToInt32(cboModeOfPayment.SelectedValue))) 
                        {
                            txtUploadedBy.Text = GlobalSettings.UserFullName;
                            txtUploadedBy.Tag = common.GetEmployeeId();
                            dtpUploadedBy.Enabled = true;
                            txtUploadedBy.BackColor = Declaration.reqBackColor;

                            btnUploadedBy.Visible = true;
                            toolTip.SetToolTip(btnSubmit, "Set as Uploaded");
                            toolTip.SetToolTip(btnReturn, "Return CA Status[Approved]");
                        }
                        else
                        {
                            txtReleasedBy.Text = GlobalSettings.UserFullName;
                            txtReleasedBy.Tag = common.GetEmployeeId();
                            dtpCashReleasedBy.Enabled = true;
                            txtReleasedBy.BackColor = Declaration.reqBackColor;

                            btnCashReleasedBy.Visible = true;
                            toolTip.SetToolTip(btnSubmit, "Set as Released");
                            toolTip.SetToolTip(btnReturn, "Return CA Status[Approved]");
                        }
                    }
                    else
                    { DisableALL(); }
                    break;
                case Declaration.CA_STATUS_ID_UPLOADED:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_RELEASING, GlobalSettings.ACCESS_WRITE))
                    {
                        btnSave.Visible = true;
                        btnDecline.Location = btnAccept.Location;
                        cboModeOfPayment.Enabled = true;
                        btnSubmit.Visible = true;
                        btnReturn.Visible = true;
                        btnDecline.Visible = true;

                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;
                        
                        txtReleasedBy.Text = GlobalSettings.UserFullName;
                        txtReleasedBy.Tag = common.GetEmployeeId();
                        dtpCashReleasedBy.Enabled = true;
                        txtReleasedBy.BackColor = Declaration.reqBackColor;

                        btnCashReleasedBy.Visible = true;
                        toolTip.SetToolTip(btnSubmit, "Set as Released");
                        toolTip.SetToolTip(btnReturn, "Return CA Status[Approved]");
                    }
                    else
                    { DisableALL(); }
                    break; 
                case Declaration.CA_STATUS_ID_LIQUIDATED:
                    if (function.HasAccess(Declaration.MOD_CODE_RELEASED, GlobalSettings.ACCESS_WRITE))
                    {
                        btnSave.Visible = true;
                        //btnDecline.Visible = true;

                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;                        
                    }
                    else
                    { DisableALL(); }
                    break;
                case Declaration.CA_STATUS_ID_RELEASED:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_RELEASING, GlobalSettings.ACCESS_WRITE))
                    {
                        btnSave.Visible = true;
                        //btnDecline.Visible = true;

                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;
                        btnSubmitEmail.Visible = true;
                    }
                    break;
                default:
                    DisableALL();
                    break;
            }

            toolStrip.Text = "";         


            if (btnAccept.Visible)
            { toolStrip.Text += "Accept[Ctrl+T] | "; }
            if (btnDecline.Visible)
            { toolStrip.Text += "Decline[Ctrl+D] | "; }
            if (btnSave.Visible)
            { toolStrip.Text += "Save[Ctrl+S] | "; }
            if (btnSubmit.Visible)
            { toolStrip.Text += "Submit[Ctrl+B] | "; }
            if (btnPrint.Visible)
            { toolStrip.Text += "Print[Ctrl+P] | "; }
            if (btnReturn.Visible)
            { toolStrip.Text += "Return[Ctrl+R] | "; }
            if (btnAdd.Visible)
            { toolStrip.Text += "Add Detail[Ctrl+A] | "; }

            pnlRequired.BackColor = Declaration.reqBackColor;
        }

        private string GetUserId()
        {
            System.Data.SqlClient.SqlParameter pUserId = new System.Data.SqlClient.SqlParameter("@userId", SqlDbType.Int);
            pUserId.Direction = ParameterDirection.Output;

            StringBuilder sSQL = new StringBuilder();

            sSQL.AppendLine("SELECT @userId = employeeId FROM SystemUser WHERE secCode = " + GlobalSettings.UserName.sQuote());

            using (SQLDB sql = new SQLDB())
            { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pUserId); }

            if (pUserId.Value.ToString() == "")
            { pUserId.Value = -1; }

            return pUserId.Value.ToString();
        }
       
        private void ComputeTotalAmount()
        {
            decimal caAmount = 0;
            decimal totalAmount = 0;
            
            int chargeToId = 0;

            for (int i = 0; i < dgvList.Rows.Count; ++i)
            {
                chargeToId = Convert.ToInt32(dgvList["chargeToId", i].Value);
                if (Convert.ToBoolean(dgvList["isActive", i].Value) == true && Convert.ToInt32(cboChargeTo.SelectedValue) == chargeToId)
                { caAmount += Convert.ToDecimal(dgvList["Amount", i].Value); }
            }

            for (int i = 0; i < dgvList.Rows.Count; ++i)
            {
                if (Convert.ToBoolean(dgvList["isActive", i].Value) == true)
                { totalAmount += Convert.ToDecimal(dgvList["Amount", i].Value); }
            }

            txtCAAmount.Text = function.FormatDouble(caAmount.ToString());
            txtTotalAmount.Text = function.FormatDouble(totalAmount.ToString());

            if (totalAmount > Declaration.AMOUNT_LIMIT)
            {
                btnSearchMgtApprover.Visible = true;
                dtpMgtApproved.Enabled = true;
                txtMgtApproved.BackColor = Declaration.reqBackColor;
            }
            else
            {
                txtMgtApproved.BackColor = default(System.Drawing.Color);
                btnSearchMgtApprover.Visible = false;
                dtpMgtApproved.Enabled = false;
            }
        }

        private void frmCashAdvanceDetail_Load(object sender, EventArgs e)
        {
            common.LoadComboBusinessPurpose(ref cboBusinessPurpose);
            common.LoadComboStore(ref cboStores, ref comboStores);
            common.LoadComboModeOfPayment(ref cboModeOfPayment);
            common.LoadComboDepartment(ref cboDepartment);
            LoadComboChargeTo();
   
            txtName.Text = GlobalSettings.UserFullName;
            txtName.Tag = GetUserId();
            
            if (cboDepartment.SelectedValue == null)
            { cboDepartment.SelectedValue = common.GetDepartmentId(); }
            if (mvCAId != -1)
            {
                LoadDetail();
            }
            btnSubmit.Visible = true;
            FormatObjects();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {         
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_CASH_ADVANCE, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }
                
                ValidateInfo();
    
             
                frmSearchApprover frm = new frmSearchApprover();

                if (Convert.ToInt32(lblStatus.Tag) == Declaration.CA_STATUS_ID_SAVED
                            || Convert.ToInt32(lblStatus.Tag) == Declaration.CA_STATUS_ID_NEW)
                {
                    DialogResult strInformApprover = function.MsgBoxQuestion(this.Text, "Inform your approver thru email?");

                    if (strInformApprover == DialogResult.Yes)
                    {
                        //if (Convert.ToDecimal(txtTotalAmount.Text) > Declaration.AMOUNT_LIMIT)
                        //{
                        //    frm.LUType = "ALL";
                        //}

                        frm.ShowDialog();

                        if (frm.DialogResult != DialogResult.OK)
                        {
                            throw new Exception("Please select a approver.");
                        }
                    }
                }
                else
                {
                    DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to submit the changes? ");

                    if (strAnswer == DialogResult.No)
                    { return; }
                }

                SaveInfo(MODE_SUBMIT);

                LoadDetail();

                if(Convert.ToInt32(lblStatus.Tag) == Declaration.CA_STATUS_ID_FOR_APPROVAL)
                {                       
                    if (Convert.ToInt32(lblStatus.Tag) == Declaration.CA_STATUS_ID_FOR_APPROVAL && frm.LUEmail != "")
                    {
                        function.MsgBoxInfo(this.Text, "Record submission was successful.\n\rSending an email notification to the approver.\n\rPlease click OK and wait.");

                        this.Cursor = Cursors.WaitCursor;

                        StringBuilder emailMsg = new StringBuilder();
                        emailMsg.AppendLine("<div style=\"font-family:Tahoma, Verdana, sans-serif;font-weight:bold;\">"); 
                        emailMsg.AppendLine("<h2 style=\"color:black;\">Cash Advance Approval</h2></td>");           
                        emailMsg.AppendLine("<h4 style=\"color:black;\">For your approval please:</h4>");                               
                        emailMsg.AppendLine("<h3 style=\"color:black;\">Header</h3>"); 

                        emailMsg.AppendLine("<table style=\"color:black;\">");           
                             
                        emailMsg.AppendLine("<tr>");    
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;width:120px\">CA #:</td>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">");

                            if (cboChargeTo.Items.Count > 1)
                            {
                                foreach (DataRowView row in cboChargeTo.Items)
                                {
                                    emailMsg.AppendLine(row.Row.ItemArray[1]
                                        + txtCANumber.Text.Split('-')[0].ToString().Substring(txtCANumber.Text.Split('-')[0].ToString().Length - 2, 2)
                                            + "-" + txtCANumber.Text.Split('-')[1] + ";");
                                }

                            }
                            else
                            {
                                emailMsg.AppendLine(txtCANumber.Text);
                            }

                        emailMsg.AppendLine("</td>");
                        emailMsg.AppendLine("</tr>");   
                        emailMsg.AppendLine("<tr>");    
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">Business Purpose:</td>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">");    
                        emailMsg.AppendLine(cboBusinessPurpose.Text);
                        emailMsg.AppendLine("</td>");
                        emailMsg.AppendLine("</tr>");
                             
                       if (txtBusinessOthers.Text != "")
                        {
                            emailMsg.AppendLine("<tr>");
                            emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">Other Details:</td>");
                            emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">");
                            emailMsg.AppendLine(txtBusinessOthers.Text);
                            emailMsg.AppendLine("</td>");
                            emailMsg.AppendLine("</tr>");
                        }

                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">Requested By:</td>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">");
                        emailMsg.AppendLine(txtName.Text);
                        emailMsg.AppendLine("</td>");
                        emailMsg.AppendLine("</tr>");      
                            
                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">Total CA Amount:</td>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">");
                        emailMsg.AppendLine(txtTotalAmount.Text);
                        emailMsg.AppendLine("</td>");
                        emailMsg.AppendLine("</tr>");             
                             
                        emailMsg.AppendLine("</table>"); 

                        emailMsg.AppendLine("<table style=\"color:black;font-family:Tahoma, Verdana, sans-serif;\">");
                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td><h3>Details</h3></td>"); 
                        emailMsg.AppendLine("</tr>");
                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<th style=\"border:1px solid black;padding:5px;margin:0;width:80px;\">");
                        emailMsg.AppendLine("Charge To");
                        emailMsg.AppendLine("</th>");
                        emailMsg.AppendLine("<th style=\"border:1px solid black;padding:5px;margin:0;\">");
                        emailMsg.AppendLine("Particulars");
                        emailMsg.AppendLine("</th>");
                        emailMsg.AppendLine("<th style=\"border:1px solid black;padding:5px;margin:0;\">");
                        emailMsg.AppendLine("Amount");
                        emailMsg.AppendLine("</th>");
                        emailMsg.AppendLine("</tr>");

                        foreach (DataGridViewRow row in dgvList.Rows)
                        {
                            emailMsg.AppendLine("<tr>");
                            emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;width:80px;\">");
                            emailMsg.AppendLine(row.Cells[IX_GRID_CHARGE_TO_NAME].Value.ToString());
                            emailMsg.AppendLine("</td>");
                            emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">");
                            emailMsg.AppendLine(row.Cells[IX_GRID_PARTICULARS].Value.ToString());
                            emailMsg.AppendLine("</td>");
                            emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">");
                            emailMsg.AppendLine(row.Cells[IX_GRID_AMOUNT].Value.ToString());
                            emailMsg.AppendLine("</td>");
                            emailMsg.AppendLine("</tr>");
                        }
                        emailMsg.AppendLine("</table>"); 
                        emailMsg.AppendLine("<table>"); 
                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td style=\"color:black;font-size:12px;font-weight:bold\">To approve the CA please visit the link below:</td>");
                        emailMsg.AppendLine("</tr>");
                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td>");
                        emailMsg.AppendLine("<a style=\"color:green;font-size:24px;text-decoration:none\"");
                        emailMsg.AppendLine("href =\"http://rgmcgroup.com:7171/cashadvance/" + mvCAId + "/" + mvChargeToId + "\">");
                        emailMsg.AppendLine("Approve Cash Advance</a>");
                        emailMsg.AppendLine("</td>");
                        emailMsg.AppendLine("</tr>"); 

                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td><h4 style=\"color:black;\">Thank you!</h4></td>"); 
                        emailMsg.AppendLine("</tr>"); 

                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td><h6 style=\"color:black;\">Please do not reply. System-generated email notification only.<br />");
                        emailMsg.AppendLine("For your concerns please contact the Treasury Department.</h6></td>"); 
                        emailMsg.AppendLine("</tr>"); 
                        emailMsg.AppendLine("</table>"); 
                        emailMsg.AppendLine("</div>"); 
           

                        common.SendEmail("Travel and Expense System - Cash Advance Approval", emailMsg.ToString(), frm.LUEmail);
                    }
                }
              
                SubmitReceivedConfirmation();

                refresh = System.Windows.Forms.DialogResult.OK;
                btnPrint.Visible = true;

                this.Cursor = Cursors.Default;

                FormatObjects();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }
        private void SubmitReceivedConfirmation() {

            if (Convert.ToInt32(lblStatus.Tag) == Declaration.CA_STATUS_ID_RELEASED)
            {
                DialogResult strEmail = function.MsgBoxQuestion(this.Text, "Inform Requester to confirm received thru automatically generated email?");

                if (strEmail == DialogResult.Yes)
                {
                    int requesterId = Convert.ToInt32(txtName.Tag);
                    string toEmail = ""; //common.GetEmail(requesterId);

                    //if (toEmail == "")
                    //{
                    frmConfirmReceived frm = new frmConfirmReceived();

                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        toEmail = frm.LUEmail;
                    }
                    //}

                    if (toEmail == "")
                    {
                        function.MsgBoxInfo(this.Text, "Please input email before proceeding. Sending canceled.");
                        return;
                    }

                    this.Cursor = Cursors.WaitCursor;
                    StringBuilder emailMsg = new StringBuilder();


                    emailMsg.AppendLine("<p>Please visit the link below for confirmation that you have Received your cash reimbursement:</p>");
                    emailMsg.AppendLine("<p><font size=\"5\"><a href=\"http://rgmcgroup.com:7171/cashadvance/receive/" + mvCAId + "/" + requesterId + "\"><b>Confirm Received</b></a></font></p>");
                    emailMsg.AppendLine("<p>Thank you!</p>");

                    emailMsg.AppendLine("<p><b>CA Received Confirmation.</b></p>");
                    emailMsg.AppendLine("<p><b>CA #:<br />&emsp;");
                    if (cboChargeTo.Items.Count > 1)
                    {
                        foreach (DataRowView row in cboChargeTo.Items)
                        {
                            emailMsg.AppendLine(row.Row.ItemArray[1]
                                + txtCANumber.Text.Split('-')[0].ToString().Substring(txtCANumber.Text.Split('-')[0].ToString().Length - 2, 2)
                                    + "-" + txtCANumber.Text.Split('-')[1] + ";");
                        }

                    }
                    else
                    {
                        emailMsg.AppendLine(txtCANumber.Text);
                    }
                    emailMsg.AppendLine("</b></p>");
                    emailMsg.AppendLine("<p><b>Released By:<br />&emsp;");
                    emailMsg.AppendLine(txtReleasedBy.Text);
                    emailMsg.AppendLine("</b></p>");
                    emailMsg.AppendLine("<p><b>Released Date:<br />&emsp;");
                    emailMsg.AppendLine(dtpCashReleasedBy.Text);
                    emailMsg.AppendLine("</b></p>");
                    emailMsg.AppendLine("<p><b>Total Expense:<br />&emsp;PHP");
                    emailMsg.AppendLine(txtCAAmount.Text);
                    emailMsg.AppendLine("</b></p>");

                    emailMsg.AppendLine("<font size=\"-3\"><p>Please do not reply. System-generated email notification only.<br /></font></p>");

                    common.SendEmail("CA Received Confirmation", emailMsg.ToString(), toEmail);

                    StringBuilder sSQL = new StringBuilder();


                    sSQL.AppendLine("DECLARE @employeeId INT = " + txtName.Tag);
                    sSQL.AppendLine("DECLARE @email VARCHAR(50) = " + toEmail.sQuote());

                    sSQL.AppendLine("SELECT @employeeId = employeeId");
                    sSQL.AppendLine("FROM SystemUser");
                    sSQL.AppendLine("WHERE email = @email");

                    sSQL.AppendLine("IF @@ROWCOUNT = 0");
                    sSQL.AppendLine("BEGIN");
                    sSQL.AppendLine("UPDATE SystemUser SET");
                    sSQL.AppendLine(" email = @email");
                    sSQL.AppendLine("FROM SystemUser");
                    sSQL.AppendLine("WHERE employeeId = @employeeId");
                    sSQL.AppendLine("END");

                    using (SQLDB sql = new SQLDB())
                    { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text); }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmCashAdvanceDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (refresh == System.Windows.Forms.DialogResult.OK)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to exit? All changes will not be saved.");

                if (strAnswer == DialogResult.No)
                { e.Cancel = true; }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtParticulars.Text.Trim() == "")
                {
                    txtParticulars.Focus();
                    throw new Exception("Please indicate Particulars.");
                }

                if (txtAmount.Text.Trim() == "")
                {
                    txtAmount.Focus();
                    throw new Exception("Please incdicate Amount");
                }

                if (function.IsDouble(txtAmount.Text) == false)
                {
                    throw new Exception("Invalid Amount.");
                }

                if (cboChargeTo.SelectedIndex == -1)
                {
                    throw new Exception("Please select a Charge To first.");
                }

                decimal amount = Convert.ToDecimal(txtAmount.Text);
                
                if (lastIndex == -1)
                {
                    if (isMultiple)
                    {
                        foreach (DataRowView chk in chkPartChargeTo.CheckedItems)
                        {
                            var index = dgvList.Rows.Add();
                            dgvList.Rows[index].Cells[IX_GRID_PARTICULARS].Value = txtParticulars.Text.Trim();
                            dgvList.Rows[index].Cells[IX_GRID_CHARGE_TO_NAME].Value = chk.Row["chargeToName"];
                            dgvList.Rows[index].Cells[IX_GRID_AMOUNT].Value = function.FormatDouble((amount / chkPartChargeTo.CheckedItems.Count).ToString());
                            dgvList.Rows[index].Cells[IX_GRID_IS_ACTIVE].Value = true;
                            dgvList.Rows[index].Cells[IX_GRID_CHARGE_TO_ID].Value = chk.Row["chargeToId"];
                        }
                    }
                    else
                    {
                        var index = dgvList.Rows.Add();
                        dgvList.Rows[index].Cells[IX_GRID_PARTICULARS].Value = txtParticulars.Text;
                        dgvList.Rows[index].Cells[IX_GRID_CHARGE_TO_NAME].Value = cboChargeTo.Text;
                        dgvList.Rows[index].Cells[IX_GRID_AMOUNT].Value = function.FormatDouble(amount.ToString());
                        dgvList.Rows[index].Cells[IX_GRID_IS_ACTIVE].Value = true;
                        dgvList.Rows[index].Cells[IX_GRID_CHARGE_TO_ID].Value = cboChargeTo.SelectedValue;
                    }
                }
                else
                {
                    dgvList.Rows[lastIndex].Cells[IX_GRID_PARTICULARS].Value = txtParticulars.Text;
                    dgvList.Rows[lastIndex].Cells[IX_GRID_CHARGE_TO_NAME].Value = cboChargeTo.Text;
                    dgvList.Rows[lastIndex].Cells[IX_GRID_AMOUNT].Value = function.FormatDouble(amount.ToString());
                    dgvList.Rows[lastIndex].Cells[IX_GRID_IS_ACTIVE].Value = true;
                    dgvList.Rows[lastIndex].Cells[IX_GRID_CHARGE_TO_ID].Value = cboChargeTo.SelectedValue;

                    lastIndex = -1;
                }

                if (isMultiple)
                {              
                    chkPartChargeTo.Visible = true;
                    txtPartChange.Visible = false;
                }

                txtParticulars.Text = "";
                txtAmount.Text = "";

                ComputeTotalAmount();

            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
            }
       }
               
        private void txtParticulars_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != "")
            {
                txt.BackColor = default(System.Drawing.Color);
            }
            else
            {
                { txt.BackColor = Declaration.reqBackColor; }
            }
        }             
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                dgvList.Rows.Remove(dgvList.SelectedRows[0]);
            }

            ComputeTotalAmount();
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.SelectedRows.Count == 0)
                { return; }

                lastIndex = dgvList.SelectedRows[0].Index;
                       
                txtParticulars.Text = dgvList.SelectedRows[0].Cells[IX_GRID_PARTICULARS].Value.ToString();
                
                txtAmount.Text = dgvList.SelectedRows[0].Cells[IX_GRID_AMOUNT].Value.ToString();

                cboChargeTo.SelectedValue = dgvList.SelectedRows[0].Cells[IX_GRID_CHARGE_TO_ID].Value;
                
                if (isMultiple)
                {
                    chkPartChargeTo.Visible = false;
                    txtPartChange.Visible = true;
                    txtPartChange.Text = cboChargeTo.Text;
                }
            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
            }
        }

        private void TextBoxValidation_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != "")
            {
                txt.BackColor = default(System.Drawing.Color);
            }
            else
            {
                { txt.BackColor = Declaration.reqBackColor; }
            }
        }

        private void ComboBoxValidation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            Label lbl = null;

            switch (cbo.Name)
            {
                case "cboDepartment":
                    lbl = lblDepartment;
                    break;
                case "cboBusinessPurpose":
                    lbl = lblBusiness;
                    break;
                case "cboModeOfPayment":
                    lbl = lblModeOfPayment;
                    break;
                case "cboChargeTo":
                    lbl = lblChargeTo;
                    break;
                case "cboStores":
                    lbl = lblStore;
                    break;
            }

            if (cbo.Text != "")
            { lbl.BackColor = default(System.Drawing.Color); }
            else
            { lbl.BackColor = Declaration.reqBackColor; }

            if (cbo.Name == "cboBusinessPurpose")
            {
                if (Convert.ToString(cbo.SelectedValue) == "0")
                { lblOthers.BackColor = Declaration.reqBackColor; }
                else
                {
                    lblOthers.BackColor = default(System.Drawing.Color);
                    lbl.BackColor = default(System.Drawing.Color);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_CASH_ADVANCE, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }

                ValidateInfo();

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to save the changes you've made?");

                if (strAnswer == DialogResult.No)
                { return; }

                SaveInfo(MODE_SAVE);

                function.MsgBoxInfo(this.Text, "Saving of record was successful. You can edit this form later.");

                LoadDetail();

                //ClearInfo();
                refresh = System.Windows.Forms.DialogResult.OK;

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable rptMain = new DataTable();
            DataTable rptDetail = new DataTable();

            DataTable[] listTable = { rptMain, rptDetail };

            string sSQL = "proc_RPT04CashAdvance";

            try
            {
                Cursor = Cursors.WaitCursor;

                System.Data.SqlClient.SqlParameter pCAId = new System.Data.SqlClient.SqlParameter("@caId", SqlDbType.Int);
                pCAId.Value = mvCAId;
                
                System.Data.SqlClient.SqlParameter pChargeToId = new System.Data.SqlClient.SqlParameter("@chargeToId", SqlDbType.Int);
                pChargeToId.Value = cboChargeTo.SelectedValue;

                using (SQLDB sql = new SQLDB())
                { sql.GetDT(ref listTable, sSQL, CommandType.StoredProcedure, pCAId, pChargeToId); }

                int rowCount = rptDetail.Rows.Count;

                if (rptMain.Rows.Count == 0)
                {
                    throw new Exception("Nothing to Print.");
                }

                int rowPerPage = 24;
                int rowToAdd = 0;
                if (rowCount > rowPerPage)
                {
                    for (rowToAdd = rowCount; rowToAdd >= rowPerPage;)
                    {
                        rowToAdd = rowToAdd - rowPerPage;
                    }                    
                }
                else if (rowCount < rowPerPage)
                {
                    rowToAdd = rowPerPage - rowCount;
                }
                
                for (int i = 0; i < rowToAdd; i++)
                {
                    rptDetail.Rows.Add("", 0, -1, 9999);
                }

                frmPreview frm = new frmPreview();
                LocalReport report = frm.rpvPreview.LocalReport;

                report.DataSources.Clear(); //clear report
                report.ReportEmbeddedResource = "MyRIS.Reports.rptCashAdvance.rdlc"; // bind reportviewer with .rdlc  
                report.DisplayName = "Cash Advance";
                                        
                ReportDataSource ds = new ReportDataSource("CashAdvance", rptMain); // set the datasource
                report.DataSources.Add(ds);

                ds = new ReportDataSource("CashAdvanceDetail", rptDetail); // set the datasource
                report.DataSources.Add(ds);

                ReportParameter p = new
                ReportParameter("txtPrintedBy", "Printed by: " + GlobalSettings.UserFullName + " | " + string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", DateTime.Now) + " | " + report.DisplayName);
                report.SetParameters(new ReportParameter[] { p });

                report.Refresh();

                //frm.ShowDialog();

                Byte[] bytes = report.Render("PDF");
                FileStream fs = new FileStream(Path.GetTempPath() + @"\CA_" + txtCANumber.Text + ".pdf", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                System.Diagnostics.Process.Start(Path.GetTempPath() + @"\CA_" + txtCANumber.Text + ".pdf");
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { Cursor = Cursors.Default; }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_CASH_ADVANCE, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }
                
                if(txtRemarks.Text.Trim() == "")
                {
                    txtRemarks.Focus();
                    throw new Exception("Remark is required.");
                }

                if (dgvList.Rows.Count == 0)
                { throw new Exception("List of particulars cannot be empty."); }

                if (txtHeadApproved.Tag.ToString() == "-1")
                {
                    throw new Exception("Approved by is required.");
                }

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to reject the CA?");

                if (strAnswer == DialogResult.No)
                { return; }

                SaveInfo(MODE_REJECT);

                function.MsgBoxInfo(this.Text, "CA Rejected.");

                LoadDetail();

                //ClearInfo();
                refresh = System.Windows.Forms.DialogResult.OK;


            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_CASH_ADVANCE, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }

                if (dgvList.Rows.Count == 0)
                { throw new Exception("List of particulars cannot be empty."); }

                if (txtHeadApproved.Tag.ToString() == "-1")
                { throw new Exception("Head Approved By cannot be empty."); }

                if (txtMgtApproved.Tag.ToString() == "-1" && Convert.ToDecimal(txtTotalAmount.Text) > Declaration.AMOUNT_LIMIT)
                { throw new Exception("Mgt Approved By cannot be empty."); }

                if (Convert.ToInt32(txtName.Tag) == Convert.ToInt32(txtHeadApproved.Tag))
                {
                    btnSearchHeadApprover.Focus();
                    throw new Exception("You cannot approved your self.");
                }

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to approve the CA?");
                
                if (strAnswer == DialogResult.No)
                { return; }

                SaveInfo(MODE_APPROVE);                

                LoadDetail();

                DialogResult strEmail = function.MsgBoxQuestion(this.Text, "Inform Treasury Department thru automatically generated email?");

                if (strEmail == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    StringBuilder emailMsg = new StringBuilder();

                    emailMsg.AppendLine("<p>A CA Request requires to be updated. Current Status[" + lblStatus.Text + "]</p>");
                    emailMsg.AppendLine("<p><b>CA #:<br />&emsp;");
                    emailMsg.AppendLine(txtCANumber.Text);
                    emailMsg.AppendLine("</b></p>");
                    emailMsg.AppendLine("<p><b>Requested By:<br />&emsp;");
                    emailMsg.AppendLine(txtName.Text);
                    emailMsg.AppendLine("</b></p>");
                    emailMsg.AppendLine("<p><b>CA Amount:<br />&emsp;PHP");
                    emailMsg.AppendLine(txtCAAmount.Text);
                    emailMsg.AppendLine("</b></p>");

                    emailMsg.AppendLine("<p>Thank you!</p>");
                    emailMsg.AppendLine("");
                    emailMsg.AppendLine("<font size=\"-3\"><p>Please do not reply. System-generated email notification only.<br /></font></p>");

                    common.SendEmail("Travel and Expense System - Cash Advance Request", emailMsg.ToString(), function.GetDBSetting("TREASURY_EMAIL", ""));
                }

                FormatObjects();

                this.Cursor = Cursors.Default;
                refresh = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void txtStore_Enter(object sender, EventArgs e)
        {
            txtStore.Clear();
        }

        private void txtStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataRow[] dr = comboStores.Select("storeName like '%" + txtStore.Text + "%'");
                if (dr.Length > 0)
                {
                    cboStores.DataSource = dr.CopyToDataTable();
                    cboStores.DisplayMember = "storeName";
                    cboStores.ValueMember = "storeId";
                    cboStores.DroppedDown = true;
                    cboStores.Focus();
                }
            }
        }

        private void txtStore_Leave(object sender, EventArgs e)
        {
            txtStore.Clear();
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == IX_GRID_IS_ACTIVE && e.RowIndex != -1)
            {
                dgvList.EndEdit();
            }
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == IX_GRID_IS_ACTIVE && e.RowIndex != -1)
            {
                ComputeTotalAmount();
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnAdd.PerformClick(); }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_CASH_ADVANCE, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }

                if (txtRemarks.Text.Trim() == "")
                {
                    txtRemarks.Focus();
                    throw new Exception("Remark is required.");
                }

                if (dgvList.Rows.Count == 0)
                { throw new Exception("List of particulars cannot be empty."); }

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to return the CA?");

                if (strAnswer == DialogResult.No)
                { return; }

                SaveInfo(MODE_RETURN);

                function.MsgBoxInfo(this.Text, "CA returned.");

                LoadDetail();

                FormatObjects();

                refresh = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void btnSearchApprover_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();
            frm.GROUP = "APPROVER";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtHeadApproved.Text = frm.LUName;
                txtHeadApproved.Tag = frm.LUId;
            }
        }

        private void btnSearchDocsReceived_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();
            frm.GROUP = "TREASURY";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtDocsReceivedBy.Text = frm.LUName;
                txtDocsReceivedBy.Tag = frm.LUId;
            }
        }

        private void btnSearchMgtApprover_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();
            frm.GROUP = "ALL";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtMgtApproved.Text = frm.LUName;
                txtMgtApproved.Tag = frm.LUId;
            }
        }

        private void btnUploadedBy_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();
            frm.GROUP = "TREASURY";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtUploadedBy.Text = frm.LUName;
                txtUploadedBy.Tag = frm.LUId;
            }
        }

        private void btnCashReleasedBy_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();
            frm.GROUP = "TREASURY";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtReleasedBy.Text = frm.LUName;
                txtReleasedBy.Tag = frm.LUId;
            }
        }

        private void cboChargeTo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboChargeTo.SelectedValue.ToString()) == Declaration.CHARGE_TO_ID_MULTIPLE)
            {
                DataTable dt = new DataTable();
                StringBuilder sSQL = new StringBuilder();

                try
                {
                    dt.Columns.Add("chargeToId");
                    dt.Columns.Add("chargeToName");

                    sSQL.AppendLine("SELECT chargeToId, chargeToName FROM ChargeTo WHERE chargeToId <> " + Declaration.CHARGE_TO_ID_MULTIPLE);

                    using (SQLDB sql = new SQLDB())
                    { dt = sql.GetDT(sSQL.ToString()); }

                    dt.DefaultView.Sort = "chargeToId";
                    dt = dt.DefaultView.ToTable();

                    chkBoxChargeTo.DataSource = dt;
                    chkBoxChargeTo.DisplayMember = "chargeToName";
                    chkBoxChargeTo.ValueMember = "chargeToId";
                }
                catch (Exception ex)
                { function.MsgBoxInfo(this.Text, ex.Message); }
                txtCANumber.Clear();
                chkBoxChargeTo.Visible = true;
                chkBoxChargeTo.Height = chkBoxChargeTo.Height * (dt.Rows.Count - 1);
                cboChargeTo.Visible = false;
                btnSaveMultiple.Visible = true;
                FormatObjects();
            }
            else if (mvCAId != -1)
            {
                SelectChargeTo();
                FormatObjects();
            }
        }

        private void btnSaveMultiple_Click(object sender, EventArgs e)
        {
            if (cboChargeTo.SelectedIndex == -1)
            { return; }

            if (!isMultiple)
            {
                chkBoxChargeTo.Visible = false;
                btnSaveMultiple.Visible = false;
                chkBoxChargeTo.Height = 19;
                cboChargeTo.Visible = true;

                isMultiple = true;
                cboChargeTo.DataSource = chkBoxChargeTo.CheckedItems;
                cboChargeTo.DisplayMember = "chargeToName";
                cboChargeTo.ValueMember = "chargeToId";

                chkPartChargeTo.DataSource = chkBoxChargeTo.CheckedItems;
                chkPartChargeTo.DisplayMember = "chargeToName";
                chkPartChargeTo.ValueMember = "chargeToId";

                txtParticulars.Width = 274;
                chkPartChargeTo.Visible = true;
                lblPartChargeTo.Visible = true;

                dgvList.Columns["chargeToName"].Visible = true;
                dgvList.Columns["Description"].Width = 300;
            }
        }

        private void chkPartChargeTo_Enter(object sender, EventArgs e)
        {
            chkPartChargeTo.Height = chkPartChargeTo.Height * (chkPartChargeTo.Items.Count);
        }
        
        private void chkPartChargeTo_Leave(object sender, EventArgs e)
        {
            chkPartChargeTo.Height = 19;
        }

        private void btnAuditedBy_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();
            frm.GROUP = "AUD";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtAuditedBy.Text = frm.LUName;
                txtAuditedBy.Tag = frm.LUId;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_CASH_ADVANCE, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }

                ValidateInfo();

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to submit the changes you've made?");

                if (strAnswer == DialogResult.No)
                { return; }

                SaveInfo(MODE_MODIFY);

                LoadDetail();

                if (Convert.ToInt32(lblStatus.Tag) == Declaration.CA_STATUS_ID_FOR_APPROVAL)
                {
                    DialogResult strInformApprover = function.MsgBoxQuestion(this.Text, "Inform your approver thru email?");

                    if (strInformApprover == DialogResult.Yes)
                    {
                        frmSearchApprover frm = new frmSearchApprover();
                        frm.ShowDialog();
                        if (Convert.ToInt32(lblStatus.Tag) == Declaration.CA_STATUS_ID_SAVED
                            && Convert.ToInt32(lblStatus.Tag) == Declaration.CA_STATUS_ID_NEW)
                        {
                            frm.ShowDialog();

                            if (frm.DialogResult != DialogResult.OK)
                            {
                                throw new Exception("Please select a approver.");
                            }
                        }

                    }
                }
                refresh = System.Windows.Forms.DialogResult.OK;
                btnPrint.Visible = true;

                this.Cursor = Cursors.Default;

                FormatObjects();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            SubmitReceivedConfirmation();
            this.Cursor = Cursors.Default;
        }
    }
}
