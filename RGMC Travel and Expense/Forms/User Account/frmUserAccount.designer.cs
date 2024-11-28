namespace MyRIS
{
    partial class frmUserAccount
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
            this.tabUserAccount = new System.Windows.Forms.TabControl();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.tabUserAccount.SuspendLayout();
            this.tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabUserAccount
            // 
            this.tabUserAccount.Controls.Add(this.tabGroup);
            this.tabUserAccount.Controls.Add(this.tabUser);
            this.tabUserAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUserAccount.Location = new System.Drawing.Point(0, 0);
            this.tabUserAccount.Name = "tabUserAccount";
            this.tabUserAccount.SelectedIndex = 0;
            this.tabUserAccount.Size = new System.Drawing.Size(587, 319);
            this.tabUserAccount.TabIndex = 0;
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.dgvGroup);
            this.tabGroup.Controls.Add(this.pnlButtons);
            this.tabGroup.Location = new System.Drawing.Point(4, 22);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(579, 293);
            this.tabGroup.TabIndex = 0;
            this.tabGroup.Text = "Groups";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.AllowUserToOrderColumns = true;
            this.dgvGroup.AllowUserToResizeRows = false;
            this.dgvGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dgvGroup.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroup.Location = new System.Drawing.Point(3, 3);
            this.dgvGroup.MultiSelect = false;
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.RowHeadersVisible = false;
            this.dgvGroup.RowHeadersWidth = 30;
            this.dgvGroup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroup.Size = new System.Drawing.Size(573, 245);
            this.dgvGroup.TabIndex = 18;
            this.dgvGroup.DoubleClick += new System.EventHandler(this.dgvGroup_DoubleClick);
            this.dgvGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvGroup_KeyDown);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnRemoveGroup);
            this.pnlButtons.Controls.Add(this.btnAddGroup);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(3, 248);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(573, 42);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveGroup.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveGroup.Location = new System.Drawing.Point(353, 7);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(66, 28);
            this.btnRemoveGroup.TabIndex = 1;
            this.btnRemoveGroup.Text = "&Remove";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Visible = false;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGroup.Location = new System.Drawing.Point(500, 7);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(66, 28);
            this.btnAddGroup.TabIndex = 0;
            this.btnAddGroup.Text = "&Add";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.dgvUser);
            this.tabUser.Controls.Add(this.panel1);
            this.tabUser.Location = new System.Drawing.Point(4, 22);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(579, 293);
            this.tabUser.TabIndex = 1;
            this.tabUser.Text = "Users";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToResizeRows = false;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(3, 3);
            this.dgvUser.MultiSelect = false;
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowHeadersWidth = 30;
            this.dgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUser.Size = new System.Drawing.Size(573, 245);
            this.dgvUser.TabIndex = 18;
            this.dgvUser.DoubleClick += new System.EventHandler(this.dgvUser_DoubleClick);
            this.dgvUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUser_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnRemoveUser);
            this.panel1.Controls.Add(this.btnAddUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 42);
            this.panel1.TabIndex = 4;
            // 
            // txtUser
            // 
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUser.Location = new System.Drawing.Point(36, 9);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(211, 20);
            this.txtUser.TabIndex = 3;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(253, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveUser.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveUser.Location = new System.Drawing.Point(396, 7);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(66, 28);
            this.btnRemoveUser.TabIndex = 1;
            this.btnRemoveUser.Text = "&Remove";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Visible = false;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.Location = new System.Drawing.Point(500, 7);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(66, 28);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "&Add";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // frmUserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 319);
            this.Controls.Add(this.tabUserAccount);
            this.Name = "frmUserAccount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Account";
            this.Load += new System.EventHandler(this.frmUserAccount_Load);
            this.tabUserAccount.ResumeLayout(false);
            this.tabGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUserAccount;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtUser;
    }
}