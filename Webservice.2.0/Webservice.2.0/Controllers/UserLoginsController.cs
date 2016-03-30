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
    public class UserLoginsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/UserLogins
        public IQueryable<UserLogin> GetUserLogins()
        {
            return db.UserLogins;
        }

        // GET: api/UserLogins/5
        [ResponseType(typeof(UserLogin))]
        public async Task<IHttpActionResult> GetUserLogin(int id)
        {
            UserLogin userLogin = await db.UserLogins.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return Ok(userLogin);
        }

        // PUT: api/UserLogins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserLogin(int id, UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userLogin.Id)
            {
                return BadRequest();
            }

            db.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(id))
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

        // POST: api/UserLogins
        [ResponseType(typeof(UserLogin))]
        public async Task<IHttpActionResult> PostUserLogin(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserLogins.Add(userLogin);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userLogin.Id }, userLogin);
        }

        // DELETE: api/UserLogins/5
        [ResponseType(typeof(UserLogin))]
        public async Task<IHttpActionResult> DeleteUserLogin(int id)
        {
            UserLogin userLogin = await db.UserLogins.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            db.UserLogins.Remove(userLogin);
            await db.SaveChangesAsync();

            return Ok(userLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserLoginExists(int id)
        {
            return db.UserLogins.Count(e => e.Id == id) > 0;
        }
    }
}