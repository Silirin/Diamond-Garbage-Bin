using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;

namespace Test2.Controllers
{
    public class HomeController : Controller
    {
        static List<Computer> comps = new List<Computer>();
        static HomeController()
        {
            comps.Add(new Computer { Id = 1, Name = "Apple II", Company = "Apple", Year = 1977 });
            comps.Add(new Computer { Id = 2, Name = "Macintosh", Company = "Apple", Year = 1983 });
            comps.Add(new Computer { Id = 3, Name = "IBM PC", Company = "IBM", Year = 1981 });
            comps.Add(new Computer { Id = 4, Name = "Altair", Company = "MITS", Year = 1975 });
            comps.Add(new Computer { Id = 5, Name = "???", Company = "???", Year = 2000 });
        }
        public ActionResult Index()
        {
            return View(comps);
        }
        public ActionResult Details(int id)
        {
            Computer c = comps.FirstOrDefault(com => com.Id == id);
            if (c != null)
                return PartialView(c);
            return HttpNotFound();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
