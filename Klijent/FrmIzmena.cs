using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Klijent
{
    public partial class FrmIzmena : Form
    {
        public static Utakmica utakmica = new Utakmica();
        public FrmIzmena(Utakmica u)
        {
            InitializeComponent();

            txtGrupa.Text = u.Grupa;
            txtDomacin.Text = u.Domacin.Naziv;
            txtGolovaDomacin.Text = Convert.ToString(u.GolovaDomacin);
            txtGost.Text = u.Gost.Naziv;
            txtGolovaGost.Text = Convert.ToString(u.GolovaGost);

            utakmica.Grupa = u.Grupa;
            utakmica.Domacin = u.Domacin;
            utakmica.Gost = u.Gost;
            utakmica.GolovaDomacin = u.GolovaDomacin;
            utakmica.GolovaGost = u.GolovaGost;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Reprezentacija r in Komunikacija.GetInstance().VratiSveRepke())
            {
                cmbDomacin.Items.Add(r);
                cmbGost.Items.Add(r);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSacuvajIzmene_Click(object sender, EventArgs e)
        {
            if(txtGrupa.Text == "" || 
                txtGolovaDomacin.Text == "" || 
                txtGolovaGost.Text == "")
            {
                MessageBox.Show("Sva polja su obavezna!!!");
                return;
            }

            //if(cmbDomacin.SelectedItem == cmbGost.SelectedItem)
            //{
            //    MessageBox.Show("Domacin i gost moraju biti razliciti!!!");
            //    return;
            //}

            if(txtGrupa.Text != "A" &&
                txtGrupa.Text != "B" &&
                txtGrupa.Text != "C" &&
                txtGrupa.Text != "D" &&
                txtGrupa.Text != "E" &&
                txtGrupa.Text != "F")
            {
                MessageBox.Show("Grupa moze imati samo vrednosti A, B, C, D, E, F!");
                return;
            }

            utakmica.Grupa = txtGrupa.Text;
            if (cmbDomacin.SelectedItem != null)
                utakmica.Domacin = (Reprezentacija)cmbDomacin.SelectedItem;
            if (cmbGost.SelectedItem != null)
                utakmica.Gost = (Reprezentacija)cmbGost.SelectedItem;
            utakmica.GolovaDomacin = Convert.ToInt32(txtGolovaDomacin.Text);
            utakmica.GolovaGost = Convert.ToInt32(txtGolovaGost.Text);

            if(utakmica.Domacin == utakmica.Gost)
            {
                MessageBox.Show("Domacin i gost moraju biti razliciti!!!");
                return;
            }

            foreach (Utakmica u in Komunikacija.GetInstance().VratiSveUtakmice())
            {
                if (u.Domacin.Naziv == utakmica.Domacin.Naziv && u.Gost.Naziv == utakmica.Gost.Naziv &&
                    (cmbDomacin.SelectedItem != null || cmbGost.SelectedItem != null))
                {
                    MessageBox.Show($"U sistemu vec postoji utakmica za par {utakmica.Domacin.Naziv} - {utakmica.Gost.Naziv}");
                    return;
                }
            }
            //MessageBox.Show($"par {utakmica.Domacin.Naziv} - {utakmica.Gost.Naziv}");



            utakmica.Status = Status.Izmeni;

            this.Close();
        }
    }
}
