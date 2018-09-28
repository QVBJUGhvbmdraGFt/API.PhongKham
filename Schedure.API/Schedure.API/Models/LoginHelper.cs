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
        public static Account_BenhNhan GetAccount()
        {
            try
            {
                var Authorization = HttpContext.Current.Request.Headers["Authorization"];
                if (Authorization != null && Authorization.StartsWith("Basic"))
                {
                    var decodeAuthorization = Encoding.UTF8.GetString(Convert.FromBase64String(Authorization.Remove(0, "Basic ".Length)));
                    var up = decodeAuthorization.Split(':');
                    if (up.Length == 2)
                    {
                        int IDBN = int.Parse(up[0]);
                        string stoken = up[1];
                        var acc = new SchedureEntities().Account_BenhNhan.Find(IDBN);
                        if (acc != null && acc.Token == stoken && acc.TokenExpiration >= DateTime.Now && acc.Status == "ACTIVE")
                        {
                            return acc;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return null;
        }

        public static bool CheckAccount(int? id)
        {
            var acc = LoginHelper.GetAccount();
            return acc != null && acc.IDAccountBN == id;
        }

        public static Account_NhanVien GetAccountNV()
        {
            try
            {
                var Authorization = HttpContext.Current.Request.Headers["Authorization"];
                if (Authorization != null && Authorization.StartsWith("Basic"))
                {
                    var decodeAuthorization = Encoding.UTF8.GetString(Convert.FromBase64String(Authorization.Remove(0, "Basic ".Length)));
                    var up = decodeAuthorization.Split(':');
                    if (up.Length == 2)
                    {
                        int IDAccountNV = int.Parse(up[0]);
                        string stoken = up[1];
                        Account_NhanVien account = new SchedureEntities().Account_NhanVien.Find(IDAccountNV);
                        if (account != null && account.Token == stoken && account.TokenExpiration >= DateTime.Now && account.Status == "ACTIVE")
                        {
                            return account;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return null;
        }
    }
}