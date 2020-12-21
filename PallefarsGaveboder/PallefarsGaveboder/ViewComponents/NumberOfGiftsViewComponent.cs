using PallefarsGaveboder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PallefarsGaveboder.ViewComponents
{
    public class NumberOfGiftsViewComponent
    {
        private readonly GiftContext db;
        public NumberOfGiftsViewComponent(GiftContext db)
        {
            this.db = db;
        }
        public string Invoke()
        {
            return "    Number of gifts in storage: " + db.Gifts.Count().ToString();
        }
    }
}
