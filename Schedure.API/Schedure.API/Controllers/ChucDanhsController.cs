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
    public class ChucDanhsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/ChucDanhs
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(List<ChucDanhDTO>))]
        public List<ChucDanhDTO> GetChucDanhs()
        {
            var lst = new List<ChucDanhDTO>();
            foreach (var item in db.ChucDanhs.Where(q => q.Status != "DELETE"))
            {
                lst.Add(ConvertToChucDanhDTO(item));
            }
            return lst;
        }

        public static ChucDanhDTO ConvertToChucDanhDTO(ChucDanh item)
        {
            if (item == null) return null;
            return new ChucDanhDTO
            {
                IDChucDanh = item.IDChucDanh,
                Name = item.Name,
                Status = item.Status,
                MoTa = item.MoTa
            };
        }

        // GET: api/ChucDanhs/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        public async Task<IHttpActionResult> GetChucDanh(int id)
        {
            ChucDanh ChucDanh = await db.ChucDanhs.FindAsync(id);

            if (ChucDanh == null || ChucDanh.Status == "DELETE")
            {
                return NotFound();
            }

            return Ok(ConvertToChucDanhDTO(ChucDanh));
        }

        // PUT: api/ChucDanhs/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutChucDanh(int id, ChucDanh ChucDanh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ChucDanh.IDChucDanh)
            {
                return BadRequest();
            }

            db.Entry(ChucDanh).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucDanhExists(id))
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

        // POST: api/ChucDanhs
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostChucDanh(ChucDanh ChucDanh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChucDanhs.Add(ChucDanh);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChucDanhExists(ChucDanh.IDChucDanh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ChucDanh.IDChucDanh }, ChucDanh);
        }

        // DELETE: api/ChucDanhs/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteChucDanh(int id)
        {
            ChucDanh ChucDanh = await db.ChucDanhs.FindAsync(id);
            if (ChucDanh == null)
            {
                return NotFound();
            }

            ChucDanh.Status = "DELETE";
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

        private bool ChucDanhExists(int id)
        {
            return db.ChucDanhs.Count(e => e.IDChucDanh == id) > 0;
        }
    }
}