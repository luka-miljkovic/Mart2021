using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Tabela
    {
        [Browsable(false)]
        public int RepkaID { get; set; }
        public string NazivRepke { get; set; }
        public int GolovaDala { get; set; }
        public int GolovaPrimila { get; set; }
        public int GolRazlika { get; set; }
    }
}
