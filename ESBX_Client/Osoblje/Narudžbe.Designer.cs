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
            this.dgNarudzbe = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GlavniSastojak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SporedniSastojak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DresingSastojak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrijemeDolaska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zavrsena = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Nedolazak = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbNarudzbeStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnNarudzbePregled = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgNarudzbe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgNarudzbe
            // 
            this.dgNarudzbe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNarudzbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNarudzbe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Korisnik,
            this.GlavniSastojak,
            this.SporedniSastojak,
            this.DresingSastojak,
            this.VrijemeDolaska,
            this.Zavrsena,
            this.Nedolazak});
            this.dgNarudzbe.Location = new System.Drawing.Point(126, 107);
            this.dgNarudzbe.Name = "dgNarudzbe";
            this.dgNarudzbe.Size = new System.Drawing.Size(927, 496);
            this.dgNarudzbe.TabIndex = 0;
            this.dgNarudzbe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNarudzbe_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Korisnik
            // 
            this.Korisnik.DataPropertyName = "Korisnik";
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.Name = "Korisnik";
            // 
            // GlavniSastojak
            // 
            this.GlavniSastojak.DataPropertyName = "GlavniSastojak";
            this.GlavniSastojak.HeaderText = "Glavni sastojak";
            this.GlavniSastojak.Name = "GlavniSastojak";
            // 
            // SporedniSastojak
            // 
            this.SporedniSastojak.DataPropertyName = "SporedniSastojak";
            this.SporedniSastojak.HeaderText = "Sporedni sastojci";
            this.SporedniSastojak.Name = "SporedniSastojak";
            // 
            // DresingSastojak
            // 
            this.DresingSastojak.DataPropertyName = "DresingSastojak";
            this.DresingSastojak.HeaderText = "Dresing";
            this.DresingSastojak.Name = "DresingSastojak";
            // 
            // VrijemeDolaska
            // 
            this.VrijemeDolaska.DataPropertyName = "VrijemeDolaska";
            this.VrijemeDolaska.HeaderText = "Vrijeme dolaska";
            this.VrijemeDolaska.Name = "VrijemeDolaska";
            // 
            // Zavrsena
            // 
            this.Zavrsena.HeaderText = "Zavrsena";
            this.Zavrsena.Name = "Zavrsena";
            this.Zavrsena.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Zavrsena.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Zavrsena.Text = "Zavrsena";
            this.Zavrsena.UseColumnTextForButtonValue = true;
            // 
            // Nedolazak
            // 
            this.Nedolazak.HeaderText = "Nedolazak";
            this.Nedolazak.Name = "Nedolazak";
            this.Nedolazak.Text = "Nedolazak";
            this.Nedolazak.UseColumnTextForButtonValue = true;
            // 
            // cmbNarudzbeStatus
            // 
            this.cmbNarudzbeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNarudzbeStatus.FormattingEnabled = true;
            this.cmbNarudzbeStatus.Location = new System.Drawing.Point(230, 69);
            this.cmbNarudzbeStatus.Name = "cmbNarudzbeStatus";
            this.cmbNarudzbeStatus.Size = new System.Drawing.Size(273, 21);
            this.cmbNarudzbeStatus.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status narudžbe";
            // 
            // btnNarudzbePregled
            // 
            this.btnNarudzbePregled.Location = new System.Drawing.Point(523, 67);
            this.btnNarudzbePregled.Name = "btnNarudzbePregled";
            this.btnNarudzbePregled.Size = new System.Drawing.Size(75, 23);
            this.btnNarudzbePregled.TabIndex = 3;
            this.btnNarudzbePregled.Text = "Filtriraj";
            this.btnNarudzbePregled.UseVisualStyleBackColor = true;
            this.btnNarudzbePregled.Click += new System.EventHandler(this.Filtriraj);
            // 
            // frmNarudzbe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 599);
            this.Controls.Add(this.btnNarudzbePregled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNarudzbeStatus);
            this.Controls.Add(this.dgNarudzbe);
            this.Name = "frmNarudzbe";
            this.Text = "Pregled narudžbi";
            this.Load += new System.EventHandler(this.frmNarudzbe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgNarudzbe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNarudzbe;
        private System.Windows.Forms.ComboBox cmbNarudzbeStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn GlavniSastojak;
        private System.Windows.Forms.DataGridViewTextBoxColumn SporedniSastojak;
        private System.Windows.Forms.DataGridViewTextBoxColumn DresingSastojak;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrijemeDolaska;
        private System.Windows.Forms.DataGridViewButtonColumn Zavrsena;
        private System.Windows.Forms.DataGridViewButtonColumn Nedolazak;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnNarudzbePregled;
    }
}