using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Poliklinika.Models
{
    public abstract class Osoba 
    {
        private String _ime;
        private String _prezime;
        private String _email;
        private DateTime _datumRodjenja;
        private String _mjestoRodjenja;

        public String Ime {  
            get
            {
                return _ime;
            }

            set
            {
                if(Poliklinika.isAlphaNumeric(value))
                {
                    _ime = value;
                }
                else
                {
                    throw new ArgumentException("Nije uneseno valjano ime");
                }
            }
        }
        public String Prezime {  get { return _prezime; }
            set
            {
                if(Poliklinika.isAlphaNumeric(value))
                {
                    _prezime = value;
                } else
                {
                    throw new ArgumentException("Nije uneseno valjano prezime");
                }
            }
        }
        public String Email
        {
            get { return _email; }
            set
            {
                if(!Poliklinika.isAlphaNumeric(value) && !value.Contains("@"))
                {
                    throw new ArgumentException("Nije unesena valjana email adresa");
                } else
                {
                    _email = value;
                }
            }
        }
        public String MjestoRodjenja { get { return _mjestoRodjenja; } set  { _mjestoRodjenja = value; } }
        public DateTime DatumRodjenja {  get { return _datumRodjenja; }
            set
            {
              if(value<=Convert.ToDateTime("01/01/1900") || value>=DateTime.Now)
                {
                    throw new ArgumentException("Nije unesen valjan datum rođenja");
                } else
                {
                    _datumRodjenja = value;
                }
            }
        }

        public Osoba(string ime, string prezime, string email, string mjestoRodjenja, DateTime datumRodjenja)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Email = email;
            this.MjestoRodjenja = mjestoRodjenja;
            this.DatumRodjenja = datumRodjenja;
        }

        public Osoba()
        {
        }
    }
}
