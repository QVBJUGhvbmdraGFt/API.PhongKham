//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schedure.API.Models
{
    using System;
    
    public partial class SP_ChuyenKhoa_GetAll_Result
    {
        public int IDChuyenKhoa { get; set; }
        public int PhongBan_Id { get; set; }
        public string TenPhongBan { get; set; }
        public int NhanVien_Id { get; set; }
        public string TenNhanVien { get; set; }
        public int IDLich { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> HourStart { get; set; }
        public Nullable<System.TimeSpan> HourEnd { get; set; }
        public string ChuyenKhoa_Name { get; set; }
        public string ChuyenKhoa_Status { get; set; }
        public string LichLamViec_Status { get; set; }
        public string TimeSplot_Name { get; set; }
        public string TimeSlot_Status { get; set; }
        public Nullable<int> TimeUse { get; set; }
        public string Avatar { get; set; }
    }
}
