using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPIUGE40PROGRAMMERINGKOMNU.Models
{
    public class PackCigarrette
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string Name { get; set; }
        
        public int Id { get; set; }
       
        public int NumberofCigs { get; set; }
        
        public double Price { get; set; }
        
        public bool IsLongSmøg { get; set; }
        
        public bool IsSoftPack { get; set; }

        
        

    }
}
