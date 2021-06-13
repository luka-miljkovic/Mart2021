using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum Status
    {
        Nepromenjena,
        Izmeni,
        Obrisi

    }
    [Serializable]
    public class Utakmica
    {
        [Browsable(false)]
        public int UtakmicaId { get; set; }
        public string Grupa { get; set; }
        public Reprezentacija Domacin { get; set; }
        public Reprezentacija Gost { get; set; }
        public int GolovaDomacin { get; set; }
        public int GolovaGost { get; set; }
        public Status Status { get; set; }
    }
}
