using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Poliklinika.Models
{
    public class Poliklinika
    {
        private List<Osoba> _zaposlenici;
        private List<Pacijent> _pacijent;
        private List<ZdravstveniKarton> _kartoni;
        private List<Nalaz> _nalazi;

        public List<Osoba> Zaposlenici { get => _zaposlenici; set => _zaposlenici = value; }
        public List<Pacijent> Pacijent { get => _pacijent; set => _pacijent = value; }
        public List<ZdravstveniKarton> Kartoni { get => _kartoni; set => _kartoni = value; }
        public List<Nalaz> Nalazi { get => _nalazi; set => _nalazi = value; }

        public Poliklinika(List<Osoba> listaZaposlenika, List<Pacijent> listaPacijenata, List<ZdravstveniKarton> listKartona, List<Nalaz> listNalaza)
        {
            this.Zaposlenici = listaZaposlenika;
            this.Pacijent = listaPacijenata;
            this.Kartoni = listKartona;
            this.Nalazi = listNalaza;
        }

        public Poliklinika()
        {
        }

        public static Boolean isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            return rg.IsMatch(strToCheck);
        }
    }
}
