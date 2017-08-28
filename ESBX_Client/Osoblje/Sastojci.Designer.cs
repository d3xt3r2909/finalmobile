namespace ESBX_Client.Osoblje
{
    partial class frmSastojci
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgSastojci = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gramaza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojKalorija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrstaSastojka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kontrole = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtSastojciPretragaNaziv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSastojciPretraga = new System.Windows.Forms.Button();
            this.btnSastojciNovi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgSastojci)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSastojci
            // 
            this.dgSastojci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSastojci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSastojci.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Naziv,
            this.Gramaza,
            this.Cijena,
            this.BrojKalorija,
            this.VrstaSastojka,
            this.Kontrole});
            this.dgSastojci.Location = new System.Drawing.Point(124, 119);
            this.dgSastojci.Name = "dgSastojci";
            this.dgSastojci.Size = new System.Drawing.Size(631, 332);
            this.dgSastojci.TabIndex = 3;
            this.dgSastojci.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSastojci_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            // 
            // Gramaza
            // 
            this.Gramaza.DataPropertyName = "Gramaza";
            this.Gramaza.HeaderText = "Gramaza";
            this.Gramaza.Name = "Gramaza";
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            // 
            // BrojKalorija
            // 
            this.BrojKalorija.DataPropertyName = "BrojKalorija";
            this.BrojKalorija.HeaderText = "Broj kalorija";
            this.BrojKalorija.Name = "BrojKalorija";
            // 
            // VrstaSastojka
            // 
            this.VrstaSastojka.DataPropertyName = "VrstaSastojka";
            this.VrstaSastojka.HeaderText = "Vrsta sastojka";
            this.VrstaSastojka.Name = "VrstaSastojka";
            // 
            // Kontrole
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Kontrole.DefaultCellStyle = dataGridViewCellStyle1;
            this.Kontrole.HeaderText = "Kontrole";
            this.Kontrole.Name = "Kontrole";
            this.Kontrole.Text = "Izbrisi";
            this.Kontrole.UseColumnTextForButtonValue = true;
            // 
            // txtSastojciPretragaNaziv
            // 
            this.txtSastojciPretragaNaziv.Location = new System.Drawing.Point(251, 79);
            this.txtSastojciPretragaNaziv.Name = "txtSastojciPretragaNaziv";
            this.txtSastojciPretragaNaziv.Size = new System.Drawing.Size(100, 20);
            this.txtSastojciPretragaNaziv.TabIndex = 4;
            this.txtSastojciPretragaNaziv.TextChanged += new System.EventHandler(this.txtSastojciPretragaNaziv_TextChanged);
            this.txtSastojciPretragaNaziv.Enter += new System.EventHandler(this.Sastojci_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pretraga po nazivu";
            // 
            // btnSastojciPretraga
            // 
            this.btnSastojciPretraga.Location = new System.Drawing.Point(371, 79);
            this.btnSastojciPretraga.Name = "btnSastojciPretraga";
            this.btnSastojciPretraga.Size = new System.Drawing.Size(75, 23);
            this.btnSastojciPretraga.TabIndex = 6;
            this.btnSastojciPretraga.Text = "Trazi";
            this.btnSastojciPretraga.UseVisualStyleBackColor = true;
            this.btnSastojciPretraga.Click += new System.EventHandler(this.btnSastojciPretraga_Click);
            // 
            // btnSastojciNovi
            // 
            this.btnSastojciNovi.Location = new System.Drawing.Point(590, 79);
            this.btnSastojciNovi.Name = "btnSastojciNovi";
            this.btnSastojciNovi.Size = new System.Drawing.Size(157, 23);
            this.btnSastojciNovi.TabIndex = 7;
            this.btnSastojciNovi.Text = "Dodaj sastojak";
            this.btnSastojciNovi.UseVisualStyleBackColor = true;
            this.btnSastojciNovi.Click += new System.EventHandler(this.btnSastojciNovi_Click);
            // 
            // frmSastojci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 519);
            this.ControlBox = false;
            this.Controls.Add(this.btnSastojciNovi);
            this.Controls.Add(this.btnSastojciPretraga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSastojciPretragaNaziv);
            this.Controls.Add(this.dgSastojci);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSastojci";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregled sastojaka";
            this.Load += new System.EventHandler(this.Sastojci_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSastojci)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgSastojci;
        private System.Windows.Forms.TextBox txtSastojciPretragaNaziv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSastojciPretraga;
        private System.Windows.Forms.Button btnSastojciNovi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gramaza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojKalorija;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrstaSastojka;
        private System.Windows.Forms.DataGridViewButtonColumn Kontrole;
    }
}