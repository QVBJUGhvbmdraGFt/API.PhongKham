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
                Email = item.Email,
                IDAccountBN = item.IDAccountBN,
                BenhNhan_Id = item.BenhNhan_Id,
                Password = item.Password,
                Status = item.Status,
                Token = item.Token,
                Username = item.Username,
                TokenExpiration = item.TokenExpiration,
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
                    db.Entry(Account_BenhNhan).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Ok();
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

        [HttpPost]
        [BasicAuthentication]
        [ResponseType(typeof(bool))]
        public bool BNChangePassword([FromUri]string oldpass, [FromUri] string newpass)
        {
            if (newpass.Length >= 8)
            {
                var acc = LoginHelper.GetAccount();
                if (acc.Password == oldpass)
                {
                    var obj = db.Account_BenhNhan.Find(acc.IDAccountBN);
                    if (obj != null)
                    {
                        obj.Password = newpass;
                        db.Entry(obj).State = EntityState.Modified;
                        return db.SaveChanges() > 0;
                    }
                }
            }
            return false;
        }

        #endregion

        #region NHANVIEN

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(bool))]
        public bool NVChangePassword(string oldpass, string newpass)
        {
            if (newpass.Length >= 8)
            {
                var acc = LoginHelper.GetAccountNV();
                if (acc.Password == oldpass)
                {
                    var obj = db.Account_NhanVien.Find(acc.IDAccountNV);
                    if (obj != null)
                    {
                        obj.Password = newpass;
                        db.Entry(obj).State = EntityState.Modified;
                        return db.SaveChanges() > 0;
                    }
                }
            }
            return false;
        }

        [HttpGet]
        [AdminAuthentication]
        [ResponseType(typeof(DM_BenhNhan))]
        public IHttpActionResult FindBN([FromUri]string MaYTe)
        {
            if (string.IsNullOrWhiteSpace(MaYTe)) return NotFound();
            var acc = db.SP_DM_BenhNhan_GetByMaYTe(MaYTe);
            foreach (var item in acc)
            {
                return Ok(new DM_BenhNhan
                {
                    BenhNhan_Id = item.BenhNhan_Id,
                    ChucVu = item.ChucVu,
                    CMND = item.CMND,
                    DiaChi = item.DiaChi,
                    Email = item.Email,
                    GhiChu = item.GhiChu,
                    GioiTinh = item.GioiTinh,
                    Ho = item.Ho,
                    MaBenhVien = item.MaBenhVien,
                    MaYTe = item.MaYTe,
                    NamSinh = item.NamSinh,
                    NgayHetHieuLuc_BHYT = item.NgayHetHieuLuc_BHYT,
                    NgayHieuLuc_BHYT = item.NgayHieuLuc_BHYT,
                    NgaySinh = item.NgaySinh,
                    SoThe_BHYT = item.SoThe_BHYT,
                    SoVaoVien = item.SoVaoVien,
                    Ten = item.Ten,
                    TenBenhNhan = item.TenBenhNhan,
                    TenKhongDau = item.TenKhongDau,
                    TienSuBenh = item.TienSuBenh,
                    VietKieu = item.VietKieu,
                });
            }
            return NotFound();
        }

        [HttpPost]
        [ResponseType(typeof(Account_NhanVienDTO))]
        [AdminAuthentication]
        public IHttpActionResult GetAccountNV()
        {
            try
            {
                var acc = LoginHelper.GetAccountNV();
                if (acc != null)
                {
                    return Ok(AuthenticateController.ConvertToAccountNVDTO(acc));
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return NotFound();
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(List<Account_NhanVienDTO>))]
        public IEnumerable<Account_NhanVienDTO> GetAllNV()
        {
            try
            {
                var data = db.SP_Account_NhanVien_GetAllOrByID(null);
                return data.ToList().Select(q => new Account_NhanVienDTO
                {
                    IDAccountNV = q.IDAccountNV,
                    IDPosition = q.IDPosition,
                    MaNhanvien = q.MaNhanVien,
                    NhanVien_Id = q.NhanVien_Id,
                    Password = q.Password,
                    Status = q.Status,
                    TenNhanVien = q.TenNhanVien,
                    Username = q.Username,
                    Position = new PositionDTO
                    {
                        Name = q.Name,
                        Status = q.Status
                    }
                }).ToList();
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return new List<Account_NhanVienDTO>();
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(List<Account_NhanVienDTO>))]
        public IEnumerable<Account_NhanVienDTO> GetSourceNV()
        {
            try
            {
                var data = db.SP_Account_NhanVien_GetSource();
                return data.ToList().Select(q => new Account_NhanVienDTO
                {
                    MaNhanvien = q.MaNhanVien,
                    NhanVien_Id = q.NhanVien_Id,
                    TenNhanVien = q.TenNhanVien,
                    Position = null
                }).ToList();
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return new List<Account_NhanVienDTO>();
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Delete(int NVID)
        {
            var acc = db.Account_NhanVien.Find(NVID);
            if (acc != null)
            {
                acc.Status = "DELETE";
                return Ok(db.SaveChanges() > 0);
            }
            return NotFound();
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(bool))]
        public IHttpActionResult UpdateNV(Account_NhanVien nv)
        {
            if (nv != null)
            {
                var ac = db.Account_NhanVien.Find(nv.IDAccountNV);
                if (ac != null)
                {
                    ac.IDPosition = nv.IDPosition;
                    if (nv.Password?.Length >= 0)
                    {
                        ac.Password = nv.Password;
                    }
                    return Ok(db.SaveChanges() > 0);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [AdminAuthentication]
        [ResponseType(typeof(bool))]
        public IHttpActionResult CreateNV(Account_NhanVien nv)
        {
            if (nv != null)
            {
                db.Account_NhanVien.Add(nv);
                return Ok(db.SaveChanges() > 0);
            }
            return NotFound();
        }

        #endregion
    }
}