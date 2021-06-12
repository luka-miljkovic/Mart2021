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

            dgvUtakmice.DataSource = new BindingList<Utakmica>(Komunikacija.GetInstance().VratiSveUtakmice());
        }

        private void dtnIzmeniUtakmicu_Click(object sender, EventArgs e)
        {
            Utakmica u = (Utakmica)dgvUtakmice.CurrentRow.DataBoundItem;

            new FrmIzmena(u).ShowDialog();

        }
    }
}
