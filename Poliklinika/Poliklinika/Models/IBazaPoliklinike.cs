using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public interface IBazaPoliklinike
    {
        void dodajPacijenta();
        void ukloniPacijenta();
        void dodajZaposlenika();
        void ukloniZaposlenika();

    }
}
