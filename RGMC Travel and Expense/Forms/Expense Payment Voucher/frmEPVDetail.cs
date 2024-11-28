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
    public partial class frmEPVDetail : Form
    {
        private Common common = new Common();
        Function function = new Function();
        private int mvEPVId = -1;
        private int mvChargeToId = -1;
        private DataTable dtStores;
        private DataTable comboChargeTo;
        DataTable mainDT = new DataTable();
        DataTable detailDT = new DataTable();
        private bool detailEdit = false;

        private const string TRANSACTION_REIMBURSEMENT = "REIMBURSEMENT";
        private const string TRANSACTION_LIQUIDATION = "LIQUIDATION";

        private static int IX_GRID_NATURE_OF_EXPENSE_ID = 0;
        private static int IX_GRID_TRANSACTION_DATE = 1;
        private static int IX_GRID_NATURE_OF_EXPENSE = 2;
        private static int IX_GRID_PARTICULARS = 3;
        private static int IX_GRID_CHARGE_TO_NAME = 4;
        private static int IX_GRID_AMOUNT = 5;
        private static int IX_GRID_VENDOR_ID = 6;
        private static int IX_GRID_VENDOR_NAME = 7;
        private static int IX_GRID_TIN = 8;
        private static int IX_GRID_REFERENCE_NUMBER = 9;
        private static int IX_GRID_VAT_AMOUNT = 10;
        private static int IX_GRID_CLAIM_TO_ID = 11;
        private static int IX_GRID_IS_ACTIVE = 12;
        private static int IX_GRID_ADDRESS = 13;
        private static int IX_GRID_CHARGE_TO_ID = 14;

        private static int TRANSPORT_CHARGES_ID = 35;

        private const int MODE_SUBMIT = 1;
        private const int MODE_SAVE = 2;
        private const int MODE_APPROVE = 3;
        private const int MODE_REJECT = 4;
        private const int MODE_RETURN = 5;
        
        private const string CODE_SUBMIT = "SUBMIT";
        private const string CODE_SAVE = "SAVE";
        private const string CODE_APPROVE = "APPROVE";
        private const string CODE_REJECT = "REJECT";
        private const string CODE_RETURN = "RETURN";

        DialogResult refresh = new DialogResult();

        private int lastIndex = -1;

        private Control _currentToolTipControl = null;

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private bool remarkRequired = false;

        private bool isMultiple = false;

        private bool mvSave = false;

        #region Property

        public int EPVId
        {
            set { mvEPVId = value; }
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

            if (keyData == Keys.Escape && pnlTransportMultiple.Visible)
            {
                pnlTransportMultiple.Visible = false;
                cboNatureOfExpense.Focus();
                pnlTransport.Visible = false;
            }

            if (keyData == Keys.Escape && chkBoxChargeTo.Visible)
            {
                chkBoxChargeTo.SelectedIndex = -1;
                chkBoxChargeTo.Visible = false;
                chkBoxChargeTo.Height = 19;
                cboChargeTo.Visible = true;
                btnSaveMultiple.Visible = false;
            }

            if (keyData == Keys.Escape && chkDestChargeTo.Visible)
            {
                chkDestChargeTo.Height = 19;
            }

            if (keyData == Keys.Escape && chkPartChargeTo.Visible)
            {
                chkPartChargeTo.Height = 19;
            }

            if (keyData == (Keys.Control | Keys.A) && pnlTransportMultiple.Visible)
            {
                btnAdd.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        public frmEPVDetail()
        {
            InitializeComponent();
        }

        private void SaveInfo(int MODE)
        {
            StringBuilder sSQL = new StringBuilder();

            DataTable dt = new DataTable();
            string strUserName = GlobalSettings.UserName;

            try
            {
                // declare variable
                // **************************
                System.Data.SqlClient.SqlParameter pEPVId = new System.Data.SqlClient.SqlParameter("@epvId", SqlDbType.Int);
                pEPVId.Direction = ParameterDirection.Output;

                decimal caAmount = decimal.Parse(txtCashAdvance.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Any);
                decimal cashOver = decimal.Parse(txtCashOver.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Any);
                decimal totalAmount = 0;

                sSQL.AppendLine("DECLARE @employeeId INT = " + txtRequestBy.Tag);
                sSQL.AppendLine("DECLARE @requestDate DATE = " + dtpRequested.Text.sQuote());
                sSQL.AppendLine("DECLARE @transactionTypeId INT = " + cboTransactionType.SelectedValue);
                sSQL.AppendLine("DECLARE @formNumber VARCHAR(50) = " + txtFormNumber.Text.Trim().sQuote());

                sSQL.AppendLine("DECLARE @businessPurposeId INT = " + cboBusinessPurpose.SelectedValue);
                sSQL.AppendLine("DECLARE @bpOthers VARCHAR(250) = " + txtBusinessOthers.Text.sQuote());
                sSQL.AppendLine("DECLARE @chargeToId INT = " + cboChargeTo.SelectedValue);
                sSQL.AppendLine("DECLARE @modeOfPaymentId INT = " + (cboModeOfPayment.SelectedValue == null ? -1 : cboModeOfPayment.SelectedValue));
                sSQL.AppendLine("DECLARE @caId INT = " + txtCA.Tag);

                sSQL.AppendLine("DECLARE @costCenterId INT = " + cboDepartment.SelectedValue);
                sSQL.AppendLine("DECLARE @storeId INT = " + cboStores.SelectedValue);
                sSQL.AppendLine("DECLARE @epvStatusId INT");
                sSQL.AppendLine("DECLARE @headApprovedById INT = " + txtHeadApprovedBy.Tag);
                sSQL.AppendLine("DECLARE @headApprovedDate DATE = " + dtpHeadApproved.Text.sQuote());
                sSQL.AppendLine("DECLARE @mgtApprovedById INT = " + txtMgtApprovedBy.Tag);
                sSQL.AppendLine("DECLARE @mgtApprovedDate DATE = " + dtpMgtApproved.Text.sQuote());
                sSQL.AppendLine("DECLARE @receivedByAcctId INT = " + txtDocsReceivedBy.Tag);
                sSQL.AppendLine("DECLARE @receivedByAcctDate DATE = " + dtpDocsReceived.Text.sQuote());
                sSQL.AppendLine("DECLARE @auditedById INT = " + txtAuditedBy.Tag);
                sSQL.AppendLine("DECLARE @auditedDate DATE = " + dtpAudited.Text.sQuote());
                sSQL.AppendLine("DECLARE @uploadedById INT = " + txtUploadedBy.Tag);
                sSQL.AppendLine("DECLARE @uploadedDate DATE = " + dtpUploadedBy.Text.sQuote());
                sSQL.AppendLine("DECLARE @releasedById INT = " + txtReleasedBy.Tag);
                sSQL.AppendLine("DECLARE @releasedDate DATE = " + dtpReleased.Text.sQuote());

                sSQL.AppendLine("DECLARE @batchDate DATE = " + dtpBatchDate.Text.sQuote());
                sSQL.AppendLine("DECLARE @releasingDate DATE = " + dtpReleasingDate.Text.sQuote());                
                sSQL.AppendLine("DECLARE @remark VARCHAR(300) = " + txtRemarks.Text.sQuote());
                
                sSQL.AppendLine("DECLARE @username VARCHAR(50) = " + GlobalSettings.UserName.sQuote());
                sSQL.AppendLine("");

                string modeCode = "";
                int statusId = -1;

                int currentStatus = Convert.ToInt32(lblStatus.Tag);

                if (MODE == MODE_SUBMIT)
                {
                    modeCode = CODE_SUBMIT;
                    statusId = Declaration.EPV_STATUS_ID_FOR_APPROVAL;
                }
                else if (MODE == MODE_SAVE)
                {
                    modeCode = CODE_SAVE;
                    statusId = Declaration.EPV_STATUS_ID_SAVED;
                }
                else if (MODE == MODE_APPROVE)
                {
                    modeCode = CODE_APPROVE;
                    statusId = Declaration.EPV_STATUS_ID_APPROVED;
                }
                else if (MODE == MODE_REJECT)
                {
                    modeCode = CODE_REJECT;
                    statusId = Declaration.EPV_STATUS_ID_REJECTED;
                }
                else if (MODE == MODE_RETURN)
                {
                    modeCode = CODE_RETURN;
                    statusId = Declaration.EPV_STATUS_ID_SAVED;

                    if (currentStatus == Declaration.EPV_STATUS_ID_FOR_AUDIT)
                    {
                        statusId = Declaration.EPV_STATUS_ID_APPROVED;
                    }
                    else if (currentStatus == Declaration.EPV_STATUS_ID_FOR_RELEASING)
                    {
                        statusId = Declaration.EPV_STATUS_ID_FOR_AUDIT;
                    }
                }

                sSQL.AppendLine("");

                sSQL.AppendLine("DECLARE @errorMessage VARCHAR(250)");

                sSQL.AppendLine("\r");
                // **************************                             

                // **************************
                // new record
                if (mvEPVId == -1)
                {
                    sSQL.AppendLine(function.GenerateIdScript("epvId"));

                    sSQL.AppendLine("SELECT epvId");
                    sSQL.AppendLine("FROM EPV");
                    sSQL.AppendLine("WHERE epvId = @epvId");
                    sSQL.AppendLine("   AND chargeToId = @chargeToId");

                    sSQL.AppendLine("");

                    sSQL.AppendLine("IF @@ROWCOUNT > 0");
                    sSQL.AppendLine("    BEGIN");
                    sSQL.AppendLine("        SELECT @errorMessage = 'EPV ID already exist.'");
                    sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                    sSQL.AppendLine("        ROLLBACK TRANSACTION");
                    sSQL.AppendLine("        RETURN");
                    sSQL.AppendLine("    END");

                    if (MODE == MODE_SUBMIT)
                    {
                        sSQL.AppendLine("DECLARE @epv" + cboTransactionType.Text + DateTime.Now.Year.ToString().Substring(2, 2) + "Id INT ");
                        sSQL.AppendLine(function.GenerateIdScript("epv" + cboTransactionType.Text + DateTime.Now.Year.ToString().Substring(2, 2) + "Id"));
                    }

                    string chargeToName = "";
                    string chargeToCode = "";               

                    if (isMultiple)
                    {
                        for (int i = 0; i < cboChargeTo.Items.Count; i++)
                        {
                            DataRowView x = (DataRowView)cboChargeTo.Items[i];

                            sSQL.AppendLine("SELECT @chargeToId = " + x["chargeToId"]);
                                                     
                            foreach (DataGridViewRow row in dgvList.Rows)
                            {
                                if (Convert.ToInt32(row.Cells[IX_GRID_CHARGE_TO_ID].Value) == Convert.ToInt32(x["chargeToId"]))
                                { totalAmount += Convert.ToDecimal(row.Cells[IX_GRID_AMOUNT].Value); }
                            }

                            if (MODE == MODE_SUBMIT)
                            {
                                chargeToName = System.Text.RegularExpressions.Regex.Replace(x["chargeToName"].ToString().Split(':')[0], @"[^0-9a-zA-Z]+", "");
                                chargeToCode = x["chargeToName"].ToString().Split(':')[1];


                                sSQL.AppendLine("SELECT @formNumber =" + (chargeToCode + "-" + cboTransactionType.Text.Substring(0, 1) + DateTime.Now.Year.ToString().Substring(2, 2) + "-").sQuote() + " + FORMAT(@epv" + cboTransactionType.Text + DateTime.Now.Year.ToString().Substring(2, 2) + "Id, '0000')");
                                                               
                                sSQL.AppendLine("SELECT @epvStatusId = " + statusId); 
                            }
                            else
                            {
                                sSQL.AppendLine(" SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_SAVED);
                                sSQL.AppendLine(" SELECT @formNumber = ''");
                            }

                            sSQL.AppendLine("INSERT INTO EPV(epvId, formNumber, transactionTypeId, caId, chargeToId, ");
                            sSQL.AppendLine("   costCenterId, storeId, businessPurposeId, bpOthers, modeOfPaymentId, totalExpense, cashOverUnder,");
                            sSQL.AppendLine("   employeeId, requestDate, remark, epvStatusId, createBy, createDate)");
                            sSQL.AppendLine("VALUES (@epvId, @formNumber, @transactionTypeId, @caId, " + x["chargeToId"] + ", ");
                            sSQL.AppendLine("   @costCenterId, @storeId, @businessPurposeId, @bpOthers, @modeOfPaymentId, " + totalAmount + ",");
                            if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                            { sSQL.AppendLine((totalAmount - caAmount).ToString() + ","); }
                            else
                            { sSQL.AppendLine(0 + ","); }
                            sSQL.AppendLine("   @employeeId, GETDATE(), @remark, @epvStatusId, @username, GETDATE())");
                        }
                    }
                    else
                    {
                        if (MODE == MODE_SUBMIT)
                        { sSQL.AppendLine("SELECT @formNumber =" + (cboTransactionType.Text.Substring(0, 1) + DateTime.Now.Year.ToString().Substring(2, 2) + "-").sQuote() + " + FORMAT(@epv" + cboTransactionType.Text + "Id, '0000') "); }

                        foreach (DataGridViewRow row in dgvList.Rows)
                        {
                            totalAmount += Convert.ToDecimal(row.Cells[IX_GRID_AMOUNT].Value);
                        }

                        sSQL.AppendLine("SELECT @epvStatusId = " + statusId);

                        sSQL.AppendLine("INSERT INTO EPV(epvId, formNumber, transactionTypeId, caId, chargeToId, ");
                        sSQL.AppendLine("   costCenterId, storeId, businessPurposeId, bpOthers, modeOfPaymentId, totalExpense, cashOverUnder,");
                        sSQL.AppendLine("   employeeId, requestDate, remark, epvStatusId, createBy, createDate)");
                        sSQL.AppendLine("VALUES (@epvId, @formNumber, @transactionTypeId, @caId, " + cboChargeTo.SelectedValue + ", ");
                        sSQL.AppendLine("   @costCenterId, @storeId, @businessPurposeId, @bpOthers, @modeOfPaymentId, " + totalAmount + ",");
                        if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                        { sSQL.AppendLine((totalAmount - caAmount).ToString() + ","); }
                        else
                        { sSQL.AppendLine(0 + ","); }
                        sSQL.AppendLine("   @employeeId, GETDATE(), @remark, @epvStatusId, @username, GETDATE())");
                    }

                    if (MODE == MODE_SUBMIT)
                    {
                        if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                        {
                            if (Convert.ToInt32(cboChargeTo.SelectedValue) == Convert.ToInt32(txtCAStatus.Tag))
                            {
                                sSQL.AppendLine("UPDATE CashAdvance");
                                sSQL.AppendLine("SET");
                                sSQL.AppendLine("   cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_LIQUIDATED + ",");
                                sSQL.AppendLine("   dateLiquidated = GETDATE(), ");
                                sSQL.AppendLine("   updateBy = @username, ");
                                sSQL.AppendLine("   updateDate = GETDATE() ");
                                sSQL.AppendLine("WHERE caId = @caId");
                                sSQL.AppendLine("   AND chargeToId = " + cboChargeTo.SelectedValue);
                            }

                            sSQL.AppendLine(" SELECT @epvStatusId = " + statusId);

                            totalAmount = 0;
                            foreach (DataGridViewRow row in dgvList.Rows)
                            {
                                if (Convert.ToInt32(row.Cells[IX_GRID_CHARGE_TO_ID].Value) == Convert.ToInt32(cboChargeTo.SelectedValue))
                                { totalAmount += Convert.ToDecimal(row.Cells[IX_GRID_AMOUNT].Value); }
                            }

                            sSQL.AppendLine("UPDATE EPV");
                            sSQL.AppendLine("SET");
                            sSQL.AppendLine("   epvStatusId = @epvStatusId, ");
                            sSQL.AppendLine("   cashOverUnder = " + (totalAmount - caAmount).ToString() + ",");
                            sSQL.AppendLine("   updateBy = @username, ");
                            sSQL.AppendLine("   updateDate = GETDATE() ");
                            sSQL.AppendLine("WHERE caId = @caId");
                            sSQL.AppendLine("   AND chargeToId = " + cboChargeTo.SelectedValue);
                        }
                    }                   
                    
                }
                // existing record
                else
                {
                    sSQL.AppendLine("SELECT @epvId = " + mvEPVId);

                    // UPDATE APPROVED BY
                    if (MODE != MODE_SAVE)
                    {
                        if (!isMultiple)
                        {
                            sSQL.AppendLine("SELECT @epvStatusId = " + statusId);

                            sSQL.AppendLine("IF @formNumber = ''");
                            sSQL.AppendLine("BEGIN");
                            sSQL.AppendLine("DECLARE @epv" + cboTransactionType.Text + "Id INT ");
                            sSQL.AppendLine(function.GenerateIdScript("epv" + cboTransactionType.Text + "Id"));
                            sSQL.AppendLine("");
                            sSQL.AppendLine("SELECT @formNumber =" + (cboTransactionType.Text.Substring(0, 1) + DateTime.Now.Year.ToString().Substring(2, 2) + "-").sQuote() + " + FORMAT(@epv" + cboTransactionType.Text + "Id, '00000') ");
                            sSQL.AppendLine("");

                            sSQL.AppendLine("UPDATE EPV");
                            sSQL.AppendLine("SET formNumber = @formNumber"); 
                            sSQL.AppendLine("WHERE epvId = @epvId");
                            sSQL.AppendLine(" AND chargeToId = @chargeToId");
                            sSQL.AppendLine("END");

                            sSQL.AppendLine("UPDATE EPV");
                            sSQL.AppendLine("SET epvStatusId = @epvStatusId");
                            sSQL.AppendLine("WHERE epvId = @epvId");
                            sSQL.AppendLine(" AND chargeToId = @chargeToId");
                            sSQL.AppendLine("");

                            if (MODE == MODE_RETURN) { }

                            switch (currentStatus)
                            {
                                case Declaration.EPV_STATUS_ID_FOR_APPROVAL:
                                    if (MODE == MODE_RETURN)
                                    {
                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_SAVED);

                                        sSQL.AppendLine("   UPDATE EPV ");
                                        sSQL.AppendLine("   SET epvStatusId = @epvStatusId");
                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                                    }
                                    else
                                    {
                                        if (Convert.ToDecimal(txtTotalExpense.Text) > Declaration.AMOUNT_LIMIT && txtMgtApprovedBy.Text.Trim() == "")
                                        {
                                            sSQL.AppendLine("    BEGIN");
                                            sSQL.AppendLine("        SELECT @errorMessage = 'Mgt Approved cannot be empty.'");
                                            sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                                            sSQL.AppendLine("        ROLLBACK TRANSACTION");
                                            sSQL.AppendLine("        RETURN");
                                            sSQL.AppendLine("    END");
                                        }

                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_APPROVED);

                                        sSQL.AppendLine("IF @headApprovedById <> -1");
                                        sSQL.AppendLine("BEGIN");
                                        sSQL.AppendLine("   UPDATE EPV SET ");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId");
                                        sSQL.AppendLine(",      headApprovedById = @headApprovedById");
                                        sSQL.AppendLine(",      headApprovedDate = @headApprovedDate");

                                        if (txtMgtApprovedBy.Text.Trim() != "")
                                        {
                                            sSQL.AppendLine(",      mgtApprovedById = @mgtApprovedById");
                                            sSQL.AppendLine(",      mgtApprovedDate = @mgtApprovedDate");
                                        }

                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("       AND chargeToId = @chargeToId");
                                        sSQL.AppendLine("END");
                                    }
                                    break;
                                case Declaration.EPV_STATUS_ID_APPROVED:
                                    if (MODE == MODE_RETURN)
                                    {
                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_FOR_APPROVAL);

                                        sSQL.AppendLine("   UPDATE EPV ");
                                        sSQL.AppendLine("   SET headApprovedById = -1,");
                                        sSQL.AppendLine("       mgtApprovedById = -1,");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId");
                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                                    }
                                    else
                                    {
                                        sSQL.AppendLine("IF @receivedByAcctId <> -1");
                                        sSQL.AppendLine("BEGIN");
                                        sSQL.AppendLine("   SELECT @batchDate = CASE WHEN DATEPART(dw, @receivedByAcctDate) = 2 THEN DATEADD(d, 3, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 3 THEN DATEADD(d, 2, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 4 THEN DATEADD(d, 1, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 5 THEN DATEADD(d, 4, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 6 THEN DATEADD(d, 3, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 7 THEN DATEADD(d, 2, @receivedByAcctDate)");
                                        sSQL.AppendLine("   ELSE @receivedByAcctDate END");

                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_FOR_AUDIT);

                                        sSQL.AppendLine("   UPDATE EPV ");
                                        sSQL.AppendLine("   SET batchDate = @batchDate");
                                        sSQL.AppendLine(",      epvStatusId = @epvStatusId");
                                        sSQL.AppendLine(",      releasingDate = DATEADD(d, 1, @batchDate)");
                                        sSQL.AppendLine(",      receivedByAcctId = @receivedByAcctId");
                                        sSQL.AppendLine(",      receivedByAcctDate = @receivedByAcctDate");
                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("       AND chargeToId = @chargeToId");
                                        sSQL.AppendLine("END");
                                    }
                                    break;
                                case Declaration.EPV_STATUS_ID_FOR_AUDIT:
                                    if (MODE == MODE_RETURN)
                                    {
                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_APPROVED);

                                        sSQL.AppendLine("   UPDATE EPV ");
                                        sSQL.AppendLine("   SET receivedByAcctId = -1,");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId");
                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                                    }
                                    else
                                    {
                                        sSQL.AppendLine("IF @auditedById <> -1");
                                        sSQL.AppendLine("BEGIN");
                                        if (MODE == MODE_APPROVE)
                                        { sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_FOR_RELEASING); }
                                        else if (MODE == MODE_REJECT)
                                        { sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_REJECTED); }

                                        sSQL.AppendLine("UPDATE EPV");
                                        sSQL.AppendLine("   SET batchDate = @batchDate,");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId,");
                                        sSQL.AppendLine("       releasingDate = @releasingDate,");
                                        sSQL.AppendLine("       auditedById = @auditedById,");
                                        sSQL.AppendLine("       auditedDate = GETDATE()");
                                        sSQL.AppendLine("WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                                        sSQL.AppendLine("END");
                                    }
                                    break;
                                case Declaration.EPV_STATUS_ID_FOR_RELEASING:
                                    if (txtReleasedBy.Text.Trim() != "")
                                    {
                                        sSQL.AppendLine("IF @releasedById <> -1");
                                        sSQL.AppendLine("BEGIN");

                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_RELEASED);

                                        sSQL.AppendLine("UPDATE EPV");
                                        sSQL.AppendLine("   SET batchDate = @batchDate,");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId,");
                                        sSQL.AppendLine("       releasingDate = @releasingDate,");
                                        sSQL.AppendLine("       releasedById = @releasedById,");
                                        sSQL.AppendLine("       releasedDate = @releasedDate");
                                        sSQL.AppendLine("WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");

                                        sSQL.AppendLine("END");
                                    }
                                    else
                                    {
                                        sSQL.AppendLine("IF @uploadedById <> -1");
                                        sSQL.AppendLine("BEGIN");

                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_UPLOADED);

                                        sSQL.AppendLine("UPDATE EPV");
                                        sSQL.AppendLine("   SET batchDate = @batchDate,");
                                        sSQL.AppendLine("   epvStatusId = @epvStatusId,");
                                        sSQL.AppendLine("   releasingDate = @releasingDate,");
                                        sSQL.AppendLine("   uploadedById = @uploadedById,");
                                        sSQL.AppendLine("   uploadedDate = @uploadedDate");
                                        sSQL.AppendLine("WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");

                                        sSQL.AppendLine("END");
                                    }
                                    break;
                                case Declaration.EPV_STATUS_ID_UPLOADED:
                                    sSQL.AppendLine("IF @releasedById <> -1");
                                    sSQL.AppendLine("BEGIN");

                                    sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_RELEASED);

                                    sSQL.AppendLine("UPDATE EPV");
                                    sSQL.AppendLine("   SET batchDate = @batchDate,");
                                    sSQL.AppendLine("   epvStatusId = @epvStatusId,");
                                    sSQL.AppendLine("   releasingDate = @releasingDate,");
                                    sSQL.AppendLine("   releasedById = @releasedById,");
                                    sSQL.AppendLine("   releasedDate = @releasedDate");
                                    sSQL.AppendLine("WHERE epvId = @epvId");
                                    sSQL.AppendLine("   AND chargeToId = @chargeToId");

                                    sSQL.AppendLine("END");
                                    break;
                            }

                        }
                        else
                        {
                            if (MODE == MODE_SUBMIT)
                            {

                                sSQL.AppendLine("SELECT @epvStatusId = " + statusId);
                                sSQL.AppendLine("DECLARE @formNo INT ");
                                sSQL.AppendLine("DECLARE @epv" + cboTransactionType.Text + "Id INT ");

                                sSQL.AppendLine("SELECT @formNumber = formNumber FROM EPV WHERE epvId = @epvId AND formNumber != ''");
                                sSQL.AppendLine("IF @@ROWCOUNT = 0");
                                sSQL.AppendLine("BEGIN");
                                sSQL.AppendLine(function.GenerateIdScript("epv" + cboTransactionType.Text + "Id"));
                                sSQL.AppendLine("END");
                                for (int i = 0; i < cboChargeTo.Items.Count; i++)
                                {
                                    DataRowView x = (DataRowView)cboChargeTo.Items[i];

                                    sSQL.AppendLine("SELECT @chargeToId = " + x["chargeToId"]);

                                    var chargeToName = System.Text.RegularExpressions.Regex.Replace(x["chargeToName"].ToString().Split(':')[0], @"[^0-9a-zA-Z]+", "");
                                    var chargeToCode = x["chargeToName"].ToString().Split(':')[1];

                                    sSQL.AppendLine("SELECT @formNumber = formNumber FROM EPV WHERE epvId = @epvId AND chargeToId = @chargeToId");

                                    sSQL.AppendLine("SELECT @epvStatusId = " + statusId);
        
                                            sSQL.AppendLine("IF @formNumber = ''"); 
                                    sSQL.AppendLine("BEGIN");
                                    sSQL.AppendLine("   SELECT @formNumber =" + (chargeToCode + "-" + cboTransactionType.Text.Substring(0, 1) + DateTime.Now.Year.ToString().Substring(2, 2) + "-").sQuote() + " + FORMAT(@epv" + cboTransactionType.Text + "Id, '00000') ");
                            
                                    sSQL.AppendLine("UPDATE EPV");
                                    sSQL.AppendLine("SET formNumber = @formNumber"); ;
                                    sSQL.AppendLine("WHERE epvId = @epvId"); 
                                    sSQL.AppendLine(" AND chargeToId = @chargeToId");

                                    sSQL.AppendLine("END");
                                    sSQL.AppendLine("UPDATE EPV");
                                    sSQL.AppendLine("SET epvStatusId = @epvStatusId");
                                    sSQL.AppendLine("WHERE epvId = @epvId");
                                    sSQL.AppendLine(" AND chargeToId = @chargeToId");
                                    sSQL.AppendLine("");
                                }
                            }


                            sSQL.AppendLine("SELECT @chargeToId = " + cboChargeTo.SelectedValue);
                            switch (currentStatus)
                            {
                                case Declaration.EPV_STATUS_ID_FOR_APPROVAL:
                                    if (MODE == MODE_RETURN)
                                    {
                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_SAVED);

                                        sSQL.AppendLine("   UPDATE EPV ");
                                        sSQL.AppendLine("   SET epvStatusId = @epvStatusId");
                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                                    }
                                    else
                                    {
                                        if (Convert.ToDecimal(txtTotalExpense.Text) > Declaration.AMOUNT_LIMIT && txtMgtApprovedBy.Text.Trim() == "")
                                        {
                                            sSQL.AppendLine("    BEGIN");
                                            sSQL.AppendLine("        SELECT @errorMessage = 'Mgt Approved cannot be empty.'");
                                            sSQL.AppendLine("        RAISERROR (@errorMessage, 16, 1)  WITH NOWAIT");
                                            sSQL.AppendLine("        ROLLBACK TRANSACTION");
                                            sSQL.AppendLine("        RETURN");
                                            sSQL.AppendLine("    END");
                                        }

                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_APPROVED);

                                        sSQL.AppendLine("IF @headApprovedById <> -1");
                                        sSQL.AppendLine("BEGIN");
                                        sSQL.AppendLine("   UPDATE EPV SET ");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId");
                                        sSQL.AppendLine(",      headApprovedById = @headApprovedById");
                                        sSQL.AppendLine(",      headApprovedDate = @headApprovedDate");

                                        if (txtMgtApprovedBy.Text.Trim() != "")
                                        {
                                            sSQL.AppendLine(",      mgtApprovedById = @mgtApprovedById");
                                            sSQL.AppendLine(",      mgtApprovedDate = @mgtApprovedDate");
                                        }

                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("       AND chargeToId = @chargeToId");
                                        sSQL.AppendLine("END");
                                    }
                                    break;
                                case Declaration.EPV_STATUS_ID_APPROVED:
                                    if (MODE == MODE_RETURN)
                                    {
                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_FOR_APPROVAL);

                                        sSQL.AppendLine("   UPDATE EPV ");
                                        sSQL.AppendLine("   SET headApprovedById = -1,");
                                        sSQL.AppendLine("       mgtApprovedById = -1,");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId");
                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                                    }
                                    else
                                    {
                                        sSQL.AppendLine("IF @receivedByAcctId <> -1");
                                        sSQL.AppendLine("BEGIN");
                                        sSQL.AppendLine("   SELECT @batchDate = CASE WHEN DATEPART(dw, @receivedByAcctDate) = 2 THEN DATEADD(d, 3, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 3 THEN DATEADD(d, 2, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 4 THEN DATEADD(d, 1, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 5 THEN DATEADD(d, 4, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 6 THEN DATEADD(d, 3, @receivedByAcctDate)");
                                        sSQL.AppendLine("   WHEN DATEPART(dw, @receivedByAcctDate) = 7 THEN DATEADD(d, 2, @receivedByAcctDate)");
                                        sSQL.AppendLine("   ELSE @receivedByAcctDate END");

                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_FOR_AUDIT);

                                        sSQL.AppendLine("   UPDATE EPV ");
                                        sSQL.AppendLine("   SET batchDate = @batchDate");
                                        sSQL.AppendLine(",       epvStatusId = @epvStatusId");
                                        sSQL.AppendLine(",      releasingDate = DATEADD(d, 1, @batchDate)");
                                        sSQL.AppendLine(",      receivedByAcctId = @receivedByAcctId");
                                        sSQL.AppendLine(",      receivedByAcctDate = @receivedByAcctDate");
                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("       AND chargeToId = @chargeToId");
                                        sSQL.AppendLine("END");
                                    }
                                    break;
                                case Declaration.EPV_STATUS_ID_FOR_AUDIT:
                                    if (MODE == MODE_RETURN)
                                    {
                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_APPROVED);

                                        sSQL.AppendLine("   UPDATE EPV ");
                                        sSQL.AppendLine("   SET receivedByAcctId = -1,");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId");
                                        sSQL.AppendLine("   WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                                    }
                                    else
                                    {
                                        sSQL.AppendLine("IF @auditedById <> -1");
                                        sSQL.AppendLine("BEGIN");
                                        if (MODE == MODE_APPROVE)
                                        { sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_FOR_RELEASING); }
                                        else if (MODE == MODE_REJECT)
                                        { sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_REJECTED); }

                                        sSQL.AppendLine("UPDATE EPV");
                                        sSQL.AppendLine("   SET batchDate = @batchDate,");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId,");
                                        sSQL.AppendLine("       releasingDate = @releasingDate,");
                                        sSQL.AppendLine("       auditedById = @auditedById,");
                                        sSQL.AppendLine("       auditedDate = GETDATE()");
                                        sSQL.AppendLine("WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                                        sSQL.AppendLine("END");
                                    }
                                    break;
                                case Declaration.EPV_STATUS_ID_FOR_RELEASING:
                                    if (txtReleasedBy.Text.Trim() != "")
                                    {
                                        sSQL.AppendLine("IF @releasedById <> -1");
                                        sSQL.AppendLine("BEGIN");

                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_RELEASED);

                                        sSQL.AppendLine("UPDATE EPV");
                                        sSQL.AppendLine("   SET batchDate = @batchDate,");
                                        sSQL.AppendLine("       epvStatusId = @epvStatusId,");
                                        sSQL.AppendLine("       releasingDate = @releasingDate,");
                                        sSQL.AppendLine("       releasedById = @releasedById,");
                                        sSQL.AppendLine("       releasedDate = @releasedDate");
                                        sSQL.AppendLine("WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");

                                        sSQL.AppendLine("END");
                                    }
                                    else
                                    {
                                        sSQL.AppendLine("IF @uploadedById <> -1");
                                        sSQL.AppendLine("BEGIN");

                                        sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_UPLOADED);

                                        sSQL.AppendLine("UPDATE EPV");
                                        sSQL.AppendLine("   SET batchDate = @batchDate,");
                                        sSQL.AppendLine("   epvStatusId = @epvStatusId,");
                                        sSQL.AppendLine("   releasingDate = @releasingDate,");
                                        sSQL.AppendLine("   uploadedById = @uploadedById,");
                                        sSQL.AppendLine("   uploadedDate = @uploadedDate");
                                        sSQL.AppendLine("WHERE epvId = @epvId");
                                        sSQL.AppendLine("   AND chargeToId = @chargeToId");

                                        sSQL.AppendLine("END");
                                    }
                                    break;
                                case Declaration.EPV_STATUS_ID_UPLOADED:
                                    sSQL.AppendLine("IF @releasedById <> -1");
                                    sSQL.AppendLine("BEGIN");

                                    sSQL.AppendLine("SELECT @epvStatusId = " + Declaration.EPV_STATUS_ID_RELEASED);

                                    sSQL.AppendLine("UPDATE EPV");
                                    sSQL.AppendLine("   SET batchDate = @batchDate,");
                                    sSQL.AppendLine("   epvStatusId = @epvStatusId,");
                                    sSQL.AppendLine("   releasingDate = @releasingDate,");
                                    sSQL.AppendLine("   releasedById = @releasedById,");
                                    sSQL.AppendLine("   releasedDate = @releasedDate");
                                    sSQL.AppendLine("WHERE epvId = @epvId");
                                    sSQL.AppendLine("   AND chargeToId = @chargeToId");

                                    sSQL.AppendLine("END");
                                    break;
                            }

                            //string chargeToName = System.Text.RegularExpressions.Regex.Replace(cboChargeTo.Text.Split(':')[0], @"[^0-9a-zA-Z]+", "");
                            //string chargeToCode = cboChargeTo.Text.Split(':')[1];

                            //sSQL.AppendLine("IF @formNumber = ''");
                            //sSQL.AppendLine("BEGIN");
                            //sSQL.AppendLine("   DECLARE @formNo VARCHAR(4) = ''");
                            //sSQL.AppendLine("   SELECT @formNo = SUBSTRING(formNumber, (LEN(formNumber) - 3), 4) FROM EPV WHERE epvId = @epvId  AND formNumber <> ''");
                            //sSQL.AppendLine("IF @formNo <> ''");
                            //sSQL.AppendLine("BEGIN");
                            //sSQL.AppendLine("   DECLARE @epv" + cboTransactionType.Text + "Id INT ");
                            //sSQL.AppendLine("   SELECT @formNumber =" + (chargeToCode + "-" + cboTransactionType.Text.Substring(0, 1) + DateTime.Now.Year.ToString().Substring(2, 2) + "-").sQuote() + " + @formNo");
                            //sSQL.AppendLine("END");
                            //sSQL.AppendLine("ELSE");
                            //sSQL.AppendLine("BEGIN");
                            //sSQL.AppendLine(    function.GenerateIdScript("epv" + cboTransactionType.Text + "Id"));
                            //sSQL.AppendLine("   SELECT @formNumber =" + (chargeToCode + "-" + cboTransactionType.Text.Substring(0, 1) + DateTime.Now.Year.ToString().Substring(2, 2) + "-").sQuote() + " + FORMAT(@epv" + cboTransactionType.Text + "Id, '0000') ");
                            //sSQL.AppendLine("END");
                            //sSQL.AppendLine("END");
                        }

                        totalAmount = 0;

                        foreach (DataGridViewRow row in dgvList.Rows)
                        {
                            if (Convert.ToInt32(row.Cells[IX_GRID_CHARGE_TO_ID].Value) == Convert.ToInt32(cboChargeTo.SelectedValue)
                                 && Convert.ToBoolean(row.Cells[IX_GRID_IS_ACTIVE].Value))
                            {
                                totalAmount += Convert.ToDecimal(row.Cells[IX_GRID_AMOUNT].Value); 
                            }
                        }
                
                        sSQL.AppendLine("UPDATE EPV");
                        sSQL.AppendLine("SET");
                        sSQL.AppendLine("   businessPurposeId = @businessPurposeId,");
                        sSQL.AppendLine("   bpOthers = @bpOthers,");
                        sSQL.AppendLine("   costCenterId = @costCenterId,");
                        sSQL.AppendLine("   storeId = @storeId,");
                        sSQL.AppendLine("   transactionTypeId = @transactionTypeId,");
                        sSQL.AppendLine("   chargeToId = @chargeToId,");
                        sSQL.AppendLine("   modeOfPaymentId = @modeOfPaymentId,");
                        sSQL.AppendLine("   caId = @caId,");
                        sSQL.AppendLine("   totalExpense = " + totalAmount + ",");
                        if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                        { sSQL.AppendLine("   cashOverUnder = " + cashOver + ","); }
                        else
                        { sSQL.AppendLine("   cashOverUnder = 0,"); }
                        sSQL.AppendLine("   requestDate = @requestDate,");
                        if (txtPastRemark.Text.Trim() == "")
                        { sSQL.AppendLine("   remark = @remark,"); }
                        else
                        { sSQL.AppendLine("   remark = remark + ' | ' + @remark,"); }
                        sSQL.AppendLine("   updateBy = @username,");
                        sSQL.AppendLine("   updateDate = GETDATE()");
                        sSQL.AppendLine("WHERE epvId = @epvId");
                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                    }
                    else //SAVE
                    {
                        totalAmount = 0;

                        foreach (DataGridViewRow row in dgvList.Rows)
                        {
                            if (Convert.ToInt32(row.Cells[IX_GRID_CHARGE_TO_ID].Value) == Convert.ToInt32(cboChargeTo.SelectedValue) && Convert.ToBoolean(row.Cells[IX_GRID_IS_ACTIVE].Value))
                            { totalAmount += Convert.ToDecimal(row.Cells[IX_GRID_AMOUNT].Value); }
                        }

                        sSQL.AppendLine("UPDATE EPV");
                        sSQL.AppendLine("SET");
                        sSQL.AppendLine("   businessPurposeId = @businessPurposeId,");
                        sSQL.AppendLine("   bpOthers = @bpOthers,");
                        sSQL.AppendLine("   costCenterId = @costCenterId,");
                        sSQL.AppendLine("   storeId = @storeId,");
                        sSQL.AppendLine("   transactionTypeId = @transactionTypeId,");
                        sSQL.AppendLine("   chargeToId = @chargeToId,");
                        sSQL.AppendLine("   modeOfPaymentId = @modeOfPaymentId,");
                        sSQL.AppendLine("   caId = @caId,");
                        sSQL.AppendLine("   totalExpense = " + totalAmount + ",");
                        if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                        { sSQL.AppendLine("   cashOverUnder = " + (totalAmount - caAmount).ToString() + ","); }
                        sSQL.AppendLine("   remark = @remark,");
                        sSQL.AppendLine("   requestDate = @requestDate,");
                        sSQL.AppendLine("   updateBy = @username,");
                        sSQL.AppendLine("   updateDate = GETDATE()");
                        sSQL.AppendLine("WHERE epvId = @epvId");
                        sSQL.AppendLine("   AND chargeToId = @chargeToId");
                    }

                    if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                    {
                        if (Convert.ToInt32(cboChargeTo.SelectedValue) == Convert.ToInt32(txtCAStatus.Tag))
                        {
                            sSQL.AppendLine("UPDATE CashAdvance");
                            sSQL.AppendLine("SET");
                            sSQL.AppendLine("   cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_LIQUIDATED + ",");
                            sSQL.AppendLine("   dateLiquidated = GETDATE(), ");
                            sSQL.AppendLine("   updateBy = @username, ");
                            sSQL.AppendLine("   updateDate = GETDATE() ");
                            sSQL.AppendLine("WHERE caId = @caId");
                            sSQL.AppendLine("   AND chargeToId = " + cboChargeTo.SelectedValue);
                        }
                    }
                }
                             
                //EPV DETAIL

                sSQL.AppendLine("DECLARE @transactionDate DATE ");
                sSQL.AppendLine("DECLARE @particulars VARCHAR(250)");
                sSQL.AppendLine("DECLARE @natureOfExpenseId INT");
                sSQL.AppendLine("DECLARE @amount DECIMAL(18,2)");
                sSQL.AppendLine("DECLARE @vendorId INT");
                sSQL.AppendLine("DECLARE @referenceNumber VARCHAR(60)");
                sSQL.AppendLine("DECLARE @vatAmount DECIMAL(18,2)");
                sSQL.AppendLine("DECLARE @claimToId INT");
                sSQL.AppendLine("DECLARE @lineNumber INT");
                sSQL.AppendLine("DECLARE @chargeToAmount DECIMAL(18,2)");
                sSQL.AppendLine("DECLARE @isActive BIT");

                sSQL.AppendLine("DELETE FROM EPVDetail WHERE epvId = @epvId");

                int lineNumber = 0;
                decimal amount = 0;

                foreach (DataGridViewRow row in dgvList.Rows)
                {
                    amount = decimal.Parse(row.Cells[IX_GRID_AMOUNT].Value.ToString(), System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowLeadingSign);
                    lineNumber = lineNumber + 1;

                    sSQL.AppendLine("SELECT @lineNumber = " + lineNumber);
                    sSQL.AppendLine("SELECT @transactionDate = " + row.Cells[IX_GRID_TRANSACTION_DATE].Value.ToString().sQuote());
                    sSQL.AppendLine("SELECT @natureOfExpenseId = " + row.Cells[IX_GRID_NATURE_OF_EXPENSE_ID].Value);
                    sSQL.AppendLine("SELECT @particulars = " + row.Cells[IX_GRID_PARTICULARS].Value.ToString().sQuote());
                    sSQL.AppendLine("SELECT @amount  = " + amount);

                    sSQL.AppendLine("SELECT @vendorId = " + row.Cells[IX_GRID_VENDOR_ID].Value);
                    sSQL.AppendLine("SELECT @chargeToId = " + row.Cells[IX_GRID_CHARGE_TO_ID].Value);
                    sSQL.AppendLine("SELECT @referenceNumber = " + row.Cells[IX_GRID_REFERENCE_NUMBER].Value.ToString().sQuote());
                    sSQL.AppendLine("SELECT @vatAmount = " + decimal.Parse(row.Cells[IX_GRID_VAT_AMOUNT].Value.ToString(), System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands));
                    sSQL.AppendLine("SELECT @claimToId = " + row.Cells[IX_GRID_CLAIM_TO_ID].Value);
                    sSQL.AppendLine("SELECT @isActive = " + Convert.ToInt32(row.Cells[IX_GRID_IS_ACTIVE].Value));

                    sSQL.AppendLine("INSERT INTO EPVDetail(lineNumber, epvId, chargeToId, transactionDate, natureOfExpenseId, particulars, ");
                    sSQL.AppendLine("amount, vendorId, referenceNumber, vatAmount, claimToId, isActive, createBy, createDate)");
                    sSQL.AppendLine("VALUES(@lineNumber, @epvId, @chargeToId, @transactionDate, @natureOfExpenseId, @particulars,");
                    sSQL.AppendLine("@amount, @vendorId, @referenceNumber, @vatAmount, @claimToId, @isActive, @username, GETDATE())");
                }

                sSQL.AppendLine(common.SaveActiviyLog("EPV", lblStatus.Text + " | MODE : " + modeCode, "@formNumber"));

                using (SQLDB sql = new SQLDB())
                { sql.ExecuteNonQuery(sSQL.ToString(), CommandType.Text, pEPVId); }

                mvEPVId = Convert.ToInt32(pEPVId.Value.ToString());
                mvChargeToId = Convert.ToInt32(cboChargeTo.SelectedValue);    
                mvSave = true;

                Form openfrm = Application.OpenForms["frmMain"];
                if (openfrm != null)
                {
                    frmMain frm = (frmMain)openfrm;
                    frm.EPVCountStatus();
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        private void ValidateInfo()
        {
            try
            {
                string modeOfPayment = cboModeOfPayment.Text;
                int currentStatus = Convert.ToInt32(lblStatus.Tag);

                // ******************************
                if (txtRequestBy.Text.Trim() == "")
                {
                    txtRequestBy.Focus();
                    throw new Exception("Name is required.");
                }

                if (cboBusinessPurpose.Text.Trim() == "")
                {
                    cboBusinessPurpose.Focus();
                    throw new Exception("Business Purpose is required.");
                }

                if (cboDepartment.Text.Trim() == "")
                {
                    cboDepartment.Focus();
                    throw new Exception("Department is required.");
                }                              

                if (cboStores.Text.Trim() == "")
                {
                    txtStore.Focus();
                    throw new Exception("Please select a store.");
                }

                if (chkBoxChargeTo.Visible && mvEPVId == -1)
                {
                    btnSaveMultiple.Focus();
                    throw new Exception("Charge To is not Set.");
                }

                if (cboTransactionType.Text.Trim() == "")
                {
                    cboTransactionType.Focus();
                    throw new Exception("Transaction Type is required.");
                }

                if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID && (txtCAStatus.Text != "RECEIVED" && txtCAStatus.Text != "LIQUIDATED"))
                {
                    txtCA.Focus();
                    throw new Exception("CA # is required.");
                }

                if (dgvList.RowCount == 0)
                {
                    dgvList.Focus();
                    throw new Exception("Please add EPV Details.");
                }
                
                if (txtUploadedBy.Text == "" && currentStatus == Declaration.EPV_STATUS_ID_FOR_RELEASING &&
                    (common.ModeOfPaymentUploading(Convert.ToInt32(cboModeOfPayment.SelectedValue))
                    && decimal.Parse(txtCashOver.Text, System.Globalization.NumberStyles.AllowDecimalPoint 
                    | System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Any) >= 0)
                    && txtReleasedBy.Text != "")
                {
                    throw new Exception("Not yet uploaded.");
                }
                
                if (txtHeadApprovedBy.Text == "" && txtAuditedBy.Text != "" && currentStatus == Declaration.EPV_STATUS_ID_FOR_AUDIT)
                {
                    throw new Exception("Must be approved before audited.");
                }

                if (cboBusinessPurpose.SelectedValue.ToString() == "0" && txtBusinessOthers.Text.Trim() == "")
                {
                    txtBusinessOthers.Focus();
                    throw new Exception("Please fill in the other details.");
                }

                if (remarkRequired && (currentStatus != Declaration.EPV_STATUS_ID_SAVED && currentStatus != Declaration.EPV_STATUS_ID_NEW))
                {
                    if (txtRemarks.Text.Trim() == "")
                    {
                        txtRemarks.Focus();
                        throw new Exception("Changes has been made. Remark is required.");
                    }
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        private void ToggleGeneralInfo(bool r)
        {
            cboBusinessPurpose.Enabled = r;
            txtBusinessOthers.Enabled = r;
            cboDepartment.Enabled = r;
            txtStore.ReadOnly = !r;
            cboStores.Enabled = r;
        }

        private void DisableALL()
        {
            txtStore.Clear();
            dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
            btnSubmit.Visible = false;
            btnPrint.Visible = true;
            dtpHeadApproved.Enabled = false;
            //btnAdd.Visible = false;
            btnAddMultiple.Visible = false;
            btnEditDestination.Visible = false;
            btnSave.Visible = false;
            
            pnlVAT.Enabled = false;       
            btnDelete.Visible = false;

            btnAccept.Visible = false;
            btnDecline.Visible = false;
            txtRemarks.ReadOnly = true;
            btnReturn.Visible = false;

            lblNatureOfExpense.BackColor = default(System.Drawing.Color);
            lblParticulars.BackColor = default(System.Drawing.Color);
            lblAmount.BackColor = default(System.Drawing.Color);
            lblTransDate.BackColor = default(System.Drawing.Color);
        }

        private void EnableControls(bool t)
        {
            btnSave.Visible = t;
            btnSubmit.Visible = t;
            btnAccept.Visible = t;
            btnDecline.Visible = t;
            btnReturn.Visible = t;

            cboModeOfPayment.Enabled = t;
            btnAccept.Visible = t;
            btnDecline.Visible = t;
            btnSubmit.Visible = t;
            btnSave.Visible = t;
            btnReturn.Visible = t;
            btnDelete.Visible = t;

            btnSearchHeadApprover.Visible = t;
            dtpHeadApproved.Enabled = t;

            btnSearchMgtApprover.Visible = t;
            dtpMgtApproved.Enabled = t;

            btnSearchDocsReceived.Visible = t;
            dtpDocsReceived.Enabled = t;

            btnSearchAuditedBy.Visible = t;
            dtpAudited.Enabled = t;

            btnSearchUploadedBy.Visible = t;
            dtpUploadedBy.Enabled = t;

            btnSearchReleasedBy.Visible = t;
            dtpReleased.Enabled = t;
        }

        private void FormatObjects()
        {
            txtRemarks.Clear();

            pnlRequired.BackColor = Declaration.reqBackColor;

            int currentStatus = Convert.ToInt32(lblStatus.Tag);

            ToggleGeneralInfo(true);

            EnableControls(false);

            txtHeadApprovedBy.BackColor = default(System.Drawing.Color);
            txtMgtApprovedBy.BackColor = default(System.Drawing.Color);
            txtDocsReceivedBy.BackColor = default(System.Drawing.Color);
            txtAuditedBy.BackColor = default(System.Drawing.Color);
            txtUploadedBy.BackColor = default(System.Drawing.Color);
            txtReleasedBy.BackColor = default(System.Drawing.Color);
            lblModeOfPayment.BackColor = default(System.Drawing.Color);
            lblCA.BackColor = default(System.Drawing.Color);
            lblTransDate.BackColor = default(System.Drawing.Color);
                   
            pnlVAT.Enabled = false;
            txtRemarks.ReadOnly = false;
            dgvList.Columns[IX_GRID_CHARGE_TO_NAME].Visible = false;
            dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = false;
            toolStrip.Text = "";

            if (isMultiple)
            {
                btnSaveMultiple.Visible = false;
                chkPartChargeTo.Visible = true;
                chkDestChargeTo.Visible = true;
                dgvList.Columns[IX_GRID_CHARGE_TO_NAME].Visible = true;
            }

            //SetChargeTo();

            switch (currentStatus)
            {
                case Declaration.EPV_STATUS_ID_NEW:
                case Declaration.EPV_STATUS_ID_SAVED: 
                    if (Convert.ToInt32(txtRequestBy.Tag) == common.GetEmployeeId())
                    {
                        btnDelete.Visible = true;
                        btnSave.Visible = true;
                        btnSubmit.Visible = true;
                        btnPrint.Visible = false;
                        cboTransactionType.Enabled = true;
                        lblParticulars.BackColor = Declaration.reqBackColor;
                        lblAmount.BackColor = Declaration.reqBackColor;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;
                        toolStrip.Text = "Submit[Ctrl + B] | ";
                    }
                    else
                    {
                        DisableALL();
                        btnPrint.Visible = false;
                    }

                    btnSubmit.Visible = true;
                    break;

                case Declaration.EPV_STATUS_ID_FOR_APPROVAL:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_APPROVAL, GlobalSettings.ACCESS_WRITE))
                    {                   
                        txtHeadApprovedBy.Text = GlobalSettings.UserFullName;
                        txtHeadApprovedBy.Tag = common.GetEmployeeId();
                        dtpHeadApproved.Enabled = true;
                        txtHeadApprovedBy.BackColor = Declaration.reqBackColor;

                        if (Declaration.USER_TYPE.Contains(Declaration.GROUP_ACCOUNTING)
                            || Declaration.USER_TYPE.Contains(Declaration.GROUP_TREASURY))
                        { btnSearchHeadApprover.Visible = true; }

                        if (Convert.ToDecimal(txtTotalExpense.Text) > Declaration.AMOUNT_LIMIT
                            && (Declaration.USER_TYPE.Contains(Declaration.GROUP_ACCOUNTING)
                            || Declaration.USER_TYPE.Contains(Declaration.GROUP_TREASURY)))
                        {
                            btnSearchMgtApprover.Visible = true;
                            dtpMgtApproved.Enabled = true;
                            txtMgtApprovedBy.BackColor = Declaration.reqBackColor;
                        }

                        if (Convert.ToDecimal(txtTotalExpense.Text) > Declaration.AMOUNT_LIMIT 
                            && Declaration.USER_TYPE.Contains(Declaration.GROUP_ALL_DEPARTMENT))
                        {
                            txtMgtApprovedBy.Text = GlobalSettings.UserFullName;
                            txtMgtApprovedBy.Tag = common.GetEmployeeId();
                            dtpMgtApproved.Enabled = true;
                            txtMgtApprovedBy.BackColor = Declaration.reqBackColor;
                        }

                        btnSave.Visible = false;
                        btnReturn.Visible = true;
                        btnAccept.Visible = true;
                        btnDecline.Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;
                        btnPrint.Visible = true;
                    }
                    else
                    {
                        DisableALL();
                    }
              
                    break;

                case Declaration.EPV_STATUS_ID_APPROVED:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_RECEIVING, GlobalSettings.ACCESS_WRITE))
                    {
                        txtDocsReceivedBy.Text = GlobalSettings.UserFullName;
                        txtDocsReceivedBy.Tag = common.GetEmployeeId();
                        dtpDocsReceived.Enabled = true;
                        txtDocsReceivedBy.BackColor = Declaration.reqBackColor;

                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;

                        cboModeOfPayment.Enabled = true;
                        lblModeOfPayment.BackColor = Declaration.reqBackColor;

                        btnReturn.Visible = true;
                        btnSubmit.Visible = true;
                        btnPrint.Visible = true;
                        btnAccept.Visible = false;
                        btnDecline.Visible = false;
                        btnSave.Visible = false;
                        btnReturn.Visible = false;
                        toolTip.SetToolTip(btnSubmit, "Receive Docs");
                        btnSearchDocsReceived.Visible = true;
                        dtpDocsReceived.Enabled = true;                       
                        toolStrip.Text = "Received Docs[Ctrl + B] | ";
                    }
                    else
                    { DisableALL(); }
                    break;
                case Declaration.EPV_STATUS_ID_FOR_AUDIT:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_AUDIT, GlobalSettings.ACCESS_WRITE))
                    {
                        txtAuditedBy.Text = GlobalSettings.UserFullName;
                        txtAuditedBy.Tag = common.GetEmployeeId();
                        dtpAudited.Enabled = true;
                        txtAuditedBy.BackColor = Declaration.reqBackColor;

                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;

                        pnlVAT.Enabled = true;

                        cboModeOfPayment.Enabled = false;
                        btnPrint.Visible = true;
                        btnAccept.Visible = true;
                        btnDecline.Visible = true;
                        btnSubmit.Visible = false;
                        btnSave.Visible = false;
                        btnReturn.Visible = true;
                        ToggleGeneralInfo(true);
                    }
                    else
                    { DisableALL(); }
                    break;
                case Declaration.EPV_STATUS_ID_FOR_RELEASING:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_RELEASING, GlobalSettings.ACCESS_WRITE))
                    {
                        btnSubmit.Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].ReadOnly = false;
                        btnPrint.Visible = true;
                        btnAccept.Visible = false;
                        btnDecline.Visible = true; 
                        btnSave.Visible = true;
                        btnReturn.Visible = true;
                        cboModeOfPayment.Enabled = false;

                        if ((common.ModeOfPaymentUploading(Convert.ToInt32(cboModeOfPayment.SelectedValue)) && decimal.Parse(txtCashOver.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Any) >= 0) || cboModeOfPayment.Text == "Cash Card")
                        {
                            txtUploadedBy.Text = GlobalSettings.UserFullName;
                            txtUploadedBy.Tag = common.GetEmployeeId();
                            dtpUploadedBy.Enabled = true;
                            txtUploadedBy.BackColor = Declaration.reqBackColor;
                            toolTip.SetToolTip(btnSubmit, "Set as Uploaded");
                            toolStrip.Text = "Set as Uploaded[Ctrl + B] | ";
                        }
                        else 
                        {
                            txtReleasedBy.Text = GlobalSettings.UserFullName;
                            txtReleasedBy.Tag = common.GetEmployeeId();
                            dtpReleased.Enabled = true;
                            txtReleasedBy.BackColor = Declaration.reqBackColor;
                            toolTip.SetToolTip(btnSubmit, "Set as Released");
                            toolStrip.Text = "Set as Released[Ctrl + B] | ";
                        }                    
                    }
                    else
                    { DisableALL(); }
                    break;
                case Declaration.EPV_STATUS_ID_UPLOADED:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_RELEASING, GlobalSettings.ACCESS_WRITE))
                    {
                        btnSubmit.Visible = true;
                        dgvList.Columns[IX_GRID_IS_ACTIVE].Visible = true;
                        btnPrint.Visible = true;
                        btnAccept.Visible = false;
                        btnDecline.Visible = false;
                        btnSave.Visible = true;
                        cboModeOfPayment.Enabled = false;
                        dtpUploadedBy.Enabled = true;

                        txtReleasedBy.Text = GlobalSettings.UserFullName;
                        txtReleasedBy.Tag = common.GetEmployeeId();
                        dtpReleased.Enabled = true;
                        txtReleasedBy.BackColor = Declaration.reqBackColor;
                        toolStrip.Text = "Set as Released[Ctrl + B] | ";
                    }
                    else
                    { DisableALL(); }
                    break;
                case Declaration.EPV_STATUS_ID_RELEASED:
                    if (function.HasAccess(Declaration.MOD_CODE_FOR_RELEASING, GlobalSettings.ACCESS_WRITE))
                    {
                        btnSubmitEmail.Visible = true;
                    }
                    break;
                default:
                    DisableALL();
                    break;
            }

            if (btnAccept.Visible)
            { toolStrip.Text += "Accept[Ctrl+T] | "; }
            if (btnDecline.Visible)
            { toolStrip.Text += "Decline[Ctrl+D] | "; }
            if (btnSave.Visible)
            { toolStrip.Text += "Save[Ctrl+S] | "; }
            if (btnPrint.Visible)
            { toolStrip.Text += "Print[Ctrl+P] | "; }
            if (btnReturn.Visible)
            { toolStrip.Text += "Return[Ctrl+R] | "; }
            if (btnAdd.Visible)
            { toolStrip.Text += "Add Detail[Ctrl+A] | "; }

            if (Declaration.USER_TYPE.Contains(Declaration.GROUP_TREASURY) && mvEPVId != -1)
            {
                cboDepartment.Enabled = false;
                cboBusinessPurpose.Enabled = false;
                cboStores.Enabled = false;
                switch (Convert.ToInt32(lblStatus.Tag))
                {
                    case Declaration.EPV_STATUS_ID_FOR_RELEASING:
                    case Declaration.CA_STATUS_ID_APPROVED:
                        btnSave.Visible = true;
                        //btnSave.Location = new Point(853, 292);
                        break;
                }
            }
            
            if (Declaration.USER_TYPE.Contains(Declaration.GROUP_ADMINISTRATIVE) && mvEPVId != -1)
            {
                cboModeOfPayment.Enabled = true;
                cboDepartment.Enabled = true;
                cboBusinessPurpose.Enabled = true;
                cboStores.Enabled = true;
                dtpBatchDate.Enabled = true;
                dtpReleasingDate.Enabled = true;   

                switch (Convert.ToInt32(lblStatus.Tag))
                {     
                    case Declaration.EPV_STATUS_ID_FOR_APPROVAL:
                        //btnSave.Visible = true;
                        //btnSave.Location = new Point(801, 292);
                        break;
                    case Declaration.EPV_STATUS_ID_FOR_AUDIT:
                    case Declaration.EPV_STATUS_ID_APPROVED:
                    case Declaration.EPV_STATUS_ID_FOR_RELEASING:
                    case Declaration.EPV_STATUS_ID_UPLOADED:                     
                    case Declaration.EPV_STATUS_ID_SAVED:
                        btnSave.Visible = true;
                        //btnSave.Location = new Point(853, 292);
                        if (txtReleasedBy.BackColor == Declaration.reqBackColor)
                        { btnSearchReleasedBy.Visible = true; }
                        if (txtUploadedBy.BackColor == Declaration.reqBackColor)
                        { btnSearchUploadedBy.Visible = true; }
                        if (txtAuditedBy.BackColor == Declaration.reqBackColor)
                        { btnSearchAuditedBy.Visible = true; }
                        break;
                }
            }
        }

        private void LoadDetail()
        {
            DataTable[] listTable = { mainDT, detailDT };
            mainDT.Clear();
            detailDT.Clear();
            try
            {
                string sSQL = "proc_EPVDetail";

                SqlParameter pEPVId = new SqlParameter("@epvId", SqlDbType.Int);
                pEPVId.Value = mvEPVId;

                using (SQLDB sql = new SQLDB())
                { sql.GetDT(ref listTable, sSQL, CommandType.StoredProcedure, pEPVId); }

                var strChargeToId = "";

                for (int i = 0; i < mainDT.Rows.Count; i++)
                {
                    if (strChargeToId != "")
                    { strChargeToId = strChargeToId + ", " + mainDT.Rows[i]["chargeToId"].ToString(); }
                    else
                    { strChargeToId = mainDT.Rows[i]["chargeToId"].ToString(); }
                }

                cboChargeTo.DataSource = comboChargeTo.Select("chargeToId IN ( " + strChargeToId + ")").CopyToDataTable();
                cboChargeTo.DisplayMember = "chargeToName";
                cboChargeTo.ValueMember = "chargeToId";

                if (cboChargeTo.Items.Count > 1)
                {
                    isMultiple = true;

                    chkPartChargeTo.DataSource = cboChargeTo.Items;
                    chkPartChargeTo.DisplayMember = "chargeToName";
                    chkPartChargeTo.ValueMember = "chargeToId";

                    chkPartChargeTo.Visible = true;
                    lblPartChargeTo.Visible = true;
                    txtParticulars.Width = 244;
                    lblParticulars.Width = 244;

                    txtTotalExpense.Location = new Point(793, 183);
                    txtTotalExpense.Width = 92;
                    lblOF.Visible = true;
                    txtTotalExpenses.Visible = true;


                }
                else
                {
                    txtTotalExpense.Location = new Point(833, 183);
                    txtTotalExpense.Width = 146;
                    lblOF.Visible = false;
                    txtTotalExpenses.Visible = false;
                }

                if (mvChargeToId == -1)
                { cboChargeTo.SelectedIndex = 0; }
                else
                { cboChargeTo.SelectedValue = mvChargeToId; }

                SelectChargeTo();


                dgvList.Rows.Clear();

                detailDT.DefaultView.Sort = "lineNumber";
                detailDT = detailDT.DefaultView.ToTable();
                detailDT.Columns["isActive"].ReadOnly = false;

                foreach (DataRow dr in detailDT.Rows)
                {
                    dgvList.Rows.Add("");
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_TRANSACTION_DATE].Value = Convert.ToDateTime(dr["transactionDate"]).ToString("MM/dd/yyyy");
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_NATURE_OF_EXPENSE_ID].Value = dr["natureOfExpenseId"].ToString();
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_NATURE_OF_EXPENSE].Value = dr["natureOfExpenseName"].ToString();
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_PARTICULARS].Value = dr["particulars"].ToString();
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_CHARGE_TO_NAME].Value = dr["chargeToName"].ToString();
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_AMOUNT].Value = function.FormatDouble(dr["amount"].ToString());
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_VENDOR_ID].Value = dr["vendorId"];
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_VENDOR_NAME].Value = dr["vendorName"];
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_TIN].Value = dr["tin"];
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_REFERENCE_NUMBER].Value = dr["referenceNumber"];
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_VAT_AMOUNT].Value = dr["vatAmount"];
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_CLAIM_TO_ID].Value = dr["claimToId"];
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_ADDRESS].Value = dr["vendorAddress"];
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_CHARGE_TO_ID].Value = dr["chargeToId"];
                    dgvList.Rows[dgvList.RowCount - 1].Cells[IX_GRID_IS_ACTIVE].Value = Convert.ToBoolean(dr["isActive"]);    
                }

                dgvList.Columns["isActive"].ReadOnly = false;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void SelectChargeTo()
        {
            if (mainDT.Rows.Count != 0)
            {
                DataTable dtMain = mainDT.Select("chargeToId = " + cboChargeTo.SelectedValue).CopyToDataTable();

                lblStatus.Tag = dtMain.Rows[0]["epvStatusId"].ToString();
                lblStatus.Text = "CURRENT STATUS : " + dtMain.Rows[0]["epvStatusName"].ToString();
                txtFormNumber.Text = dtMain.Rows[0]["formNumber"].ToString();
                cboModeOfPayment.Tag = dtMain.Rows[0]["modeOfPaymentId"].ToString();
                cboModeOfPayment.Text = dtMain.Rows[0]["modeOfPaymentCode"].ToString();
                dtpRequested.Text = dtMain.Rows[0]["requestDate"].ToString();
                cboTransactionType.Tag = dtMain.Rows[0]["transactionTypeId"].ToString();
                cboTransactionType.Text = dtMain.Rows[0]["transactionTypeName"].ToString();
                cboChargeTo.SelectedValue = dtMain.Rows[0]["chargeToId"].ToString();
                txtRequestBy.Tag = dtMain.Rows[0]["employeeId"].ToString();
                txtRequestBy.Text = dtMain.Rows[0]["requestedByName"].ToString();
                cboBusinessPurpose.SelectedValue = dtMain.Rows[0]["businessPurposeId"].ToString();
                cboBusinessPurpose.Text = dtMain.Rows[0]["businessPurposeName"].ToString();
                txtBusinessOthers.Text = dtMain.Rows[0]["bpOthers"].ToString();
                cboDepartment.Tag = dtMain.Rows[0]["costCenterId"].ToString();
                cboDepartment.Text = dtMain.Rows[0]["costCenterName"].ToString();
                cboStores.Tag = dtMain.Rows[0]["storeId"].ToString();
                cboStores.Text = dtMain.Rows[0]["storeName"].ToString();
                txtCA.Tag = dtMain.Rows[0]["caId"].ToString();
                txtCA.Text = dtMain.Rows[0]["caNumber"].ToString();
                txtCAStatus.Text = dtMain.Rows[0]["caStatus"].ToString();
                txtCAStatus.Tag = dtMain.Rows[0]["caChargeToId"].ToString() == "" ? "-1" : dtMain.Rows[0]["caChargeToId"].ToString();
                txtCashAdvance.Text = function.FormatDouble(dtMain.Rows[0]["caAmount"].ToString());
                txtTotalExpense.Text = function.FormatDouble(dtMain.Rows[0]["totalExpense"].ToString());
                txtCashOver.Text = function.FormatDouble(dtMain.Rows[0]["cashOverUnder"].ToString());

                txtRequestBy.Tag = dtMain.Rows[0]["employeeId"].ToString();
                txtRequestBy.Text = dtMain.Rows[0]["employeeName"].ToString();

                dtpRequested.Text = dtMain.Rows[0]["requestDate"].ToString();

                txtHeadApprovedBy.Tag = dtMain.Rows[0]["headApprovedById"].ToString();
                txtHeadApprovedBy.Text = dtMain.Rows[0]["headApprovedByName"].ToString();

                txtMgtApprovedBy.Tag = dtMain.Rows[0]["mgtApprovedById"].ToString();
                txtMgtApprovedBy.Text = dtMain.Rows[0]["mgtApprovedByName"].ToString();

                if (txtHeadApprovedBy.Text.Trim() != "")
                {
                    dtpHeadApproved.Text = dtMain.Rows[0]["headApprovedDate"].ToString();
                    dtpReleasingDate.Text = dtMain.Rows[0]["releasingDate"].ToString();
                    dtpBatchDate.Text = dtMain.Rows[0]["batchDate"].ToString();
                }

                if (txtMgtApprovedBy.Text.Trim() != "")
                {
                    dtpMgtApproved.Text = dtMain.Rows[0]["mgtApprovedDate"].ToString();
                }

                txtDocsReceivedBy.Tag = dtMain.Rows[0]["receivedByAcctId"].ToString();
                txtDocsReceivedBy.Text = dtMain.Rows[0]["receivedByAccountingName"].ToString();
                if (txtDocsReceivedBy.Text.Trim() != "")
                { dtpDocsReceived.Text = dtMain.Rows[0]["receivedByAcctDate"].ToString(); }

                txtAuditedBy.Tag = dtMain.Rows[0]["auditedById"].ToString();
                txtAuditedBy.Text = dtMain.Rows[0]["auditedByName"].ToString();
                if (txtAuditedBy.Text.Trim() != "")
                { dtpAudited.Text = dtMain.Rows[0]["auditedDate"].ToString(); }

                txtUploadedBy.Tag = dtMain.Rows[0]["uploadedById"].ToString();
                txtUploadedBy.Text = dtMain.Rows[0]["uploadedByName"].ToString();
                if (txtUploadedBy.Text.Trim() != "")
                { dtpUploadedBy.Text = dtMain.Rows[0]["uploadedDate"].ToString(); }

                txtReleasedBy.Tag = dtMain.Rows[0]["releasedById"].ToString();
                txtReleasedBy.Text = dtMain.Rows[0]["releasedByName"].ToString();

                if (txtReleasedBy.Text.Trim() != "")
                { dtpReleased.Text = dtMain.Rows[0]["releasedDate"].ToString(); }

                txtPastRemark.Text = dtMain.Rows[0]["remark"].ToString();

                if (Convert.ToInt32(lblStatus.Tag) == Declaration.EPV_STATUS_ID_REJECTED && txtAuditedBy.Text != "")
                { lblAudited.Text = "Rejected by:"; }
                else if (Convert.ToInt32(lblStatus.Tag) == Declaration.EPV_STATUS_ID_REJECTED && txtAuditedBy.Text == "")
                { lblHeadApproved.Text = "Rejected by:"; }

                cboTransactionType.Enabled = false;

                if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                {
                    if (txtCAStatus.Text == "LIQUIDATED")
                    {
                        txtCA.ReadOnly = true;
                        lblCA.BackColor = default(System.Drawing.Color);
                    }
                    else
                    {
                        txtCA.ReadOnly = false;
                        lblCA.BackColor = Declaration.reqBackColor;
                    }
                }

                FormatObjects();

                ComputeTotalExpense();
            }
        }             
               
        private void LoadComboChargeTo()
        {
            try
            {
                StringBuilder sSQL = new StringBuilder();

                sSQL.AppendLine("SELECT chargeToId, (chargeToName + ':' + chargeToCode) AS chargeToName  FROM ChargeTo");
                sSQL.AppendLine("WHERE isActive = 1");

                using (SQLDB sql = new SQLDB())
                { comboChargeTo = sql.GetDT(sSQL.ToString()); }

                cboChargeTo.DataSource = comboChargeTo;
                cboChargeTo.DisplayMember = "chargeToName";
                cboChargeTo.ValueMember = "chargeToId";

                //to set the first index as blank
                cboChargeTo.SelectedIndex = -1;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void LoadComboTransactionType()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            try
            {
                dt.Columns.Add("transactionTypeId");
                dt.Columns.Add("transactionTypeName");

                sSQL.AppendLine("SELECT [transactionTypeId], [transactionTypeName] FROM TransactionType");

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString()); }

                dt.DefaultView.Sort = "transactionTypeName";
                dt = dt.DefaultView.ToTable();

                cboTransactionType.DataSource = dt;
                cboTransactionType.DisplayMember = "transactionTypeName";
                cboTransactionType.ValueMember = "transactionTypeId";

                //to set the first index as blank
                cboTransactionType.SelectedIndex = -1;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }
        
        private void LoadComboModeOfTransportation()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();
            ComboBox[] cboModeMulti = { cboModeMulti1, cboModeMulti2, cboModeMulti3, cboModeMulti4, cboModeMulti5, cboModeMulti6, cboModeMulti7, cboModeMulti8, cboModeMulti9, cboModeMulti10, cboModeMulti11, cboModeMulti12, cboModeMulti13, cboModeMulti14 };
            try
            {
                dt.Columns.Add("modeOfTranspoId");
                dt.Columns.Add("modeOfTranspoName");

                sSQL.AppendLine("SELECT [modeOfTranspoId], [modeOfTranspoName] FROM ModeOfTransportation");
                sSQL.AppendLine("WHERE isActive = 1");

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString()); }

                dt.DefaultView.Sort = "modeOfTranspoId";
                dt = dt.DefaultView.ToTable();

                cboModeOfTransportation.DataSource = dt;
                cboModeOfTransportation.DisplayMember = "modeOfTranspoName";
                cboModeOfTransportation.ValueMember = "modeOfTranspoId";
                cboModeOfTransportation.SelectedIndex = -1;

                for (int i = 0; i < cboModeMulti.Length; i++)
                {
                    cboModeMulti[i].DataSource = dt.Copy();
                    cboModeMulti[i].DisplayMember = "modeOfTranspoName";
                    cboModeMulti[i].ValueMember = "modeOfTranspoId";
                    cboModeMulti[i].SelectedIndex = -1;
                }   
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }
        
        private void LoadComboNatureOfExpense()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            try
            {
                dt.Columns.Add("natureOfExpenseId");
                dt.Columns.Add("natureOfExpenseName");

                sSQL.AppendLine("SELECT natureOfExpenseId, natureOfExpenseName FROM NatureOfExpense");
                sSQL.AppendLine("WHERE isActive = 1");

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString()); }

                dt.DefaultView.Sort = "natureOfExpenseName";
                dt = dt.DefaultView.ToTable();

                cboNatureOfExpense.DataSource = dt;
                cboNatureOfExpense.DisplayMember = "natureOfExpenseName";
                cboNatureOfExpense.ValueMember = "natureOfExpenseId";

                //to set the first index as blank
                cboNatureOfExpense.SelectedIndex = -1;

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private void LoadComboClaimTo()
        {
            DataTable dt = new DataTable();
            StringBuilder sSQL = new StringBuilder();

            try
            {
                dt.Columns.Add("chargeToId");
                dt.Columns.Add("chargeToName");

                sSQL.AppendLine("SELECT -1 AS [chargeToId], '' AS [chargeToName]");
                sSQL.AppendLine("UNION");
                sSQL.AppendLine("SELECT [chargeToId], [chargeToName] FROM ChargeTo");
                sSQL.AppendLine("WHERE isActive = 1");

                using (SQLDB sql = new SQLDB())
                { dt = sql.GetDT(sSQL.ToString()); }                

                dt.DefaultView.Sort = "chargeToName";
                dt = dt.DefaultView.ToTable();

                cboClaimTo.DataSource = dt;
                cboClaimTo.DisplayMember = "chargeToName";
                cboClaimTo.ValueMember = "chargeToId";

                //to set the first index as blank
                cboClaimTo.SelectedValue = -1;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void frmEPVDetail_Load(object sender, EventArgs e)
        {
            common.LoadComboBusinessPurpose(ref cboBusinessPurpose);
            common.LoadComboStore(ref cboStores, ref dtStores);
            common.LoadComboModeOfPayment(ref cboModeOfPayment);
            common.LoadComboDepartment(ref cboDepartment);
            LoadComboChargeTo();
            LoadComboTransactionType();
            LoadComboNatureOfExpense();
            LoadComboModeOfTransportation();
            LoadComboClaimTo();
            
            txtRequestBy.Text = GlobalSettings.UserFullName;
            txtRequestBy.Tag = common.GetEmployeeId();

            if (cboDepartment.SelectedValue == null)
            { cboDepartment.SelectedValue = common.GetDepartmentId(); }

            if (mvEPVId != -1)
            { LoadDetail(); }

            FormatObjects();
            //btnSubmit.Visible = true;
            txtRequestBy.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_EPV, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }

                ValidateInfo();

                if (int.Parse(lblStatus.Tag.ToString()) == Declaration.EPV_STATUS_ID_APPROVED && cboModeOfPayment.SelectedValue == null)
                {
                    cboModeOfPayment.Focus();
                    throw new Exception("Mode of Payment is required.");
                }

                frmSearchApprover frm = new frmSearchApprover();

                if (Convert.ToInt32(lblStatus.Tag) == Declaration.EPV_STATUS_ID_NEW || Convert.ToInt32(lblStatus.Tag) == Declaration.EPV_STATUS_ID_SAVED)
                {
                    DialogResult strInformApprover = function.MsgBoxQuestion(this.Text, "Inform your approver thru email?");

                    if (strInformApprover == DialogResult.Yes)
                    {
                        frm.ShowDialog();

                        if (frm.DialogResult != DialogResult.OK)
                        { throw new Exception("Please select an approver."); }
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

                if (Convert.ToInt32(lblStatus.Tag) == Declaration.EPV_STATUS_ID_FOR_APPROVAL && frm.LUEmail != "")
                {

                    if (Convert.ToInt32(lblStatus.Tag) == Declaration.CA_STATUS_ID_FOR_APPROVAL && frm.LUEmail != "")
                    {
                        function.MsgBoxInfo(this.Text, "Record submission was successful.\n\rSending an email notification to the approver.\n\rPlease click OK and wait.");

                        this.Cursor = Cursors.WaitCursor;

                        StringBuilder emailMsg = new StringBuilder();
                        emailMsg.AppendLine("<div style=\"font-family:Tahoma, Verdana, sans-serif;font-weight:bold;\">");
                        emailMsg.AppendLine("<h2 style=\"color:black;\">" + cboTransactionType.Text + " Approval</h2></td>");
                        emailMsg.AppendLine("<h4 style=\"color:black;\">For your approval please:</h4>");
                        emailMsg.AppendLine("<h3 style=\"color:black;\">Header</h3>");

                        emailMsg.AppendLine("<table style=\"color:black;\">");

                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;width:120px\">EPV #:</td>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">");

                        if (cboChargeTo.Items.Count > 1)
                        {
                            var formNumberArray = txtFormNumber.Text.Split('-');

                            foreach (DataRowView row in cboChargeTo.Items)
                            {
                                emailMsg.AppendLine(row.Row.ItemArray[1].ToString().Split(':')[1]
                                        + "-" + formNumberArray[1] + "-" + (formNumberArray.Length == 3 ? formNumberArray[2] : "") + ";");
                            }
                        }
                        else
                        {
                            emailMsg.AppendLine(txtFormNumber.Text);
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
                        emailMsg.AppendLine(txtRequestBy.Text);
                        emailMsg.AppendLine("</td>");
                        emailMsg.AppendLine("</tr>");

                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">Total Expenses:</td>");
                        emailMsg.AppendLine("<td style=\"border:1px solid black;padding:5px;margin:0;\">");
                        emailMsg.AppendLine(txtTotalExpenses.Text);
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
                        emailMsg.AppendLine("<td style=\"color:black;font-size:12px;font-weight:bold\">To approve the " + cboTransactionType.Text + " please visit the link below:</td>");
                        emailMsg.AppendLine("</tr>");
                        emailMsg.AppendLine("<tr>");
                        emailMsg.AppendLine("<td>");
                        emailMsg.AppendLine("<a style=\"color:green;font-size:24px;text-decoration:none\"");
                        emailMsg.AppendLine("href =\"http://rgmcgroup.com:7171/epv/" + mvEPVId + "/" + mvChargeToId + "/" + cboTransactionType.SelectedValue + "\">");
                        emailMsg.AppendLine("Approve " + cboTransactionType.Text + "</a>");
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

                        common.SendEmail("Travel and Expense System - EPV Approval", emailMsg.ToString(), frm.LUEmail);
                    }

                    //function.MsgBoxInfo(this.Text, "Record submission was successful.\n\rSending an email notification to the approver.\n\rPlease click OK and wait.");
                    //this.Cursor = Cursors.WaitCursor;            

                    //StringBuilder emailMsg = new StringBuilder();

                    //emailMsg.AppendLine("<p>For your approval please. Transaction Type[" + cboTransactionType.Text + "]</p>");
                    //emailMsg.AppendLine("<p><b>EPV #:<br />&emsp;");
                    //emailMsg.AppendLine(txtFormNumber.Text);
                    //emailMsg.AppendLine("</b></p>");
                    //emailMsg.AppendLine("<p><b>Requested By:<br />&emsp;");
                    //emailMsg.AppendLine(txtRequestBy.Text);
                    //emailMsg.AppendLine("</b></p>");
                    //emailMsg.AppendLine("<p><b>Total Expense:<br />&emsp;PHP");
                    //emailMsg.AppendLine(txtTotalExpense.Text);
                    //emailMsg.AppendLine("</b></p>");

                    //if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                    //{
                    //    emailMsg.AppendLine("<p><b>Cash Advance:<br />&emsp;PHP");
                    //    emailMsg.AppendLine(txtCashAdvance.Text);
                    //    emailMsg.AppendLine("</b></p>");
                    //    emailMsg.AppendLine("<p><b>Cash Under/(Over):<br />&emsp;PHP");
                    //    emailMsg.AppendLine(txtCashOver.Text);
                    //    emailMsg.AppendLine("</b></p>");
                    //}
                    //emailMsg.AppendLine("<p>Please search in the Travel and Expense System the EPV # for your approval. Thank you!</p>");
                    //emailMsg.AppendLine("");
                    //emailMsg.AppendLine("<font size=\"-3\"><p>Please do not reply. System-generated email notification only.<br />");
                    //emailMsg.AppendLine("For your concerns please contact Accounting Treasury</font></p>");

                    //common.SendEmail("Travel and Expense System - EPV Approval", emailMsg.ToString(), frm.LUEmail);
                }
                else
                {
                    function.MsgBoxInfo(this.Text, "Record submission was successful.");
                }

                EmailReceivedConfirmation();

                FormatObjects();

                refresh = System.Windows.Forms.DialogResult.OK;

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { this.Cursor = Cursors.Default; }
        }

        private void EmailReceivedConfirmation()
        {
            if (Convert.ToInt32(lblStatus.Tag) == Declaration.EPV_STATUS_ID_RELEASED && Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_REIMBURSEMENT_ID)
            {
                DialogResult strEmail = function.MsgBoxQuestion(this.Text, "Inform Requester to confirm received thru automatically generated email?");

                if (strEmail == DialogResult.Yes)
                {
                    int requesterId = Convert.ToInt32(txtRequestBy.Tag);
                    //string toEmail = common.GetEmail(requesterId);

                    string toEmail = "";

                    //if (toEmail == "")
                    //{
                    frmConfirmReceived frmCR = new frmConfirmReceived();

                    frmCR.ShowDialog();

                    if (frmCR.DialogResult == DialogResult.OK)
                    {
                        toEmail = frmCR.LUEmail;
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
                    emailMsg.AppendLine("<p><font size=\"5\"><a href=\"http://rgmcgroup.com:7171/epv-received/ " + mvEPVId + "/" + requesterId + "\"><b>Confirm Received</b></a></font></p>");
                    emailMsg.AppendLine("<p>Thank you!</p>");

                    emailMsg.AppendLine("<p><b>Reimbursement Received Confirmation.</b></p>");
                    emailMsg.AppendLine("<p><b>EPV #:<br />&emsp;");
                    if (cboChargeTo.Items.Count > 1)
                    {
                        var formNumberArray = txtFormNumber.Text.Split('-');

                        foreach (DataRowView row in cboChargeTo.Items)
                        {
                            emailMsg.AppendLine(row.Row.ItemArray[1].ToString().Split(':')[1]
                                    + "-" + formNumberArray[1] + "-" + (formNumberArray.Length == 3 ? formNumberArray[2] : "") + ";");
                        }
                    }
                    else
                    {
                        emailMsg.AppendLine(txtFormNumber.Text);
                    }

                    emailMsg.AppendLine("</b></p>"); 
                    emailMsg.AppendLine("<p><b>Released By:<br />&emsp;");
                    emailMsg.AppendLine(txtReleasedBy.Text);
                    emailMsg.AppendLine("</b></p>");
                    emailMsg.AppendLine("<p><b>Released Date:<br />&emsp;");
                    emailMsg.AppendLine(dtpReleased.Text);
                    emailMsg.AppendLine("</b></p>");
                    emailMsg.AppendLine("<p><b>Total Amount Reimbursed:<br />&emsp;PHP");
                    emailMsg.AppendLine(txtTotalExpense.Text);
                    emailMsg.AppendLine("</b></p>");

                    emailMsg.AppendLine("<font size=\"-3\"><p>Please do not reply. System-generated email notification only.<br /></font></p>");

                    common.SendEmail("EPV Received Confirmation", emailMsg.ToString(), toEmail);

                    StringBuilder sSQL = new StringBuilder();


                    sSQL.AppendLine("DECLARE @employeeId INT = " + txtRequestBy.Tag);
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


        private void btnSearchNature_Click(object sender, EventArgs e)
        {
            frmSearchNatureOfExpense frm = new frmSearchNatureOfExpense();

            frm.LUName = cboNatureOfExpense.Text;

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                cboNatureOfExpense.SelectedValue = frm.LUId;
                cboNatureOfExpense.Text = frm.LUName;

                if (Convert.ToInt32(cboNatureOfExpense.SelectedValue) != TRANSPORT_CHARGES_ID)
                {
                    pnlTransport.Visible = false;
                    txtParticulars.Focus();
                }
                else
                {
                    //pnlTransport.Visible = true;
                    ToggleMultipleTransport();
                    txtDestination.Focus();
                }
            }

            frm.Dispose();
        }
        
        private void txtBusinessOthers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { e.SuppressKeyPress = true; }
        }

        private void ComputeTotalExpense()
        {
            decimal expensePerChargeTo = 0;
            decimal totalExpenses = 0;
            int chargeToId = -1;

            for (int i = 0; i < dgvList.Rows.Count; ++i)
            {
                chargeToId = Convert.ToInt32(dgvList["chargeToId", i].Value);
                if (Convert.ToBoolean(dgvList["isActive", i].Value) == true && Convert.ToInt32(cboChargeTo.SelectedValue) == chargeToId)
                { expensePerChargeTo += Convert.ToDecimal(dgvList["Amount", i].Value); }
            }

            for (int i = 0; i < dgvList.Rows.Count; ++i)
            {
                if (Convert.ToBoolean(dgvList["isActive", i].Value) == true)
                { totalExpenses += Convert.ToDecimal(dgvList["Amount", i].Value); }
            }

            txtTotalExpenses.Text = function.FormatDouble(totalExpenses.ToString());

            txtTotalExpense.Text = function.FormatDouble(expensePerChargeTo.ToString());
            
            decimal cashAdvance = Convert.ToDecimal(txtCashAdvance.Text);            
            decimal cashOverUnder = expensePerChargeTo - cashAdvance;

            if (Convert.ToInt32(cboTransactionType.SelectedValue) != Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
            { txtCashOver.Text = "0"; }
            else
            { txtCashOver.Text = Convert.ToString(cashOverUnder); }
    
            if (expensePerChargeTo > Declaration.AMOUNT_LIMIT)
            {
                btnSearchMgtApprover.Visible = true;
                dtpMgtApproved.Enabled = true;
                txtMgtApprovedBy.BackColor = Declaration.reqBackColor;
            }
            else
            {
                txtMgtApprovedBy.BackColor = default(System.Drawing.Color);
                btnSearchMgtApprover.Visible = false;
                dtpMgtApproved.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboBusinessPurpose.Text.Trim() == "")
                {
                    cboBusinessPurpose.Focus();
                    throw new Exception("Business Purpose is required.");
                }

                if (cboDepartment.Text.Trim() == "")
                {
                    cboDepartment.Focus();
                    throw new Exception("Department is required.");
                }
                
                if (cboStores.Text.Trim() == "")
                {
                    cboStores.Focus();
                    throw new Exception("Store is required.");
                }

                if (chkBoxChargeTo.Visible && mvEPVId == -1)
                {
                    btnSaveMultiple.Focus();
                    throw new Exception("Charge To is not Set.");
                }

                if (cboTransactionType.Text.Trim() == "")
                {
                    cboStores.Focus();
                    throw new Exception("Transaction Type is required.");
                }

                if (dtpTransaction.Value > dtpRequested.Value.AddDays(1))
                {
                    dtpTransaction.Focus();
                    throw new Exception("Transaction Date must be less than(<) or equal(=) to Request Date.");
                }
                
                if (cboNatureOfExpense.Text.Trim() == "")
                {
                    cboNatureOfExpense.Focus();
                    throw new Exception("Nature of Expense is required.");
                }

                if (txtParticulars.Text.Trim() == "" && Convert.ToInt32(cboNatureOfExpense.SelectedValue) != TRANSPORT_CHARGES_ID)
                {
                    txtParticulars.Focus();
                    throw new Exception("Please indicate Particulars.");
                }             

                if (txtAmount.Text.Trim() == "" && !pnlTransportMultiple.Visible)
                {
                    txtAmount.Focus();
                    throw new Exception("Please indicate Amount");
                }

                if (cboChargeTo.Text == "")
                {
                    cboChargeTo.Focus();
                    throw new Exception("Please select a Charge To first.");
                }

                if (function.IsDouble(txtAmount.Text) == false && !pnlTransportMultiple.Visible)
                {
                    txtAmount.SelectAll();
                    throw new Exception("Invalid Amount.");
                }

                if (txtDestination.Text == "" && pnlTransportMultiple.Visible)
                {
                    txtDestination.Focus();
                    throw new Exception("Destination required.");
                }

                if (!detailEdit)
                {
                    if (chkDestChargeTo.CheckedItems.Count == 0 && pnlTransportMultiple.Visible && isMultiple)
                    {
                        chkDestChargeTo.Focus();
                        throw new Exception("Please check a Charge To.");
                    }

                    if (chkPartChargeTo.CheckedItems.Count == 0 && !pnlTransportMultiple.Visible && isMultiple)
                    {
                        chkDestChargeTo.Focus();
                        throw new Exception("Please check a Charge To.");
                    }
                }

                if (cboClaimTo.SelectedValue.ToString() != "-1")
                {
                    if (txtSupplier.Text.Trim() == "")
                    {
                        btnSearchSupplier.Focus();
                        throw new Exception("Supplier required.");
                    }
                    
                    if (txtReferenceNumber.Text.Trim() == "")
                    {
                        txtReferenceNumber.Focus();
                        throw new Exception("Reference # required.");
                    }

                    if (function.IsDouble(txtVatAmount.Text) == false)
                    {
                        txtVatAmount.Focus();
                        throw new Exception("Invalid VAT Amount.");
                    }
                }                

                TextBox[] txtFromMulti = { txtFromMulti1, txtFromMulti2, txtFromMulti3, txtFromMulti4, txtFromMulti5, txtFromMulti6, txtFromMulti7, txtFromMulti8, txtFromMulti9, txtFromMulti10, txtFromMulti11, txtFromMulti12, txtFromMulti13, txtFromMulti14, };
                TextBox[] txtToMulti = { txtToMulti1, txtToMulti2, txtToMulti3, txtToMulti4, txtToMulti5, txtToMulti6, txtToMulti7, txtToMulti8, txtToMulti9, txtToMulti10, txtToMulti11, txtToMulti12, txtToMulti13, txtToMulti14 };
                ComboBox[] cboModeMulti = { cboModeMulti1, cboModeMulti2, cboModeMulti3, cboModeMulti4, cboModeMulti5, cboModeMulti6, cboModeMulti7, cboModeMulti8, cboModeMulti9, cboModeMulti10, cboModeMulti11, cboModeMulti12, cboModeMulti13, cboModeMulti14 };
                TextBox[] txtAmountMulti = { txtAmountMulti1, txtAmountMulti2, txtAmountMulti3, txtAmountMulti4, txtAmountMulti5, txtAmountMulti6, txtAmountMulti7, txtAmountMulti8, txtAmountMulti9, txtAmountMulti10, txtAmountMulti11, txtAmountMulti12, txtAmountMulti13, txtAmountMulti14 };
                             
                if (pnlTransportMultiple.Visible && (txtFromMulti[0].Text.Trim() == "" || txtToMulti[0].Text.Trim() == "" || cboModeMulti[0].Text.Trim() == "" || txtAmountMulti[0].Text.Trim() == ""))
                {
                    throw new Exception("Travel details cannot be empty.");
                }

                decimal amount = 0;

                if (Convert.ToInt32(cboNatureOfExpense.SelectedValue) == TRANSPORT_CHARGES_ID && pnlTransportMultiple.Visible)
                {
                    if (!isMultiple)
                    {
                        dgvList.Rows.Add(cboNatureOfExpense.SelectedValue, dtpTransaction.Text, cboNatureOfExpense.Text,
                        "Destination : " + txtDestination.Text, cboChargeTo.Text, 0, txtSupplier.Tag,
                        txtSupplier.Text, txtTIN.Text, txtReferenceNumber.Text, txtVatAmount.Text,
                        cboClaimTo.SelectedValue == null ? -1 : cboClaimTo.SelectedValue, true, txtAddress.Text, cboChargeTo.SelectedValue);

                        for (int i = 0; i < txtFromMulti.Length; i++)
                        {

                            if (txtFromMulti[i].Text != "" && txtToMulti[i].Text != "" && cboModeMulti[i].Text != "" && txtAmountMulti[i].Text != "")
                            {
                                amount = (txtAmountMulti[i].Text == "" ? 0 : Convert.ToDecimal(txtAmountMulti[i].Text));
                                dgvList.Rows.Add(cboNatureOfExpense.SelectedValue, dtpTransaction.Text,
                                cboNatureOfExpense.Text, "From: " + txtFromMulti[i].Text + "; To: " + txtToMulti[i].Text + "; Mode: " + cboModeMulti[i].Text,
                                cboChargeTo.Text,
                                function.FormatDouble(amount.ToString()),
                                txtSupplier.Tag, txtSupplier.Text, txtTIN.Text, txtReferenceNumber.Text, txtVatAmount.Text,
                                cboClaimTo.SelectedValue == null ? -1 : cboClaimTo.SelectedValue, true,
                                txtAddress.Text, cboChargeTo.SelectedValue);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRowView itemChecked in chkDestChargeTo.CheckedItems)
                        {
                            dgvList.Rows.Add(cboNatureOfExpense.SelectedValue, dtpTransaction.Text, cboNatureOfExpense.Text,
                            "Destination : " + txtDestination.Text, itemChecked.Row["chargeToName"].ToString(), 0, txtSupplier.Tag,
                            txtSupplier.Text, txtTIN.Text, txtReferenceNumber.Text, txtVatAmount.Text,
                            cboClaimTo.SelectedValue == null ? -1 : cboClaimTo.SelectedValue, true, txtAddress.Text, itemChecked.Row["chargeToId"]);

                            for (int i = 0; i < txtFromMulti.Length; i++)
                            {
                                if (txtFromMulti[i].Text != "" && txtToMulti[i].Text != "" && cboModeMulti[i].Text != "" && txtAmountMulti[i].Text != "")
                                {
                                    amount = (txtAmountMulti[i].Text == "" ? 0 : Convert.ToDecimal(txtAmountMulti[i].Text));
                                    dgvList.Rows.Add(cboNatureOfExpense.SelectedValue, dtpTransaction.Text,
                                    cboNatureOfExpense.Text, "From: " + txtFromMulti[i].Text + "; To: " + txtToMulti[i].Text + "; Mode: " + cboModeMulti[i].Text,
                                    itemChecked.Row["chargeToName"].ToString(),
                                    function.FormatDouble((amount / Convert.ToDecimal(chkDestChargeTo.CheckedItems.Count)).ToString()),
                                    txtSupplier.Tag, txtSupplier.Text, txtTIN.Text, txtReferenceNumber.Text, txtVatAmount.Text,
                                    cboClaimTo.SelectedValue == null ? -1 : cboClaimTo.SelectedValue, true,
                                    txtAddress.Text, itemChecked.Row["chargeToId"]);
                                }
                            }
                        }
                    }

                    lastIndex = -1;

                    ToggleMultipleTransport();
                }
                else
                {
                    if (Convert.ToInt32(cboNatureOfExpense.SelectedValue) == TRANSPORT_CHARGES_ID && !pnlTransportMultiple.Visible)
                    {
                        txtParticulars.Text = "From: " + txtFrom.Text + "; To: " + txtTo.Text + "; Mode: " + cboModeOfTransportation.Text;
                    }

                    if (lastIndex == -1)
                    {
                        if (!isMultiple)
                        {
                            amount = Convert.ToDecimal(txtAmount.Text);

                            dgvList.Rows.Add(cboNatureOfExpense.SelectedValue, dtpTransaction.Text,
                            cboNatureOfExpense.Text, txtParticulars.Text, cboChargeTo.Text, function.FormatDouble(amount.ToString()),
                            txtSupplier.Tag, txtSupplier.Text, txtTIN.Text, txtReferenceNumber.Text, txtVatAmount.Text,
                            cboClaimTo.SelectedValue == null ? -1 : cboClaimTo.SelectedValue, true,
                            txtAddress.Text, cboChargeTo.SelectedValue);
                        }
                        else
                        {
                            amount = Convert.ToDecimal(txtAmount.Text) / chkPartChargeTo.CheckedItems.Count;

                            foreach (DataRowView itemChecked in chkPartChargeTo.CheckedItems)
                            {
                                dgvList.Rows.Add(cboNatureOfExpense.SelectedValue, dtpTransaction.Text,
                                cboNatureOfExpense.Text, txtParticulars.Text, itemChecked.Row["chargeToName"], function.FormatDouble(amount.ToString()),
                                txtSupplier.Tag, txtSupplier.Text, txtTIN.Text, txtReferenceNumber.Text, txtVatAmount.Text,
                                cboClaimTo.SelectedValue == null ? -1 : cboClaimTo.SelectedValue, true,
                                txtAddress.Text, itemChecked.Row["chargeToId"]);
                            }
                        }
                    }
                    else
                    {
                        dgvList.Rows[lastIndex].Cells[IX_GRID_TRANSACTION_DATE].Value = dtpTransaction.Text;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_NATURE_OF_EXPENSE].Value = cboNatureOfExpense.Text;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_NATURE_OF_EXPENSE_ID].Value = cboNatureOfExpense.SelectedValue;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_PARTICULARS].Value = txtParticulars.Text;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_CHARGE_TO_NAME].Value = cboChargeTo.Text;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_AMOUNT].Value = function.FormatDouble(txtAmount.Text);
                        dgvList.Rows[lastIndex].Cells[IX_GRID_VENDOR_ID].Value = txtSupplier.Tag;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_VENDOR_NAME].Value = txtSupplier.Text;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_TIN].Value = txtTIN.Text;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_REFERENCE_NUMBER].Value = txtReferenceNumber.Text;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_VAT_AMOUNT].Value = function.FormatDouble(txtVatAmount.Text);
                        dgvList.Rows[lastIndex].Cells[IX_GRID_CLAIM_TO_ID].Value = cboClaimTo.SelectedValue == null ? -1 : cboClaimTo.SelectedValue;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_IS_ACTIVE].Value = true;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_ADDRESS].Value = txtAddress.Text;
                        dgvList.Rows[lastIndex].Cells[IX_GRID_CHARGE_TO_ID].Value = cboChargeTo.SelectedValue;
                        lastIndex = -1;
                    }
                }

                //textbox clear mode
                if (pnlTransportMultiple.Visible)
                {
                    for (int i = 0; i < txtFromMulti.Length; i++)
                    {
                        txtFromMulti[i].Clear();
                        txtToMulti[i].Clear();
                        cboModeMulti[i].SelectedIndex = -1;
                        txtAmountMulti[i].Clear();
                    }
                    ToggleMultipleTransport();
                }

                if (isMultiple)
                {
                    cboChargeTo.Enabled = true;
                    txtParticulars.Width = 240;
                    lblParticulars.Width = 240;
                    lblPartChargeTo.Visible = true;
                    chkPartChargeTo.Visible = true;
                }

                if (btnAdd.BackgroundImage.RawFormat == MyRIS.Properties.Resources.Save_Icon.RawFormat)
                {
                    remarkRequired = true;
                    dgvList.FirstDisplayedScrollingRowIndex = dgvList.RowCount - 1;
                }
                
                cboNatureOfExpense.Enabled = true;
                pnlTransport.Visible = false;
                dtpTransaction.Text = "";
                txtParticulars.Text = "";
                cboNatureOfExpense.SelectedIndex = -1;
                cboModeOfTransportation.SelectedIndex = -1;
                txtAmount.Clear();
                txtFrom.Clear();
                txtTo.Clear();
                txtSupplier.Clear();
                txtSupplier.Tag = -1;
                txtTIN.Clear();
                txtReferenceNumber.Clear();
                txtVatAmount.Text = "0";
                cboClaimTo.SelectedValue = -1;
                txtAddress.Clear();
                detailEdit = false;
                ComputeTotalExpense();                

                btnAdd.BackgroundImage = MyRIS.Properties.Resources.Add_Icon; ;

                ClearTextBoxes(pnlTransportMultiple.Controls);         

                dtpTransaction.Focus();
            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
            }
        }

        private void ClearTextBoxes(Control.ControlCollection col)
        {
            foreach (Control control in col)
                if (control is TextBox)
                    (control as TextBox).Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to delete this row?");

            if (strAnswer == DialogResult.No)
            { return; }

            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                if (!row.IsNewRow)
                    dgvList.Rows.Remove(row);
            }
            
            ComputeTotalExpense();
        }
        
        private void btnApprovedBy_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();

            frm.GROUP = Declaration.GROUP_APPROVER;

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtHeadApprovedBy.Tag = frm.LUId;
                txtHeadApprovedBy.Text = frm.LUName;
            }
        }
       
        private void btnAuditedBy_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();

            frm.GROUP = Declaration.GROUP_ACCOUNTING;

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtAuditedBy.Tag = frm.LUId;
                txtAuditedBy.Text = frm.LUName;
            }
        }

        private void btnReceivedBy_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtUploadedBy.Tag = frm.LUId;
                txtUploadedBy.Text = frm.LUName;
            }
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.SelectedRows.Count == 0)
                { return; }

                lastIndex = dgvList.SelectedRows[0].Index;
                btnAdd.BackgroundImage = MyRIS.Properties.Resources.Save_Icon;

                if (dgvList.SelectedRows[0].Cells[IX_GRID_PARTICULARS].Value.ToString().Contains("Destination"))
                {
                    dtpTransaction.Text = dgvList.SelectedRows[0].Cells[IX_GRID_TRANSACTION_DATE].Value.ToString();
                    cboNatureOfExpense.Enabled = false;
                    cboNatureOfExpense.Text = dgvList.SelectedRows[0].Cells[IX_GRID_NATURE_OF_EXPENSE].Value.ToString();
                    cboNatureOfExpense.SelectedValue = dgvList.SelectedRows[0].Cells[IX_GRID_NATURE_OF_EXPENSE_ID].Value.ToString();
                    txtEditDestination.Text = dgvList.SelectedRows[0].Cells[IX_GRID_PARTICULARS].Value.ToString().Split(':')[1].Trim();
                    pnlEditDestination.Visible = true;
                    pnlVAT.Enabled = false;
                    cboNatureOfExpense.Enabled = false;
                    return;
                }
                else if (dgvList.SelectedRows[0].Cells[IX_GRID_PARTICULARS].Value.ToString().Contains("From"))
                {
                    cboNatureOfExpense.Enabled = false;
                    pnlVAT.Enabled = true;
                }
                else
                {
                    pnlVAT.Enabled = true;
                    cboNatureOfExpense.Enabled = true;
                }

                cboChargeTo.Enabled = false;
                //if (isMultiple)
                //{
                //    chkPartChargeTo.Visible = true;
                //    lblPartChargeTo.Visible = true;
                //    txtParticulars.Width = 244;
                //    lblParticulars.Width = 244;
                //}
                //else
                //{
                chkPartChargeTo.Visible = false;
                lblPartChargeTo.Visible = false;
                txtParticulars.Width = 328;
                lblParticulars.Width = 328;
                //}
                pnlEditDestination.Visible = false;

                dtpTransaction.Text = dgvList.SelectedRows[0].Cells[IX_GRID_TRANSACTION_DATE].Value.ToString();
                cboNatureOfExpense.Text = dgvList.SelectedRows[0].Cells[IX_GRID_NATURE_OF_EXPENSE].Value.ToString();
                cboNatureOfExpense.SelectedValue = dgvList.SelectedRows[0].Cells[IX_GRID_NATURE_OF_EXPENSE_ID].Value.ToString();
                txtParticulars.Text = dgvList.SelectedRows[0].Cells[IX_GRID_PARTICULARS].Value.ToString();
                //chkPartChargeTo.Text = dgvList.SelectedRows[0].Cells[IX_GRID_CHARGE_TO_NAME].Value.ToString();
                //chkPartChargeTo.Tag = dgvList.SelectedRows[0].Cells[IX_GRID_CHARGE_TO_ID].Value.ToString();
                for (int i = 0; i < chkPartChargeTo.Items.Count; i++)
                { chkPartChargeTo.SetItemChecked(i, false); }

                for (int i = 0; i < chkPartChargeTo.Items.Count; i++)
                {
                    DataRowView listBoxItem = (DataRowView)chkPartChargeTo.Items[i];
                    string strChargeToChkBox = listBoxItem.Row["ChargeToName"] as string;
                    string strChargeToGrid = dgvList.SelectedRows[0].Cells[IX_GRID_CHARGE_TO_NAME].Value.ToString();              
                    if (strChargeToChkBox.Contains(strChargeToGrid))
                    {
                        chkPartChargeTo.SetItemChecked(i, true);
                        break;
                    }
                }

                txtAmount.Text = dgvList.SelectedRows[0].Cells[IX_GRID_AMOUNT].Value.ToString();
                cboClaimTo.SelectedValue = dgvList.SelectedRows[0].Cells["claimToId"].Value.ToString();
                txtSupplier.Tag = dgvList.SelectedRows[0].Cells[IX_GRID_VENDOR_ID].Value.ToString();
                txtSupplier.Text = dgvList.SelectedRows[0].Cells[IX_GRID_VENDOR_NAME].Value.ToString();
                txtAddress.Text = dgvList.SelectedRows[0].Cells[IX_GRID_ADDRESS].Value.ToString();
                this.toolTip.SetToolTip(this.txtAddress, txtAddress.Text);

                txtTIN.Text = dgvList.SelectedRows[0].Cells[IX_GRID_TIN].Value.ToString();
                txtReferenceNumber.Text = dgvList.SelectedRows[0].Cells[IX_GRID_REFERENCE_NUMBER].Value.ToString();
                txtVatAmount.Text = dgvList.SelectedRows[0].Cells[IX_GRID_VAT_AMOUNT].Value.ToString();
                cboChargeTo.SelectedValue = dgvList.SelectedRows[0].Cells[IX_GRID_CHARGE_TO_ID].Value;
                detailEdit = true;

                if (Convert.ToInt32(cboNatureOfExpense.SelectedValue) == TRANSPORT_CHARGES_ID)
                {
                    string[] particulars = txtParticulars.Text.Split(';');

                    txtFrom.Text = particulars[0].Split(':')[1].Trim();
                    txtTo.Text = particulars[1].Split(':')[1].Trim();
                    cboModeOfTransportation.Text = particulars[2].Split(':')[1].Trim();

                    pnlTransport.Visible = true;

                    txtParticulars.Clear();                                        
                }
                else
                {
                    pnlTransport.Visible = false;
                }                
            }
            catch (Exception ex)
            {
                function.MsgBoxInfo(this.Text, ex.Message);
            }
        }

        private void txtCashAdvance_TextChanged(object sender, EventArgs e)
        {
            decimal cashAdvance = Convert.ToDecimal(txtCashAdvance.Text);
            txtCashOver.Text = function.FormatDouble((Convert.ToDecimal(txtTotalExpense.Text) - cashAdvance).ToString());
        }
        
        private void frmEPVDetail_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ComboBoxValidation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            Label lbl = null;

            switch (cbo.Name)
            {
                case "cboBusinessPurpose":
                    lbl = lblBusiness;
                    break;
                case "cboDepartment":
                    lbl = lblDepartment;
                    break;
                case "cboStores":
                    lbl = lblStore;
                    break;
                case "cboChargeTo":
                    lbl = lblChargeTo;
                    break;
                case "cboNatureOfExpense":
                    lbl = lblNatureOfExpense;
                    break;
                default:
                    return;
            }

            if (cbo.Text != "")
            {                       
                lbl.BackColor = default(System.Drawing.Color);
            }
            else
            {
                { lbl.BackColor = Declaration.reqBackColor; }
            }
        }
                        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_EPV, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }

                //ValidateInfo();

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to save the changes you've made?");

                if (strAnswer == DialogResult.No)
                { return; }

                SaveInfo(MODE_SAVE);

                function.MsgBoxInfo(this.Text, "Saving of record was successful. You can edit this form later.");

                LoadDetail();
                
                refresh = System.Windows.Forms.DialogResult.OK;              
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable mainDT = new DataTable();
            DataTable detailDT = new DataTable();

            DataTable[] listTable = { mainDT, detailDT };

            string sSQL = "proc_RPT05EPV";

            try
            {
                Cursor = Cursors.WaitCursor;

                System.Data.SqlClient.SqlParameter pEPVId = new System.Data.SqlClient.SqlParameter("@epvId", SqlDbType.Int);
                pEPVId.Value = mvEPVId;

                System.Data.SqlClient.SqlParameter pChargeToId = new System.Data.SqlClient.SqlParameter("@chargeToId", SqlDbType.Int);
                pChargeToId.Value = cboChargeTo.SelectedValue;

                using (SQLDB sql = new SQLDB())
                { sql.GetDT(ref listTable, sSQL, CommandType.StoredProcedure, pEPVId, pChargeToId); }

                if (mainDT.Rows.Count == 0)
                {
                    throw new Exception("Nothing to Print.");
                }

                frmPreview frm = new frmPreview();
                LocalReport report = frm.rpvPreview.LocalReport;

                report.DataSources.Clear(); 
                report.ReportEmbeddedResource = "MyRIS.Reports.rptEPV.rdlc"; 
                report.DisplayName = "Expense Payment Voucher";

                int dateCount = detailDT
                                  .AsEnumerable()
                                    .Select(r => r.Field<DateTime>("transactionDate"))
                                    .Distinct()
                                    .Count();

                int rowCount = detailDT.Rows.Count + dateCount;

                int maxRowPerPage = 32;
                int rowForLastPage = 24;
                int rowToAdd = 0;
                if (rowCount > maxRowPerPage)
                {
                    for (rowToAdd = rowCount; rowToAdd >= maxRowPerPage;)
                    {
                        rowToAdd = rowToAdd - maxRowPerPage;
                    }

                    rowToAdd = rowForLastPage - rowToAdd;
                }
                else if (rowCount < rowForLastPage)
                {
                    rowToAdd = rowForLastPage - rowCount;
                }
                else
                {
                    rowToAdd = 0;
                }

                for (int i = 0; i < rowToAdd; i++)
                {
                    detailDT.Rows.Add(-1, -1, DateTime.Today, -1, "", "", 0, 9999);
                }

                ReportDataSource ds = new ReportDataSource("EPV", mainDT); 
                report.DataSources.Add(ds);

                ds = new ReportDataSource("EPVDetail", detailDT); 
                report.DataSources.Add(ds);

                string mgtApproved = Convert.ToDecimal(txtTotalExpenses.Text) > Declaration.AMOUNT_LIMIT ? "1" : "0";

                ReportParameter p = new
                ReportParameter("WithMgtApprover", mgtApproved);
                report.SetParameters(new ReportParameter[] { p });

                p = new
                ReportParameter("PrintedBy", "Printed by: " + GlobalSettings.UserFullName + " | " + string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", DateTime.Now) + " | " + report.DisplayName);
                report.SetParameters(new ReportParameter[] { p });

                report.Refresh();

                //frm.ShowDialog();

                Byte[] bytes = report.Render("PDF");
                FileStream fs = new FileStream(Path.GetTempPath() + @"\EPV_" + txtFormNumber.Text + ".pdf", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                System.Diagnostics.Process.Start(Path.GetTempPath() + @"\EPV_" + txtFormNumber.Text + ".pdf");

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
            finally
            { Cursor = Cursors.Default; }
        }

        private void TextBoxValidation_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            Label lbl = null;

            switch (txt.Name)
            {
                case "txtParticulars":
                    lbl = lblParticulars;
                    break;
                case "txtAmount":
                    lbl = lblAmount;
                    break;
                case "txtDestination":
                    lbl = lblDestination;
                    break;
                default:
                    return;
            }

            if (txt.Text != "")
            { lbl.BackColor = default(System.Drawing.Color); }
            else
            { lbl.BackColor = Declaration.reqBackColor; }
        }
        
        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            frmSearchSupplier frm = new frmSearchSupplier();

            frm.LUName = txtSupplier.Text.Trim();

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtSupplier.Tag = frm.LUId;
                txtSupplier.Text = frm.LUName;
                txtTIN.Text = frm.LUCode;
                txtAddress.Text = frm.LUAddress;
            }
        }
        
        private void ToggleMultipleTransport()
        {
            pnlTransportMultiple.Visible = !pnlTransportMultiple.Visible;

            txtFromMulti1.Text = txtFrom.Text;
            txtToMulti1.Text = txtTo.Text;
            cboModeMulti1.Text = cboModeOfTransportation.Text;            
        }

        private void txtToMulti1_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti2.Text = txtToMulti1.Text;
        }

        private void txtToMulti2_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti3.Text = txtToMulti2.Text;
        }

        private void txtToMulti3_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti4.Text = txtToMulti3.Text;
        }

        private void txtToMulti4_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti5.Text = txtToMulti4.Text;
        }

        private void txtToMulti5_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti6.Text = txtToMulti5.Text;
        }

        private void txtToMulti6_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti7.Text = txtToMulti6.Text;
        }

        private void txtToMulti7_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti8.Text = txtToMulti7.Text;
        }

        private void txtToMulti8_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti9.Text = txtToMulti8.Text;
        }

        private void txtToMulti9_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti10.Text = txtToMulti9.Text;
        }

        private void txtToMulti10_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti11.Text = txtToMulti10.Text;
        }

        private void txtToMulti11_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti12.Text = txtToMulti11.Text;
        }

        private void txtToMulti12_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti13.Text = txtToMulti12.Text;
        }

        private void txtToMulti13_TextChanged(object sender, EventArgs e)
        {
            txtFromMulti14.Text = txtToMulti13.Text;
        }

        private void cboNature_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboNatureOfExpense.SelectedValue) == TRANSPORT_CHARGES_ID && lastIndex == -1)
                {
                    SetChargeTo();
                    pnlTransportMultiple.Visible = true;
                    pnlTransport.Visible = true;
                    lblDestination.BackColor = Declaration.reqBackColor;
                    txtDestination.Focus();                    
                }
                else if (Convert.ToInt32(cboNatureOfExpense.SelectedValue) == TRANSPORT_CHARGES_ID && lastIndex != -1)
                {
                    SetChargeTo();
                    pnlTransportMultiple.Visible = false;
                    pnlTransport.Visible = true;
                    lblDestination.BackColor = Declaration.reqBackColor;
                    txtDestination.Focus();
                }
            }
            catch { }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_EPV, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }

                if (dgvList.Rows.Count == 0)
                { throw new Exception(""); }

                if (txtHeadApprovedBy.Tag.ToString() == "-1")
                { throw new Exception("Head Approved By cannot be empty."); }

                if (txtMgtApprovedBy.Tag.ToString() == "-1" && Convert.ToDecimal(txtTotalExpense.Text) > Declaration.AMOUNT_LIMIT)
                { throw new Exception("Mgt Approved By cannot be empty."); }

                foreach (DataGridViewRow row in dgvList.Rows)
                {
                    if (!Convert.ToBoolean(row.Cells["isActive"].Value) && txtRemarks.Text == "")
                    {
                        txtRemarks.Focus();
                        throw new Exception("Please enter a Remark for not including some details.");
                    }
                }

                if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID && Convert.ToInt32(txtCA.Tag) == -1)
                {
                    txtCA.Focus();
                    throw new Exception("Please enter a valid CA #.");
                }

                if (Convert.ToInt32(txtRequestBy.Tag) == Convert.ToInt32(txtHeadApprovedBy.Tag))
                {
                    btnSearchHeadApprover.Focus();
                    throw new Exception("You cannot approved your self.");
                }

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to approved the Voucher?");

                if (strAnswer == DialogResult.No)
                { return; }

                SaveInfo(MODE_APPROVE);

                function.MsgBoxInfo(this.Text, "Voucher approved.");

                LoadDetail();
                
                DialogResult strEmail = function.MsgBoxQuestion(this.Text, "Inform Treasury Department thru automatically generated email?");

                if (strEmail == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    StringBuilder emailMsg = new StringBuilder();

                    emailMsg.AppendLine("<p>An EPV Request requires to be updated. Current Status[" + lblStatus.Text + "].</p>");
                    emailMsg.AppendLine("<p><b>EPV #:<br />&emsp;");
                    emailMsg.AppendLine(txtFormNumber.Text);
                    emailMsg.AppendLine("</b></p>");
                    emailMsg.AppendLine("<p><b>Requested By:<br />&emsp;");
                    emailMsg.AppendLine(txtRequestBy.Text);
                    emailMsg.AppendLine("</b></p>");
                    emailMsg.AppendLine("<p><b>Total Expense:<br />&emsp;PHP");
                    emailMsg.AppendLine(txtTotalExpense.Text);
                    emailMsg.AppendLine("</b></p>");

                    if (Convert.ToInt32(cboTransactionType.SelectedValue) == Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                    {
                        emailMsg.AppendLine("<p><b>Cash Advance:<br />&emsp;PHP");
                        emailMsg.AppendLine(txtCashAdvance.Text);
                        emailMsg.AppendLine("</b></p>");
                        emailMsg.AppendLine("<p><b>Cash Under/(Over):<br />&emsp;PHP");
                        emailMsg.AppendLine(txtCashOver.Text);
                        emailMsg.AppendLine("</b></p>");
                    }

                    emailMsg.AppendLine("<p>Thank you!</p>");
                    emailMsg.AppendLine("");
                    emailMsg.AppendLine("<font size=\"-3\"><p>Please do not reply. System-generated email notification only.<br /></font></p>");

                    common.SendEmail("Travel and Expense System - EPV Request", emailMsg.ToString(), function.GetDBSetting("TREASURY_EMAIL", ""));
                }

                FormatObjects();

                this.Cursor = Cursors.Default;
                refresh = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_EPV, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }

                if (txtRemarks.Text.Trim() == "")
                {
                    txtRemarks.Focus();
                    throw new Exception("Remark is required.");
                }
                
                if (dgvList.Rows.Count == 0)
                { throw new Exception("List of particulars cannot be empty."); }

                if (txtHeadApprovedBy.Tag.ToString() == "-1")
                { throw new Exception("Approved By cannot be empty."); }

                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to reject the Voucher?");

                if (strAnswer == DialogResult.No)
                { return; }

                SaveInfo(MODE_REJECT);

                function.MsgBoxInfo(this.Text, "Voucher rejected.");

                LoadDetail();

                FormatObjects();

                refresh = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void btnEditDestination_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpTransaction.Value > dtpRequested.Value)
                {
                    dtpTransaction.Focus();
                    throw new Exception("Invalid Date.");
                }

                if (txtEditDestination.Text == "")
                {
                    txtEditDestination.Focus();
                    throw new Exception("Destination is required.");
                }

                if (lastIndex != -1)
                {               
                    dgvList[IX_GRID_PARTICULARS, lastIndex].Value = "Destination : " + txtEditDestination.Text;
                    dgvList.Rows[lastIndex].Cells[IX_GRID_TRANSACTION_DATE].Value = dtpTransaction.Text;
                    pnlEditDestination.Visible = false;
                    pnlTransport.Visible = false;
                    cboNatureOfExpense.Enabled = true;
                    lastIndex = -1;
                }

                remarkRequired = true;
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
                DataRow[] dr = dtStores.Select("storeName like '%" + txtStore.Text + "%'");
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

        private void txtCA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable();
                StringBuilder sSQL = new StringBuilder();

                try
                {
                    int transactTypeId = Convert.ToInt32(cboTransactionType.SelectedValue);
                    if (transactTypeId != Declaration.TRANSACT_TYPE_LIQUIDATED_ID)
                    { return; }

                    if (txtRequestBy.Tag.ToString() == "-1")
                    { return; }

                    if (cboChargeTo.SelectedValue == null)
                    { return; }

                    if (cboTransactionType.SelectedValue == null || transactTypeId == -1)
                    {
                        cboTransactionType.Focus();
                        throw new Exception("Please select Transaction Type");
                    }

                    sSQL.AppendLine("SELECT CA.caId, CA.chargeToId, CA.caAmount, CAS.name AS caStatus, CAS.cashAdvanceStatusId AS caStatusId");
                    sSQL.AppendLine("FROM CashAdvance CA ");
                    sSQL.AppendLine("INNER JOIN CashAdvanceStatus CAS ON CAS.cashAdvanceStatusId = CA.cashAdvanceStatusId");
                    sSQL.AppendLine("WHERE caNumber = " + txtCA.Text.sQuote());
                    if (function.HasAccess(Declaration.MOD_CODE_CASH_ADVANCE_ADMIN, GlobalSettings.ACCESS_WRITE) == false)
                    { sSQL.AppendLine("   AND employeeId = " + txtRequestBy.Tag); }
                    sSQL.AppendLine("   AND chargeToId = " + cboChargeTo.SelectedValue);
                    sSQL.AppendLine("   AND CA.cashAdvanceStatusId = " + Declaration.CA_STATUS_ID_RECEIVED);

                    using (SQLDB sql = new SQLDB())
                    { dt = sql.GetDT(sSQL.ToString()); }
                              
                    if (dt.Rows.Count == 0)
                    {
                        txtCA.Tag = -1;
                        txtCashAdvance.Text = "0";
                        txtCAStatus.Clear();
                        throw new Exception("Invalid CA Number or CA is not yet [RECEIVED] status.");
                    }
                    else
                    {
                        txtCA.Tag = dt.Rows[0]["caId"];
                        txtCashAdvance.Text = function.FormatDouble(dt.Rows[0]["caAmount"].ToString());
                        txtCAStatus.Text = dt.Rows[0]["caStatus"].ToString();
                        txtCAStatus.Tag = dt.Rows[0]["chargeToId"].ToString();
                        lblCA.BackColor = default(System.Drawing.Color);
                        throw new Exception("CA Number is valid.");
                    }
                }
                catch (Exception ex)
                {
                    toolTip.Show(ex.Message, txtCA);
                }
            }
        }

        private void dgvList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // End of edition on each click on column of checkbox
            if (e.ColumnIndex == IX_GRID_IS_ACTIVE && e.RowIndex != -1)
            {
                dgvList.EndEdit();
            }
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == IX_GRID_IS_ACTIVE && e.RowIndex != -1)
            {
                ComputeTotalExpense();
            }
        }
        
        private void cboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;

            if (cbo.SelectedValue == null)
            {
                lblTransaction.BackColor = Declaration.reqBackColor;
                return;
            }

            if (cbo.SelectedValue.ToString() == "1") //epv
            {
                txtCA.ReadOnly = true;
                txtCA.Clear();
                txtCA.Tag = "-1";
                txtCAStatus.Clear();
                lblTransaction.BackColor = default(System.Drawing.Color);
                lblCA.BackColor = default(System.Drawing.Color);
            }
            else if (cbo.SelectedValue.ToString() == "2") //liquidation
            {
                txtCA.ReadOnly = false;
                txtCA.TabStop = true;
                lblCA.BackColor = Declaration.reqBackColor;
                lblTransaction.BackColor = default(System.Drawing.Color);
            }
            else
            { lblTransaction.BackColor = default(System.Drawing.Color); }
        }

        private void frmEPVDetail_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = GetChildAtPoint(e.Location);
            if (control != null)
            {
                if (!control.Enabled && _currentToolTipControl == null)
                {
                    string toolTipString = toolTip.GetToolTip(control);
                    // trigger the tooltip with no delay and some basic positioning just to give you an idea
                    toolTip.Show(toolTipString, control, control.Width / 2, control.Height / 2);
                    _currentToolTipControl = control;
                }
            }
            else
            {
                if (_currentToolTipControl != null) toolTip.Hide(_currentToolTipControl);
                _currentToolTipControl = null;
            }
        }

        private void txtEditDestination_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnEditDestination.PerformClick(); }
        }
        
        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { btnAdd.PerformClick(); }
        }

        private void txtCA_Enter(object sender, EventArgs e)
        {
            if (mvEPVId == -1)
            { txtCA.SelectAll(); }
        }

        private void TextBoxKeyPress_DoubleOnly(object sender, KeyPressEventArgs e)
        {
            //if (function.DoubleOnly(e.KeyChar, sender))
            //    { e.Handled = true; }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (function.HasAccess(Declaration.MOD_CODE_EPV, GlobalSettings.ACCESS_WRITE) == false)
                { throw new Exception("Sorry you have no access in this module."); }

                if (txtRemarks.Text.Trim() == "")
                {
                    txtRemarks.Focus();
                    throw new Exception("Remark is required.");
                }

                if (dgvList.Rows.Count == 0)
                { throw new Exception("List of particulars cannot be empty."); }
                
                DialogResult strAnswer = function.MsgBoxQuestion(this.Text, "Are you sure you want to return the EPV?");

                if (strAnswer == DialogResult.No)
                { return; }

                SaveInfo(MODE_RETURN);

                function.MsgBoxInfo(this.Text, "EPV returned.");

                LoadDetail();

                FormatObjects();

                refresh = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }
        
        private void dgvList_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnSearchApprover_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee();
            frm.GROUP = "APPROVER";
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtHeadApprovedBy.Text = frm.LUName;
                txtHeadApprovedBy.Tag = frm.LUId; 
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
                txtMgtApprovedBy.Text = frm.LUName;
                txtMgtApprovedBy.Tag = frm.LUId;
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

                    sSQL.AppendLine("SELECT chargeToId, (chargeToName + ':' + chargeToCode) AS chargeToName  FROM ChargeTo WHERE chargeToId <> " + Declaration.CHARGE_TO_ID_MULTIPLE);

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

                chkBoxChargeTo.Visible = true;
                chkBoxChargeTo.Height = chkBoxChargeTo.Height * (dt.Rows.Count - 1);
                cboChargeTo.Visible = false;
                btnSaveMultiple.Visible = true;
                isMultiple = true;
            }
            else if (mvEPVId != -1)
            {
                SelectChargeTo();
            }
        }

        private void SetChargeTo()
        {
            try
            {
                chkPartChargeTo.DataSource = cboChargeTo.Items;
                chkPartChargeTo.DisplayMember = "chargeToName";
                chkPartChargeTo.ValueMember = "chargeToId";

                chkDestChargeTo.DataSource = cboChargeTo.Items;
                chkDestChargeTo.DisplayMember = "chargeToName";
                chkDestChargeTo.ValueMember = "chargeToId";
            }
            catch{ }
        }

        private void btnSaveMultiple_Click(object sender, EventArgs e)
        {
            if (cboChargeTo.SelectedIndex == -1)
            { return; }

            if (chkBoxChargeTo.Visible)
            {
                chkBoxChargeTo.Visible = false;
                chkBoxChargeTo.Height = 19;
                cboChargeTo.Visible = true;

                btnSaveMultiple.BackgroundImage = global::MyRIS.Properties.Resources.Refresh_Icon;
                toolTip.SetToolTip(btnSaveMultiple, "Reset Charge To List");

                cboChargeTo.DataSource = chkBoxChargeTo.CheckedItems;
                cboChargeTo.DisplayMember = "chargeToName";
                cboChargeTo.ValueMember = "chargeToId";

                chkPartChargeTo.Visible = true;
                chkPartChargeTo.DataSource = chkBoxChargeTo.CheckedItems;
                chkPartChargeTo.DisplayMember = "chargeToName";
                chkPartChargeTo.ValueMember = "chargeToId";

                chkDestChargeTo.Visible = true;
                chkDestChargeTo.DataSource = chkBoxChargeTo.CheckedItems;
                chkDestChargeTo.DisplayMember = "chargeToName";
                chkDestChargeTo.ValueMember = "chargeToId";

                SetChargeTo();

                chkPartChargeTo.Visible = true;
                lblPartChargeTo.Visible = true;
                txtParticulars.Width = 244;
                lblParticulars.Width = 244;
                dgvList.Columns[IX_GRID_CHARGE_TO_NAME].Visible = true;
                isMultiple = true;
                
                txtTotalExpense.Location = new Point(793, 183);
                txtTotalExpense.Width = 92;
                lblOF.Visible = true;
                txtTotalExpenses.Visible = true;
            }
            else
            {
                if (!isMultiple)
                {
                    isMultiple = true;
                    cboChargeTo.Enabled = false;
                    btnSaveMultiple.BackgroundImage = global::MyRIS.Properties.Resources.Refresh_Icon;
                    toolTip.SetToolTip(btnSaveMultiple, "Reset Charge To List");

                    cboChargeTo.DataSource = comboChargeTo.Select("chargeToId = " + cboChargeTo.SelectedValue).CopyToDataTable();
                    cboChargeTo.DisplayMember = "chargeToName";
                    cboChargeTo.ValueMember = "chargeToId";

                    SetChargeTo();
                    dgvList.Columns[IX_GRID_CHARGE_TO_NAME].Visible = true;
                }
                else
                {
                    txtTotalExpense.Location = new Point(833, 183);
                    txtTotalExpense.Width = 146;
                    lblOF.Visible = false;
                    txtTotalExpenses.Visible = false;

                    isMultiple = false;
                    btnSaveMultiple.BackgroundImage = global::MyRIS.Properties.Resources.Save_Icon;
                    cboChargeTo.DataSource = comboChargeTo;
                    cboChargeTo.DisplayMember = "chargeToName";
                    cboChargeTo.ValueMember = "chargeToId";
                    cboChargeTo.Enabled = true;
                    toolTip.SetToolTip(btnSaveMultiple, "Set Charge To");

                    cboChargeTo.SelectedValue = -1;
                    chkPartChargeTo.DataSource = null;
                    chkDestChargeTo.DataSource = null;
                    lblPartChargeTo.Visible = false;
                    chkPartChargeTo.Visible = false;
                    lblParticulars.Width = 328;
                    txtParticulars.Width = 328;
                    chkDestChargeTo.Visible = false;
                    lblDestChargeTo.Visible = false;
                    dgvList.Columns[IX_GRID_CHARGE_TO_NAME].Visible = false;
                }
            }
        }

        private void dgvList_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dgvList.DoDragDrop(
                    dgvList.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void dgvList_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dgvList.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dgvList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // The mouse locations are relative to the screen, so they must be 
                // converted to client coordinates.
                Point clientPoint = dgvList.PointToClient(new Point(e.X, e.Y));

                // Get the row index of the item the mouse is below. 
                rowIndexOfItemUnderMouseToDrop =
                    dgvList.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

                // If the drag operation was a move then remove and insert the row.
                if (e.Effect == DragDropEffects.Move && rowIndexOfItemUnderMouseToDrop != -1)
                {
                    DataGridViewRow rowToMove = e.Data.GetData(
                        typeof(DataGridViewRow)) as DataGridViewRow;
                    dgvList.Rows.RemoveAt(rowIndexFromMouseDown);
                    dgvList.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

                }
            }
            catch { }
        }

        private void chkPartChargeTo_Enter(object sender, EventArgs e)
        {
            chkPartChargeTo.Height = chkPartChargeTo.Height * (chkPartChargeTo.Items.Count);
        }

        private void chkDestChargeTo_Enter(object sender, EventArgs e)
        {
            chkDestChargeTo.Height = chkDestChargeTo.Height * (chkDestChargeTo.Items.Count);
        }

        private void chkPartChargeTo_Leave(object sender, EventArgs e)
        {
            chkPartChargeTo.Height = 19;
        }

        private void chkDestChargeTo_Leave(object sender, EventArgs e)
        {
            chkDestChargeTo.Height = 19;
        }

        private void dgvList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnSearchAuditedBy_Click(object sender, EventArgs e)
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

        private void btnSearchUploadedBy_Click(object sender, EventArgs e)
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

        private void btnSearchReleasedBy_Click(object sender, EventArgs e)
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

        private void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            EmailReceivedConfirmation();
            this.Cursor = Cursors.Default;
        }
    }
}