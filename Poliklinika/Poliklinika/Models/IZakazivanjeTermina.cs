using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
   public interface IZakazivanjeTermina
    {
        List<DateTime> pretragaSlobodnog(DateTime datum, Doktor doktor);
        bool zahtjevZaTerminom(DateTime datum, Doktor doktor);
        void dodajTermin(Termin termin);

    }
}
