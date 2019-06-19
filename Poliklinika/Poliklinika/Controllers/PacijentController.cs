using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Poliklinika.Controllers
{
    public class PacijentController : Controller
    {
        private Administrator administrator = Administrator.Instance();
        public static DateTime unosDatuma;
        public static DateTime unosVremena;



        
        public PacijentController()
        {
        }
    }
}
