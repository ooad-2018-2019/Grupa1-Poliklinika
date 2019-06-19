using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Nalaz
    {
        private String _tipNalaza;
        private String _detaljiNalaza;
        private DateTime _datumNalaza;

        public DateTime DatumNalaza { get { return _datumNalaza; }
            set
            {
                if(value>=DateTime.Now)
                {
                    throw new ArgumentException("Nalaz ne može biti urađen u budućnosti");
                }
                _datumNalaza = value;
            }
        }

        public string TipNalaza { get => _tipNalaza; set => _tipNalaza = value; }
        public string DetaljiNalaza { get => _detaljiNalaza; set => _detaljiNalaza = value; }

        public Nalaz(String tip, DateTime datumNalaza, string detaljiNalaza)
        {
            this.TipNalaza = tip;
            this.DatumNalaza = datumNalaza;
            this.DetaljiNalaza = detaljiNalaza;
        }

        public Nalaz()
        {
        
        }
    }
}
