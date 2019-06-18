using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public abstract class Osoba 
    {
        private String ime { public get;
            public set
            {
                if(isAlphaNumeric(value))
                {
                    ime = value;
                }
                else
                {
                    throw new ArgumentException("Nije uneseno valjano ime");
                }
            }
        }
        private String prezime { public get; public set; }
        private String email { public get; public set; }
        private String mjestoRodjenja { public get;  public set; }
        private DateTime datumRodjenja { public get; public set; }

        public Osoba(string ime, string prezime, string email, string mjestoRodjenja, DateTime datumRodjenja)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
            this.mjestoRodjenja = mjestoRodjenja;
            this.datumRodjenja = datumRodjenja;
        }

        public Osoba()
        {
        }

        private static Boolean isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            return rg.IsMatch(strToCheck);
        }

    }
}
