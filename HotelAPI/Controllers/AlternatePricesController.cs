using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using Hotel.Models;

namespace Hotel.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AlternatePricesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AlternatePrices
        [AllowAnonymous]
        public IQueryable<AlternatePrice> GetAlternatePrices()
        {
            return db.AlternatePrices;
        }

        // GET: api/AlternatePrices/5
        [AllowAnonymous]
        [ResponseType(typeof(AlternatePrice))]
        public async Task<IHttpActionResult> GetAlternatePrice(int id)
        {
            AlternatePrice alternatePrice = await db.AlternatePrices.FindAsync(id);
            if (alternatePrice == null)
            {
                return NotFound();
            }

            return Ok(alternatePrice);
        }

        // PUT: api/AlternatePrices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlternatePrice(int id, AlternatePrice alternatePrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alternatePrice.Id)
            {
                return BadRequest();
            }

            db.Entry(alternatePrice).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlternatePriceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AlternatePrices
        [ResponseType(typeof(AlternatePrice))]
        public async Task<IHttpActionResult> PostAlternatePrice(AlternatePrice alternatePrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AlternatePrices.Add(alternatePrice);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = alternatePrice.Id }, alternatePrice);
        }

        // DELETE: api/AlternatePrices/5
        [ResponseType(typeof(AlternatePrice))]
        public async Task<IHttpActionResult> DeleteAlternatePrice(int id)
        {
            AlternatePrice alternatePrice = await db.AlternatePrices.FindAsync(id);
            if (alternatePrice == null)
            {
                return NotFound();
            }

            db.AlternatePrices.Remove(alternatePrice);
            await db.SaveChangesAsync();

            return Ok(alternatePrice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlternatePriceExists(int id)
        {
            return db.AlternatePrices.Count(e => e.Id == id) > 0;
        }
    }
}