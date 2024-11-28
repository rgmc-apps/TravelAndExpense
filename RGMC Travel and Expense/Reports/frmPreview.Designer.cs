namespace MyRIS
{
    partial class frmPreview
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.rpvPreview = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.BackgroundImage = global::MyRIS.Properties.Resources.Print_Icon;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(159, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(25, 25);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rpvPreview
            // 
            this.rpvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvPreview.Location = new System.Drawing.Point(0, 0);
            this.rpvPreview.Name = "rpvPreview";
            this.rpvPreview.ServerReport.BearerToken = null;
            this.rpvPreview.ShowContextMenu = false;
            this.rpvPreview.ShowCredentialPrompts = false;
            this.rpvPreview.ShowDocumentMapButton = false;
            this.rpvPreview.ShowExportButton = false;
            this.rpvPreview.ShowParameterPrompts = false;
            this.rpvPreview.ShowPrintButton = false;
            this.rpvPreview.ShowProgress = false;
            this.rpvPreview.ShowPromptAreaButton = false;
            this.rpvPreview.ShowRefreshButton = false;
            this.rpvPreview.ShowStopButton = false;
            this.rpvPreview.Size = new System.Drawing.Size(780, 498);
            this.rpvPreview.TabIndex = 2;
            // 
            // frmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 498);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rpvPreview);
            this.Name = "frmPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        public Microsoft.Reporting.WinForms.ReportViewer rpvPreview;
    }
}