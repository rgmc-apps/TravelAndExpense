namespace MyRIS
{
    partial class frmUserActivity
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
            this.dgvActionHistory = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActionHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActionHistory
            // 
            this.dgvActionHistory.AllowUserToAddRows = false;
            this.dgvActionHistory.AllowUserToDeleteRows = false;
            this.dgvActionHistory.AllowUserToOrderColumns = true;
            this.dgvActionHistory.AllowUserToResizeRows = false;
            this.dgvActionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActionHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActionHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvActionHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvActionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActionHistory.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvActionHistory.Location = new System.Drawing.Point(0, 39);
            this.dgvActionHistory.Name = "dgvActionHistory";
            this.dgvActionHistory.ReadOnly = true;
            this.dgvActionHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActionHistory.Size = new System.Drawing.Size(761, 546);
            this.dgvActionHistory.TabIndex = 87;
            this.dgvActionHistory.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 88;
            this.lblName.Text = "Name";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(55, 13);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(247, 20);
            this.txtUser.TabIndex = 89;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // btnFilter
            // 
            this.btnFilter.BackgroundImage = global::MyRIS.Properties.Resources.Filter_Icon;
            this.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(308, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(24, 21);
            this.btnFilter.TabIndex = 90;
            this.btnFilter.TabStop = false;
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // frmUserActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 585);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dgvActionHistory);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserActivity";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Action History";
            this.Load += new System.EventHandler(this.frmProductDesignHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActionHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActionHistory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.Button btnFilter;
    }
}