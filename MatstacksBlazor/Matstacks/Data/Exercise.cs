using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matstacks.Data
{
    public class Exercise
    {
        public string Title { get; set; }
        public long Id { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public int Rating { get; set; }
        public string Difficulty { get; set; }
        public List<Answer> Answers { get; set; }
        public ExerciseSubject ExerciseSubject { get; set; }
    }
}
