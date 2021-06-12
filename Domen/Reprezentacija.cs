using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Reprezentacija
    {
        public int ReprezentacijaId { get; set; }
        public string Naziv { get; set; }
        public override string ToString()
        {
            return Naziv;
        }
    }
}
