namespace ESBX_Client.Menadzer
{
    partial class OsobljePrikazForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.PretragaImePtxt = new System.Windows.Forms.TextBox();
            this.TraziBtn = new System.Windows.Forms.Button();
            this.DodajUposlenikBtn = new System.Windows.Forms.Button();
            this.KorisniciGrid = new System.Windows.Forms.DataGridView();
            this.UposlenikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uposlenik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumZaposlenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.KorisniciGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(83, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime i prezime";
            // 
            // PretragaImePtxt
            // 
            this.PretragaImePtxt.Location = new System.Drawing.Point(170, 87);
            this.PretragaImePtxt.Name = "PretragaImePtxt";
            this.PretragaImePtxt.Size = new System.Drawing.Size(141, 20);
            this.PretragaImePtxt.TabIndex = 2;
            // 
            // TraziBtn
            // 
            this.TraziBtn.Location = new System.Drawing.Point(318, 87);
            this.TraziBtn.Name = "TraziBtn";
            this.TraziBtn.Size = new System.Drawing.Size(75, 23);
            this.TraziBtn.TabIndex = 3;
            this.TraziBtn.Text = "Traži";
            this.TraziBtn.UseVisualStyleBackColor = true;
            this.TraziBtn.Click += new System.EventHandler(this.TraziBtn_Click);
            // 
            // DodajUposlenikBtn
            // 
            this.DodajUposlenikBtn.Location = new System.Drawing.Point(772, 87);
            this.DodajUposlenikBtn.Name = "DodajUposlenikBtn";
            this.DodajUposlenikBtn.Size = new System.Drawing.Size(100, 23);
            this.DodajUposlenikBtn.TabIndex = 4;
            this.DodajUposlenikBtn.Text = "Dodaj uposlenika";
            this.DodajUposlenikBtn.UseVisualStyleBackColor = true;
            this.DodajUposlenikBtn.Click += new System.EventHandler(this.DodajUposlenikBtn_Click);
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
            this.UposlenikId,
            this.Uposlenik,
            this.Email,
            this.Telefon,
            this.DatumZaposlenja,
            this.Aktivan});
            this.KorisniciGrid.Location = new System.Drawing.Point(83, 135);
            this.KorisniciGrid.MultiSelect = false;
            this.KorisniciGrid.Name = "KorisniciGrid";
            this.KorisniciGrid.RowHeadersWidth = 51;
            this.KorisniciGrid.Size = new System.Drawing.Size(789, 330);
            this.KorisniciGrid.TabIndex = 5;
            this.KorisniciGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.KorisniciGrid_CellContentClick);
            // 
            // UposlenikId
            // 
            this.UposlenikId.DataPropertyName = "UposlenikId";
            this.UposlenikId.HeaderText = "UposlenikId";
            this.UposlenikId.Name = "UposlenikId";
            this.UposlenikId.Visible = false;
            // 
            // Uposlenik
            // 
            this.Uposlenik.DataPropertyName = "Uposlenik";
            this.Uposlenik.HeaderText = "Uposlenik";
            this.Uposlenik.Name = "Uposlenik";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            // 
            // DatumZaposlenja
            // 
            this.DatumZaposlenja.DataPropertyName = "DatumZaposlenja";
            this.DatumZaposlenja.HeaderText = "Datum zaposlenja";
            this.DatumZaposlenja.Name = "DatumZaposlenja";
            // 
            // Aktivan
            // 
            this.Aktivan.DataPropertyName = "Aktivan";
            this.Aktivan.HeaderText = "Aktivan";
            this.Aktivan.Name = "Aktivan";
            this.Aktivan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Aktivan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // OsobljePrikazForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 524);
            this.Controls.Add(this.KorisniciGrid);
            this.Controls.Add(this.DodajUposlenikBtn);
            this.Controls.Add(this.TraziBtn);
            this.Controls.Add(this.PretragaImePtxt);
            this.Controls.Add(this.label1);
            this.Name = "OsobljePrikazForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregled osoblja";
            this.Load += new System.EventHandler(this.OsobljePrikazForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KorisniciGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PretragaImePtxt;
        private System.Windows.Forms.Button TraziBtn;
        private System.Windows.Forms.Button DodajUposlenikBtn;
        private System.Windows.Forms.DataGridView KorisniciGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn UposlenikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uposlenik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumZaposlenja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivan;

    }
}