using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Schedure.API.Models;
using SchedureDTO;

namespace Schedure.API.Controllers
{
    [AdminAuthentication("", "SA", "BACSI", "YTA")]
    public class AccountsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        #region BENHNHAN
        [AdminAuthentication]
        public List<Account_BenhNhanDTO> GetAccount_BenhNhans()
        {
            var lst = new List<Account_BenhNhanDTO>();
            foreach (var item in db.Account_BenhNhan.Where(q => q.Status != "DELETE"))
            {
                lst.Add(ConvertToAccount_BenhNhanDTO(item));
            }
            return lst;
        }

        public static Account_BenhNhanDTO ConvertToAccount_BenhNhanDTO(Account_BenhNhan item)
        {
            if (item == null) return null;
            return new Account_BenhNhanDTO
            {
                Adress = item.Adress,
                Avatar = item.Avatar,
                Birthday = item.Birthday,
                Email = item.Email,
                IDAccountBN = item.IDAccountBN,
                FullName = item.FullName,
                Male = item.Male == true,
                Password = item.Password,
                Phone = item.Phone,
                Status = item.Status,
                TieuSu = item.TieuSu,
                Username = item.Username,
            };
        }

        [HttpPost]
        [BasicAuthentication]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> ChangeAvatar(int id)
        {
            var acc = LoginHelper.GetAccount();
            if (acc.IDAccountBN != id)
                return NotFound();

            var Account_BenhNhan = db.Account_BenhNhan.Find(id);
            if (Account_BenhNhan != null)
            {
                var save = UploadHelper.SaveImage();
                if (save.Key)
                {
                    Account_BenhNhan.Avatar = save.Value;
                    db.Entry(Account_BenhNhan).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Ok(Account_BenhNhan.Avatar);
                }
                return Content(HttpStatusCode.NotAcceptable, save.Key);
            }
            return BadRequest();
        }

        // GET: api/Account_BenhNhans/5
        [ResponseType(typeof(Account_BenhNhanDTO))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> GetAccount_BenhNhan(int id)
        {
            var acc = LoginHelper.GetAccount();
            if (acc.IDAccountBN != id)
                return NotFound();

            Account_BenhNhan item = await db.Account_BenhNhan.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(ConvertToAccount_BenhNhanDTO(item));
        }

        // PUT: api/Account_BenhNhans/5
        [ResponseType(typeof(void))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> PutAccount_BenhNhan(int id, Account_BenhNhan Account_BenhNhan)
        {
            if (LoginHelper.CheckAccount(id) == false || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Account_BenhNhan.IDAccountBN)
            {
                return BadRequest();
            }

            db.Entry(Account_BenhNhan).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Account_BenhNhanExists(id))
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

        // POST: api/Account_BenhNhans
        [ResponseType(typeof(string))]
        [AdminAuthentication]
        public async Task<IHttpActionResult> PostAccount_BenhNhan(Account_BenhNhan Account_BenhNhan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Account_BenhNhan.Add(Account_BenhNhan);
            await db.SaveChangesAsync();

            return Ok("SUCCESS");
        }

        // DELETE: api/Account_BenhNhans/5
        [ResponseType(typeof(Account_BenhNhanDTO))]
        [AdminAuthentication("SA", "BACSI")]
        public async Task<IHttpActionResult> DeleteAccount_BenhNhan(int id)
        {
            Account_BenhNhan Account_BenhNhan = await db.Account_BenhNhan.FindAsync(id);
            if (Account_BenhNhan == null)
            {
                return NotFound();
            }

            Account_BenhNhan.Status = "DELETE";
            await db.SaveChangesAsync();

            return Ok(ConvertToAccount_BenhNhanDTO(Account_BenhNhan));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Account_BenhNhanExists(int id)
        {
            return db.Account_BenhNhan.Count(e => e.IDAccountBN == id) > 0;
        }

        [HttpGet]
        [AdminAuthentication]
        [ResponseType(typeof(Account_BenhNhan))]
        public async Task<IHttpActionResult> FindBN([FromUri]string MaYTe)
        {
            if (string.IsNullOrWhiteSpace(MaYTe)) return NotFound();
            var acc = await db.Account_BenhNhan.FirstOrDefaultAsync(q => q.Username == MaYTe);
            if (acc == null || acc.Status == "DELETE") return NotFound();
            return Ok(ConvertToAccount_BenhNhanDTO(acc));
        }
        #endregion

        #region NHANVIEN

        #endregion
    }
}