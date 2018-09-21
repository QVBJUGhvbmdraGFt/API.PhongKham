
namespace SchedureDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegisterDTO
    {
        public int IDRegister { get; set; }
        public Nullable<int> IDAccount { get; set; }
        public Nullable<int> IDDoctor { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Doctor_FullName { get; set; }
        public string Account_FullName { get; set; }
        public string Specia_Name { get; set; }
    }
}
