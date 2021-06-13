namespace Klijent
{
    partial class FrmKlijent
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
            this.Utakmice = new System.Windows.Forms.GroupBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnObrisiUtakmicu = new System.Windows.Forms.Button();
            this.dtnIzmeniUtakmicu = new System.Windows.Forms.Button();
            this.dgvUtakmice = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Utakmice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtakmice)).BeginInit();
            this.SuspendLayout();
            // 
            // Utakmice
            // 
            this.Utakmice.Controls.Add(this.btnSacuvaj);
            this.Utakmice.Controls.Add(this.btnObrisiUtakmicu);
            this.Utakmice.Controls.Add(this.dtnIzmeniUtakmicu);
            this.Utakmice.Controls.Add(this.dgvUtakmice);
            this.Utakmice.Location = new System.Drawing.Point(12, 12);
            this.Utakmice.Name = "Utakmice";
            this.Utakmice.Size = new System.Drawing.Size(882, 421);
            this.Utakmice.TabIndex = 0;
            this.Utakmice.TabStop = false;
            this.Utakmice.Text = "utakmice";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(6, 387);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(314, 28);
            this.btnSacuvaj.TabIndex = 3;
            this.btnSacuvaj.Text = "Sacuvaj izmene";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnObrisiUtakmicu
            // 
            this.btnObrisiUtakmicu.Location = new System.Drawing.Point(172, 356);
            this.btnObrisiUtakmicu.Name = "btnObrisiUtakmicu";
            this.btnObrisiUtakmicu.Size = new System.Drawing.Size(148, 25);
            this.btnObrisiUtakmicu.TabIndex = 2;
            this.btnObrisiUtakmicu.Text = "Obrisi utakmicu";
            this.btnObrisiUtakmicu.UseVisualStyleBackColor = true;
            this.btnObrisiUtakmicu.Click += new System.EventHandler(this.btnObrisiUtakmicu_Click);
            // 
            // dtnIzmeniUtakmicu
            // 
            this.dtnIzmeniUtakmicu.Location = new System.Drawing.Point(6, 356);
            this.dtnIzmeniUtakmicu.Name = "dtnIzmeniUtakmicu";
            this.dtnIzmeniUtakmicu.Size = new System.Drawing.Size(148, 25);
            this.dtnIzmeniUtakmicu.TabIndex = 1;
            this.dtnIzmeniUtakmicu.Text = "Izmeni utakmicu";
            this.dtnIzmeniUtakmicu.UseVisualStyleBackColor = true;
            this.dtnIzmeniUtakmicu.Click += new System.EventHandler(this.dtnIzmeniUtakmicu_Click);
            // 
            // dgvUtakmice
            // 
            this.dgvUtakmice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUtakmice.Location = new System.Drawing.Point(6, 21);
            this.dgvUtakmice.Name = "dgvUtakmice";
            this.dgvUtakmice.RowHeadersWidth = 51;
            this.dgvUtakmice.RowTemplate.Height = 24;
            this.dgvUtakmice.Size = new System.Drawing.Size(870, 329);
            this.dgvUtakmice.TabIndex = 0;
            // 
            // FrmKlijent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 445);
            this.Controls.Add(this.Utakmice);
            this.Name = "FrmKlijent";
            this.Text = " [FON] Fudbal - klijenski program";
            this.Load += new System.EventHandler(this.FrmKlijent_Load);
            this.Utakmice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtakmice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Utakmice;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnObrisiUtakmicu;
        private System.Windows.Forms.Button dtnIzmeniUtakmicu;
        private System.Windows.Forms.DataGridView dgvUtakmice;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

