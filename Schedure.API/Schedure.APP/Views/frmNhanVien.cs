using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchedureBUS;
using SchedureDTO;

namespace Schedure.APP.Views
{
    public partial class frmNhanVien : FormBase
    {
        private bool _isEdit;
        private Account_NhanVienDTO _nhanvien;

        public bool IsEdit
        {
            get => _isEdit; set
            {
                _isEdit = value;
                btnCreate.Text = _isEdit ? "Sửa" : "Thêm mới";
                txtUsername.ReadOnly = IsEdit;
                cmbNVSrc.Enabled = !IsEdit;
            }
        }

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            mDataGridView2.BinDataPropertyName<Account_NhanVienDTO>(
                new ColumnFormat<Account_NhanVienDTO>(q => q.Username),
                new ColumnFormat<Account_NhanVienDTO>(q => q.Position.Name),
                new ColumnFormat<Account_NhanVienDTO>(q => q.MaNhanvien),
                new ColumnFormat<Account_NhanVienDTO>(q => q.TenNhanVien)
                );
            _reload();
        }

        private void mDataGridView2_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            _nhanvien = dataBoundItem as Account_NhanVienDTO;
            if (_nhanvien != null)
            {
                if (e.ColumnIndex == mDataGridView2.ColumnCount - 1)
                {
                    if ($"Xóa nhân viên {_nhanvien.TenNhanVien}".XacNhan() == DialogResult.OK)
                    {
                        SetStatus(new AccountBUS(this).Delete(_nhanvien.IDAccountNV));
                        _reload();
                    }
                }
                else
                {
                    IsEdit = _nhanvien != null;
                    txtUsername.Text = _nhanvien.Username;
                    txtPassword.Clear();
                    cmbPosition.SelectedItem = _nhanvien.IDPosition;
                }
            }
        }

        private void _reload()
        {
            var data = new AccountBUS(this).GetAllNV().OrderBy(q=>q.TenNhanVien).ToList();
            var src = new AccountBUS(this).GetSourceNV().OrderBy(q => q.TenNhanVien).ToList();

            //loai bo nhung nv da có
            src = src.Where(q => !data.Any(a => a.NhanVien_Id == q.NhanVien_Id)).ToList();

            //loai ra NV sa
            data = data.Where(q => q.Position.Name != "SA").ToList();

            cmbNVSrc.BindItems(src, q => q.TenNhanVien);
            cmbPosition.BindDataSource(new PositionBUS(this).GetAll(), q => q.IDPosition, q => q.Name);

            txtUsername.Clear();
            txtPassword.Clear();

            mDataGridView2.SetDataSource(data);

            IsEdit = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (IsEdit)
            {
                if (string.IsNullOrEmpty(txtPassword.Text) == false)
                {
                    if ("Đặt lại mật khẩu cho nhân viên?".XacNhan() == DialogResult.OK)
                    {
                        if (txtPassword.Text.Length < 8)
                        {
                            "Vui lòng nhập mật khẩu ít nhất 8 kí tự, để hủy vui lòng để trống mật khẩu!".ThongBao();
                            return;
                        }
                        _nhanvien.Password = txtPassword.Text;
                    }
                }
                _nhanvien.IDPosition = (int?)cmbPosition.SelectedValue;
                success = new AccountBUS(this).UpdateNV(_nhanvien);
                if (success == false)
                {
                    "Sửa thất bại".ThongBao();
                }
                _reload();
            }
            else
            {
                if (txtPassword.Text.Length < 8)
                {
                    if ("Mật khẩu không hợp lệ (ít nhất 8 kí tự), bạn muốn tự tạo mật khẩu?".XacNhan() == DialogResult.OK)
                    {
                        txtPassword.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(new Random().Next(10000000, 99999999).ToString())).Replace("==", "");
                    }
                    else
                    {
                        return;
                    }
                }
                _nhanvien = new Account_NhanVienDTO
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    IDPosition = (int?)cmbPosition.SelectedValue,
                    Status = "ACTIVE",
                    NhanVien_Id = (cmbNVSrc.SelectedItem as Account_NhanVienDTO).NhanVien_Id
                };
                success = new AccountBUS(this).CreateNV(_nhanvien);
                if (success)
                {
                    string message = $@"Tạo thành công tải khoản NV.
Mã NV: {(cmbNVSrc.SelectedItem as Account_NhanVienDTO).MaNhanvien}
Username: {_nhanvien.Username}
Password: {_nhanvien.Password}
Copy thông tin vào bộ nhớ đệm?
";

                    _reload();
                    if (message.XacNhan() == DialogResult.OK)
                    {
                        Clipboard.SetText(message);
                    }
                }
                else
                {
                    "Thất bại".ThongBao();
                }
            }
            SetStatus(success);
        }

        private void cmbNVSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsEdit == false)
            {
                txtUsername.Text = (cmbNVSrc.SelectedItem as Account_NhanVienDTO).MaNhanvien;
            }
        }
    }
}
