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
    
    public partial class TimeSlotDTO
    {
        public int IDTimeSlot { get; set; }
        public string Name { get; set; }
        public Nullable<System.TimeSpan> HourStart { get; set; }
        public Nullable<System.TimeSpan> HourEnd { get; set; }
    }
}
