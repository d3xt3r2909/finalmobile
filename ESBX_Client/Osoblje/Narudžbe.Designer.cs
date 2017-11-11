namespace ESBX_Client.Osoblje
{
    partial class frmNarudzbe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNarudzbe));
            this.dgNarudzbe = new System.Windows.Forms.DataGridView();
            this.NarudzbaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrijemeDolaska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prikaz = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Zavrsena = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Nedolazak = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbNarudzbeStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnNarudzbePregled = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpPregledIsteka = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgPrikazSalata = new System.Windows.Forms.DataGridView();
            this.SalataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GlavniSastojak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SporedniSastojak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DresingSastojak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CijenaSalate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgNarudzbe)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpPregledIsteka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrikazSalata)).BeginInit();
            this.SuspendLayout();
            // 
            // dgNarudzbe
            // 
            this.dgNarudzbe.AllowUserToAddRows = false;
            this.dgNarudzbe.AllowUserToDeleteRows = false;
            this.dgNarudzbe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNarudzbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNarudzbe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NarudzbaId,
            this.Korisnik,
            this.VrijemeDolaska,
            this.Prikaz,
            this.Zavrsena,
            this.Nedolazak});
            this.dgNarudzbe.Location = new System.Drawing.Point(40, 140);
            this.dgNarudzbe.Name = "dgNarudzbe";
            this.dgNarudzbe.ReadOnly = true;
            this.dgNarudzbe.Size = new System.Drawing.Size(1113, 189);
            this.dgNarudzbe.TabIndex = 0;
            this.dgNarudzbe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNarudzbe_CellContentClick);
            // 
            // NarudzbaId
            // 
            this.NarudzbaId.DataPropertyName = "NarudzbaId";
            this.NarudzbaId.HeaderText = "Id";
            this.NarudzbaId.Name = "NarudzbaId";
            this.NarudzbaId.ReadOnly = true;
            this.NarudzbaId.Visible = false;
            // 
            // Korisnik
            // 
            this.Korisnik.DataPropertyName = "Korisnik";
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            // 
            // VrijemeDolaska
            // 
            this.VrijemeDolaska.DataPropertyName = "VrijemeDolaska";
            this.VrijemeDolaska.HeaderText = "Vrijeme dolaska";
            this.VrijemeDolaska.Name = "VrijemeDolaska";
            this.VrijemeDolaska.ReadOnly = true;
            // 
            // Prikaz
            // 
            this.Prikaz.HeaderText = "Prikaz salata";
            this.Prikaz.Name = "Prikaz";
            this.Prikaz.ReadOnly = true;
            this.Prikaz.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Prikaz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Prikaz.Text = "Prikaz";
            this.Prikaz.UseColumnTextForButtonValue = true;
            // 
            // Zavrsena
            // 
            this.Zavrsena.HeaderText = "Zavrsena";
            this.Zavrsena.Name = "Zavrsena";
            this.Zavrsena.ReadOnly = true;
            this.Zavrsena.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Zavrsena.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Zavrsena.Text = "Zavrsena";
            this.Zavrsena.ToolTipText = "Pritiskom na ovo dugme, podrazumjeva se da je gost dosao i preuzeo narudzbu. Potr" +
    "ebno mu je izdati racun i unjeti eventualni popust.";
            this.Zavrsena.UseColumnTextForButtonValue = true;
            // 
            // Nedolazak
            // 
            this.Nedolazak.HeaderText = "Nedolazak";
            this.Nedolazak.Name = "Nedolazak";
            this.Nedolazak.ReadOnly = true;
            this.Nedolazak.Text = "Nedolazak";
            this.Nedolazak.UseColumnTextForButtonValue = true;
            // 
            // cmbNarudzbeStatus
            // 
            this.cmbNarudzbeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNarudzbeStatus.FormattingEnabled = true;
            this.cmbNarudzbeStatus.Location = new System.Drawing.Point(156, 49);
            this.cmbNarudzbeStatus.Name = "cmbNarudzbeStatus";
            this.cmbNarudzbeStatus.Size = new System.Drawing.Size(273, 21);
            this.cmbNarudzbeStatus.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status narudžbe";
            // 
            // btnNarudzbePregled
            // 
            this.btnNarudzbePregled.Location = new System.Drawing.Point(463, 47);
            this.btnNarudzbePregled.Name = "btnNarudzbePregled";
            this.btnNarudzbePregled.Size = new System.Drawing.Size(75, 23);
            this.btnNarudzbePregled.TabIndex = 3;
            this.btnNarudzbePregled.Text = "Filtriraj";
            this.btnNarudzbePregled.UseVisualStyleBackColor = true;
            this.btnNarudzbePregled.Click += new System.EventHandler(this.Filtriraj);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpPregledIsteka);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgPrikazSalata);
            this.groupBox1.Controls.Add(this.btnNarudzbePregled);
            this.groupBox1.Controls.Add(this.dgNarudzbe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbNarudzbeStatus);
            this.groupBox1.Location = new System.Drawing.Point(38, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1191, 639);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prikaz narudžbi";
            // 
            // grpPregledIsteka
            // 
            this.grpPregledIsteka.Controls.Add(this.label6);
            this.grpPregledIsteka.Controls.Add(this.pictureBox1);
            this.grpPregledIsteka.Cursor = System.Windows.Forms.Cursors.Help;
            this.grpPregledIsteka.Location = new System.Drawing.Point(938, 33);
            this.grpPregledIsteka.Name = "grpPregledIsteka";
            this.grpPregledIsteka.Size = new System.Drawing.Size(215, 58);
            this.grpPregledIsteka.TabIndex = 60;
            this.grpPregledIsteka.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pomoć!";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Prikaz narudzbi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Prikaz salata za odabranu narudzbu";
            // 
            // dgPrikazSalata
            // 
            this.dgPrikazSalata.AllowUserToAddRows = false;
            this.dgPrikazSalata.AllowUserToDeleteRows = false;
            this.dgPrikazSalata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPrikazSalata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrikazSalata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SalataId,
            this.GlavniSastojak,
            this.SporedniSastojak,
            this.DresingSastojak,
            this.Kolicina,
            this.CijenaSalate});
            this.dgPrikazSalata.Location = new System.Drawing.Point(40, 409);
            this.dgPrikazSalata.Name = "dgPrikazSalata";
            this.dgPrikazSalata.ReadOnly = true;
            this.dgPrikazSalata.Size = new System.Drawing.Size(1113, 189);
            this.dgPrikazSalata.TabIndex = 4;
            // 
            // SalataId
            // 
            this.SalataId.DataPropertyName = "SalataId";
            this.SalataId.HeaderText = "SalataId";
            this.SalataId.Name = "SalataId";
            this.SalataId.ReadOnly = true;
            this.SalataId.Visible = false;
            // 
            // GlavniSastojak
            // 
            this.GlavniSastojak.DataPropertyName = "GlavniSastojak";
            this.GlavniSastojak.HeaderText = "Glavni sastojak";
            this.GlavniSastojak.Name = "GlavniSastojak";
            this.GlavniSastojak.ReadOnly = true;
            // 
            // SporedniSastojak
            // 
            this.SporedniSastojak.DataPropertyName = "SporedniSastojak";
            this.SporedniSastojak.HeaderText = "Sporedni sastojci";
            this.SporedniSastojak.Name = "SporedniSastojak";
            this.SporedniSastojak.ReadOnly = true;
            // 
            // DresingSastojak
            // 
            this.DresingSastojak.DataPropertyName = "DresingSastojak";
            this.DresingSastojak.HeaderText = "Dresing sastojak";
            this.DresingSastojak.Name = "DresingSastojak";
            this.DresingSastojak.ReadOnly = true;
            // 
            // Kolicina
            // 
            this.Kolicina.DataPropertyName = "Kolicina";
            this.Kolicina.HeaderText = "Kolicina";
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            // 
            // CijenaSalate
            // 
            this.CijenaSalate.DataPropertyName = "CijenaSalate";
            this.CijenaSalate.HeaderText = "Cijena salate";
            this.CijenaSalate.Name = "CijenaSalate";
            this.CijenaSalate.ReadOnly = true;
            // 
            // frmNarudzbe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 720);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmNarudzbe";
            this.Text = "Pregled narudžbi";
            this.Load += new System.EventHandler(this.frmNarudzbe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgNarudzbe)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpPregledIsteka.ResumeLayout(false);
            this.grpPregledIsteka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrikazSalata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNarudzbe;
        private System.Windows.Forms.ComboBox cmbNarudzbeStatus;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnNarudzbePregled;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgPrikazSalata;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalataId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GlavniSastojak;
        private System.Windows.Forms.DataGridViewTextBoxColumn SporedniSastojak;
        private System.Windows.Forms.DataGridViewTextBoxColumn DresingSastojak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina;
        private System.Windows.Forms.DataGridViewTextBoxColumn CijenaSalate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarudzbaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrijemeDolaska;
        private System.Windows.Forms.DataGridViewButtonColumn Prikaz;
        private System.Windows.Forms.DataGridViewButtonColumn Zavrsena;
        private System.Windows.Forms.DataGridViewButtonColumn Nedolazak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpPregledIsteka;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}