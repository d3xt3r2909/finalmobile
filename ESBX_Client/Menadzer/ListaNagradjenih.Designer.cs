﻿namespace ESBX_Client.Menadzer
{
    partial class ListaNagradjenih
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaNagradjenih));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.inputImePrezime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inputKuponKod = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.inputTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.inputCheckBoxIskoristeni = new System.Windows.Forms.CheckBox();
            this.inputTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.gridNagrade = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.KorisnikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnikImePrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnikEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KuponKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Popust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VaziDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iskoristen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNagrade)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnPretraga);
            this.groupBox1.Controls.Add(this.gridNagrade);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(67, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1191, 591);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nagradjeni kupci";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.inputImePrezime);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.inputKuponKod);
            this.groupBox4.Location = new System.Drawing.Point(281, 91);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(248, 139);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Opcionalni filteri";
            // 
            // inputImePrezime
            // 
            this.inputImePrezime.Location = new System.Drawing.Point(20, 42);
            this.inputImePrezime.Name = "inputImePrezime";
            this.inputImePrezime.Size = new System.Drawing.Size(203, 20);
            this.inputImePrezime.TabIndex = 10;
            this.inputImePrezime.TextChanged += new System.EventHandler(this.inputImePrezime_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ime prezime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Kupon kod";
            // 
            // inputKuponKod
            // 
            this.inputKuponKod.Location = new System.Drawing.Point(20, 81);
            this.inputKuponKod.Name = "inputKuponKod";
            this.inputKuponKod.Size = new System.Drawing.Size(203, 20);
            this.inputKuponKod.TabIndex = 12;
            this.inputKuponKod.TextChanged += new System.EventHandler(this.inputKuponKod_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.inputTimePickerStart);
            this.groupBox3.Controls.Add(this.inputCheckBoxIskoristeni);
            this.groupBox3.Controls.Add(this.inputTimePickerEnd);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(27, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 139);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Obavezni filteri";
            // 
            // inputTimePickerStart
            // 
            this.inputTimePickerStart.Location = new System.Drawing.Point(15, 39);
            this.inputTimePickerStart.Name = "inputTimePickerStart";
            this.inputTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this.inputTimePickerStart.TabIndex = 15;
            // 
            // inputCheckBoxIskoristeni
            // 
            this.inputCheckBoxIskoristeni.AutoSize = true;
            this.inputCheckBoxIskoristeni.Location = new System.Drawing.Point(15, 117);
            this.inputCheckBoxIskoristeni.Name = "inputCheckBoxIskoristeni";
            this.inputCheckBoxIskoristeni.Size = new System.Drawing.Size(150, 17);
            this.inputCheckBoxIskoristeni.TabIndex = 14;
            this.inputCheckBoxIskoristeni.Text = "Iskoristene / neiskoristene";
            this.inputCheckBoxIskoristeni.UseVisualStyleBackColor = true;
            this.inputCheckBoxIskoristeni.CheckedChanged += new System.EventHandler(this.inputCheckBoxIskoristeni_CheckedChanged);
            // 
            // inputTimePickerEnd
            // 
            this.inputTimePickerEnd.Location = new System.Drawing.Point(15, 78);
            this.inputTimePickerEnd.Name = "inputTimePickerEnd";
            this.inputTimePickerEnd.Size = new System.Drawing.Size(200, 20);
            this.inputTimePickerEnd.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Do datuma";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Od datuma";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Ocisti filtere";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(578, 198);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(193, 23);
            this.btnPretraga.TabIndex = 19;
            this.btnPretraga.Text = "Upotrijebi filter";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // gridNagrade
            // 
            this.gridNagrade.AllowUserToAddRows = false;
            this.gridNagrade.AllowUserToDeleteRows = false;
            this.gridNagrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridNagrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNagrade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikId,
            this.KorisnikImePrezime,
            this.KorisnikEmail,
            this.KuponKod,
            this.Popust,
            this.VaziDo,
            this.Iskoristen});
            this.gridNagrade.Location = new System.Drawing.Point(27, 244);
            this.gridNagrade.Name = "gridNagrade";
            this.gridNagrade.ReadOnly = true;
            this.gridNagrade.Size = new System.Drawing.Size(1113, 330);
            this.gridNagrade.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Help;
            this.groupBox2.Location = new System.Drawing.Point(27, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 66);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Help;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(106, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(297, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Takodjer, moguce je upotrijebiti jedan ili vise filtera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Help;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(105, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(543, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "U tabeli se prikazuju kupci koji su do sada ostvarili nagrade kao i iskoristenost" +
    " samog kupona.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // KorisnikId
            // 
            this.KorisnikId.DataPropertyName = "KorisnikId";
            this.KorisnikId.HeaderText = "KorisnikId";
            this.KorisnikId.Name = "KorisnikId";
            this.KorisnikId.ReadOnly = true;
            this.KorisnikId.Visible = false;
            // 
            // KorisnikImePrezime
            // 
            this.KorisnikImePrezime.DataPropertyName = "KorisnikImePrezime";
            this.KorisnikImePrezime.HeaderText = "Korisnik";
            this.KorisnikImePrezime.Name = "KorisnikImePrezime";
            this.KorisnikImePrezime.ReadOnly = true;
            // 
            // KorisnikEmail
            // 
            this.KorisnikEmail.DataPropertyName = "KorisnikEmail";
            this.KorisnikEmail.HeaderText = "Email";
            this.KorisnikEmail.Name = "KorisnikEmail";
            this.KorisnikEmail.ReadOnly = true;
            // 
            // KuponKod
            // 
            this.KuponKod.DataPropertyName = "KuponKod";
            this.KuponKod.HeaderText = "Kupon kod";
            this.KuponKod.Name = "KuponKod";
            this.KuponKod.ReadOnly = true;
            // 
            // Popust
            // 
            this.Popust.DataPropertyName = "Popust";
            this.Popust.HeaderText = "Popust";
            this.Popust.Name = "Popust";
            this.Popust.ReadOnly = true;
            // 
            // VaziDo
            // 
            this.VaziDo.DataPropertyName = "VaziDo";
            this.VaziDo.HeaderText = "Vazi do";
            this.VaziDo.Name = "VaziDo";
            this.VaziDo.ReadOnly = true;
            // 
            // Iskoristen
            // 
            this.Iskoristen.DataPropertyName = "IskoristenOpis";
            this.Iskoristen.HeaderText = "Iskoristen";
            this.Iskoristen.Name = "Iskoristen";
            this.Iskoristen.ReadOnly = true;
            // 
            // ListaNagradjenih
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 665);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListaNagradjenih";
            this.Text = "ListaNagradjenih";
            this.Load += new System.EventHandler(this.ListaNagradjenih_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNagrade)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView gridNagrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputKuponKod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputImePrezime;
        private System.Windows.Forms.CheckBox inputCheckBoxIskoristeni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker inputTimePickerEnd;
        private System.Windows.Forms.DateTimePicker inputTimePickerStart;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikImePrezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn KuponKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Popust;
        private System.Windows.Forms.DataGridViewTextBoxColumn VaziDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iskoristen;
    }
}