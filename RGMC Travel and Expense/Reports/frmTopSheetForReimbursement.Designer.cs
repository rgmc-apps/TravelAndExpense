namespace MyRIS
{
    partial class frmTopSheetForReimbursement
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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.dtpBatchDate = new System.Windows.Forms.DateTimePicker();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.lblModeOfPayment = new System.Windows.Forms.Label();
            this.cboModeOfPayment = new System.Windows.Forms.ComboBox();
            this.lblBatchDate = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnExcel);
            this.pnlButtons.Controls.Add(this.btnPreview);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(108, 163);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(314, 42);
            this.pnlButtons.TabIndex = 101;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(5, 7);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(104, 28);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "&Export To Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(236, 7);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(66, 28);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(119, 10);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(8);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(286, 75);
            this.lblDescription.TabIndex = 100;
            this.lblDescription.Text = "Report description\r\n\r\n\r\nPaper Type : Letter\r\nPaper Orientation : Potrait\r\n";
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Firebrick;
            this.pnlLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(108, 205);
            this.pnlLogo.TabIndex = 102;
            // 
            // dtpBatchDate
            // 
            this.dtpBatchDate.CustomFormat = "MM/dd/yyyy";
            this.dtpBatchDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dtpBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatchDate.Location = new System.Drawing.Point(260, 91);
            this.dtpBatchDate.Name = "dtpBatchDate";
            this.dtpBatchDate.Size = new System.Drawing.Size(80, 21);
            this.dtpBatchDate.TabIndex = 0;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // lblModeOfPayment
            // 
            this.lblModeOfPayment.AutoSize = true;
            this.lblModeOfPayment.BackColor = System.Drawing.SystemColors.Control;
            this.lblModeOfPayment.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeOfPayment.Location = new System.Drawing.Point(135, 121);
            this.lblModeOfPayment.Name = "lblModeOfPayment";
            this.lblModeOfPayment.Size = new System.Drawing.Size(123, 16);
            this.lblModeOfPayment.TabIndex = 104;
            this.lblModeOfPayment.Text = "Mode of Payment:";
            // 
            // cboModeOfPayment
            // 
            this.cboModeOfPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModeOfPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeOfPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeOfPayment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeOfPayment.FormattingEnabled = true;
            this.cboModeOfPayment.Location = new System.Drawing.Point(260, 118);
            this.cboModeOfPayment.Name = "cboModeOfPayment";
            this.cboModeOfPayment.Size = new System.Drawing.Size(126, 22);
            this.cboModeOfPayment.TabIndex = 105;
            // 
            // lblBatchDate
            // 
            this.lblBatchDate.AutoSize = true;
            this.lblBatchDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblBatchDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchDate.Location = new System.Drawing.Point(177, 93);
            this.lblBatchDate.Name = "lblBatchDate";
            this.lblBatchDate.Size = new System.Drawing.Size(81, 16);
            this.lblBatchDate.TabIndex = 104;
            this.lblBatchDate.Text = "Batch Date:";
            // 
            // frmTopSheetForReimbursement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 205);
            this.Controls.Add(this.dtpBatchDate);
            this.Controls.Add(this.lblBatchDate);
            this.Controls.Add(this.lblModeOfPayment);
            this.Controls.Add(this.cboModeOfPayment);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pnlLogo);
            this.Name = "frmTopSheetForReimbursement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top Sheet For Reimbursement";
            this.Load += new System.EventHandler(this.frmTopSheetForReimbursement_Load);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.DateTimePicker dtpBatchDate;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label lblModeOfPayment;
        private System.Windows.Forms.ComboBox cboModeOfPayment;
        private System.Windows.Forms.Label lblBatchDate;
    }
}