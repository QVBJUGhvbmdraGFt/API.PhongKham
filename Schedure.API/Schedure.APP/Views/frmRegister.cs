using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP.Views
{
    public partial class frmRegister : FormBase
    {
        private List<ChuyenKhoaDTO> _allChuyenKhoa;

        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            mDataGridView1.BinDataPropertyName<LichLamViecDTO>(
                new ColumnFormat<LichLamViecDTO>(q => q.Doctor.FullName),
                new ColumnFormat<LichLamViecDTO>(q => q.Date, "dd-MM-yyyy"),
                new ColumnFormat<LichLamViecDTO>(q => $"{q.TimeSlot.Name} ({q.TimeSlot.HourStart} - {q.TimeSlot.HourEnd})")
                );

            dateNgayKham.MinDate = DateTime.Now.AddDays(1);
            dateNgayKham.MaxDate = DateTime.Now.AddDays(14);

            _allChuyenKhoa = new ChuyenKhoasBUS(this).NVJoinAllChuyenKhoa();
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
            var date = _onlydate(dateNgayKham.Value);
            mDataGridView1.DataSource = new List<LichLamViecDTO>(obj.LichLamViecs.Where(q => _onlydate(q.Date) == date).ToList());
        }

        private void cmbPhongKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = cmbPhongKham.SelectedItem as PhongBanDTO;
            cmbBacSi.BindItems(obj.Doctors, q => q.FullName);
        }

        private void mDataGridView1_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            if (e.ColumnIndex == mDataGridView1.ColumnCount - 1)
            {
                var obj = dataBoundItem as LichLamViecDTO;
                if (obj != null)
                {
                    if (new Regex(@"^\d{10}$").IsMatch(txtPhone.Text))
                    {
                        if ($"Xác nhận đăng kí cho bệnh nhân?".XacNhan() == DialogResult.OK)
                        {
                            if (new RegisterBUS(this).NVCreate(new RegisterDTO
                            {
                                IDAccountBN = null,
                                CreateDate = DateTime.Now,
                                IDChuyenKhoa = (cmbChuyenKhoa.SelectedItem as ChuyenKhoaDTO).IDChuyenKhoa,
                                IDLich = obj.IDLich,
                                MaYTe = txtName.Text,
                                Message = txtMessage.Text,
                                NhanVien_Id = obj.NhanVien_Id,
                                NgayKham = dateNgayKham.Value,
                                Patient_name = txtName.Text,
                                Status_Patient = txtStatus.Text,
                                Phone = txtPhone.Text,
                            }, txtMaYTe.Text))
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
                    else
                    {
                        var message = "Vui lòng nhập SDT có 10 số";
                        SetStatus(message);
                        message.ThongBao();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bn = new AccountBUS(this).FindBN(txtMaYTe.Text);
            mDataGridView1.Enabled = bn != null;
            if (bn == null)
            {
                var message = $"Không tìm thấy Bệnh nhân mã {txtMaYTe.Text}!";
                message.ThongBao();
                SetStatus(message);
            }
            else
            {
                txtName.Text = bn.TenBenhNhan;
                SetStatus(bn.TenBenhNhan);
            }
        }

        private void dateNgayKham_ValueChanged(object sender, EventArgs e)
        {
            var obj = cmbBacSi.SelectedItem as DoctorDTO;
            if (obj != null)
            {
                var date = _onlydate(dateNgayKham.Value);
                mDataGridView1.DataSource = new List<LichLamViecDTO>(obj.LichLamViecs.Where(q => _onlydate(q.Date) == date).ToList());
            }
        }

        private DateTime? _onlydate(DateTime? date)
        {
            if (date == null) return null;
            return new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);
        }
    }
}
