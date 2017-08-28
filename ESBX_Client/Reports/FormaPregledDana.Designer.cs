namespace ESBX_Client.Reports
{
    partial class FormaPregledDana
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
            this.rptPregledDana = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtPregDanaSifra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rptPregledDana
            // 
            this.rptPregledDana.LocalReport.ReportEmbeddedResource = "ExpressSaladBarDesktop_Client.Reports.Report1.rdlc";
            this.rptPregledDana.Location = new System.Drawing.Point(166, 100);
            this.rptPregledDana.Name = "rptPregledDana";
            this.rptPregledDana.ServerReport.BearerToken = null;
            this.rptPregledDana.Size = new System.Drawing.Size(737, 570);
            this.rptPregledDana.TabIndex = 0;
            // 
            // txtPregDanaSifra
            // 
            this.txtPregDanaSifra.Location = new System.Drawing.Point(317, 69);
            this.txtPregDanaSifra.Name = "txtPregDanaSifra";
            this.txtPregDanaSifra.Size = new System.Drawing.Size(178, 20);
            this.txtPregDanaSifra.TabIndex = 3;
            this.txtPregDanaSifra.TextChanged += new System.EventHandler(this.txtPregDanaSifra_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pretraga po sifri narudzbe: ";
            // 
            // FormaPregledDana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 694);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPregDanaSifra);
            this.Controls.Add(this.rptPregledDana);
            this.Name = "FormaPregledDana";
            this.Text = "FormaPregledDana";
            this.Load += new System.EventHandler(this.FormaPregledDana_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptPregledDana;
        private System.Windows.Forms.TextBox txtPregDanaSifra;
        private System.Windows.Forms.Label label2;
    }
}