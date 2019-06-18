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
            this.Osoba = osoba;
            this.Username = username;
            this.Password = password;
        }

        public Osoba Osoba { get => _osoba; set => _osoba = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
