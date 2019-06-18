using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Doktor : IUvidUKarton
    {
        private String _specijalnost;

        public string Specijalnost { get => _specijalnost;
            set
            {
                if(!Poliklinika.Models.Poliklinika.isAlphanumeric(value))
                {
                    throw new ArgumentException("Specijalnost nije validna");
                }
                else
                {
                    _specijalnost = value;
                }
            }
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
