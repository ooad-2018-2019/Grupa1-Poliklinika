using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Poliklinika
    {
        public List<Osoba> listaZaposlenika { get; set; }
        public List<Pacijent> listaPacijenata { get; set; }
        public List<ZdravstveniKarton> listKartona { get; set; }
        public List<Nalaz> listNalaza { get; set; }

        public Poliklinika(List<Osoba> listaZaposlenika, List<Pacijent> listaPacijenata, List<ZdravstveniKarton> listKartona, List<Nalaz> listNalaza)
        {
            this.listaZaposlenika = listaZaposlenika;
            this.listaPacijenata = listaPacijenata;
            this.listKartona = listKartona;
            this.listNalaza = listNalaza;
        }

        public Poliklinika()
        {
        }
    }
}
