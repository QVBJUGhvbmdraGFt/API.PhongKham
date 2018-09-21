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
    public class DoctorsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        public static DoctorDTO ConvertToDoctorDTO(Doctor item)
        {
            if (item == null) return null;
            return new DoctorDTO
            {
                Avatar = item.Avatar,
                FullName = item.FullName,
                IDDoctor = item.IDDoctor,
                Status = item.Status,
                Study = item.Study,
                Sumary = item.Sumary,
                TrainingProcess = item.TrainingProcess,
                IDChucDanh = item.IDChucDanh,
                Male = item.Male,
                IDPhongKham = item.IDPhongKham,

                ChucDanh = ChucDanhsController.ConvertToChucDanhDTO(item.ChucDanh),
                PhongKham = PhongKhamsController.ConvertToPhongKhamDTO(item.PhongKham)
            };
        }

        public static DoctorDTO ConvertToDoctorDTOFull(Doctor item)
        {
            if (item == null) return null;
            var obj = ConvertToDoctorDTO(item);
            obj.LichLamViecs = new HashSet<LichLamViecDTO>(item.LichLamViecs.ToList().Select(q => LichLamViecsController.ConvertToLichLamViecDTO(q)));
            return obj;
        }

        // GET: api/Doctors
        [AdminAuthentication("SA", "BACSI", "YTA")]
        public List<DoctorDTO> GetDoctors()
        {
            var lst = new List<DoctorDTO>();
            foreach (var item in db.Doctors.Where(q => q.Status != "DELETE"))
            {
                lst.Add(ConvertToDoctorDTO(item));
            }
            return lst;
        }

        // GET: api/Doctors/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(DoctorDTO))]
        public async Task<IHttpActionResult> GetDoctor(int id)
        {
            Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(ConvertToDoctorDTO(doctor));
        }

        // PUT: api/Doctors/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctor.IDDoctor)
            {
                return BadRequest();
            }

            db.Entry(doctor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        [HttpPost]
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> ChangeAvatar(int id)
        {
            var doctor = db.Doctors.Find(id);

            if (doctor != null)
            {
                var save = UploadHelper.SaveImage();
                if (save.Key)
                {
                    doctor.Avatar = save.Value;
                    db.Entry(doctor).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Ok(doctor.Avatar);
                }
                return Content(HttpStatusCode.NotAcceptable, save.Key);
            }
            return BadRequest();
        }

        // POST: api/Doctors
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostDoctor(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Doctors.Add(doctor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoctorExists(doctor.IDDoctor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok("SUCCESS");
        }

        // DELETE: api/Doctors/5
        [AdminAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteDoctor(int id)
        {
            Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            doctor.Status = "DELETE";
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

        private bool DoctorExists(int id)
        {
            return db.Doctors.Count(e => e.IDDoctor == id) > 0;
        }

        //[HttpPost]
        //[AdminAuthentication]
        //[ResponseType(typeof(List<DoctorDTO>))]
        //public List<DoctorDTO> GetBySpecia(int id)
        //{
        //    var lst = new List<DoctorDTO>();
        //    foreach (var item in db.Doctors.Where(q => q.IDSpecia == id))
        //    {
        //        lst.Add(ConvertToDoctorDTO(item));
        //    }
        //    return lst;
        //}
    }
}