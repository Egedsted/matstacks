using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPIUGE40PROGRAMMERINGKOMNU.Models
{
    public class CigarrettesDataContext : DbContext
    {
        public DbSet<PackCigarrette> Cigarrettes { get; set; }

        public CigarrettesDataContext(DbContextOptions<CigarrettesDataContext> options) : base (options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating (ModelBuilder m)
        {
            
            m.Seed();
        }
    }
}
