using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public interface IBazaPoliklinike
    {
       
        void dodajPacijenta(Login osoba);
      
       void dodajZaposlenika(Login osoba);
      void obrisiOsobu(Login osoba);
      List<Osoba> dajListuPacijenata();
        List<Osoba> vratiListuOsoblja();
  Int32 vratiNajveciID(String query);
        Int32 vratiIdPoLoginu(String username);
    }
}
