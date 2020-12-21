using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftApiMedDb
{
        public class Gift
        {
            [Timestamp]
            public byte[] RowVersion { get; set; }
            public int GiftNumber { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime CreationDate { get; set; }
            public bool BoyGift { get; set; }
            public bool GirlGift { get; set; }
        }
}
