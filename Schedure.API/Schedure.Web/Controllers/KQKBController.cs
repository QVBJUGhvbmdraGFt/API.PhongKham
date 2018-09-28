using SchedureBUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedure.Web.Controllers
{
    public class KQKBController : BaseController
    {
        public ActionResult Index(string start, string end)
        {
            DateTime d_end = DateTime.Now;
            DateTime d_start = d_end.AddDays(-30);
            if (string.IsNullOrWhiteSpace(start) == false)
            {
                d_start = DateTime.ParseExact(start, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (string.IsNullOrWhiteSpace(end) == false)
            {
                d_end = DateTime.ParseExact(end, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            ViewBag.s_start = d_start.ToString("yyyy-MM-dd");
            ViewBag.s_end = d_end.ToString("yyyy-MM-dd");

            var kqbetween = new KQKBBUS(this).Fillter(d_start, d_end);
            return View(kqbetween);
        }

        public ActionResult Detail(int KhamBenh_Id)
        {
            var data = new KQKBBUS(this).GetByKhamBenhId(KhamBenh_Id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }
    }
}