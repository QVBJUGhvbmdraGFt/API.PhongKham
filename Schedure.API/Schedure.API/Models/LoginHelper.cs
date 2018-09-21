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
                if (Authorization != null || Authorization.StartsWith("Basic"))
                {
                    var decodeAuthorization = Encoding.UTF8.GetString(Convert.FromBase64String(Authorization.Remove(0, "Basic ".Length)));
                    var up = decodeAuthorization.Split(':');
                    if (up.Length == 4 && up[0] == "BN")
                    {
                        int IDBN = int.Parse(up[1]);
                        string username = up[2];
                        string password = up[3];
                        var acc = new SchedureEntities().Account_BenhNhan.Find(IDBN);
                        if (acc != null && acc.Username == username && acc.Password == password && acc.Status == "ACTIVE")
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

        public static bool CheckAccount(int id)
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
                    if (up.Length == 4)
                    {
                        string key = up[0];
                        if (key == "NV")
                        {
                            int IDAccountNV = int.Parse(up[1]);
                            string username = up[2];
                            string password = up[3];
                            Account_NhanVien account =  new SchedureEntities().Account_NhanVien.Find(IDAccountNV);
                            if (account != null && account.Username == username && account.Password == password && account.Status != "DELETE")
                            {
                                return account;
                            }
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