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
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm, IToken
    {
        private PositionManager _positionManager;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            mDataGridView1.BinDataPropertyName<RegisterDTO>(
                new ColumnFormat<RegisterDTO>(q => q.IDRegister),
                new ColumnFormat<RegisterDTO>(q => q.LichLamViec.PhongKham.ChuyenKhoa.Name),
                new ColumnFormat<RegisterDTO>(q => q.LichLamViec.PhongKham.TenPhongBan),
                new ColumnFormat<RegisterDTO>(q => q.Account_BenhNhan.Username),
                new ColumnFormat<RegisterDTO>(q => q.LichLamViec.Doctor.FullName),
                new ColumnFormat<RegisterDTO>(q => q.NgayKham),
                new ColumnFormat<RegisterDTO>(q => q.LichLamViec.TimeSlot.HourStart + " - " + q.LichLamViec.TimeSlot.HourEnd),
                new ColumnFormat<RegisterDTO>(q => q.CreateDate),
                new ColumnFormat<RegisterDTO>(q => q.Status),
                new ColumnFormat<RegisterDTO>(q => q.Status)
                );

            _positionManager = new PositionManager();

            _positionManager.AddButton(btnDangKiKham, q => q.QL_Dang_Ky == true || q.Name == "SA");
            _positionManager.AddButton(btnLichLamViec, q => q.QL_Lich_Lam_Viec == true || q.Name == "SA");
            _positionManager.AddButton(btnCDLS, q => q.Xem_KQCLS == true || q.Name == "SA");
            _positionManager.AddButton(btnChuyenKhoa, q => q.QL_Chuyen_Khoa == true || q.Name == "SA");
            _positionManager.AddButton(btnPhongKham, q => q.QL_Phong_Ban == true || q.Name == "SA");
            _positionManager.AddButton(btnBacSi, q => q.QL_Bac_Si == true || q.Name == "SA");
            _positionManager.AddButton(btTGKhamBenh, q => q.QL_Thoi_Gian_Lam == true || q.Name == "SA");

            _positionManager.AddButton(btnChucVu, q => q.Name == "SA");
            _positionManager.AddButton(btnNhanVien, q => q.Name == "SA");

            _positionManager.AddControl(btnMain_Loc, q => q.QL_Dang_Ky == true || q.Name == "SA");
            _positionManager.AddControl(btnMain_Tim, q => q.QL_Dang_Ky == true || q.Name == "SA");
            _positionManager.AddControl(btnMain_reload, q => (q.QL_Dang_Ky == true || q.Name == "SA"));

            if (_login())
            {
                _reload();
            }
        }

        private void _setEnableButtonForPosition()
        {
            _positionManager.SetEnable();
        }

        private bool _login()
        {
            this.Hide();
            if (new frmLogin().ShowDialog() == DialogResult.OK)
            {
                Show();
                COMMON.User = new AccountBUS(this).GetAccountNV();
                _positionManager.Position = COMMON.User.Position;
                _setEnableButtonForPosition();
                return true;
            }
            else
            {
                Close();
            }
            return false;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            _login();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void _reload()
        {
            datestart.Value = DateTime.Now;
            dateend.Value = DateTime.Now.AddDays(14);
            var lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>(null, "Tất cả"));
            lst.Add(new KeyValuePair<string, string>("ACTIVE", "Chờ khám"));
            lst.Add(new KeyValuePair<string, string>("CONFIRM", "Chờ xác nhận"));
            lst.Add(new KeyValuePair<string, string>("DONE", "Đã khám"));
            lst.Add(new KeyValuePair<string, string>("CANCLE", "Đã hủy"));
            cmbTrangThai.BindDataSource(lst, q => q.Key, q => q.Value);
            cmbTrangThai.SelectedIndex = 2;

            var pk = new PhongKhamsBUS(this).GetAll();
            pk.Insert(0, new PhongBanDTO
            {
                IDPhongBan = 0,
                TenPhongBan = "Tất cả"
            });
            cmbPhongKham.BindDataSource(pk, q => q.IDPhongBan, q => q.TenPhongBan);
            cmbPhongKham.SelectedIndex = 0;

            _fillter();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            _fillter();
        }

        private void _fillter()
        {
            mDataGridView1.DataSource = new RegisterBUS(this).Fillter(datestart.Value, dateend.Value, (int?)cmbPhongKham.SelectedValue, (string)cmbTrangThai.SelectedValue);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            _search();
        }

        private void _search()
        {
            var res = new RegisterBUS(this).NVGetByID((int)numSearch.Value);
            mDataGridView1.DataSource = new List<RegisterDTO>() { res };
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            _dialog(new frmRegister());
        }

        private void _dialog(Form frm)
        {
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _reload();
            }
        }

        public string GetToken()
        {
            return COMMON.TokenBasic + "";
        }

        private void mDataGridView1_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            var obj = dataBoundItem as RegisterDTO;
            if (obj != null)
            {
                if (e.ColumnIndex == mDataGridView1.ColumnCount - 1)
                {
                    switch (obj.Status)
                    {
                        case "CONFIRM":
                        case "ACTIVE":
                            if (new frmConfirm(obj).ShowDialog() == DialogResult.OK)
                            {
                                _reload();
                            }
                            break;
                        case "CANCLE":
                            "Đăng kí đã hủy khám!".ThongBao();
                            break;
                        case "DONE":
                            break;
                        default:
                            $"Trạng thái không xác định: {obj.Status}".ThongBao();
                            break;
                    }
                }
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            _dialog(new frmChuyenKhoa());
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            _dialog(new frmPhongBan());
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            _dialog(new frmBacSi());
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            _dialog(new frmTimeSlot());
        }

        private void buttonItem9_Click_1(object sender, EventArgs e)
        {
            _dialog(new frmLichLamViec());
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            _dialog(new frmKQCLS());
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            _dialog(new frmChucVu());

        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            _dialog(new frmNhanVien());
        }
    }
}
