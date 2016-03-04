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
using Hotel.Models;

namespace Hotel.Controllers
{
    [Authorize]
    public class ConfirmationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Confirmations
        public IQueryable<Confirmation> GetConfirmations()
        {
            return db.Confirmations;
        }

        // GET: api/Confirmations/5
        [ResponseType(typeof(Confirmation))]
        public async Task<IHttpActionResult> GetConfirmation(int id)
        {
            Confirmation confirmation = await db.Confirmations.FindAsync(id);
            if (confirmation == null)
            {
                return NotFound();
            }

            return Ok(confirmation);
        }

        // PUT: api/Confirmations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConfirmation(int id, Confirmation confirmation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != confirmation.Id)
            {
                return BadRequest();
            }

            db.Entry(confirmation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfirmationExists(id))
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

        // POST: api/Confirmations
        [ResponseType(typeof(Confirmation))]
        public async Task<IHttpActionResult> PostConfirmation(Confirmation confirmation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Confirmations.Add(confirmation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = confirmation.Id }, confirmation);
        }

        // DELETE: api/Confirmations/5
        [ResponseType(typeof(Confirmation))]
        public async Task<IHttpActionResult> DeleteConfirmation(int id)
        {
            Confirmation confirmation = await db.Confirmations.FindAsync(id);
            if (confirmation == null)
            {
                return NotFound();
            }

            db.Confirmations.Remove(confirmation);
            await db.SaveChangesAsync();

            return Ok(confirmation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfirmationExists(int id)
        {
            return db.Confirmations.Count(e => e.Id == id) > 0;
        }
    }
}