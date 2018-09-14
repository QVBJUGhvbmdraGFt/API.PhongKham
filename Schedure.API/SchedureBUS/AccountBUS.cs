using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class AccountBUS : BaseBUS
    {
        public AccountBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "Accounts";

        public List<AccountDTO> GetAll()
        {
            return API.GET<List<AccountDTO>>($"api/{controlerAPI}").Value ?? new List<AccountDTO>();
        }

        public AccountDTO GetByID(int id)
        {
            var res = API.GET<AccountDTO>($"api/{controlerAPI}/{id}");
            return res.Key? res.Value: null;
        }

        public bool Create(AccountDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(AccountDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDAccount}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<AccountDTO>($"api/{controlerAPI}/{id}").Key;
        }

        public KeyValuePair<bool, string> ChangeAvatar(int iDAccount, byte[] imageData, string nameImage)
        {
            return API.UploadImage<string>($"apis/{controlerAPI}/ChangeAvatar/{iDAccount}", imageData, nameImage);
        }
    }
}
