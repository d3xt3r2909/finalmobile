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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GenerisiReportBtn = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DatumDoPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DatumOdPicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GenerisiReportBtn);
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Controls.Add(this.DatumDoPicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DatumOdPicker);
            this.groupBox1.Location = new System.Drawing.Point(38, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1191, 500);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prikaz zarade";
            // 
            // GenerisiReportBtn
            // 
            this.GenerisiReportBtn.Location = new System.Drawing.Point(1008, 69);
            this.GenerisiReportBtn.Name = "GenerisiReportBtn";
            this.GenerisiReportBtn.Size = new System.Drawing.Size(132, 20);
            this.GenerisiReportBtn.TabIndex = 11;
            this.GenerisiReportBtn.Text = "Generiši report";
            this.GenerisiReportBtn.UseVisualStyleBackColor = true;
            this.GenerisiReportBtn.Click += new System.EventHandler(this.GenerisiReportBtn_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ESBX_Client.Reports.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(27, 107);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1113, 330);
            this.reportViewer1.TabIndex = 6;
            // 
            // DatumDoPicker
            // 
            this.DatumDoPicker.Location = new System.Drawing.Point(278, 69);
            this.DatumDoPicker.Name = "DatumDoPicker";
            this.DatumDoPicker.Size = new System.Drawing.Size(213, 20);
            this.DatumDoPicker.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Datum od:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Datum do:";
            // 
            // DatumOdPicker
            // 
            this.DatumOdPicker.Location = new System.Drawing.Point(27, 69);
            this.DatumOdPicker.Name = "DatumOdPicker";
            this.DatumOdPicker.Size = new System.Drawing.Size(213, 20);
            this.DatumOdPicker.TabIndex = 9;
            // 
            // ReportZarada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 665);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportZarada";
            this.Text = "ReportZarada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GenerisiReportBtn;
        private System.Windows.Forms.DateTimePicker DatumDoPicker;
        private System.Windows.Forms.DateTimePicker DatumOdPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}