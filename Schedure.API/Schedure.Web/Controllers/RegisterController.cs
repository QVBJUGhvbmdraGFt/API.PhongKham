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
            var lstRegister = new RegisterBUS(this).GetByAccount(Account.IDAccount);
            return View(lstRegister);
        }

        public ActionResult Create(int idSpecia)
        {
            ViewBag.doctors = new SelectList(new DoctorBUS(this).GetBySpecia(idSpecia), "IDDoctor", "FullName");
            ViewBag.sepecia = new SpeciaBUS(this).GetByID(idSpecia);
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterDTO register)
        {
            register.IDAccount = Account.IDAccount;
            register.CreateDate = DateTime.Now;
            register.Status = "ACTIVE";
            new RegisterBUS(this).Create(register);
            return RedirectToAction("Index");
        }

        public JsonResult Cancle(int id)
        {
            return Json(new RegisterBUS(this).Cancle(id));
        }
    }
}