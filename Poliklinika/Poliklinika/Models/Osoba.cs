using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public abstract class Osoba 
    {
        private String ime { get; set; }
        private String prezime { get; set; }
        private String email { get; set; }
        private String mjestoRodjenja { get; set; }
        private DateTime datumRodjenja { get; set; }

        protected Osoba(string ime, string prezime, string email, string mjestoRodjenja, DateTime datumRodjenja)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
            this.mjestoRodjenja = mjestoRodjenja;
            this.datumRodjenja = datumRodjenja;
        }

        protected Osoba()
        {
        }
    }
}
