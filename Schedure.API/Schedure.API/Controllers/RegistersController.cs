using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
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
    public class RegistersController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/Registers
        [BasicAuthentication]
        [HttpPost]
        [ResponseType(typeof(List<RegisterDTO>))]
        public List<RegisterDTO> GetByAccount([FromUri]string start, [FromUri] string end)
        {
            try
            {
                int? iDAccount = LoginHelper.GetAccount()?.IDAccountBN;
                if (iDAccount != null)
                {
                    DateTime? d_start = DateTime.ParseExact(start, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    DateTime? d_end = DateTime.ParseExact(end, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    var all = db.SP_Register_GetAllOrBy(d_start, d_end, null, null, null, iDAccount);
                    return all.ToList().Select(q => ConvertToRegisterDTO(q)).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return null;
        }

        private RegisterDTO ConvertToRegisterDTO(SP_Register_GetAllOrBy_Result q)
        {
            if (q == null) return null;
            return new RegisterDTO
            {
                ChuyenKhoa = new ChuyenKhoaDTO
                {
                    Name = q.ChuyenKhoa_Name,
                    IDChuyenKhoa = q.IDChuyenKhoa ?? 0
                },
                CreateDate = q.CreateDate,
                IDAccountBN = q.IDAccountBN,
                IDChuyenKhoa = q.IDChuyenKhoa,
                IDLich = q.IDLich,
                IDRegister = q.IDRegister,
                LichLamViec = new LichLamViecDTO
                {
                    IDLich = q.IDLich,
                    CreaterDate = q.CreateDate,
                    Doctor = new DoctorDTO
                    {
                        FullName = q.TenNhanVien,
                        IDDoctor = q.NhanVien_Id ?? 0
                    },
                    NhanVien_Id = q.NhanVien_Id,
                    IDPhongKham = q.IDPhongKham,
                    PhongKham = new PhongBanDTO
                    {
                        IDPhongBan = q.IDPhongKham ?? 0,
                        PhongBan_Id = q.IDPhongKham,
                        TenPhongBan = q.TenPhongBan,
                        ChuyenKhoa = new ChuyenKhoaDTO
                        {
                            Name = q.ChuyenKhoa_Name,
                            IDChuyenKhoa = q.IDChuyenKhoa ?? 0
                        }
                    },
                    TimeSlot = new TimeSlotDTO
                    {
                        HourStart = q.HourStart,
                        HourEnd = q.HourEnd,
                        Name = q.TimeSlot_Name,
                        Status = q.TimeSlot_Status
                    }
                },
                Message = q.Message,
                NgayKham = q.NgayKham,
                NhanVien_Id = q.NhanVien_Id,
                Patient_name = q.Patient_name,
                Phone = q.Phone,
                Status = q.Status,
                Status_Patient = q.Status_Patient,
                Account_BenhNhan = new Account_BenhNhanDTO
                {
                    IDAccountBN = q.IDAccountBN ?? 0,
                    Username = q.Username
                }
            };
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(List<RegisterDTO>))]
        public List<RegisterDTO> Fillter([FromUri]string start, [FromUri] string end, [FromUri] int? IDPhongBan, [FromUri]string Status)
        {
            try
            {
                DateTime? d_start = DateTime.ParseExact(start, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime? d_end = DateTime.ParseExact(end, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                IDPhongBan = IDPhongBan > 0 ? IDPhongBan : null;
                var all = db.SP_Register_GetAllOrBy(d_start, d_end, Status, IDPhongBan, null, null);
                return all.AsEnumerable().Select(q => ConvertToRegisterDTO(q)).ToList();
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return null;
        }

        public static RegisterDTO ConvertToRegisterDTO(Register item)
        {
            return new RegisterDTO
            {
                CreateDate = item.CreateDate,
                IDAccountBN = item.IDAccountBN,
                IDRegister = item.IDRegister,
                Message = item.Message,
                Status = item.Status,
                IDLich = item.IDLich,
                Phone = item.Phone,
                Account_BenhNhan = AccountsController.ConvertToAccount_BenhNhanDTO(item.Account_BenhNhan),
                IDChuyenKhoa = item.IDChuyenKhoa,
                LichLamViec = LichLamViecsController.ConvertToLichLamViecDTO(item.LichLamViec),
                NgayKham = item.NgayKham,
                NhanVien_Id = item.NhanVien_Id,
                Patient_name = item.Patient_name,
                Status_Patient = item.Status_Patient,
            };
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(RegisterDTO))]
        public IHttpActionResult NVGetByID(int id)
        {
            try
            {
                var all = db.SP_Register_GetAllOrBy(null, null, null, null, id, null);
                var q = all.AsEnumerable().FirstOrDefault();
                if (q != null)
                {
                    return Ok(ConvertToRegisterDTO(q));
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return null;
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> NVCreate(Register register)
        {
            register.Status = "ACTIVE";
            register.CreateDate = DateTime.Now;
            db.Registers.Add(register);
            return Ok((await db.SaveChangesAsync()) > 0);
        }

        [ResponseType(typeof(bool))]
        [AdminAuthentication]
        public async Task<IHttpActionResult> Confirm(int id, [FromUri]string status)
        {
            try
            {
                Register item = await db.Registers.FindAsync(id);

                if (item == null || (item.Status != "CONFIRM" && item.Status != "ACTIVE"))
                {
                    return NotFound();
                }
                else
                {
                    item.Status = status;
                    db.SaveChanges();
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return BadRequest();
        }

        [ResponseType(typeof(bool))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> Cancle(int id)
        {
            try
            {
                Register item = await db.Registers.FindAsync(id);
                if (item != null && item.Status == "CONFIRM")
                {
                    if (LoginHelper.CheckAccount(item.IDAccountBN))
                    {
                        item.Status = "CANCLE";
                        db.SaveChanges();
                        return Ok(true);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return BadRequest();
        }

        // PUT: api/Registers/5
        [AdminAuthentication]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegister(int id, Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != register.IDRegister)
            {
                return BadRequest();
            }

            db.Entry(register).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
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

        // POST: api/Registers
        [ResponseType(typeof(bool))]
        public IHttpActionResult PostRegister(RegisterDTO register)
        {
            try
            {
                register.Status = "CONFIRM";
                return Ok(db.SP_Register_Insert(register.IDAccountBN, register.MaYTe, register.Message, register.Status, register.IDLich, register.Phone, register.NgayKham, register.Status_Patient, register.Patient_name, register.NhanVien_Id, register.IDChuyenKhoa) > 0);
            }
            catch (Exception ex)
            {
                ex.DebugLog();
                return BadRequest("false");
            }
        }

        // DELETE: api/Registers/5
        [AdminAuthentication]
        [ResponseType(typeof(Register))]
        public async Task<IHttpActionResult> DeleteRegister(int id)
        {
            Register register = await db.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }

            db.Registers.Remove(register);
            await db.SaveChangesAsync();

            return Ok(register);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegisterExists(int id)
        {
            return db.Registers.Count(e => e.IDRegister == id) > 0;
        }
    }
}