using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class LichLamViecsBUS
    {
        public APIHelper API { get; private set; }

        public LichLamViecsBUS()
        {
            API = new APIHelper();
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

        public bool Create(IToken token, LichLamViecDTO obj)
        {
            return new APIHelper(token.GetToken()).POST<object>($"api/{controlerAPI}", obj).Key;
        }

        public bool Delete(IToken token, int id)
        {
            return new APIHelper(token.GetToken()).DELETE<object>($"api/{controlerAPI}/{id}").Key;
        }

        public List<LichLamViecDTO> GetByIDPhongBan(int iDPhongBan)
        {
            return API.POST<List<LichLamViecDTO>>($"apis/{controlerAPI}/GetByIDPhongBan?iDPhongBan={iDPhongBan}", iDPhongBan).Value ?? new List<LichLamViecDTO>();
        }
    }
}
