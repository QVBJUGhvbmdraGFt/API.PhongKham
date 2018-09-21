using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Schedure.Web.Models
{
    public class LoginHelper
    {
        public static Account_BenhNhanDTO GetAccountBN()
        {
            return HttpContext.Current.Session["LOGIN"] as Account_BenhNhanDTO;
        }
    }
}