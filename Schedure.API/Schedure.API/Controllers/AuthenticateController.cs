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
            var token = Convert.ToBase64String(new UTF8Encoding().GetBytes($"BN:{account.IDAccountBN}:{Username}:{Password}"));
            return Ok(token);
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Register(Account_BenhNhanDTO account)
        {
            var acc = await db.Account_BenhNhan.FirstOrDefaultAsync(q => q.Username == account.MaYTe || q.Email == account.Email);
            if (acc == null)
            {
                var bn = await db.DM_BenhNhan.FirstOrDefaultAsync(q => q.MaYTe == account.MaYTe);
                if (bn != null)
                {
                    account.Status = CONFIRM;
                    account.Username = account.MaYTe;
                    acc = db.Account_BenhNhan.Add(new Account_BenhNhan
                    {
                        Adress = account.Adress,
                        Avatar = account.Avatar,
                        BenhNhan_Id = bn.BenhNhan_Id,
                        Birthday = account.Birthday,
                        Email = account.Email,
                        FullName = account.FullName,
                        IDAccountBN = account.IDAccountBN,
                        Male = account.Male,
                        Password = account.Password,
                        Phone = account.Phone,
                        Status = account.Status,
                        TieuSu = account.TieuSu,
                        Username = account.Username,
                    });
                    if ((await db.SaveChangesAsync()) > 0)
                    {
                        string urlConfirm = $"{acc.IDAccountBN}:{acc.Username}:{acc.Email}";
                        urlConfirm = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlConfirm));
                        urlConfirm = "http://" + Request.RequestUri.Authority + Url.Route("Custom", new { action = "Confirm", id = urlConfirm });

                        string bodyEmail = $"<a href='{urlConfirm}'>Bấm để xác nhận tài khoản.</a>" +
                             $"<br/>THÔNG TIN TÀI KHOẢN: " +
                             $"<br>Username: {acc.Username}" +
                             $"<br/>Password: {acc.Password}";
                        var success = MailHelper.SendMail(account.Email, "Xác nhận tài khoản", bodyEmail);
                        if (success)
                        {
                            return Ok("OK");
                        }
                        return Content(HttpStatusCode.Created, "Vui lòng xác nhận tài khoản với email " + acc.Email);
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotAcceptable, "Server không thể cấp tài khoản cho quý khách!");
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
        [ResponseType(typeof(Account_BenhNhanDTO))]
        public async Task<IHttpActionResult> GetAccount(string token)
        {
            try
            {
                if (token != null)
                {
                    var decodeAuthorization = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    var up = decodeAuthorization.Split(':');
                    if (up.Length == 4 && up[0] == "BN")
                    {
                        int IDAccount = int.Parse(up[1]);
                        string username = up[2];
                        string password = up[3];
                        var account = await db.Account_BenhNhan.FindAsync(IDAccount);
                        if (account != null && account.Username == username && account.Password == password && account.Status != "DELETE")
                        {
                            return Ok(ConvertToAccountBNDTO(account));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return NotFound();
        }


        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> ResendMail([FromUri] string email, [FromUri] string maYte)
        {
            var account = await db.Account_BenhNhan.FirstOrDefaultAsync(q => q.Username == maYte);
            if (account != null && account.Status == CONFIRM && account.Email == email && account.DM_BenhNhan.MaYTe == maYte)
            {
                string urlConfirm = $"{account.IDAccountBN}:{account.Username}:{account.Email}";
                urlConfirm = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlConfirm));
                urlConfirm = "http://" + Request.RequestUri.Authority + Url.Route("Custom", new { action = "Confirm", id = urlConfirm });

                var success = MailHelper.SendMail(account.Email, "Xác nhận lại tài khoản", $"<a href='{urlConfirm}'>Bấm để xác nhận tài khoản.</a>" +
                     $"<br/>THÔNG TIN TÀI KHOẢN: " +
                     $"<br>Username: {account.Username}" +
                     $"<br/>Password: {account.Password}");
                if (success)
                {
                    return Ok("Gửi mail thành công!");
                }
                return Content(HttpStatusCode.Created, "Gửi mail thất bại!");
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Confirm(string id)
        {
            if (id == null) return Content(HttpStatusCode.BadRequest, "");

            var url = Encoding.UTF8.GetString(Convert.FromBase64String(HttpUtility.UrlDecode(id)));
            var decodeArray = url.Split(':');
            if (decodeArray.Length != 3) return Content(HttpStatusCode.BadRequest, "");

            var account_test = new Account_BenhNhan
            {
                Username = decodeArray[1],
                Email = decodeArray[2]
            };
            int idAccount = 0;
            if (int.TryParse(decodeArray[0], out idAccount))
            {
                account_test.IDAccountBN = idAccount;

                if (db.Account_BenhNhan.Find(account_test.IDAccountBN) is Account_BenhNhan account)
                {
                    if (account.Username == account_test.Username && account.Email == account_test.Email && account.Status == CONFIRM)
                    {
                        account.Status = ACTIVE;
                        await db.SaveChangesAsync();
                        return Content(HttpStatusCode.OK, $"{account.Email} xác nhận thành công.");
                    }
                }
            }
            return Content(HttpStatusCode.BadRequest, "Xác nhận thất bại");
        }
        public static Account_BenhNhanDTO ConvertToAccountBNDTO(Account_BenhNhan account)
        {
            return new Account_BenhNhanDTO
            {
                Adress = account.Adress,
                Avatar = account.Avatar,
                Birthday = account.Birthday,
                Email = account.Email,
                FullName = account.FullName,
                Male = account.Male == true,
                IDAccountBN = account.IDAccountBN,
                Password = account.Password,
                Phone = account.Phone,
                Status = account.Status,
                TieuSu = account.TieuSu,
                Username = account.Username,
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
                NhanVien = ConvertToNhanVienDTO(account.NhanVien),
                Position = ConvertToPositionDTO(account.Position),
            };
        }

        private static PositionDTO ConvertToPositionDTO(Position position)
        {
            if (position == null) return null;
            return new PositionDTO
            {
                IDPosition = position.IDPosition,
                Name = position.Name,
                MoTa = position.MoTa,
            };
        }

        private static NhanVienDTO ConvertToNhanVienDTO(NhanVien nhanVien)
        {
            if (nhanVien == null) return null;
            return new NhanVienDTO
            {
                CMND = nhanVien.CMND,
                DiaChi = nhanVien.DiaChi,
                GioiTinh = nhanVien.GioiTinh,
                Ho = nhanVien.Ho,
                MaNhanVien = nhanVien.MaNhanVien,
                NgaySinh = nhanVien.NgaySinh,
                NgayTao = nhanVien.NgayTao,
                NguoiTao_Id = nhanVien.NguoiTao_Id,
                NhanVien_Id = nhanVien.NhanVien_Id,
                TamNgung_Id = nhanVien.TamNgung_Id,
                Ten = nhanVien.Ten,
                TenTat = nhanVien.TenTat,
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
            var token = Convert.ToBase64String(new UTF8Encoding().GetBytes($"NV:{account.IDAccountNV}:{Username}:{Password}"));
            return Ok(token);
        }

        [HttpPost]
        [ResponseType(typeof(Account_NhanVienDTO))]
        public async Task<IHttpActionResult> GetAccountNV(string token)
        {
            try
            {
                if (token != null)
                {
                    var decodeAuthorization = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    var up = decodeAuthorization.Split(':');
                    if (up.Length == 4 && up[0] == "NV")
                    {
                        int IDAccountNV = int.Parse(up[1]);
                        string username = up[2];
                        string password = up[3];
                        Account_NhanVien account = await db.Account_NhanVien.FindAsync(IDAccountNV);
                        if (account != null && account.Username == username && account.Password == password && account.Status != "DELETE")
                        {
                            return Ok(ConvertToAccountNVDTO(account));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return NotFound();
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
