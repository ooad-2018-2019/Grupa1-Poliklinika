using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Terapija
    {
        private List<Lijek> _lijekovi;
        private DateTime _datumPocetka;
        private DateTime _datumKraja;
        private String _napomena;

        public List<Lijek> Lijekovi { get => _lijekovi; set => _lijekovi = value; }
        public DateTime DatumPocetka { get => _datumPocetka; set => _datumPocetka = value; }
        public DateTime DatumKraja { get => _datumKraja; set => _datumKraja = value; }
        public string Napomena { get => _napomena; set => _napomena = value; }

        public Terapija(List<Lijek> lijekoviTerapije, DateTime datumPocetak, DateTime datumKraja, string napomena)
        {
            this.Lijekovi = lijekoviTerapije;
            this.DatumPocetka = datumPocetak;
            this.DatumKraja = datumKraja;
            this.Napomena = napomena;
        }

        public Terapija()
        {
        }
    }
}
