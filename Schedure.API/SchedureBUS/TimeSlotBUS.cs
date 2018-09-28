using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class TimeSlotBUS : BaseBUS
    {
        public TimeSlotBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "TimeSlots";

        public List<TimeSlotDTO> GetAll()
        {
            return API.GET<List<TimeSlotDTO>>($"api/{controlerAPI}").Value ?? new List<TimeSlotDTO>();
        }

        public TimeSlotDTO GetByID(int id)
        {
            var res =  API.GET<TimeSlotDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(TimeSlotDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(TimeSlotDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDTimeSlot}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<TimeSlotDTO>($"api/{controlerAPI}/{id}").Key;
        }

    }
}
