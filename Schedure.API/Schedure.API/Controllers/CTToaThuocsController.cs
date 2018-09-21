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
    public class CTToaThuocsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/CTToaThuocs
        [ResponseType(typeof(List<CTToaThuocDTO>))]
        [AdminAuthentication("SA", "BACSI", "YTA")]
        public List<CTToaThuocDTO> GetCTToaThuocs()
        {
            var lst = new List<CTToaThuocDTO>();
            foreach (var item in db.CTToaThuocs)
            {
                lst.Add(ConvertToCTToaThuocDTO(item));
            }
            return lst;
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(List<CTToaThuocDTO>))]
        public List<CTToaThuocDTO> GetByIDToaThuoc(int id)
        {
            var lst = new List<CTToaThuocDTO>();
            if (LoginHelper.CheckAccount(db.ToaThuocs.FirstOrDefault(q => q.IDToaThuoc == id)?.HistoryKhamBenh.Register.IDAccount ?? 0) == false) return lst;
            foreach (var item in db.CTToaThuocs.Where(q => q.IDToaThuoc == id))
            {
                lst.Add(ConvertToCTToaThuocDTO(item));
            }
            return lst;
        }


        public static CTToaThuocDTO ConvertToCTToaThuocDTO(CTToaThuoc item)
        {
            return new CTToaThuocDTO
            {
                GiaTien = item.GiaTien,
                IDCT = item.IDCT,
                IDThuoc = item.IDThuoc,
                IDToaThuoc = item.IDToaThuoc,
                SoLuong = item.SoLuong,
                Thuoc_Name = item.Thuoc.Name,
                Thuoc_DonVi = item.Thuoc.DonVi,
                
            };
        }

        // GET: api/CTToaThuocs/5
        [AdminAuthentication]
        [ResponseType(typeof(CTToaThuocDTO))]
        public async Task<IHttpActionResult> GetCTToaThuoc(int id)
        {
            CTToaThuoc cTToaThuoc = await db.CTToaThuocs.FindAsync(id);

            if (LoginHelper.CheckAccount(cTToaThuoc.ToaThuoc.HistoryKhamBenh.Register.IDAccount ?? 0) == false || cTToaThuoc == null)
            {
                return NotFound();
            }

            return Ok(cTToaThuoc);
        }

        // PUT: api/CTToaThuocs/5
        [AdminAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutCTToaThuoc(int id, CTToaThuoc cTToaThuoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cTToaThuoc.IDCT)
            {
                return BadRequest();
            }

            db.Entry(cTToaThuoc).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CTToaThuocExists(id))
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

        // POST: api/CTToaThuocs
        [AdminAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostCTToaThuoc(CTToaThuoc cTToaThuoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CTToaThuocs.Add(cTToaThuoc);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CTToaThuocExists(cTToaThuoc.IDCT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cTToaThuoc.IDCT }, cTToaThuoc);
        }

        // DELETE: api/CTToaThuocs/5
        [AdminAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteCTToaThuoc(int id)
        {
            CTToaThuoc cTToaThuoc = await db.CTToaThuocs.FindAsync(id);
            if (cTToaThuoc == null)
            {
                return NotFound();
            }

            db.CTToaThuocs.Remove(cTToaThuoc);
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

        private bool CTToaThuocExists(int id)
        {
            return db.CTToaThuocs.Count(e => e.IDCT == id) > 0;
        }
    }
}