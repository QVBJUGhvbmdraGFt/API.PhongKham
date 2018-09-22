using SchedureBUS;
using SchedureDTO;
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
    public partial class frmKQKB : FormBase
    {
        private RegisterDTO register;

        public frmKQKB(RegisterDTO register)
        {
            InitializeComponent();
            this.register = register;
        }

        private void frmKQKB_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if ("Xác nhận hủy khám?".XacNhan() == DialogResult.OK)
            {
                if (new RegisterBUS(this).Confirm(register.IDRegister, "CANCLE"))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    "Hủy thất bại".ThongBao();
                }
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            "Đang phát triển".ThongBao();
        }
    }
}
