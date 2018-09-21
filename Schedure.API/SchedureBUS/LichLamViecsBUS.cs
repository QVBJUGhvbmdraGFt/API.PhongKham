using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class LichLamViecsBUS : BaseBUS
    {
        public LichLamViecsBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "LichLamViecs";

        public List<LichLamViecDTO> GetAll()
        {
            return API.GET<List<LichLamViecDTO>>($"api/{controlerAPI}").Value ?? new List<LichLamViecDTO>();
        }

        public LichLamViecDTO GetByID(int id)
        {
            var res = API.GET<LichLamViecDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(LichLamViecDTO obj)
        {
            return API.POST<object>($"api/{controlerAPI}", obj).Key;
        }

        public bool Update(LichLamViecDTO obj)
        {
            return API.PUT<string>($"api/{controlerAPI}/{obj.IDLich}", obj).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<object>($"api/{controlerAPI}/{id}").Key;
        }
    }
}
