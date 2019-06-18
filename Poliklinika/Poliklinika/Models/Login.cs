using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poliklinika.Models
{
    public class Login
    {
     public Osoba osoba { get; set; }
       public String username { get; set; }
       public String password { get; set; }

        public Login(Osoba osoba, string username, string password)
        {
            this.osoba = osoba;
            this.username = username;
            this.password = password;
        }




    }
}
