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
    public class StudentRegistrationsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/StudentRegistrations
        public IQueryable<StudentRegistration> GetStudentRegistrations()
        {
            return db.StudentRegistrations;
        }

        // GET: api/StudentRegistrations/5
        [ResponseType(typeof(StudentRegistration))]
        public async Task<IHttpActionResult> GetStudentRegistration(int id)
        {
            StudentRegistration studentRegistration = await db.StudentRegistrations.FindAsync(id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            return Ok(studentRegistration);
        }

        // PUT: api/StudentRegistrations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudentRegistration(int id, StudentRegistration studentRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentRegistration.Id)
            {
                return BadRequest();
            }

            db.Entry(studentRegistration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentRegistrationExists(id))
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

        // POST: api/StudentRegistrations
        [ResponseType(typeof(StudentRegistration))]
        public async Task<IHttpActionResult> PostStudentRegistration(StudentRegistration studentRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentRegistrations.Add(studentRegistration);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentRegistrationExists(studentRegistration.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = studentRegistration.Id }, studentRegistration);
        }

        // DELETE: api/StudentRegistrations/5
        [ResponseType(typeof(StudentRegistration))]
        public async Task<IHttpActionResult> DeleteStudentRegistration(int id)
        {
            StudentRegistration studentRegistration = await db.StudentRegistrations.FindAsync(id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            db.StudentRegistrations.Remove(studentRegistration);
            await db.SaveChangesAsync();

            return Ok(studentRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentRegistrationExists(int id)
        {
            return db.StudentRegistrations.Count(e => e.Id == id) > 0;
        }
    }
}