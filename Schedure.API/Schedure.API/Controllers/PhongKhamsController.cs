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
    public class PhongKhamsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/PhongKhams
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(List<PhongKhamDTO>))]
        public List<PhongKhamDTO> GetPhongKhams()
        {
            var lst = new List<PhongKhamDTO>();
            foreach (var item in db.PhongKhams)
            {
                lst.Add(ConvertToPhongKhamDTO(item));
            }
            return lst;
        }

        public static PhongKhamDTO ConvertToPhongKhamDTO(PhongKham item)
        {
            if (item == null) return null;
            return new PhongKhamDTO
            {
                IDPhongKham = item.IDPhongKham,
                Name = item.Name,
                IDChuyenKhoa = item.IDChuyenKhoa,
                ChuyenKhoa = ChuyenKhoasController.ConvertToChuyenKhoaDTO(item.ChuyenKhoa)
            };
        }

        public static PhongKhamDTO ConvertToPhongKhamDTOFull(PhongKham item)
        {
            if (item == null) return null;
            var obj = ConvertToPhongKhamDTO(item);
            obj.Doctors = item.Doctors.Select(q => DoctorsController.ConvertToDoctorDTOFull(q)).ToList();
            return obj;
        }

        // GET: api/PhongKhams/5
        [ResponseType(typeof(PhongKhamDTO))]
        [AdminAuthentication("SA", "BACSI", "YTA")]
        public async Task<IHttpActionResult> GetPhongKham(int id)
        {
            PhongKham PhongKham = await db.PhongKhams.FindAsync(id);
            if (PhongKham == null)
            {
                return NotFound();
            }

            return Ok(ConvertToPhongKhamDTO(PhongKham));
        }

        // PUT: api/PhongKhams/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutPhongKham(int id, PhongKham PhongKham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != PhongKham.IDPhongKham)
            {
                return BadRequest();
            }

            db.Entry(PhongKham).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhongKhamExists(id))
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

        // POST: api/PhongKhams
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostPhongKham(PhongKham PhongKham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhongKhams.Add(PhongKham);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhongKhamExists(PhongKham.IDPhongKham))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = PhongKham.IDPhongKham }, PhongKham);
        }

        // DELETE: api/PhongKhams/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeletePhongKham(int id)
        {
            PhongKham PhongKham = await db.PhongKhams.FindAsync(id);
            if (PhongKham == null)
            {
                return NotFound();
            }

            PhongKham.Status = "DELETE";
            await db.SaveChangesAsync();

            return Ok(PhongKham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhongKhamExists(int id)
        {
            return db.PhongKhams.Count(e => e.IDPhongKham == id) > 0;
        }
    }
}