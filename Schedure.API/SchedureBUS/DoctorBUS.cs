using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class DoctorBUS : BaseBUS
    {
        public DoctorBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "Doctors";

        public List<DoctorDTO> GetAll()
        {
            return API.GET<List<DoctorDTO>>($"api/{controlerAPI}").Value ?? new List<DoctorDTO>();
        }

        public DoctorDTO GetByID(int id)
        {
            var res = API.GET<DoctorDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public List<DoctorDTO> GetBySpecia(int id)
        {
            return API.POST<List<DoctorDTO>>($"apis/{controlerAPI}/GetBySpecia/{id}", id).Value;
        }

        public bool Create(DoctorDTO account)
        {
            return API.POST<string>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(DoctorDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDDoctor}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<string>($"api/{controlerAPI}/{id}").Key;
        }

        public KeyValuePair<bool, string> ChangeAvatar(int id, byte[] imageData, string nameImage)
        {
            return API.UploadImage<string>($"apis/{controlerAPI}/ChangeAvatar/{id}", imageData, nameImage);
        }
    }
}
