using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PallefarsGaveboder.Models;

namespace PallefarsGaveboder.Controllers
{
    public class GiftController : Controller
    {
        private readonly ILogger<GiftController> _logger;
        //private readonly GiftContext db;
        private readonly GiftWrapper db;

        public GiftController(ILogger<GiftController> logger, GiftWrapper db)
        {
            _logger = logger;
            //this.db = db;
            this.db = db;
        }

        public IActionResult Index()
        {
            //return View(db.Gifts.ToList());
            return View(db.GetAll());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new Gift());
        }
        [HttpPost, Authorize(Roles ="Admin")] 
        public async Task<IActionResult> Create(Gift gift)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            gift.CreationDate = DateTime.Now;
            /*
            db.Gifts.Add(gift);
            await db.SaveChangesAsync();
            */
            await db.Add(gift);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Girls()
        {
            //return View(db.Gifts.Where(x => x.GirlGift == true).ToList());
            var girlList = await db.GetAll();
            return View(girlList.AsQueryable().Where(x => x.GirlGift == true).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("/gift/{start}/{end}")]
        public async Task<IActionResult> ByDate(string start, string end)
        {
            try
            {
                var startDate = DateTime.Parse(start);
                var endDate = DateTime.Parse(end);
                //return View(db.Gifts.Where(x => x.CreationDate >= startDate && x.CreationDate <= endDate));
                var list = await db.GetAll();
                return View(list.AsQueryable().Where(x => x.CreationDate >= startDate && x.CreationDate <= endDate));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
    }
}
