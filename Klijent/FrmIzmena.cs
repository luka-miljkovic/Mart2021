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

namespace Klijent
{
    public partial class FrmIzmena : Form
    {
        public FrmIzmena(Utakmica u)
        {
            InitializeComponent();

            txtGrupa.Text = u.Grupa;
            txtDomacin.Text = u.Domacin.Naziv;
            txtGolovaDomacin.Text = Convert.ToString(u.GolovaDomacin);
            txtGost.Text = u.Gost.Naziv;
            txtGolovaGost.Text = Convert.ToString(u.GolovaGost);
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
    }
}
