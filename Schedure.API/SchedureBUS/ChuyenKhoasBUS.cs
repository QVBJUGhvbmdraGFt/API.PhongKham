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

        public List<ChuyenKhoaDTO> NVJoinAllChuyenKhoa()
        {
            return API.POST<List<ChuyenKhoaDTO>>($"apis/{controlerAPI}/NVJoinAllChuyenKhoa","").Value ?? new List<ChuyenKhoaDTO>();
        }

        public List<ChuyenKhoaDTO> NVAllChuyenKhoa()
        {
            return API.POST<List<ChuyenKhoaDTO>>($"apis/{controlerAPI}/NVAllChuyenKhoa", "").Value ?? new List<ChuyenKhoaDTO>();
        }

        public static List<ChuyenKhoaDTO> JoinAllChuyenKhoa()
        {
            return new APIHelper().POST<List<ChuyenKhoaDTO>>($"apis/{controlerAPI}/JoinAllChuyenKhoa","").Value ?? new List<ChuyenKhoaDTO>();
        }

        public List<ChuyenKhoaDTO> NVChuyenKhoaJoinBacSi()
        {
            return new APIHelper().POST<List<ChuyenKhoaDTO>>($"apis/{controlerAPI}/NVChuyenKhoaJoinBacSi","").Value ?? new List<ChuyenKhoaDTO>();
        }

        public ChuyenKhoaDTO GetByID(int id)
        {
            var res = API.GET<ChuyenKhoaDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(ChuyenKhoaDTO obj)
        {
            return API.POST<object>($"apis/{controlerAPI}/PostChuyenKhoa", obj).Key;
        }

        public bool Update(ChuyenKhoaDTO obj)
        {
            return API.PUT<string>($"api/{controlerAPI}/{obj.IDChuyenKhoa}", obj).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<object>($"api/{controlerAPI}/{id}").Key;
        }
    }
}
