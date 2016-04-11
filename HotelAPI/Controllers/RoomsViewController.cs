using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;

namespace Hotel.Controllers
{
    [RoutePrefix("Rooms")]
    public class RoomsViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rooms
        [Route]
        public async Task<ActionResult> Index()
        {
            return View(await db.Rooms.ToListAsync());
        }

        // GET: Rooms/5
        [Route("{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/New
        [Route("New")]
        public ActionResult New()
        {
            return View();
        }

        //// POST: RoomsView/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,RoomNumber,NumPersons,MinPrice")] Room room)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Rooms.Add(room);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(room);
        //}

        // GET: RoomsView/Edit/5
        [Route("{id:int}/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: RoomsView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,RoomNumber,NumPersons,MinPrice")] Room room)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(room).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(room);
        //}

        // GET: RoomsView/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Room room = await db.Rooms.FindAsync(id);
        //    if (room == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(room);
        //}

        // POST: RoomsView/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Room room = await db.Rooms.FindAsync(id);
        //    db.Rooms.Remove(room);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
