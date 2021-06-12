using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class TransferKlasa
    {
        public Operacije Operacija { get; set; }
        public Object TransferObjekat { get; set; }
        public Object Rezultat { get; set; }
    }
}
