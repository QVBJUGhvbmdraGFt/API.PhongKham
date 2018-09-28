using Schedure.API.Models;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

        #region BenhNhan
        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Login([FromUri]string Username, [FromUri]string Password)
        {
            Account_BenhNhan account = await db.Account_BenhNhan.FirstOrDefaultAsync(q => q.Username == Username && q.Password == Password && q.Status == ACTIVE);
            if (account == null)
            {
                return NotFound();
            }

            var time = TimeSpan.FromHours(10);
            var Expiration = DateTime.Now.Add(time);
            account.TokenExpiration = Expiration;

            var token = Convert.ToBase64String(new UTF8Encoding().GetBytes($"BN:{account.IDAccountBN}:{Username}:{Password}:{Expiration}:{new Random().Next(1000, 9999)}"));
            token = token.CreateMD5();
            account.Token = token;

            if (await db.SaveChangesAsync() > 0)
            {
                token = $"{account.IDAccountBN}:{token}";
                token = Convert.ToBase64String(new UTF8Encoding().GetBytes(token));
                return Ok(token);
            }
            return BadRequest();
        }

        #region CONFIRM

        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Register(Account_BenhNhanDTO account)
        {
            var acc = await db.Account_BenhNhan.FirstOrDefaultAsync(q => q.Username == account.MaYTe && q.Status == "ACTIVE");
            if (acc == null)
            {
                var bn = db.SP_DM_BenhNhan_GetByMaYTe(account.MaYTe).FirstOrDefault();
                if (bn != null)
                {
                    var id = db.SP_Account_BenhNhan_Insert(account.Password, account.Email, account.MaYTe).FirstOrDefault();
                    if (id != null)
                    {

                        if (_sendMailConfirm(id.IDAccountBN ?? 0))
                        {
                            return Ok("Vui lòng xác nhận tài khoản, kiểm tra mail " + account.Email);
                        }
                        return Content(HttpStatusCode.Created, "Vui lòng xác nhận tài khoản, thử lại gửi mail: " + account.Email);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            else
            {
                if (acc.Status == CONFIRM)
                {
                    return Content(HttpStatusCode.Created, "Vui lòng xác nhận tài khoản với email " + acc.Email);
                }
                else if (acc.Status == ACTIVE)
                {
                    return Content(HttpStatusCode.NotAcceptable, "Tài khoản đã tồn tại");
                }
            }
            return Content(HttpStatusCode.NotAcceptable, "Thông tin Email hoặc Mã y tế đã được sử dụng");
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> ResendMail([FromUri] string email, [FromUri] string maYte)
        {
            var account = await db.Account_BenhNhan.FirstOrDefaultAsync(q => q.Username == maYte && q.Email == email && q.Status == CONFIRM);
            if (account != null)
            {
                if (_sendMailConfirm(account.IDAccountBN))
                {
                    return Ok("Gửi mail thành công");
                }
                return Content(HttpStatusCode.Created, "Gửi mail thất bại!");
            }
            return NotFound();
        }

        private bool _sendMailConfirm(int IDAccountBN)
        {
            var acc = db.Account_BenhNhan.Find(IDAccountBN);
            if (acc != null && acc.Status == CONFIRM)
            {
                acc.TokenExpiration = DateTime.Now.AddDays(1);
                acc.Token = $"{acc.IDAccountBN}:{acc.TokenExpiration}:{new Random().Next()}".CreateMD5();
                if (db.SaveChanges() > 0)
                {
                    string urlConfirm = $"{acc.Username}:{acc.Token}";
                    urlConfirm = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlConfirm));
                    urlConfirm = "http://" + Request.RequestUri.Authority + Url.Route("Custom", new { action = "Confirm", id = urlConfirm });

                    string bodyEmail = $"<a href='{urlConfirm}'>Bấm vào đây để xác nhận tài khoản.</a>" +
                         $"<br/>THÔNG TIN TÀI KHOẢN: " +
                         $"<br>Username: {acc.Username}" +
                         $"<br/>Password: {acc.Password}";
                    return MailHelper.SendMail(acc.Email, "Xác nhận tài khoản", bodyEmail);
                }
            }
            return false;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Confirm(string id)
        {
            if (id == null) return Content(HttpStatusCode.BadRequest, "");

            var url = Encoding.UTF8.GetString(Convert.FromBase64String(HttpUtility.UrlDecode(id)));
            var decodeArray = url.Split(':');
            if (decodeArray.Length != 2) return Content(HttpStatusCode.BadRequest, "");

            var account_test = new Account_BenhNhan
            {
                Username = decodeArray[0],
                Token = decodeArray[1],
            };
            if (db.Account_BenhNhan.FirstOrDefault(q => q.Username == account_test.Username) is Account_BenhNhan account)
            {
                if (account.Token == account_test.Token && account.Status == CONFIRM)
                {
                    if (account.TokenExpiration >= DateTime.Now)
                    {
                        account.Status = ACTIVE;
                        await db.SaveChangesAsync();
                        return Content(HttpStatusCode.OK, $"{account.Email} xác nhận thành công.");
                    }
                    else return Content(HttpStatusCode.OK, $"{account.Email} hết thời gian xác nhận.");
                }
            }
            return Content(HttpStatusCode.BadRequest, "Xác nhận thất bại");
        }
        #endregion


        [HttpPost]
        [ResponseType(typeof(Account_BenhNhanDTO))]
        [BasicAuthentication]
        public IHttpActionResult GetAccount()
        {
            try
            {
                var acc = LoginHelper.GetAccount();
                if (acc != null)
                {
                    return Ok(ConvertToAccountBNDTO(acc));
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return NotFound();
        }



        public static Account_BenhNhanDTO ConvertToAccountBNDTO(Account_BenhNhan account)
        {
            return new Account_BenhNhanDTO
            {
                Email = account.Email,
                IDAccountBN = account.IDAccountBN,
                Password = account.Password,
                Status = account.Status,
                Username = account.Username,
                MaYTe = account.Username,
                BenhNhan_Id = account.BenhNhan_Id,
                Token = account.Token,
                TokenExpiration = account.TokenExpiration,
            };
        }
        #endregion

        #region NhanVien
        public static Account_NhanVienDTO ConvertToAccountNVDTO(Account_NhanVien account)
        {
            if (account == null) return null;
            return new Account_NhanVienDTO
            {
                IDAccountNV = account.IDAccountNV,
                IDPosition = account.IDPosition,
                NhanVien_Id = account.NhanVien_Id,
                Status = account.Status,
                Username = account.Username,
                Password = account.Password,
                Position = PositionsController.ConvertToPositionDTO(account.Position),
            };
        }

        private static PositionDTO ConvertToPositionDTO(Position position)
        {
            if (position == null) return null;
            return new PositionDTO
            {
                IDPosition = position.IDPosition,
                Name = position.Name,
            };
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> LoginNV([FromUri]string Username, [FromUri]string Password)
        {
            Account_NhanVien account = await db.Account_NhanVien.FirstOrDefaultAsync(q => q.Username == Username && q.Password == Password && q.Status == ACTIVE);
            if (account == null)
            {
                return NotFound();
            }
            var time = TimeSpan.FromHours(10);
            var Expiration = DateTime.Now.Add(time);
            var token = Convert.ToBase64String(new UTF8Encoding().GetBytes($"NV:{account.IDAccountNV}:{Username}:{Password}:{new Random().Next()}"));
            token = token.CreateMD5();
            account.Token = token;
            account.TokenExpiration = Expiration;
            if (await db.SaveChangesAsync() > 0)
            {
                token = $"{account.IDAccountNV}:{token}";
                return Ok(Convert.ToBase64String(Encoding.UTF8.GetBytes(token)));
            }
            return BadRequest();
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
