
namespace SchedureDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpeciaDTO
    {
        public int IDSpecia { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public Nullable<int> TimeUse { get; set; }
        public string Status { get; set; }
    }
}
