using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Pacijent : IUvidUKarton, IZakazivanjeTermina
    {

        public void dodajTermin(Termin termin)
        {
            throw new NotImplementedException();
        }

        public void izlistajAktuelneNalaze()
        {
            throw new NotImplementedException();
        }

        public void izlistajHistorijuTerapija()
        {
            throw new NotImplementedException();
        }

        public void izlistajNalaze()
        {
            throw new NotImplementedException();
        }

        public void izlistajTrenutnuTerapiju()
        {
            throw new NotImplementedException();
        }

        public List<DateTime> pretragaSlobodnog(DateTime datum, Doktor doktor)
        {
            throw new NotImplementedException();
        }

        public bool zahtjevZaTerminom(DateTime datum, Doktor doktor)
        {
            throw new NotImplementedException();
        }
    }
}
