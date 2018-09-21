using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
    public class ChuyenKhoasController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/ChuyenKhoas
        [BasicAuthentication]
        [ResponseType(typeof(List<ChuyenKhoaDTO>))]
        public List<ChuyenKhoaDTO> GetChuyenKhoas()
        {
            try
            {
                var data = db.ChuyenKhoas.Where(q => q.Status != "DELETE").ToList();
                var res = data.Select(q => ConvertToChuyenKhoaDTOFull(q)).ToList();
                return res;
            }
            catch (Exception ex)
            {
                ex.DebugLog();
                return null;
            }
        }

        [AdminAuthentication]
        [HttpGet]
        [ResponseType(typeof(List<ChuyenKhoaDTO>))]
        public List<ChuyenKhoaDTO> NVGetAll()
        {
            try
            {
                var data = db.ChuyenKhoas.Where(q => q.Status != "DELETE").ToList();
                var res = data.Select(q => ConvertToChuyenKhoaDTOFull(q)).ToList();
                return res;
            }
            catch (Exception ex)
            {
                ex.DebugLog();
                return null;
            }
        }

        public static ChuyenKhoaDTO ConvertToChuyenKhoaDTO(ChuyenKhoa item)
        {
            if (item == null) return null;
            return new ChuyenKhoaDTO
            {
                Avatar = item.Avatar,
                IDChuyenKhoa = item.IDChuyenKhoa,
                Name = item.Name,
                TimeUse = item.TimeUse,
                Status = item.Status,
            };
        }

        public static ChuyenKhoaDTO ConvertToChuyenKhoaDTOFull(ChuyenKhoa item)
        {
            if (item == null) return null;
            var obj = ConvertToChuyenKhoaDTO(item);
            obj.PhongKhams = item.PhongKhams.ToList().Select(q => PhongKhamsController.ConvertToPhongKhamDTOFull(q)).ToList();
            return obj;
        }

        // GET: api/ChuyenKhoas/5
        [ResponseType(typeof(ChuyenKhoaDTO))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> GetChuyenKhoa(int id)
        {
            ChuyenKhoa ChuyenKhoa = await db.ChuyenKhoas.FindAsync(id);
            if (ChuyenKhoa == null)
            {
                return NotFound();
            }

            return Ok(ConvertToChuyenKhoaDTO(ChuyenKhoa));
        }

        // PUT: api/ChuyenKhoas/5
        [AdminAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutChuyenKhoa(int id, ChuyenKhoa ChuyenKhoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ChuyenKhoa.IDChuyenKhoa)
            {
                return BadRequest();
            }

            db.Entry(ChuyenKhoa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuyenKhoaExists(id))
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

        // POST: api/ChuyenKhoas
        [AdminAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostChuyenKhoa(ChuyenKhoa ChuyenKhoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChuyenKhoas.Add(ChuyenKhoa);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChuyenKhoaExists(ChuyenKhoa.IDChuyenKhoa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ChuyenKhoa.IDChuyenKhoa }, ChuyenKhoa);
        }

        // DELETE: api/ChuyenKhoas/5
        [AdminAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteChuyenKhoa(int id)
        {
            ChuyenKhoa ChuyenKhoa = await db.ChuyenKhoas.FindAsync(id);
            if (ChuyenKhoa == null)
            {
                return NotFound();
            }

            db.ChuyenKhoas.Remove(ChuyenKhoa);
            await db.SaveChangesAsync();

            return Ok(ChuyenKhoa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChuyenKhoaExists(int id)
        {
            return db.ChuyenKhoas.Count(e => e.IDChuyenKhoa == id) > 0;
        }
    }
}