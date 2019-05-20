using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class ZdravstveniKarton
    {
        public Pacijent pacijent { get; set; }
        public Doktor odgovorniDoktor { get; set; }
        public List<Terapija> listaTerapija { get; set; }
        public List<Nalaz> listaNalaza { get; set; }

        public ZdravstveniKarton(Pacijent pacijent, Doktor odgovorniDoktor, List<Terapija> listaTerapija, List<Nalaz> listaNalaza)
        {
            this.pacijent = pacijent;
            this.odgovorniDoktor = odgovorniDoktor;
            this.listaTerapija = listaTerapija;
            this.listaNalaza = listaNalaza;
        }

        public ZdravstveniKarton()
        {
        }
    }
}
