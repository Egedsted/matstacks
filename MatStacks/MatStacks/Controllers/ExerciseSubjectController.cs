using MatStacks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace MatStacks.Controllers
{
    public class ExerciseSubjectController : Controller
    {
        private readonly ExerciseSubjectDataContext db;
        public ExerciseSubjectController(ExerciseSubjectDataContext db)
        {
            this.db = db;
        }
        
        public IActionResult Index()
		{
            return View(db.ExerciseSubjects.ToArray());
		} 
        
        public IActionResult Subject(long Id)
		{
            return View(db.ExerciseSubjects.Where(x => x.Id == Id).Include( x => x.Exercises).FirstOrDefault());
		}
        public IActionResult Create()
		{
            return View();
		}

        [HttpPost]
        public IActionResult Create(ExerciseSubject exerciseSubject)
		{
            if (!ModelState.IsValid)
                return View();

            db.ExerciseSubjects.Add(exerciseSubject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Exercise(long? id)
        {
            var exerciseSubject = db.ExerciseSubjects.Where(x => x.Id == id)
                .Include(x => x.Exercises).FirstOrDefault();
            return View(exerciseSubject);
        }
    }
}
