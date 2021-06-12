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
        Komunikacija k;
        public FrmKlijent()
        {
            InitializeComponent();
        }

        private void FrmKlijent_Load(object sender, EventArgs e)
        {
            k = new Komunikacija();

            if (k.PoveziSeNaServer())
            {
            }
            else
            {
                this.Text = "Neuspesno povezivanje sa serverom";
            }
        }
    }
}
