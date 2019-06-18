using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Lijek
    {
        private String _naziv;
        private DateTime _rok;
        private String _detalji;
        private int _kolicina;

        public String NazivLijeka { get;
            set
            {
                if(!Poliklinika.Models.Poliklinika.isAlphaNumeric(value))
                {
                    throw new ArgumentException("Naziv lijeka nije ispravan");
                }
                _naziv = value;
            }
        }
        public DateTime RokLijeka { get;
            set
            {
                if(value<=DateTime.Now)
                {
                    throw new ArgumentException("Rok lijeka ne moze biti stari datum");
                }

                _rok = value;
            }
        }
        public int Kolicina { get;
            set
            {
                if(value<0)
                {
                    throw new ArgumentException("Količina ne može biti negativna");
                }
                _kolicina = value;
            }
        } //odnosi se na kol u skladistu

        public string Detalji { get => _detalji; set => _detalji = value; }

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
