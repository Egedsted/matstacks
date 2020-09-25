using MatStacks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MatStacks.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SubjectDataContext db;
        public SubjectController(SubjectDataContext db)
        {
            this.db = db;
        }
        public IActionResult Index(long? id)
        {
            var subject = db.Subjects.Where(x => x.Id == id)
                .Include(x => x.Posts).FirstOrDefault();
            return View(subject);
        }
    }
}
