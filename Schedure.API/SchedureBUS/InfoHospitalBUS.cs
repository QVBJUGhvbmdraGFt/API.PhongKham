using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class InfoHospitalBUS : BaseBUS
    {
        public InfoHospitalBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "InfoHospitals";

        public List<InfoHospitalDTO> GetAll()
        {
            return API.GET<List<InfoHospitalDTO>>($"api/{controlerAPI}").Value ?? new List<InfoHospitalDTO>();
        }

        public InfoHospitalDTO GetByID(int id)
        {
            var res =  API.GET<InfoHospitalDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(InfoHospitalDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(InfoHospitalDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDInfoHospital}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<InfoHospitalDTO>($"api/{controlerAPI}/{id}").Key;
        }

    }
}
