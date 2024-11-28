namespace MyRIS
{
    partial class frmEPV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEPV));
            this.pnlGroup = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.pnlPeriod = new System.Windows.Forms.GroupBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblDash = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearchItemID = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlRGMC = new System.Windows.Forms.Panel();
            this.pnlGroup.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.pnlRGMC.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGroup
            // 
            this.pnlGroup.BackColor = System.Drawing.Color.White;
            this.pnlGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGroup.Controls.Add(this.btnExcel);
            this.pnlGroup.Controls.Add(this.lblCount);
            this.pnlGroup.Controls.Add(this.lblRecordCount);
            this.pnlGroup.Controls.Add(this.pnlPeriod);
            this.pnlGroup.Controls.Add(this.btnSearchItemID);
            this.pnlGroup.Controls.Add(this.txtSearch);
            this.pnlGroup.Controls.Add(this.lblSearch);
            this.pnlGroup.Controls.Add(this.panel4);
            this.pnlGroup.Controls.Add(this.panel2);
            this.pnlGroup.Controls.Add(this.pnlBrand);
            this.pnlGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroup.Location = new System.Drawing.Point(0, 37);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.Size = new System.Drawing.Size(1040, 111);
            this.pnlGroup.TabIndex = 42;
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::MyRIS.Properties.Resources.Excel_Icon;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(618, 51);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(46, 43);
            this.btnExcel.TabIndex = 36;
            this.btnExcel.TabStop = false;
            this.btnExcel.Tag = "";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(100, 87);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 14);
            this.lblCount.TabIndex = 28;
            this.lblCount.Text = "#";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(4, 87);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(85, 14);
            this.lblRecordCount.TabIndex = 28;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.btnGo);
            this.pnlPeriod.Controls.Add(this.lblDash);
            this.pnlPeriod.Controls.Add(this.dtpEndDate);
            this.pnlPeriod.Controls.Add(this.dtpStartDate);
            this.pnlPeriod.Location = new System.Drawing.Point(350, 45);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(262, 50);
            this.pnlPeriod.TabIndex = 28;
            this.pnlPeriod.TabStop = false;
            this.pnlPeriod.Text = "Period";
            // 
            // btnGo
            // 
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(204, 16);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(30, 21);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDash.Location = new System.Drawing.Point(100, 19);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(12, 13);
            this.lblDash.TabIndex = 2;
            this.lblDash.Text = "-";
            this.lblDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "MM/dd/yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(118, 16);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(80, 21);
            this.dtpEndDate.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "MM/dd/yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(14, 16);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(80, 21);
            this.dtpStartDate.TabIndex = 1;
            // 
            // btnSearchItemID
            // 
            this.btnSearchItemID.BackgroundImage = global::MyRIS.Properties.Resources.Filter_Icon;
            this.btnSearchItemID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchItemID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchItemID.Location = new System.Drawing.Point(648, 21);
            this.btnSearchItemID.Name = "btnSearchItemID";
            this.btnSearchItemID.Size = new System.Drawing.Size(26, 24);
            this.btnSearchItemID.TabIndex = 27;
            this.btnSearchItemID.TabStop = false;
            this.btnSearchItemID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSearchItemID.UseVisualStyleBackColor = true;
            this.btnSearchItemID.Click += new System.EventHandler(this.btnSearchItemID_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(350, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(295, 20);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(347, 7);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(301, 14);
            this.lblSearch.TabIndex = 25;
            this.lblSearch.Text = "Filter by [EPV #, Store, Department, Mode of Payment]";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cboTransactionType);
            this.panel4.Controls.Add(this.lblTransactionType);
            this.panel4.Location = new System.Drawing.Point(1, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(241, 23);
            this.panel4.TabIndex = 23;
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(95, 1);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(146, 21);
            this.cboTransactionType.TabIndex = 22;
            this.cboTransactionType.SelectionChangeCommitted += new System.EventHandler(this.cboTransactionType_SelectionChangeCommitted);
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionType.Location = new System.Drawing.Point(3, 5);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(93, 14);
            this.lblTransactionType.TabIndex = 21;
            this.lblTransactionType.Text = "Transaction Type:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEmployee);
            this.panel2.Controls.Add(this.txtEmployee);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 23);
            this.panel2.TabIndex = 23;
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmployee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Location = new System.Drawing.Point(297, 0);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(26, 24);
            this.btnEmployee.TabIndex = 123;
            this.btnEmployee.TabStop = false;
            this.btnEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(95, 2);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.Size = new System.Drawing.Size(198, 20);
            this.txtEmployee.TabIndex = 22;
            this.txtEmployee.Tag = "-1";
            this.txtEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployee_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 14);
            this.label2.TabIndex = 21;
            this.label2.Text = "Employee Name:";
            // 
            // pnlBrand
            // 
            this.pnlBrand.Controls.Add(this.cboCompany);
            this.pnlBrand.Controls.Add(this.lblCompany);
            this.pnlBrand.Location = new System.Drawing.Point(2, 5);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(286, 23);
            this.pnlBrand.TabIndex = 23;
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(93, 1);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(172, 21);
            this.cboCompany.TabIndex = 22;
            this.cboCompany.SelectionChangeCommitted += new System.EventHandler(this.cboCompany_SelectionChangeCommitted);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(3, 5);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(55, 14);
            this.lblCompany.TabIndex = 21;
            this.lblCompany.Text = "Company:";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 148);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1040, 535);
            this.dgvList.TabIndex = 43;
            this.dgvList.DoubleClick += new System.EventHandler(this.dgvList_DoubleClick);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Firebrick;
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHeader.Location = new System.Drawing.Point(3, 8);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(328, 23);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Expense Payment Voucher";
            // 
            // pnlRGMC
            // 
            this.pnlRGMC.BackColor = System.Drawing.Color.Firebrick;
            this.pnlRGMC.Controls.Add(this.lblHeader);
            this.pnlRGMC.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRGMC.Location = new System.Drawing.Point(0, 0);
            this.pnlRGMC.Name = "pnlRGMC";
            this.pnlRGMC.Size = new System.Drawing.Size(1040, 37);
            this.pnlRGMC.TabIndex = 38;
            this.pnlRGMC.Tag = "";
            // 
            // frmEPV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 683);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.pnlGroup);
            this.Controls.Add(this.pnlRGMC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "frmEPV";
            this.Text = "Expense Payment Voucher";
            this.Load += new System.EventHandler(this.frmEPV_Load);
            this.pnlGroup.ResumeLayout(false);
            this.pnlGroup.PerformLayout();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.pnlRGMC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGroup;
        private System.Windows.Forms.GroupBox pnlPeriod;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        public System.Windows.Forms.Button btnSearchItemID;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlRGMC;
        private System.Windows.Forms.Button btnExcel;
    }
}