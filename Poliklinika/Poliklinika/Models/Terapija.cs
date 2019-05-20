using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Terapija
    {
        public List<Lijek> lijekoviTerapije { get; set; }
        public DateTime datumPocetak { get; set; }
        public DateTime datumKraja { get; set; }
        public String napomena { get; set; }

        public Terapija(List<Lijek> lijekoviTerapije, DateTime datumPocetak, DateTime datumKraja, string napomena)
        {
            this.lijekoviTerapije = lijekoviTerapije;
            this.datumPocetak = datumPocetak;
            this.datumKraja = datumKraja;
            this.napomena = napomena;
        }

        public Terapija()
        {
        }
    }
}
