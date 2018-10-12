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
    public class ChuyenKhoasController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/ChuyenKhoas
        [AdminAuthentication]
        [ResponseType(typeof(List<ChuyenKhoaDTO>))]
        public List<ChuyenKhoaDTO> NVJoinAllChuyenKhoa()
        {
            try
            {
                return GetJoin();
            }
            catch (Exception ex)
            {
                ex.DebugLog();
                return null;
            }
        }

        [AdminAuthentication]
        [ResponseType(typeof(List<ChuyenKhoaDTO>))]
        public List<ChuyenKhoaDTO> NVAllChuyenKhoa()
        {
            try
            {
                return db.ChuyenKhoas.ToList().Select(q => new ChuyenKhoaDTO
                {
                    Avatar = q.Avatar,
                    IDChuyenKhoa = q.IDChuyenKhoa,
                    Name = q.Name,
                    Status = q.Status,
                    TimeUse = q.TimeUse,
                    PhongBans = q.PhongBans.Select(a => new PhongBanDTO
                    {
                        IDChuyenKhoa = a.IDChuyenKhoa,
                        PhongBan_Id = a.PhongBan_Id,
                        Status = a.Status,
                        IDPhongBan = a.IDPhongBan,
                        TenPhongBan = a.TenPhongBan,
                    }).ToList()
                }).ToList();
            }
            catch (Exception ex)
            {
                ex.DebugLog();
                return null;
            }
        }

        [ResponseType(typeof(List<ChuyenKhoaDTO>))]
        [HttpPost]
        public List<ChuyenKhoaDTO> JoinAllChuyenKhoa()
        {
            try
            {
                var data = GetJoin();
                return data;
            }
            catch (Exception ex)
            {
                ex.DebugLog();
                return null;
            }
        }

        public static List<ChuyenKhoaDTO> GetJoin()
        {
            var data = new SchedureEntities().SP_ChuyenKhoa_GetAll().ToList();
            List<ChuyenKhoaDTO> lst = new List<ChuyenKhoaDTO>();
            foreach (var gr in data.GroupBy(q => q.IDChuyenKhoa))
            {
                var first = gr.First();
                ChuyenKhoaDTO chuyenKhoa = new ChuyenKhoaDTO()
                {
                    IDChuyenKhoa = first.IDChuyenKhoa,
                    Avatar = first.Avatar,
                    Name = first.ChuyenKhoa_Name,
                    PhongBans = new List<PhongBanDTO>(),
                    Status = first.ChuyenKhoa_Status,
                    TimeUse = first.TimeUse,
                };

                foreach (var pb in gr.GroupBy(q => q.PhongBan_Id))
                {
                    var pb_first = pb.First();
                    var phongban = new PhongBanDTO()
                    {
                        IDChuyenKhoa = pb_first.IDChuyenKhoa,
                        IDPhongBan = pb_first.PhongBan_Id,
                        TenPhongBan = pb_first.TenPhongBan,
                        PhongBan_Id = pb_first.PhongBan_Id,
                        Doctors = new List<DoctorDTO>(),
                        Status = "ACTIVE",
                    };

                    foreach (var bs in pb.GroupBy(q => q.NhanVien_Id))
                    {
                        var bs_first = bs.First();

                        var bacsi = new DoctorDTO
                        {
                            IDDoctor = bs_first.NhanVien_Id,
                            FullName = bs_first.TenNhanVien,
                            LichLamViecs = new HashSet<LichLamViecDTO>(),
                        };

                        foreach (var lich in bs)
                        {
                            LichLamViecDTO lichLamViec = new LichLamViecDTO
                            {
                                IDLich = lich.IDLich,
                                Status = lich.LichLamViec_Status,
                                Date = lich.Date,
                                TimeSlot = new TimeSlotDTO
                                {
                                    HourEnd = lich.HourEnd,
                                    HourStart = lich.HourStart,
                                    Name = lich.TimeSplot_Name,
                                    Status = lich.TimeSlot_Status,
                                },
                                Doctor = new DoctorDTO
                                {
                                    IDDoctor = bs_first.NhanVien_Id,
                                    FullName = bs_first.TenNhanVien,
                                    LichLamViecs = new HashSet<LichLamViecDTO>(),
                                }
                            };
                            bacsi.LichLamViecs.Add(lichLamViec);
                        }

                        phongban.Doctors.Add(bacsi);
                    }

                    chuyenKhoa.PhongBans.Add(phongban);
                }

                lst.Add(chuyenKhoa);
            }
            return lst.OrderBy(q => q.Name).ToList();
        }

        // GET: api/ChuyenKhoas1/5
        [ResponseType(typeof(ChuyenKhoa))]
        public async Task<IHttpActionResult> GetChuyenKhoa(int id)
        {
            ChuyenKhoa chuyenKhoa = await db.ChuyenKhoas.FindAsync(id);
            if (chuyenKhoa == null)
            {
                return NotFound();
            }

            return Ok(chuyenKhoa);
        }

        // PUT: api/ChuyenKhoas1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChuyenKhoa(int id, ChuyenKhoa chuyenKhoa)
        {
            if (id != chuyenKhoa.IDChuyenKhoa)
            {
                return BadRequest();
            }

            db.Entry(chuyenKhoa).State = EntityState.Modified;

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

        // POST: api/ChuyenKhoas1
        [ResponseType(typeof(bool))]
        [AdminAuthentication]
        public async Task<IHttpActionResult> PostChuyenKhoa(ChuyenKhoa chuyenKhoa)
        {
            chuyenKhoa = new ChuyenKhoa
            {
                Avatar = "",
                IDChuyenKhoa = 0,
                Name = chuyenKhoa.Name,
                PhongBans = null,
                Status = "ACTIVE",
                TimeUse = null
            };

            db.ChuyenKhoas.Add(chuyenKhoa);
            return Ok(await db.SaveChangesAsync() > 0);
        }

        // DELETE: api/ChuyenKhoas1/5
        [ResponseType(typeof(ChuyenKhoa))]
        public async Task<IHttpActionResult> DeleteChuyenKhoa(int id)
        {
            ChuyenKhoa chuyenKhoa = await db.ChuyenKhoas.FindAsync(id);
            if (chuyenKhoa == null)
            {
                return NotFound();
            }

            db.ChuyenKhoas.Remove(chuyenKhoa);
            await db.SaveChangesAsync();

            return Ok(chuyenKhoa);
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