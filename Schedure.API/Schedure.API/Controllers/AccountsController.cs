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
    [BasicAuthentication("", "SA", "BACSI", "YTA")]
    public class AccountsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/Accounts
        [BasicAuthentication("SA", "BACSI", "YTA")]
        public List<AccountDTO> GetAccounts()
        {
            var lst = new List<AccountDTO>();
            foreach (var item in db.Accounts.Where(q => q.Status != "DELETE"))
            {
                lst.Add(ConvertToAccountDTO(item));
            }
            return lst;
        }

        private AccountDTO ConvertToAccountDTO(Account item)
        {
            return new AccountDTO
            {
                Adress = item.Adress,
                Avatar = item.Avatar,
                Birthday = item.Birthday,
                Email = item.Email,
                IDAccount = item.IDAccount,
                FullName = item.FullName,
                Male = item.Male,
                Password = item.Password,
                Phone = item.Phone,
                POSITION = item.POSITION,
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
            if (string.IsNullOrWhiteSpace(acc.POSITION) && acc.IDAccount != id)
                return NotFound();

            var account = db.Accounts.Find(id);
            if (account != null)
            {
                var save = UploadHelper.SaveImage();
                if (save.Key)
                {
                    account.Avatar = save.Value;
                    db.Entry(account).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Ok(account.Avatar);
                }
                return Content(HttpStatusCode.NotAcceptable, save.Key);
            }
            return BadRequest();
        }

        // GET: api/Accounts/5
        [ResponseType(typeof(AccountDTO))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> GetAccount(int id)
        {
            var acc = LoginHelper.GetAccount();
            if (string.IsNullOrWhiteSpace(acc.POSITION) && acc.IDAccount != id)
                return NotFound();

            Account item = await db.Accounts.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(ConvertToAccountDTO(item));
        }

        // PUT: api/Accounts/5
        [ResponseType(typeof(void))]
        [BasicAuthentication]
        public async Task<IHttpActionResult> PutAccount(int id, Account account)
        {
            if (LoginHelper.CheckAccount(id) == false || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.IDAccount)
            {
                return BadRequest();
            }

            db.Entry(account).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        [ResponseType(typeof(string))]
        [BasicAuthentication("SA", "BACSI", "YTA")]
        public async Task<IHttpActionResult> PostAccount(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accounts.Add(account);
            await db.SaveChangesAsync();

            return Ok("SUCCESS");
        }

        // DELETE: api/Accounts/5
        [ResponseType(typeof(AccountDTO))]
        [BasicAuthentication("SA", "BACSI")]
        public async Task<IHttpActionResult> DeleteAccount(int id)
        {
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            account.Status = "DELETE";
            await db.SaveChangesAsync();

            return Ok(ConvertToAccountDTO(account));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountExists(int id)
        {
            return db.Accounts.Count(e => e.IDAccount == id) > 0;
        }

    }
}