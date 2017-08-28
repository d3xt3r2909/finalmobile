﻿namespace ESBX_Client.Menadzer
{
    partial class PromjenaPovjerljivosti
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
            this.KorisniciGrid = new System.Windows.Forms.DataGridView();
            this.KorisnikID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UkupanDug = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Povjerljiv = new System.Windows.Forms.DataGridViewLinkColumn();
            this.TraziBtn = new System.Windows.Forms.Button();
            this.PretragaImePtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KorisniciGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // KorisniciGrid
            // 
            this.KorisniciGrid.AllowUserToAddRows = false;
            this.KorisniciGrid.AllowUserToDeleteRows = false;
            this.KorisniciGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.KorisniciGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.KorisniciGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KorisniciGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikID,
            this.Korisnik,
            this.Email,
            this.Telefon,
            this.UkupanDug,
            this.Povjerljiv});
            this.KorisniciGrid.Location = new System.Drawing.Point(83, 158);
            this.KorisniciGrid.MultiSelect = false;
            this.KorisniciGrid.Name = "KorisniciGrid";
            this.KorisniciGrid.RowHeadersWidth = 51;
            this.KorisniciGrid.Size = new System.Drawing.Size(807, 308);
            this.KorisniciGrid.TabIndex = 41;
            this.KorisniciGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.KorisniciGrid_CellContentClick);
            // 
            // KorisnikID
            // 
            this.KorisnikID.DataPropertyName = "KorisnikId";
            this.KorisnikID.HeaderText = "KorisnikID";
            this.KorisnikID.Name = "KorisnikID";
            this.KorisnikID.Visible = false;
            // 
            // Korisnik
            // 
            this.Korisnik.DataPropertyName = "Korisnik";
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            // 
            // UkupanDug
            // 
            this.UkupanDug.DataPropertyName = "UkupanDug";
            this.UkupanDug.HeaderText = "Ukupan dug";
            this.UkupanDug.Name = "UkupanDug";
            this.UkupanDug.ReadOnly = true;
            // 
            // Povjerljiv
            // 
            this.Povjerljiv.HeaderText = "";
            this.Povjerljiv.Name = "Povjerljiv";
            this.Povjerljiv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Povjerljiv.Text = "Aktiviraj";
            this.Povjerljiv.ToolTipText = "Aktiviraj";
            this.Povjerljiv.UseColumnTextForLinkValue = true;
            // 
            // TraziBtn
            // 
            this.TraziBtn.Location = new System.Drawing.Point(316, 98);
            this.TraziBtn.Name = "TraziBtn";
            this.TraziBtn.Size = new System.Drawing.Size(75, 23);
            this.TraziBtn.TabIndex = 44;
            this.TraziBtn.Text = "Traži";
            this.TraziBtn.UseVisualStyleBackColor = true;
            this.TraziBtn.Click += new System.EventHandler(this.TraziBtn_Click);
            // 
            // PretragaImePtxt
            // 
            this.PretragaImePtxt.Location = new System.Drawing.Point(168, 98);
            this.PretragaImePtxt.Name = "PretragaImePtxt";
            this.PretragaImePtxt.Size = new System.Drawing.Size(141, 20);
            this.PretragaImePtxt.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(80, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ime i prezime";
            // 
            // PromjenaPovjerljivosti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 510);
            this.Controls.Add(this.TraziBtn);
            this.Controls.Add(this.PretragaImePtxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KorisniciGrid);
            this.Name = "PromjenaPovjerljivosti";
            this.Text = "Nepovjerljivi korisnici";
            this.Load += new System.EventHandler(this.PromjenaPovjerljivosti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KorisniciGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView KorisniciGrid;
        private System.Windows.Forms.Button TraziBtn;
        private System.Windows.Forms.TextBox PretragaImePtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn UkupanDug;
        private System.Windows.Forms.DataGridViewLinkColumn Povjerljiv;
    }
}