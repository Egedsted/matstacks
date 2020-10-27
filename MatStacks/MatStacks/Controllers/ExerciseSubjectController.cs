using MatStacks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Controllers
{
    public class ExerciseSubjectController : Controller
    {
        private readonly ExerciseSubjectDataContext db;
        public ExerciseSubjectController(ExerciseSubjectDataContext db)
        {
            this.db = db;
        }
        public IActionResult Index(long? id)
        {
            var exerciseSubject = db.ExerciseSubjects.Where(x => x.Id == id)
                .Include(x => x.Exercises).FirstOrDefault();
            return View(exerciseSubject);
        }
    }
}
