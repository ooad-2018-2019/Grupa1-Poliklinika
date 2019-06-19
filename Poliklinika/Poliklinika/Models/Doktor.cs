using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Doktor : Osoba, IUvidUKarton
    {
     /*  
      *  Mislim da nema potrebe za specijalnosti s obzirom da se treba mijenjati i u bazi i query structure
      *  Za to nemamo bas vremena..
      *  
      *  private String _specijalnost;

        public string Specijalnost { get => _specijalnost;
            set
            {
                if(!Poliklinika.isAlphaNumeric(value))
                {
                    throw new ArgumentException("Specijalnost nije validna");
                }
                else
                {
                    _specijalnost = value;
                }
            }
        }
        */
      

        public Doktor(string ime, string prezime, string email, string mjestoRodjenja, DateTime datumRodjenja) : base(ime, prezime, email, mjestoRodjenja, datumRodjenja)
            {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Email = email;
            this.MjestoRodjenja = mjestoRodjenja;
            this.DatumRodjenja = datumRodjenja;
        
            
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
    }
}
