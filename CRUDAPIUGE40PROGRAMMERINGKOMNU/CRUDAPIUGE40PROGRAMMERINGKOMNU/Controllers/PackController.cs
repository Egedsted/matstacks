using CRUDAPIUGE40PROGRAMMERINGKOMNU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiNET.Worlds;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPIUGE40PROGRAMMERINGKOMNU.Controllers
{
    [ApiController, Route("[controller]")]
    public class PackController : ControllerBase
    {

        private readonly CigarrettesDataContext db;


        public PackController(CigarrettesDataContext db)
        {
            this.db = db;

        }
        [HttpGet]
        public IActionResult GetAllPacks()
        {
           return Ok(db.Cigarrettes.ToList());
        }

        [HttpGet("{id}")] // samme måde at skrive get pis på som ovenover
        public IActionResult GetPack(int id)
        {
            
            return Ok(db.Cigarrettes.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostPackCigarrette (PackCigarrette packCigarrette)
        {
            db.Cigarrettes.Add(packCigarrette);
            await db.SaveChangesAsync();

            return CreatedAtAction(
                "GetPack",
                new { id = packCigarrette.Id },
                packCigarrette);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackCigarrette(int id, [FromBody] PackCigarrette packCigarrette)
        {
            if (id != packCigarrette.Id)
            {
                return BadRequest();
            }

            var packCigarretToUpdate = await db.Cigarrettes.FindAsync(id);
            if (db.Cigarrettes.Find(id) == null)
            {
                return NotFound();
            }

            db.Entry(packCigarretToUpdate).Property("RowVersion").OriginalValue = packCigarrette.RowVersion;
          
            if(await TryUpdateModelAsync<PackCigarrette>(packCigarretToUpdate, "", c => c.Name, c => c.Id, c => c.IsLongSmøg, c => c.IsSoftPack, c => c.NumberofCigs, c => c.Price))
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (PackCigarrette)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The department was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (PackCigarrette)databaseEntry.ToObject();
                        packCigarretToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                        
                    }
            }

            return NoContent();


        }







        [HttpDelete("{id}")]
        public async Task<ActionResult<PackCigarrette>> DeleteCigarrette(int id)
        {
            var smøg = await db.Cigarrettes.FindAsync(id);
            if (smøg == null)
            {
                return NotFound(); 
            }
            db.Cigarrettes.Remove(smøg);
            await db.SaveChangesAsync();

                return smøg; 
        }

    }
}
