using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedure.Web.Controllers
{
    public class RegisterController : BaseController
    {
        // GET: Register
        public ActionResult Index()
        {
            var lstRegister = new RegisterBUS(this).GetByAccount(Account.IDAccountBN);
            return View(lstRegister);
        }

        public ActionResult Create(int IDLich)
        {
            var data = new LichLamViecsBUS(this).GetByID(IDLich);
            return View(new RegisterDTO { LichLamViec = data, IDLich = IDLich });
        }

        [HttpPost]
        public ActionResult Create(RegisterDTO register)
        {
            register.IDAccount = Account.IDAccountBN;
            register.CreateDate = DateTime.Now;
            register.Status = "CONFIRM";
            new RegisterBUS(this).Create(register);
            return RedirectToAction("Index");
        }

        public JsonResult Cancle(int id)
        {
            return Json(new RegisterBUS(this).Cancle(id));
        }
    }
}