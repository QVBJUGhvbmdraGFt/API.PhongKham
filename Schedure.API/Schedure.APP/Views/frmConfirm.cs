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
    public partial class frmConfirm : FormBase
    {
        private RegisterDTO register;

        public frmConfirm(RegisterDTO register)
        {
            InitializeComponent();
            this.register = register;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmConfirm_Load(object sender, EventArgs e)
        {
            lblFullName.FormatTextFromTag(register.Account_BenhNhan.FullName);
            lblsdt.FormatTextFromTag(register.Phone);
            lblMayte.FormatTextFromTag(register.Account_BenhNhan.Username);
            lblmesage.FormatTextFromTag(register.Message);

            lblchuyenkhoa.FormatTextFromTag(register.LichLamViec.Doctor.PhongKham.ChuyenKhoa.Name);
            lblphongkham.FormatTextFromTag(register.LichLamViec.Doctor.PhongKham.Name);
            lblbacsi.FormatTextFromTag(register.LichLamViec.Doctor.FullName);
            lbllichlamviec.FormatTextFromTag(register.LichLamViec.TimeSlot.HourStart + " - " + register.LichLamViec.TimeSlot.HourEnd);
            lblngaykham.FormatTextFromTag(register.NgayKham?.ToString("dd/MM/yyyy"));
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if ("Xác nhận bệnh nhân tới khám thành công?".XacNhan() == DialogResult.OK)
            {
                new RegisterBUS(this).Confirm(register.IDRegister, "ACTIVE");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if ("Xác nhận bệnh nhân hủy khám?".XacNhan() == DialogResult.OK)
            {
                new RegisterBUS(this).Confirm(register.IDRegister, "CANCLE");
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
