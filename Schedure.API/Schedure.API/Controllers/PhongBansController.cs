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
    public class PhongBansController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/PhongBans
        [AdminAuthentication()]
        [ResponseType(typeof(List<PhongBanDTO>))]
        public List<PhongBanDTO> GetPhongBans()
        {
            return db.SP_PhongBan_GetAll().Select(q => new PhongBanDTO
            {
                PhongBan_Id = q.PhongBan_Id,
                TenPhongBan = q.TenPhongBan,
                ChuyenKhoa = new ChuyenKhoaDTO
                {
                    Status = q.ChuyenKhoa_Status,
                    Name = q.Name,
                    IDChuyenKhoa = q.IDChuyenKhoa,
                },
                IDChuyenKhoa = q.IDChuyenKhoa,
                IDPhongBan = q.IDPhongBan,
                Status = q.PhongBan_Status,
            }).ToList();
        }

        [AdminAuthentication()]
        [ResponseType(typeof(List<DoctorDTO>))]
        [HttpPost]
        public List<DoctorDTO> GetDoctorByPhongKham(int id)
        {
            return db.SP_BacSi_GetByPhongBan_Id(id).Select(q => new DoctorDTO
            {
                FullName = q.TenNhanVien,
                IDDoctor = q.NhanVien_Id,
                LichLamViecs = null,
                PhongBan = new PhongBanDTO
                {
                    ChuyenKhoa = new ChuyenKhoaDTO
                    {
                        Name = q.Name,
                        IDChuyenKhoa = q.IDChuyenKhoa,
                        Status = q.ChuyenKhoa_Status,
                    },
                    IDChuyenKhoa = q.IDChuyenKhoa,
                    PhongBan_Id = q.PhongBan_Id,
                    Status = q.PhongBan_Status,
                    IDPhongBan = q.IDPhongBan,
                    TenPhongBan = q.TenPhongBan,
                }
            }).ToList();
        }

        [HttpPost]
        [AdminAuthentication()]
        [ResponseType(typeof(List<DoctorDTO>))]
        public List<DoctorDTO> GetAllDoctor()
        {
            return db.SP_BacSi_GetAll().Select(q => new DoctorDTO
            {
                FullName = q.TenNhanVien,
                IDDoctor = q.NhanVien_Id,
                LichLamViecs = null,
                PhongBan = new PhongBanDTO
                {
                    ChuyenKhoa = new ChuyenKhoaDTO
                    {
                        Name = q.Name,
                        IDChuyenKhoa = q.IDChuyenKhoa,
                        Status = q.ChuyenKhoa_Status,
                    },
                    IDChuyenKhoa = q.IDChuyenKhoa,
                    PhongBan_Id = q.PhongBan_Id,
                    Status = q.PhongBan_Status,
                    IDPhongBan = q.IDPhongBan,
                    TenPhongBan = q.TenPhongBan,
                }
            }).ToList();
        }

        [HttpPost]
        [AdminAuthentication()]
        [ResponseType(typeof(List<PhongBanDTO>))]
        public List<PhongBanDTO> GetSource()
        {
            return db.SP_PhongBan_GetSource().Select(q => new PhongBanDTO
            {
                PhongBan_Id = q.PhongBan_Id,
                TenPhongBan = q.TenPhongBan,
                IDPhongBan = q.PhongBan_Id

            }).ToList();
        }

        public static PhongBanDTO ConvertToPhongBanDTO(PhongBan item)
        {
            if (item == null) return null;
            return new PhongBanDTO
            {
                IDPhongBan = item.IDPhongBan,
                PhongBan_Id = item.PhongBan_Id,
                IDChuyenKhoa = item.IDChuyenKhoa,
                Status = item.Status,
                ChuyenKhoa = new ChuyenKhoaDTO
                {
                    IDChuyenKhoa = item.ChuyenKhoa.IDChuyenKhoa,
                    Name = item.ChuyenKhoa.Name,
                },
            };
        }

        public static PhongBanDTO ConvertToPhongBanDTOFull(PhongBan item)
        {
            if (item == null) return null;
            var obj = ConvertToPhongBanDTO(item);
            return obj;
        }

        // GET: api/PhongBans/5
        [ResponseType(typeof(PhongBanDTO))]
        [AdminAuthentication]
        public async Task<IHttpActionResult> GetPhongBan(int id)
        {
            PhongBan PhongBan = await db.PhongBans.FindAsync(id);
            if (PhongBan == null)
            {
                return NotFound();
            }

            return Ok(ConvertToPhongBanDTO(PhongBan));
        }

        // PUT: api/PhongBans/5
        [AdminAuthentication]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutPhongBan(int id, PhongBan PhongBan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != PhongBan.IDPhongBan)
            {
                return BadRequest();
            }

            db.Entry(PhongBan).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhongBanExists(id))
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

        // POST: api/PhongBans
        [AdminAuthentication]
        [ResponseType(typeof(string))]
        public IHttpActionResult PostPhongBan(PhongBan PhongBan)
        {
            return Ok(db.SP_PhongBan_Insert(PhongBan.IDChuyenKhoa, PhongBan.PhongBan_Id));
        }

        // DELETE: api/PhongBans/5
        [AdminAuthentication]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeletePhongBan(int id)
        {
            PhongBan PhongBan = await db.PhongBans.FindAsync(id);
            if (PhongBan == null)
            {
                return NotFound();
            }

            db.PhongBans.Remove(PhongBan);
            await db.SaveChangesAsync();

            return Ok(PhongBan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhongBanExists(int id)
        {
            return db.PhongBans.Count(e => e.IDPhongBan == id) > 0;
        }
    }
}