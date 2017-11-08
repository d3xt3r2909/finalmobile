namespace ESBX_Client.Reports
{
    partial class frmIzdavanjeRacuna
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
            this.KorpaForDgRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptIzdavanjeRacunaView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KorpaForDgRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // KorpaForDgRowBindingSource
            // 
            this.KorpaForDgRowBindingSource.DataSource = typeof(ESBX_db.ViewModel.KorpaForDgRow);
            // 
            // rptIzdavanjeRacunaView
            // 
            this.rptIzdavanjeRacunaView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rptIzdavanjeRacunaView.LocalReport.ReportEmbeddedResource = "ESBX_Client.Reports.IzdavanjeRacunaRdlc.rdlc";
            this.rptIzdavanjeRacunaView.Location = new System.Drawing.Point(0, 40);
            this.rptIzdavanjeRacunaView.Name = "rptIzdavanjeRacunaView";
            this.rptIzdavanjeRacunaView.ServerReport.BearerToken = null;
            this.rptIzdavanjeRacunaView.ShowBackButton = false;
            this.rptIzdavanjeRacunaView.ShowContextMenu = false;
            this.rptIzdavanjeRacunaView.ShowCredentialPrompts = false;
            this.rptIzdavanjeRacunaView.ShowDocumentMapButton = false;
            this.rptIzdavanjeRacunaView.ShowExportButton = false;
            this.rptIzdavanjeRacunaView.ShowFindControls = false;
            this.rptIzdavanjeRacunaView.ShowPageNavigationControls = false;
            this.rptIzdavanjeRacunaView.ShowParameterPrompts = false;
            this.rptIzdavanjeRacunaView.ShowPrintButton = false;
            this.rptIzdavanjeRacunaView.ShowProgress = false;
            this.rptIzdavanjeRacunaView.ShowPromptAreaButton = false;
            this.rptIzdavanjeRacunaView.ShowRefreshButton = false;
            this.rptIzdavanjeRacunaView.ShowStopButton = false;
            this.rptIzdavanjeRacunaView.ShowToolBar = false;
            this.rptIzdavanjeRacunaView.ShowZoomControl = false;
            this.rptIzdavanjeRacunaView.Size = new System.Drawing.Size(1175, 421);
            this.rptIzdavanjeRacunaView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Napomena: Printani izvjestaj je takodjer poslat na email adresu korisnika.";
            // 
            // frmIzdavanjeRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rptIzdavanjeRacunaView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmIzdavanjeRacuna";
            this.Text = "FormaIzdavanjeRacuna";
            this.Load += new System.EventHandler(this.FormaIzdavanjeRacuna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KorpaForDgRowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptIzdavanjeRacunaView;
        private System.Windows.Forms.BindingSource KorpaForDgRowBindingSource;
        private System.Windows.Forms.Label label1;
    }
}