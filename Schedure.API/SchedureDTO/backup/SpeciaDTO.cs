
namespace SchedureDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChuyenKhoaDTO
    {
        public int IDChuyenKhoa { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public Nullable<int> TimeUse { get; set; }
        public string Status { get; set; }
    }
}
