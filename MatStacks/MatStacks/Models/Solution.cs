using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class Solution
    {
        public long Id { get; set; }
        public string Answer { get; set; }

        public int Score { get; set; }

        public string Author { get; set; }
    }
}
