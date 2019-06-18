using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Termin 
    {
        private DateTime _vrijemePocetka;
        private DateTime _vrijemeKraja;
        private Doktor _doktor;

        public DateTime VrijemePocetka { get => _vrijemePocetka; set => _vrijemePocetka = value; }
        public DateTime VrijemeKraja { get => _vrijemeKraja; set => _vrijemeKraja = value; }
        public Doktor Doktor { get => _doktor; set => _doktor = value; }

        public Termin(DateTime vrijemePocetka, DateTime vrijemeKraja, Doktor doktor)
        {
            this.VrijemePocetka = vrijemePocetka;
            this.VrijemeKraja = vrijemeKraja;
            this.Doktor = doktor;
        }

        public Termin()
        {
        }
    }
}
