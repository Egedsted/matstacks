using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftApiMedDb
{
    public class GiftContext : DbContext
    {
        public DbSet<Gift> Gifts { get; set; }
        public GiftContext(DbContextOptions<GiftContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
