using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class ToaThuocBUS : BaseBUS
    {
        public ToaThuocBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "ToaThuocs";

        public List<ToaThuocDTO> GetAll()
        {
            return API.GET<List<ToaThuocDTO>>($"api/{controlerAPI}").Value ?? new List<ToaThuocDTO>();
        }

        public ToaThuocDTO GetByID(int id)
        {
            var res =  API.GET<ToaThuocDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(ToaThuocDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(ToaThuocDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDToaThuoc}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<string>($"api/{controlerAPI}/{id}").Key;
        }

        public ToaThuocDTO GetByIDHistory(int iDHistory)
        {
            var res = API.POST<ToaThuocDTO>($"apis/{controlerAPI}/GetByIDHistory/{iDHistory}", iDHistory);
            return res.Key ? res.Value : null;
        }
    }
}
