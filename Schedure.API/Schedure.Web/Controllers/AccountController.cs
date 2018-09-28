using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedure.Web.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string OldPass, string NewPass, string RePass)
        {
            bool validate = true;
            if (NewPass.Length < 8)
            {
                ModelState.AddModelError("", "Mật khẩu có ít nhất 8 kí tự");
                validate = false;
            }
            if (NewPass != RePass)
            {
                ModelState.AddModelError("", "Vui lòng xác nhận mật khẩu trùng khớp");
                validate = false;
            }
            var myAacount = new AuthenticateBUS().GetAccount(GetToken());
            if (myAacount.Password == OldPass)
            {
                if (validate)
                {
                    string error = "";
                    if (new AccountBUS(this).BNChangePassword(OldPass, NewPass, RePass, ref error))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Mật khẩu cũ không chính xác");
            }
            return View();
        }
    }
}