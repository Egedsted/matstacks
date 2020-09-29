using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment> { new Comment {Author = "Din mor", Date = DateTime.Now, ResponsText = "Nej jeg tror du tager fejl", Score = 3 },
            new Comment { Author = "Din far", Date = DateTime.Now, ResponsText = "Ja jeg tror du tager fejl", Score = 1337 }};

    }
}
