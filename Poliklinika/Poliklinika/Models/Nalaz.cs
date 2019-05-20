using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Nalaz
    {
        public DateTime datumNalaza { get; set; }
        public String detaljiNalaza { get; set; }

        public Nalaz(DateTime datumNalaza, string detaljiNalaza)
        {
            this.datumNalaza = datumNalaza;
            this.detaljiNalaza = detaljiNalaza;
        }

        public Nalaz()
        {
            //test test   d
        }
    }
}
