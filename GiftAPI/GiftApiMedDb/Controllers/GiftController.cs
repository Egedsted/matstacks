using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftApiMedDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GiftController : ControllerBase
    {
        private GiftContext db;
        public GiftController(GiftContext db)
        {
            this.db = db;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(db.Gifts);
        }
        [HttpPost("Create")]
        public IActionResult Post([Bind("Title", "Description", "BoyGift", "GirlGift")] Gift g)
        {
            db.Add(g);
            db.SaveChanges();
            return Ok(db.Gifts);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Gift g)
        {
            var giftToUpdate = await db.Gifts.FindAsync(g.GiftNumber);
            if(giftToUpdate == null)
            {
                return NotFound();
            }
            db.Entry(giftToUpdate).Property("RowVersion").OriginalValue = g.RowVersion;
            if(await TryUpdateModelAsync<Gift>(giftToUpdate, "", x => x.BoyGift, x => x.GirlGift, x => x.Description, x => x.GiftNumber, x => x.Title, x => x.CreationDate))
            {
                try
                {
                    await db.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Gift)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The department was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Gift)databaseEntry.ToObject();
                        giftToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");

                    }
                }
            }
            db.Update(g);
            db.SaveChanges();
            return Ok(g);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Gift g)
        {
            db.Remove(g);
            db.SaveChanges();
            return Ok(g);
        }
    }
}
