namespace MyRIS
{
    partial class frmCashAdvanceDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashAdvanceDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.cboStores = new System.Windows.Forms.ComboBox();
            this.lblChargeTo = new System.Windows.Forms.Label();
            this.cboBusinessPurpose = new System.Windows.Forms.ComboBox();
            this.lblBusiness = new System.Windows.Forms.Label();
            this.lblOthers = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblDateRequested = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnSaveMultiple = new System.Windows.Forms.Button();
            this.lblCAForm = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblCANumber = new System.Windows.Forms.Label();
            this.txtCANumber = new System.Windows.Forms.TextBox();
            this.pnlRequired = new System.Windows.Forms.Panel();
            this.lblRequired = new System.Windows.Forms.Label();
            this.lblDateNeeded = new System.Windows.Forms.Label();
            this.dtpDateNeeded = new System.Windows.Forms.DateTimePicker();
            this.lblModeOfPayment = new System.Windows.Forms.Label();
            this.cboModeOfPayment = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.dtpHeadApproved = new System.Windows.Forms.DateTimePicker();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtHeadApproved = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeToName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chargeToId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblParticulars = new System.Windows.Forms.Label();
            this.txtParticulars = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDoubleClick = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtDocsReceivedBy = new System.Windows.Forms.TextBox();
            this.dtpDocsReceived = new System.Windows.Forms.DateTimePicker();
            this.lblDocsReceivedBy = new System.Windows.Forms.Label();
            this.txtReleasedBy = new System.Windows.Forms.TextBox();
            this.lblForm = new System.Windows.Forms.Label();
            this.lblCashReleasedBy = new System.Windows.Forms.Label();
            this.txtFormNumber = new System.Windows.Forms.TextBox();
            this.dtpCashReleasedBy = new System.Windows.Forms.DateTimePicker();
            this.cboChargeTo = new System.Windows.Forms.ComboBox();
            this.txtBusinessOthers = new System.Windows.Forms.TextBox();
            this.txtStore = new System.Windows.Forms.TextBox();
            this.dtpRequested = new System.Windows.Forms.DateTimePicker();
            this.dtpUploadedBy = new System.Windows.Forms.DateTimePicker();
            this.lbUploadedBy = new System.Windows.Forms.Label();
            this.txtUploadedBy = new System.Windows.Forms.TextBox();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearchHeadApprover = new System.Windows.Forms.Button();
            this.btnSearchDocsReceived = new System.Windows.Forms.Button();
            this.txtMgtApproved = new System.Windows.Forms.TextBox();
            this.dtpMgtApproved = new System.Windows.Forms.DateTimePicker();
            this.btnSearchMgtApprover = new System.Windows.Forms.Button();
            this.lblMgtApprovedBy = new System.Windows.Forms.Label();
            this.lblHeadApproved = new System.Windows.Forms.Label();
            this.btnCashReleasedBy = new System.Windows.Forms.Button();
            this.btnUploadedBy = new System.Windows.Forms.Button();
            this.chkBoxChargeTo = new System.Windows.Forms.CheckedListBox();
            this.lblPartChargeTo = new System.Windows.Forms.Label();
            this.chkPartChargeTo = new System.Windows.Forms.CheckedListBox();
            this.txtPartChange = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.TSSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripShortcut = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOF = new System.Windows.Forms.Label();
            this.txtCAAmount = new System.Windows.Forms.TextBox();
            this.lblAudited = new System.Windows.Forms.Label();
            this.txtAuditedBy = new System.Windows.Forms.TextBox();
            this.dtpAudited = new System.Windows.Forms.DateTimePicker();
            this.btnAuditedBy = new System.Windows.Forms.Button();
            this.txtRejectedBy = new System.Windows.Forms.TextBox();
            this.dtpRejected = new System.Windows.Forms.DateTimePicker();
            this.lblRejected = new System.Windows.Forms.Label();
            this.btnSubmitEmail = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 100;
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 20;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(68, 59);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 15);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            this.toolTip.SetToolTip(this.lblName, "Name of the individual who actually incurred the expense.");
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(107, 56);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(401, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TabStop = false;
            this.txtName.Tag = "-1";
            this.toolTip.SetToolTip(this.txtName, "Name of the individual who actually incurred the expense.");
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.Location = new System.Drawing.Point(70, 139);
            this.lblStore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(34, 15);
            this.lblStore.TabIndex = 4;
            this.lblStore.Text = "Store:";
            this.toolTip.SetToolTip(this.lblStore, "Name of the store to which the expense is related and chargeable to.");
            // 
            // cboStores
            // 
            this.cboStores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStores.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStores.FormattingEnabled = true;
            this.cboStores.Location = new System.Drawing.Point(107, 159);
            this.cboStores.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboStores.Name = "cboStores";
            this.cboStores.Size = new System.Drawing.Size(401, 22);
            this.cboStores.TabIndex = 6;
            this.toolTip.SetToolTip(this.cboStores, "Name of the store to which the expense is related and chargeable to.");
            this.cboStores.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValidation_SelectedIndexChanged);
            // 
            // lblChargeTo
            // 
            this.lblChargeTo.AutoSize = true;
            this.lblChargeTo.BackColor = System.Drawing.Color.White;
            this.lblChargeTo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblChargeTo.Location = new System.Drawing.Point(588, 58);
            this.lblChargeTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChargeTo.Name = "lblChargeTo";
            this.lblChargeTo.Size = new System.Drawing.Size(57, 15);
            this.lblChargeTo.TabIndex = 161;
            this.lblChargeTo.Text = "Charge To:";
            this.toolTip.SetToolTip(this.lblChargeTo, "Name of the company to which the expense is related and chargeable to.");
            // 
            // cboBusinessPurpose
            // 
            this.cboBusinessPurpose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBusinessPurpose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBusinessPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusinessPurpose.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cboBusinessPurpose.FormattingEnabled = true;
            this.cboBusinessPurpose.Location = new System.Drawing.Point(107, 84);
            this.cboBusinessPurpose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboBusinessPurpose.Name = "cboBusinessPurpose";
            this.cboBusinessPurpose.Size = new System.Drawing.Size(401, 22);
            this.cboBusinessPurpose.TabIndex = 3;
            this.toolTip.SetToolTip(this.cboBusinessPurpose, "A phrase denoting the main intent or primary reason for the expense.");
            this.cboBusinessPurpose.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValidation_SelectedIndexChanged);
            // 
            // lblBusiness
            // 
            this.lblBusiness.AutoSize = true;
            this.lblBusiness.BackColor = System.Drawing.Color.Transparent;
            this.lblBusiness.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusiness.Location = new System.Drawing.Point(11, 87);
            this.lblBusiness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBusiness.Name = "lblBusiness";
            this.lblBusiness.Size = new System.Drawing.Size(93, 15);
            this.lblBusiness.TabIndex = 163;
            this.lblBusiness.Text = "Business Purpose:";
            this.toolTip.SetToolTip(this.lblBusiness, "A phrase denoting the main intent or primary reason for the expense.");
            // 
            // lblOthers
            // 
            this.lblOthers.AutoSize = true;
            this.lblOthers.BackColor = System.Drawing.Color.Transparent;
            this.lblOthers.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOthers.Location = new System.Drawing.Point(35, 114);
            this.lblOthers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOthers.Name = "lblOthers";
            this.lblOthers.Size = new System.Drawing.Size(69, 15);
            this.lblOthers.TabIndex = 165;
            this.lblOthers.Text = "Other Details:";
            this.toolTip.SetToolTip(this.lblOthers, "Other generic description of the business transaction (What, When, Where, etc.) w" +
        "hich supports that the expense is necessary, reasonable and appropriate.");
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(206, 33);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(63, 15);
            this.lblDepartment.TabIndex = 3;
            this.lblDepartment.Text = "Department:";
            this.toolTip.SetToolTip(this.lblDepartment, "Name of the cost center / department to which the expense is related and chargeab" +
        "le to.");
            // 
            // lblDateRequested
            // 
            this.lblDateRequested.AutoSize = true;
            this.lblDateRequested.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRequested.Location = new System.Drawing.Point(23, 32);
            this.lblDateRequested.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateRequested.Name = "lblDateRequested";
            this.lblDateRequested.Size = new System.Drawing.Size(81, 15);
            this.lblDateRequested.TabIndex = 0;
            this.lblDateRequested.Text = "Date Requested:";
            this.toolTip.SetToolTip(this.lblDateRequested, "Date of submission of the request through the T&E System.");
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackgroundImage = global::MyRIS.Properties.Resources.Save_Icon;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(708, 299);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(46, 42);
            this.btnSave.TabIndex = 16;
            this.toolTip.SetToolTip(this.btnSave, "Save and Edit Later");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(657, 298);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(46, 42);
            this.btnSubmit.TabIndex = 17;
            this.toolTip.SetToolTip(this.btnSubmit, "Submit");
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::MyRIS.Properties.Resources.Go_Back_Icon;
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturn.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(556, 299);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(46, 42);
            this.btnReturn.TabIndex = 172;
            this.btnReturn.TabStop = false;
            this.btnReturn.Tag = "";
            this.toolTip.SetToolTip(this.btnReturn, "Return To Requester");
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Visible = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnSaveMultiple
            // 
            this.btnSaveMultiple.BackgroundImage = global::MyRIS.Properties.Resources.Save_Icon;
            this.btnSaveMultiple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveMultiple.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMultiple.Location = new System.Drawing.Point(776, 53);
            this.btnSaveMultiple.Name = "btnSaveMultiple";
            this.btnSaveMultiple.Size = new System.Drawing.Size(27, 24);
            this.btnSaveMultiple.TabIndex = 179;
            this.btnSaveMultiple.TabStop = false;
            this.btnSaveMultiple.Tag = "";
            this.toolTip.SetToolTip(this.btnSaveMultiple, "Set Charge To");
            this.btnSaveMultiple.UseVisualStyleBackColor = true;
            this.btnSaveMultiple.Visible = false;
            this.btnSaveMultiple.Click += new System.EventHandler(this.btnSaveMultiple_Click);
            // 
            // lblCAForm
            // 
            this.lblCAForm.AutoSize = true;
            this.lblCAForm.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCAForm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCAForm.Location = new System.Drawing.Point(2, 3);
            this.lblCAForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCAForm.Name = "lblCAForm";
            this.lblCAForm.Size = new System.Drawing.Size(202, 18);
            this.lblCAForm.TabIndex = 1;
            this.lblCAForm.Text = "CASH ADVANCE FORM";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Firebrick;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStatus.Location = new System.Drawing.Point(482, 0);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(331, 25);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Tag = "0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Firebrick;
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Controls.Add(this.lblCAForm);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(813, 25);
            this.pnlHeader.TabIndex = 38;
            this.pnlHeader.Tag = "";
            // 
            // lblCANumber
            // 
            this.lblCANumber.AutoSize = true;
            this.lblCANumber.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCANumber.Location = new System.Drawing.Point(581, 33);
            this.lblCANumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCANumber.Name = "lblCANumber";
            this.lblCANumber.Size = new System.Drawing.Size(64, 15);
            this.lblCANumber.TabIndex = 39;
            this.lblCANumber.Text = "CA Number:";
            // 
            // txtCANumber
            // 
            this.txtCANumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCANumber.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCANumber.Location = new System.Drawing.Point(647, 31);
            this.txtCANumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCANumber.Name = "txtCANumber";
            this.txtCANumber.ReadOnly = true;
            this.txtCANumber.Size = new System.Drawing.Size(127, 20);
            this.txtCANumber.TabIndex = 7;
            this.txtCANumber.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // pnlRequired
            // 
            this.pnlRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlRequired.Location = new System.Drawing.Point(683, 573);
            this.pnlRequired.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlRequired.Name = "pnlRequired";
            this.pnlRequired.Size = new System.Drawing.Size(44, 23);
            this.pnlRequired.TabIndex = 112;
            // 
            // lblRequired
            // 
            this.lblRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.Location = new System.Drawing.Point(730, 577);
            this.lblRequired.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(66, 16);
            this.lblRequired.TabIndex = 111;
            this.lblRequired.Text = "Required";
            // 
            // lblDateNeeded
            // 
            this.lblDateNeeded.AutoSize = true;
            this.lblDateNeeded.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateNeeded.Location = new System.Drawing.Point(577, 113);
            this.lblDateNeeded.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateNeeded.Name = "lblDateNeeded";
            this.lblDateNeeded.Size = new System.Drawing.Size(67, 15);
            this.lblDateNeeded.TabIndex = 0;
            this.lblDateNeeded.Text = "Date Needed:";
            // 
            // dtpDateNeeded
            // 
            this.dtpDateNeeded.CustomFormat = "MM/dd/yyyy";
            this.dtpDateNeeded.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateNeeded.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateNeeded.Location = new System.Drawing.Point(647, 111);
            this.dtpDateNeeded.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpDateNeeded.Name = "dtpDateNeeded";
            this.dtpDateNeeded.Size = new System.Drawing.Size(127, 22);
            this.dtpDateNeeded.TabIndex = 10;
            // 
            // lblModeOfPayment
            // 
            this.lblModeOfPayment.AutoSize = true;
            this.lblModeOfPayment.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeOfPayment.Location = new System.Drawing.Point(556, 85);
            this.lblModeOfPayment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModeOfPayment.Name = "lblModeOfPayment";
            this.lblModeOfPayment.Size = new System.Drawing.Size(89, 15);
            this.lblModeOfPayment.TabIndex = 1;
            this.lblModeOfPayment.Text = "Mode of Payment:";
            // 
            // cboModeOfPayment
            // 
            this.cboModeOfPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeOfPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeOfPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeOfPayment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeOfPayment.FormattingEnabled = true;
            this.cboModeOfPayment.Location = new System.Drawing.Point(647, 82);
            this.cboModeOfPayment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboModeOfPayment.Name = "cboModeOfPayment";
            this.cboModeOfPayment.Size = new System.Drawing.Size(127, 22);
            this.cboModeOfPayment.TabIndex = 9;
            // 
            // cboDepartment
            // 
            this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(272, 30);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(236, 22);
            this.cboDepartment.TabIndex = 1;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValidation_SelectedIndexChanged);
            // 
            // dtpHeadApproved
            // 
            this.dtpHeadApproved.CustomFormat = "MM/dd/yyyy";
            this.dtpHeadApproved.Enabled = false;
            this.dtpHeadApproved.Font = new System.Drawing.Font("Arial", 8.25F);
            this.dtpHeadApproved.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeadApproved.Location = new System.Drawing.Point(14, 471);
            this.dtpHeadApproved.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpHeadApproved.Name = "dtpHeadApproved";
            this.dtpHeadApproved.Size = new System.Drawing.Size(98, 20);
            this.dtpHeadApproved.TabIndex = 15;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(566, 368);
            this.lblRemarks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(230, 28);
            this.lblRemarks.TabIndex = 129;
            this.lblRemarks.Text = "Remarks:";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeadApproved
            // 
            this.txtHeadApproved.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeadApproved.Location = new System.Drawing.Point(14, 418);
            this.txtHeadApproved.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtHeadApproved.Multiline = true;
            this.txtHeadApproved.Name = "txtHeadApproved";
            this.txtHeadApproved.ReadOnly = true;
            this.txtHeadApproved.Size = new System.Drawing.Size(140, 53);
            this.txtHeadApproved.TabIndex = 131;
            this.txtHeadApproved.Tag = "-1";
            this.txtHeadApproved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeadApproved.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(566, 398);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRemarks.MaxLength = 300;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(230, 102);
            this.txtRemarks.TabIndex = 19;
            this.txtRemarks.Tag = "";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.chargeToName,
            this.Amount,
            this.isActive,
            this.chargeToId});
            this.dgvList.Location = new System.Drawing.Point(14, 243);
            this.dgvList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(530, 151);
            this.dgvList.TabIndex = 14;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            this.dgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellValueChanged);
            this.dgvList.DoubleClick += new System.EventHandler(this.dgvList_DoubleClick);
            // 
            // Description
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Description.DefaultCellStyle = dataGridViewCellStyle1;
            this.Description.HeaderText = "Description/Particulars";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 380;
            // 
            // chargeToName
            // 
            this.chargeToName.FillWeight = 80F;
            this.chargeToName.HeaderText = "Charge To";
            this.chargeToName.Name = "chargeToName";
            this.chargeToName.ReadOnly = true;
            this.chargeToName.Visible = false;
            this.chargeToName.Width = 80;
            // 
            // Amount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // isActive
            // 
            this.isActive.FillWeight = 45F;
            this.isActive.HeaderText = "   √";
            this.isActive.Name = "isActive";
            this.isActive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.isActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isActive.Width = 45;
            // 
            // chargeToId
            // 
            this.chargeToId.HeaderText = "chargeToId";
            this.chargeToId.Name = "chargeToId";
            this.chargeToId.ReadOnly = true;
            this.chargeToId.Visible = false;
            // 
            // lblParticulars
            // 
            this.lblParticulars.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParticulars.Location = new System.Drawing.Point(14, 188);
            this.lblParticulars.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParticulars.Name = "lblParticulars";
            this.lblParticulars.Size = new System.Drawing.Size(340, 14);
            this.lblParticulars.TabIndex = 138;
            this.lblParticulars.Text = "Description/Particulars";
            this.lblParticulars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtParticulars
            // 
            this.txtParticulars.AcceptsTab = true;
            this.txtParticulars.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParticulars.Location = new System.Drawing.Point(16, 204);
            this.txtParticulars.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtParticulars.MaxLength = 250;
            this.txtParticulars.Name = "txtParticulars";
            this.txtParticulars.Size = new System.Drawing.Size(376, 20);
            this.txtParticulars.TabIndex = 11;
            this.txtParticulars.TextChanged += new System.EventHandler(this.txtParticulars_TextChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(394, 187);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(114, 15);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(394, 204);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(114, 20);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            // 
            // lblDoubleClick
            // 
            this.lblDoubleClick.AutoSize = true;
            this.lblDoubleClick.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDoubleClick.Location = new System.Drawing.Point(409, 229);
            this.lblDoubleClick.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoubleClick.Name = "lblDoubleClick";
            this.lblDoubleClick.Size = new System.Drawing.Size(131, 13);
            this.lblDoubleClick.TabIndex = 144;
            this.lblDoubleClick.Text = "*Double click a row to edit";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(587, 225);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(64, 15);
            this.lblTotalAmount.TabIndex = 145;
            this.lblTotalAmount.Text = "CA Amount:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(584, 273);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(170, 22);
            this.txtTotalAmount.TabIndex = 146;
            this.txtTotalAmount.Text = "0";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDocsReceivedBy
            // 
            this.txtDocsReceivedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocsReceivedBy.Location = new System.Drawing.Point(347, 418);
            this.txtDocsReceivedBy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDocsReceivedBy.Multiline = true;
            this.txtDocsReceivedBy.Name = "txtDocsReceivedBy";
            this.txtDocsReceivedBy.ReadOnly = true;
            this.txtDocsReceivedBy.Size = new System.Drawing.Size(140, 53);
            this.txtDocsReceivedBy.TabIndex = 139;
            this.txtDocsReceivedBy.Tag = "-1";
            this.txtDocsReceivedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpDocsReceived
            // 
            this.dtpDocsReceived.CustomFormat = "MM/dd/yyyy";
            this.dtpDocsReceived.Enabled = false;
            this.dtpDocsReceived.Font = new System.Drawing.Font("Arial", 8.25F);
            this.dtpDocsReceived.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocsReceived.Location = new System.Drawing.Point(347, 471);
            this.dtpDocsReceived.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpDocsReceived.Name = "dtpDocsReceived";
            this.dtpDocsReceived.Size = new System.Drawing.Size(94, 20);
            this.dtpDocsReceived.TabIndex = 19;
            // 
            // lblDocsReceivedBy
            // 
            this.lblDocsReceivedBy.AutoSize = true;
            this.lblDocsReceivedBy.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocsReceivedBy.Location = new System.Drawing.Point(350, 400);
            this.lblDocsReceivedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDocsReceivedBy.Name = "lblDocsReceivedBy";
            this.lblDocsReceivedBy.Size = new System.Drawing.Size(91, 15);
            this.lblDocsReceivedBy.TabIndex = 139;
            this.lblDocsReceivedBy.Text = "Docs Received by:";
            // 
            // txtReleasedBy
            // 
            this.txtReleasedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReleasedBy.Location = new System.Drawing.Point(348, 527);
            this.txtReleasedBy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtReleasedBy.Multiline = true;
            this.txtReleasedBy.Name = "txtReleasedBy";
            this.txtReleasedBy.ReadOnly = true;
            this.txtReleasedBy.Size = new System.Drawing.Size(140, 53);
            this.txtReleasedBy.TabIndex = 145;
            this.txtReleasedBy.Tag = "-1";
            this.txtReleasedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForm.Location = new System.Drawing.Point(675, 145);
            this.lblForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(48, 14);
            this.lblForm.TabIndex = 160;
            this.lblForm.Text = "EPV No.";
            // 
            // lblCashReleasedBy
            // 
            this.lblCashReleasedBy.AutoSize = true;
            this.lblCashReleasedBy.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashReleasedBy.Location = new System.Drawing.Point(351, 509);
            this.lblCashReleasedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCashReleasedBy.Name = "lblCashReleasedBy";
            this.lblCashReleasedBy.Size = new System.Drawing.Size(91, 15);
            this.lblCashReleasedBy.TabIndex = 144;
            this.lblCashReleasedBy.Text = "Cash Released by:";
            // 
            // txtFormNumber
            // 
            this.txtFormNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFormNumber.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormNumber.Location = new System.Drawing.Point(647, 161);
            this.txtFormNumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFormNumber.Name = "txtFormNumber";
            this.txtFormNumber.ReadOnly = true;
            this.txtFormNumber.Size = new System.Drawing.Size(101, 20);
            this.txtFormNumber.TabIndex = 161;
            // 
            // dtpCashReleasedBy
            // 
            this.dtpCashReleasedBy.CustomFormat = "MM/dd/yyyy";
            this.dtpCashReleasedBy.Font = new System.Drawing.Font("Arial", 8.25F);
            this.dtpCashReleasedBy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCashReleasedBy.Location = new System.Drawing.Point(348, 580);
            this.dtpCashReleasedBy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpCashReleasedBy.Name = "dtpCashReleasedBy";
            this.dtpCashReleasedBy.Size = new System.Drawing.Size(93, 20);
            this.dtpCashReleasedBy.TabIndex = 20;
            // 
            // cboChargeTo
            // 
            this.cboChargeTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboChargeTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboChargeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChargeTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChargeTo.FormattingEnabled = true;
            this.cboChargeTo.Location = new System.Drawing.Point(647, 55);
            this.cboChargeTo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboChargeTo.Name = "cboChargeTo";
            this.cboChargeTo.Size = new System.Drawing.Size(127, 22);
            this.cboChargeTo.TabIndex = 8;
            this.cboChargeTo.SelectedIndexChanged += new System.EventHandler(this.ComboBoxValidation_SelectedIndexChanged);
            this.cboChargeTo.SelectionChangeCommitted += new System.EventHandler(this.cboChargeTo_SelectionChangeCommitted);
            // 
            // txtBusinessOthers
            // 
            this.txtBusinessOthers.BackColor = System.Drawing.SystemColors.Window;
            this.txtBusinessOthers.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtBusinessOthers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBusinessOthers.Location = new System.Drawing.Point(107, 111);
            this.txtBusinessOthers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBusinessOthers.MaxLength = 250;
            this.txtBusinessOthers.Name = "txtBusinessOthers";
            this.txtBusinessOthers.Size = new System.Drawing.Size(401, 20);
            this.txtBusinessOthers.TabIndex = 4;
            this.txtBusinessOthers.TabStop = false;
            this.txtBusinessOthers.Tag = "";
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.SystemColors.Window;
            this.txtStore.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtStore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtStore.Location = new System.Drawing.Point(107, 137);
            this.txtStore.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStore.Name = "txtStore";
            this.txtStore.Size = new System.Drawing.Size(401, 20);
            this.txtStore.TabIndex = 5;
            this.txtStore.Tag = "";
            this.txtStore.Text = "Search Store";
            this.txtStore.Enter += new System.EventHandler(this.txtStore_Enter);
            this.txtStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStore_KeyDown);
            this.txtStore.Leave += new System.EventHandler(this.txtStore_Leave);
            // 
            // dtpRequested
            // 
            this.dtpRequested.CustomFormat = "MM/dd/yyyy";
            this.dtpRequested.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRequested.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequested.Location = new System.Drawing.Point(107, 30);
            this.dtpRequested.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpRequested.Name = "dtpRequested";
            this.dtpRequested.Size = new System.Drawing.Size(81, 20);
            this.dtpRequested.TabIndex = 0;
            // 
            // dtpUploadedBy
            // 
            this.dtpUploadedBy.CalendarFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpUploadedBy.CustomFormat = "MM/dd/yyyy";
            this.dtpUploadedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpUploadedBy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUploadedBy.Location = new System.Drawing.Point(181, 580);
            this.dtpUploadedBy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpUploadedBy.Name = "dtpUploadedBy";
            this.dtpUploadedBy.Size = new System.Drawing.Size(92, 20);
            this.dtpUploadedBy.TabIndex = 169;
            // 
            // lbUploadedBy
            // 
            this.lbUploadedBy.AutoSize = true;
            this.lbUploadedBy.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUploadedBy.Location = new System.Drawing.Point(184, 509);
            this.lbUploadedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUploadedBy.Name = "lbUploadedBy";
            this.lbUploadedBy.Size = new System.Drawing.Size(68, 15);
            this.lbUploadedBy.TabIndex = 170;
            this.lbUploadedBy.Text = "Uploaded by:";
            // 
            // txtUploadedBy
            // 
            this.txtUploadedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUploadedBy.Location = new System.Drawing.Point(181, 527);
            this.txtUploadedBy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUploadedBy.Multiline = true;
            this.txtUploadedBy.Name = "txtUploadedBy";
            this.txtUploadedBy.ReadOnly = true;
            this.txtUploadedBy.Size = new System.Drawing.Size(140, 53);
            this.txtUploadedBy.TabIndex = 171;
            this.txtUploadedBy.Tag = "-1";
            this.txtUploadedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDecline
            // 
            this.btnDecline.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDecline.BackgroundImage")));
            this.btnDecline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDecline.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecline.Location = new System.Drawing.Point(657, 299);
            this.btnDecline.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(46, 42);
            this.btnDecline.TabIndex = 17;
            this.btnDecline.TabStop = false;
            this.btnDecline.Tag = "";
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Visible = false;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccept.BackgroundImage")));
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccept.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(605, 299);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(46, 42);
            this.btnAccept.TabIndex = 16;
            this.btnAccept.TabStop = false;
            this.btnAccept.Tag = "";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Visible = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(757, 298);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(46, 42);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::MyRIS.Properties.Resources.Delete_Icon;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(518, 400);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(26, 24);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.TabStop = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(514, 201);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 25);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearchHeadApprover
            // 
            this.btnSearchHeadApprover.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchHeadApprover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchHeadApprover.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchHeadApprover.Location = new System.Drawing.Point(130, 397);
            this.btnSearchHeadApprover.Name = "btnSearchHeadApprover";
            this.btnSearchHeadApprover.Size = new System.Drawing.Size(24, 21);
            this.btnSearchHeadApprover.TabIndex = 174;
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
            this.btnSearchDocsReceived.Location = new System.Drawing.Point(464, 397);
            this.btnSearchDocsReceived.Name = "btnSearchDocsReceived";
            this.btnSearchDocsReceived.Size = new System.Drawing.Size(24, 21);
            this.btnSearchDocsReceived.TabIndex = 175;
            this.btnSearchDocsReceived.TabStop = false;
            this.btnSearchDocsReceived.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchDocsReceived.UseVisualStyleBackColor = true;
            this.btnSearchDocsReceived.Visible = false;
            this.btnSearchDocsReceived.Click += new System.EventHandler(this.btnSearchDocsReceived_Click);
            // 
            // txtMgtApproved
            // 
            this.txtMgtApproved.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMgtApproved.Location = new System.Drawing.Point(181, 418);
            this.txtMgtApproved.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMgtApproved.Multiline = true;
            this.txtMgtApproved.Name = "txtMgtApproved";
            this.txtMgtApproved.ReadOnly = true;
            this.txtMgtApproved.Size = new System.Drawing.Size(140, 53);
            this.txtMgtApproved.TabIndex = 131;
            this.txtMgtApproved.Tag = "-1";
            this.txtMgtApproved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMgtApproved.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            // 
            // dtpMgtApproved
            // 
            this.dtpMgtApproved.CustomFormat = "MM/dd/yyyy";
            this.dtpMgtApproved.Enabled = false;
            this.dtpMgtApproved.Font = new System.Drawing.Font("Arial", 8.25F);
            this.dtpMgtApproved.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMgtApproved.Location = new System.Drawing.Point(181, 471);
            this.dtpMgtApproved.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpMgtApproved.Name = "dtpMgtApproved";
            this.dtpMgtApproved.Size = new System.Drawing.Size(92, 20);
            this.dtpMgtApproved.TabIndex = 15;
            // 
            // btnSearchMgtApprover
            // 
            this.btnSearchMgtApprover.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchMgtApprover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchMgtApprover.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchMgtApprover.Location = new System.Drawing.Point(298, 397);
            this.btnSearchMgtApprover.Name = "btnSearchMgtApprover";
            this.btnSearchMgtApprover.Size = new System.Drawing.Size(24, 21);
            this.btnSearchMgtApprover.TabIndex = 174;
            this.btnSearchMgtApprover.TabStop = false;
            this.btnSearchMgtApprover.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchMgtApprover.UseVisualStyleBackColor = true;
            this.btnSearchMgtApprover.Visible = false;
            this.btnSearchMgtApprover.Click += new System.EventHandler(this.btnSearchMgtApprover_Click);
            // 
            // lblMgtApprovedBy
            // 
            this.lblMgtApprovedBy.AutoSize = true;
            this.lblMgtApprovedBy.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMgtApprovedBy.Location = new System.Drawing.Point(184, 400);
            this.lblMgtApprovedBy.Name = "lblMgtApprovedBy";
            this.lblMgtApprovedBy.Size = new System.Drawing.Size(89, 15);
            this.lblMgtApprovedBy.TabIndex = 177;
            this.lblMgtApprovedBy.Text = "Mgt Approved by:";
            // 
            // lblHeadApproved
            // 
            this.lblHeadApproved.AutoSize = true;
            this.lblHeadApproved.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadApproved.Location = new System.Drawing.Point(17, 400);
            this.lblHeadApproved.Name = "lblHeadApproved";
            this.lblHeadApproved.Size = new System.Drawing.Size(95, 15);
            this.lblHeadApproved.TabIndex = 178;
            this.lblHeadApproved.Text = "Head Approved by:";
            // 
            // btnCashReleasedBy
            // 
            this.btnCashReleasedBy.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnCashReleasedBy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCashReleasedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCashReleasedBy.Location = new System.Drawing.Point(465, 506);
            this.btnCashReleasedBy.Name = "btnCashReleasedBy";
            this.btnCashReleasedBy.Size = new System.Drawing.Size(24, 21);
            this.btnCashReleasedBy.TabIndex = 174;
            this.btnCashReleasedBy.TabStop = false;
            this.btnCashReleasedBy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCashReleasedBy.UseVisualStyleBackColor = true;
            this.btnCashReleasedBy.Click += new System.EventHandler(this.btnCashReleasedBy_Click);
            // 
            // btnUploadedBy
            // 
            this.btnUploadedBy.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnUploadedBy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUploadedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadedBy.Location = new System.Drawing.Point(297, 506);
            this.btnUploadedBy.Name = "btnUploadedBy";
            this.btnUploadedBy.Size = new System.Drawing.Size(24, 21);
            this.btnUploadedBy.TabIndex = 174;
            this.btnUploadedBy.TabStop = false;
            this.btnUploadedBy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUploadedBy.UseVisualStyleBackColor = true;
            this.btnUploadedBy.Click += new System.EventHandler(this.btnUploadedBy_Click);
            // 
            // chkBoxChargeTo
            // 
            this.chkBoxChargeTo.CheckOnClick = true;
            this.chkBoxChargeTo.FormattingEnabled = true;
            this.chkBoxChargeTo.Location = new System.Drawing.Point(647, 56);
            this.chkBoxChargeTo.Name = "chkBoxChargeTo";
            this.chkBoxChargeTo.Size = new System.Drawing.Size(127, 19);
            this.chkBoxChargeTo.TabIndex = 180;
            this.chkBoxChargeTo.Visible = false;
            // 
            // lblPartChargeTo
            // 
            this.lblPartChargeTo.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartChargeTo.Location = new System.Drawing.Point(292, 186);
            this.lblPartChargeTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPartChargeTo.Name = "lblPartChargeTo";
            this.lblPartChargeTo.Size = new System.Drawing.Size(98, 16);
            this.lblPartChargeTo.TabIndex = 8;
            this.lblPartChargeTo.Text = "Charge To";
            this.lblPartChargeTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPartChargeTo.Visible = false;
            // 
            // chkPartChargeTo
            // 
            this.chkPartChargeTo.CheckOnClick = true;
            this.chkPartChargeTo.FormattingEnabled = true;
            this.chkPartChargeTo.Location = new System.Drawing.Point(295, 204);
            this.chkPartChargeTo.Name = "chkPartChargeTo";
            this.chkPartChargeTo.Size = new System.Drawing.Size(97, 19);
            this.chkPartChargeTo.TabIndex = 180;
            this.chkPartChargeTo.Visible = false;
            this.chkPartChargeTo.Enter += new System.EventHandler(this.chkPartChargeTo_Enter);
            this.chkPartChargeTo.Leave += new System.EventHandler(this.chkPartChargeTo_Leave);
            // 
            // txtPartChange
            // 
            this.txtPartChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartChange.Location = new System.Drawing.Point(295, 203);
            this.txtPartChange.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPartChange.Name = "txtPartChange";
            this.txtPartChange.ReadOnly = true;
            this.txtPartChange.Size = new System.Drawing.Size(97, 20);
            this.txtPartChange.TabIndex = 12;
            this.txtPartChange.Visible = false;
            this.txtPartChange.TextChanged += new System.EventHandler(this.TextBoxValidation_TextChanged);
            this.txtPartChange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSLabel,
            this.toolStripShortcut,
            this.toolStrip});
            this.statusStrip.Location = new System.Drawing.Point(0, 611);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(813, 22);
            this.statusStrip.TabIndex = 181;
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
            // lblOF
            // 
            this.lblOF.AutoSize = true;
            this.lblOF.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOF.Location = new System.Drawing.Point(724, 246);
            this.lblOF.Name = "lblOF";
            this.lblOF.Size = new System.Drawing.Size(26, 16);
            this.lblOF.TabIndex = 183;
            this.lblOF.Text = "OF";
            // 
            // txtCAAmount
            // 
            this.txtCAAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCAAmount.Location = new System.Drawing.Point(584, 243);
            this.txtCAAmount.Name = "txtCAAmount";
            this.txtCAAmount.ReadOnly = true;
            this.txtCAAmount.Size = new System.Drawing.Size(137, 22);
            this.txtCAAmount.TabIndex = 182;
            this.txtCAAmount.TabStop = false;
            this.txtCAAmount.Text = "0";
            this.txtCAAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAudited
            // 
            this.lblAudited.AutoSize = true;
            this.lblAudited.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudited.Location = new System.Drawing.Point(17, 512);
            this.lblAudited.Name = "lblAudited";
            this.lblAudited.Size = new System.Drawing.Size(60, 15);
            this.lblAudited.TabIndex = 185;
            this.lblAudited.Text = "Audited by:";
            // 
            // txtAuditedBy
            // 
            this.txtAuditedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditedBy.Location = new System.Drawing.Point(14, 530);
            this.txtAuditedBy.Multiline = true;
            this.txtAuditedBy.Name = "txtAuditedBy";
            this.txtAuditedBy.ReadOnly = true;
            this.txtAuditedBy.Size = new System.Drawing.Size(140, 50);
            this.txtAuditedBy.TabIndex = 186;
            this.txtAuditedBy.Tag = "-1";
            this.txtAuditedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpAudited
            // 
            this.dtpAudited.CalendarFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAudited.CustomFormat = "MM/dd/yyyy";
            this.dtpAudited.Enabled = false;
            this.dtpAudited.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAudited.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAudited.Location = new System.Drawing.Point(14, 580);
            this.dtpAudited.Name = "dtpAudited";
            this.dtpAudited.Size = new System.Drawing.Size(98, 20);
            this.dtpAudited.TabIndex = 184;
            // 
            // btnAuditedBy
            // 
            this.btnAuditedBy.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnAuditedBy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAuditedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditedBy.Location = new System.Drawing.Point(130, 509);
            this.btnAuditedBy.Name = "btnAuditedBy";
            this.btnAuditedBy.Size = new System.Drawing.Size(24, 21);
            this.btnAuditedBy.TabIndex = 174;
            this.btnAuditedBy.TabStop = false;
            this.btnAuditedBy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAuditedBy.UseVisualStyleBackColor = true;
            this.btnAuditedBy.Click += new System.EventHandler(this.btnAuditedBy_Click);
            // 
            // txtRejectedBy
            // 
            this.txtRejectedBy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRejectedBy.Location = new System.Drawing.Point(514, 527);
            this.txtRejectedBy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRejectedBy.Multiline = true;
            this.txtRejectedBy.Name = "txtRejectedBy";
            this.txtRejectedBy.ReadOnly = true;
            this.txtRejectedBy.Size = new System.Drawing.Size(140, 53);
            this.txtRejectedBy.TabIndex = 145;
            this.txtRejectedBy.Tag = "-1";
            this.txtRejectedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpRejected
            // 
            this.dtpRejected.CustomFormat = "MM/dd/yyyy";
            this.dtpRejected.Font = new System.Drawing.Font("Arial", 8.25F);
            this.dtpRejected.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRejected.Location = new System.Drawing.Point(514, 580);
            this.dtpRejected.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpRejected.Name = "dtpRejected";
            this.dtpRejected.Size = new System.Drawing.Size(93, 20);
            this.dtpRejected.TabIndex = 20;
            // 
            // lblRejected
            // 
            this.lblRejected.AutoSize = true;
            this.lblRejected.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRejected.Location = new System.Drawing.Point(517, 509);
            this.lblRejected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRejected.Name = "lblRejected";
            this.lblRejected.Size = new System.Drawing.Size(63, 15);
            this.lblRejected.TabIndex = 187;
            this.lblRejected.Text = "Rejected by:";
            // 
            // btnSubmitEmail
            // 
            this.btnSubmitEmail.BackgroundImage = global::MyRIS.Properties.Resources.Go_Back_Icon;
            this.btnSubmitEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSubmitEmail.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitEmail.Location = new System.Drawing.Point(708, 298);
            this.btnSubmitEmail.Name = "btnSubmitEmail";
            this.btnSubmitEmail.Size = new System.Drawing.Size(46, 43);
            this.btnSubmitEmail.TabIndex = 188;
            this.btnSubmitEmail.TabStop = false;
            this.btnSubmitEmail.Tag = "";
            this.btnSubmitEmail.UseVisualStyleBackColor = true;
            this.btnSubmitEmail.Visible = false;
            this.btnSubmitEmail.Click += new System.EventHandler(this.btnSubmitEmail_Click);
            // 
            // frmCashAdvanceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(813, 633);
            this.Controls.Add(this.btnSubmitEmail);
            this.Controls.Add(this.lblRejected);
            this.Controls.Add(this.lblAudited);
            this.Controls.Add(this.txtAuditedBy);
            this.Controls.Add(this.dtpAudited);
            this.Controls.Add(this.lblOF);
            this.Controls.Add(this.txtCAAmount);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.chkPartChargeTo);
            this.Controls.Add(this.chkBoxChargeTo);
            this.Controls.Add(this.btnSaveMultiple);
            this.Controls.Add(this.txtMgtApproved);
            this.Controls.Add(this.lblMgtApprovedBy);
            this.Controls.Add(this.dtpMgtApproved);
            this.Controls.Add(this.lblHeadApproved);
            this.Controls.Add(this.txtHeadApproved);
            this.Controls.Add(this.btnAuditedBy);
            this.Controls.Add(this.btnUploadedBy);
            this.Controls.Add(this.btnCashReleasedBy);
            this.Controls.Add(this.btnSearchMgtApprover);
            this.Controls.Add(this.dtpHeadApproved);
            this.Controls.Add(this.btnSearchDocsReceived);
            this.Controls.Add(this.btnSearchHeadApprover);
            this.Controls.Add(this.txtFormNumber);
            this.Controls.Add(this.lblForm);
            this.Controls.Add(this.dtpRejected);
            this.Controls.Add(this.dtpCashReleasedBy);
            this.Controls.Add(this.dtpUploadedBy);
            this.Controls.Add(this.lbUploadedBy);
            this.Controls.Add(this.lblCashReleasedBy);
            this.Controls.Add(this.txtUploadedBy);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.txtRejectedBy);
            this.Controls.Add(this.txtReleasedBy);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblDocsReceivedBy);
            this.Controls.Add(this.txtStore);
            this.Controls.Add(this.dtpDocsReceived);
            this.Controls.Add(this.txtBusinessOthers);
            this.Controls.Add(this.txtDocsReceivedBy);
            this.Controls.Add(this.lblOthers);
            this.Controls.Add(this.cboBusinessPurpose);
            this.Controls.Add(this.lblBusiness);
            this.Controls.Add(this.lblChargeTo);
            this.Controls.Add(this.cboChargeTo);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboStores);
            this.Controls.Add(this.lblStore);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblDoubleClick);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtPartChange);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblPartChargeTo);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtParticulars);
            this.Controls.Add(this.lblParticulars);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cboModeOfPayment);
            this.Controls.Add(this.lblModeOfPayment);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dtpRequested);
            this.Controls.Add(this.lblDateRequested);
            this.Controls.Add(this.dtpDateNeeded);
            this.Controls.Add(this.lblDateNeeded);
            this.Controls.Add(this.lblRequired);
            this.Controls.Add(this.pnlRequired);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtCANumber);
            this.Controls.Add(this.lblCANumber);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnReturn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmCashAdvanceDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Advance Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCashAdvanceDetail_FormClosing);
            this.Load += new System.EventHandler(this.frmCashAdvanceDetail_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblCAForm;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblCANumber;
        private System.Windows.Forms.TextBox txtCANumber;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel pnlRequired;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label lblDateNeeded;
        private System.Windows.Forms.DateTimePicker dtpDateNeeded;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblModeOfPayment;
        private System.Windows.Forms.ComboBox cboModeOfPayment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.DateTimePicker dtpHeadApproved;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtHeadApproved;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label lblParticulars;
        private System.Windows.Forms.TextBox txtParticulars;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblDoubleClick;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.ComboBox cboStores;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDocsReceivedBy;
        private System.Windows.Forms.DateTimePicker dtpDocsReceived;
        private System.Windows.Forms.Label lblDocsReceivedBy;
        private System.Windows.Forms.TextBox txtReleasedBy;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.Label lblCashReleasedBy;
        private System.Windows.Forms.TextBox txtFormNumber;
        private System.Windows.Forms.DateTimePicker dtpCashReleasedBy;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblChargeTo;
        private System.Windows.Forms.ComboBox cboChargeTo;
        private System.Windows.Forms.ComboBox cboBusinessPurpose;
        private System.Windows.Forms.Label lblBusiness;
        private System.Windows.Forms.TextBox txtBusinessOthers;
        private System.Windows.Forms.Label lblOthers;
        private System.Windows.Forms.TextBox txtStore;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblDateRequested;
        private System.Windows.Forms.DateTimePicker dtpRequested;
        private System.Windows.Forms.DateTimePicker dtpUploadedBy;
        private System.Windows.Forms.Label lbUploadedBy;
        private System.Windows.Forms.TextBox txtUploadedBy;
        private System.Windows.Forms.Button btnReturn;
        public System.Windows.Forms.Button btnSearchHeadApprover;
        public System.Windows.Forms.Button btnSearchDocsReceived;
        private System.Windows.Forms.TextBox txtMgtApproved;
        private System.Windows.Forms.DateTimePicker dtpMgtApproved;
        public System.Windows.Forms.Button btnSearchMgtApprover;
        private System.Windows.Forms.Label lblMgtApprovedBy;
        private System.Windows.Forms.Label lblHeadApproved;
        public System.Windows.Forms.Button btnCashReleasedBy;
        public System.Windows.Forms.Button btnUploadedBy;
        private System.Windows.Forms.Button btnSaveMultiple;
        private System.Windows.Forms.CheckedListBox chkBoxChargeTo;
        private System.Windows.Forms.Label lblPartChargeTo;
        private System.Windows.Forms.CheckedListBox chkPartChargeTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeToName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeToId;
        private System.Windows.Forms.TextBox txtPartChange;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel TSSLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripShortcut;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip;
        private System.Windows.Forms.Label lblOF;
        private System.Windows.Forms.TextBox txtCAAmount;
        private System.Windows.Forms.Label lblAudited;
        private System.Windows.Forms.TextBox txtAuditedBy;
        private System.Windows.Forms.DateTimePicker dtpAudited;
        public System.Windows.Forms.Button btnAuditedBy;
        private System.Windows.Forms.TextBox txtRejectedBy;
        private System.Windows.Forms.DateTimePicker dtpRejected;
        private System.Windows.Forms.Label lblRejected;
        private System.Windows.Forms.Button btnSubmitEmail;
    }
}