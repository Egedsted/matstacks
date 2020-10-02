using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MatStacks.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public double PostScore
        {
            get
            {
                if (Ratings.Count == 0)
                {
                    return 0;
                } 
                
                return Ratings.Average(x => x.UserRating); }
        }

        public List<Rating> Ratings { get; set; } = new List<Rating>();

        public Rating NewRating { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Comment NewComment { get; set; }

    }
}
