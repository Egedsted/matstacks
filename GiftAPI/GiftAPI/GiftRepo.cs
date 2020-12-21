using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftAPI
{
    public class GiftRepo
    {
        private List<Gift> gifts;
        private object myLock = new object();
        public GiftRepo()
        {
            gifts = new List<Gift> { new Gift {GiftNumber = 1, Title = "Iphone", BoyGift = true, GirlGift = true, CreationDate = DateTime.Now, Description = "nu med et batteri"},
                 new Gift {GiftNumber = 2, Title = "Brandbil", BoyGift = true, GirlGift = false, CreationDate = DateTime.Now, Description = "rød"},
                  new Gift {GiftNumber = 3, Title = "Brandbil", BoyGift = true, GirlGift = false, CreationDate = DateTime.Now, Description = "blå"},
                   new Gift {GiftNumber = 4, Title = "Barbie", BoyGift = false, GirlGift = true, CreationDate = DateTime.Now, Description = "med lyst hår"},
                    new Gift {GiftNumber = 5, Title = "Lego", BoyGift = true, GirlGift = true, CreationDate = DateTime.Now, Description = "stort legosæt"}
            };
        }
        public void Add(Gift g)
        {
            lock (myLock)
            {
                gifts.Add(g);
            }
        }
        public void Remove(Gift g)
        {
            lock (myLock)
            {
                gifts.Remove(g);
            }
        }
        public List<Gift> Get()
        {
            lock (myLock)
            {
                return gifts;
            }
        }
        public void Update(Gift g)
        {
            lock (myLock)
            {
                var oldGift = gifts.Find(x => x.GiftNumber == g.GiftNumber);
                gifts.Remove(oldGift);
                gifts.Add(g);
            }
        }
    }
}
