namespace MyRIS
{
    partial class frmEPVMonitoring
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
            this.pnlPeriod = new System.Windows.Forms.GroupBox();
            this.radReleasedDate = new System.Windows.Forms.RadioButton();
            this.radBatchDate = new System.Windows.Forms.RadioButton();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDash = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnExcel);
            this.pnlButtons.Controls.Add(this.btnPreview);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(108, 179);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(306, 42);
            this.pnlButtons.TabIndex = 89;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(4, 7);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(104, 28);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "&Export To Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(226, 7);
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
            this.lblDescription.Size = new System.Drawing.Size(295, 75);
            this.lblDescription.TabIndex = 88;
            this.lblDescription.Text = "Report description\r\n\r\n\r\nPaper Type : Letter\r\nPaper Orientation : Potrait\r\n";
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Firebrick;
            this.pnlLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(108, 221);
            this.pnlLogo.TabIndex = 90;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.radReleasedDate);
            this.pnlPeriod.Controls.Add(this.radBatchDate);
            this.pnlPeriod.Controls.Add(this.dtpEndDate);
            this.pnlPeriod.Controls.Add(this.dtpStartDate);
            this.pnlPeriod.Controls.Add(this.lblDash);
            this.pnlPeriod.Location = new System.Drawing.Point(133, 90);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(262, 74);
            this.pnlPeriod.TabIndex = 91;
            this.pnlPeriod.TabStop = false;
            this.pnlPeriod.Text = "Period (Batch Date)";
            // 
            // radReleasedDate
            // 
            this.radReleasedDate.AutoSize = true;
            this.radReleasedDate.Location = new System.Drawing.Point(141, 19);
            this.radReleasedDate.Name = "radReleasedDate";
            this.radReleasedDate.Size = new System.Drawing.Size(96, 17);
            this.radReleasedDate.TabIndex = 10;
            this.radReleasedDate.TabStop = true;
            this.radReleasedDate.Tag = "1";
            this.radReleasedDate.Text = "Released Date";
            this.radReleasedDate.UseVisualStyleBackColor = true;
            // 
            // radBatchDate
            // 
            this.radBatchDate.AutoSize = true;
            this.radBatchDate.Location = new System.Drawing.Point(26, 19);
            this.radBatchDate.Name = "radBatchDate";
            this.radBatchDate.Size = new System.Drawing.Size(79, 17);
            this.radBatchDate.TabIndex = 11;
            this.radBatchDate.TabStop = true;
            this.radBatchDate.Tag = "0";
            this.radBatchDate.Text = "Batch Date";
            this.radBatchDate.UseVisualStyleBackColor = true;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "MM/dd/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(141, 46);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(83, 20);
            this.dtpEndDate.TabIndex = 4;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "MM/dd/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(36, 46);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(83, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDash.Location = new System.Drawing.Point(124, 49);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(12, 13);
            this.lblDash.TabIndex = 2;
            this.lblDash.Text = "-";
            this.lblDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEPVMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 221);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.pnlPeriod);
            this.Name = "frmEPVMonitoring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPV Monitoring";
            this.Load += new System.EventHandler(this.frmEPVMonitoring_Load);
            this.pnlButtons.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.GroupBox pnlPeriod;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.RadioButton radReleasedDate;
        private System.Windows.Forms.RadioButton radBatchDate;
    }
}