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
    
    public partial class ChuyenKhoaDTO
    {
        public ChuyenKhoaDTO()
        {
            this.PhongBans = new HashSet<PhongBanDTO>();
        }

        public int IDChuyenKhoa { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public Nullable<int> TimeUse { get; set; }
        public string Status { get; set; }

        public virtual ICollection<PhongBanDTO> PhongBans { get; set; }
    }
}
