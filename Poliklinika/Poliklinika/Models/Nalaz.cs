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

        public DateTime DatumNalaza { get;
            set
            {
                if(value>=DateTime.Now)
                {
                    throw new ArgumentException("Nalaz ne može biti urađen u budućnosti");
                }
                _datumNalaza = value;
            }
        }
        public String DetaljiNalaza { get; set; }
        public String TipNalaza { get; set; }

        public Nalaz(String tip, DateTime datumNalaza, string detaljiNalaza)
        {
            this.TipNalaza = tip;
            this.datumNalaza = datumNalaza;
            this.detaljiNalaza = detaljiNalaza;
        }

        public Nalaz()
        {
        
        }
    }
}
