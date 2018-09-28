using Newtonsoft.Json;
using Schedure.Web.Models;
using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Schedure.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            if (CaptchaGoogle.CheckCaptcha().IsSuccess)
            {
                var res = new AuthenticateBUS().Login(Username, Password);
                Session["TOKEN"] = res.Value;
                if (res.Key)
                {
                    Session["LOGIN"] = new AuthenticateBUS().GetAccount(res.Value);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập capcha");
            }
            ModelState.AddModelError("", "Đăng nhập thất bại.");
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Account_BenhNhanDTO account)
        {
            var res = await new AuthenticateBUS().Register(account);
            switch (res.Key)
            {
                case 0:
                    ModelState.AddModelError("", "Đăng kí thất bại");
                    break;
                case 1:
                case 2:
                    return RedirectToAction("Confirm", account);
                case 3:
                    ModelState.AddModelError("", "Thông tin tài khoản đã tồn tại!");
                    break;
                default:
                    break;
            }
            ModelState.AddModelError("", res.Value);
            return View();
        }

        public ActionResult Confirm(Account_BenhNhanDTO account)
        {
            return View(account);
        }

        public async Task<ActionResult> ResendMail(string Email, string MaYte)
        {
            var res = await new AuthenticateBUS().ResendMail(Email, MaYte);
            ModelState.AddModelError("", "ResendMail: " + res.Value);
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }


}