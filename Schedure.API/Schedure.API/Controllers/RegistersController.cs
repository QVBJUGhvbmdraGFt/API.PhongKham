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
    public class RegistersController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/Registers
        [BasicAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(List<RegisterDTO>))]
        public List<RegisterDTO> GetRegisters()
        {
            var lst = new List<RegisterDTO>();
            foreach (var item in db.Registers)
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
            if (string.IsNullOrWhiteSpace(acc.POSITION) && acc.IDAccount != id)
                return lst;

            foreach (var item in db.Registers.Where(q => q.IDAccount == id))
            {
                lst.Add(ConvertToRegisterDTO(item));
            }
            return lst;
        }

        private RegisterDTO ConvertToRegisterDTO(Register item)
        {
            return new RegisterDTO
            {
                Account_FullName = item.Account.FullName,
                CreateDate = item.CreateDate,
                Doctor_FullName = item.Doctor.FullName,
                IDAccount = item.IDAccount,
                IDDoctor = item.IDDoctor,
                IDRegister = item.IDRegister,
                Message = item.Message,
                Status = item.Status,
                Specia_Name = item.Doctor.Specia.Name
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
            if (string.IsNullOrWhiteSpace(acc.POSITION) && acc.IDAccount != item.IDAccount)
                return NotFound();

            return Ok(ConvertToRegisterDTO(item));
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

        [HttpPost]
        [BasicAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(List<RegisterDTO>))]
        public List<RegisterDTO> GetByIDSpecia(int id)
        {
            var all = db.Registers.ToList().Where(q => q.Doctor.IDSpecia == id);

            var lst = new List<RegisterDTO>();
            foreach (var item in all)
            {
                lst.Add(ConvertToRegisterDTO(item));
            }
            return lst;
        }

        // PUT: api/Registers/5
        [BasicAuthentication("SA", "BACSI", "YTA")]
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

        // DELETE: api/Registers/5
        [BasicAuthentication("SA", "BACSI", "YTA")]
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