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

        public List<Account_BenhNhanDTO> GetAll()
        {
            return API.GET<List<Account_BenhNhanDTO>>($"api/{controlerAPI}").Value ?? new List<Account_BenhNhanDTO>();
        }

        public Account_BenhNhanDTO GetByID(int id)
        {
            var res = API.GET<Account_BenhNhanDTO>($"api/{controlerAPI}/{id}");
            return res.Key? res.Value: null;
        }

        public bool Create(Account_BenhNhanDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(Account_BenhNhanDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDAccountBN}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<Account_BenhNhanDTO>($"api/{controlerAPI}/{id}").Key;
        }

        public KeyValuePair<bool, string> ChangeAvatar(int iDAccount, byte[] imageData, string nameImage)
        {
            return API.UploadImage<string>($"apis/{controlerAPI}/ChangeAvatar/{iDAccount}", imageData, nameImage);
        }

        public Account_BenhNhanDTO FindBN(string MaYTe)
        {
            return API.GET<Account_BenhNhanDTO>($"apis/{controlerAPI}/FindBN?MaYTe={MaYTe}").Value;
        }
    }
}
