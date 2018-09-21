using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class ChuyenKhoasBUS : BaseBUS
    {
        public ChuyenKhoasBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "ChuyenKhoas";

        public List<ChuyenKhoaDTO> GetAll()
        {
            return API.GET<List<ChuyenKhoaDTO>>($"api/{controlerAPI}").Value ?? new List<ChuyenKhoaDTO>();
        }

        public ChuyenKhoaDTO GetByID(int id)
        {
            var res = API.GET<ChuyenKhoaDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(ChuyenKhoaDTO obj)
        {
            return API.POST<object>($"api/{controlerAPI}", obj).Key;
        }

        public bool Update(ChuyenKhoaDTO obj)
        {
            return API.PUT<string>($"api/{controlerAPI}/{obj.IDChuyenKhoa}", obj).Key;
        }

        public List<ChuyenKhoaDTO> NVGetAll()
        {
            return API.GET<List<ChuyenKhoaDTO>>($"apis/{controlerAPI}/NVGetAll").Value ?? new List<ChuyenKhoaDTO>();
        }

        public bool Delete(int id)
        {
            return API.DELETE<object>($"api/{controlerAPI}/{id}").Key;
        }
    }
}
