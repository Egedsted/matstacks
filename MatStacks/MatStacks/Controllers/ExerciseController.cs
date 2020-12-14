using MatStacks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;

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

            var exercise = db.Exercise.Where(x => x.Id == id).Include(x => x.Answers).FirstOrDefault();
            if (exercise != null)
            {
                return View(exercise);
            }
            else
            {
                return NotFound();
            }
            
        }
        public IActionResult CreateAnswer(long id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAnswer(long id,[Bind("Body")] Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //Filling answer object with our data
            answer.Author = User.Identity.Name;
            answer.SubmissionDate = DateTime.Now;
            answer.Id = 0;
            var exercise = db.Exercise.Where(x => x.Id == id).Include(x => x.Answers).FirstOrDefault();
            if(exercise.Answers == null)
            {
                exercise.Answers = new List<Answer>();
            }
            exercise.Answers.Add(answer);
            db.Update(exercise);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = id });
        }
        public IActionResult Create(long id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Exercise exercise, long id)
        {
            
            exercise.Id = 0;
            if (!ModelState.IsValid)
            {
                return View();
            }
            exercise.Author = User.Identity.Name;
            exercise.CreateDate = DateTime.Now;
            var subject = db.ExerciseSubjects.Find(id);
            subject.Exercises.Add(exercise);
            db.ExerciseSubjects.Update(subject);
            await db.SaveChangesAsync();
            var list = db.Exercise.ToList();
            return RedirectToAction("Index", list[list.Count -1].Id);
            
        }
    }
}
