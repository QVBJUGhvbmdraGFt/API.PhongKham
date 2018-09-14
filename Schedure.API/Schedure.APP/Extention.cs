using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP
{
    public static class Extention
    {
        public static DialogResult ThongBao(this string message)
        {
            return MessageBox.Show(message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult XacNhan(this string message)
        {
            return MessageBox.Show(message, "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static bool Validate(this ErrorProvider errorProvider, Control control, Func<string, bool> funcCheck, string messageError = "Vui lòng điền giá trị")
        {
            if (funcCheck(control.Text) == false)
            {
                errorProvider.SetError(control, messageError);
                return false;
            }
            return true;
        }
    }
}
