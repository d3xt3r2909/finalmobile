namespace ESBX_Client.Osoblje
{
    partial class Kupon
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnIzdaj = new System.Windows.Forms.Button();
            this.txtPoklonBon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgIzdajRacun = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgIzdajRacun)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(748, 339);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(113, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "PDF download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnIzdaj
            // 
            this.btnIzdaj.Location = new System.Drawing.Point(748, 368);
            this.btnIzdaj.Name = "btnIzdaj";
            this.btnIzdaj.Size = new System.Drawing.Size(113, 23);
            this.btnIzdaj.TabIndex = 3;
            this.btnIzdaj.Text = "Zakljuci racun";
            this.btnIzdaj.UseVisualStyleBackColor = true;
            this.btnIzdaj.Click += new System.EventHandler(this.btnIzdaj_Click);
            // 
            // txtPoklonBon
            // 
            this.txtPoklonBon.Location = new System.Drawing.Point(748, 137);
            this.txtPoklonBon.Name = "txtPoklonBon";
            this.txtPoklonBon.Size = new System.Drawing.Size(113, 20);
            this.txtPoklonBon.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(748, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Poklon bon";
            // 
            // dgIzdajRacun
            // 
            this.dgIzdajRacun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIzdajRacun.Location = new System.Drawing.Point(69, 115);
            this.dgIzdajRacun.Name = "dgIzdajRacun";
            this.dgIzdajRacun.Size = new System.Drawing.Size(673, 277);
            this.dgIzdajRacun.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(305, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izdavanje racuna kupcu";
            // 
            // Kupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 483);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPoklonBon);
            this.Controls.Add(this.btnIzdaj);
            this.Controls.Add(this.dgIzdajRacun);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.label1);
            this.Name = "Kupon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kupon";
            this.Load += new System.EventHandler(this.Kupon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgIzdajRacun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnIzdaj;
        private System.Windows.Forms.TextBox txtPoklonBon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgIzdajRacun;
        private System.Windows.Forms.Label label1;
    }
}