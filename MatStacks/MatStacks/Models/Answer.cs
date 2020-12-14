using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Author { get; set; }
        [Required]
        public string Body { get; set; }
        public bool IsReviewed { get; set; }
        public int Points { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
