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
using SampleWebAPI.Models;

namespace SampleWebAPI.Controllers
{
    public class SavingsTypesController : ApiController
    {
        private SavingsDBContext db = null;

        public SavingsTypesController()
        { }
        public SavingsTypesController(SavingsDBContext dbcontext)
        {
            db = dbcontext;
        }
        // GET: api/SavingsTypes
        [Authorize]
        public IQueryable<SavingsType> GetSavingsTypes()
        {
            return db.SavingsTypes;
        }

        // GET: api/SavingsTypes/5
        [Authorize]
        [ResponseType(typeof(SavingsType))]
        public async Task<IHttpActionResult> GetSavingsType(int id)
        {
            SavingsType savingsType = await db.SavingsTypes.FindAsync(id);
            if (savingsType == null)
            {
              
                return NotFound();
            }

            return Ok(savingsType);
        }

        // PUT: api/SavingsTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSavingsType(int id, SavingsType savingsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savingsType.ID)
            {
                return BadRequest();
            }

            db.Entry(savingsType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavingsTypeExists(id))
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

        // POST: api/SavingsTypes
        [ResponseType(typeof(SavingsType))]
        public async Task<IHttpActionResult> PostSavingsType(SavingsType savingsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SavingsTypes.Add(savingsType);
            await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = savingsType.ID }, savingsType);
            return Ok<SavingsType>(savingsType);
        }

        // DELETE: api/SavingsTypes/5
        [ResponseType(typeof(SavingsType))]
        public async Task<IHttpActionResult> DeleteSavingsType(int id)
        {
            SavingsType savingsType = await db.SavingsTypes.FindAsync(id);
            if (savingsType == null)
            {
                return NotFound();
            }

            db.SavingsTypes.Remove(savingsType);
            await db.SaveChangesAsync();

            return Ok(savingsType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SavingsTypeExists(int id)
        {
            return db.SavingsTypes.Count(e => e.ID == id) > 0;
        }
    }
}