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
    using System.Collections.Generic;
    
    public partial class Register
    {
        public int IDRegister { get; set; }
        public Nullable<int> IDAccountBN { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public int IDLich { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> NgayKham { get; set; }
        public string Status_Patient { get; set; }
        public string Patient_name { get; set; }
        public Nullable<int> NhanVien_Id { get; set; }
        public Nullable<int> IDChuyenKhoa { get; set; }
    
        public virtual Account_BenhNhan Account_BenhNhan { get; set; }
        public virtual LichLamViec LichLamViec { get; set; }
    }
}
