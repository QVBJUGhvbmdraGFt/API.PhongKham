using Newtonsoft.Json;
using Schedure.API.Models;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace Schedure.API.Controllers
{
    public class KQKBController : ApiController
    {
        [ResponseType(typeof(string))]
        [BasicAuthentication]
        [HttpPost]
        public IHttpActionResult Fillter([FromUri]string s_tuNgay, [FromUri]string s_denNgay)
        {
            int benhNhan_Id = LoginHelper.GetAccount().BenhNhan_Id ?? 0;
            var data = _Fillter(benhNhan_Id, s_tuNgay, s_denNgay);
            return Ok(_encode(data));
        }

        [ResponseType(typeof(string))]
        [HttpPost]
        [AdminAuthentication]
        public IHttpActionResult NVFillter([FromBody]int? benhNhan_Id, [FromUri]string s_tuNgay, [FromUri]string s_denNgay)
        {
            return Ok(_encode(_Fillter(benhNhan_Id, s_tuNgay, s_denNgay)));
        }

        private List<NgayKhamDTO> _Fillter(int? benhNhan_Id, string s_tuNgay, string s_denNgay)
        {
            try
            {
                if (benhNhan_Id > 0 || benhNhan_Id == null)
                {
                    DateTime tuNgay = DateTime.ParseExact(s_tuNgay, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime denNgay = DateTime.ParseExact(s_denNgay, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    var data = db.sp_LayNgayKhamTuNgayDenNgay(benhNhan_Id, tuNgay, denNgay);
                    return data.Select(q => new NgayKhamDTO()
                    {
                        CanNang = q.CanNang,
                        ChieuCao = q.ChieuCao,
                        DiaChi = q.DiaChi,
                        GioiTinh = q.GioiTinh,
                        HuyetAp = q.HuyetAp,
                        MaYTe = q.MaYTe,
                        Mach = q.Mach,
                        NgayHenTaiKham = q.NgayHenTaiKham,
                        NguoiLienHe = q.NguoiLienHe,
                        NhietDo = q.NhietDo,
                        NhipTho = q.NhipTho,
                        SoBHYT = q.SoBHYT,
                        SoDienThoai = q.SoDienThoai,
                        TenBenhNhan = q.TenBenhNhan,
                        TenPhongBan = q.TenPhongBan,
                        ThoiGianKham = q.ThoiGianKham,
                        TrieuChungLamSang = q.TrieuChungLamSang,
                        KhamBenh_Id = q.KhamBenh_Id,
                        Tuoi = q.Tuoi,
                    }).OrderByDescending(q => q.ThoiGianKham).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return new List<NgayKhamDTO>();
        }

        [ResponseType(typeof(string))]
        [HttpPost]
        [BasicAuthentication]
        public IHttpActionResult GetByKhamBenhId([FromBody]int KhamBenh_Id)
        {
            var data = _GetByKhamBenhId(KhamBenh_Id);
            var acc = LoginHelper.GetAccount();
            if (acc != null && acc.BenhNhan_Id == data.BenhNhan_Id)
            {
                return Ok(_encode(_GetByKhamBenhId(KhamBenh_Id)));

            }
            return NotFound();
        }

        [ResponseType(typeof(string))]
        [HttpPost]
        [AdminAuthentication]
        public IHttpActionResult NVGetByKhamBenhId([FromBody]int KhamBenh_Id)
        {
            return Ok(_encode(_GetByKhamBenhId(KhamBenh_Id)));
        }

        string _encode(object data)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
        }

        private ChanDoanKhamLS _GetByKhamBenhId(int khamBenh_Id)
        {
            try
            {
                var data = db.sp_LayChanDoanKhamLS(khamBenh_Id);
                foreach (var q in data)
                {
                    var lst_cls = db.SP_LayKetQuaCLS(khamBenh_Id);
                    return new ChanDoanKhamLS
                    {
                        BenhNhan_Id = q.BenhNhan_Id,
                        SoVaoVien = q.SoVaoVien,
                        Tuoi = q.Tuoi,
                        CanNang = q.CanNang,
                        ChanDoanKhoaKham = q.ChanDoanKhoaKham,
                        ChieuCao = q.ChieuCao,
                        DiaChi = q.DiaChi,
                        GioiTinh = q.GioiTinh,
                        HuyetAp = q.HuyetAp,
                        MaBenh = q.MaBenh,
                        MaBenhPhu = q.MaBenhPhu,
                        Mach = q.Mach,
                        MaYTe = q.MaYTe,
                        NgayHenTaiKham = q.NgayHenTaiKham,
                        NguoiLienHe = q.NguoiLienHe,
                        NhietDo = q.NhietDo,
                        NhipTho = q.NhipTho,
                        NoiDungKham = q.NoiDungKham,
                        SoBHYT = q.SoBHYT,
                        SoDienThoai = q.SoDienThoai,
                        TenBenhNhan = q.TenBenhNhan,
                        TenPhongBan = q.TenPhongBan,
                        ThoiGianKham = q.ThoiGianKham,
                        TrieuChungLamSang = q.TrieuChungLamSang,
                        KetQuaCLS = lst_cls.Select(cls => new KetQuaCLS
                        {
                            CSBT = cls?.CSBT,
                            DonViTinh = cls?.DonViTinh,
                            KetQua = cls?.KetQua,
                            ket_luan = cls?.ket_luan,
                            mo_ta = cls?.mo_ta,
                            ngay_kq = cls?.ngay_kq,
                            NoiDung = cls?.NoiDung,
                            TenNhomDichVu = cls?.TenNhomDichVu,
                            TienSu = cls?.TienSu,
                        }).ToList(),
                    };
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return null;
        }

        #region MyRegion
        private SchedureEntities db = new SchedureEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}
