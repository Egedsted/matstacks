using MatStacksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MatStacksAPI.Controllers
{
    [ApiController, Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        //:))))))
        private ExerciseSubjectDataContext db;
        public ExerciseController(ExerciseSubjectDataContext db)
        {
            this.db = db;
        }

        public IActionResult GetAllExercises()
        {
            return Ok(db.Exercises.ToList());
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(long id)
        {
            var result = db.Exercises.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult CreateExercise(Exercise exercise)
        {
            db.Exercises.Add(exercise);
            db.SaveChanges();
            return CreatedAtAction("GetById", new { id = exercise.Id }, exercise);
        }

        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteExercise(long id)
        {
            var result = db.Exercises.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            db.Exercises.Remove(result);
            db.SaveChanges();
            return Ok(result);
        }
    }
}
