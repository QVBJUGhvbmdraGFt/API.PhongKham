using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureDTO
{
    public partial class NgayKhamDTO
    {
        public string TenBenhNhan { get; set; }
        public string MaYTe { get; set; }
        public string Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<System.DateTime> ThoiGianKham { get; set; }
        public string TrieuChungLamSang { get; set; }
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
        public int KhamBenh_Id { get; set; }
    }
}
