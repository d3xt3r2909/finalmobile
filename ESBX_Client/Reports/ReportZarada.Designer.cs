namespace ESBX_Client.Reports
{
    partial class ReportZarada
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DatumOdPicker = new System.Windows.Forms.DateTimePicker();
            this.DatumDoPicker = new System.Windows.Forms.DateTimePicker();
            this.GenerisiReportBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ESBX_Client.Reports.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(96, 82);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(831, 580);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datum od:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Datum do:";
            // 
            // DatumOdPicker
            // 
            this.DatumOdPicker.Location = new System.Drawing.Point(174, 38);
            this.DatumOdPicker.Name = "DatumOdPicker";
            this.DatumOdPicker.Size = new System.Drawing.Size(190, 20);
            this.DatumOdPicker.TabIndex = 3;
            // 
            // DatumDoPicker
            // 
            this.DatumDoPicker.Location = new System.Drawing.Point(461, 38);
            this.DatumDoPicker.Name = "DatumDoPicker";
            this.DatumDoPicker.Size = new System.Drawing.Size(190, 20);
            this.DatumDoPicker.TabIndex = 4;
            // 
            // GenerisiReportBtn
            // 
            this.GenerisiReportBtn.Location = new System.Drawing.Point(704, 38);
            this.GenerisiReportBtn.Name = "GenerisiReportBtn";
            this.GenerisiReportBtn.Size = new System.Drawing.Size(91, 23);
            this.GenerisiReportBtn.TabIndex = 5;
            this.GenerisiReportBtn.Text = "Generiši report";
            this.GenerisiReportBtn.UseVisualStyleBackColor = true;
            this.GenerisiReportBtn.Click += new System.EventHandler(this.GenerisiReportBtn_Click);
            // 
            // ReportZarada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 674);
            this.Controls.Add(this.GenerisiReportBtn);
            this.Controls.Add(this.DatumDoPicker);
            this.Controls.Add(this.DatumOdPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportZarada";
            this.Text = "ReportZarada";
            this.Load += new System.EventHandler(this.ReportZarada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DatumOdPicker;
        private System.Windows.Forms.DateTimePicker DatumDoPicker;
        private System.Windows.Forms.Button GenerisiReportBtn;
    }
}