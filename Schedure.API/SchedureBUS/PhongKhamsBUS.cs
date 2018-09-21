using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class PhongKhamsBUS : BaseBUS
    {
        public PhongKhamsBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "PhongKhams";

        public List<PhongKhamDTO> GetAll()
        {
            return API.GET<List<PhongKhamDTO>>($"api/{controlerAPI}").Value ?? new List<PhongKhamDTO>();
        }

        public PhongKhamDTO GetByID(int id)
        {
            var res = API.GET<PhongKhamDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(PhongKhamDTO obj)
        {
            return API.POST<object>($"api/{controlerAPI}", obj).Key;
        }

        public bool Update(PhongKhamDTO obj)
        {
            return API.PUT<string>($"api/{controlerAPI}/{obj.IDPhongKham}", obj).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<object>($"api/{controlerAPI}/{id}").Key;
        }
    }
}
