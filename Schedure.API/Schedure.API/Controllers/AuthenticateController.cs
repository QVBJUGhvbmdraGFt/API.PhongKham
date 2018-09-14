using Schedure.API.Models;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Schedure.API.Controllers
{
    public class AuthenticateController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();
        private readonly string CONFIRM = "CONFIRM";
        const string ACTIVE = "ACTIVE";


        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Login([FromUri]string Username, [FromUri]string Password)
        {
            Account account = await db.Accounts.FirstOrDefaultAsync(q => q.Username == Username && q.Password == Password && q.Status == ACTIVE);
            if (account == null)
            {
                return NotFound();
            }
            var token = Convert.ToBase64String(new UTF8Encoding().GetBytes($"{Username}:{Password}"));
            return Ok(token);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Register(Account account)
        {
            var acc = await db.Accounts.FirstOrDefaultAsync(q => q.Username == account.Username && q.Status == ACTIVE);
            if (acc == null)
            {
                account.Status = CONFIRM;
                db.Accounts.Add(account);
                await db.SaveChangesAsync();

                string urlConfirm = $"{account.IDAccount}:{account.Username}:{account.Email}";
                urlConfirm = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlConfirm));
                urlConfirm = "http://" + Request.RequestUri.Authority + Url.Route("Custom", new { action = "Confirm", id = urlConfirm });

                MailHelper.SendMail(account.Email, "Xác nhận", $"<a href='{urlConfirm}'>Bấm để xác nhận Confirm</a>");

                return Ok(urlConfirm);
            }
            else
            {
                return Content(HttpStatusCode.NotAcceptable, "Tài khoản đã tồn tại");
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Confirm(string id)
        {
            if (id == null) return Content(HttpStatusCode.BadRequest, "");

            var url = Encoding.UTF8.GetString(Convert.FromBase64String(HttpUtility.UrlDecode(id)));
            var decodeArray = url.Split(':');
            if (decodeArray.Length != 3) return Content(HttpStatusCode.BadRequest, "");

            var account_test = new Account
            {
                Username = decodeArray[1],
                Email = decodeArray[2]
            };
            int idAccount = 0;
            if (int.TryParse(decodeArray[0], out idAccount))
            {
                account_test.IDAccount = idAccount;

                if (db.Accounts.Find(account_test.IDAccount) is Account account)
                {
                    if (account.Username == account_test.Username && account.Email == account_test.Email && account.Status == CONFIRM)
                    {
                        account.Status = ACTIVE;
                        await db.SaveChangesAsync();
                        return Content(HttpStatusCode.OK, "Xác nhận thành công.");
                    }
                }
            }
            return Content(HttpStatusCode.BadRequest, "");
        }

        [HttpPost]
        [ResponseType(typeof(AccountDTO))]
        public async Task<IHttpActionResult> GetAccount(string token)
        {
            if (token == null) return NotFound();

            var decodeAuthorization = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var up = decodeAuthorization.Split(':');
            if (up.Length != 2) return NotFound();

            string username = up[0];
            string password = up[1];
            Account account = await db.Accounts.FirstOrDefaultAsync(q => q.Username == username && q.Password == password && q.Status != "DELETE");
            if (account == null)
            {
                return NotFound();
            }

            return Ok(ConvertToAccountDTO(account));
        }

        private AccountDTO ConvertToAccountDTO(Account account)
        {
            return new AccountDTO
            {
                Adress = account.Adress,
                Avatar = account.Avatar,
                Birthday = account.Birthday,
                Email = account.Email,
                FullName = account.FullName,
                Male = account.Male,
                IDAccount = account.IDAccount,
                Password = account.Password,
                Phone = account.Phone,
                POSITION = account.POSITION,
                Status = account.Status,
                TieuSu = account.TieuSu,
                Username = account.Username,
            };
        }
    }
}
