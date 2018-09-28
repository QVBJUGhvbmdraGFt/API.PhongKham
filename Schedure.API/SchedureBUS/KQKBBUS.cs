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
            return API.POST<List<NgayKhamDTO>>($"apis/{controlerAPI}/Fillter?s_tuNgay={tuNgay.ToString("dd-MM-yyyy")}&s_denNgay={denNgay.ToString("dd-MM-yyyy")}", "").Value ?? new List<NgayKhamDTO>();
        }

        public List<NgayKhamDTO> NVFillter(int? benhNhan_Id, DateTime tuNgay, DateTime denNgay)
        {
            return API.POST<List<NgayKhamDTO>>($"apis/{controlerAPI}/NVFillter?s_tuNgay={tuNgay.ToString("dd-MM-yyyy")}&s_denNgay={denNgay.ToString("dd-MM-yyyy")}", benhNhan_Id).Value ?? new List<NgayKhamDTO>();
        }

        public ChanDoanKhamLS GetByKhamBenhId(int KhamBenh_Id)
        {
            return API.POST<ChanDoanKhamLS>($"apis/{controlerAPI}/GetByKhamBenhId", KhamBenh_Id).Value;
        }

        public ChanDoanKhamLS NVGetByKhamBenhId(int KhamBenh_Id)
        {
            return API.POST<ChanDoanKhamLS>($"apis/{controlerAPI}/NVGetByKhamBenhId", KhamBenh_Id).Value;
        }
    }
}
