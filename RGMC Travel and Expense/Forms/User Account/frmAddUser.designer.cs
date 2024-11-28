namespace MyRIS
{
    partial class frmAddUser
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
            this.lblRequired = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPageMember = new System.Windows.Forms.TabPage();
            this.tvwMembersOf = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtPassConfirm = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabUserInfo = new System.Windows.Forms.TabControl();
            this.pnlButtons.SuspendLayout();
            this.tabPageMember.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.tabUserInfo.SuspendLayout();
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
            this.pnlButtons.Location = new System.Drawing.Point(0, 323);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(501, 42);
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
            this.btnRight.Enabled = false;
            this.btnRight.Location = new System.Drawing.Point(281, 7);
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
            this.btnCancel.Location = new System.Drawing.Point(425, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(353, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPageMember
            // 
            this.tabPageMember.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageMember.Controls.Add(this.tvwMembersOf);
            this.tabPageMember.Controls.Add(this.panel1);
            this.tabPageMember.Location = new System.Drawing.Point(4, 22);
            this.tabPageMember.Name = "tabPageMember";
            this.tabPageMember.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMember.Size = new System.Drawing.Size(493, 297);
            this.tabPageMember.TabIndex = 1;
            this.tabPageMember.Text = "Members Of";
            // 
            // tvwMembersOf
            // 
            this.tvwMembersOf.CheckBoxes = true;
            this.tvwMembersOf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwMembersOf.Location = new System.Drawing.Point(3, 40);
            this.tvwMembersOf.Name = "tvwMembersOf";
            this.tvwMembersOf.Size = new System.Drawing.Size(487, 254);
            this.tvwMembersOf.TabIndex = 21;
            this.tvwMembersOf.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.node_AfterCheck);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 37);
            this.panel1.TabIndex = 22;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(3, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(423, 18);
            this.lblInfo.TabIndex = 20;
            this.lblInfo.Text = "NOTE: THE CURRENT USER IS ASSIGNED TO THESE CHECKED GROUPS";
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageInfo.Controls.Add(this.cboDepartment);
            this.tabPageInfo.Controls.Add(this.lblDepartment);
            this.tabPageInfo.Controls.Add(this.picIcon);
            this.tabPageInfo.Controls.Add(this.lblMiddleName);
            this.tabPageInfo.Controls.Add(this.lblFirstName);
            this.tabPageInfo.Controls.Add(this.lblLastName);
            this.tabPageInfo.Controls.Add(this.lblCode);
            this.tabPageInfo.Controls.Add(this.txtPassConfirm);
            this.tabPageInfo.Controls.Add(this.txtMiddleName);
            this.tabPageInfo.Controls.Add(this.txtFirstName);
            this.tabPageInfo.Controls.Add(this.txtLastName);
            this.tabPageInfo.Controls.Add(this.txtCode);
            this.tabPageInfo.Controls.Add(this.txtPassword);
            this.tabPageInfo.Controls.Add(this.txtEmail);
            this.tabPageInfo.Controls.Add(this.txtName);
            this.tabPageInfo.Controls.Add(this.lblEmail);
            this.tabPageInfo.Controls.Add(this.label2);
            this.tabPageInfo.Controls.Add(this.lblName);
            this.tabPageInfo.Controls.Add(this.label1);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(493, 297);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "User Editor";
            // 
            // cboDepartment
            // 
            this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(109, 80);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(203, 22);
            this.cboDepartment.TabIndex = 0;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDepartment.Location = new System.Drawing.Point(9, 82);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 13);
            this.lblDepartment.TabIndex = 0;
            this.lblDepartment.Text = "Department:";
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIcon.ErrorImage = null;
            this.picIcon.InitialImage = null;
            this.picIcon.Location = new System.Drawing.Point(8, 6);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(64, 64);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picIcon.TabIndex = 17;
            this.picIcon.TabStop = false;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Location = new System.Drawing.Point(8, 189);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(72, 13);
            this.lblMiddleName.TabIndex = 4;
            this.lblMiddleName.Text = "Middle Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(8, 163);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(64, 13);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name*:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(8, 137);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(65, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name*:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(8, 111);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(71, 13);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Login Name*:";
            // 
            // txtPassConfirm
            // 
            this.txtPassConfirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassConfirm.Location = new System.Drawing.Point(109, 267);
            this.txtPassConfirm.MaxLength = 250;
            this.txtPassConfirm.Name = "txtPassConfirm";
            this.txtPassConfirm.PasswordChar = '•';
            this.txtPassConfirm.Size = new System.Drawing.Size(191, 20);
            this.txtPassConfirm.TabIndex = 7;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMiddleName.Location = new System.Drawing.Point(109, 186);
            this.txtMiddleName.MaxLength = 50;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(191, 20);
            this.txtMiddleName.TabIndex = 4;
            this.txtMiddleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtFirstName
            // 
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.Location = new System.Drawing.Point(109, 160);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(191, 20);
            this.txtFirstName.TabIndex = 3;
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtLastName
            // 
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.Location = new System.Drawing.Point(109, 134);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(191, 20);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(109, 108);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(139, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(109, 241);
            this.txtPassword.MaxLength = 250;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(191, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.Location = new System.Drawing.Point(131, 38);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(254, 20);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Location = new System.Drawing.Point(109, 214);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(276, 20);
            this.txtName.TabIndex = 5;
            this.txtName.TabStop = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(93, 41);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Confirm Password*:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 217);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Full Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Password*:";
            // 
            // tabUserInfo
            // 
            this.tabUserInfo.Controls.Add(this.tabPageInfo);
            this.tabUserInfo.Controls.Add(this.tabPageMember);
            this.tabUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUserInfo.Location = new System.Drawing.Point(0, 0);
            this.tabUserInfo.Name = "tabUserInfo";
            this.tabUserInfo.SelectedIndex = 0;
            this.tabUserInfo.Size = new System.Drawing.Size(501, 323);
            this.tabUserInfo.TabIndex = 17;
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 365);
            this.Controls.Add(this.tabUserInfo);
            this.Controls.Add(this.pnlButtons);
            this.Name = "frmAddUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info";
            this.Load += new System.EventHandler(this.frmUserAccount_Load);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.tabPageMember.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.tabUserInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.TabPage tabPageMember;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtPassConfirm;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabUserInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.TreeView tvwMembersOf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
    }
}