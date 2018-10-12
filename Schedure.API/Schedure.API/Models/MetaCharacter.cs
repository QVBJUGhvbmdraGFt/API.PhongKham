using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Schedure.API.Models
{
    public static class MetaCharacter
    {
        static HashSet<string> CHARACTER = new HashSet<string>() {
            "union", "select", "order", "information_schema", "insert", "drop", "load_file"
        };

        public static string RemoveMetaCharacter(this string input)
        {
            var output = Regex.Replace(input, "[^0-9a-zA-Z]+", "");
            foreach (var item in CHARACTER)
            {
                output.Replace(item, "");
            }
            return output;
        }
    }
}