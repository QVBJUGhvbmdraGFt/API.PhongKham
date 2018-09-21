using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SchedureBUS
{
    public static class Extentions
    {
        public static void DebugLog(this object message)
        {
            Debug.WriteLine("|==========SchedureBUS===========");
            Debug.WriteLine(message);
            Debug.WriteLine("==========SchedureBUS===========|");
        }
    }
}