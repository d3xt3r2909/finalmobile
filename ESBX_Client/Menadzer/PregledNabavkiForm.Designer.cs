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
            this.dataGridViewSastojciList = new System.Windows.Forms.DataGridView();
            this.SastojakId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPregledNabavke = new System.Windows.Forms.DataGridView();
            this.UlazZalihaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobavljacId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NabavkaDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Napomena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DobavljacInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FilterNabavkaDatum = new System.Windows.Forms.DateTimePicker();
            this.cmbFilterNabavkaDobavljac = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOcistiFilter = new System.Windows.Forms.Button();
            this.btnPrimjeniFilter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSastojciList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPregledNabavke)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnPrimjeniFilter);
            this.groupBox1.Controls.Add(this.btnOcistiFilter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbFilterNabavkaDobavljac);
            this.groupBox1.Controls.Add(this.FilterNabavkaDatum);
            this.groupBox1.Controls.Add(this.dataGridViewSastojciList);
            this.groupBox1.Controls.Add(this.dgPregledNabavke);
            this.groupBox1.Location = new System.Drawing.Point(67, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1191, 500);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pregled nabavki";
            // 
            // dataGridViewSastojciList
            // 
            this.dataGridViewSastojciList.AllowUserToAddRows = false;
            this.dataGridViewSastojciList.AllowUserToDeleteRows = false;
            this.dataGridViewSastojciList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSastojciList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSastojciList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SastojakId,
            this.Naziv,
            this.Kolicina,
            this.Cijena});
            this.dataGridViewSastojciList.Location = new System.Drawing.Point(652, 275);
            this.dataGridViewSastojciList.Name = "dataGridViewSastojciList";
            this.dataGridViewSastojciList.ReadOnly = true;
            this.dataGridViewSastojciList.Size = new System.Drawing.Size(501, 200);
            this.dataGridViewSastojciList.TabIndex = 1;
            // 
            // SastojakId
            // 
            this.SastojakId.DataPropertyName = "SastojakId";
            this.SastojakId.HeaderText = "SastojakId";
            this.SastojakId.Name = "SastojakId";
            this.SastojakId.ReadOnly = true;
            this.SastojakId.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Sastojak";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Kolicina
            // 
            this.Kolicina.DataPropertyName = "Kolicina";
            this.Kolicina.HeaderText = "Kolicina";
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // dgPregledNabavke
            // 
            this.dgPregledNabavke.AllowUserToAddRows = false;
            this.dgPregledNabavke.AllowUserToDeleteRows = false;
            this.dgPregledNabavke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPregledNabavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPregledNabavke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UlazZalihaId,
            this.DobavljacId,
            this.NabavkaDate,
            this.Napomena,
            this.DobavljacInfo});
            this.dgPregledNabavke.Location = new System.Drawing.Point(48, 145);
            this.dgPregledNabavke.Name = "dgPregledNabavke";
            this.dgPregledNabavke.ReadOnly = true;
            this.dgPregledNabavke.Size = new System.Drawing.Size(556, 330);
            this.dgPregledNabavke.TabIndex = 0;
            this.dgPregledNabavke.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPregledNabavke_CellContentClick);
            // 
            // UlazZalihaId
            // 
            this.UlazZalihaId.DataPropertyName = "UlazZalihaId";
            this.UlazZalihaId.HeaderText = "UlazZalihaId";
            this.UlazZalihaId.Name = "UlazZalihaId";
            this.UlazZalihaId.ReadOnly = true;
            this.UlazZalihaId.Visible = false;
            // 
            // DobavljacId
            // 
            this.DobavljacId.DataPropertyName = "DobavljacId";
            this.DobavljacId.HeaderText = "DobavljacId";
            this.DobavljacId.Name = "DobavljacId";
            this.DobavljacId.ReadOnly = true;
            this.DobavljacId.Visible = false;
            // 
            // NabavkaDate
            // 
            this.NabavkaDate.DataPropertyName = "NabavkaDate";
            this.NabavkaDate.HeaderText = "Datum narudzbe";
            this.NabavkaDate.Name = "NabavkaDate";
            this.NabavkaDate.ReadOnly = true;
            // 
            // Napomena
            // 
            this.Napomena.DataPropertyName = "Napomena";
            this.Napomena.HeaderText = "Napomena";
            this.Napomena.Name = "Napomena";
            this.Napomena.ReadOnly = true;
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
            // FilterNabavkaDatum
            // 
            this.FilterNabavkaDatum.Location = new System.Drawing.Point(172, 47);
            this.FilterNabavkaDatum.Name = "FilterNabavkaDatum";
            this.FilterNabavkaDatum.Size = new System.Drawing.Size(200, 20);
            this.FilterNabavkaDatum.TabIndex = 2;
            // 
            // cmbFilterNabavkaDobavljac
            // 
            this.cmbFilterNabavkaDobavljac.FormattingEnabled = true;
            this.cmbFilterNabavkaDobavljac.Location = new System.Drawing.Point(172, 94);
            this.cmbFilterNabavkaDobavljac.Name = "cmbFilterNabavkaDobavljac";
            this.cmbFilterNabavkaDobavljac.Size = new System.Drawing.Size(200, 21);
            this.cmbFilterNabavkaDobavljac.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Datum nabavke: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dobavljac: ";
            // 
            // btnOcistiFilter
            // 
            this.btnOcistiFilter.Location = new System.Drawing.Point(460, 47);
            this.btnOcistiFilter.Name = "btnOcistiFilter";
            this.btnOcistiFilter.Size = new System.Drawing.Size(128, 23);
            this.btnOcistiFilter.TabIndex = 6;
            this.btnOcistiFilter.Text = "Ocisti filter";
            this.btnOcistiFilter.UseVisualStyleBackColor = true;
            this.btnOcistiFilter.Click += new System.EventHandler(this.btnOcistiFilter_Click);
            // 
            // btnPrimjeniFilter
            // 
            this.btnPrimjeniFilter.Location = new System.Drawing.Point(460, 92);
            this.btnPrimjeniFilter.Name = "btnPrimjeniFilter";
            this.btnPrimjeniFilter.Size = new System.Drawing.Size(128, 23);
            this.btnPrimjeniFilter.TabIndex = 7;
            this.btnPrimjeniFilter.Text = "Primijeni filter";
            this.btnPrimjeniFilter.UseVisualStyleBackColor = true;
            this.btnPrimjeniFilter.Click += new System.EventHandler(this.btnPrimjeniFilter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(649, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Naruceni sastojci odabrane narudzbe:";
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
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSastojciList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPregledNabavke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgPregledNabavke;
        private System.Windows.Forms.DataGridView dataGridViewSastojciList;
        private System.Windows.Forms.DataGridViewTextBoxColumn SastojakId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilterNabavkaDobavljac;
        private System.Windows.Forms.DateTimePicker FilterNabavkaDatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn UlazZalihaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DobavljacId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NabavkaDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Napomena;
        private System.Windows.Forms.DataGridViewButtonColumn DobavljacInfo;
        private System.Windows.Forms.Button btnOcistiFilter;
        private System.Windows.Forms.Button btnPrimjeniFilter;
        private System.Windows.Forms.Label label3;
    }
}