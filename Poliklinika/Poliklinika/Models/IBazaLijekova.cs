using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public interface IBazaLijekova
    {
        void dodajLijek(Lijek lijek);
        void ukloniLijek(Lijek lijek);

        void azurirajLijek(Lijek lijek);
        void dodijeliLijekTerapiji(Lijek lijek);

    }
}
