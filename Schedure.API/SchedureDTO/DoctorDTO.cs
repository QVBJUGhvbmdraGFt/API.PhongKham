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
    
    public partial class DoctorDTO
    {
        public DoctorDTO()
        {
            LichLamViecs = new HashSet<LichLamViecDTO>();
        }

        public int IDDoctor { get; set; }
        public string FullName { get; set; }

        public HashSet<LichLamViecDTO> LichLamViecs { get; set; }
        public PhongBanDTO PhongBan { get; set; }
    }
}
