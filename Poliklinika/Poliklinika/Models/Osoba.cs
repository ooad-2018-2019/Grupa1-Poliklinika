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
        public String ime {  
get {
                return _ime;
                }
set
            {
                if(isAlphaNumeric(value))
                {
                    _ime = value;
                }
                else
                {
                    throw new ArgumentException("Nije uneseno valjano ime");
                }
            }
        }
        public String prezime {  get;  set; }
        public String email {  get;  set; }
        public String mjestoRodjenja {  get;   set; }
        public DateTime datumRodjenja {  get;  set; }

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
