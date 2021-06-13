using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class NitKlijenta
    {
        private NetworkStream tok;
        BinaryFormatter formater;

        public NitKlijenta(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();

            ThreadStart ts = Obradi;
            new Thread(ts).Start();
        }


        public void Obradi()
        {
            try
            {
                int operacija = 0;

                while(operacija != (int)Operacije.Kraj)
                {
                    TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;

                    switch (transfer.Operacija)
                    {
                        case Operacije.Kraj:
                            operacija = 1;
                            break;
                        case Operacije.VratiUtakmice:
                            transfer.Rezultat = Broker.GetInstance().VratiSveUtakmice();
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.VratiRepke:
                            transfer.Rezultat = Broker.GetInstance().VratiSveRepke();
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.SacuvajIzmene:
                            transfer.Rezultat = Broker.GetInstance().SacuvajIzmene((List<Utakmica>)transfer.TransferObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
