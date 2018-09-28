using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class PositionBUS : BaseBUS
    {
        public PositionBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "Positions";

        public List<PositionDTO> GetAll()
        {
            return API.GET<List<PositionDTO>>($"api/{controlerAPI}").Value ?? new List<PositionDTO>();
        }

        public PositionDTO GetByID(int id)
        {
            var res =  API.GET<PositionDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(PositionDTO account)
        {
            return API.POST<bool>($"api/{controlerAPI}", account).Value;
        }

        public bool Update(PositionDTO account)
        {
            return API.PUT<bool>($"api/{controlerAPI}/{account.IDPosition}", account).Value;
        }

        public bool Delete(int id)
        {
            return API.DELETE<bool>($"api/{controlerAPI}/{id}").Value;
        }

    }
}
