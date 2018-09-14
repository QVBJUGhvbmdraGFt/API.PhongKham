using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Schedure.API.Models;
using SchedureDTO;

namespace Schedure.API.Controllers
{
    public class HistoryKhamBenhsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/HistoryKhamBenhs
        [BasicAuthentication("SA", "BACSI", "YTA")]
        [ResponseType(typeof(List<HistoryKhamBenhDTO>))]
        public List<HistoryKhamBenhDTO> GetHistoryKhamBenhs()
        {
            var lst = new List<HistoryKhamBenhDTO>();
            foreach (var item in db.HistoryKhamBenhs)
            {
                lst.Add(ConvertToHistoryKhamBenhDTO(item));
            }
            return lst;
        }

        [HttpPost]
        [ResponseType(typeof(List<HistoryKhamBenhFakeDTO>))]
        [BasicAuthentication]
        public List<HistoryKhamBenhFakeDTO> GetByAccount(int id)
        {
            var lst = new List<HistoryKhamBenhFakeDTO>();

            if (LoginHelper.CheckAccount(id) == false)
                return lst;

            var key = Models.Encoder.GetKey();
            var acc = LoginHelper.GetAccount();
            foreach (var item in db.HistoryKhamBenhs.Where(q => q.Register.IDAccount == id))
            {
                var v = ConvertToHistoryKhamBenhDTO(item);
                lst.Add(v.Encode<HistoryKhamBenhFakeDTO>(key));
            }

            MailHelper.SendMail(acc.Email, "Mã xác nhận xem lịch sử khám bệnh", $"[{DateTime.Now}] Xin chào {acc.FullName},Đây là mã xác nhận của bạn: {key}");
            return lst;
        }

        [HttpPost]
        [ResponseType(typeof(List<HistoryKhamBenhDTO>))]
        [BasicAuthentication]
        public List<HistoryKhamBenhDTO> GiaiMaHistoryKhamBenhs(string id, List<HistoryKhamBenhFakeDTO> list)
        {
            var lst = new List<HistoryKhamBenhDTO>();

            foreach (var item in list)
            {
                lst.Add(item.Decode<HistoryKhamBenhDTO>(id));
            }
            return lst;
        }

        [HttpPost]
        [BasicAuthentication]
        [ResponseType(typeof(HistoryKhamBenhDTO))]
        public async Task<IHttpActionResult> GetByIDRegister(int id)
        {
            if (await db.HistoryKhamBenhs.FirstOrDefaultAsync(q => q.IDRegister == id) is HistoryKhamBenh value)
            {
                if (LoginHelper.CheckAccount(value.Register.IDAccount ?? 0) == false)
                    return NotFound();

                return Ok(ConvertToHistoryKhamBenhDTO(value));
            }
            return NotFound();
        }

        private HistoryKhamBenhDTO ConvertToHistoryKhamBenhDTO(HistoryKhamBenh item)
        {
            return new HistoryKhamBenhDTO
            {
                CanNang = item.CanNang,
                ChieuCao = item.ChieuCao,
                ChuanDoanSoBo = item.ChuanDoanSoBo,
                CreateTime = item.CreateTime,
                HuyetApTD = item.HuyetApTD,
                HuyetApTT = item.HuyetApTT,
                ICD = item.ICD,
                IDDoctor = item.IDDoctor,
                IDHistory = item.IDHistory,
                IDRegister = item.IDRegister,
                Mach = item.Mach,
                NhietDo = item.NhieuDo,
                NhipTho = item.NhipTho,
                TrieuChungLS = item.TrieuChungLS,
                Doctor_FullName = item.Doctor.FullName,
                Register_CreateTime = item.Register.CreateDate,
                CachGiaiQuyet = item.CachGiaiQuyet,
                Specia_Name = item.Register.Doctor.Specia.Name
            };
        }

        // GET: api/HistoryKhamBenhs/5
        [BasicAuthentication]
        [ResponseType(typeof(HistoryKhamBenhDTO))]
        public async Task<IHttpActionResult> GetHistoryKhamBenh(int id)
        {
            HistoryKhamBenh historyKhamBenh = await db.HistoryKhamBenhs.FindAsync(id);

            if (historyKhamBenh == null)
            {
                return NotFound();
            }

            if (LoginHelper.CheckAccount(historyKhamBenh.Register.IDAccount ?? 0) == false)
                return NotFound();

            return Ok(ConvertToHistoryKhamBenhDTO(historyKhamBenh));
        }

        // PUT: api/HistoryKhamBenhs/5
        [BasicAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PutHistoryKhamBenh(int id, HistoryKhamBenh historyKhamBenh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historyKhamBenh.IDHistory)
            {
                return BadRequest();
            }

            db.Entry(historyKhamBenh).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryKhamBenhExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HistoryKhamBenhs
        [BasicAuthentication("SA", "BACSI")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostHistoryKhamBenh(HistoryKhamBenh historyKhamBenh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistoryKhamBenhs.Add(historyKhamBenh);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HistoryKhamBenhExists(historyKhamBenh.IDHistory))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = historyKhamBenh.IDHistory }, historyKhamBenh);
        }

        // DELETE: api/HistoryKhamBenhs/5
        [BasicAuthentication("SA", "BACSI")]
        [ResponseType(typeof(HistoryKhamBenhDTO))]
        public async Task<IHttpActionResult> DeleteHistoryKhamBenh(int id)
        {
            HistoryKhamBenh historyKhamBenh = await db.HistoryKhamBenhs.FindAsync(id);
            if (historyKhamBenh == null)
            {
                return NotFound();
            }

            db.HistoryKhamBenhs.Remove(historyKhamBenh);
            await db.SaveChangesAsync();

            return Ok(ConvertToHistoryKhamBenhDTO(historyKhamBenh));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoryKhamBenhExists(int id)
        {
            return db.HistoryKhamBenhs.Count(e => e.IDHistory == id) > 0;
        }
    }
}