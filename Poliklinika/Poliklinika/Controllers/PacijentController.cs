using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTermin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Poliklinika.Controllers
{
    public class PacijentController : Controller
    {
        private Administrator administrator = Administrator.Instance();
        public static DateTime unosDatuma;


        
        public PacijentController()
        {
        }
    }
}
