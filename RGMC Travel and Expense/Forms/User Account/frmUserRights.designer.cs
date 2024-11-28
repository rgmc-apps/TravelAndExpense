namespace MyRIS
{
    partial class frmUserRights
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
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.dgvModules = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblModules = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.tvwSelect = new System.Windows.Forms.TreeView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tabUserInfo = new System.Windows.Forms.TabControl();
            this.cmsCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFullRights = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tabUserInfo.SuspendLayout();
            this.cmsCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageInfo.Controls.Add(this.dgvModules);
            this.tabPageInfo.Controls.Add(this.pnlButtons);
            this.tabPageInfo.Controls.Add(this.lblModules);
            this.tabPageInfo.Controls.Add(this.lblSelect);
            this.tabPageInfo.Controls.Add(this.tvwSelect);
            this.tabPageInfo.Controls.Add(this.txtName);
            this.tabPageInfo.Controls.Add(this.lblName);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(755, 339);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "User Editor";
            // 
            // dgvModules
            // 
            this.dgvModules.AllowUserToAddRows = false;
            this.dgvModules.AllowUserToDeleteRows = false;
            this.dgvModules.AllowUserToResizeColumns = false;
            this.dgvModules.AllowUserToResizeRows = false;
            this.dgvModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvModules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvModules.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModules.Location = new System.Drawing.Point(209, 46);
            this.dgvModules.MultiSelect = false;
            this.dgvModules.Name = "dgvModules";
            this.dgvModules.RowHeadersVisible = false;
            this.dgvModules.RowHeadersWidth = 30;
            this.dgvModules.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvModules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvModules.Size = new System.Drawing.Size(543, 254);
            this.dgvModules.TabIndex = 27;
            this.dgvModules.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvModules_CellPainting);
            this.dgvModules.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvModules_ColumnHeaderMouseClick);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(3, 302);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(749, 34);
            this.pnlButtons.TabIndex = 26;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(676, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(604, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 28);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblModules
            // 
            this.lblModules.AutoSize = true;
            this.lblModules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModules.Location = new System.Drawing.Point(212, 30);
            this.lblModules.Name = "lblModules";
            this.lblModules.Size = new System.Drawing.Size(406, 13);
            this.lblModules.TabIndex = 25;
            this.lblModules.Text = "Select Modules (Note: Click a Column Header to Toggle Check Boxes)";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.Location = new System.Drawing.Point(4, 30);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(97, 13);
            this.lblSelect.TabIndex = 24;
            this.lblSelect.Text = "Select Category";
            // 
            // tvwSelect
            // 
            this.tvwSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvwSelect.Location = new System.Drawing.Point(1, 45);
            this.tvwSelect.Name = "tvwSelect";
            this.tvwSelect.Size = new System.Drawing.Size(202, 255);
            this.tvwSelect.TabIndex = 22;
            this.tvwSelect.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.node_AfterCheck);
            this.tvwSelect.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSelect_AfterSelect);
            this.tvwSelect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvwSelect_MouseClick);
            // 
            // txtName
            // 
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Location = new System.Drawing.Point(54, 5);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(698, 20);
            this.txtName.TabIndex = 16;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 13);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "USER:";
            // 
            // tabUserInfo
            // 
            this.tabUserInfo.Controls.Add(this.tabPageInfo);
            this.tabUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUserInfo.Location = new System.Drawing.Point(0, 0);
            this.tabUserInfo.Name = "tabUserInfo";
            this.tabUserInfo.SelectedIndex = 0;
            this.tabUserInfo.Size = new System.Drawing.Size(763, 365);
            this.tabUserInfo.TabIndex = 17;
            // 
            // cmsCategory
            // 
            this.cmsCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFullRights,
            this.mnuRemove});
            this.cmsCategory.Name = "cmsCategory";
            this.cmsCategory.Size = new System.Drawing.Size(154, 48);
            // 
            // mnuFullRights
            // 
            this.mnuFullRights.Name = "mnuFullRights";
            this.mnuFullRights.Size = new System.Drawing.Size(153, 22);
            this.mnuFullRights.Text = "Full Rights";
            this.mnuFullRights.Click += new System.EventHandler(this.mnuFullRights_Click);
            // 
            // mnuRemove
            // 
            this.mnuRemove.Name = "mnuRemove";
            this.mnuRemove.Size = new System.Drawing.Size(153, 22);
            this.mnuRemove.Text = "Remove Rights";
            this.mnuRemove.Click += new System.EventHandler(this.mnuRemove_Click);
            // 
            // frmUserRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 365);
            this.Controls.Add(this.tabUserInfo);
            this.Name = "frmUserRights";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUserAccount_Load);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tabUserInfo.ResumeLayout(false);
            this.cmsCategory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabControl tabUserInfo;
        private System.Windows.Forms.Label lblModules;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.TreeView tvwSelect;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvModules;
        private System.Windows.Forms.ContextMenuStrip cmsCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuFullRights;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ToolStripMenuItem mnuRemove;

    }
}