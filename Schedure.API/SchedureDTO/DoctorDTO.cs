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
        public string Avatar { get; set; }
        public string Sumary { get; set; }
        public string TrainingProcess { get; set; }
        public string Study { get; set; }
        public string Status { get; set; }
        public Nullable<bool> Male { get; set; }
        public Nullable<int> IDChucDanh { get; set; }
        public Nullable<int> IDPhongKham { get; set; }

        public HashSet<LichLamViecDTO> LichLamViecs { get; set; }
        public PhongKhamDTO PhongKham { get; set; }
        public ChucDanhDTO ChucDanh { get; set; }
    }
}
