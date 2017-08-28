namespace ESBX_Client.Menadzer
{
    partial class AddOsobljeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ImeTxt = new System.Windows.Forms.TextBox();
            this.PrezimeTxt = new System.Windows.Forms.TextBox();
            this.EmailTxt = new System.Windows.Forms.TextBox();
            this.GradCmb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.LozinkaTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TelefonTxt = new System.Windows.Forms.MaskedTextBox();
            this.DatumRodjenjaPicker = new System.Windows.Forms.DateTimePicker();
            this.DatumZaposlenjaPicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.AdresaTxt = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prezime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Datum rođenja";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Datum zaposlenja";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Grad";
            // 
            // ImeTxt
            // 
            this.ImeTxt.Location = new System.Drawing.Point(273, 90);
            this.ImeTxt.Name = "ImeTxt";
            this.ImeTxt.Size = new System.Drawing.Size(200, 20);
            this.ImeTxt.TabIndex = 7;
            this.ImeTxt.Validating += new System.ComponentModel.CancelEventHandler(this.ImeTxt_Validating);
            // 
            // PrezimeTxt
            // 
            this.PrezimeTxt.Location = new System.Drawing.Point(273, 131);
            this.PrezimeTxt.Name = "PrezimeTxt";
            this.PrezimeTxt.Size = new System.Drawing.Size(200, 20);
            this.PrezimeTxt.TabIndex = 8;
            this.PrezimeTxt.Validating += new System.ComponentModel.CancelEventHandler(this.PrezimeTxt_Validating);
            // 
            // EmailTxt
            // 
            this.EmailTxt.Location = new System.Drawing.Point(273, 213);
            this.EmailTxt.Name = "EmailTxt";
            this.EmailTxt.Size = new System.Drawing.Size(200, 20);
            this.EmailTxt.TabIndex = 9;
            this.EmailTxt.Validating += new System.ComponentModel.CancelEventHandler(this.EmailTxt_Validating);
            // 
            // GradCmb
            // 
            this.GradCmb.FormattingEnabled = true;
            this.GradCmb.Location = new System.Drawing.Point(273, 406);
            this.GradCmb.Name = "GradCmb";
            this.GradCmb.Size = new System.Drawing.Size(200, 21);
            this.GradCmb.TabIndex = 12;
            this.GradCmb.Validating += new System.ComponentModel.CancelEventHandler(this.GradCmb_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Sačuvaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Lozinka";
            // 
            // LozinkaTxt
            // 
            this.LozinkaTxt.Location = new System.Drawing.Point(273, 289);
            this.LozinkaTxt.Name = "LozinkaTxt";
            this.LozinkaTxt.Size = new System.Drawing.Size(200, 20);
            this.LozinkaTxt.TabIndex = 15;
            this.LozinkaTxt.Validating += new System.ComponentModel.CancelEventHandler(this.LozinkaTxt_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Telefon";
            // 
            // TelefonTxt
            // 
            this.TelefonTxt.Location = new System.Drawing.Point(273, 172);
            this.TelefonTxt.Mask = "(999) 000-000";
            this.TelefonTxt.Name = "TelefonTxt";
            this.TelefonTxt.Size = new System.Drawing.Size(200, 20);
            this.TelefonTxt.TabIndex = 17;
            this.TelefonTxt.Validating += new System.ComponentModel.CancelEventHandler(this.TelefonTxt_Validating);
            // 
            // DatumRodjenjaPicker
            // 
            this.DatumRodjenjaPicker.Location = new System.Drawing.Point(273, 335);
            this.DatumRodjenjaPicker.Name = "DatumRodjenjaPicker";
            this.DatumRodjenjaPicker.Size = new System.Drawing.Size(200, 20);
            this.DatumRodjenjaPicker.TabIndex = 18;
            // 
            // DatumZaposlenjaPicker
            // 
            this.DatumZaposlenjaPicker.Location = new System.Drawing.Point(273, 372);
            this.DatumZaposlenjaPicker.Name = "DatumZaposlenjaPicker";
            this.DatumZaposlenjaPicker.Size = new System.Drawing.Size(200, 20);
            this.DatumZaposlenjaPicker.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(170, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Adresa";
            // 
            // AdresaTxt
            // 
            this.AdresaTxt.Location = new System.Drawing.Point(273, 253);
            this.AdresaTxt.Name = "AdresaTxt";
            this.AdresaTxt.Size = new System.Drawing.Size(200, 20);
            this.AdresaTxt.TabIndex = 22;
            this.AdresaTxt.Validating += new System.ComponentModel.CancelEventHandler(this.AdresaTxt_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // AddOsobljeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 515);
            this.Controls.Add(this.AdresaTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DatumZaposlenjaPicker);
            this.Controls.Add(this.DatumRodjenjaPicker);
            this.Controls.Add(this.TelefonTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LozinkaTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GradCmb);
            this.Controls.Add(this.EmailTxt);
            this.Controls.Add(this.PrezimeTxt);
            this.Controls.Add(this.ImeTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddOsobljeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodavanje osoblja";
            this.Load += new System.EventHandler(this.AddOsobljeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ImeTxt;
        private System.Windows.Forms.TextBox PrezimeTxt;
        private System.Windows.Forms.TextBox EmailTxt;
        private System.Windows.Forms.ComboBox GradCmb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox LozinkaTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox TelefonTxt;
        private System.Windows.Forms.DateTimePicker DatumRodjenjaPicker;
        private System.Windows.Forms.DateTimePicker DatumZaposlenjaPicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox AdresaTxt;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}