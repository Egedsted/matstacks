using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    
    public class Subject
    {
        
        public string Title { get; set; }

        public string Description { get; set; }

        public List<Post> posts = new List<Post>();

        public long Id { get; set; }
    }
}
