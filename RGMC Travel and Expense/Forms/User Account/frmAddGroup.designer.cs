namespace MyRIS
{
    partial class frmAddGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddGroup));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.lblRequired = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtGroupHead = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tabGeneralInfo = new System.Windows.Forms.TabControl();
            this.tabPageMember = new System.Windows.Forms.TabPage();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.secCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlButtons.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.tabGeneralInfo.SuspendLayout();
            this.tabPageMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.lblRequired);
            this.pnlButtons.Controls.Add(this.btnRight);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 379);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(632, 42);
            this.pnlButtons.TabIndex = 2;
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.Location = new System.Drawing.Point(10, 12);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(78, 16);
            this.lblRequired.TabIndex = 10;
            this.lblRequired.Text = "* Required";
            // 
            // btnRight
            // 
            this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRight.Location = new System.Drawing.Point(412, 7);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(66, 28);
            this.btnRight.TabIndex = 0;
            this.btnRight.Text = "&Rights";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(556, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(484, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageInfo.Controls.Add(this.btnSearchUser);
            this.tabPageInfo.Controls.Add(this.picIcon);
            this.tabPageInfo.Controls.Add(this.lblCode);
            this.tabPageInfo.Controls.Add(this.txtCode);
            this.tabPageInfo.Controls.Add(this.txtGroupHead);
            this.tabPageInfo.Controls.Add(this.label1);
            this.tabPageInfo.Controls.Add(this.txtName);
            this.tabPageInfo.Controls.Add(this.lblName);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(624, 353);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "General";
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearchUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUser.Location = new System.Drawing.Point(356, 197);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(23, 20);
            this.btnSearchUser.TabIndex = 154;
            this.btnSearchUser.TabStop = false;
            this.btnSearchUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIcon.ErrorImage = null;
            this.picIcon.InitialImage = null;
            this.picIcon.Location = new System.Drawing.Point(11, 13);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(63, 60);
            this.picIcon.TabIndex = 17;
            this.picIcon.TabStop = false;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(8, 95);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(71, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Group Code*:";
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(109, 92);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(139, 20);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // txtGroupHead
            // 
            this.txtGroupHead.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroupHead.Location = new System.Drawing.Point(109, 197);
            this.txtGroupHead.MaxLength = 100;
            this.txtGroupHead.Name = "txtGroupHead";
            this.txtGroupHead.ReadOnly = true;
            this.txtGroupHead.Size = new System.Drawing.Size(241, 20);
            this.txtGroupHead.TabIndex = 1;
            this.txtGroupHead.Tag = "-1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group Head*:";
            // 
            // txtName
            // 
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Location = new System.Drawing.Point(109, 119);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(373, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 122);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Group Name*:";
            // 
            // tabGeneralInfo
            // 
            this.tabGeneralInfo.Controls.Add(this.tabPageInfo);
            this.tabGeneralInfo.Controls.Add(this.tabPageMember);
            this.tabGeneralInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneralInfo.Location = new System.Drawing.Point(0, 0);
            this.tabGeneralInfo.Name = "tabGeneralInfo";
            this.tabGeneralInfo.SelectedIndex = 0;
            this.tabGeneralInfo.Size = new System.Drawing.Size(632, 379);
            this.tabGeneralInfo.TabIndex = 0;
            // 
            // tabPageMember
            // 
            this.tabPageMember.Controls.Add(this.btnRemove);
            this.tabPageMember.Controls.Add(this.btnAdd);
            this.tabPageMember.Controls.Add(this.dgvMembers);
            this.tabPageMember.Controls.Add(this.dgvUsers);
            this.tabPageMember.Controls.Add(this.panel1);
            this.tabPageMember.Location = new System.Drawing.Point(4, 22);
            this.tabPageMember.Name = "tabPageMember";
            this.tabPageMember.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMember.Size = new System.Drawing.Size(624, 353);
            this.tabPageMember.TabIndex = 2;
            this.tabPageMember.Text = "Members";
            this.tabPageMember.UseVisualStyleBackColor = true;
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.AllowUserToResizeColumns = false;
            this.dgvMembers.AllowUserToResizeRows = false;
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.secCode,
            this.secName});
            this.dgvMembers.Location = new System.Drawing.Point(339, 37);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.Size = new System.Drawing.Size(282, 316);
            this.dgvMembers.TabIndex = 25;
            this.dgvMembers.DoubleClick += new System.EventHandler(this.dgvMembers_DoubleClick);
            this.dgvMembers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMembers_KeyDown);
            // 
            // secCode
            // 
            this.secCode.HeaderText = "secCode";
            this.secCode.Name = "secCode";
            this.secCode.ReadOnly = true;
            this.secCode.Visible = false;
            // 
            // secName
            // 
            this.secName.HeaderText = "Name";
            this.secName.Name = "secName";
            this.secName.ReadOnly = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(0, 37);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 25;
            this.dgvUsers.Size = new System.Drawing.Size(282, 316);
            this.dgvUsers.TabIndex = 24;
            this.dgvUsers.DoubleClick += new System.EventHandler(this.dgvUsers_DoubleClick);
            this.dgvUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUsers_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.txtMember);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 37);
            this.panel1.TabIndex = 23;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(9, 11);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(48, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Member:";
            // 
            // txtMember
            // 
            this.txtMember.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMember.Location = new System.Drawing.Point(57, 8);
            this.txtMember.MaxLength = 50;
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(192, 20);
            this.txtMember.TabIndex = 2;
            this.txtMember.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMember_KeyDown);
            // 
            // btnRemove
            // 
            this.btnRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemove.BackgroundImage")));
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.Location = new System.Drawing.Point(289, 195);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(40, 40);
            this.btnRemove.TabIndex = 27;
            this.toolTip.SetToolTip(this.btnRemove, "Remove");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Location = new System.Drawing.Point(289, 141);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.TabIndex = 26;
            this.toolTip.SetToolTip(this.btnAdd, "Add");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::MyRIS.Properties.Resources.Search_Icon;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(255, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(24, 21);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.TabStop = false;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 421);
            this.Controls.Add(this.tabGeneralInfo);
            this.Controls.Add(this.pnlButtons);
            this.Name = "frmAddGroup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group Info";
            this.Load += new System.EventHandler(this.frmUserAccount_Load);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.tabGeneralInfo.ResumeLayout(false);
            this.tabPageMember.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabControl tabGeneralInfo;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.TabPage tabPageMember;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtMember;
        public System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn secCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn secName;
        private System.Windows.Forms.TextBox txtGroupHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchUser;
    }
}