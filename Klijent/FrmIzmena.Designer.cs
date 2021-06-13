namespace Klijent
{
    partial class FrmIzmena
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGrupa = new System.Windows.Forms.TextBox();
            this.txtGolovaDomacin = new System.Windows.Forms.TextBox();
            this.txtGolovaGost = new System.Windows.Forms.TextBox();
            this.cmbDomacin = new System.Windows.Forms.ComboBox();
            this.cmbGost = new System.Windows.Forms.ComboBox();
            this.btnSacuvajIzmene = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDomacin = new System.Windows.Forms.TextBox();
            this.txtGost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Domacin(trenutno)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gost(trenutno)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Golova domacin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Golova gost";
            // 
            // txtGrupa
            // 
            this.txtGrupa.Location = new System.Drawing.Point(216, 44);
            this.txtGrupa.Name = "txtGrupa";
            this.txtGrupa.Size = new System.Drawing.Size(170, 22);
            this.txtGrupa.TabIndex = 5;
            // 
            // txtGolovaDomacin
            // 
            this.txtGolovaDomacin.Location = new System.Drawing.Point(216, 214);
            this.txtGolovaDomacin.Name = "txtGolovaDomacin";
            this.txtGolovaDomacin.Size = new System.Drawing.Size(170, 22);
            this.txtGolovaDomacin.TabIndex = 9;
            // 
            // txtGolovaGost
            // 
            this.txtGolovaGost.Location = new System.Drawing.Point(216, 247);
            this.txtGolovaGost.Name = "txtGolovaGost";
            this.txtGolovaGost.Size = new System.Drawing.Size(170, 22);
            this.txtGolovaGost.TabIndex = 10;
            // 
            // cmbDomacin
            // 
            this.cmbDomacin.FormattingEnabled = true;
            this.cmbDomacin.Location = new System.Drawing.Point(216, 108);
            this.cmbDomacin.Name = "cmbDomacin";
            this.cmbDomacin.Size = new System.Drawing.Size(170, 24);
            this.cmbDomacin.TabIndex = 11;
            // 
            // cmbGost
            // 
            this.cmbGost.FormattingEnabled = true;
            this.cmbGost.Location = new System.Drawing.Point(216, 176);
            this.cmbGost.Name = "cmbGost";
            this.cmbGost.Size = new System.Drawing.Size(170, 24);
            this.cmbGost.TabIndex = 12;
            // 
            // btnSacuvajIzmene
            // 
            this.btnSacuvajIzmene.Location = new System.Drawing.Point(216, 292);
            this.btnSacuvajIzmene.Name = "btnSacuvajIzmene";
            this.btnSacuvajIzmene.Size = new System.Drawing.Size(170, 32);
            this.btnSacuvajIzmene.TabIndex = 13;
            this.btnSacuvajIzmene.Text = "Sacuvaj izmene";
            this.btnSacuvajIzmene.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSacuvajIzmene.UseVisualStyleBackColor = true;
            this.btnSacuvajIzmene.Click += new System.EventHandler(this.btnSacuvajIzmene_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Izaberi novog domacina";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Izaberi novog gosta";
            // 
            // txtDomacin
            // 
            this.txtDomacin.Location = new System.Drawing.Point(216, 77);
            this.txtDomacin.Name = "txtDomacin";
            this.txtDomacin.ReadOnly = true;
            this.txtDomacin.Size = new System.Drawing.Size(170, 22);
            this.txtDomacin.TabIndex = 16;
            // 
            // txtGost
            // 
            this.txtGost.Location = new System.Drawing.Point(216, 144);
            this.txtGost.Name = "txtGost";
            this.txtGost.ReadOnly = true;
            this.txtGost.Size = new System.Drawing.Size(170, 22);
            this.txtGost.TabIndex = 17;
            // 
            // FrmIzmena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.txtGost);
            this.Controls.Add(this.txtDomacin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSacuvajIzmene);
            this.Controls.Add(this.cmbGost);
            this.Controls.Add(this.cmbDomacin);
            this.Controls.Add(this.txtGolovaGost);
            this.Controls.Add(this.txtGolovaDomacin);
            this.Controls.Add(this.txtGrupa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmIzmena";
            this.Text = "Izmena utakmice";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGrupa;
        private System.Windows.Forms.TextBox txtGolovaDomacin;
        private System.Windows.Forms.TextBox txtGolovaGost;
        private System.Windows.Forms.ComboBox cmbDomacin;
        private System.Windows.Forms.ComboBox cmbGost;
        private System.Windows.Forms.Button btnSacuvajIzmene;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDomacin;
        private System.Windows.Forms.TextBox txtGost;
    }
}