using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public interface IBazaPoliklinike
    {
       
        void dodajPacijenta(Pacijent osoba);
       void ukloniPacijenta(Pacijent osoba);
       void dodajZaposlenika();
      void ukloniZaposlenika();
        void izlistajSvePacijente();
        void izlistajSvoOsoblje();

        Int32 vratiNajveciID(String query);

    }
}
