using SchedureBUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP.Views
{
    public partial class frmChangePassword : BaseForm
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void oke_Click(object sender, EventArgs e)
        {
            var acc = new AuthenticateBUS().GetAccount(COMMON.TokenBasic);
            if (acc.Password == oldPass.Text)
            {
                if (repass.Text == newpass.Text && newpass.Text.Length >= 8)
                {
                    acc.Password = repass.Text;
                    new AccountBUS(this).Update(acc);
                    "Đổi mật khẩu thành công".ThongBao();
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    "Nhập mật khẩu ít nhất 08 kí tự và trùng khớp với nhau.".ThongBao();
                }
            }
            else
            {
                "Nhập mật khẩu cũ không chính xác.".ThongBao();
            }
        }

        private void cancle_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
