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

        const string controlerAPI = "PhongBans";

        public List<PhongBanDTO> GetAll()
        {
            return API.GET<List<PhongBanDTO>>($"api/{controlerAPI}").Value ?? new List<PhongBanDTO>();
        }

        public List<PhongBanDTO> GetSource()
        {
            return API.POST<List<PhongBanDTO>>($"apis/{controlerAPI}/GetSource", "").Value ?? new List<PhongBanDTO>();
        }

        public PhongBanDTO GetByID(int id)
        {
            var res = API.GET<PhongBanDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(PhongBanDTO obj)
        {
            return API.POST<object>($"apis/{controlerAPI}/PostPhongBan", obj).Key;
        }

        public bool Update(PhongBanDTO obj)
        {
            return API.PUT<string>($"api/{controlerAPI}/{obj.IDPhongBan}", obj).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<object>($"api/{controlerAPI}/{id}").Key;
        }

        public List<DoctorDTO> GetDoctorByPhongKham(int iDPhongBan)
        {
            return API.POST<List<DoctorDTO>>($"apis/{controlerAPI}/GetDoctorByPhongKham/{iDPhongBan}", "").Value ?? new List<DoctorDTO>();
        }

        public List<DoctorDTO> GetAllDoctor()
        {
            return API.POST<List<DoctorDTO>>($"apis/{controlerAPI}/GetAllDoctor", "").Value ?? new List<DoctorDTO>();
        }
    }
}
