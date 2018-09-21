
namespace SchedureDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoctorDTO
    {
        public int IDDoctor { get; set; }
        public Nullable<int> IDSpecia { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Sumary { get; set; }
        public string TrainingProcess { get; set; }
        public string Study { get; set; }
        public string Status { get; set; }
    }
}
