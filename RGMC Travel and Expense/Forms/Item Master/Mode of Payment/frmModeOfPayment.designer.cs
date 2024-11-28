namespace MyRIS
{
    partial class frmModeOfPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModeOfPayment));
            this.ttip = new System.Windows.Forms.ToolTip(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.dgrid = new System.Windows.Forms.DataGridView();
            this.pnlGroup = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlRGMC = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid)).BeginInit();
            this.pnlGroup.SuspendLayout();
            this.pnlRGMC.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.BackgroundImage = global::MyRIS.Properties.Resources.ADD_ICON48;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(10, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(46, 43);
            this.btnNew.TabIndex = 36;
            this.btnNew.TabStop = false;
            this.btnNew.Tag = "";
            this.ttip.SetToolTip(this.btnNew, "Add Nature of Expense");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgrid
            // 
            this.dgrid.AllowUserToAddRows = false;
            this.dgrid.AllowUserToDeleteRows = false;
            this.dgrid.AllowUserToResizeRows = false;
            this.dgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid.Location = new System.Drawing.Point(0, 105);
            this.dgrid.MultiSelect = false;
            this.dgrid.Name = "dgrid";
            this.dgrid.ReadOnly = true;
            this.dgrid.RowHeadersVisible = false;
            this.dgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid.Size = new System.Drawing.Size(922, 257);
            this.dgrid.TabIndex = 22;
            this.dgrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_CellDoubleClick);
            this.dgrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgrid_KeyDown);
            this.dgrid.MouseLeave += new System.EventHandler(this.dgrid_MouseLeave);
            this.dgrid.MouseHover += new System.EventHandler(this.dgrid_MouseHover);
            // 
            // pnlGroup
            // 
            this.pnlGroup.BackColor = System.Drawing.Color.White;
            this.pnlGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGroup.Controls.Add(this.btnNew);
            this.pnlGroup.Controls.Add(this.btnExcel);
            this.pnlGroup.Controls.Add(this.lblCount);
            this.pnlGroup.Controls.Add(this.lblRecordCount);
            this.pnlGroup.Controls.Add(this.btnSearch);
            this.pnlGroup.Controls.Add(this.txtSearch);
            this.pnlGroup.Controls.Add(this.lblSearch);
            this.pnlGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroup.Location = new System.Drawing.Point(0, 37);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.Size = new System.Drawing.Size(922, 68);
            this.pnlGroup.TabIndex = 46;
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::MyRIS.Properties.Resources.Excel_Icon;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(386, 11);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(46, 43);
            this.btnExcel.TabIndex = 36;
            this.btnExcel.TabStop = false;
            this.btnExcel.Tag = "";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(167, 45);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 14);
            this.lblCount.TabIndex = 28;
            this.lblCount.Text = "#";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(76, 45);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(85, 14);
            this.lblRecordCount.TabIndex = 28;
            this.lblRecordCount.Text = "Record Count:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::MyRIS.Properties.Resources.Filter_Icon;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(342, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 24);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.TabStop = false;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(73, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(263, 21);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(70, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(128, 14);
            this.lblSearch.TabIndex = 25;
            this.lblSearch.Text = "Filter by [Code, Name]";
            // 
            // pnlRGMC
            // 
            this.pnlRGMC.BackColor = System.Drawing.Color.Firebrick;
            this.pnlRGMC.Controls.Add(this.lblHeader);
            this.pnlRGMC.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRGMC.Location = new System.Drawing.Point(0, 0);
            this.pnlRGMC.Name = "pnlRGMC";
            this.pnlRGMC.Size = new System.Drawing.Size(922, 37);
            this.pnlRGMC.TabIndex = 47;
            this.pnlRGMC.Tag = "";
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
            this.lblHeader.Text = "Mode of Payment";
            // 
            // frmModeOfPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 362);
            this.Controls.Add(this.dgrid);
            this.Controls.Add(this.pnlGroup);
            this.Controls.Add(this.pnlRGMC);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "frmModeOfPayment";
            this.Text = "Mode of Payment";
            this.Load += new System.EventHandler(this.frmModeOfPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid)).EndInit();
            this.pnlGroup.ResumeLayout(false);
            this.pnlGroup.PerformLayout();
            this.pnlRGMC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttip;
        private System.Windows.Forms.DataGridView dgrid;
        private System.Windows.Forms.Panel pnlGroup;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblRecordCount;
        public System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlRGMC;
        private System.Windows.Forms.Label lblHeader;
    }
}