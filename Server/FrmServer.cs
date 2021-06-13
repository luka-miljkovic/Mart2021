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

namespace Server
{
    public partial class FrmServer : Form
    {
        BindingList<Tabela> repkre = new BindingList<Tabela>();
        Server s = new Server();
        Timer t;
        public FrmServer()
        {
            InitializeComponent();
        }

        private void FrmServer_Load(object sender, EventArgs e)
        {
            if (s.PokreniServer())
            {
            }

            t = new Timer();
            t.Interval = 5000;
            t.Tick += Osvezi;
            t.Start();
        }

        private void Osvezi(object sender, EventArgs e)
        {

            repkre.Clear();

            if (txtGrupa.Text == "A" ||
                txtGrupa.Text == "B" ||
                txtGrupa.Text == "C" ||
                txtGrupa.Text == "D" ||
                txtGrupa.Text == "E" ||
                txtGrupa.Text == "F")
            {
                repkre = new BindingList<Tabela>(Broker.GetInstance().VratiTabelu(txtGrupa.Text));
            }
            else
            {
                foreach (Reprezentacija r in Broker.GetInstance().VratiSveRepke())
                {
                    repkre.Add(new Tabela
                    {
                        NazivRepke = r.Naziv,
                        GolovaDala = Broker.GetInstance().BrojDatihGolova(r.ReprezentacijaId),
                        GolovaPrimila = Broker.GetInstance().BrojPrimljenihGolova(r.ReprezentacijaId),
                        GolRazlika = Broker.GetInstance().BrojDatihGolova(r.ReprezentacijaId) - Broker.GetInstance().BrojPrimljenihGolova(r.ReprezentacijaId)
                    });
                }
            }

            Tabela tmp = new Tabela();
            //MessageBox.Show($"{repkre.Count()}");
            for (int i = 0; i < repkre.Count() - 1; i++)
            {
                for(int j = i + 1; j < repkre.Count(); j++)
                {
                    if (repkre[i].GolRazlika < repkre[j].GolRazlika)
                    {
                        //MessageBox.Show($"Usao. Menjam {repkre[i].NazivRepke} i {repkre[i + 1].NazivRepke}");

                        tmp = repkre[i];
                        repkre[i] = repkre[j];
                        repkre[j] = tmp;

                        //MessageBox.Show($"sada je {repkre[i].NazivRepke} pa {repkre[i + 1].NazivRepke}");
                    }
                }
                
            }

            //string lala = "";

            //foreach(Tabela t in repkre)
            //{
            //    lala += $" {t.GolRazlika}";
            //}

            //MessageBox.Show(lala);

            dataGridView1.DataSource = repkre;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
