using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class Assignment
    {
        public long Id { get; set; }
        public string AssignmentType { get; set; }

        public string Author { get; set; }

        public int Difficulty { get; set; }
    }
}
