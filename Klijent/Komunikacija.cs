using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    public class Komunikacija
    {
        TcpClient klijent;
        BinaryFormatter formater;
        NetworkStream tok;

        private static Komunikacija Instance;

        public static Komunikacija GetInstance()
        {
            if (Instance == null)
                Instance = new Komunikacija();
            return Instance;
        }

        internal List<Reprezentacija> VratiSveRepke()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiRepke;
            formater.Serialize(tok, transfer);

            transfer = (TransferKlasa)formater.Deserialize(tok);
            return (List<Reprezentacija>)transfer.Rezultat;
        }

        public bool PoveziSeNaServer()
        {
            try
            {
                klijent = new TcpClient("localhost",9000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }

        internal List<Utakmica> VratiSveUtakmice()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiUtakmice;
            formater.Serialize(tok, transfer);

            transfer = (TransferKlasa)formater.Deserialize(tok);
            return (List<Utakmica>)transfer.Rezultat;

        }

        public void Kraj()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiRepke;
            formater.Serialize(tok, transfer);
        }
    }
}
