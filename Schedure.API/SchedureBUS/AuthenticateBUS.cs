using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class AuthenticateBUS
    {
        APIHelper API = new APIHelper();
        const string controlerAPI = "Authenticate";

        #region BenhNhan
        public KeyValuePair<bool, string> Login(string Username, string Password)
        {
            return API.POST<string>($"apis/{controlerAPI}/Login?Username={Username}&Password={Password}", "");
        }
        public async Task<KeyValuePair<int, string>> Register(Account_BenhNhanDTO account)
        {
            var res = await API.POSTAsynsCode<string>($"apis/{controlerAPI}/Register", account);
            int code = 0; // FAIL
            if (res.Key == HttpStatusCode.OK)
            {
                code = 1; // CONFIRM
            }
            else if (res.Key == HttpStatusCode.Created)
            {
                code = 2; // Created => CONFIRM
            }
            else if (res.Key == HttpStatusCode.NotAcceptable)
            {
                code = 3; // ACTIVE
            }
            return new KeyValuePair<int, string>(code, res.Value);
        }

        public bool Confirm(string urlConfirm)
        {
            return API.POST<string>($"apis/{controlerAPI}/Confirm", urlConfirm).Key;
        }

        public Account_BenhNhanDTO GetAccount(string token)
        {
            var api = new APIHelper();
            api.TokenBasic = token;
            return api.POST<Account_BenhNhanDTO>($"apis/{controlerAPI}/GetAccount", "").Value;
        }

        public async Task<KeyValuePair<bool, string>> ResendMail(string email, string maYte)
        {
            return await API.POSTAsyns<string>($"apis/{controlerAPI}/ResendMail?email={email}&maYte={maYte}", "");
        }
        #endregion

        #region NhanVien
        public KeyValuePair<bool, string> LoginNV(string Username, string Password)
        {
            return API.POST<string>($"apis/{controlerAPI}/LoginNV?Username={Username}&Password={Password}", "");
        }

        #endregion

    }
}
