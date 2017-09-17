namespace ESBX_Client.Menadzer
{
    partial class IstekZaliha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IstekZaliha));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgIstekZaliha = new System.Windows.Forms.DataGridView();
            this.SastojakId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stanje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrstaSastojka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIstekZaliha)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgIstekZaliha);
            this.groupBox1.Location = new System.Drawing.Point(23, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(717, 438);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prikazani sastojci imaju stanje manje od 1000";
            // 
            // dgIstekZaliha
            // 
            this.dgIstekZaliha.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgIstekZaliha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIstekZaliha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SastojakId,
            this.Naziv,
            this.Stanje,
            this.VrstaSastojka});
            this.dgIstekZaliha.Location = new System.Drawing.Point(9, 47);
            this.dgIstekZaliha.Name = "dgIstekZaliha";
            this.dgIstekZaliha.Size = new System.Drawing.Size(702, 345);
            this.dgIstekZaliha.TabIndex = 2;
            // 
            // SastojakId
            // 
            this.SastojakId.DataPropertyName = "Id";
            this.SastojakId.HeaderText = "Id";
            this.SastojakId.Name = "SastojakId";
            this.SastojakId.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            // 
            // Stanje
            // 
            this.Stanje.DataPropertyName = "Stanje";
            this.Stanje.HeaderText = "Stanje";
            this.Stanje.Name = "Stanje";
            // 
            // VrstaSastojka
            // 
            this.VrstaSastojka.DataPropertyName = "VrstaSastojka";
            this.VrstaSastojka.HeaderText = "Vrsta sastojka";
            this.VrstaSastojka.Name = "VrstaSastojka";
            // 
            // IstekZaliha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(771, 550);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IstekZaliha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Istek zaliha";
            this.Load += new System.EventHandler(this.IstekZaliha_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgIstekZaliha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgIstekZaliha;
        private System.Windows.Forms.DataGridViewTextBoxColumn SastojakId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stanje;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrstaSastojka;
    }
}