namespace ESBX_Client.Menadzer
{
    partial class PregledNabavkiForm
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
            this.dgPregledNabavke = new System.Windows.Forms.DataGridView();
            this.SastojakId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobavljacId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SastojakNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NabavkaKolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NabavkaCijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NabavkaDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobavljacInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPregledNabavke)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgPregledNabavke);
            this.groupBox1.Location = new System.Drawing.Point(67, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1191, 500);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pregled nabavki po sastojku";
            // 
            // dgPregledNabavke
            // 
            this.dgPregledNabavke.AllowUserToAddRows = false;
            this.dgPregledNabavke.AllowUserToDeleteRows = false;
            this.dgPregledNabavke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPregledNabavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPregledNabavke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SastojakId,
            this.DobavljacId,
            this.SastojakNaziv,
            this.NabavkaKolicina,
            this.NabavkaCijena,
            this.NabavkaDate,
            this.DobavljacInfo});
            this.dgPregledNabavke.Location = new System.Drawing.Point(51, 67);
            this.dgPregledNabavke.Name = "dgPregledNabavke";
            this.dgPregledNabavke.ReadOnly = true;
            this.dgPregledNabavke.Size = new System.Drawing.Size(1113, 330);
            this.dgPregledNabavke.TabIndex = 0;
            this.dgPregledNabavke.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPregledNabavke_CellContentClick);
            // 
            // SastojakId
            // 
            this.SastojakId.DataPropertyName = "SastojakId";
            this.SastojakId.HeaderText = "SastojakId";
            this.SastojakId.Name = "SastojakId";
            this.SastojakId.ReadOnly = true;
            this.SastojakId.Visible = false;
            // 
            // DobavljacId
            // 
            this.DobavljacId.DataPropertyName = "DobavljacId";
            this.DobavljacId.HeaderText = "DobavljacId";
            this.DobavljacId.Name = "DobavljacId";
            this.DobavljacId.ReadOnly = true;
            this.DobavljacId.Visible = false;
            // 
            // SastojakNaziv
            // 
            this.SastojakNaziv.DataPropertyName = "SastojakNaziv";
            this.SastojakNaziv.HeaderText = "Sastojak";
            this.SastojakNaziv.Name = "SastojakNaziv";
            this.SastojakNaziv.ReadOnly = true;
            // 
            // NabavkaKolicina
            // 
            this.NabavkaKolicina.DataPropertyName = "NabavkaKolicina";
            this.NabavkaKolicina.HeaderText = "Nabavljena kolicina";
            this.NabavkaKolicina.Name = "NabavkaKolicina";
            this.NabavkaKolicina.ReadOnly = true;
            // 
            // NabavkaCijena
            // 
            this.NabavkaCijena.DataPropertyName = "NabavkaCijena";
            this.NabavkaCijena.HeaderText = "Cijena";
            this.NabavkaCijena.Name = "NabavkaCijena";
            this.NabavkaCijena.ReadOnly = true;
            // 
            // NabavkaDate
            // 
            this.NabavkaDate.DataPropertyName = "NabavkaDate";
            this.NabavkaDate.HeaderText = "Datum narudzbe";
            this.NabavkaDate.Name = "NabavkaDate";
            this.NabavkaDate.ReadOnly = true;
            // 
            // DobavljacInfo
            // 
            this.DobavljacInfo.HeaderText = "Dobavljaci";
            this.DobavljacInfo.Name = "DobavljacInfo";
            this.DobavljacInfo.ReadOnly = true;
            this.DobavljacInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DobavljacInfo.Text = "Info";
            this.DobavljacInfo.ToolTipText = "Pregled informacija o dobavljacima.";
            this.DobavljacInfo.UseColumnTextForButtonValue = true;
            // 
            // PregledNabavkiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 665);
            this.Controls.Add(this.groupBox1);
            this.Name = "PregledNabavkiForm";
            this.Text = "PregledNabavkiForm";
            this.Load += new System.EventHandler(this.PregledNabavkiForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPregledNabavke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgPregledNabavke;
        private System.Windows.Forms.DataGridViewTextBoxColumn SastojakId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DobavljacId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SastojakNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn NabavkaKolicina;
        private System.Windows.Forms.DataGridViewTextBoxColumn NabavkaCijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn NabavkaDate;
        private System.Windows.Forms.DataGridViewButtonColumn DobavljacInfo;
    }
}