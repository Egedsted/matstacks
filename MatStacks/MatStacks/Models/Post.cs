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

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Comment NewComment { get; set; }

    }
}
