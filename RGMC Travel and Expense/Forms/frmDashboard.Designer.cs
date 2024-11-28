namespace MyRIS
{
    partial class frmDashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDashboard = new System.Windows.Forms.DataGridView();
            this.pnlFilterSort = new System.Windows.Forms.Panel();
            this.lblLegend = new System.Windows.Forms.Label();
            this.pnlNormal = new System.Windows.Forms.Panel();
            this.lblNormal = new System.Windows.Forms.Label();
            this.pnlNeutral = new System.Windows.Forms.Panel();
            this.lblNeutral = new System.Windows.Forms.Label();
            this.pnlCaution = new System.Windows.Forms.Panel();
            this.lblCaution = new System.Windows.Forms.Label();
            this.pnlCritical = new System.Windows.Forms.Panel();
            this.lblCritical = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnEPV = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblCellFormat = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblEPV = new System.Windows.Forms.Label();
            this.btnCA = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnRefreshEPV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboard)).BeginInit();
            this.pnlFilterSort.SuspendLayout();
            this.pnlNormal.SuspendLayout();
            this.pnlNeutral.SuspendLayout();
            this.pnlCaution.SuspendLayout();
            this.pnlCritical.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDashboard
            // 
            this.dgvDashboard.AllowUserToAddRows = false;
            this.dgvDashboard.AllowUserToDeleteRows = false;
            this.dgvDashboard.AllowUserToResizeRows = false;
            this.dgvDashboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDashboard.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvDashboard.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDashboard.Location = new System.Drawing.Point(0, 50);
            this.dgvDashboard.MultiSelect = false;
            this.dgvDashboard.Name = "dgvDashboard";
            this.dgvDashboard.ReadOnly = true;
            this.dgvDashboard.RowHeadersVisible = false;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDashboard.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDashboard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDashboard.Size = new System.Drawing.Size(1001, 469);
            this.dgvDashboard.TabIndex = 78;
            this.dgvDashboard.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDashboard_CellDoubleClick);
            this.dgvDashboard.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDashboard_CellEnter);
            this.dgvDashboard.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDashboard_DataBindingComplete);
            // 
            // pnlFilterSort
            // 
            this.pnlFilterSort.Controls.Add(this.btnCA);
            this.pnlFilterSort.Controls.Add(this.lblLegend);
            this.pnlFilterSort.Controls.Add(this.pnlNormal);
            this.pnlFilterSort.Controls.Add(this.pnlNeutral);
            this.pnlFilterSort.Controls.Add(this.pnlCaution);
            this.pnlFilterSort.Controls.Add(this.pnlCritical);
            this.pnlFilterSort.Controls.Add(this.btnFind);
            this.pnlFilterSort.Controls.Add(this.btnEPV);
            this.pnlFilterSort.Controls.Add(this.txtFind);
            this.pnlFilterSort.Controls.Add(this.btnRefreshEPV);
            this.pnlFilterSort.Controls.Add(this.lblCellFormat);
            this.pnlFilterSort.Controls.Add(this.lblNote);
            this.pnlFilterSort.Controls.Add(this.lblSearch);
            this.pnlFilterSort.Controls.Add(this.lblMode);
            this.pnlFilterSort.Controls.Add(this.lblEPV);
            this.pnlFilterSort.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterSort.Location = new System.Drawing.Point(0, 0);
            this.pnlFilterSort.Name = "pnlFilterSort";
            this.pnlFilterSort.Size = new System.Drawing.Size(1001, 50);
            this.pnlFilterSort.TabIndex = 79;
            // 
            // lblLegend
            // 
            this.lblLegend.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegend.Location = new System.Drawing.Point(576, 4);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(81, 42);
            this.lblLegend.TabIndex = 9;
            this.lblLegend.Text = "Legend\r\n(Elapse Days):";
            this.lblLegend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlNormal
            // 
            this.pnlNormal.Controls.Add(this.lblNormal);
            this.pnlNormal.Location = new System.Drawing.Point(738, 26);
            this.pnlNormal.Name = "pnlNormal";
            this.pnlNormal.Size = new System.Drawing.Size(76, 23);
            this.pnlNormal.TabIndex = 8;
            // 
            // lblNormal
            // 
            this.lblNormal.AutoSize = true;
            this.lblNormal.BackColor = System.Drawing.Color.Transparent;
            this.lblNormal.Location = new System.Drawing.Point(13, 5);
            this.lblNormal.Name = "lblNormal";
            this.lblNormal.Size = new System.Drawing.Size(47, 13);
            this.lblNormal.TabIndex = 2;
            this.lblNormal.Text = "< 8 days";
            // 
            // pnlNeutral
            // 
            this.pnlNeutral.Controls.Add(this.lblNeutral);
            this.pnlNeutral.Location = new System.Drawing.Point(738, 3);
            this.pnlNeutral.Name = "pnlNeutral";
            this.pnlNeutral.Size = new System.Drawing.Size(76, 23);
            this.pnlNeutral.TabIndex = 7;
            // 
            // lblNeutral
            // 
            this.lblNeutral.AutoSize = true;
            this.lblNeutral.BackColor = System.Drawing.Color.Transparent;
            this.lblNeutral.Location = new System.Drawing.Point(5, 5);
            this.lblNeutral.Name = "lblNeutral";
            this.lblNeutral.Size = new System.Drawing.Size(65, 13);
            this.lblNeutral.TabIndex = 1;
            this.lblNeutral.Text = "8 to 16 days";
            // 
            // pnlCaution
            // 
            this.pnlCaution.Controls.Add(this.lblCaution);
            this.pnlCaution.Location = new System.Drawing.Point(661, 26);
            this.pnlCaution.Name = "pnlCaution";
            this.pnlCaution.Size = new System.Drawing.Size(76, 23);
            this.pnlCaution.TabIndex = 6;
            // 
            // lblCaution
            // 
            this.lblCaution.AutoSize = true;
            this.lblCaution.BackColor = System.Drawing.Color.Transparent;
            this.lblCaution.Location = new System.Drawing.Point(3, 5);
            this.lblCaution.Name = "lblCaution";
            this.lblCaution.Size = new System.Drawing.Size(71, 13);
            this.lblCaution.TabIndex = 1;
            this.lblCaution.Text = "16 to 24 days";
            // 
            // pnlCritical
            // 
            this.pnlCritical.Controls.Add(this.lblCritical);
            this.pnlCritical.Location = new System.Drawing.Point(661, 3);
            this.pnlCritical.Name = "pnlCritical";
            this.pnlCritical.Size = new System.Drawing.Size(76, 23);
            this.pnlCritical.TabIndex = 4;
            // 
            // lblCritical
            // 
            this.lblCritical.AutoSize = true;
            this.lblCritical.BackColor = System.Drawing.Color.Transparent;
            this.lblCritical.Location = new System.Drawing.Point(9, 5);
            this.lblCritical.Name = "lblCritical";
            this.lblCritical.Size = new System.Drawing.Size(59, 13);
            this.lblCritical.TabIndex = 0;
            this.lblCritical.Text = ">= 24 days";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Transparent;
            this.btnFind.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Location = new System.Drawing.Point(253, 26);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(20, 20);
            this.btnFind.TabIndex = 3;
            this.btnFind.Tag = "1";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnEPV
            // 
            this.btnEPV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEPV.Location = new System.Drawing.Point(91, 2);
            this.btnEPV.Name = "btnEPV";
            this.btnEPV.Size = new System.Drawing.Size(75, 23);
            this.btnEPV.TabIndex = 3;
            this.btnEPV.Tag = "1";
            this.btnEPV.Text = "EPV";
            this.btnEPV.UseVisualStyleBackColor = true;
            this.btnEPV.Click += new System.EventHandler(this.btnEPV_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(91, 27);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(156, 20);
            this.txtFind.TabIndex = 2;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // lblCellFormat
            // 
            this.lblCellFormat.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellFormat.Location = new System.Drawing.Point(380, 5);
            this.lblCellFormat.Name = "lblCellFormat";
            this.lblCellFormat.Size = new System.Drawing.Size(64, 42);
            this.lblCellFormat.TabIndex = 0;
            this.lblCellFormat.Text = "Cell\r\nFormat:";
            this.lblCellFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNote
            // 
            this.lblNote.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(441, 4);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(125, 42);
            this.lblNote.TabIndex = 0;
            this.lblNote.Text = "Ref # (Days Elapse)\r\n Total Expense";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEPV
            // 
            this.lblEPV.AutoSize = true;
            this.lblEPV.Location = new System.Drawing.Point(17, 7);
            this.lblEPV.Name = "lblEPV";
            this.lblEPV.Size = new System.Drawing.Size(73, 13);
            this.lblEPV.TabIndex = 0;
            this.lblEPV.Text = "Select Mode :";
            // 
            // btnCA
            // 
            this.btnCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCA.Location = new System.Drawing.Point(172, 2);
            this.btnCA.Name = "btnCA";
            this.btnCA.Size = new System.Drawing.Size(75, 23);
            this.btnCA.TabIndex = 10;
            this.btnCA.Tag = "1";
            this.btnCA.Text = "CA";
            this.btnCA.UseVisualStyleBackColor = true;
            this.btnCA.Click += new System.EventHandler(this.btnCA_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(43, 30);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search :";
            // 
            // lblMode
            // 
            this.lblMode.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(289, 3);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(85, 44);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Mode";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefreshEPV
            // 
            this.btnRefreshEPV.BackgroundImage = global::MyRIS.Properties.Resources.Refresh_Icon;
            this.btnRefreshEPV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshEPV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshEPV.Location = new System.Drawing.Point(253, 3);
            this.btnRefreshEPV.Name = "btnRefreshEPV";
            this.btnRefreshEPV.Size = new System.Drawing.Size(20, 20);
            this.btnRefreshEPV.TabIndex = 1;
            this.btnRefreshEPV.UseVisualStyleBackColor = true;
            this.btnRefreshEPV.Click += new System.EventHandler(this.btnRefreshEPV_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 519);
            this.Controls.Add(this.dgvDashboard);
            this.Controls.Add(this.pnlFilterSort);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboard)).EndInit();
            this.pnlFilterSort.ResumeLayout(false);
            this.pnlFilterSort.PerformLayout();
            this.pnlNormal.ResumeLayout(false);
            this.pnlNormal.PerformLayout();
            this.pnlNeutral.ResumeLayout(false);
            this.pnlNeutral.PerformLayout();
            this.pnlCaution.ResumeLayout(false);
            this.pnlCaution.PerformLayout();
            this.pnlCritical.ResumeLayout(false);
            this.pnlCritical.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDashboard;
        private System.Windows.Forms.Panel pnlFilterSort;
        private System.Windows.Forms.Label lblEPV;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnEPV;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel pnlNormal;
        private System.Windows.Forms.Panel pnlNeutral;
        private System.Windows.Forms.Panel pnlCaution;
        private System.Windows.Forms.Panel pnlCritical;
        private System.Windows.Forms.Label lblCaution;
        private System.Windows.Forms.Label lblCritical;
        private System.Windows.Forms.Label lblNeutral;
        private System.Windows.Forms.Label lblNormal;
        private System.Windows.Forms.Label lblLegend;
        private System.Windows.Forms.Label lblCellFormat;
        private System.Windows.Forms.Button btnCA;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnRefreshEPV;
    }
}