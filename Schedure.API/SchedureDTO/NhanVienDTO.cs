//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchedureDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanVienDTO
    {
        public int NhanVien_Id { get; set; }
        public string MaNhanVien { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string TenTat { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public string CMND { get; set; }
        public Nullable<int> NguoiTao_Id { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string DiaChi { get; set; }
        public bool TamNgung_Id { get; set; }
    }
}
