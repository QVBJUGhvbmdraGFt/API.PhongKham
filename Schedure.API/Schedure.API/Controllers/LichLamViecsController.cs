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
    public class LichLamViecsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/LichLamViecs
        [ResponseType(typeof(List<LichLamViecDTO>))]
        public List<LichLamViecDTO> GetLichLamViecs()
        {
            return db.SP_LichLamViec_GetAllOrID(null).Select(q => new LichLamViecDTO
            {
                CreaterDate = q.CreaterDate,
                Creater_Id = q.Creater_Id,
                Date = q.Date,
                IDLich = q.IDLich,
                IDPhongKham = q.IDPhongKham,
                IDTimeSlot = q.IDTimeSlot,
                NhanVien_Id = q.NhanVien_Id,
                Registers = null,
                Status = q.LichLamViec_Status,
                TimeSlot = new TimeSlotDTO
                {
                    Name = q.Name,
                    HourEnd = q.HourEnd,
                    HourStart = q.HourStart,
                    Status = q.TimeSlot_Status,
                    IDTimeSlot = q.IDTimeSlot ?? 0,
                },
                Doctor = new DoctorDTO
                {
                    FullName = q.TenNhanVien,
                    IDDoctor = q.NhanVien_Id ?? 0,
                    PhongBan = new PhongBanDTO
                    {
                        IDChuyenKhoa = q.IDChuyenKhoa,
                        TenPhongBan = q.TenPhongBan,
                        IDPhongBan = q.IDPhongBan,
                        PhongBan_Id = q.IDPhongBan,
                        ChuyenKhoa = new ChuyenKhoaDTO
                        {
                            IDChuyenKhoa = q.IDChuyenKhoa,
                            Name = q.ChuyenKhoa_Name
                        }
                    }
                },
            }).ToList();
        }

        [ResponseType(typeof(List<LichLamViecDTO>))]
        [HttpPost]
        public List<LichLamViecDTO> GetByIDPhongBan(int iDPhongBan, string date)
        {
            try
            {
                DateTime d_date = DateTime.ParseExact(date, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                return db.SP_LichLamViec_GetByPhongBan_Id(iDPhongBan, d_date).Select(q => new LichLamViecDTO
                {
                    CreaterDate = q.CreaterDate,
                    Creater_Id = q.Creater_Id,
                    Date = q.Date,
                    IDLich = q.IDLich,
                    IDPhongKham = q.IDPhongKham,
                    IDTimeSlot = q.IDTimeSlot,
                    NhanVien_Id = q.NhanVien_Id,
                    Registers = null,
                    Status = q.LichLamViec_Status,
                    TimeSlot = new TimeSlotDTO
                    {
                        Name = q.Name,
                        HourEnd = q.HourEnd,
                        HourStart = q.HourStart,
                        Status = q.TimeSlot_Status,
                        IDTimeSlot = q.IDTimeSlot ?? 0,
                    },
                    Doctor = new DoctorDTO
                    {
                        FullName = q.TenNhanVien,
                        IDDoctor = q.NhanVien_Id ?? 0,
                        PhongBan = new PhongBanDTO
                        {
                            IDPhongBan = q.IDPhongKham ?? 0,
                        }
                    },
                }).ToList();
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return new List<LichLamViecDTO>();
        }


        public static LichLamViecDTO ConvertToLichLamViecDTO(LichLamViec item)
        {
            return new LichLamViecDTO
            {
                CreaterDate = item.CreaterDate,
                Creater_Id = item.Creater_Id,
                Date = item.Date,
                IDLich = item.IDLich,
                IDTimeSlot = item.IDTimeSlot,
                IDPhongKham = item.IDPhongKham,
                NhanVien_Id = item.NhanVien_Id,
                Status = item.Status,
                TimeSlot = TimeSlotsController.ConvertToTimeSlotDTO(item.TimeSlot),
                Registers = item.Registers.Select(q => RegistersController.ConvertToRegisterDTO(q)).ToList(),
            };
        }

        // GET: api/LichLamViecs/5
        [HttpGet]
        [ResponseType(typeof(LichLamViecDTO))]
        public IHttpActionResult GetLichLamViec(int id)
        {
            var q = db.SP_LichLamViec_GetAllOrID(id).FirstOrDefault();
            if (q == null)
                return NotFound();
            return Ok(new LichLamViecDTO
            {
                CreaterDate = q.CreaterDate,
                Creater_Id = q.Creater_Id,
                Date = q.Date,
                IDLich = q.IDLich,
                IDPhongKham = q.IDPhongKham,
                IDTimeSlot = q.IDTimeSlot,
                NhanVien_Id = q.NhanVien_Id,
                Registers = null,
                Status = q.LichLamViec_Status,
                TimeSlot = new TimeSlotDTO
                {
                    Name = q.Name,
                    HourEnd = q.HourEnd,
                    HourStart = q.HourStart,
                    Status = q.TimeSlot_Status,
                    IDTimeSlot = q.IDTimeSlot ?? 0,
                },
                Doctor = new DoctorDTO
                {
                    FullName = q.TenNhanVien,
                    IDDoctor = q.NhanVien_Id ?? 0,
                    PhongBan = new PhongBanDTO
                    {
                        IDChuyenKhoa = q.IDChuyenKhoa,
                        TenPhongBan = q.TenPhongBan,
                        IDPhongBan = q.IDPhongBan,
                        PhongBan_Id = q.IDPhongBan,
                        ChuyenKhoa = new ChuyenKhoaDTO
                        {
                            IDChuyenKhoa = q.IDChuyenKhoa,
                            Name = q.ChuyenKhoa_Name
                        }
                    }
                },
            });
        }

        // POST: api/LichLamViecs
        [ResponseType(typeof(string))]
        [AdminAuthentication]
        public async Task<IHttpActionResult> PostLichLamViec(LichLamViec LichLamViec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LichLamViecs.Add(LichLamViec);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LichLamViecExists(LichLamViec.IDLich))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE: api/LichLamViecs/5
        [AdminAuthentication]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteLichLamViec(int id)
        {
            LichLamViec LichLamViec = await db.LichLamViecs.FindAsync(id);
            if (LichLamViec == null)
            {
                return NotFound();
            }

            db.LichLamViecs.Remove(LichLamViec);
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

        private bool LichLamViecExists(int id)
        {
            return db.LichLamViecs.Count(e => e.IDLich == id) > 0;
        }
    }
}