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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptPregledDana
            // 
            this.rptPregledDana.LocalReport.ReportEmbeddedResource = "ESBX_Client.Reports.Report1.rdlc";
            this.rptPregledDana.Location = new System.Drawing.Point(27, 107);
            this.rptPregledDana.Name = "rptPregledDana";
            this.rptPregledDana.ServerReport.BearerToken = null;
            this.rptPregledDana.Size = new System.Drawing.Size(1113, 330);
            this.rptPregledDana.TabIndex = 0;
            // 
            // txtPregDanaSifra
            // 
            this.txtPregDanaSifra.Location = new System.Drawing.Point(27, 69);
            this.txtPregDanaSifra.Name = "txtPregDanaSifra";
            this.txtPregDanaSifra.Size = new System.Drawing.Size(213, 20);
            this.txtPregDanaSifra.TabIndex = 3;
            this.txtPregDanaSifra.TextChanged += new System.EventHandler(this.txtPregDanaSifra_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pretraga po sifri narudzbe: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rptPregledDana);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPregDanaSifra);
            this.groupBox1.Location = new System.Drawing.Point(72, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1191, 500);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pregled dana u obliku izvjestaja";
            // 
            // FormaPregledDana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 665);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormaPregledDana";
            this.Text = "FormaPregledDana";
            this.Load += new System.EventHandler(this.FormaPregledDana_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptPregledDana;
        private System.Windows.Forms.TextBox txtPregDanaSifra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}