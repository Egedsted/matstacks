using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class ExerciseSubject
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        public long Id { get; set; }
    }
}
