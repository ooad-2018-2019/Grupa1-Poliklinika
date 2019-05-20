using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Lijek
    {
        public String nazivLijeka { get; set; }
        public DateTime rokLijeka { get; set; }
        public String detaljiLijeka { get; set; }
        public int kolicina { get; set; } //odnosi se na kol u skladistu

        public Lijek(string nazivLijeka, DateTime rokLijeka, string detaljiLijeka, int kolicina)
        {
            this.nazivLijeka = nazivLijeka;
            this.rokLijeka = rokLijeka;
            this.detaljiLijeka = detaljiLijeka;
            this.kolicina = kolicina;
        }

        public Lijek()
        {
        }
    }
}
