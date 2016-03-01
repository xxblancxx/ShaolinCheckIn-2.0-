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
    public class ClubsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Clubs
        public IQueryable<Club> GetClub()
        {
            return db.Club;
        }

        // GET: api/Clubs/5
        [ResponseType(typeof(Club))]
        public async Task<IHttpActionResult> GetClub(int id)
        {
            Club club = await db.Club.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            return Ok(club);
        }

        // PUT: api/Clubs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClub(int id, Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != club.Id)
            {
                return BadRequest();
            }

            db.Entry(club).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
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

        // POST: api/Clubs
        [ResponseType(typeof(Club))]
        public async Task<IHttpActionResult> PostClub(Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Club.Add(club);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [ResponseType(typeof(Club))]
        public async Task<IHttpActionResult> DeleteClub(int id)
        {
            Club club = await db.Club.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            db.Club.Remove(club);
            await db.SaveChangesAsync();

            return Ok(club);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClubExists(int id)
        {
            return db.Club.Count(e => e.Id == id) > 0;
        }
    }
}