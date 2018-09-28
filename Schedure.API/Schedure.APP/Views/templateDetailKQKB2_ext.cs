using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedure.APP.Views
{
    public partial class templateDetailKQKB2
    {
        public SchedureDTO.ChanDoanKhamLS Model { get; set; }

        public void Write(object obj)
        {
            base.Write(obj + "");
        }
    }
}
