namespace ExpressSaladBarDesktop_Client
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imgLoginLogo = new System.Windows.Forms.PictureBox();
            this.lblLoginEmail = new System.Windows.Forms.Label();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.lblLoginLozinka = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.btnLoginPrijava = new System.Windows.Forms.Button();
            this.errProviderLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoginLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.44134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.30726F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.39106F));
            this.tableLayoutPanel1.Controls.Add(this.imgLoginLogo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLoginEmail, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLoginUsername, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLoginLozinka, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtLoginPassword, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnLoginPrijava, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.192825F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.37556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.57466F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(955, 549);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // imgLoginLogo
            // 
            this.imgLoginLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgLoginLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLoginLogo.Image")));
            this.imgLoginLogo.Location = new System.Drawing.Point(338, 31);
            this.imgLoginLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgLoginLogo.Name = "imgLoginLogo";
            this.imgLoginLogo.Size = new System.Drawing.Size(317, 223);
            this.imgLoginLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoginLogo.TabIndex = 19;
            this.imgLoginLogo.TabStop = false;
            // 
            // lblLoginEmail
            // 
            this.lblLoginEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLoginEmail.AutoSize = true;
            this.lblLoginEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginEmail.Location = new System.Drawing.Point(456, 258);
            this.lblLoginEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoginEmail.Name = "lblLoginEmail";
            this.lblLoginEmail.Size = new System.Drawing.Size(81, 31);
            this.lblLoginEmail.TabIndex = 20;
            this.lblLoginEmail.Text = "Email";
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLoginUsername.Location = new System.Drawing.Point(238, 302);
            this.txtLoginUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.Size = new System.Drawing.Size(517, 22);
            this.txtLoginUsername.TabIndex = 14;
            this.txtLoginUsername.Text = "menadzer@gmail.com";
            this.txtLoginUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtLoginUsername_Validating);
            // 
            // lblLoginLozinka
            // 
            this.lblLoginLozinka.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLoginLozinka.AutoSize = true;
            this.lblLoginLozinka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginLozinka.Location = new System.Drawing.Point(442, 340);
            this.lblLoginLozinka.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoginLozinka.Name = "lblLoginLozinka";
            this.lblLoginLozinka.Size = new System.Drawing.Size(108, 31);
            this.lblLoginLozinka.TabIndex = 18;
            this.lblLoginLozinka.Text = "Lozinka";
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLoginPassword.Location = new System.Drawing.Point(238, 377);
            this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLoginPassword.Size = new System.Drawing.Size(517, 22);
            this.txtLoginPassword.TabIndex = 15;
            this.txtLoginPassword.Text = "testtest";
            this.txtLoginPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtLoginPassword_Validating);
            // 
            // btnLoginPrijava
            // 
            this.btnLoginPrijava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoginPrijava.Location = new System.Drawing.Point(600, 430);
            this.btnLoginPrijava.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoginPrijava.Name = "btnLoginPrijava";
            this.btnLoginPrijava.Size = new System.Drawing.Size(156, 46);
            this.btnLoginPrijava.TabIndex = 16;
            this.btnLoginPrijava.Text = "Prijava";
            this.btnLoginPrijava.UseVisualStyleBackColor = true;
            this.btnLoginPrijava.Click += new System.EventHandler(this.btnLoginPrijava_Click);
            // 
            // errProviderLogin
            // 
            this.errProviderLogin.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProviderLogin.ContainerControl = this;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prijava na sistem";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoginLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox imgLoginLogo;
        private System.Windows.Forms.Label lblLoginEmail;
        private System.Windows.Forms.TextBox txtLoginUsername;
        private System.Windows.Forms.Label lblLoginLozinka;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Button btnLoginPrijava;
        private System.Windows.Forms.ErrorProvider errProviderLogin;
    }
}

