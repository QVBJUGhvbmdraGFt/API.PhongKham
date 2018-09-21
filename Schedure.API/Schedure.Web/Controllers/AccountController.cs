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
        // GET: Account
        public ActionResult Index()
        {
            var myAacount = new AuthenticateBUS().GetAccount(GetToken());
            return View(myAacount);
        }

        [HttpPost]
        public ActionResult Index(Account_BenhNhanDTO account)
        {
            new AccountBUS(this).Update(account);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string OldPass, string NewPass, string RePass)
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
                    myAacount.Password = NewPass;
                    new AccountBUS(this).Update(myAacount);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Mật khẩu cũ không chính xác");
            }
            return View();
        }


        [HttpPost]
        public JsonResult ChangeAvatar(HttpPostedFileBase Avatar)
        {
            byte[] data;
            using (Stream inputStream = Avatar.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            return Json(new AccountBUS(this).ChangeAvatar(Account.IDAccountBN, data, Avatar.FileName).Value);
        }
    }
}