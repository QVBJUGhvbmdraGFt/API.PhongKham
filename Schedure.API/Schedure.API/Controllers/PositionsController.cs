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
    [AdminAuthentication]
    public class PositionsController : ApiController
    {
        private SchedureEntities db = new SchedureEntities();

        // GET: api/Positions
        [ResponseType(typeof(PositionDTO))]
        public IEnumerable<PositionDTO> GetPositions()
        {
            return db.Positions.Where(q => q.Status != "DELETE").ToList().Select(q => ConvertToPositionDTO(q));
        }

        public static PositionDTO ConvertToPositionDTO(Position q)
        {
            if (q == null) return null;
            return new PositionDTO
            {
                IDPosition = q.IDPosition,
                Name = q.Name,
                QL_Bac_Si = q.QL_Bac_Si,
                QL_Chuyen_Khoa = q.QL_Chuyen_Khoa,
                QL_Dang_Ky = q.QL_Dang_Ky,
                QL_Lich_Lam_Viec = q.QL_Lich_Lam_Viec,
                QL_Phong_Ban = q.QL_Phong_Ban,
                QL_Thoi_Gian_Lam = q.QL_Thoi_Gian_Lam,
                QL_Thong_Tin_Benh_Vien = q.QL_Thong_Tin_Benh_Vien,
                Status = q.Status,
                Xem_KQCLS = q.Xem_KQCLS,
            };
        }

        // GET: api/Positions/5
        [ResponseType(typeof(PositionDTO))]
        public async Task<IHttpActionResult> GetPosition(int id)
        {
            Position position = await db.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            return Ok(ConvertToPositionDTO(position));
        }

        // PUT: api/Positions/5
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> PutPosition(int id, Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != position.IDPosition)
            {
                return BadRequest();
            }

            db.Entry(position).State = EntityState.Modified;

            try
            {
                return Ok(await db.SaveChangesAsync() > 0);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Positions
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> PostPosition(Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            position.Status = "ACTIVE";
            db.Positions.Add(position);
            return Ok(await db.SaveChangesAsync() > 0);
        }

        // DELETE: api/Positions/5
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeletePosition(int id)
        {
            Position position = await db.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            position.Status = "DELETE";

            return Ok(await db.SaveChangesAsync() > 0);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PositionExists(int id)
        {
            return db.Positions.Count(e => e.IDPosition == id) > 0;
        }
    }
}