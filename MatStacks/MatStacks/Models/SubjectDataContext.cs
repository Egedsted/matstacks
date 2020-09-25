using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class SubjectDataContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set;}

        public SubjectDataContext(DbContextOptions<SubjectDataContext>options) : base (options)
        {
           //Tjekker om der findes en database, gør der ikke det - så danner den en ny database 
            Database.EnsureCreated(); 

        }
    }
}
