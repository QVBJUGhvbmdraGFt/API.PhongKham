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
    public class ToaThuocsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/ToaThuocs
        [ResponseType(typeof(List<ToaThuocDTO>))]
        [BasicAuthentication("SA", "BACSI", "YTA")]
        public List<ToaThuocDTO> GetToaThuocs()
        {
            var lst = new List<ToaThuocDTO>();
            foreach (var item in db.ToaThuocs)
            {
                lst.Add(ConvertToToaThuocDTO(item));
            }
            return lst;
        }

        private ToaThuocDTO ConvertToToaThuocDTO(ToaThuoc item)
        {
            return new ToaThuocDTO
            {
                CachDung = item.CachDung,
                GhiChu = item.GhiChu,
                Gia = item.Gia,
                IDHistory = item.IDHistory,
                IDToaThuoc = item.IDToaThuoc,
            };
        }

        // GET: api/ToaThuocs/5
        [HttpGet]
        [ResponseType(typeof(ToaThuocDTO))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> GetToaThuoc(int id)
        {
            ToaThuoc toaThuoc = await db.ToaThuocs.FindAsync(id);
            if (toaThuoc == null)
            {
                return NotFound();
            }

            var acc = LoginHelper.GetAccount();
            if (string.IsNullOrWhiteSpace(acc.POSITION) && acc.IDAccount != toaThuoc.HistoryKhamBenh.Register.IDAccount)
                return NotFound();

            return Ok(toaThuoc);
        }

        [HttpPost]
        [BasicAuthentication]
        [ResponseType(typeof(ToaThuocDTO))]
        public async Task<IHttpActionResult> GetByIDHistory(int id)
        {
            ToaThuoc toaThuoc = await db.ToaThuocs.FirstOrDefaultAsync(q => q.IDHistory == id);
            if (toaThuoc == null)
            {
                return NotFound();
            }

            var acc = LoginHelper.GetAccount();
            if (string.IsNullOrWhiteSpace(acc.POSITION) && acc.IDAccount != toaThuoc.HistoryKhamBenh.Register.IDAccount)
                return NotFound();

            return Ok(ConvertToToaThuocDTO(toaThuoc));
        }

        // PUT: api/ToaThuocs/5
        [BasicAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutToaThuoc(int id, ToaThuoc toaThuoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toaThuoc.IDToaThuoc)
            {
                return BadRequest();
            }

            db.Entry(toaThuoc).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToaThuocExists(id))
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

        // POST: api/ToaThuocs
        [ResponseType(typeof(string))]
        [BasicAuthentication("SA", "BACSI")]
        public async Task<IHttpActionResult> PostToaThuoc(ToaThuoc toaThuoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToaThuocs.Add(toaThuoc);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ToaThuocExists(toaThuoc.IDToaThuoc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = toaThuoc.IDToaThuoc }, toaThuoc);
        }

        // DELETE: api/ToaThuocs/5
        [BasicAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteToaThuoc(int id)
        {
            ToaThuoc toaThuoc = await db.ToaThuocs.FindAsync(id);
            if (toaThuoc == null)
            {
                return NotFound();
            }

            db.ToaThuocs.Remove(toaThuoc);
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

        private bool ToaThuocExists(int id)
        {
            return db.ToaThuocs.Count(e => e.IDToaThuoc == id) > 0;
        }
    }
}