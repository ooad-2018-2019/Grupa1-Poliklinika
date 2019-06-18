using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public interface IBazaPoliklinike
    {
       
        void dodajPacijenta(Login osoba);
       void ukloniPacijenta(Login osoba);
       void dodajZaposlenika();
      void ukloniZaposlenika();
        void izlistajSvePacijente();
        void izlistajSvoOsoblje();

        Int32 vratiNajveciID(String query);

    }
}
