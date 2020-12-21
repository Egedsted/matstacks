using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GiftController : ControllerBase
    {
        private GiftRepo db;
        public GiftController(GiftRepo db)
        {
            this.db = db;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(db.Get());
        }
        [HttpPost("Create")]
        public IActionResult Post([Bind(include: "Title, Description, BoyGift, GirlGift")] Gift g)
        {
            g.CreationDate = DateTime.Now;
            db.Add(g);
            return Ok(db.Get());
        }
        [HttpPut("Update")]
        public IActionResult Update(Gift g)
        {
            db.Update(g);
            return Ok(g);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete (int id)
        {
            var g = db.Get().Find(x => x.GiftNumber == id);
            db.Remove(g);
            return Ok(g);
        }
    }
}
