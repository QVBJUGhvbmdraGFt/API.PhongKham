
namespace SchedureDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class InfoHospitalDTO
    {
        public int IDInfoHospital { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Adress { get; set; }
        public string Hotline { get; set; }
        public string Email { get; set; }
        public Nullable<System.TimeSpan> WorkStart { get; set; }
        public Nullable<System.TimeSpan> WorkEnd { get; set; }
    }
}
