using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class CTToaThuocBUS : BaseBUS
    {
        public CTToaThuocBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "CTToaThuocs";

        public List<CTToaThuocDTO> GetAll()
        {
            return API.GET<List<CTToaThuocDTO>>($"api/{controlerAPI}").Value ?? new List<CTToaThuocDTO>();
        }

        public CTToaThuocDTO GetByID(int id)
        {
            var res = API.GET<CTToaThuocDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(CTToaThuocDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(CTToaThuocDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDCT}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<string>($"api/{controlerAPI}/{id}").Key;
        }

        public List<CTToaThuocDTO> GetByIDToaThuoc(int iDToaThuoc)
        {
            var res = API.POST<List<CTToaThuocDTO>>($"apis/{controlerAPI}/GetByIDToaThuoc/{iDToaThuoc}", iDToaThuoc);
            return res.Key ? res.Value as List<CTToaThuocDTO> : new List<CTToaThuocDTO>();
        }
    }
}
