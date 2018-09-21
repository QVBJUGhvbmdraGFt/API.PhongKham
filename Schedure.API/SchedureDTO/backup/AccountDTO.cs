
namespace SchedureDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account_BenhNhanDTO
    {
        public int IDAccountBN { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public Nullable<bool> Male { get; set; }
        public DateTime? Birthday { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TieuSu { get; set; }
        public string POSITION { get; set; }
        public string Status { get; set; }
    }
}
