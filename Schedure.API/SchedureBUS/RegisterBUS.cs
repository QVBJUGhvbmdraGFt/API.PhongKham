using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class RegisterBUS : BaseBUS
    {
        public RegisterBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "Registers";

        public List<RegisterDTO> GetAll()
        {
            return API.GET<List<RegisterDTO>>($"api/{controlerAPI}").Value ?? new List<RegisterDTO>();
        }

        public RegisterDTO GetByID(int id)
        {
            var res = API.GET<RegisterDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(RegisterDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(RegisterDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDRegister}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<RegisterDTO>($"api/{controlerAPI}/{id}").Key;
        }

        public List<RegisterDTO> GetByIDSpecia(int id)
        {
            return API.POST<List<RegisterDTO>>($"apis/{controlerAPI}/GetByIDSpecia/{id}", id).Value;
        }

        public bool Cancle(int id)
        {
            return API.POST<string>($"apis/{controlerAPI}/Cancle/{id}", id).Key;
        }

        public List<RegisterDTO> GetByAccount(int iDAccount)
        {
            return API.POST<List<RegisterDTO>>($"apis/{controlerAPI}/GetByAccount/{iDAccount}", iDAccount).Value ?? new List<RegisterDTO>();
        }
    }
}
