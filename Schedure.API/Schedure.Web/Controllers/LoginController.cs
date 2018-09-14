using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var res = new AuthenticateBUS().Login(Username, Password);
            Session["TOKEN"] = res.Value;
            if (res.Key)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Đăng nhập thất bại.");
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountDTO account)
        {
            var res = new AuthenticateBUS().Register(account);
            if (res.Key)
            {
                return RedirectToAction("Confirm", account);
            }
            ModelState.AddModelError("", res.Value);
            return View();
        }

        public ActionResult Confirm(AccountDTO account)
        {
            return View(account);
        }

        public ActionResult Logout()
        {
            Session["TOKEN"] = null;
            return RedirectToAction("Index");
        }
    }
}