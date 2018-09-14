using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class ThuocBUS : BaseBUS
    {
        public ThuocBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "Thuocs";

        public List<ThuocDTO> GetAll()
        {
            return API.GET<List<ThuocDTO>>($"api/{controlerAPI}").Value ?? new List<ThuocDTO>();
        }

        public ThuocDTO GetByID(int id)
        {
            var res =  API.GET<ThuocDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(ThuocDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(ThuocDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDThuoc}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<string>($"api/{controlerAPI}/{id}").Key;
        }

    }
}
