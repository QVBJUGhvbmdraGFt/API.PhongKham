using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Schedure.API.Models
{
    public static class Extentions
    {
        public static void DebugLog(this object message)
        {
            Debug.WriteLine("|==========Schedure.API===========");
            Debug.WriteLine(message);
            Debug.WriteLine("==========Schedure.API===========|");
        }
    }
}