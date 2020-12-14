using MatStacks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly ExerciseSubjectDataContext db;
        public ExerciseController(ExerciseSubjectDataContext db)
        {
            this.db = db;
        }
        public IActionResult Index(long id)
        {
            return View(db.Exercises.Find(id));
        }

        public IActionResult Create(long id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Exercise exercise, long id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            exercise.Author = User.Identity.Name;
            exercise.CreateDate = DateTime.Now;
            db.Exercises.Add(exercise);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", db.Exercises.Find(exercise).Id);
        }
    }
}
