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
    public partial class frmRegister : FormBase
    {
        private List<ChuyenKhoaDTO> _allChuyenKhoa;

        public Account_BenhNhanDTO Account_BenhNhan { get; private set; }

        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            mDataGridView1.BinDataPropertyName<LichLamViecDTO>(
                new ColumnFormat<LichLamViecDTO>(q => q.Doctor.FullName),
                new ColumnFormat<LichLamViecDTO>(q => q.TimeSlot.HourStart),
                new ColumnFormat<LichLamViecDTO>(q => q.TimeSlot.HourEnd)
                );

            dateNgayKham.MinDate = DateTime.Now.AddDays(1);
            dateNgayKham.MaxDate = DateTime.Now.AddDays(14);

            _allChuyenKhoa = new ChuyenKhoasBUS(this).NVAllChuyenKhoa();
            cmbChuyenKhoa.BindItems(_allChuyenKhoa, q => q.Name);

        }

        private void cmbChuyenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = cmbChuyenKhoa.SelectedItem as ChuyenKhoaDTO;
            cmbPhongKham.BindItems(obj.PhongBans, q => q.TenPhongBan);
        }

        private void cmbBacSi_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = cmbBacSi.SelectedItem as DoctorDTO;
            mDataGridView1.DataSource = new List<LichLamViecDTO>(obj.LichLamViecs);
        }

        private void cmbPhongKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = cmbPhongKham.SelectedItem as PhongBanDTO;
            cmbBacSi.BindItems(obj.Doctors, q => q.FullName);
        }

        private void mDataGridView1_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            if(Account_BenhNhan == null)
            {
                "Vui lòng tìm bệnh nhân".ThongBao();
                return;
            }
            var obj = dataBoundItem as LichLamViecDTO;
            if ($"Xác nhận đăng kí cho bệnh nhân {Account_BenhNhan.Username}({Account_BenhNhan.Username})?".XacNhan() == DialogResult.OK)
            {
                if(new RegisterBUS(this).NVCreate(new RegisterDTO
                {
                    Account_BenhNhan = null,
                    CreateDate = DateTime.Now,
                    IDAccountBN = Account_BenhNhan.IDAccountBN,
                    IDLich = obj.IDLich,
                    IDRegister = 0,
                    LichLamViec = null,
                    Message = "",
                    NgayKham = dateNgayKham.Value,
                    Phone = txtPhone.Text,
                    Status = "ACTIVE"
                }))
                {
                    "Thành công".ThongBao();
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    "Thất bại".ThongBao();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account_BenhNhan = new AccountBUS(this).FindBN(txtMaYTe.Text);
            if(Account_BenhNhan == null)
            {
                "Không tìm thấy tài khoản bệnh nhân! Bệnh nhân vui lòng tạo tài khoản theo Mã Y tế của mình!".ThongBao();
            }
            else
            {
                lblBenhNhan.Text = $"Tài khoản: {Account_BenhNhan.Username} - MaYTe: {Account_BenhNhan.Username}";
            }
        }
    }
}
