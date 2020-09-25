﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment> { new Comment {Author = "Din mor", Date = DateTime.Now, Id = 1, ResponsText = "Nej jeg tror du tager fejl", Score = 3 },
            new Comment { Author = "Din far", Date = DateTime.Now, Id = 2, ResponsText = "Ja jeg tror du tager fejl", Score = 1337 }};

    }
}