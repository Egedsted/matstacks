using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MatStacks.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace MatStacks.Controllers
{

    public class ForumController : Controller
    { 
        public IActionResult Index()
        {
            List<Subject> subjects = new List<Subject> {
            new Subject {Title = "Opgaver", Id = 1, Description = "Here u shall add numbers together"},
            new Subject {Title = "Beviser", Id = 2, Description = "Here u shall prove numbers"},
            new Subject {Title = "Blandet", Id = 3, Description = "Here u shall put numbers together"},
            new Subject {Title = "Hjælp", Id = 4, Description = "Here u shall help numbers together"},
            new Subject {Title = "Statistik", Id = 5, Description = "Here u shall count numbers together and put them in a list"},
            new Subject {Title = "Funktioner", Id = 6, Description = "Here u shall function numbers together"}
            }; 
            return View(subjects);
        }



        //Smart pis man ka lukke sammen hvis man har lyst 
        #region 


        #endregion
    }
}
