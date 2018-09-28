using Schedure.Web.Models;
using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedure.Web.Controllers
{
    public class Register2Controller : Controller
    {
        public ActionResult Index(int IDLich)
        {
            var data = new LichLamViecsBUS().GetByID(IDLich);
            return View(new RegisterDTO
            {
                LichLamViec = data,
                IDLich = IDLich,
                NhanVien_Id = data.NhanVien_Id,
                IDChuyenKhoa = data.Doctor.PhongBan.IDChuyenKhoa,
                IDAccountBN = LoginHelper.GetAccountBN()?.IDAccountBN
            });
        }

        [HttpPost]
        public ActionResult Index(RegisterDTO register)
        {
#if DEBUG == false || true
            if (CaptchaGoogle.CheckCaptcha().IsSuccess)
            {
#endif
            register.IDAccountBN = LoginHelper.GetAccountBN()?.IDAccountBN;
            string message = RegisterBUS.Create(register) ? "Đăng kí thành công" : "Đăng kí thất bại";
            return RedirectToAction("Result", "Register2", new { message = message });
#if DEBUG == false || true
            }
            ModelState.AddModelError("", "Vui lòng nhập captcha");
            return View(register.IDLich);
#endif
        }

        public ActionResult Result(string message)
        {
            ViewBag.message = message;
            return View();
        }
    }
}