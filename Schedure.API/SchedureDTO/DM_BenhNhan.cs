using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureDTO
{
    public partial class DM_BenhNhan
    {
        public int BenhNhan_Id { get; set; }
        public string MaYTe { get; set; }
        public string MaBenhVien { get; set; }
        public string SoVaoVien { get; set; }
        public string TenBenhNhan { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public Nullable<short> NamSinh { get; set; }
        public string DiaChi { get; set; }
        public bool VietKieu { get; set; }
        public string CMND { get; set; }
        public string TenKhongDau { get; set; }
        public string GhiChu { get; set; }
        public string TienSuBenh { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public string SoThe_BHYT { get; set; }
        public Nullable<System.DateTime> NgayHieuLuc_BHYT { get; set; }
        public Nullable<System.DateTime> NgayHetHieuLuc_BHYT { get; set; }
    }
}
