using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class Comment
    {
        public string ResponsText { get; set; }

        public string Author { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }

        public long Id { get; set; }


    }
}
