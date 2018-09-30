using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class AccountBUS : BaseBUS
    {
        public AccountBUS(IToken token) : base(token)
        {
        }

        const string controlerAPI = "Accounts";

        public List<Account_BenhNhanDTO> GetAllBN()
        {
            return API.GET<List<Account_BenhNhanDTO>>($"api/{controlerAPI}").Value ?? new List<Account_BenhNhanDTO>();
        }

        public Account_BenhNhanDTO GetByID(int id)
        {
            var res = API.GET<Account_BenhNhanDTO>($"api/{controlerAPI}/{id}");
            return res.Key ? res.Value : null;
        }

        public bool Create(Account_BenhNhanDTO account)
        {
            return API.POST<object>($"api/{controlerAPI}", account).Key;
        }

        public bool Update(Account_BenhNhanDTO account)
        {
            return API.PUT<string>($"api/{controlerAPI}/{account.IDAccountBN}", account).Key;
        }

        public bool Delete(int id)
        {
            return API.DELETE<Account_BenhNhanDTO>($"api/{controlerAPI}/{id}").Key;
        }

        public KeyValuePair<bool, string> ChangeAvatar(int iDAccount, byte[] imageData, string nameImage)
        {
            return API.UploadImage<string>($"apis/{controlerAPI}/ChangeAvatar/{iDAccount}", imageData, nameImage);
        }

        public DM_BenhNhan FindBN(string MaYTe)
        {
            return API.GET<DM_BenhNhan>($"apis/{controlerAPI}/FindBN?MaYTe={MaYTe}").Value;
        }

        public Account_NhanVienDTO GetAccountNV()
        {
            return API.POST<Account_NhanVienDTO>($"apis/{controlerAPI}/GetAccountNV", "").Value;
        }

        public List<Account_NhanVienDTO> GetAllNV()
        {
            return API.POST<List<Account_NhanVienDTO>>($"apis/{controlerAPI}/GetAllNV", "").Value;
        }

        public List<Account_NhanVienDTO> GetSourceNV()
        {
            return API.POST<List<Account_NhanVienDTO>>($"apis/{controlerAPI}/GetSourceNV", "").Value;
        }

        public bool BNChangePassword(string OldPass, string NewPass, string RePass, ref string error)
        {
            bool validate = true;
            if (NewPass.Length < 8)
            {
                error = "Mật khẩu có ít nhất 8 kí tự. ";
                validate = false;
            }
            if (NewPass != RePass)
            {
                error += "Vui lòng xác nhận mật khẩu trùng khớp. ";
                validate = false;
            }
            if (validate)
            {
                return API.POST<bool>($"apis/{controlerAPI}/BNChangePassword?oldpass={OldPass}&newpass={NewPass}", "").Value;
            }

            return false;
        }

        public bool NVChangePassword(string OldPass, string NewPass, string RePass, ref string error)
        {
            bool validate = true;
            if (NewPass.Length < 8)
            {
                error = "Mật khẩu có ít nhất 8 kí tự. ";
                validate = false;
            }
            if (NewPass != RePass)
            {
                error += "Vui lòng xác nhận mật khẩu trùng khớp. ";
                validate = false;
            }
            if (validate)
            {
                return API.POST<bool>($"apis/{controlerAPI}/NVChangePassword?oldpass={OldPass}&newpass={NewPass}", "").Value;
            }

            return false;
        }

        public bool UpdateNV(Account_NhanVienDTO nhanvien)
        {
            return API.POST<bool>($"apis/{controlerAPI}/UpdateNV", nhanvien).Value;
        }

        public bool CreateNV(Account_NhanVienDTO nhanvien)
        {
            return API.POST<bool>($"apis/{controlerAPI}/CreateNV", nhanvien).Value;
        }
    }
}
