namespace MyRIS
{
    partial class frmEPVDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEPVDetail));
            this.lblForm = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBusiness = new System.Windows.Forms.Label();
            this.txtRequestBy = new System.Windows.Forms.TextBox();
            this.txtBusinessOthers = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.dtpRequested = new System.Windows.Forms.DateTimePicker();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.NatureOfExpenseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NatureOfExpense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargeToName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claimToId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vendorAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeToId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTransDate = new System.Windows.Forms.Label();
            this.lblParticulars = new System.Windows.Forms.Label();
            this.txtParticulars = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblTotalExpense = new System.Windows.Forms.Label();
            this.lblCashAdvance = new System.Windows.Forms.Label();
            this.lblCashOver = new System.Windows.Forms.Label();
            this.txtTotalExpense = new System.Windows.Forms.TextBox();
            this.txtCashAdvance = new System.Windows.Forms.TextBox();
            this.txtCashOver = new System.Windows.Forms.TextBox();
            this.txtFormNumber = new System.Windows.Forms.TextBox();
            this.lblCA = new System.Windows.Forms.Label();
            this.txtCA = new System.Windows.Forms.TextBox();
            this.lblNatureOfExpense = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblModeOfPayment = new System.Windows.Forms.Label();
            this.cboModeOfPayment = new System.Windows.Forms.ComboBox();
            this.lblRequired = new System.Windows.Forms.Label();
            this.pnlRequired = new System.Windows.Forms.Panel();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.lblTransaction = new System.Windows.Forms.Label();
            this.dtpHeadApproved = new System.Windows.Forms.DateTimePicker();
            this.dtpUploadedBy = new System.Windows.Forms.DateTimePicker();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtUploadedBy = new System.Windows.Forms.TextBox();
            this.txtAuditedBy = new System.Windows.Forms.TextBox();
            this.txtHeadApprovedBy = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lbUploadedBy = new System.Windows.Forms.Label();
            this.lblAudited = new System.Windows.Forms.Label();
            this.lblHeadApproved = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMainInfo = new System.Windows.Forms.Panel();
            this.cboBusinessPurpose = new System.Windows.Forms.ComboBox();
            this.btnSaveMultiple = new System.Windows.Forms.Button();
            this.txtStore = new System.Windows.Forms.TextBox();
            this.lblOthers = new System.Windows.Forms.Label();
            this.lblCAStatus = new System.Windows.Forms.Label();
            this.txtCAStatus = new System.Windows.Forms.TextBox();
            this.lblChargeTo = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.cboStores = new System.Windows.Forms.ComboBox();
            this.cboChargeTo = new System.Windows.Forms.ComboBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnEditDestination = new System.Windows.Forms.Button();
            this.btnAddMultiple = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpTransaction = new System.Windows.Forms.DateTimePicker();
            this.cboNatureOfExpense = new System.Windows.Forms.ComboBox();
            this.lblDoubleClick = new System.Windows.Forms.Label();
            this.dtpDocsReceived = new System.Windows.Forms.DateTimePicker();
            this.dtpReleased = new System.Windows.Forms.DateTimePicker();
            this.dtpReleasingDate = new System.Windows.Forms.DateTimePicker();
            this.lblBatchDate = new System.Windows.Forms.Label();
            this.dtpBatchDate = new System.Windows.Forms.DateTimePicker();
            this.lblReleasedBy = new System.Windows.Forms.Label();
            this.txtReleasedBy = new System.Windows.Forms.TextBox();
            this.lblDocsReceived = new System.Windows.Forms.Label();
            this.txtDocsReceivedBy = new System.Windows.Forms.TextBox();
            this.lblReleasing = new System.Windows.Forms.Label();
            this.pnlVAT = new System.Windows.Forms.Panel();
            this.lblRefNumber = new System.Windows.Forms.Label();
            this.lblClaimableBy = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTIN = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblVatAmount = new System.Windows.Forms.Label();
            this.lblTIN = new System.Windows.Forms.Label();
            this.txtVatAmount = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.cboClaimTo = new System.Windows.Forms.ComboBox();
            this.btnSearchSupplier = new System.Windows.Forms.Button();
            this.pnlDetailInfo = new System.Windows.Forms.Panel();
            this.pnlTransport = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.cboModeOfTransportation = new System.Windows.Forms.ComboBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.chkPartChargeTo = new System.Windows.Forms.CheckedListBox();
            this.lblPartChargeTo = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlTransportMultiple = new System.Windows.Forms.Panel();
            this.chkDestChargeTo = new System.Windows.Forms.CheckedListBox();
            this.lblDestChargeTo = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.MultiFrom = new System.Windows.Forms.Label();
            this.MultiMode = new System.Windows.Forms.Label();
            this.MultiAmount = new System.Windows.Forms.Label();
            this.MultiTo = new System.Windows.Forms.Label();
            this.txtAmountMulti1 = new System.Windows.Forms.TextBox();
            this.txtFromMulti1 = new System.Windows.Forms.TextBox();
            this.cboModeMulti14 = new System.Windows.Forms.ComboBox();
            this.cboModeMulti12 = new System.Windows.Forms.ComboBox();
            this.cboModeMulti13 = new System.Windows.Forms.ComboBox();
            this.cboModeMulti11 = new System.Windows.Forms.ComboBox();
            this.cboModeMulti10 = new System.Windows.Forms.ComboBox();
            this.cboModeMulti8 = new System.Windows.Forms.ComboBox();
            this.txtAmountMulti5 = new System.Windows.Forms.TextBox();
            this.cboModeMulti4 = new System.Windows.Forms.ComboBox();
            this.txtFromMulti5 = new System.Windows.Forms.TextBox();
            this.cboModeMulti6 = new System.Windows.Forms.ComboBox();
            this.txtAmountMulti3 = new System.Windows.Forms.TextBox();
            this.cboModeMulti2 = new System.Windows.Forms.ComboBox();
            this.txtAmountMulti9 = new System.Windows.Forms.TextBox();
            this.txtAmountMulti7 = new System.Windows.Forms.TextBox();
            this.cboModeMulti9 = new System.Windows.Forms.ComboBox();
            this.cboModeMulti7 = new System.Windows.Forms.ComboBox();
            this.txtFromMulti3 = new System.Windows.Forms.TextBox();
            this.cboModeMulti3 = new System.Windows.Forms.ComboBox();
            this.txtFromMulti9 = new System.Windows.Forms.TextBox();
            this.txtFromMulti7 = new System.Windows.Forms.TextBox();
            this.txtAmountMulti2 = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.cboModeMulti5 = new System.Windows.Forms.ComboBox();
            this.txtAmountMulti6 = new System.Windows.Forms.TextBox();
            this.cboModeMulti1 = new System.Windows.Forms.ComboBox();
            this.txtAmountMulti4 = new System.Windows.Forms.TextBox();
            this.txtAmountMulti14 = new System.Windows.Forms.TextBox();
            this.txtAmountMulti12 = new System.Windows.Forms.TextBox();
            this.txtAmountMulti13 = new System.Windows.Forms.TextBox();
            this.txtAmountMulti11 = new System.Windows.Forms.TextBox();
            this.txtAmountMulti10 = new System.Windows.Forms.TextBox();
            this.txtToMulti14 = new System.Windows.Forms.TextBox();
            this.txtToMulti13 = new System.Windows.Forms.TextBox();
            this.txtToMulti12 = new System.Windows.Forms.TextBox();
            this.txtToMulti11 = new System.Windows.Forms.TextBox();
            this.txtToMulti10 = new System.Windows.Forms.TextBox();
            this.txtAmountMulti8 = new System.Windows.Forms.TextBox();
            this.txtToMulti8 = new System.Windows.Forms.TextBox();
            this.txtFromMulti2 = new System.Windows.Forms.TextBox();
            this.txtToMulti4 = new System.Windows.Forms.TextBox();
            this.txtFromMulti6 = new System.Windows.Forms.TextBox();
            this.txtToMulti6 = new System.Windows.Forms.TextBox();
            this.txtFromMulti14 = new System.Windows.Forms.TextBox();
            this.txtFromMulti4 = new System.Windows.Forms.TextBox();
            this.txtFromMulti13 = new System.Windows.Forms.TextBox();
            this.txtFromMulti12 = new System.Windows.Forms.TextBox();
            this.txtFromMulti11 = new System.Windows.Forms.TextBox();
            this.txtFromMulti10 = new System.Windows.Forms.TextBox();
            this.txtToMulti2 = new System.Windows.Forms.TextBox();
            this.txtToMulti9 = new System.Windows.Forms.TextBox();
            this.txtFromMulti8 = new System.Windows.Forms.TextBox();
            this.txtToMulti7 = new System.Windows.Forms.TextBox();
            this.txtToMulti1 = new System.Windows.Forms.TextBox();
            this.txtToMulti3 = new System.Windows.Forms.TextBox();
            this.txtToMulti5 = new System.Windows.Forms.TextBox();
            this.dtpAudited = new System.Windows.Forms.DateTimePicker();
            this.pnlEditDestination = new System.Windows.Forms.Panel();
            this.txtEditDestination = new System.Windows.Forms.TextBox();
            this.lblEditDestination = new System.Windows.Forms.Label();
            this.txtPastRemark = new System.Windows.Forms.TextBox();
            this.btnSearchHeadApprover = new System.Windows.Forms.Button();
            this.btnSearchDocsReceived = new System.Windows.Forms.Button();
            this.txtMgtApprovedBy = new System.Windows.Forms.TextBox();
            this.dtpMgtApproved = new System.Windows.Forms.DateTimePicker();
            this.lblMgtApprovedBy = new System.Windows.Forms.Label();
            this.btnSearchMgtApprover = new System.Windows.Forms.Button();
            this.chkBoxChargeTo = new System.Windows.Forms.CheckedListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.TSSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripShortcut = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtTotalExpenses = new System.Windows.Forms.TextBox();
            this.lblOF = new System.Windows.Forms.Label();
            this.btnSearchReleasedBy = new System.Windows.Forms.Button();
            this.btnSearchAuditedBy = new System.Windows.Forms.Button();
            this.btnSearchUploadedBy = new System.Windows.Forms.Button();
            this.lblVoucher = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnSubmitEmail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.pnlMainInfo.SuspendLayout();
            this.pnlVAT.SuspendLayout();
            this.pnlDetailInfo.SuspendLayout();
            this.pnlTransport.SuspendLayout();
            this.pnlTransportMultiple.SuspendLayout();
            this.pnlEditDestination.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForm.Location = new System.Drawing.Point(872, 9);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(49, 16);
            this.lblForm.TabIndex = 2;
            this.lblForm.Text = "EPV #:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(78, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.toolTip.SetToolTip(this.lblName, "Name of the individual who actually incurred the expense.");
            // 
            // lblBusiness
            // 
            this.lblBusiness.AutoSize = true;
            this.lblBusiness.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBusiness.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusiness.Location = new System.Drawing.Point(4, 36);
            this.lblBusiness.Name = "lblBusiness";
            this.lblBusiness.Size = new System.Drawing.Size(123, 16);
            this.lblBusiness.TabIndex = 1;
            this.lblBusiness.Text = "Business Purpose:";
            this.toolTip.SetToolTip(this.lblBusiness, "A phrase denoting the main intent or primary reason for the expense.");
            // 
            // txtRequestBy
            // 
            this.txtRequestBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestBy.Location = new System.Drawing.Point(127, 7);
            this.txtRequestBy.Name = "txtRequestBy";
            this.txtRequestBy.ReadOnly = true;
            this.txtRequestBy.Size = new System.Drawing.Size(303, 20);
            this.txtRequestBy.TabIndex = 0;
            this.txtRequestBy.Tag = "-1";
            // 
            // txtBusinessOthers
            // 
            this.txtBusinessOthers.BackColor = System.Drawing.SystemColors.Window;
            this.txtBusinessOthers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBusinessOthers.Location = new System.Drawing.Point(127, 64);
            this.txtBusinessOthers.MaxLength = 250;
            this.txtBusinessOthers.Name = "txtBusinessOthers";
            this.txtBusinessOthers.Size = new System.Drawing.Size(303, 20);
            this.txtBusinessOthers.TabIndex = 2;
            this.txtBusinessOthers.TabStop = false;
            this.txtBusinessOthers.Tag = "";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.White;
            this.lblDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(434, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(96, 16);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Request Date:";
            this.toolTip.SetToolTip(this.lblDate, "Date of submission of the request through the T&E System.");
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.BackColor = System.Drawing.Color.White;
            this.lblDepartment.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(38, 93);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(86, 16);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "Department:";
            this.toolTip.SetToolTip(this.lblDepartment, "Name of the cost center / department to which the expense is related and chargeab" +
        "le to.");
            // 
            // dtpRequested
            // 
            this.dtpRequested.CustomFormat = "MM/dd/yyyy";
            this.dtpRequested.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRequested.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequested.Location = new System.Drawing.Point(533, 7);
            this.dtpRequested.Name = "dtpRequested";
            this.dtpRequested.Size = new System.Drawing.Size(83, 20);
            this.dtpRequested.TabIndex = 3;
            // 
            // dgvList
            // 
            this.dgvList.AllowDrop = true;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NatureOfExpenseId,
            this.Date,
            this.NatureOfExpense,
            this.Particulars,
            this.ChargeToName,
            this.Amount,
            this.vendorId,
            this.vendorName,
            this.tin,
            this.referenceNumber,
            this.vatAmount,
            this.claimToId,
            this.isActive,
            this.vendorAddress,
            this.chargeToId});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvList.Location = new System.Drawing.Point(5, 91);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvList.RowHeadersWidth = 20;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(770, 220);
            this.dgvList.TabIndex = 16;
            this.dgvList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_CellMouseUp);
            this.dgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellValueChanged);
            this.dgvList.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvList_ColumnAdded);
            this.dgvList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_ColumnHeaderMouseClick);
            this.dgvList.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvList_DragDrop);
            this.dgvList.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvList_DragOver);
            this.dgvList.DoubleClick += new System.EventHandler(this.dgvList_DoubleClick);
            this.dgvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvList_MouseDown);
            this.dgvList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvList_MouseMove);
            // 
            // NatureOfExpenseId
            // 
            this.NatureOfExpenseId.HeaderText = "NatureOfExpenseId";
            this.NatureOfExpenseId.Name = "NatureOfExpenseId";
            this.NatureOfExpenseId.Visible = false;
            // 
            // Date
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Date.HeaderText = "Trans Date";
            this.Date.Name = "Date";
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Date.Width = 88;
            // 
            // NatureOfExpense
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NatureOfExpense.DefaultCellStyle = dataGridViewCellStyle3;
            this.NatureOfExpense.HeaderText = "Nature of Expense";
            this.NatureOfExpense.Name = "NatureOfExpense";
            this.NatureOfExpense.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NatureOfExpense.Width = 150;
            // 
            // Particulars
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Particulars.DefaultCellStyle = dataGridViewCellStyle4;
            this.Particulars.HeaderText = "Particulars";
            this.Particulars.Name = "Particulars";
            this.Particulars.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Particulars.Width = 300;
            // 
            // ChargeToName
            // 
            this.ChargeToName.HeaderText = "Charge To";
            this.ChargeToName.Name = "ChargeToName";
            this.ChargeToName.Width = 88;
            // 
            // Amount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Amount.Width = 80;
            // 
            // vendorId
            // 
            this.vendorId.HeaderText = "vendorId";
            this.vendorId.Name = "vendorId";
            this.vendorId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vendorId.Visible = false;
            // 
            // vendorName
            // 
            this.vendorName.HeaderText = "vendorName";
            this.vendorName.Name = "vendorName";
            this.vendorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vendorName.Visible = false;
            // 
            // tin
            // 
            this.tin.HeaderText = "tin";
            this.tin.Name = "tin";
            this.tin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tin.Visible = false;
            // 
            // referenceNumber
            // 
            this.referenceNumber.HeaderText = "referenceNumber";
            this.referenceNumber.Name = "referenceNumber";
            this.referenceNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.referenceNumber.Visible = false;
            // 
            // vatAmount
            // 
            this.vatAmount.HeaderText = "vatAmount";
            this.vatAmount.Name = "vatAmount";
            this.vatAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vatAmount.Visible = false;
            this.vatAmount.Width = 85;
            // 
            // claimToId
            // 
            this.claimToId.HeaderText = "claimToId";
            this.claimToId.Name = "claimToId";
            this.claimToId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.claimToId.Visible = false;
            // 
            // isActive
            // 
            this.isActive.FillWeight = 40F;
            this.isActive.HeaderText = " √";
            this.isActive.Name = "isActive";
            this.isActive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.isActive.Width = 40;
            // 
            // vendorAddress
            // 
            this.vendorAddress.HeaderText = "vendorAddress";
            this.vendorAddress.Name = "vendorAddress";
            this.vendorAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vendorAddress.Visible = false;
            // 
            // chargeToId
            // 
            this.chargeToId.HeaderText = "chargeToId";
            this.chargeToId.Name = "chargeToId";
            this.chargeToId.Visible = false;
            // 
            // lblTransDate
            // 
            this.lblTransDate.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransDate.Location = new System.Drawing.Point(9, 3);
            this.lblTransDate.Name = "lblTransDate";
            this.lblTransDate.Size = new System.Drawing.Size(78, 21);
            this.lblTransDate.TabIndex = 17;
            this.lblTransDate.Text = "Trans. Date";
            this.lblTransDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.lblTransDate, "Date when the transaction actually occurred.");
            // 
            // lblParticulars
            // 
            this.lblParticulars.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParticulars.Location = new System.Drawing.Point(317, 4);
            this.lblParticulars.Name = "lblParticulars";
            this.lblParticulars.Size = new System.Drawing.Size(330, 20);
            this.lblParticulars.TabIndex = 19;
            this.lblParticulars.Text = "Particulars";
            this.lblParticulars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.lblParticulars, "Detailed information and description of the expense incurred.");
            // 
            // txtParticulars
            // 
            this.txtParticulars.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParticulars.Location = new System.Drawing.Point(317, 25);
            this.txtParticulars.MaxLength = 250;
            this.txtParticulars.Name = "txtParticulars";
            this.txtParticulars.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtParticulars.Size = new System.Drawing.Size(330, 20);
            this.txtParticulars.TabIndex = 3;
            this.txtParticulars.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(651, 25);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(94, 20);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(651, 3);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(94, 19);
            this.lblAmount.TabIndex = 24;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.lblAmount, "Total amount paid for the each expense item which the company is required to pay." +
        "");
            // 
            // lblTotalExpense
            // 
            this.lblTotalExpense.AutoSize = true;
            this.lblTotalExpense.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpense.Location = new System.Drawing.Point(873, 167);
            this.lblTotalExpense.Name = "lblTotalExpense";
            this.lblTotalExpense.Size = new System.Drawing.Size(117, 13);
            this.lblTotalExpense.TabIndex = 26;
            this.lblTotalExpense.Text = "TOTAL EXPENSES";
            // 
            // lblCashAdvance
            // 
            this.lblCashAdvance.AutoSize = true;
            this.lblCashAdvance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashAdvance.Location = new System.Drawing.Point(865, 208);
            this.lblCashAdvance.Name = "lblCashAdvance";
            this.lblCashAdvance.Size = new System.Drawing.Size(144, 13);
            this.lblCashAdvance.TabIndex = 27;
            this.lblCashAdvance.Text = "LESS: CASH ADVANCE";
            // 
            // lblCashOver
            // 
            this.lblCashOver.AutoSize = true;
            this.lblCashOver.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashOver.Location = new System.Drawing.Point(862, 251);
            this.lblCashOver.Name = "lblCashOver";
            this.lblCashOver.Size = new System.Drawing.Size(149, 13);
            this.lblCashOver.TabIndex = 28;
            this.lblCashOver.Text = "CASH UNDER / (OVER)";
            // 
            // txtTotalExpense
            // 
            this.txtTotalExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalExpense.Location = new System.Drawing.Point(824, 183);
            this.txtTotalExpense.Name = "txtTotalExpense";
            this.txtTotalExpense.ReadOnly = true;
            this.txtTotalExpense.Size = new System.Drawing.Size(92, 20);
            this.txtTotalExpense.TabIndex = 29;
            this.txtTotalExpense.TabStop = false;
            this.txtTotalExpense.Text = "0";
            // 
            // txtCashAdvance
            // 
            this.txtCashAdvance.Location = new System.Drawing.Point(864, 223);
            this.txtCashAdvance.Name = "txtCashAdvance";
            this.txtCashAdvance.ReadOnly = true;
            this.txtCashAdvance.Size = new System.Drawing.Size(146, 20);
            this.txtCashAdvance.TabIndex = 30;
            this.txtCashAdvance.TabStop = false;
            this.txtCashAdvance.Text = "0";
            this.txtCashAdvance.TextChanged += new System.EventHandler(this.txtCashAdvance_TextChanged);
            // 
            // txtCashOver
            // 
            this.txtCashOver.Location = new System.Drawing.Point(864, 267);
            this.txtCashOver.Name = "txtCashOver";
            this.txtCashOver.ReadOnly = true;
            this.txtCashOver.Size = new System.Drawing.Size(146, 20);
            this.txtCashOver.TabIndex = 31;
            this.txtCashOver.TabStop = false;
            this.txtCashOver.Text = "0";
            // 
            // txtFormNumber
            // 
            this.txtFormNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFormNumber.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormNumber.Location = new System.Drawing.Point(924, 7);
            this.txtFormNumber.Name = "txtFormNumber";
            this.txtFormNumber.ReadOnly = true;
            this.txtFormNumber.Size = new System.Drawing.Size(112, 20);
            this.txtFormNumber.TabIndex = 9;
            this.txtFormNumber.TabStop = false;
            // 
            // lblCA
            // 
            this.lblCA.AutoSize = true;
            this.lblCA.BackColor = System.Drawing.Color.White;
            this.lblCA.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCA.Location = new System.Drawing.Point(880, 40);
            this.lblCA.Name = "lblCA";
            this.lblCA.Size = new System.Drawing.Size(41, 16);
            this.lblCA.TabIndex = 9;
            this.lblCA.Text = "CA #:";
            this.toolTip.SetToolTip(this.lblCA, "The cash advance series number to which the expense is related and applicable. (R" +
        "equired only for liquidations.)");
            // 
            // txtCA
            // 
            this.txtCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCA.Location = new System.Drawing.Point(924, 38);
            this.txtCA.Name = "txtCA";
            this.txtCA.Size = new System.Drawing.Size(112, 20);
            this.txtCA.TabIndex = 10;
            this.txtCA.TabStop = false;
            this.txtCA.Tag = "-1";
            this.txtCA.Text = "0";
            this.toolTip.SetToolTip(this.txtCA, "Press Enter to verify CA #");
            this.txtCA.Enter += new System.EventHandler(this.txtCA_Enter);
            this.txtCA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCA_KeyDown);
            // 
            // lblNatureOfExpense
            // 
            this.lblNatureOfExpense.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNatureOfExpense.Location = new System.Drawing.Point(93, 3);
            this.lblNatureOfExpense.Name = "lblNatureOfExpense";
            this.lblNatureOfExpense.Size = new System.Drawing.Size(219, 19);
            this.lblNatureOfExpense.TabIndex = 39;
            this.lblNatureOfExpense.Text = "Nature of Expense";
            this.lblNatureOfExpense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.lblNatureOfExpense, "Appropriate expense type classification.");
            // 
            // cboDepartment
            // 
            this.cboDepartment.AccessibleDescription = "";
            this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(127, 90);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(303, 22);
            this.cboDepartment.TabIndex = 4;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValidation_SelectedIndexChanged);
            // 
            // lblModeOfPayment
            // 
            this.lblModeOfPayment.AutoSize = true;
            this.lblModeOfPayment.BackColor = System.Drawing.Color.White;
            this.lblModeOfPayment.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeOfPayment.Location = new System.Drawing.Point(647, 36);
            this.lblModeOfPayment.Name = "lblModeOfPayment";
            this.lblModeOfPayment.Size = new System.Drawing.Size(123, 16);
            this.lblModeOfPayment.TabIndex = 7;
            this.lblModeOfPayment.Text = "Mode of Payment:";
            // 
            // cboModeOfPayment
            // 
            this.cboModeOfPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeOfPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeOfPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeOfPayment.Enabled = false;
            this.cboModeOfPayment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeOfPayment.FormattingEnabled = true;
            this.cboModeOfPayment.Location = new System.Drawing.Point(773, 33);
            this.cboModeOfPayment.Name = "cboModeOfPayment";
            this.cboModeOfPayment.Size = new System.Drawing.Size(93, 22);
            this.cboModeOfPayment.TabIndex = 8;
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.Location = new System.Drawing.Point(955, 553);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(66, 16);
            this.lblRequired.TabIndex = 90;
            this.lblRequired.Text = "Required";
            // 
            // pnlRequired
            // 
            this.pnlRequired.Location = new System.Drawing.Point(953, 524);
            this.pnlRequired.Name = "pnlRequired";
            this.pnlRequired.Size = new System.Drawing.Size(71, 26);
            this.pnlRequired.TabIndex = 91;
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(773, 6);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(93, 22);
            this.cboTransactionType.TabIndex = 6;
            this.cboTransactionType.SelectedIndexChanged += new System.EventHandler(this.cboTransactionType_SelectedIndexChanged);
            // 
            // lblTransaction
            // 
            this.lblTransaction.AutoSize = true;
            this.lblTransaction.BackColor = System.Drawing.Color.White;
            this.lblTransaction.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransaction.Location = new System.Drawing.Point(651, 9);
            this.lblTransaction.Name = "lblTransaction";
            this.lblTransaction.Size = new System.Drawing.Size(119, 16);
            this.lblTransaction.TabIndex = 6;
            this.lblTransaction.Text = "Transaction Type:";
            this.toolTip.SetToolTip(this.lblTransaction, "Proper classification as to reimbursement / liquidation.");
            // 
            // dtpHeadApproved
            // 
            this.dtpHeadApproved.CalendarFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHeadApproved.CustomFormat = "MM/dd/yyyy";
            this.dtpHeadApproved.Enabled = false;
            this.dtpHeadApproved.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHeadApproved.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeadApproved.Location = new System.Drawing.Point(35, 573);
            this.dtpHeadApproved.Name = "dtpHeadApproved";
            this.dtpHeadApproved.Size = new System.Drawing.Size(77, 20);
            this.dtpHeadApproved.TabIndex = 100;
            // 
            // dtpUploadedBy
            // 
            this.dtpUploadedBy.CalendarFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpUploadedBy.CustomFormat = "MM/dd/yyyy";
            this.dtpUploadedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpUploadedBy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUploadedBy.Location = new System.Drawing.Point(566, 570);
            this.dtpUploadedBy.Name = "dtpUploadedBy";
            this.dtpUploadedBy.Size = new System.Drawing.Size(77, 20);
            this.dtpUploadedBy.TabIndex = 102;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(792, 444);
            this.txtRemarks.MaxLength = 300;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(251, 45);
            this.txtRemarks.TabIndex = 117;
            this.txtRemarks.Tag = "";
            // 
            // txtUploadedBy
            // 
            this.txtUploadedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUploadedBy.Location = new System.Drawing.Point(544, 517);
            this.txtUploadedBy.Multiline = true;
            this.txtUploadedBy.Name = "txtUploadedBy";
            this.txtUploadedBy.ReadOnly = true;
            this.txtUploadedBy.Size = new System.Drawing.Size(125, 50);
            this.txtUploadedBy.TabIndex = 116;
            this.txtUploadedBy.Tag = "-1";
            this.txtUploadedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAuditedBy
            // 
            this.txtAuditedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditedBy.Location = new System.Drawing.Point(410, 517);
            this.txtAuditedBy.Multiline = true;
            this.txtAuditedBy.Name = "txtAuditedBy";
            this.txtAuditedBy.ReadOnly = true;
            this.txtAuditedBy.Size = new System.Drawing.Size(125, 50);
            this.txtAuditedBy.TabIndex = 115;
            this.txtAuditedBy.Tag = "-1";
            this.txtAuditedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeadApprovedBy
            // 
            this.txtHeadApprovedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeadApprovedBy.Location = new System.Drawing.Point(10, 517);
            this.txtHeadApprovedBy.Multiline = true;
            this.txtHeadApprovedBy.Name = "txtHeadApprovedBy";
            this.txtHeadApprovedBy.ReadOnly = true;
            this.txtHeadApprovedBy.Size = new System.Drawing.Size(125, 50);
            this.txtHeadApprovedBy.TabIndex = 114;
            this.txtHeadApprovedBy.Tag = "-1";
            this.txtHeadApprovedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(916, 339);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(47, 15);
            this.lblRemarks.TabIndex = 112;
            this.lblRemarks.Text = "Remarks";
            // 
            // lbUploadedBy
            // 
            this.lbUploadedBy.AutoSize = true;
            this.lbUploadedBy.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUploadedBy.Location = new System.Drawing.Point(547, 501);
            this.lbUploadedBy.Name = "lbUploadedBy";
            this.lbUploadedBy.Size = new System.Drawing.Size(68, 15);
            this.lbUploadedBy.TabIndex = 111;
            this.lbUploadedBy.Text = "Uploaded by:";
            // 
            // lblAudited
            // 
            this.lblAudited.AutoSize = true;
            this.lblAudited.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudited.Location = new System.Drawing.Point(413, 501);
            this.lblAudited.Name = "lblAudited";
            this.lblAudited.Size = new System.Drawing.Size(60, 15);
            this.lblAudited.TabIndex = 110;
            this.lblAudited.Text = "Audited by:";
            // 
            // lblHeadApproved
            // 
            this.lblHeadApproved.AutoSize = true;
            this.lblHeadApproved.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadApproved.Location = new System.Drawing.Point(11, 499);
            this.lblHeadApproved.Name = "lblHeadApproved";
            this.lblHeadApproved.Size = new System.Drawing.Size(95, 15);
            this.lblHeadApproved.TabIndex = 109;
            this.lblHeadApproved.Text = "Head Approved by:";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 100;
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 20;
            this.toolTip.ShowAlways = true;
            // 
            // pnlMainInfo
            // 
            this.pnlMainInfo.Controls.Add(this.cboBusinessPurpose);
            this.pnlMainInfo.Controls.Add(this.lblName);
            this.pnlMainInfo.Controls.Add(this.btnSaveMultiple);
            this.pnlMainInfo.Controls.Add(this.lblForm);
            this.pnlMainInfo.Controls.Add(this.lblBusiness);
            this.pnlMainInfo.Controls.Add(this.txtRequestBy);
            this.pnlMainInfo.Controls.Add(this.txtStore);
            this.pnlMainInfo.Controls.Add(this.txtBusinessOthers);
            this.pnlMainInfo.Controls.Add(this.lblOthers);
            this.pnlMainInfo.Controls.Add(this.lblDate);
            this.pnlMainInfo.Controls.Add(this.lblDepartment);
            this.pnlMainInfo.Controls.Add(this.dtpRequested);
            this.pnlMainInfo.Controls.Add(this.txtFormNumber);
            this.pnlMainInfo.Controls.Add(this.lblCAStatus);
            this.pnlMainInfo.Controls.Add(this.lblCA);
            this.pnlMainInfo.Controls.Add(this.txtCAStatus);
            this.pnlMainInfo.Controls.Add(this.txtCA);
            this.pnlMainInfo.Controls.Add(this.lblChargeTo);
            this.pnlMainInfo.Controls.Add(this.lblStore);
            this.pnlMainInfo.Controls.Add(this.cboStores);
            this.pnlMainInfo.Controls.Add(this.cboDepartment);
            this.pnlMainInfo.Controls.Add(this.lblModeOfPayment);
            this.pnlMainInfo.Controls.Add(this.cboChargeTo);
            this.pnlMainInfo.Controls.Add(this.cboTransactionType);
            this.pnlMainInfo.Controls.Add(this.lblTransaction);
            this.pnlMainInfo.Controls.Add(this.cboModeOfPayment);
            this.pnlMainInfo.Location = new System.Drawing.Point(7, 32);
            this.pnlMainInfo.Name = "pnlMainInfo";
            this.pnlMainInfo.Size = new System.Drawing.Size(1048, 121);
            this.pnlMainInfo.TabIndex = 0;
            this.toolTip.SetToolTip(this.pnlMainInfo, " ");
            // 
            // cboBusinessPurpose
            // 
            this.cboBusinessPurpose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBusinessPurpose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBusinessPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusinessPurpose.FormattingEnabled = true;
            this.cboBusinessPurpose.Location = new System.Drawing.Point(127, 35);
            this.cboBusinessPurpose.Name = "cboBusinessPurpose";
            this.cboBusinessPurpose.Size = new System.Drawing.Size(303, 21);
            this.cboBusinessPurpose.TabIndex = 1;
            this.cboBusinessPurpose.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValidation_SelectedIndexChanged);
            // 
            // btnSaveMultiple
            // 
            this.btnSaveMultiple.BackgroundImage = global::MyRIS.Properties.Resources.Save_Icon;
            this.btnSaveMultiple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveMultiple.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMultiple.Location = new System.Drawing.Point(616, 32);
            this.btnSaveMultiple.Name = "btnSaveMultiple";
            this.btnSaveMultiple.Size = new System.Drawing.Size(27, 24);
            this.btnSaveMultiple.TabIndex = 8;
            this.btnSaveMultiple.TabStop = false;
            this.btnSaveMultiple.Tag = "";
            this.toolTip.SetToolTip(this.btnSaveMultiple, "Set Charge To");
            this.btnSaveMultiple.UseVisualStyleBackColor = true;
            this.btnSaveMultiple.Visible = false;
            this.btnSaveMultiple.Click += new System.EventHandler(this.btnSaveMultiple_Click);
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.SystemColors.Window;
            this.txtStore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtStore.Location = new System.Drawing.Point(485, 64);
            this.txtStore.Name = "txtStore";
            this.txtStore.Size = new System.Drawing.Size(340, 20);
            this.txtStore.TabIndex = 5;
            this.txtStore.Tag = "";
            this.txtStore.Text = "Search Store";
            this.txtStore.Enter += new System.EventHandler(this.txtStore_Enter);
            this.txtStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStore_KeyDown);
            this.txtStore.Leave += new System.EventHandler(this.txtStore_Leave);
            // 
            // lblOthers
            // 
            this.lblOthers.AutoSize = true;
            this.lblOthers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOthers.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOthers.Location = new System.Drawing.Point(33, 67);
            this.lblOthers.Name = "lblOthers";
            this.lblOthers.Size = new System.Drawing.Size(94, 16);
            this.lblOthers.TabIndex = 2;
            this.lblOthers.Text = "Other Details:";
            this.toolTip.SetToolTip(this.lblOthers, "Other generic description of the business transaction (What, When, Where, etc.) w" +
        "hich supports that the expense is necessary, reasonable and appropriate.");
            // 
            // lblCAStatus
            // 
            this.lblCAStatus.AutoSize = true;
            this.lblCAStatus.BackColor = System.Drawing.Color.White;
            this.lblCAStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCAStatus.Location = new System.Drawing.Point(848, 68);
            this.lblCAStatus.Name = "lblCAStatus";
            this.lblCAStatus.Size = new System.Drawing.Size(73, 16);
            this.lblCAStatus.TabIndex = 9;
            this.lblCAStatus.Text = "CA Status:";
            // 
            // txtCAStatus
            // 
            this.txtCAStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCAStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCAStatus.Location = new System.Drawing.Point(924, 66);
            this.txtCAStatus.Name = "txtCAStatus";
            this.txtCAStatus.ReadOnly = true;
            this.txtCAStatus.Size = new System.Drawing.Size(112, 20);
            this.txtCAStatus.TabIndex = 11;
            this.txtCAStatus.TabStop = false;
            this.txtCAStatus.Tag = "-1";
            // 
            // lblChargeTo
            // 
            this.lblChargeTo.AutoSize = true;
            this.lblChargeTo.BackColor = System.Drawing.Color.White;
            this.lblChargeTo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargeTo.Location = new System.Drawing.Point(436, 36);
            this.lblChargeTo.Name = "lblChargeTo";
            this.lblChargeTo.Size = new System.Drawing.Size(77, 16);
            this.lblChargeTo.TabIndex = 8;
            this.lblChargeTo.Text = "Charge To:";
            this.toolTip.SetToolTip(this.lblChargeTo, "Name of the company to which the expense is related and chargeable to.");
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.BackColor = System.Drawing.Color.White;
            this.lblStore.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.Location = new System.Drawing.Point(436, 65);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(46, 16);
            this.lblStore.TabIndex = 5;
            this.lblStore.Text = "Store:";
            this.toolTip.SetToolTip(this.lblStore, "Name of the store to which the expense is related and chargeable to.");
            // 
            // cboStores
            // 
            this.cboStores.AccessibleDescription = "";
            this.cboStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStores.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStores.FormattingEnabled = true;
            this.cboStores.Location = new System.Drawing.Point(485, 87);
            this.cboStores.Name = "cboStores";
            this.cboStores.Size = new System.Drawing.Size(340, 22);
            this.cboStores.TabIndex = 5;
            this.cboStores.TabStop = false;
            this.cboStores.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValidation_SelectedIndexChanged);
            // 
            // cboChargeTo
            // 
            this.cboChargeTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboChargeTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboChargeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChargeTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChargeTo.FormattingEnabled = true;
            this.cboChargeTo.Location = new System.Drawing.Point(533, 33);
            this.cboChargeTo.Name = "cboChargeTo";
            this.cboChargeTo.Size = new System.Drawing.Size(83, 22);
            this.cboChargeTo.TabIndex = 7;
            this.cboChargeTo.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValidation_SelectedIndexChanged);
            this.cboChargeTo.SelectionChangeCommitted += new System.EventHandler(this.cboChargeTo_SelectionChangeCommitted);
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::MyRIS.Properties.Resources.Go_Back_Icon;
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReturn.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(792, 292);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(46, 43);
            this.btnReturn.TabIndex = 167;
            this.btnReturn.TabStop = false;
            this.btnReturn.Tag = "";
            this.toolTip.SetToolTip(this.btnReturn, "Return To Requester");
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Visible = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnEditDestination
            // 
            this.btnEditDestination.BackgroundImage = global::MyRIS.Properties.Resources.Save_Icon;
            this.btnEditDestination.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditDestination.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDestination.Location = new System.Drawing.Point(258, 22);
            this.btnEditDestination.Name = "btnEditDestination";
            this.btnEditDestination.Size = new System.Drawing.Size(27, 24);
            this.btnEditDestination.TabIndex = 8;
            this.btnEditDestination.TabStop = false;
            this.toolTip.SetToolTip(this.btnEditDestination, "Update");
            this.btnEditDestination.UseVisualStyleBackColor = true;
            this.btnEditDestination.Click += new System.EventHandler(this.btnEditDestination_Click);
            // 
            // btnAddMultiple
            // 
            this.btnAddMultiple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddMultiple.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMultiple.Image = global::MyRIS.Properties.Resources.Add_Icon;
            this.btnAddMultiple.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMultiple.Location = new System.Drawing.Point(374, 408);
            this.btnAddMultiple.Name = "btnAddMultiple";
            this.btnAddMultiple.Size = new System.Drawing.Size(123, 31);
            this.btnAddMultiple.TabIndex = 8;
            this.btnAddMultiple.TabStop = false;
            this.btnAddMultiple.Text = "ADD DETAIL";
            this.btnAddMultiple.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMultiple.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnAddMultiple, "Add");
            this.btnAddMultiple.UseVisualStyleBackColor = true;
            this.btnAddMultiple.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::MyRIS.Properties.Resources.Delete_Icon;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(749, 315);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(26, 24);
            this.btnDelete.TabIndex = 103;
            this.toolTip.SetToolTip(this.btnDelete, "Delete");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::MyRIS.Properties.Resources.Print_Icon;
            this.btnPrint.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(997, 292);
            this.btnPrint.MaximumSize = new System.Drawing.Size(46, 43);
            this.btnPrint.MinimumSize = new System.Drawing.Size(46, 43);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(46, 43);
            this.btnPrint.TabIndex = 161;
            this.btnPrint.TabStop = false;
            this.toolTip.SetToolTip(this.btnPrint, "Print");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.BackgroundImage = global::MyRIS.Properties.Resources.Reject_Icon;
            this.btnDecline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDecline.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecline.Location = new System.Drawing.Point(948, 291);
            this.btnDecline.MaximumSize = new System.Drawing.Size(46, 43);
            this.btnDecline.MinimumSize = new System.Drawing.Size(46, 43);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(46, 43);
            this.btnDecline.TabIndex = 35;
            this.btnDecline.TabStop = false;
            this.btnDecline.Tag = "";
            this.toolTip.SetToolTip(this.btnDecline, "Reject");
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Visible = false;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackgroundImage = global::MyRIS.Properties.Resources.Accept_Icon;
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccept.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(896, 292);
            this.btnAccept.MaximumSize = new System.Drawing.Size(46, 43);
            this.btnAccept.MinimumSize = new System.Drawing.Size(46, 43);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(46, 43);
            this.btnAccept.TabIndex = 130;
            this.btnAccept.TabStop = false;
            this.btnAccept.Tag = "";
            this.toolTip.SetToolTip(this.btnAccept, "Accept");
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Visible = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackgroundImage = global::MyRIS.Properties.Resources.Submit_Icon;
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubmit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(896, 291);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(46, 43);
            this.btnSubmit.TabIndex = 35;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Tag = "";
            this.toolTip.SetToolTip(this.btnSubmit, "Submit");
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::MyRIS.Properties.Resources.Save_Icon;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(845, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(46, 43);
            this.btnSave.TabIndex = 130;
            this.btnSave.TabStop = false;
            this.btnSave.Tag = "";
            this.toolTip.SetToolTip(this.btnSave, "Save and Edit Later");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpTransaction
            // 
            this.dtpTransaction.CustomFormat = "MM/dd/yyyy";
            this.dtpTransaction.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransaction.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransaction.Location = new System.Drawing.Point(9, 25);
            this.dtpTransaction.Name = "dtpTransaction";
            this.dtpTransaction.Size = new System.Drawing.Size(78, 20);
            this.dtpTransaction.TabIndex = 1;
            // 
            // cboNatureOfExpense
            // 
            this.cboNatureOfExpense.AccessibleDescription = "";
            this.cboNatureOfExpense.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNatureOfExpense.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNatureOfExpense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNatureOfExpense.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNatureOfExpense.FormattingEnabled = true;
            this.cboNatureOfExpense.Location = new System.Drawing.Point(93, 25);
            this.cboNatureOfExpense.Name = "cboNatureOfExpense";
            this.cboNatureOfExpense.Size = new System.Drawing.Size(221, 22);
            this.cboNatureOfExpense.TabIndex = 2;
            this.cboNatureOfExpense.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValidation_SelectedIndexChanged);
            this.cboNatureOfExpense.SelectedValueChanged += new System.EventHandler(this.cboNature_SelectedValueChanged);
            // 
            // lblDoubleClick
            // 
            this.lblDoubleClick.AutoSize = true;
            this.lblDoubleClick.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDoubleClick.Location = new System.Drawing.Point(11, 465);
            this.lblDoubleClick.Name = "lblDoubleClick";
            this.lblDoubleClick.Size = new System.Drawing.Size(131, 13);
            this.lblDoubleClick.TabIndex = 126;
            this.lblDoubleClick.Text = "*Double click a row to edit";
            // 
            // dtpDocsReceived
            // 
            this.dtpDocsReceived.CustomFormat = "MM/dd/yyyy";
            this.dtpDocsReceived.Enabled = false;
            this.dtpDocsReceived.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDocsReceived.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocsReceived.Location = new System.Drawing.Point(301, 571);
            this.dtpDocsReceived.Name = "dtpDocsReceived";
            this.dtpDocsReceived.Size = new System.Drawing.Size(77, 20);
            this.dtpDocsReceived.TabIndex = 132;
            // 
            // dtpReleased
            // 
            this.dtpReleased.CustomFormat = "MM/dd/yyyy";
            this.dtpReleased.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReleased.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReleased.Location = new System.Drawing.Point(705, 570);
            this.dtpReleased.Name = "dtpReleased";
            this.dtpReleased.Size = new System.Drawing.Size(77, 20);
            this.dtpReleased.TabIndex = 134;
            // 
            // dtpReleasingDate
            // 
            this.dtpReleasingDate.CustomFormat = "MM/dd/yyyy";
            this.dtpReleasingDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReleasingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReleasingDate.Location = new System.Drawing.Point(840, 556);
            this.dtpReleasingDate.Name = "dtpReleasingDate";
            this.dtpReleasingDate.Size = new System.Drawing.Size(78, 20);
            this.dtpReleasingDate.TabIndex = 136;
            // 
            // lblBatchDate
            // 
            this.lblBatchDate.AutoSize = true;
            this.lblBatchDate.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchDate.Location = new System.Drawing.Point(849, 497);
            this.lblBatchDate.Name = "lblBatchDate";
            this.lblBatchDate.Size = new System.Drawing.Size(59, 15);
            this.lblBatchDate.TabIndex = 147;
            this.lblBatchDate.Text = "Batch Date:";
            // 
            // dtpBatchDate
            // 
            this.dtpBatchDate.CustomFormat = "MM/dd/yyyy";
            this.dtpBatchDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatchDate.Location = new System.Drawing.Point(841, 515);
            this.dtpBatchDate.Name = "dtpBatchDate";
            this.dtpBatchDate.Size = new System.Drawing.Size(77, 20);
            this.dtpBatchDate.TabIndex = 139;
            // 
            // lblReleasedBy
            // 
            this.lblReleasedBy.AutoSize = true;
            this.lblReleasedBy.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleasedBy.Location = new System.Drawing.Point(681, 499);
            this.lblReleasedBy.Name = "lblReleasedBy";
            this.lblReleasedBy.Size = new System.Drawing.Size(99, 15);
            this.lblReleasedBy.TabIndex = 144;
            this.lblReleasedBy.Text = "Released/Settled by:";
            // 
            // txtReleasedBy
            // 
            this.txtReleasedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReleasedBy.Location = new System.Drawing.Point(678, 517);
            this.txtReleasedBy.Multiline = true;
            this.txtReleasedBy.Name = "txtReleasedBy";
            this.txtReleasedBy.ReadOnly = true;
            this.txtReleasedBy.Size = new System.Drawing.Size(125, 50);
            this.txtReleasedBy.TabIndex = 145;
            this.txtReleasedBy.Tag = "-1";
            this.txtReleasedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDocsReceived
            // 
            this.lblDocsReceived.AutoSize = true;
            this.lblDocsReceived.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocsReceived.Location = new System.Drawing.Point(280, 499);
            this.lblDocsReceived.Name = "lblDocsReceived";
            this.lblDocsReceived.Size = new System.Drawing.Size(91, 15);
            this.lblDocsReceived.TabIndex = 139;
            this.lblDocsReceived.Text = "Docs Received by:";
            // 
            // txtDocsReceivedBy
            // 
            this.txtDocsReceivedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocsReceivedBy.Location = new System.Drawing.Point(277, 517);
            this.txtDocsReceivedBy.Multiline = true;
            this.txtDocsReceivedBy.Name = "txtDocsReceivedBy";
            this.txtDocsReceivedBy.ReadOnly = true;
            this.txtDocsReceivedBy.Size = new System.Drawing.Size(125, 50);
            this.txtDocsReceivedBy.TabIndex = 139;
            this.txtDocsReceivedBy.Tag = "-1";
            this.txtDocsReceivedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReleasing
            // 
            this.lblReleasing.AutoSize = true;
            this.lblReleasing.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleasing.Location = new System.Drawing.Point(840, 538);
            this.lblReleasing.Name = "lblReleasing";
            this.lblReleasing.Size = new System.Drawing.Size(78, 15);
            this.lblReleasing.TabIndex = 137;
            this.lblReleasing.Text = "Releasing Date:";
            // 
            // pnlVAT
            // 
            this.pnlVAT.Controls.Add(this.lblRefNumber);
            this.pnlVAT.Controls.Add(this.lblClaimableBy);
            this.pnlVAT.Controls.Add(this.txtAddress);
            this.pnlVAT.Controls.Add(this.txtTIN);
            this.pnlVAT.Controls.Add(this.lblAddress);
            this.pnlVAT.Controls.Add(this.lblVatAmount);
            this.pnlVAT.Controls.Add(this.lblTIN);
            this.pnlVAT.Controls.Add(this.txtVatAmount);
            this.pnlVAT.Controls.Add(this.lblSupplier);
            this.pnlVAT.Controls.Add(this.txtReferenceNumber);
            this.pnlVAT.Controls.Add(this.txtSupplier);
            this.pnlVAT.Controls.Add(this.cboClaimTo);
            this.pnlVAT.Controls.Add(this.btnSearchSupplier);
            this.pnlVAT.Enabled = false;
            this.pnlVAT.Location = new System.Drawing.Point(3, 53);
            this.pnlVAT.Name = "pnlVAT";
            this.pnlVAT.Size = new System.Drawing.Size(772, 41);
            this.pnlVAT.TabIndex = 162;
            // 
            // lblRefNumber
            // 
            this.lblRefNumber.AutoSize = true;
            this.lblRefNumber.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefNumber.Location = new System.Drawing.Point(591, -4);
            this.lblRefNumber.Name = "lblRefNumber";
            this.lblRefNumber.Size = new System.Drawing.Size(60, 15);
            this.lblRefNumber.TabIndex = 4;
            this.lblRefNumber.Text = "Reference #";
            // 
            // lblClaimableBy
            // 
            this.lblClaimableBy.Location = new System.Drawing.Point(11, -1);
            this.lblClaimableBy.Name = "lblClaimableBy";
            this.lblClaimableBy.Size = new System.Drawing.Size(70, 13);
            this.lblClaimableBy.TabIndex = 93;
            this.lblClaimableBy.Text = "Claimable By:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(245, 14);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(192, 20);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.TabStop = false;
            this.txtAddress.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // txtTIN
            // 
            this.txtTIN.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTIN.Location = new System.Drawing.Point(443, 13);
            this.txtTIN.Name = "txtTIN";
            this.txtTIN.ReadOnly = true;
            this.txtTIN.Size = new System.Drawing.Size(112, 20);
            this.txtTIN.TabIndex = 1;
            this.txtTIN.TabStop = false;
            this.txtTIN.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(318, -3);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(53, 15);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "ADDRESS";
            // 
            // lblVatAmount
            // 
            this.lblVatAmount.AutoSize = true;
            this.lblVatAmount.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatAmount.Location = new System.Drawing.Point(694, -4);
            this.lblVatAmount.Name = "lblVatAmount";
            this.lblVatAmount.Size = new System.Drawing.Size(65, 15);
            this.lblVatAmount.TabIndex = 4;
            this.lblVatAmount.Text = "VAT Amount";
            // 
            // lblTIN
            // 
            this.lblTIN.AutoSize = true;
            this.lblTIN.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIN.Location = new System.Drawing.Point(486, -4);
            this.lblTIN.Name = "lblTIN";
            this.lblTIN.Size = new System.Drawing.Size(22, 15);
            this.lblTIN.TabIndex = 4;
            this.lblTIN.Text = "TIN";
            // 
            // txtVatAmount
            // 
            this.txtVatAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatAmount.Location = new System.Drawing.Point(687, 14);
            this.txtVatAmount.Name = "txtVatAmount";
            this.txtVatAmount.Size = new System.Drawing.Size(79, 20);
            this.txtVatAmount.TabIndex = 1;
            this.txtVatAmount.Text = "0";
            this.txtVatAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVatAmount.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(127, -1);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(46, 15);
            this.lblSupplier.TabIndex = 3;
            this.lblSupplier.Text = "Supplier";
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceNumber.Location = new System.Drawing.Point(561, 13);
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(122, 20);
            this.txtReferenceNumber.TabIndex = 1;
            this.txtReferenceNumber.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(88, 15);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(124, 20);
            this.txtSupplier.TabIndex = 0;
            this.txtSupplier.Tag = "-1";
            this.txtSupplier.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // cboClaimTo
            // 
            this.cboClaimTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClaimTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClaimTo.FormattingEnabled = true;
            this.cboClaimTo.Location = new System.Drawing.Point(12, 15);
            this.cboClaimTo.Name = "cboClaimTo";
            this.cboClaimTo.Size = new System.Drawing.Size(70, 22);
            this.cboClaimTo.TabIndex = 43;
            // 
            // btnSearchSupplier
            // 
            this.btnSearchSupplier.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchSupplier.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSupplier.Location = new System.Drawing.Point(218, 13);
            this.btnSearchSupplier.Name = "btnSearchSupplier";
            this.btnSearchSupplier.Size = new System.Drawing.Size(21, 22);
            this.btnSearchSupplier.TabIndex = 92;
            this.btnSearchSupplier.TabStop = false;
            this.btnSearchSupplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchSupplier.UseVisualStyleBackColor = true;
            this.btnSearchSupplier.Click += new System.EventHandler(this.btnSearchSupplier_Click);
            // 
            // pnlDetailInfo
            // 
            this.pnlDetailInfo.Controls.Add(this.pnlTransport);
            this.pnlDetailInfo.Controls.Add(this.chkPartChargeTo);
            this.pnlDetailInfo.Controls.Add(this.dtpTransaction);
            this.pnlDetailInfo.Controls.Add(this.lblTransDate);
            this.pnlDetailInfo.Controls.Add(this.lblPartChargeTo);
            this.pnlDetailInfo.Controls.Add(this.dgvList);
            this.pnlDetailInfo.Controls.Add(this.pnlVAT);
            this.pnlDetailInfo.Controls.Add(this.txtParticulars);
            this.pnlDetailInfo.Controls.Add(this.txtAmount);
            this.pnlDetailInfo.Controls.Add(this.lblAmount);
            this.pnlDetailInfo.Controls.Add(this.btnAdd);
            this.pnlDetailInfo.Controls.Add(this.lblNatureOfExpense);
            this.pnlDetailInfo.Controls.Add(this.btnDelete);
            this.pnlDetailInfo.Controls.Add(this.lblParticulars);
            this.pnlDetailInfo.Controls.Add(this.cboNatureOfExpense);
            this.pnlDetailInfo.Location = new System.Drawing.Point(7, 154);
            this.pnlDetailInfo.Name = "pnlDetailInfo";
            this.pnlDetailInfo.Size = new System.Drawing.Size(779, 342);
            this.pnlDetailInfo.TabIndex = 1;
            // 
            // pnlTransport
            // 
            this.pnlTransport.Controls.Add(this.lblFrom);
            this.pnlTransport.Controls.Add(this.txtTo);
            this.pnlTransport.Controls.Add(this.lblMode);
            this.pnlTransport.Controls.Add(this.cboModeOfTransportation);
            this.pnlTransport.Controls.Add(this.txtFrom);
            this.pnlTransport.Controls.Add(this.lblTo);
            this.pnlTransport.Location = new System.Drawing.Point(317, -1);
            this.pnlTransport.Name = "pnlTransport";
            this.pnlTransport.Size = new System.Drawing.Size(330, 48);
            this.pnlTransport.TabIndex = 163;
            this.pnlTransport.Visible = false;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(49, 5);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(32, 15);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "From";
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(120, 23);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(99, 20);
            this.txtTo.TabIndex = 10;
            this.txtTo.TextChanged += new System.EventHandler(this.txtToMulti1_TextChanged);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(263, 5);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(32, 15);
            this.lblMode.TabIndex = 11;
            this.lblMode.Text = "Mode";
            // 
            // cboModeOfTransportation
            // 
            this.cboModeOfTransportation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeOfTransportation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeOfTransportation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeOfTransportation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeOfTransportation.FormattingEnabled = true;
            this.cboModeOfTransportation.Location = new System.Drawing.Point(231, 22);
            this.cboModeOfTransportation.Name = "cboModeOfTransportation";
            this.cboModeOfTransportation.Size = new System.Drawing.Size(90, 22);
            this.cboModeOfTransportation.TabIndex = 11;
            // 
            // txtFrom
            // 
            this.txtFrom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(9, 23);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(99, 20);
            this.txtFrom.TabIndex = 9;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(162, 5);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(18, 15);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "To";
            // 
            // chkPartChargeTo
            // 
            this.chkPartChargeTo.CheckOnClick = true;
            this.chkPartChargeTo.FormattingEnabled = true;
            this.chkPartChargeTo.Location = new System.Drawing.Point(563, 25);
            this.chkPartChargeTo.Name = "chkPartChargeTo";
            this.chkPartChargeTo.Size = new System.Drawing.Size(83, 19);
            this.chkPartChargeTo.TabIndex = 170;
            this.chkPartChargeTo.Visible = false;
            this.chkPartChargeTo.Enter += new System.EventHandler(this.chkPartChargeTo_Enter);
            this.chkPartChargeTo.Leave += new System.EventHandler(this.chkPartChargeTo_Leave);
            // 
            // lblPartChargeTo
            // 
            this.lblPartChargeTo.BackColor = System.Drawing.Color.White;
            this.lblPartChargeTo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPartChargeTo.Location = new System.Drawing.Point(564, 5);
            this.lblPartChargeTo.Name = "lblPartChargeTo";
            this.lblPartChargeTo.Size = new System.Drawing.Size(81, 17);
            this.lblPartChargeTo.TabIndex = 8;
            this.lblPartChargeTo.Text = "Charge To";
            this.lblPartChargeTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPartChargeTo.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::MyRIS.Properties.Resources.Add_Icon;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(749, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlTransportMultiple
            // 
            this.pnlTransportMultiple.Controls.Add(this.chkDestChargeTo);
            this.pnlTransportMultiple.Controls.Add(this.lblDestChargeTo);
            this.pnlTransportMultiple.Controls.Add(this.lblDestination);
            this.pnlTransportMultiple.Controls.Add(this.MultiFrom);
            this.pnlTransportMultiple.Controls.Add(this.MultiMode);
            this.pnlTransportMultiple.Controls.Add(this.MultiAmount);
            this.pnlTransportMultiple.Controls.Add(this.MultiTo);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti1);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti1);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti14);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti12);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti13);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti11);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti10);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti8);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti5);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti4);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti5);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti6);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti3);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti2);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti9);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti7);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti9);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti7);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti3);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti3);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti9);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti7);
            this.pnlTransportMultiple.Controls.Add(this.btnAddMultiple);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti2);
            this.pnlTransportMultiple.Controls.Add(this.txtDestination);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti5);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti6);
            this.pnlTransportMultiple.Controls.Add(this.cboModeMulti1);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti4);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti14);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti12);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti13);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti11);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti10);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti14);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti13);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti12);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti11);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti10);
            this.pnlTransportMultiple.Controls.Add(this.txtAmountMulti8);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti8);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti2);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti4);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti6);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti6);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti14);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti4);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti13);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti12);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti11);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti10);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti2);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti9);
            this.pnlTransportMultiple.Controls.Add(this.txtFromMulti8);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti7);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti1);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti3);
            this.pnlTransportMultiple.Controls.Add(this.txtToMulti5);
            this.pnlTransportMultiple.Location = new System.Drawing.Point(325, 154);
            this.pnlTransportMultiple.Name = "pnlTransportMultiple";
            this.pnlTransportMultiple.Size = new System.Drawing.Size(500, 441);
            this.pnlTransportMultiple.TabIndex = 165;
            this.pnlTransportMultiple.Visible = false;
            // 
            // chkDestChargeTo
            // 
            this.chkDestChargeTo.CheckOnClick = true;
            this.chkDestChargeTo.FormattingEnabled = true;
            this.chkDestChargeTo.Location = new System.Drawing.Point(356, 5);
            this.chkDestChargeTo.Name = "chkDestChargeTo";
            this.chkDestChargeTo.Size = new System.Drawing.Size(83, 19);
            this.chkDestChargeTo.TabIndex = 170;
            this.chkDestChargeTo.Visible = false;
            this.chkDestChargeTo.Enter += new System.EventHandler(this.chkDestChargeTo_Enter);
            this.chkDestChargeTo.Leave += new System.EventHandler(this.chkDestChargeTo_Leave);
            // 
            // lblDestChargeTo
            // 
            this.lblDestChargeTo.AutoSize = true;
            this.lblDestChargeTo.BackColor = System.Drawing.Color.White;
            this.lblDestChargeTo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDestChargeTo.Location = new System.Drawing.Point(296, 6);
            this.lblDestChargeTo.Name = "lblDestChargeTo";
            this.lblDestChargeTo.Size = new System.Drawing.Size(57, 15);
            this.lblDestChargeTo.TabIndex = 50;
            this.lblDestChargeTo.Text = "Charge To:";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.Location = new System.Drawing.Point(13, 6);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(62, 15);
            this.lblDestination.TabIndex = 0;
            this.lblDestination.Text = "Destination:";
            // 
            // MultiFrom
            // 
            this.MultiFrom.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiFrom.Location = new System.Drawing.Point(10, 25);
            this.MultiFrom.Name = "MultiFrom";
            this.MultiFrom.Size = new System.Drawing.Size(136, 18);
            this.MultiFrom.TabIndex = 7;
            this.MultiFrom.Text = "From";
            this.MultiFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MultiMode
            // 
            this.MultiMode.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiMode.Location = new System.Drawing.Point(292, 26);
            this.MultiMode.Name = "MultiMode";
            this.MultiMode.Size = new System.Drawing.Size(96, 17);
            this.MultiMode.TabIndex = 11;
            this.MultiMode.Text = "Mode";
            this.MultiMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MultiAmount
            // 
            this.MultiAmount.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiAmount.Location = new System.Drawing.Point(390, 26);
            this.MultiAmount.Name = "MultiAmount";
            this.MultiAmount.Size = new System.Drawing.Size(104, 16);
            this.MultiAmount.TabIndex = 24;
            this.MultiAmount.Text = "Amount";
            this.MultiAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MultiTo
            // 
            this.MultiTo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiTo.Location = new System.Drawing.Point(149, 26);
            this.MultiTo.Name = "MultiTo";
            this.MultiTo.Size = new System.Drawing.Size(135, 18);
            this.MultiTo.TabIndex = 9;
            this.MultiTo.Text = "To";
            this.MultiTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAmountMulti1
            // 
            this.txtAmountMulti1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti1.Location = new System.Drawing.Point(390, 44);
            this.txtAmountMulti1.Name = "txtAmountMulti1";
            this.txtAmountMulti1.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti1.TabIndex = 12;
            this.txtAmountMulti1.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtFromMulti1
            // 
            this.txtFromMulti1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti1.Location = new System.Drawing.Point(10, 45);
            this.txtFromMulti1.Name = "txtFromMulti1";
            this.txtFromMulti1.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti1.TabIndex = 9;
            // 
            // cboModeMulti14
            // 
            this.cboModeMulti14.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti14.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti14.FormattingEnabled = true;
            this.cboModeMulti14.Location = new System.Drawing.Point(292, 384);
            this.cboModeMulti14.Name = "cboModeMulti14";
            this.cboModeMulti14.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti14.TabIndex = 47;
            // 
            // cboModeMulti12
            // 
            this.cboModeMulti12.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti12.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti12.FormattingEnabled = true;
            this.cboModeMulti12.Location = new System.Drawing.Point(292, 331);
            this.cboModeMulti12.Name = "cboModeMulti12";
            this.cboModeMulti12.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti12.TabIndex = 47;
            // 
            // cboModeMulti13
            // 
            this.cboModeMulti13.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti13.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti13.FormattingEnabled = true;
            this.cboModeMulti13.Location = new System.Drawing.Point(292, 358);
            this.cboModeMulti13.Name = "cboModeMulti13";
            this.cboModeMulti13.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti13.TabIndex = 47;
            // 
            // cboModeMulti11
            // 
            this.cboModeMulti11.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti11.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti11.FormattingEnabled = true;
            this.cboModeMulti11.Location = new System.Drawing.Point(292, 305);
            this.cboModeMulti11.Name = "cboModeMulti11";
            this.cboModeMulti11.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti11.TabIndex = 47;
            // 
            // cboModeMulti10
            // 
            this.cboModeMulti10.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti10.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti10.FormattingEnabled = true;
            this.cboModeMulti10.Location = new System.Drawing.Point(292, 279);
            this.cboModeMulti10.Name = "cboModeMulti10";
            this.cboModeMulti10.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti10.TabIndex = 47;
            // 
            // cboModeMulti8
            // 
            this.cboModeMulti8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti8.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti8.FormattingEnabled = true;
            this.cboModeMulti8.Location = new System.Drawing.Point(292, 227);
            this.cboModeMulti8.Name = "cboModeMulti8";
            this.cboModeMulti8.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti8.TabIndex = 39;
            // 
            // txtAmountMulti5
            // 
            this.txtAmountMulti5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti5.Location = new System.Drawing.Point(390, 149);
            this.txtAmountMulti5.Name = "txtAmountMulti5";
            this.txtAmountMulti5.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti5.TabIndex = 28;
            this.txtAmountMulti5.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // cboModeMulti4
            // 
            this.cboModeMulti4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti4.FormattingEnabled = true;
            this.cboModeMulti4.Location = new System.Drawing.Point(292, 122);
            this.cboModeMulti4.Name = "cboModeMulti4";
            this.cboModeMulti4.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti4.TabIndex = 23;
            // 
            // txtFromMulti5
            // 
            this.txtFromMulti5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti5.Location = new System.Drawing.Point(10, 149);
            this.txtFromMulti5.Name = "txtFromMulti5";
            this.txtFromMulti5.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti5.TabIndex = 25;
            // 
            // cboModeMulti6
            // 
            this.cboModeMulti6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti6.FormattingEnabled = true;
            this.cboModeMulti6.Location = new System.Drawing.Point(292, 175);
            this.cboModeMulti6.Name = "cboModeMulti6";
            this.cboModeMulti6.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti6.TabIndex = 31;
            // 
            // txtAmountMulti3
            // 
            this.txtAmountMulti3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti3.Location = new System.Drawing.Point(390, 96);
            this.txtAmountMulti3.Name = "txtAmountMulti3";
            this.txtAmountMulti3.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti3.TabIndex = 20;
            this.txtAmountMulti3.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // cboModeMulti2
            // 
            this.cboModeMulti2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti2.FormattingEnabled = true;
            this.cboModeMulti2.Location = new System.Drawing.Point(292, 70);
            this.cboModeMulti2.Name = "cboModeMulti2";
            this.cboModeMulti2.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti2.TabIndex = 15;
            // 
            // txtAmountMulti9
            // 
            this.txtAmountMulti9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti9.Location = new System.Drawing.Point(390, 253);
            this.txtAmountMulti9.Name = "txtAmountMulti9";
            this.txtAmountMulti9.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti9.TabIndex = 44;
            this.txtAmountMulti9.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtAmountMulti7
            // 
            this.txtAmountMulti7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti7.Location = new System.Drawing.Point(390, 201);
            this.txtAmountMulti7.Name = "txtAmountMulti7";
            this.txtAmountMulti7.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti7.TabIndex = 36;
            this.txtAmountMulti7.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // cboModeMulti9
            // 
            this.cboModeMulti9.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti9.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti9.FormattingEnabled = true;
            this.cboModeMulti9.Location = new System.Drawing.Point(292, 253);
            this.cboModeMulti9.Name = "cboModeMulti9";
            this.cboModeMulti9.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti9.TabIndex = 43;
            // 
            // cboModeMulti7
            // 
            this.cboModeMulti7.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti7.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti7.FormattingEnabled = true;
            this.cboModeMulti7.Location = new System.Drawing.Point(292, 201);
            this.cboModeMulti7.Name = "cboModeMulti7";
            this.cboModeMulti7.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti7.TabIndex = 35;
            // 
            // txtFromMulti3
            // 
            this.txtFromMulti3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti3.Location = new System.Drawing.Point(10, 96);
            this.txtFromMulti3.Name = "txtFromMulti3";
            this.txtFromMulti3.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti3.TabIndex = 17;
            // 
            // cboModeMulti3
            // 
            this.cboModeMulti3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti3.FormattingEnabled = true;
            this.cboModeMulti3.Location = new System.Drawing.Point(292, 96);
            this.cboModeMulti3.Name = "cboModeMulti3";
            this.cboModeMulti3.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti3.TabIndex = 19;
            // 
            // txtFromMulti9
            // 
            this.txtFromMulti9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti9.Location = new System.Drawing.Point(10, 253);
            this.txtFromMulti9.Name = "txtFromMulti9";
            this.txtFromMulti9.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti9.TabIndex = 41;
            // 
            // txtFromMulti7
            // 
            this.txtFromMulti7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti7.Location = new System.Drawing.Point(10, 201);
            this.txtFromMulti7.Name = "txtFromMulti7";
            this.txtFromMulti7.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti7.TabIndex = 33;
            // 
            // txtAmountMulti2
            // 
            this.txtAmountMulti2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti2.Location = new System.Drawing.Point(390, 70);
            this.txtAmountMulti2.Name = "txtAmountMulti2";
            this.txtAmountMulti2.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti2.TabIndex = 16;
            this.txtAmountMulti2.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtDestination
            // 
            this.txtDestination.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestination.Location = new System.Drawing.Point(79, 4);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(177, 20);
            this.txtDestination.TabIndex = 0;
            this.txtDestination.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // cboModeMulti5
            // 
            this.cboModeMulti5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti5.FormattingEnabled = true;
            this.cboModeMulti5.Location = new System.Drawing.Point(292, 149);
            this.cboModeMulti5.Name = "cboModeMulti5";
            this.cboModeMulti5.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti5.TabIndex = 27;
            // 
            // txtAmountMulti6
            // 
            this.txtAmountMulti6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti6.Location = new System.Drawing.Point(390, 175);
            this.txtAmountMulti6.Name = "txtAmountMulti6";
            this.txtAmountMulti6.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti6.TabIndex = 32;
            this.txtAmountMulti6.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // cboModeMulti1
            // 
            this.cboModeMulti1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeMulti1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeMulti1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeMulti1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeMulti1.FormattingEnabled = true;
            this.cboModeMulti1.Location = new System.Drawing.Point(292, 44);
            this.cboModeMulti1.Name = "cboModeMulti1";
            this.cboModeMulti1.Size = new System.Drawing.Size(97, 22);
            this.cboModeMulti1.TabIndex = 11;
            // 
            // txtAmountMulti4
            // 
            this.txtAmountMulti4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti4.Location = new System.Drawing.Point(390, 122);
            this.txtAmountMulti4.Name = "txtAmountMulti4";
            this.txtAmountMulti4.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti4.TabIndex = 24;
            this.txtAmountMulti4.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtAmountMulti14
            // 
            this.txtAmountMulti14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti14.Location = new System.Drawing.Point(390, 384);
            this.txtAmountMulti14.Name = "txtAmountMulti14";
            this.txtAmountMulti14.Size = new System.Drawing.Size(106, 20);
            this.txtAmountMulti14.TabIndex = 48;
            this.txtAmountMulti14.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti14.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti14.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtAmountMulti12
            // 
            this.txtAmountMulti12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti12.Location = new System.Drawing.Point(390, 331);
            this.txtAmountMulti12.Name = "txtAmountMulti12";
            this.txtAmountMulti12.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti12.TabIndex = 48;
            this.txtAmountMulti12.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtAmountMulti13
            // 
            this.txtAmountMulti13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti13.Location = new System.Drawing.Point(390, 358);
            this.txtAmountMulti13.Name = "txtAmountMulti13";
            this.txtAmountMulti13.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti13.TabIndex = 48;
            this.txtAmountMulti13.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti13.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtAmountMulti11
            // 
            this.txtAmountMulti11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti11.Location = new System.Drawing.Point(390, 305);
            this.txtAmountMulti11.Name = "txtAmountMulti11";
            this.txtAmountMulti11.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti11.TabIndex = 48;
            this.txtAmountMulti11.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtAmountMulti10
            // 
            this.txtAmountMulti10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti10.Location = new System.Drawing.Point(390, 279);
            this.txtAmountMulti10.Name = "txtAmountMulti10";
            this.txtAmountMulti10.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti10.TabIndex = 48;
            this.txtAmountMulti10.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtToMulti14
            // 
            this.txtToMulti14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti14.Location = new System.Drawing.Point(151, 384);
            this.txtToMulti14.Name = "txtToMulti14";
            this.txtToMulti14.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti14.TabIndex = 46;
            // 
            // txtToMulti13
            // 
            this.txtToMulti13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti13.Location = new System.Drawing.Point(151, 358);
            this.txtToMulti13.Name = "txtToMulti13";
            this.txtToMulti13.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti13.TabIndex = 46;
            this.txtToMulti13.TextChanged += new System.EventHandler(this.txtToMulti13_TextChanged);
            // 
            // txtToMulti12
            // 
            this.txtToMulti12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti12.Location = new System.Drawing.Point(151, 331);
            this.txtToMulti12.Name = "txtToMulti12";
            this.txtToMulti12.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti12.TabIndex = 46;
            this.txtToMulti12.TextChanged += new System.EventHandler(this.txtToMulti12_TextChanged);
            // 
            // txtToMulti11
            // 
            this.txtToMulti11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti11.Location = new System.Drawing.Point(151, 305);
            this.txtToMulti11.Name = "txtToMulti11";
            this.txtToMulti11.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti11.TabIndex = 46;
            this.txtToMulti11.TextChanged += new System.EventHandler(this.txtToMulti11_TextChanged);
            // 
            // txtToMulti10
            // 
            this.txtToMulti10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti10.Location = new System.Drawing.Point(151, 279);
            this.txtToMulti10.Name = "txtToMulti10";
            this.txtToMulti10.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti10.TabIndex = 46;
            this.txtToMulti10.TextChanged += new System.EventHandler(this.txtToMulti10_TextChanged);
            // 
            // txtAmountMulti8
            // 
            this.txtAmountMulti8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountMulti8.Location = new System.Drawing.Point(390, 227);
            this.txtAmountMulti8.Name = "txtAmountMulti8";
            this.txtAmountMulti8.Size = new System.Drawing.Size(105, 20);
            this.txtAmountMulti8.TabIndex = 40;
            this.txtAmountMulti8.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmountMulti8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmountMulti8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKeyPress_DoubleOnly);
            // 
            // txtToMulti8
            // 
            this.txtToMulti8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti8.Location = new System.Drawing.Point(151, 227);
            this.txtToMulti8.Name = "txtToMulti8";
            this.txtToMulti8.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti8.TabIndex = 38;
            this.txtToMulti8.TextChanged += new System.EventHandler(this.txtToMulti8_TextChanged);
            // 
            // txtFromMulti2
            // 
            this.txtFromMulti2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti2.Location = new System.Drawing.Point(10, 70);
            this.txtFromMulti2.Name = "txtFromMulti2";
            this.txtFromMulti2.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti2.TabIndex = 13;
            // 
            // txtToMulti4
            // 
            this.txtToMulti4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti4.Location = new System.Drawing.Point(151, 122);
            this.txtToMulti4.Name = "txtToMulti4";
            this.txtToMulti4.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti4.TabIndex = 22;
            this.txtToMulti4.TextChanged += new System.EventHandler(this.txtToMulti4_TextChanged);
            // 
            // txtFromMulti6
            // 
            this.txtFromMulti6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti6.Location = new System.Drawing.Point(10, 175);
            this.txtFromMulti6.Name = "txtFromMulti6";
            this.txtFromMulti6.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti6.TabIndex = 29;
            // 
            // txtToMulti6
            // 
            this.txtToMulti6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti6.Location = new System.Drawing.Point(151, 175);
            this.txtToMulti6.Name = "txtToMulti6";
            this.txtToMulti6.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti6.TabIndex = 30;
            this.txtToMulti6.TextChanged += new System.EventHandler(this.txtToMulti6_TextChanged);
            // 
            // txtFromMulti14
            // 
            this.txtFromMulti14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti14.Location = new System.Drawing.Point(10, 384);
            this.txtFromMulti14.Name = "txtFromMulti14";
            this.txtFromMulti14.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti14.TabIndex = 45;
            // 
            // txtFromMulti4
            // 
            this.txtFromMulti4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti4.Location = new System.Drawing.Point(10, 122);
            this.txtFromMulti4.Name = "txtFromMulti4";
            this.txtFromMulti4.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti4.TabIndex = 21;
            // 
            // txtFromMulti13
            // 
            this.txtFromMulti13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti13.Location = new System.Drawing.Point(10, 358);
            this.txtFromMulti13.Name = "txtFromMulti13";
            this.txtFromMulti13.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti13.TabIndex = 45;
            // 
            // txtFromMulti12
            // 
            this.txtFromMulti12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti12.Location = new System.Drawing.Point(10, 331);
            this.txtFromMulti12.Name = "txtFromMulti12";
            this.txtFromMulti12.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti12.TabIndex = 45;
            // 
            // txtFromMulti11
            // 
            this.txtFromMulti11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti11.Location = new System.Drawing.Point(10, 305);
            this.txtFromMulti11.Name = "txtFromMulti11";
            this.txtFromMulti11.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti11.TabIndex = 45;
            // 
            // txtFromMulti10
            // 
            this.txtFromMulti10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti10.Location = new System.Drawing.Point(10, 279);
            this.txtFromMulti10.Name = "txtFromMulti10";
            this.txtFromMulti10.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti10.TabIndex = 45;
            // 
            // txtToMulti2
            // 
            this.txtToMulti2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti2.Location = new System.Drawing.Point(151, 70);
            this.txtToMulti2.Name = "txtToMulti2";
            this.txtToMulti2.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti2.TabIndex = 14;
            this.txtToMulti2.TextChanged += new System.EventHandler(this.txtToMulti2_TextChanged);
            // 
            // txtToMulti9
            // 
            this.txtToMulti9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti9.Location = new System.Drawing.Point(151, 253);
            this.txtToMulti9.Name = "txtToMulti9";
            this.txtToMulti9.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti9.TabIndex = 42;
            this.txtToMulti9.TextChanged += new System.EventHandler(this.txtToMulti9_TextChanged);
            // 
            // txtFromMulti8
            // 
            this.txtFromMulti8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromMulti8.Location = new System.Drawing.Point(10, 227);
            this.txtFromMulti8.Name = "txtFromMulti8";
            this.txtFromMulti8.Size = new System.Drawing.Size(135, 20);
            this.txtFromMulti8.TabIndex = 37;
            // 
            // txtToMulti7
            // 
            this.txtToMulti7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti7.Location = new System.Drawing.Point(151, 201);
            this.txtToMulti7.Name = "txtToMulti7";
            this.txtToMulti7.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti7.TabIndex = 34;
            this.txtToMulti7.TextChanged += new System.EventHandler(this.txtToMulti7_TextChanged);
            // 
            // txtToMulti1
            // 
            this.txtToMulti1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti1.Location = new System.Drawing.Point(151, 44);
            this.txtToMulti1.Name = "txtToMulti1";
            this.txtToMulti1.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti1.TabIndex = 10;
            this.txtToMulti1.TextChanged += new System.EventHandler(this.txtToMulti1_TextChanged);
            // 
            // txtToMulti3
            // 
            this.txtToMulti3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti3.Location = new System.Drawing.Point(151, 96);
            this.txtToMulti3.Name = "txtToMulti3";
            this.txtToMulti3.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti3.TabIndex = 18;
            this.txtToMulti3.TextChanged += new System.EventHandler(this.txtToMulti3_TextChanged);
            // 
            // txtToMulti5
            // 
            this.txtToMulti5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMulti5.Location = new System.Drawing.Point(151, 149);
            this.txtToMulti5.Name = "txtToMulti5";
            this.txtToMulti5.Size = new System.Drawing.Size(135, 20);
            this.txtToMulti5.TabIndex = 26;
            this.txtToMulti5.TextChanged += new System.EventHandler(this.txtToMulti5_TextChanged);
            // 
            // dtpAudited
            // 
            this.dtpAudited.CalendarFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAudited.CustomFormat = "MM/dd/yyyy";
            this.dtpAudited.Enabled = false;
            this.dtpAudited.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAudited.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAudited.Location = new System.Drawing.Point(435, 571);
            this.dtpAudited.Name = "dtpAudited";
            this.dtpAudited.Size = new System.Drawing.Size(77, 20);
            this.dtpAudited.TabIndex = 101;
            // 
            // pnlEditDestination
            // 
            this.pnlEditDestination.Controls.Add(this.txtEditDestination);
            this.pnlEditDestination.Controls.Add(this.lblEditDestination);
            this.pnlEditDestination.Controls.Add(this.btnEditDestination);
            this.pnlEditDestination.Location = new System.Drawing.Point(325, 155);
            this.pnlEditDestination.Name = "pnlEditDestination";
            this.pnlEditDestination.Size = new System.Drawing.Size(499, 53);
            this.pnlEditDestination.TabIndex = 166;
            this.pnlEditDestination.Visible = false;
            // 
            // txtEditDestination
            // 
            this.txtEditDestination.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditDestination.Location = new System.Drawing.Point(8, 24);
            this.txtEditDestination.MaxLength = 238;
            this.txtEditDestination.Name = "txtEditDestination";
            this.txtEditDestination.Size = new System.Drawing.Size(247, 20);
            this.txtEditDestination.TabIndex = 0;
            this.txtEditDestination.TabStop = false;
            this.txtEditDestination.Tag = "-1";
            this.txtEditDestination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEditDestination_KeyDown);
            // 
            // lblEditDestination
            // 
            this.lblEditDestination.AutoSize = true;
            this.lblEditDestination.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEditDestination.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEditDestination.Location = new System.Drawing.Point(103, 4);
            this.lblEditDestination.Name = "lblEditDestination";
            this.lblEditDestination.Size = new System.Drawing.Size(69, 16);
            this.lblEditDestination.TabIndex = 0;
            this.lblEditDestination.Text = "Destination";
            // 
            // txtPastRemark
            // 
            this.txtPastRemark.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPastRemark.Location = new System.Drawing.Point(792, 357);
            this.txtPastRemark.MaxLength = 300;
            this.txtPastRemark.Multiline = true;
            this.txtPastRemark.Name = "txtPastRemark";
            this.txtPastRemark.ReadOnly = true;
            this.txtPastRemark.Size = new System.Drawing.Size(251, 84);
            this.txtPastRemark.TabIndex = 117;
            this.txtPastRemark.Tag = "";
            // 
            // btnSearchHeadApprover
            // 
            this.btnSearchHeadApprover.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchHeadApprover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchHeadApprover.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchHeadApprover.Location = new System.Drawing.Point(111, 496);
            this.btnSearchHeadApprover.Name = "btnSearchHeadApprover";
            this.btnSearchHeadApprover.Size = new System.Drawing.Size(24, 21);
            this.btnSearchHeadApprover.TabIndex = 168;
            this.btnSearchHeadApprover.TabStop = false;
            this.btnSearchHeadApprover.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchHeadApprover.UseVisualStyleBackColor = true;
            this.btnSearchHeadApprover.Visible = false;
            this.btnSearchHeadApprover.Click += new System.EventHandler(this.btnSearchApprover_Click);
            // 
            // btnSearchDocsReceived
            // 
            this.btnSearchDocsReceived.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchDocsReceived.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchDocsReceived.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDocsReceived.Location = new System.Drawing.Point(377, 495);
            this.btnSearchDocsReceived.Name = "btnSearchDocsReceived";
            this.btnSearchDocsReceived.Size = new System.Drawing.Size(24, 21);
            this.btnSearchDocsReceived.TabIndex = 168;
            this.btnSearchDocsReceived.TabStop = false;
            this.btnSearchDocsReceived.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchDocsReceived.UseVisualStyleBackColor = true;
            this.btnSearchDocsReceived.Visible = false;
            this.btnSearchDocsReceived.Click += new System.EventHandler(this.btnSearchDocsReceived_Click);
            // 
            // txtMgtApprovedBy
            // 
            this.txtMgtApprovedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMgtApprovedBy.Location = new System.Drawing.Point(143, 517);
            this.txtMgtApprovedBy.Multiline = true;
            this.txtMgtApprovedBy.Name = "txtMgtApprovedBy";
            this.txtMgtApprovedBy.ReadOnly = true;
            this.txtMgtApprovedBy.Size = new System.Drawing.Size(125, 50);
            this.txtMgtApprovedBy.TabIndex = 114;
            this.txtMgtApprovedBy.Tag = "-1";
            this.txtMgtApprovedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpMgtApproved
            // 
            this.dtpMgtApproved.CalendarFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMgtApproved.CustomFormat = "MM/dd/yyyy";
            this.dtpMgtApproved.Enabled = false;
            this.dtpMgtApproved.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMgtApproved.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMgtApproved.Location = new System.Drawing.Point(168, 573);
            this.dtpMgtApproved.Name = "dtpMgtApproved";
            this.dtpMgtApproved.Size = new System.Drawing.Size(77, 20);
            this.dtpMgtApproved.TabIndex = 100;
            // 
            // lblMgtApprovedBy
            // 
            this.lblMgtApprovedBy.AutoSize = true;
            this.lblMgtApprovedBy.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMgtApprovedBy.Location = new System.Drawing.Point(144, 499);
            this.lblMgtApprovedBy.Name = "lblMgtApprovedBy";
            this.lblMgtApprovedBy.Size = new System.Drawing.Size(89, 15);
            this.lblMgtApprovedBy.TabIndex = 109;
            this.lblMgtApprovedBy.Text = "Mgt Approved by:";
            // 
            // btnSearchMgtApprover
            // 
            this.btnSearchMgtApprover.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchMgtApprover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchMgtApprover.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchMgtApprover.Location = new System.Drawing.Point(244, 496);
            this.btnSearchMgtApprover.Name = "btnSearchMgtApprover";
            this.btnSearchMgtApprover.Size = new System.Drawing.Size(24, 21);
            this.btnSearchMgtApprover.TabIndex = 168;
            this.btnSearchMgtApprover.TabStop = false;
            this.btnSearchMgtApprover.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchMgtApprover.UseVisualStyleBackColor = true;
            this.btnSearchMgtApprover.Visible = false;
            this.btnSearchMgtApprover.Click += new System.EventHandler(this.btnSearchMgtApprover_Click);
            // 
            // chkBoxChargeTo
            // 
            this.chkBoxChargeTo.CheckOnClick = true;
            this.chkBoxChargeTo.FormattingEnabled = true;
            this.chkBoxChargeTo.Location = new System.Drawing.Point(540, 66);
            this.chkBoxChargeTo.Name = "chkBoxChargeTo";
            this.chkBoxChargeTo.Size = new System.Drawing.Size(83, 19);
            this.chkBoxChargeTo.TabIndex = 170;
            this.chkBoxChargeTo.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSLabel,
            this.toolStripShortcut,
            this.toolStrip});
            this.statusStrip.Location = new System.Drawing.Point(0, 593);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1055, 22);
            this.statusStrip.TabIndex = 171;
            this.statusStrip.Text = "statusStrip1";
            // 
            // TSSLabel
            // 
            this.TSSLabel.Name = "TSSLabel";
            this.TSSLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripShortcut
            // 
            this.toolStripShortcut.Name = "toolStripShortcut";
            this.toolStripShortcut.Size = new System.Drawing.Size(82, 17);
            this.toolStripShortcut.Text = "Shortcut Keys:";
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(0, 17);
            // 
            // txtTotalExpenses
            // 
            this.txtTotalExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalExpenses.Location = new System.Drawing.Point(953, 183);
            this.txtTotalExpenses.Name = "txtTotalExpenses";
            this.txtTotalExpenses.ReadOnly = true;
            this.txtTotalExpenses.Size = new System.Drawing.Size(95, 20);
            this.txtTotalExpenses.TabIndex = 172;
            this.txtTotalExpenses.TabStop = false;
            this.txtTotalExpenses.Text = "0";
            // 
            // lblOF
            // 
            this.lblOF.AutoSize = true;
            this.lblOF.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOF.Location = new System.Drawing.Point(922, 187);
            this.lblOF.Name = "lblOF";
            this.lblOF.Size = new System.Drawing.Size(24, 13);
            this.lblOF.TabIndex = 173;
            this.lblOF.Text = "OF";
            // 
            // btnSearchReleasedBy
            // 
            this.btnSearchReleasedBy.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchReleasedBy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchReleasedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchReleasedBy.Location = new System.Drawing.Point(779, 496);
            this.btnSearchReleasedBy.Name = "btnSearchReleasedBy";
            this.btnSearchReleasedBy.Size = new System.Drawing.Size(24, 21);
            this.btnSearchReleasedBy.TabIndex = 168;
            this.btnSearchReleasedBy.TabStop = false;
            this.btnSearchReleasedBy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchReleasedBy.UseVisualStyleBackColor = true;
            this.btnSearchReleasedBy.Visible = false;
            this.btnSearchReleasedBy.Click += new System.EventHandler(this.btnSearchReleasedBy_Click);
            // 
            // btnSearchAuditedBy
            // 
            this.btnSearchAuditedBy.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchAuditedBy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchAuditedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchAuditedBy.Location = new System.Drawing.Point(511, 495);
            this.btnSearchAuditedBy.Name = "btnSearchAuditedBy";
            this.btnSearchAuditedBy.Size = new System.Drawing.Size(24, 21);
            this.btnSearchAuditedBy.TabIndex = 168;
            this.btnSearchAuditedBy.TabStop = false;
            this.btnSearchAuditedBy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchAuditedBy.UseVisualStyleBackColor = true;
            this.btnSearchAuditedBy.Visible = false;
            this.btnSearchAuditedBy.Click += new System.EventHandler(this.btnSearchAuditedBy_Click);
            // 
            // btnSearchUploadedBy
            // 
            this.btnSearchUploadedBy.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchUploadedBy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchUploadedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUploadedBy.Location = new System.Drawing.Point(645, 495);
            this.btnSearchUploadedBy.Name = "btnSearchUploadedBy";
            this.btnSearchUploadedBy.Size = new System.Drawing.Size(24, 21);
            this.btnSearchUploadedBy.TabIndex = 168;
            this.btnSearchUploadedBy.TabStop = false;
            this.btnSearchUploadedBy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchUploadedBy.UseVisualStyleBackColor = true;
            this.btnSearchUploadedBy.Visible = false;
            this.btnSearchUploadedBy.Click += new System.EventHandler(this.btnSearchUploadedBy_Click);
            // 
            // lblVoucher
            // 
            this.lblVoucher.BackColor = System.Drawing.Color.Firebrick;
            this.lblVoucher.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVoucher.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucher.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblVoucher.Location = new System.Drawing.Point(0, 0);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(278, 28);
            this.lblVoucher.TabIndex = 1;
            this.lblVoucher.Text = "EXPENSE PAYMENT VOUCHER";
            this.lblVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Firebrick;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStatus.Location = new System.Drawing.Point(660, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(395, 28);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Tag = "0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Firebrick;
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Controls.Add(this.lblVoucher);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1055, 28);
            this.pnlHeader.TabIndex = 37;
            this.pnlHeader.Tag = "";
            // 
            // btnSubmitEmail
            // 
            this.btnSubmitEmail.BackgroundImage = global::MyRIS.Properties.Resources.Go_Back_Icon;
            this.btnSubmitEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSubmitEmail.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitEmail.Location = new System.Drawing.Point(948, 291);
            this.btnSubmitEmail.Name = "btnSubmitEmail";
            this.btnSubmitEmail.Size = new System.Drawing.Size(46, 43);
            this.btnSubmitEmail.TabIndex = 167;
            this.btnSubmitEmail.TabStop = false;
            this.btnSubmitEmail.Tag = "";
            this.btnSubmitEmail.UseVisualStyleBackColor = true;
            this.btnSubmitEmail.Visible = false;
            this.btnSubmitEmail.Click += new System.EventHandler(this.btnSubmitEmail_Click);
            // 
            // frmEPVDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1055, 615);
            this.Controls.Add(this.pnlTransportMultiple);
            this.Controls.Add(this.lblOF);
            this.Controls.Add(this.txtTotalExpenses);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.chkBoxChargeTo);
            this.Controls.Add(this.btnSearchMgtApprover);
            this.Controls.Add(this.btnSearchHeadApprover);
            this.Controls.Add(this.btnSubmitEmail);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.pnlEditDestination);
            this.Controls.Add(this.dtpBatchDate);
            this.Controls.Add(this.lblReleasing);
            this.Controls.Add(this.dtpReleasingDate);
            this.Controls.Add(this.lblReleasedBy);
            this.Controls.Add(this.dtpUploadedBy);
            this.Controls.Add(this.lblDoubleClick);
            this.Controls.Add(this.txtReleasedBy);
            this.Controls.Add(this.lblAudited);
            this.Controls.Add(this.dtpReleased);
            this.Controls.Add(this.txtAuditedBy);
            this.Controls.Add(this.lbUploadedBy);
            this.Controls.Add(this.lblMgtApprovedBy);
            this.Controls.Add(this.lblHeadApproved);
            this.Controls.Add(this.lblDocsReceived);
            this.Controls.Add(this.dtpMgtApproved);
            this.Controls.Add(this.dtpHeadApproved);
            this.Controls.Add(this.dtpDocsReceived);
            this.Controls.Add(this.pnlDetailInfo);
            this.Controls.Add(this.txtDocsReceivedBy);
            this.Controls.Add(this.txtUploadedBy);
            this.Controls.Add(this.pnlMainInfo);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblRequired);
            this.Controls.Add(this.txtMgtApprovedBy);
            this.Controls.Add(this.txtHeadApprovedBy);
            this.Controls.Add(this.pnlRequired);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.txtCashOver);
            this.Controls.Add(this.txtPastRemark);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtCashAdvance);
            this.Controls.Add(this.txtTotalExpense);
            this.Controls.Add(this.lblCashOver);
            this.Controls.Add(this.lblCashAdvance);
            this.Controls.Add(this.lblTotalExpense);
            this.Controls.Add(this.lblBatchDate);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpAudited);
            this.Controls.Add(this.btnSearchReleasedBy);
            this.Controls.Add(this.btnSearchAuditedBy);
            this.Controls.Add(this.btnSearchUploadedBy);
            this.Controls.Add(this.btnSearchDocsReceived);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEPVDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXPENSE PAYMENT VOUCHER";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEPVDetail_FormClosing);
            this.Load += new System.EventHandler(this.frmEPVDetail_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmEPVDetail_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.pnlMainInfo.ResumeLayout(false);
            this.pnlMainInfo.PerformLayout();
            this.pnlVAT.ResumeLayout(false);
            this.pnlVAT.PerformLayout();
            this.pnlDetailInfo.ResumeLayout(false);
            this.pnlDetailInfo.PerformLayout();
            this.pnlTransport.ResumeLayout(false);
            this.pnlTransport.PerformLayout();
            this.pnlTransportMultiple.ResumeLayout(false);
            this.pnlTransportMultiple.PerformLayout();
            this.pnlEditDestination.ResumeLayout(false);
            this.pnlEditDestination.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBusiness;
        private System.Windows.Forms.TextBox txtRequestBy;
        private System.Windows.Forms.TextBox txtBusinessOthers;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.DateTimePicker dtpRequested;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label lblTransDate;
        private System.Windows.Forms.Label lblParticulars;
        private System.Windows.Forms.TextBox txtParticulars;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTotalExpense;
        private System.Windows.Forms.Label lblCashAdvance;
        private System.Windows.Forms.Label lblCashOver;
        private System.Windows.Forms.TextBox txtTotalExpense;
        private System.Windows.Forms.TextBox txtCashAdvance;
        private System.Windows.Forms.TextBox txtCashOver;
        private System.Windows.Forms.TextBox txtFormNumber;
        private System.Windows.Forms.Label lblCA;
        private System.Windows.Forms.TextBox txtCA;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblNatureOfExpense;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblModeOfPayment;
        private System.Windows.Forms.ComboBox cboModeOfPayment;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Panel pnlRequired;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.Label lblTransaction;
        private System.Windows.Forms.DateTimePicker dtpHeadApproved;
        private System.Windows.Forms.DateTimePicker dtpUploadedBy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtUploadedBy;
        private System.Windows.Forms.TextBox txtAuditedBy;
        private System.Windows.Forms.TextBox txtHeadApprovedBy;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lbUploadedBy;
        private System.Windows.Forms.Label lblAudited;
        private System.Windows.Forms.Label lblHeadApproved;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblDoubleClick;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpDocsReceived;
        private System.Windows.Forms.DateTimePicker dtpReleased;
        private System.Windows.Forms.DateTimePicker dtpReleasingDate;
        private System.Windows.Forms.Label lblReleasedBy;
        private System.Windows.Forms.TextBox txtReleasedBy;
        private System.Windows.Forms.Label lblDocsReceived;
        private System.Windows.Forms.TextBox txtDocsReceivedBy;
        private System.Windows.Forms.Label lblBatchDate;
        private System.Windows.Forms.DateTimePicker dtpBatchDate;
        private System.Windows.Forms.Label lblOthers;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel pnlVAT;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtTIN;
        private System.Windows.Forms.TextBox txtVatAmount;
        private System.Windows.Forms.Label lblVatAmount;
        private System.Windows.Forms.Label lblRefNumber;
        private System.Windows.Forms.Label lblTIN;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboClaimTo;
        private System.Windows.Forms.Button btnSearchSupplier;
        private System.Windows.Forms.Panel pnlMainInfo;
        private System.Windows.Forms.Panel pnlDetailInfo;
        private System.Windows.Forms.Label lblClaimableBy;
        private System.Windows.Forms.TextBox txtCAStatus;
        private System.Windows.Forms.Label lblReleasing;
        private System.Windows.Forms.DateTimePicker dtpAudited;
        private System.Windows.Forms.Label MultiMode;
        private System.Windows.Forms.Label MultiTo;
        private System.Windows.Forms.Label MultiFrom;
        private System.Windows.Forms.ComboBox cboModeMulti8;
        private System.Windows.Forms.ComboBox cboModeMulti4;
        private System.Windows.Forms.ComboBox cboModeMulti6;
        private System.Windows.Forms.ComboBox cboModeMulti2;
        private System.Windows.Forms.ComboBox cboModeMulti7;
        private System.Windows.Forms.ComboBox cboModeMulti3;
        private System.Windows.Forms.ComboBox cboModeMulti5;
        private System.Windows.Forms.ComboBox cboModeMulti1;
        private System.Windows.Forms.TextBox txtToMulti8;
        private System.Windows.Forms.TextBox txtToMulti4;
        private System.Windows.Forms.TextBox txtToMulti6;
        private System.Windows.Forms.TextBox txtToMulti2;
        private System.Windows.Forms.TextBox txtToMulti7;
        private System.Windows.Forms.TextBox txtToMulti3;
        private System.Windows.Forms.TextBox txtToMulti5;
        private System.Windows.Forms.TextBox txtToMulti1;
        private System.Windows.Forms.TextBox txtFromMulti8;
        private System.Windows.Forms.TextBox txtFromMulti4;
        private System.Windows.Forms.TextBox txtFromMulti6;
        private System.Windows.Forms.TextBox txtFromMulti2;
        private System.Windows.Forms.TextBox txtAmountMulti8;
        private System.Windows.Forms.TextBox txtAmountMulti4;
        private System.Windows.Forms.TextBox txtAmountMulti6;
        private System.Windows.Forms.TextBox txtAmountMulti2;
        private System.Windows.Forms.TextBox txtFromMulti7;
        private System.Windows.Forms.TextBox txtFromMulti3;
        private System.Windows.Forms.TextBox txtAmountMulti7;
        private System.Windows.Forms.TextBox txtAmountMulti3;
        private System.Windows.Forms.TextBox txtFromMulti5;
        private System.Windows.Forms.TextBox txtAmountMulti5;
        private System.Windows.Forms.TextBox txtFromMulti1;
        private System.Windows.Forms.TextBox txtAmountMulti1;
        private System.Windows.Forms.Label MultiAmount;
        private System.Windows.Forms.Label lblChargeTo;
        private System.Windows.Forms.ComboBox cboChargeTo;
        private System.Windows.Forms.ComboBox cboStores;
        private System.Windows.Forms.Button btnAddMultiple;
        private System.Windows.Forms.DateTimePicker dtpTransaction;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label lblCAStatus;
        private System.Windows.Forms.Panel pnlTransportMultiple;
        private System.Windows.Forms.ComboBox cboModeMulti10;
        private System.Windows.Forms.TextBox txtAmountMulti9;
        private System.Windows.Forms.ComboBox cboModeMulti9;
        private System.Windows.Forms.TextBox txtFromMulti9;
        private System.Windows.Forms.TextBox txtAmountMulti10;
        private System.Windows.Forms.TextBox txtToMulti10;
        private System.Windows.Forms.TextBox txtFromMulti10;
        private System.Windows.Forms.TextBox txtToMulti9;
        private System.Windows.Forms.Panel pnlTransport;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cboModeOfTransportation;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox cboNatureOfExpense;
        private System.Windows.Forms.ComboBox cboBusinessPurpose;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel pnlEditDestination;
        private System.Windows.Forms.Label lblEditDestination;
        private System.Windows.Forms.Button btnEditDestination;
        private System.Windows.Forms.TextBox txtStore;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPastRemark;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.ComboBox cboModeMulti14;
        private System.Windows.Forms.ComboBox cboModeMulti12;
        private System.Windows.Forms.ComboBox cboModeMulti13;
        private System.Windows.Forms.ComboBox cboModeMulti11;
        private System.Windows.Forms.TextBox txtAmountMulti14;
        private System.Windows.Forms.TextBox txtAmountMulti12;
        private System.Windows.Forms.TextBox txtAmountMulti13;
        private System.Windows.Forms.TextBox txtAmountMulti11;
        private System.Windows.Forms.TextBox txtToMulti14;
        private System.Windows.Forms.TextBox txtToMulti13;
        private System.Windows.Forms.TextBox txtToMulti12;
        private System.Windows.Forms.TextBox txtToMulti11;
        private System.Windows.Forms.TextBox txtFromMulti14;
        private System.Windows.Forms.TextBox txtFromMulti13;
        private System.Windows.Forms.TextBox txtFromMulti12;
        private System.Windows.Forms.TextBox txtFromMulti11;
        public System.Windows.Forms.Button btnSearchHeadApprover;
        public System.Windows.Forms.Button btnSearchDocsReceived;
        private System.Windows.Forms.TextBox txtMgtApprovedBy;
        private System.Windows.Forms.DateTimePicker dtpMgtApproved;
        private System.Windows.Forms.Label lblMgtApprovedBy;
        public System.Windows.Forms.Button btnSearchMgtApprover;
        private System.Windows.Forms.Button btnSaveMultiple;
        private System.Windows.Forms.CheckedListBox chkBoxChargeTo;
        private System.Windows.Forms.TextBox txtEditDestination;
        private System.Windows.Forms.Label lblPartChargeTo;
        private System.Windows.Forms.Label lblDestChargeTo;
        private System.Windows.Forms.CheckedListBox chkDestChargeTo;
        private System.Windows.Forms.CheckedListBox chkPartChargeTo;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel TSSLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripShortcut;
        private System.Windows.Forms.DataGridViewTextBoxColumn NatureOfExpenseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn NatureOfExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargeToName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tin;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn claimToId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeToId;
        private System.Windows.Forms.TextBox txtTotalExpenses;
        private System.Windows.Forms.Label lblOF;
        public System.Windows.Forms.Button btnSearchReleasedBy;
        public System.Windows.Forms.Button btnSearchAuditedBy;
        public System.Windows.Forms.Button btnSearchUploadedBy;
        private System.Windows.Forms.Label lblVoucher;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnSubmitEmail;
    }
}

