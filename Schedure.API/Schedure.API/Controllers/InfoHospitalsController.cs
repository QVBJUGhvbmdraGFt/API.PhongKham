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
using Schedure.API.Models;

namespace Schedure.API.Controllers
{
    [AdminAuthentication("SA", "BACSI", "YTA")]
    public class InfoHospitalsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/InfoHospitals
        public IQueryable<InfoHospital> GetInfoHospitals()
        {
            return db.InfoHospitals;
        }

        // GET: api/InfoHospitals/5
        [ResponseType(typeof(InfoHospital))]
        public async Task<IHttpActionResult> GetInfoHospital(int id)
        {
            InfoHospital infoHospital = await db.InfoHospitals.FindAsync(id);
            if (infoHospital == null)
            {
                return NotFound();
            }

            return Ok(infoHospital);
        }

        // PUT: api/InfoHospitals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInfoHospital(int id, InfoHospital infoHospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != infoHospital.IDInfoHospital)
            {
                return BadRequest();
            }

            db.Entry(infoHospital).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoHospitalExists(id))
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

        // POST: api/InfoHospitals
        [ResponseType(typeof(InfoHospital))]
        public async Task<IHttpActionResult> PostInfoHospital(InfoHospital infoHospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InfoHospitals.Add(infoHospital);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InfoHospitalExists(infoHospital.IDInfoHospital))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = infoHospital.IDInfoHospital }, infoHospital);
        }

        // DELETE: api/InfoHospitals/5
        [ResponseType(typeof(InfoHospital))]
        public async Task<IHttpActionResult> DeleteInfoHospital(int id)
        {
            InfoHospital infoHospital = await db.InfoHospitals.FindAsync(id);
            if (infoHospital == null)
            {
                return NotFound();
            }

            db.InfoHospitals.Remove(infoHospital);
            await db.SaveChangesAsync();

            return Ok(infoHospital);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InfoHospitalExists(int id)
        {
            return db.InfoHospitals.Count(e => e.IDInfoHospital == id) > 0;
        }
    }
}