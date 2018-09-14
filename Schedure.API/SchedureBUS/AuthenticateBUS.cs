using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class AuthenticateBUS
    {
        APIHelper API = new APIHelper();
        const string controlerAPI = "Authenticate";

        public KeyValuePair<bool,string> Login(string Username,string Password)
        {
            return API.POST<string>($"apis/{controlerAPI}/Login?Username={Username}&Password={Password}", "");
        }

        public KeyValuePair<bool,string> Register(AccountDTO account)
        {
            return API.POST<string>($"apis/{controlerAPI}/Register", account);
        }

        public bool Confirm(string urlConfirm)
        {
            return API.POST<string>($"apis/{controlerAPI}/Confirm", urlConfirm).Key;
        }

        public AccountDTO GetAccount(string token)
        {
            return API.POST<AccountDTO>($"apis/{controlerAPI}/GetAccount?token={token}", "").Value;
        }

    }
}
