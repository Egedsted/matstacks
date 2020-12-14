using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class ExerciseSubjectDataContext : DbContext
    {
        public DbSet<ExerciseSubject> ExerciseSubjects { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Answer> Answer { get; set; }

        public ExerciseSubjectDataContext(DbContextOptions<ExerciseSubjectDataContext> options) : base(options)
        {
            //Tjekker om der findes en database, gør der ikke det - så danner den en ny database 
            Database.EnsureCreated();

        }
    }
}
