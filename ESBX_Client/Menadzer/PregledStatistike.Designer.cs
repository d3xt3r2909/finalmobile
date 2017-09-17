namespace ESBX_Client.Menadzer
{
    partial class PregledStatistike
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GodinaLbl = new System.Windows.Forms.Label();
            this.ZaradaGrid = new System.Windows.Forms.DataGridView();
            this.RedniBroj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mjesec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojNarudzbi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UkupnaZarada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.ZaradaChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ZaradaGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZaradaChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(66, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "Pregled zarade po mjesecima";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Godina:";
            // 
            // GodinaLbl
            // 
            this.GodinaLbl.AutoSize = true;
            this.GodinaLbl.Location = new System.Drawing.Point(120, 121);
            this.GodinaLbl.Name = "GodinaLbl";
            this.GodinaLbl.Size = new System.Drawing.Size(0, 13);
            this.GodinaLbl.TabIndex = 42;
            // 
            // ZaradaGrid
            // 
            this.ZaradaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ZaradaGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RedniBroj,
            this.Mjesec,
            this.BrojNarudzbi,
            this.UkupnaZarada});
            this.ZaradaGrid.Location = new System.Drawing.Point(69, 150);
            this.ZaradaGrid.Name = "ZaradaGrid";
            this.ZaradaGrid.Size = new System.Drawing.Size(444, 343);
            this.ZaradaGrid.TabIndex = 43;
            // 
            // RedniBroj
            // 
            this.RedniBroj.DataPropertyName = "RedniBroj";
            this.RedniBroj.HeaderText = "Rd.br.";
            this.RedniBroj.Name = "RedniBroj";
            // 
            // Mjesec
            // 
            this.Mjesec.DataPropertyName = "Mjesec";
            this.Mjesec.HeaderText = "Mjesec";
            this.Mjesec.Name = "Mjesec";
            // 
            // BrojNarudzbi
            // 
            this.BrojNarudzbi.DataPropertyName = "BrojNarudzbi";
            this.BrojNarudzbi.HeaderText = "Broj narudžbi";
            this.BrojNarudzbi.Name = "BrojNarudzbi";
            // 
            // UkupnaZarada
            // 
            this.UkupnaZarada.DataPropertyName = "Zarada";
            this.UkupnaZarada.HeaderText = "Ukupna zarada (KM)";
            this.UkupnaZarada.Name = "UkupnaZarada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(556, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "Grafički prikaz zarade po mjesecima";
            // 
            // ZaradaChart
            // 
            this.ZaradaChart.BackColor = System.Drawing.Color.LightGray;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.ZaradaChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ZaradaChart.Legends.Add(legend1);
            this.ZaradaChart.Location = new System.Drawing.Point(559, 150);
            this.ZaradaChart.Name = "ZaradaChart";
            this.ZaradaChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Ukupna zarada (KM)";
            series1.XValueMember = "RedniBroj";
            series1.YValueMembers = "Zarada";
            this.ZaradaChart.Series.Add(series1);
            this.ZaradaChart.Size = new System.Drawing.Size(684, 343);
            this.ZaradaChart.TabIndex = 45;
            // 
            // PregledStatistike
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 550);
            this.Controls.Add(this.ZaradaChart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ZaradaGrid);
            this.Controls.Add(this.GodinaLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PregledStatistike";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "r";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PregledStatistike_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ZaradaGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZaradaChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GodinaLbl;
        private System.Windows.Forms.DataGridView ZaradaGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart ZaradaChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn RedniBroj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mjesec;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojNarudzbi;
        private System.Windows.Forms.DataGridViewTextBoxColumn UkupnaZarada;
    }
}