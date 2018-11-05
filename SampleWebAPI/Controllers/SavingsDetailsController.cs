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
    [Authorize]
    public class SavingsDetailsController : ApiController
    {
        private SavingsDBContext db = null;

      

        public SavingsDetailsController()
        { }
        public SavingsDetailsController(SavingsDBContext dbcontext)
        {
            db = dbcontext;
        }
        // GET: api/SavingsDetails
        public IQueryable<SavingsDetails> GetSavingsDetails()
        {
            return db.SavingsDetails;
        }

        // GET: api/SavingsDetails/5
        [ResponseType(typeof(SavingsDetails))]
        public async Task<IHttpActionResult> GetSavingsDetails(int id)
        {
            SavingsDetails savingsDetails = await db.SavingsDetails.FindAsync(id);
            if (savingsDetails == null)
            {
                return NotFound();
            }

            return Ok(savingsDetails);
        }

        // PUT: api/SavingsDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSavingsDetails(int id, SavingsDetails savingsDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savingsDetails.ID)
            {
                return BadRequest();
            }

            db.Entry(savingsDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavingsDetailsExists(id))
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

        // POST: api/SavingsDetails
        [ResponseType(typeof(SavingsDetails))]
        public async Task<IHttpActionResult> PostSavingsDetails(SavingsDetails savingsDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SavingsDetails.Add(savingsDetails);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = savingsDetails.ID }, savingsDetails);
        }

        // DELETE: api/SavingsDetails/5
        [ResponseType(typeof(SavingsDetails))]
        public async Task<IHttpActionResult> DeleteSavingsDetails(int id)
        {
            SavingsDetails savingsDetails = await db.SavingsDetails.FindAsync(id);
            if (savingsDetails == null)
            {
                return NotFound();
            }

            db.SavingsDetails.Remove(savingsDetails);
            await db.SaveChangesAsync();

            return Ok(savingsDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SavingsDetailsExists(int id)
        {
            return db.SavingsDetails.Count(e => e.ID == id) > 0;
        }
    }
}