using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int UserType { get; set; } //TODO: IDENTITY INJECTION?

        public int Points { get; set; }

        public long Id { get; set; }
    }
}
