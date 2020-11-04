using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPIUGE40PROGRAMMERINGKOMNU.Models
{
    public static class ModelBuilderExtensions
    {
        
            public static void Seed(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<PackCigarrette>().HasData(
                    new PackCigarrette { Name = "Prince", NumberofCigs = 20, IsLongSmøg = false, IsSoftPack = false, Id = 1, Price = 55},
                    new PackCigarrette { Name = "Prince Light", NumberofCigs = 20, IsLongSmøg = false, IsSoftPack = false, Id = 2, Price = 55 },
                    new PackCigarrette { Name = "Prince", NumberofCigs = 20, IsLongSmøg = false, IsSoftPack = true, Id = 3, Price = 53 },
                    new PackCigarrette { Name = "Prince Light", NumberofCigs = 20, IsLongSmøg = false, IsSoftPack = true, Id = 4, Price = 53 },
                    new PackCigarrette { Name = "Camel Click", NumberofCigs = 20, IsLongSmøg = false, IsSoftPack = false, Id = 5, Price = 55 },
                    new PackCigarrette { Name = "Benson & Hedges", NumberofCigs = 20, IsLongSmøg = false, IsSoftPack = false, Id = 6, Price = 52 }
                    );
            }
        
    }
}
