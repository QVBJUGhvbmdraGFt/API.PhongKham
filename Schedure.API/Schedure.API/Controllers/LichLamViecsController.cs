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
    public class LichLamViecsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/LichLamViecs
        [ResponseType(typeof(List<LichLamViecDTO>))]
        [BasicAuthentication]
        public List<LichLamViecDTO> GetLichLamViecs()
        {
            var lst = new List<LichLamViecDTO>();
            foreach (var item in db.LichLamViecs)
            {
                lst.Add(ConvertToLichLamViecDTO(item));
            }
            return lst;
        }

        public static LichLamViecDTO ConvertToLichLamViecDTO(LichLamViec item)
        {
            return new LichLamViecDTO
            {
                CreaterDate = item.CreaterDate,
                Creater_Id = item.Creater_Id,
                IDDoctor = item.IDDoctor,
                IDLich = item.IDLich,
                IDTimeSlot = item.IDTimeSlot,
                Time = item.Time,
                TimeSlot = TimeSlotsController.ConvertToTimeSlotDTO(item.TimeSlot),
                Doctor = DoctorsController.ConvertToDoctorDTO(item.Doctor)
            };
        }

        // GET: api/LichLamViecs/5
        [HttpGet]
        [ResponseType(typeof(LichLamViecDTO))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> GetLichLamViec(int id)
        {
            LichLamViec LichLamViec = await db.LichLamViecs.FindAsync(id);
            if (LichLamViec == null)
            {
                return NotFound();
            }

            return Ok(ConvertToLichLamViecDTO(LichLamViec));
        }

        // PUT: api/LichLamViecs/5
        [AdminAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutLichLamViec(int id, LichLamViec LichLamViec)
        {
            if (id != LichLamViec.IDLich)
            {
                return BadRequest();
            }

            db.Entry(LichLamViec).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichLamViecExists(id))
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

        // POST: api/LichLamViecs
        [ResponseType(typeof(string))]
        [AdminAuthentication("SA", "BACSI")]
        public async Task<IHttpActionResult> PostLichLamViec(LichLamViec LichLamViec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LichLamViecs.Add(LichLamViec);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LichLamViecExists(LichLamViec.IDLich))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = LichLamViec.IDLich }, LichLamViec);
        }

        // DELETE: api/LichLamViecs/5
        [AdminAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteLichLamViec(int id)
        {
            LichLamViec LichLamViec = await db.LichLamViecs.FindAsync(id);
            if (LichLamViec == null)
            {
                return NotFound();
            }

            db.LichLamViecs.Remove(LichLamViec);
            await db.SaveChangesAsync();

            return Ok("SUCCESS");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LichLamViecExists(int id)
        {
            return db.LichLamViecs.Count(e => e.IDLich == id) > 0;
        }
    }
}