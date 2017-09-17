namespace ESBX_Client.Menadzer
{
    partial class NagradnaIgraForm
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPokreniIgru = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PopustTxt = new System.Windows.Forms.MaskedTextBox();
            this.DatumPicker = new System.Windows.Forms.DateTimePicker();
            this.napomenaTxt = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UkupnoLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ObavijestiBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KorisnikLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TelefonLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPokreniIgru);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(38, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1191, 529);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nagradna igra ";
            // 
            // btnPokreniIgru
            // 
            this.btnPokreniIgru.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPokreniIgru.Location = new System.Drawing.Point(426, 89);
            this.btnPokreniIgru.Name = "btnPokreniIgru";
            this.btnPokreniIgru.Size = new System.Drawing.Size(365, 31);
            this.btnPokreniIgru.TabIndex = 64;
            this.btnPokreniIgru.Text = "Pokreni igru";
            this.btnPokreniIgru.UseVisualStyleBackColor = true;
            this.btnPokreniIgru.Click += new System.EventHandler(this.btnPokreniIgru_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.PopustTxt);
            this.groupBox2.Controls.Add(this.DatumPicker);
            this.groupBox2.Controls.Add(this.napomenaTxt);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.UkupnoLbl);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ObavijestiBtn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.KorisnikLbl);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TelefonLbl);
            this.groupBox2.Location = new System.Drawing.Point(426, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 364);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Novi dobitnik";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 0;
            // 
            // PopustTxt
            // 
            this.PopustTxt.Location = new System.Drawing.Point(139, 139);
            this.PopustTxt.Mask = "000";
            this.PopustTxt.Name = "PopustTxt";
            this.PopustTxt.Size = new System.Drawing.Size(23, 20);
            this.PopustTxt.TabIndex = 55;
            this.PopustTxt.ValidatingType = typeof(int);
            // 
            // DatumPicker
            // 
            this.DatumPicker.Location = new System.Drawing.Point(139, 182);
            this.DatumPicker.Name = "DatumPicker";
            this.DatumPicker.Size = new System.Drawing.Size(200, 20);
            this.DatumPicker.TabIndex = 54;
            // 
            // napomenaTxt
            // 
            this.napomenaTxt.Location = new System.Drawing.Point(139, 224);
            this.napomenaTxt.Name = "napomenaTxt";
            this.napomenaTxt.Size = new System.Drawing.Size(200, 67);
            this.napomenaTxt.TabIndex = 53;
            this.napomenaTxt.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Napomena";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Važi do:";
            // 
            // UkupnoLbl
            // 
            this.UkupnoLbl.AutoSize = true;
            this.UkupnoLbl.Location = new System.Drawing.Point(139, 109);
            this.UkupnoLbl.Name = "UkupnoLbl";
            this.UkupnoLbl.Size = new System.Drawing.Size(0, 13);
            this.UkupnoLbl.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Korisnik";
            // 
            // ObavijestiBtn
            // 
            this.ObavijestiBtn.Location = new System.Drawing.Point(139, 314);
            this.ObavijestiBtn.Name = "ObavijestiBtn";
            this.ObavijestiBtn.Size = new System.Drawing.Size(200, 23);
            this.ObavijestiBtn.TabIndex = 49;
            this.ObavijestiBtn.Text = "Obavijesti korisnika";
            this.ObavijestiBtn.UseVisualStyleBackColor = true;
            this.ObavijestiBtn.Click += new System.EventHandler(this.ObavijestiBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Telefon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Ukupno potrošeno";
            // 
            // KorisnikLbl
            // 
            this.KorisnikLbl.AutoSize = true;
            this.KorisnikLbl.Location = new System.Drawing.Point(136, 43);
            this.KorisnikLbl.Name = "KorisnikLbl";
            this.KorisnikLbl.Size = new System.Drawing.Size(0, 13);
            this.KorisnikLbl.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(21, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Popust:";
            // 
            // TelefonLbl
            // 
            this.TelefonLbl.AutoSize = true;
            this.TelefonLbl.Location = new System.Drawing.Point(139, 79);
            this.TelefonLbl.Name = "TelefonLbl";
            this.TelefonLbl.Size = new System.Drawing.Size(0, 13);
            this.TelefonLbl.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(445, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 25);
            this.label1.TabIndex = 63;
            this.label1.Text = "Nagradi najboljeg korisnika!";
            // 
            // NagradnaIgraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 665);
            this.Controls.Add(this.groupBox1);
            this.Name = "NagradnaIgraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NagradnaIgra";
            this.Load += new System.EventHandler(this.NagradnaIgraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPokreniIgru;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox PopustTxt;
        private System.Windows.Forms.DateTimePicker DatumPicker;
        private System.Windows.Forms.RichTextBox napomenaTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label UkupnoLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ObavijestiBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label KorisnikLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TelefonLbl;
        private System.Windows.Forms.Label label1;
    }
}