using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureDTO
{
    public partial class ChanDoanKhamLS
    {
        public Nullable<int> BenhNhan_Id { get; set; }
        public string TenBenhNhan { get; set; }
        public string MaYTe { get; set; }
        public string Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<System.DateTime> ThoiGianKham { get; set; }
        public string NoiDungKham { get; set; }
        public string TrieuChungLamSang { get; set; }
        public string ChanDoanKhoaKham { get; set; }
        public string TenPhongBan { get; set; }
        public string HuyetAp { get; set; }
        public Nullable<short> Mach { get; set; }
        public Nullable<decimal> NhietDo { get; set; }
        public Nullable<short> NhipTho { get; set; }
        public Nullable<decimal> ChieuCao { get; set; }
        public Nullable<decimal> CanNang { get; set; }
        public string SoBHYT { get; set; }
        public string NguoiLienHe { get; set; }
        public string NgayHenTaiKham { get; set; }
        public string MaBenh { get; set; }
        public string MaBenhPhu { get; set; }

        public List<KetQuaCLS> KetQuaCLS { get; set; }
        public string SoVaoVien { get; set; }
    }

    public partial class KetQuaCLS
    {
        public string NoiDung { get; set; }
        public string KetQua { get; set; }
        public string CSBT { get; set; }
        public Nullable<bool> TienSu { get; set; }
        public string DonViTinh { get; set; }
        public string TenNhomDichVu { get; set; }
        public string mo_ta { get; set; }
        public string ket_luan { get; set; }
        public Nullable<System.DateTime> ngay_kq { get; set; }
    }
}
