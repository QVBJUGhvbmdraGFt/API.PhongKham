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
using SchedureDTO;

namespace Schedure.API.Controllers
{
    public class SpeciasController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/Specias
        [BasicAuthentication]
        public List<SpeciaDTO> GetSpecias()
        {
            var lst = new List<SpeciaDTO>();
            foreach (var item in db.Specias)
            {
                lst.Add(ConvertToSpeciaDTO(item));
            }
            return lst;
        }

        private SpeciaDTO ConvertToSpeciaDTO(Specia item)
        {
            return new SpeciaDTO
            {
                Avatar = item.Avatar,
                IDSpecia = item.IDSpecia,
                Name = item.Name,
                TimeUse = item.TimeUse,
                Status = item.Status,
            };
        }

        // GET: api/Specias/5
        [ResponseType(typeof(SpeciaDTO))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> GetSpecia(int id)
        {
            Specia specia = await db.Specias.FindAsync(id);
            if (specia == null)
            {
                return NotFound();
            }

            return Ok(ConvertToSpeciaDTO(specia));
        }

        // PUT: api/Specias/5
        [BasicAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutSpecia(int id, Specia specia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specia.IDSpecia)
            {
                return BadRequest();
            }

            db.Entry(specia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeciaExists(id))
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

        // POST: api/Specias
        [BasicAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostSpecia(Specia specia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specias.Add(specia);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpeciaExists(specia.IDSpecia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = specia.IDSpecia }, specia);
        }

        // DELETE: api/Specias/5
        [BasicAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteSpecia(int id)
        {
            Specia specia = await db.Specias.FindAsync(id);
            if (specia == null)
            {
                return NotFound();
            }

            db.Specias.Remove(specia);
            await db.SaveChangesAsync();

            return Ok(specia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpeciaExists(int id)
        {
            return db.Specias.Count(e => e.IDSpecia == id) > 0;
        }
    }
}