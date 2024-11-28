namespace MyRIS
{
    partial class frmFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilter));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlInformation = new System.Windows.Forms.Panel();
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblDashNumber = new System.Windows.Forms.Label();
            this.txtToNumber = new System.Windows.Forms.TextBox();
            this.txtFromNumber = new System.Windows.Forms.TextBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblDashDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.picArrow = new System.Windows.Forms.PictureBox();
            this.cboOperation = new System.Windows.Forms.ComboBox();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblGeneralInfo = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlInformation.SuspendLayout();
            this.grpCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArrow)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 140);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(461, 42);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(381, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(309, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 28);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlInformation
            // 
            this.pnlInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInformation.Controls.Add(this.grpCondition);
            this.pnlInformation.Controls.Add(this.cboField);
            this.pnlInformation.Controls.Add(this.lblFilter);
            this.pnlInformation.Controls.Add(this.pnlTitle);
            this.pnlInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInformation.Location = new System.Drawing.Point(0, 0);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(461, 140);
            this.pnlInformation.TabIndex = 0;
            // 
            // grpCondition
            // 
            this.grpCondition.BackColor = System.Drawing.SystemColors.Control;
            this.grpCondition.Controls.Add(this.txtFilter);
            this.grpCondition.Controls.Add(this.lblDashNumber);
            this.grpCondition.Controls.Add(this.txtToNumber);
            this.grpCondition.Controls.Add(this.txtFromNumber);
            this.grpCondition.Controls.Add(this.dtpToDate);
            this.grpCondition.Controls.Add(this.lblDashDate);
            this.grpCondition.Controls.Add(this.dtpFromDate);
            this.grpCondition.Controls.Add(this.picArrow);
            this.grpCondition.Controls.Add(this.cboOperation);
            this.grpCondition.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCondition.Location = new System.Drawing.Point(10, 76);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(437, 52);
            this.grpCondition.TabIndex = 2;
            this.grpCondition.TabStop = false;
            this.grpCondition.Text = "Condition";
            // 
            // txtFilter
            // 
            this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(235, 20);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(191, 21);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.Enter += new System.EventHandler(this.txtFilter_Enter);
            // 
            // lblDashNumber
            // 
            this.lblDashNumber.AutoSize = true;
            this.lblDashNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashNumber.Location = new System.Drawing.Point(317, 23);
            this.lblDashNumber.Name = "lblDashNumber";
            this.lblDashNumber.Size = new System.Drawing.Size(26, 13);
            this.lblDashNumber.TabIndex = 9;
            this.lblDashNumber.Text = "And";
            this.lblDashNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDashNumber.Visible = false;
            // 
            // txtToNumber
            // 
            this.txtToNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToNumber.Location = new System.Drawing.Point(346, 20);
            this.txtToNumber.Name = "txtToNumber";
            this.txtToNumber.Size = new System.Drawing.Size(80, 21);
            this.txtToNumber.TabIndex = 10;
            this.txtToNumber.Visible = false;
            this.txtToNumber.Enter += new System.EventHandler(this.txtToNumber_Enter);
            this.txtToNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToNumber_KeyPress);
            // 
            // txtFromNumber
            // 
            this.txtFromNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFromNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromNumber.Location = new System.Drawing.Point(235, 20);
            this.txtFromNumber.Name = "txtFromNumber";
            this.txtFromNumber.Size = new System.Drawing.Size(80, 21);
            this.txtFromNumber.TabIndex = 8;
            this.txtFromNumber.Visible = false;
            this.txtFromNumber.Enter += new System.EventHandler(this.txtFromNumber_Enter);
            this.txtFromNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromNumber_KeyPress);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "MM/dd/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(346, 20);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(80, 21);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.Visible = false;
            // 
            // lblDashDate
            // 
            this.lblDashDate.AutoSize = true;
            this.lblDashDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashDate.Location = new System.Drawing.Point(317, 23);
            this.lblDashDate.Name = "lblDashDate";
            this.lblDashDate.Size = new System.Drawing.Size(26, 13);
            this.lblDashDate.TabIndex = 6;
            this.lblDashDate.Text = "And";
            this.lblDashDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDashDate.Visible = false;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "MM/dd/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(235, 20);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(80, 21);
            this.dtpFromDate.TabIndex = 5;
            this.dtpFromDate.Visible = false;
            // 
            // picArrow
            //             
            this.picArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picArrow.Location = new System.Drawing.Point(208, 20);
            this.picArrow.Name = "picArrow";
            this.picArrow.Size = new System.Drawing.Size(21, 21);
            this.picArrow.TabIndex = 4;
            this.picArrow.TabStop = false;
            // 
            // cboOperation
            // 
            this.cboOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOperation.FormattingEnabled = true;
            this.cboOperation.Location = new System.Drawing.Point(12, 20);
            this.cboOperation.Name = "cboOperation";
            this.cboOperation.Size = new System.Drawing.Size(190, 21);
            this.cboOperation.TabIndex = 3;
            this.cboOperation.SelectionChangeCommitted += new System.EventHandler(this.cboOperation_SelectionChangeCommitted);
            // 
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(104, 42);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(279, 21);
            this.cboField.TabIndex = 1;
            this.cboField.SelectionChangeCommitted += new System.EventHandler(this.cboField_SelectionChangeCommitted);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(10, 45);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(88, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter Records By";
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.BackColor = System.Drawing.Color.DarkMagenta;
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitle.Controls.Add(this.lblGeneralInfo);
            this.pnlTitle.Location = new System.Drawing.Point(0, 6);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(457, 26);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblGeneralInfo
            // 
            this.lblGeneralInfo.AutoSize = true;
            this.lblGeneralInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblGeneralInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneralInfo.ForeColor = System.Drawing.Color.White;
            this.lblGeneralInfo.Location = new System.Drawing.Point(6, 6);
            this.lblGeneralInfo.Margin = new System.Windows.Forms.Padding(8);
            this.lblGeneralInfo.Name = "lblGeneralInfo";
            this.lblGeneralInfo.Size = new System.Drawing.Size(85, 13);
            this.lblGeneralInfo.TabIndex = 1;
            this.lblGeneralInfo.Text = "Filter Records";
            this.lblGeneralInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmFilter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(461, 182);
            this.Controls.Add(this.pnlInformation);
            this.Controls.Add(this.pnlButtons);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFilter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Records";
            this.Activated += new System.EventHandler(this.frmFilter_Activated);
            this.Load += new System.EventHandler(this.frmFilter_Load);
            this.pnlButtons.ResumeLayout(false);
            this.pnlInformation.ResumeLayout(false);
            this.pnlInformation.PerformLayout();
            this.grpCondition.ResumeLayout(false);
            this.grpCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArrow)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnlInformation;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblGeneralInfo;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.GroupBox grpCondition;
        private System.Windows.Forms.ComboBox cboOperation;
        private System.Windows.Forms.PictureBox picArrow;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblDashDate;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblDashNumber;
        private System.Windows.Forms.TextBox txtToNumber;
        private System.Windows.Forms.TextBox txtFromNumber;
    }
}