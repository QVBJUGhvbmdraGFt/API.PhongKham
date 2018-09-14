using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;

namespace Schedure.API.Models
{
    public class LoginHelper
    {
        public static Account GetAccount()
        {
            var Authorization = HttpContext.Current.Request.Headers["Authorization"];
            if (Authorization != null || Authorization.StartsWith("Basic"))
            {
                var decodeAuthorization = Encoding.UTF8.GetString(Convert.FromBase64String(Authorization.Remove(0, "Basic ".Length)));
                var up = decodeAuthorization.Split(':');
                if (up.Length == 2)
                {
                    string username = up[0];
                    string password = up[1];
                    return new SchedureEntities().Accounts.FirstOrDefault(q => q.Username == username && q.Password == password && q.Status != "DELETE");
                }
            }
            return null;
        }

        public static bool CheckAccount(int id)
        {
            var acc = LoginHelper.GetAccount();
            if (acc != null && string.IsNullOrWhiteSpace(acc.POSITION))
                return acc != null && acc.IDAccount == id;
            return acc != null;
        }
    }
}