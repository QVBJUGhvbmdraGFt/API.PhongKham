using SchedureBUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedure.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var allSpecia = new SpeciaBUS(this).GetAll();
            return View(allSpecia);
        }

        public ActionResult Detail(int id)
        {
            var specia = new SpeciaBUS(this).GetByID(id);
            ViewBag.specia = specia;

            var doctors= new DoctorBUS(this).GetBySpecia(id);
            return View(doctors);
        }
    }
}