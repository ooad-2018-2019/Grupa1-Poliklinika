using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Administrator : IBazaLijekova, IBazaPoliklinike
    {
        public void azurirajLijek(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public Lijek dodajLijek()
        {

            throw new NotImplementedException();
        }

        //TODO : Skontat sta treba ovde...
        public void dodajPacijenta()
        {
            throw new NotImplementedException();
        }

        public void dodajZaposlenika()
        {
            throw new NotImplementedException();
        }

        public void dodijeliLijekTerapiji(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public void ukloniLijek(Lijek lijek)
        {
            throw new NotImplementedException();
        }

        public void ukloniPacijenta()
        {
            throw new NotImplementedException();
        }

        public void ukloniZaposlenika()
        {
            throw new NotImplementedException();
        }
    }
}
