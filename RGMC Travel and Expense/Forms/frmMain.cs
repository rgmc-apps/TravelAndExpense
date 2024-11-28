using System;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Settings;


namespace MyRIS
{
    public partial class frmMain : Form
    {   
        private Function function = new Function();
        private Common common = new Common();
        
        public frmMain()
        {
            InitializeComponent();
        }

        #region Procedure 

        private void CommandPass(string strCommand)
        {
            try
            {
                Form frm = this.ActiveMdiChild;

                if (frm == null)
                {
                    if (strCommand == Declaration.EXIT_COMMAND)
                    {
                        GlobalSettings.CloseSystemConnection();
                        Application.Exit();

                        return;
                    }
                    else
                    { throw new Exception("No active form."); }
                }

                if (strCommand == "")
                { throw new Exception("Invalid command."); }

                switch (frm.Name)
                {

                    case "frmEPV":
                        frmEPV frmEPV = (frmEPV)frm;
                        frmEPV.CommandPass(strCommand);
                        break;

                    case "frmCashAdvance":
                        frmCashAdvance frmCashAdvance = (frmCashAdvance)frm;
                        frmCashAdvance.CommandPass(strCommand);
                        break;

                    case "frmSupplier":
                        frmSupplier frmSupplier = (frmSupplier)frm;
                        frmSupplier.CommandPass(strCommand);
                        break;

                    case "frmNatureOfExpense":
                        frmNatureOfExpense frmNatureOfExpense = (frmNatureOfExpense)frm;
                        frmNatureOfExpense.CommandPass(strCommand);
                        break;

                    case "frmDashboard":
                        frmDashboard frmDashboard = (frmDashboard)frm;
                        frmDashboard.CommandPass(strCommand);
                        break;

                    case "frmBusinessPurpose":
                        frmBusinessPurpose frmBusinessPurpose = (frmBusinessPurpose)frm;
                        frmBusinessPurpose.CommandPass(strCommand);
                        break;

                    case "frmCostCenter":
                        frmCostCenter frmCostCenter = (frmCostCenter)frm;
                        frmCostCenter.CommandPass(strCommand);
                        break;

                    case "frmModeOfPayment":
                        frmModeOfPayment frmModeOfPayment = (frmModeOfPayment)frm;
                        frmModeOfPayment.CommandPass(strCommand);
                        break;

                    case "frmModeOfTransportation":
                        frmModeOfTransportation frmModeOfTransportation = (frmModeOfTransportation)frm;
                        frmModeOfTransportation.CommandPass(strCommand);
                        break;

                    case "frmStores":
                        frmStores frmStores = (frmStores)frm;
                        frmStores.CommandPass(strCommand);
                        break;

                    default:
                        function.MsgBoxInfo(this.Text, "Invalid active form.");
                        break;
                }

            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void EnableMenu(bool bolEnable)
        {
            mnuNew.Enabled = bolEnable;
            mnuRefresh.Enabled = bolEnable;         
        }

        public void EPVCountStatus()
        {
            btnEPV.Text = " VOUCHERS (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_ALL) + ")";
            btnEPVSaved.Text = " Saved (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_SAVED) + ")";
            btnEPVSubmitted.Text = " For Approval (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_FOR_APPROVAL) + ")";
            btnEPVApproved.Text = " Approved (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_APPROVED) + ")";
            btnEPVForAudit.Text = " For Audit (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_FOR_AUDIT) + ")";
            btnEPVUploaded.Text = " Uploaded /\r\n Pending Approval (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_UPLOADED) + ")";
            btnEPVReleasing.Text = " For Releasing (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_FOR_RELEASING) + ")";
            btnEPVReleased.Text = " Released/Settled (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_RELEASED) + ")";
            btnEPVReceived.Text = " Received (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_RECEIVED) + ")";
            btnEPVRejected.Text = " Rejected (" + common.GetStatusCount(Declaration.TRANS_MODE_EPV, Declaration.EPV_STATUS_ID_REJECTED) + ")";
        }

        public void CACountStatus()
        {
            btnCA.Text = " CASH ADVANCE (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_ALL) + ")";
            btnCASaved.Text = " Saved (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_SAVED) + ")";
            btnCASubmitted.Text = " For Approval (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_FOR_APPROVAL) + ")";
            btnCAReceiving.Text = " Approved (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_APPROVED) + ")";
            btnCAForAudit.Text = " For Audit (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_FOR_AUDIT) + ")";
            btnCAUploaded.Text = " Uploaded /\r\n Pending Approval (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_UPLOADED) + ")";
            btnCAReleasing.Text = " For Releasing (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_FOR_RELEASING) + ")";
            btnCAReleased.Text = " Released (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_RELEASED) + ")";
            btnCAReceived.Text = " Received (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_RECEIVED) + ")";
            btnCALiquidated.Text = " Liquidated (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_LIQUIDATED) + ")";
            btnCARejected.Text = " Rejected (" + common.GetStatusCount(Declaration.TRANS_MODE_CA, Declaration.CA_STATUS_ID_REJECTED) + ")";
        }

        private void UserFilter()
        {
            //if (Declaration.USER_TYPE.Contains(Declaration.GROUP_ACCOUNTING)
            //             || Declaration.USER_TYPE.Contains(Declaration.GROUP_MANAGEMENT)
            //             || Declaration.USER_TYPE.Contains(Declaration.GROUP_TREASURY)
            //             || Declaration.USER_TYPE.Contains(Declaration.GROUP_APPROVER))
            //{
            //    btnSaved.Enabled = false;
            //    btnCASaved.Enabled = false;
            //}
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(GlobalSettings.DBServer == "localhost")
            { lblHeart.Visible = true; }
            this.Text = Declaration.MODULE_TITLE;

            lblCurrentConnection.Text = "Current User: " + GlobalSettings.UserFullName;

            lblUserType.Text = Declaration.USER_TYPE;

            UserFilter();

            EPVCountStatus();
            CACountStatus();

            if (Declaration.USER_TYPE.Contains("ACTG") 
                || Declaration.USER_TYPE.Contains("ALL")
                || Declaration.USER_TYPE.Contains("TREASURY")
                || Declaration.USER_TYPE.Contains("APPROVER")
                )
            {
                Form openfrm = Application.OpenForms["frmDashboard"];

                if (openfrm != null)
                {
                    frmDashboard frm = (frmDashboard)openfrm;
                    frm.Focus();
                }
                else
                {
                    frmDashboard frm = new frmDashboard();
                    function.LoadHeaderForm(this, frm);
                }
            }            
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalSettings.CloseSystemConnection();
            Application.Exit();
        }
        
        private void CheckAccess(Form frm,  bool isDialog = false)
        {
            string strFormName = frm.Name;

            string MODE_CODE = "";

            try
            {
                switch (strFormName)
                {
                    case "frmUtilityList":
                        MODE_CODE = Declaration.MOD_CODE_UTILITY;
                        break;
                    case "frmEPV":
                        MODE_CODE = Declaration.MOD_CODE_EPV;
                        break;
                    case "frmCashAdvance":
                        MODE_CODE = Declaration.MOD_CODE_CASH_ADVANCE;
                        break;
                    case "frmUserAccount":
                        MODE_CODE = Declaration.MOD_CODE_USER_ACCOUNT;
                        break;
                    case "frmUserActivity":
                        MODE_CODE = Declaration.MOD_CODE_USER_ACTIVITY;
                        break;
                    case "frmSupplier":
                        MODE_CODE = Declaration.MOD_CODE_SUPPLIER;
                        break;
                    case "frmNatureOfExpense":
                        MODE_CODE = Declaration.MOD_CODE_NATURE_OF_EXPENSE;
                        break;
                    case "frmStores":
                        MODE_CODE = Declaration.MOD_CODE_STORES;
                        break;
                    case "frmBusinessPurpose":
                        MODE_CODE = Declaration.MOD_CODE_BUSINESS_PURPOSE;
                        break;
                    case "frmCostCenter":
                        MODE_CODE = Declaration.MOD_CODE_COST_CENTER;
                        break;
                    case "frmModeOfPayment":
                        MODE_CODE = Declaration.MOD_CODE_MODE_OF_PAYMENT;
                        break;
                    case "frmModeOfTransportation":
                        MODE_CODE = Declaration.MOD_CODE_MODE_OF_TRANSPO;
                        break;
                    default:
                        MODE_CODE = "";
                        break;
                }

                if (function.HasAccess(MODE_CODE, GlobalSettings.ACCESS_READ) == false)
              { throw new Exception("Sorry you have no access in this module."); }

               if (!isDialog)
                { function.LoadHeaderForm(this, frm); }
                else
                {
                    frm.ShowDialog();
                    frm.Dispose();
                }

               }catch (Exception ex)

            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        #endregion 

    
        private void mnuExit_Click(object sender, EventArgs e)
        {
            CommandPass(Declaration.EXIT_COMMAND);
        }        
        
        private void mnuNew_Click(object sender, EventArgs e)
        {
            CommandPass(Declaration.NEW_COMMAND);
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            CommandPass(Declaration.EDIT_COMMAND);
        }

        private void tlbPrint_Click(object sender, EventArgs e)
        {
            CommandPass(Declaration.PRINT_COMMAND);
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            int intRow = 0;

            foreach (Form frmChild in MdiChildren)
            {
                if (frmChild.Name == "frmShortcut")
                { frmChild.WindowState = FormWindowState.Maximized; }
                else
                {
                    frmChild.Close();
                }

                //if (frmChild.Name == "frmStyleServingStatus")
                //{ frmChild.WindowState = FormWindowState.Maximized; }

                intRow = intRow + 1;
            }
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        
        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            Form frm = this.ActiveMdiChild;

            if (frm == null)
            {
                //tlsMain.Enabled = false;
                return;
            }            
        }

        private void mnuCalculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }
        

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            CommandPass(Declaration.REFRESH_COMMAND);
        }

        private void tlbShowAll_Click(object sender, EventArgs e)
        {
            CommandPass(Declaration.SHOW_ALL_COMMAND);
        }

        private void tlbFilter_Click(object sender, EventArgs e)
        {
            CommandPass(Declaration.FILTER_COMMAND);
        }
        
        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();            
            frm.ShowDialog();
            frm.Dispose();
        }        

        private void mnuVoucher_Click(object sender, EventArgs e)
        {
            frmEPV frm = new frmEPV();
            CheckAccess(frm, false);
        }

        private void mnuUserAccount_Click(object sender, EventArgs e)
        {
            frmUserAccount frm = new frmUserAccount();
            CheckAccess(frm, true);
        }
        
        private void mnu_CAList_Click(object sender, EventArgs e)
        {
            frmCashAdvance frm = new frmCashAdvance();
            CheckAccess(frm, false);
        }

        private void tlbDashboard_Click(object sender, EventArgs e)
        {
            //if (pnlDashboard.Height > 0)
            //{
            //    pnlDashboard.Dock = DockStyle.Bottom;
            //    pnlDashboard.Height = 0;
            //}
            //else
            //{ pnlDashboard.Dock = DockStyle.Left; }

            Form openfrm = Application.OpenForms["frmDashboard"];

            if (openfrm != null)
            {
                frmDashboard frm = (frmDashboard)openfrm;
                frm.Focus();
            }
        }

        private void tlbMyVouchers_Click(object sender, EventArgs e)
        {
            Form openfrm = Application.OpenForms["frmEPV"];

            if (openfrm != null)
            {
                frmEPV frm = (frmEPV)openfrm;
                frm.StatusId = -1;
                frm.ExecuteSQL();
                frm.Focus();
            }
            else
            {
                frmEPV frm = new frmEPV();
                frm.StatusId = -1;
                CheckAccess(frm, false);
            }         
        }

        private void tlbCashAdvanceList_Click(object sender, EventArgs e)
        {
            Form openfrm = Application.OpenForms["frmCashAdvance"];

            if (openfrm != null)
            {
                frmCashAdvance frm = (frmCashAdvance)openfrm;
                frm.StatusId = -1;
                frm.ExecuteSQL();
                frm.Focus();
            }
            else
            { 
                frmCashAdvance frm =  new frmCashAdvance();
                frm.StatusId = -1;
                CheckAccess(frm, false);
            }         
        }

        private void tlbRefresh_Click(object sender, EventArgs e)
        {
            CommandPass(Declaration.REFRESH_COMMAND);
        }

        private void frmMain_MdiChildActivate_1(object sender, EventArgs e)
        {
            Form frm = this.ActiveMdiChild;

            if (frm == null)
            {
                //tlsMain.Enabled = false;
                return;
            }

            foreach (ToolStripItem item in ((ToolStrip)tlsMain).Items)
            {
                if (frm.Name == "frmShortcut")
                {
                    if ((item.Name != "tlbShortcut") && (item.Name != "tlbExit"))
                    { item.Enabled = false; }
                }
                else
                { item.Enabled = true; }
            }

            if (frm.Name == "frmShortcut" || frm.Name.Contains("Detail"))
            { EnableMenu(false); }
            else
            { EnableMenu(true); }
        }

        private void tlbExit_Click(object sender, EventArgs e)
        {
            CommandPass(Declaration.EXIT_COMMAND);
        }
             
        private void mnuExpenseReport_Click(object sender, EventArgs e)
        {
            frmExpenseReport frm = new frmExpenseReport();
            frm.ShowDialog();
        }

        private void summaryOfEPVsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSummaryOfEPVs frm = new frmSummaryOfEPVs();
            frm.ShowDialog();
        }

        private void CAStatusChange(int statusId)
        {
            Form openfrm = Application.OpenForms["frmCashAdvance"];

            if (openfrm != null)
            {
                frmCashAdvance frm = (frmCashAdvance)openfrm;
                frm.StatusId = statusId;
                frm.ExecuteSQL();
                frm.Focus();
            }
            else
            {
                frmCashAdvance frm = new frmCashAdvance();
                frm.StatusId = statusId;
                CheckAccess(frm, false);
            }

            CACountStatus();
        }

        private void EPVStatusChange(int statusId)
        {
            Form openfrm = Application.OpenForms["frmEPV"];

            if (openfrm != null)
            {
                frmEPV frm = (frmEPV)openfrm;
                frm.StatusId = statusId;
                frm.ExecuteSQL();
                frm.Focus();
            }
            else
            {
                frmEPV frm = new frmEPV();
                frm.StatusId = statusId;
                CheckAccess(frm, false);
            }

            EPVCountStatus();
        }
        private void btnEPVApproved_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_APPROVED);
        }

        private void btnEPVRejected_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_REJECTED);
        }

        private void btnEPVReceived_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_RECEIVED);
        }

        private void btnEPV_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_ALL);
        }

        private void btnCASaved_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_SAVED);
        }

        private void btnCASubmitted_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_FOR_APPROVAL);           
        }

        private void btnCAReceiving_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_APPROVED);             
        }

        private void btnCAReleased_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_RELEASED);  
        }

        private void btnCAReceived_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_RECEIVED);
        }

        private void btnSaved_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_SAVED);
        }

        private void btnSubmitted_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_FOR_APPROVAL);
        }

        private void btnForAudit_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_FOR_AUDIT);
        }

        private void btnReleasing_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_FOR_RELEASING);
        }

        private void btnReleased_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_RELEASED);
        }

        private void mnu_SummaryOfEPVs_Click(object sender, EventArgs e)
        {
            frmSummaryOfEPVs frm = new frmSummaryOfEPVs();
            frm.ShowDialog();
        }

        private void mnu_SummaryOfLiquidations_Click(object sender, EventArgs e)
        {
            frmSummaryOfLiquidations frm = new frmSummaryOfLiquidations();
            frm.ShowDialog();
        }

        private void mnuEPVMonitoring_Click(object sender, EventArgs e)
        {
            frmEPVMonitoring frm = new frmEPVMonitoring();
            frm.ShowDialog();
        }

        private void mnuCashAdvanceMonitoring_Click(object sender, EventArgs e)
        {
            frmCAMonitoring frm = new frmCAMonitoring();
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CACountStatus();
            EPVCountStatus();
        }

        private void tlbNew_Click(object sender, EventArgs e)
        {
            Form openfrm = Application.OpenForms["frmEPV"];

            if (openfrm != null)
            {
                frmEPV frm = (frmEPV)openfrm;
                frm.CommandPass(Declaration.NEW_COMMAND);
                frm.Focus();
                frm.ExecuteSQL();
            }
            else
            {
                frmEPV frm = new frmEPV();
                CheckAccess(frm, false);
                frm.CommandPass(Declaration.NEW_COMMAND);
            }
        }

        private void tlbNewCA_Click(object sender, EventArgs e)
        {           
            Form openfrm = Application.OpenForms["frmCashAdvance"];

            if (openfrm != null)
            {
                frmCashAdvance frm = (frmCashAdvance)openfrm;
                frm.CommandPass(Declaration.NEW_COMMAND);
                frm.Focus();
                frm.ExecuteSQL();
            }
            else
            {
                frmCashAdvance frm = new frmCashAdvance();
                CheckAccess(frm, false);
                frm.CommandPass(Declaration.NEW_COMMAND);
            }
        }

        private void btnCARejected_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_REJECTED);
        }

        private void btnCALiquidated_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_LIQUIDATED);
        }

        private void btnCA_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_ALL);
        }
      
        private void Hand_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Default_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCAUploaded_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_UPLOADED);
        }

        private void btnEPVUploaded_Click(object sender, EventArgs e)
        {
            EPVStatusChange(Declaration.EPV_STATUS_ID_UPLOADED);
        }

        private void mnuTopSheetReimbursement_Click(object sender, EventArgs e)
        {
            frmTopSheetForReimbursement frm = new frmTopSheetForReimbursement();
            frm.ShowDialog();
        }


        private void mnuTopSheetLiquidation_Click(object sender, EventArgs e)
        {
            frmTopSheetForLiquidation frm = new frmTopSheetForLiquidation();
            frm.ShowDialog();
        }

        private void userActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserActivity frm = new frmUserActivity();
            CheckAccess(frm, true);
        }

        private void mnuVendor_Click(object sender, EventArgs e)
        {
            frmSupplier frm = new frmSupplier();
            CheckAccess(frm, false);
        }

        private void mnuNatureOfExpense_Click(object sender, EventArgs e)
        {
            frmNatureOfExpense frm = new frmNatureOfExpense();
            CheckAccess(frm, false);
        }

        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStores frm = new frmStores();
            CheckAccess(frm, false);
        }

        private void mnuEPVStatusMonitoring_Click(object sender, EventArgs e)
        {
            frmEPVStatusMonitoring frm = new frmEPVStatusMonitoring();
            frm.ShowDialog();
        }

        private void btnCAForAudit_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_FOR_AUDIT);
        }

        private void btnCAReleasing_Click(object sender, EventArgs e)
        {
            CAStatusChange(Declaration.CA_STATUS_ID_FOR_RELEASING);
        }

        private void mnuStores_Click(object sender, EventArgs e)
        {
            frmStores frm = new frmStores();
            CheckAccess(frm, false);
        }

        private void mnuBusinessPurpose_Click(object sender, EventArgs e)
        {
            frmBusinessPurpose frm = new frmBusinessPurpose();
            CheckAccess(frm, false);
        }

        private void mnuCostCenter_Click(object sender, EventArgs e)
        {
            frmCostCenter frm = new frmCostCenter();
            CheckAccess(frm, false);
        }
        
        private void mnuModeOfPayment_Click(object sender, EventArgs e)
        {
            frmModeOfPayment frm = new frmModeOfPayment();
            CheckAccess(frm, false);
        }

        private void mnuModeOfTranspo_Click(object sender, EventArgs e)
        {
            frmModeOfTransportation frm = new frmModeOfTransportation();
            CheckAccess(frm, false);
        }
    }
}
