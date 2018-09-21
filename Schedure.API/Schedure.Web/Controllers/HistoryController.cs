using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedure.Web.Controllers
{
    public class HistoryController : BaseController
    {
        // GET: History
        public ActionResult Index()
        {
            return View(new HistoryKhamBenhBUS(this).GetByAccount(Account.IDAccountBN));
        }

        [HttpPost]
        public ActionResult Index(string key, List<HistoryKhamBenhDTO> list)
        {
            return View("LichSu", new HistoryKhamBenhBUS(this).GiaiMaHistoryKhamBenhs(list, key));
        }

        public ActionResult Detail(int IDHistory)
        {
            var history = new HistoryKhamBenhBUS(this).GetByID(IDHistory);
            if (history.CachGiaiQuyet == "CapDonThuoc")
            {
                var toaThuoc = new ToaThuocBUS(this).GetByIDHistory(history.IDHistory);
                ViewBag.toaThuoc = toaThuoc;
                if (toaThuoc != null)
                {
                    ViewBag.ChiTietToaThuoc = new CTToaThuocBUS(this).GetByIDToaThuoc(toaThuoc.IDToaThuoc);
                }
            }
            return View(history);
        }
    }
}