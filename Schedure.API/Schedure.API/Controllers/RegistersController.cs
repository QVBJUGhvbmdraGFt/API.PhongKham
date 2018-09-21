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
        [AdminAuthentication]
        [ResponseType(typeof(List<RegisterDTO>))]
        public List<RegisterDTO> GetRegisters()
        {
            var lst = new List<RegisterDTO>();
            foreach (var item in db.Registers.OrderByDescending(q => q.NgayKham))
            {
                lst.Add(ConvertToRegisterDTO(item));
            }
            return lst;
        }

        [HttpPost]
        [BasicAuthentication]
        [ResponseType(typeof(List<RegisterDTO>))]
        public List<RegisterDTO> GetByAccount(int id)
        {
            var lst = new List<RegisterDTO>();

            var acc = LoginHelper.GetAccount();
            if (acc.IDAccountBN != id) return lst;

            foreach (var item in db.Registers.Where(q => q.IDAccount == id))
            {
                lst.Add(ConvertToRegisterDTO(item));
            }
            return lst;
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(List<RegisterDTO>))]
        public List<RegisterDTO> Fillter([FromUri]string start, [FromUri] string end, [FromUri] int? IDChuyenKhoa, [FromUri]string Status)
        {
            try
            {
                DateTime? d_start = DateTime.ParseExact(start, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime? d_end = DateTime.ParseExact(end, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                var all = db.Registers.Where(q => q.NgayKham >= d_start && q.NgayKham <= d_end);
                if (string.IsNullOrWhiteSpace(Status) == false)
                {
                    all = all.Where(q => q.Status == Status);
                }
                if (IDChuyenKhoa > 0)
                {
                    all = all.Where(q => q.LichLamViec.Doctor.PhongKham.IDChuyenKhoa == IDChuyenKhoa);
                }
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
                IDAccount = item.IDAccount,
                IDRegister = item.IDRegister,
                Message = item.Message,
                Status = item.Status,
                IDLich = item.IDLich,
                Phone = item.Phone,
                Account_BenhNhan = AccountsController.ConvertToAccount_BenhNhanDTO(item.Account_BenhNhan),
                LichLamViec = LichLamViecsController.ConvertToLichLamViecDTO(item.LichLamViec),
                NgayKham = item.NgayKham
            };
        }

        // GET: api/Registers/5
        [BasicAuthentication]
        [ResponseType(typeof(RegisterDTO))]
        public async Task<IHttpActionResult> GetRegister(int id)
        {
            Register item = await db.Registers.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var acc = LoginHelper.GetAccount();
            if (acc.IDAccountBN != item.IDAccount)
                return NotFound();

            return Ok(ConvertToRegisterDTO(item));
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(RegisterDTO))]
        public async Task<IHttpActionResult> NVGetByID(int id)
        {
            Register item = await db.Registers.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(ConvertToRegisterDTO(item));
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

        [ResponseType(typeof(string))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> Cancle(int id)
        {
            Register item = await db.Registers.FindAsync(id);

            if (LoginHelper.CheckAccount(item.IDAccount ?? 0) == false)
                return NotFound();

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.Status = "CANCLE";
                db.SaveChanges();
            }

            return Ok("SUCCESS");
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

        //[HttpPost]
        //[AdminAuthentication("SA", "BACSI", "YTA")]
        //[ResponseType(typeof(List<RegisterDTO>))]
        //public List<RegisterDTO> GetByIDSpecia(int id)
        //{
        //    var all = db.Registers.ToList().Where(q => q.Doctor.IDSpecia == id);

        //    var lst = new List<RegisterDTO>();
        //    foreach (var item in all)
        //    {
        //        lst.Add(ConvertToRegisterDTO(item));
        //    }
        //    return lst;
        //}

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
        [BasicAuthentication]
        [ResponseType(typeof(Register))]
        public async Task<IHttpActionResult> PostRegister(Register register)
        {
            try
            {
                if (LoginHelper.CheckAccount(register.IDAccount ?? 0) == false)
                    return NotFound();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Registers.Add(register);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = register.IDRegister }, register);
            }
            catch (Exception ex)
            {
                ex.DebugLog();
                return BadRequest();
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