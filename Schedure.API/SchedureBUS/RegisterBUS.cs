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

        public static bool Create(RegisterDTO account)
        {
            return new APIHelper().POST<bool>($"apis/{controlerAPI}/PostRegister", account).Value;
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

        public List<RegisterDTO> GetByAccount(DateTime start, DateTime end)
        {
            return API.POST<List<RegisterDTO>>($"apis/{controlerAPI}/GetByAccount?start={start.ToString("dd-MM-yyyy")}&end={end.ToString("dd-MM-yyyy")}","").Value ?? new List<RegisterDTO>();
        }

        public bool Confirm(int iDRegister, string status)
        {
            var res = API.POST<bool>($"apis/{controlerAPI}/Confirm/{iDRegister}?status={status}", status);
            return res.Key && res.Value;
        }

        public List<RegisterDTO> Fillter(DateTime start, DateTime end, int? IDPhongBan, string Status)
        {
            return API.POST<List<RegisterDTO>>($"apis/{controlerAPI}/Fillter?start={start.ToString("dd-MM-yyyy")}&end={end.ToString("dd-MM-yyyy")}&IDPhongBan={IDPhongBan}&Status={Status}", "").Value ?? new List<RegisterDTO>();
        }

        public RegisterDTO NVGetByID(int id)
        {
            var res = API.POST<RegisterDTO>($"apis/{controlerAPI}/NVGetByID/{id}", "");
            return res.Key ? res.Value : null;
        }

        public bool NVCreate(RegisterDTO registerDTO)
        {
            return API.POST<bool>($"apis/{controlerAPI}/NVCreate", registerDTO).Value;
        }
    }
}
