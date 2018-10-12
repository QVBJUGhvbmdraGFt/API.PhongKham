using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Schedure.API.Models
{
    public static class Extentions
    {
        public static void DebugLog(this object message, string description = null)
        {
            Debug.WriteLine($">>>>>>>>>>>>>>>>>>{MethodBase.GetCurrentMethod().DeclaringType.Namespace}>>>>>>>>>>>>>>>>>>");
            Debug.WriteLine($"\t\t[{DateTime.Now}] {description}\t\t");
            Debug.WriteLine(message);
            Debug.WriteLine($"<<<<<<<<<<<<<<<<<{MethodBase.GetCurrentMethod().DeclaringType.Namespace}<<<<<<<<<<<<<<<<<");
        }

        public static DateTime? OnlyDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
    }
}