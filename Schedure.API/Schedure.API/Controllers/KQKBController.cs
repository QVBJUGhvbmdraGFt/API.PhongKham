using Schedure.API.Models;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Schedure.API.Controllers
{
    public class KQKBController : ApiController
    {
        [ResponseType(typeof(List<ChuyenKhoaDTO>))]
        [BasicAuthentication]
        [HttpPost]
        public List<NgayKhamDTO> Fillter([FromUri]string s_tuNgay, [FromUri]string s_denNgay)
        {
            int benhNhan_Id = LoginHelper.GetAccount().BenhNhan_Id ?? 0;
            return _Fillter(benhNhan_Id, s_tuNgay, s_denNgay);
        }

        [ResponseType(typeof(List<ChuyenKhoaDTO>))]
        [HttpPost]
        [AdminAuthentication]
        public List<NgayKhamDTO> NVFillter([FromBody]int? benhNhan_Id, [FromUri]string s_tuNgay, [FromUri]string s_denNgay)
        {
            return _Fillter(benhNhan_Id, s_tuNgay, s_denNgay);
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
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return new List<NgayKhamDTO>();
        }

        [ResponseType(typeof(ChanDoanKhamLS))]
        [HttpPost]
        [BasicAuthentication]
        public ChanDoanKhamLS GetByKhamBenhId([FromBody]int KhamBenh_Id)
        {
            var data= _GetByKhamBenhId(KhamBenh_Id);
            var acc = LoginHelper.GetAccount();
            if(acc != null && acc.BenhNhan_Id == data.BenhNhan_Id)
            {
                return data;
            }
            return null;
        }

        [ResponseType(typeof(ChanDoanKhamLS))]
        [HttpPost]
        [AdminAuthentication]
        public ChanDoanKhamLS NVGetByKhamBenhId([FromBody]int KhamBenh_Id)
        {
            return _GetByKhamBenhId(KhamBenh_Id);
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
