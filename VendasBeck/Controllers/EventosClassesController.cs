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
using VendasBeck.Models;

namespace VendasBeck.Controllers
{
    public class EventosClassesController : ApiController
    {
        private VendasBeckContext db = new VendasBeckContext();

        // GET: api/EventosClasses
        public IQueryable<EventosClass> GetEventosClasses()
        {
            return db.EventosClasses;
        }

        // GET: api/EventosClasses/5
        [ResponseType(typeof(EventosClass))]
        public async Task<IHttpActionResult> GetEventosClass(int id)
        {
            EventosClass eventosClass = await db.EventosClasses.FindAsync(id);
            if (eventosClass == null)
            {
                return NotFound();
            }

            return Ok(eventosClass);
        }

        // PUT: api/EventosClasses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventosClass(int id, EventosClass eventosClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventosClass.idEvento)
            {
                return BadRequest();
            }

            db.Entry(eventosClass).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventosClassExists(id))
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

        // POST: api/EventosClasses
        [ResponseType(typeof(EventosClass))]
        public async Task<IHttpActionResult> PostEventosClass(EventosClass eventosClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventosClasses.Add(eventosClass);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventosClass.idEvento }, eventosClass);
        }

        // DELETE: api/EventosClasses/5
        [ResponseType(typeof(EventosClass))]
        public async Task<IHttpActionResult> DeleteEventosClass(int id)
        {
            EventosClass eventosClass = await db.EventosClasses.FindAsync(id);
            if (eventosClass == null)
            {
                return NotFound();
            }

            db.EventosClasses.Remove(eventosClass);
            await db.SaveChangesAsync();

            return Ok(eventosClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventosClassExists(int id)
        {
            return db.EventosClasses.Count(e => e.idEvento == id) > 0;
        }
    }
}