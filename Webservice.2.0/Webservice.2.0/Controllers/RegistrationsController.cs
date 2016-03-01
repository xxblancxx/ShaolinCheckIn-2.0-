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
using Webservice._2._0;

namespace Webservice._2._0.Controllers
{
    public class RegistrationsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Registrations
        public IQueryable<Registration> GetRegistration()
        {
            return db.Registration;
        }

        // GET: api/Registrations/5
        [ResponseType(typeof(Registration))]
        public async Task<IHttpActionResult> GetRegistration(int id)
        {
            Registration registration = await db.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            return Ok(registration);
        }

        // PUT: api/Registrations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegistration(int id, Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registration.Id)
            {
                return BadRequest();
            }

            db.Entry(registration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
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

        // POST: api/Registrations
        [ResponseType(typeof(Registration))]
        public async Task<IHttpActionResult> PostRegistration(Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Registration.Add(registration);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = registration.Id }, registration);
        }

        // DELETE: api/Registrations/5
        [ResponseType(typeof(Registration))]
        public async Task<IHttpActionResult> DeleteRegistration(int id)
        {
            Registration registration = await db.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            db.Registration.Remove(registration);
            await db.SaveChangesAsync();

            return Ok(registration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistrationExists(int id)
        {
            return db.Registration.Count(e => e.Id == id) > 0;
        }
    }
}