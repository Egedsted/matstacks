using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PallefarsGaveboder.Models
{
    public class Gift
    {
        [Key]
        public int GiftNumber { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool BoyGift { get; set; }
        public bool GirlGift { get; set; }
    }
}
