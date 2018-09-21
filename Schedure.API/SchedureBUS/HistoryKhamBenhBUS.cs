using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class HistoryKhamBenhBUS : BaseBUS
    {
        public HistoryKhamBenhBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "HistoryKhamBenhs";

        public List<HistoryKhamBenhDTO> GetAll()
        {
            return API.GET<List<HistoryKhamBenhDTO>>($"api/{controlerAPI}").Value ?? new List<HistoryKhamBenhDTO>();
        }

        public HistoryKhamBenhDTO GetByID(int id)
        {
            var res = API.GET<HistoryKhamBenhDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(HistoryKhamBenhDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(HistoryKhamBenhDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDHistory}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<string>($"api/{controlerAPI}/{id}").Key;
        }

        public List<HistoryKhamBenhDTO> GetByAccount(int iDAccount)
        {
            return API.POST<List<HistoryKhamBenhDTO>>($"apis/{controlerAPI}/GetByAccount/{iDAccount}", iDAccount).Value ?? new List<HistoryKhamBenhDTO>();
        }

        public List<HistoryKhamBenhDTO> GiaiMaHistoryKhamBenhs(List<HistoryKhamBenhDTO> list, string key)
        {
            var res = API.POST<List<HistoryKhamBenhDTO>>($"apis/{controlerAPI}/GiaiMaHistoryKhamBenhs/{key}", list);
            return res.Key ? res.Value : new List<HistoryKhamBenhDTO>();
        }

        public HistoryKhamBenhDTO GetByIDRegister(int iDRegister)
        {
            var res = API.POST<HistoryKhamBenhDTO>($"apis/{controlerAPI}/GetByIDRegister/{iDRegister}", iDRegister);
            return res.Key ? res.Value : null;
        }
    }
}
