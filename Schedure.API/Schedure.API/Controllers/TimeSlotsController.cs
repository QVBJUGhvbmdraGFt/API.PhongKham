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
    public class TimeSlotsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/TimeSlots
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(List<TimeSlotDTO>))]
        public List<TimeSlotDTO> GetTimeSlots()
        {
            var lst = new List<TimeSlotDTO>();
            foreach (var item in db.TimeSlots)
            {
                lst.Add(ConvertToTimeSlotDTO(item));
            }
            return lst;
        }

        public static TimeSlotDTO ConvertToTimeSlotDTO(TimeSlot item)
        {
            return new TimeSlotDTO
            {
                IDTimeSlot = item.IDTimeSlot,
                Name = item.Name,
                HourEnd = item.HourEnd,
                HourStart = item.HourStart,
            };
        }

        // GET: api/TimeSlots/5
        [ResponseType(typeof(TimeSlotDTO))]
        [AdminAuthentication("SA", "BACSI", "YTA")]
        public async Task<IHttpActionResult> GetTimeSlot(int id)
        {
            TimeSlot TimeSlot = await db.TimeSlots.FindAsync(id);
            if (TimeSlot == null)
            {
                return NotFound();
            }

            return Ok(ConvertToTimeSlotDTO(TimeSlot));
        }

        // PUT: api/TimeSlots/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutTimeSlot(int id, TimeSlot TimeSlot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != TimeSlot.IDTimeSlot)
            {
                return BadRequest();
            }

            db.Entry(TimeSlot).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSlotExists(id))
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

        // POST: api/TimeSlots
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostTimeSlot(TimeSlot TimeSlot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeSlots.Add(TimeSlot);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TimeSlotExists(TimeSlot.IDTimeSlot))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = TimeSlot.IDTimeSlot }, TimeSlot);
        }

        // DELETE: api/TimeSlots/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteTimeSlot(int id)
        {
            TimeSlot TimeSlot = await db.TimeSlots.FindAsync(id);
            if (TimeSlot == null)
            {
                return NotFound();
            }

            db.TimeSlots.Remove(TimeSlot);
            await db.SaveChangesAsync();

            return Ok(TimeSlot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeSlotExists(int id)
        {
            return db.TimeSlots.Count(e => e.IDTimeSlot == id) > 0;
        }
    }
}