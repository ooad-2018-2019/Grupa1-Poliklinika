using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Termin 
    {
        public DateTime vrijemePocetka { get; set; }
        public DateTime vrijemeKraja { get; set; }
        public Doktor doktor { get; set; }

        public Termin(DateTime vrijemePocetka, DateTime vrijemeKraja, Doktor doktor)
        {
            this.vrijemePocetka = vrijemePocetka;
            this.vrijemeKraja = vrijemeKraja;
            this.doktor = doktor;
        }

        public Termin()
        {
        }
    }
}
