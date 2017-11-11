namespace ESBX_Client.Osoblje
{
    partial class frmUnosSastojka
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnosSastojka));
            this.cmbAddSasVrsta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddSasNaziv = new System.Windows.Forms.TextBox();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.txtAddSasCijena = new System.Windows.Forms.TextBox();
            this.lblCijena = new System.Windows.Forms.Label();
            this.txtAddSasKalorije = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddSasNapomena = new System.Windows.Forms.TextBox();
            this.btnAddSasSacuvaj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAddSasGramaza = new System.Windows.Forms.TextBox();
            this.btnName = new System.Windows.Forms.Button();
            this.txtInputImage = new System.Windows.Forms.TextBox();
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAddSasVrsta
            // 
            this.cmbAddSasVrsta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddSasVrsta.FormattingEnabled = true;
            this.cmbAddSasVrsta.Location = new System.Drawing.Point(57, 92);
            this.cmbAddSasVrsta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbAddSasVrsta.Name = "cmbAddSasVrsta";
            this.cmbAddSasVrsta.Size = new System.Drawing.Size(500, 24);
            this.cmbAddSasVrsta.TabIndex = 0;
            this.cmbAddSasVrsta.Validating += new System.ComponentModel.CancelEventHandler(this.cmbAddSasVrsta_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vrsta sastojka";
            // 
            // txtAddSasNaziv
            // 
            this.txtAddSasNaziv.Location = new System.Drawing.Point(277, 137);
            this.txtAddSasNaziv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddSasNaziv.Name = "txtAddSasNaziv";
            this.txtAddSasNaziv.Size = new System.Drawing.Size(280, 22);
            this.txtAddSasNaziv.TabIndex = 2;
            this.txtAddSasNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddSasNaziv_Validating);
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(53, 140);
            this.lblNaziv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(99, 17);
            this.lblNaziv.TabIndex = 3;
            this.lblNaziv.Text = "Naziv sastojka";
            // 
            // txtAddSasCijena
            // 
            this.txtAddSasCijena.Location = new System.Drawing.Point(277, 183);
            this.txtAddSasCijena.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddSasCijena.Name = "txtAddSasCijena";
            this.txtAddSasCijena.Size = new System.Drawing.Size(280, 22);
            this.txtAddSasCijena.TabIndex = 4;
            this.txtAddSasCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddSasCijena_Validating);
            // 
            // lblCijena
            // 
            this.lblCijena.AutoSize = true;
            this.lblCijena.Location = new System.Drawing.Point(53, 187);
            this.lblCijena.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(103, 17);
            this.lblCijena.TabIndex = 5;
            this.lblCijena.Text = "Cijena sastojka";
            // 
            // txtAddSasKalorije
            // 
            this.txtAddSasKalorije.Location = new System.Drawing.Point(277, 235);
            this.txtAddSasKalorije.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddSasKalorije.Name = "txtAddSasKalorije";
            this.txtAddSasKalorije.Size = new System.Drawing.Size(280, 22);
            this.txtAddSasKalorije.TabIndex = 6;
            this.txtAddSasKalorije.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddSasKalorije_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 239);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kalorije sastojka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 292);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gramaza";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 348);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Napomena";
            // 
            // txtAddSasNapomena
            // 
            this.txtAddSasNapomena.Location = new System.Drawing.Point(277, 345);
            this.txtAddSasNapomena.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddSasNapomena.Multiline = true;
            this.txtAddSasNapomena.Name = "txtAddSasNapomena";
            this.txtAddSasNapomena.Size = new System.Drawing.Size(280, 116);
            this.txtAddSasNapomena.TabIndex = 10;
            // 
            // btnAddSasSacuvaj
            // 
            this.btnAddSasSacuvaj.Location = new System.Drawing.Point(695, 485);
            this.btnAddSasSacuvaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddSasSacuvaj.Name = "btnAddSasSacuvaj";
            this.btnAddSasSacuvaj.Size = new System.Drawing.Size(207, 28);
            this.btnAddSasSacuvaj.TabIndex = 12;
            this.btnAddSasSacuvaj.Text = "Sačuvaj";
            this.btnAddSasSacuvaj.UseVisualStyleBackColor = true;
            this.btnAddSasSacuvaj.Click += new System.EventHandler(this.btnAddSasSacuvaj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAddSasGramaza);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnName);
            this.groupBox1.Controls.Add(this.txtAddSasNapomena);
            this.groupBox1.Controls.Add(this.txtInputImage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.imgBox);
            this.groupBox1.Controls.Add(this.btnAddSasSacuvaj);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbAddSasVrsta);
            this.groupBox1.Controls.Add(this.txtAddSasKalorije);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCijena);
            this.groupBox1.Controls.Add(this.txtAddSasNaziv);
            this.groupBox1.Controls.Add(this.txtAddSasCijena);
            this.groupBox1.Controls.Add(this.lblNaziv);
            this.groupBox1.Location = new System.Drawing.Point(31, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(956, 539);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unos novog sastojka";
            // 
            // txtAddSasGramaza
            // 
            this.txtAddSasGramaza.Location = new System.Drawing.Point(277, 292);
            this.txtAddSasGramaza.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddSasGramaza.Name = "txtAddSasGramaza";
            this.txtAddSasGramaza.Size = new System.Drawing.Size(280, 22);
            this.txtAddSasGramaza.TabIndex = 16;
            this.txtAddSasGramaza.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddSasGramaza_Validating);
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(695, 314);
            this.btnName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(207, 28);
            this.btnName.TabIndex = 15;
            this.btnName.Text = "Dodaj sliku";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // txtInputImage
            // 
            this.txtInputImage.Location = new System.Drawing.Point(695, 282);
            this.txtInputImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInputImage.Name = "txtInputImage";
            this.txtInputImage.ReadOnly = true;
            this.txtInputImage.Size = new System.Drawing.Size(205, 22);
            this.txtInputImage.TabIndex = 14;
            // 
            // imgBox
            // 
            this.imgBox.BackColor = System.Drawing.SystemColors.Info;
            this.imgBox.Location = new System.Drawing.Point(695, 92);
            this.imgBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(155, 132);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgBox.TabIndex = 13;
            this.imgBox.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // frmUnosSastojka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 677);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUnosSastojka";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unos novog sastojka";
            this.Load += new System.EventHandler(this.AddSastojak_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAddSasVrsta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddSasNaziv;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.TextBox txtAddSasCijena;
        private System.Windows.Forms.Label lblCijena;
        private System.Windows.Forms.TextBox txtAddSasKalorije;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddSasNapomena;
        private System.Windows.Forms.Button btnAddSasSacuvaj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.TextBox txtInputImage;
        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txtAddSasGramaza;
    }
}