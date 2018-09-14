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

        private DoctorDTO ConvertToDoctorDTO(Doctor item)
        {
            return new DoctorDTO
            {
                Avatar = item.Avatar,
                FullName = item.FullName,
                IDDoctor = item.IDDoctor,
                IDSpecia = item.IDSpecia,
                Status = item.Status,
                Study = item.Study,
                Sumary = item.Sumary,
                TrainingProcess = item.TrainingProcess,
            };

        }
        // GET: api/Doctors

        [BasicAuthentication("SA", "BACSI", "YTA")]
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
        [BasicAuthentication("SA", "BACSI", "YTA")]
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
        [BasicAuthentication("SA", "BACSI", "YTA")]
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
        [BasicAuthentication("SA", "BACSI", "YTA")]
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
        [BasicAuthentication("SA", "BACSI", "YTA")]
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
        [BasicAuthentication("SA", "BACSI", "YTA")]
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

        [HttpPost]
        [BasicAuthentication]
        [ResponseType(typeof(List<DoctorDTO>))]
        public List<DoctorDTO> GetBySpecia(int id)
        {
            var lst = new List<DoctorDTO>();
            foreach (var item in db.Doctors.Where(q => q.IDSpecia == id))
            {
                lst.Add(ConvertToDoctorDTO(item));
            }
            return lst;
        }


    }
}