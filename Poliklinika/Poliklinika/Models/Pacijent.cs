using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Pacijent : Osoba, IUvidUKarton, IZakazivanjeTermina
    {
        public Pacijent(string ime, string prezime, string email, string mjestoRodjenja, DateTime datumRodjenja) : base(ime, prezime, email, mjestoRodjenja, datumRodjenja)
            {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Email = email;
            this.MjestoRodjenja = mjestoRodjenja;
            this.DatumRodjenja = datumRodjenja;

            }

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
