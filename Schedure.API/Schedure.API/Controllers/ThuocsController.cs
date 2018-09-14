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
    public class ThuocsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/Thuocs
        [BasicAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(List<ThuocDTO>))]
        public List<ThuocDTO> GetThuocs()
        {
            var lst = new List<ThuocDTO>();
            foreach (var item in db.Thuocs.Where(q => q.Status != "DELETE"))
            {
                lst.Add(ConvertToThuocDTO(item));
            }
            return lst;
        }

        private ThuocDTO ConvertToThuocDTO(Thuoc item)
        {
            return new ThuocDTO
            {
                DonVi = item.DonVi,
                IDThuoc = item.IDThuoc,
                Name = item.Name,
                Status = item.Status,
                GiaTien = item.GiaTien
            };
        }

        // GET: api/Thuocs/5
        [BasicAuthentication]
        [BasicAuthentication("SA", "BACSI", "YTA")]
        public async Task<IHttpActionResult> GetThuoc(int id)
        {
            Thuoc thuoc = await db.Thuocs.FindAsync(id);

            if (thuoc == null || thuoc.Status == "DELETE")
            {
                return NotFound();
            }

            return Ok(ConvertToThuocDTO(thuoc));
        }

        // PUT: api/Thuocs/5
        [BasicAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutThuoc(int id, Thuoc thuoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thuoc.IDThuoc)
            {
                return BadRequest();
            }

            db.Entry(thuoc).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuocExists(id))
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

        // POST: api/Thuocs
        [BasicAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostThuoc(Thuoc thuoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Thuocs.Add(thuoc);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThuocExists(thuoc.IDThuoc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = thuoc.IDThuoc }, thuoc);
        }

        // DELETE: api/Thuocs/5
        [BasicAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteThuoc(int id)
        {
            Thuoc thuoc = await db.Thuocs.FindAsync(id);
            if (thuoc == null)
            {
                return NotFound();
            }

            thuoc.Status = "DELETE";
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

        private bool ThuocExists(int id)
        {
            return db.Thuocs.Count(e => e.IDThuoc == id) > 0;
        }
    }
}