using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class SpeciaBUS : BaseBUS
    {
        public SpeciaBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "Specias";

        public List<SpeciaDTO> GetAll()
        {
            return API.GET<List<SpeciaDTO>>($"api/{controlerAPI}").Value ?? new List<SpeciaDTO>();
        }

        public SpeciaDTO GetByID(int id)
        {
            var res = API.GET<SpeciaDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(SpeciaDTO obj)
        {
            return API.POST<object>($"api/{controlerAPI}", obj).Key;
        }

        public bool Update(SpeciaDTO obj)
        {
            return API.PUT<string>($"api/{controlerAPI}/{obj.IDSpecia}", obj).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<object>($"api/{controlerAPI}/{id}").Key;
        }
    }
}
