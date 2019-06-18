using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Login
    {
        private Osoba _osoba;
        private String _username;
        private String _password;

        public Login(Osoba osoba, string username, string password)
        {
            this.osoba = osoba;
            this.username = username;
            this.password = password;
        }

        public Osoba osoba { get => _osoba; set => _osoba = value; }
        public string username { get => _username; set => _username = value; }
        public string password { get => _password; set => _password = value; }
    }
}
