using Newtonsoft.Json;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class KQKBBUS : BaseBUS
    {
        public KQKBBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "KQKB";

        public List<NgayKhamDTO> Fillter(DateTime tuNgay, DateTime denNgay)
        {
            var input = API.POST<string>($"apis/{controlerAPI}/Fillter?s_tuNgay={tuNgay.ToString("dd-MM-yyyy")}&s_denNgay={denNgay.ToString("dd-MM-yyyy")}", "").Value;
            return _decode<List<NgayKhamDTO>>(input) ?? new List<NgayKhamDTO>();
        }

        T _decode<T>(string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(Convert.FromBase64String(input)));
            }
            catch (Exception ex)
            {
                ex.DebugLog();
            }
            return default(T);
        }

        public List<NgayKhamDTO> NVFillter(int? benhNhan_Id, DateTime tuNgay, DateTime denNgay)
        {
            return _decode<List<NgayKhamDTO>>(API.POST<string>($"apis/{controlerAPI}/NVFillter?s_tuNgay={tuNgay.ToString("dd-MM-yyyy")}&s_denNgay={denNgay.ToString("dd-MM-yyyy")}", benhNhan_Id).Value) ?? new List<NgayKhamDTO>();
        }

        public ChanDoanKhamLS GetByKhamBenhId(int KhamBenh_Id)
        {
            return _decode<ChanDoanKhamLS>(API.POST<string>($"apis/{controlerAPI}/GetByKhamBenhId", KhamBenh_Id).Value);
        }

        public ChanDoanKhamLS NVGetByKhamBenhId(int KhamBenh_Id)
        {
            return _decode<ChanDoanKhamLS>(API.POST<string>($"apis/{controlerAPI}/NVGetByKhamBenhId", KhamBenh_Id).Value);
        }
    }
}
