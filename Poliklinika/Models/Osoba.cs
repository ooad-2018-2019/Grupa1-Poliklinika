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

    }
}
