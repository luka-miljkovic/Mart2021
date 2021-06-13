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
    public partial class FrmKlijent : Form
    {
        BindingList<Utakmica> utakmice;
        
        public FrmKlijent()
        {
            InitializeComponent();
        }

        private void FrmKlijent_Load(object sender, EventArgs e)
        {

            if (Komunikacija.GetInstance().PoveziSeNaServer())
            {
            }
            else
            {
                this.Text = "Neuspesno povezivanje sa serverom";
            }

            utakmice = new BindingList<Utakmica>(Komunikacija.GetInstance().VratiSveUtakmice());

            dgvUtakmice.DataSource = utakmice;
        }

        private void dtnIzmeniUtakmicu_Click(object sender, EventArgs e)
        {
            Utakmica u = (Utakmica)dgvUtakmice.CurrentRow.DataBoundItem;
            //.Show($"{utakmice[0].UtakmicaId}");
            new FrmIzmena(u).ShowDialog();
            int index = u.UtakmicaId - 1;
            utakmice.Remove(u);
            utakmice.Insert(index, FrmIzmena.utakmica);
            

        }

        private void btnObrisiUtakmicu_Click(object sender, EventArgs e)
        {
            Utakmica u = (Utakmica)dgvUtakmice.CurrentRow.DataBoundItem;
            int index = u.UtakmicaId - 1;
            utakmice.Remove(u);
            u.Status = Status.Obrisi;
            utakmice.Insert(index, u);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            int rez = Komunikacija.GetInstance().SacuvajIzmene(new List<Utakmica>(utakmice));

            if(rez == 1)
            {
                MessageBox.Show("Izmene su uspesno sacuvane");
            }
            if(rez == 0)
            {
                MessageBox.Show("Greska prilikom cuvanja izmena");
            }
        }
    }
}
