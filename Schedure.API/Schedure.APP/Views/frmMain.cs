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
        private bool _readyUse;

        private bool isEdit;

        public bool IsEdit
        {
            get => isEdit;
            set
            {
                isEdit = value;

                btnAdd.Enabled = !IsEdit;
                btnEdit.Enabled = IsEdit;
                btnDelete.Enabled = IsEdit;
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (_login())
            {
                grv.Columns.Clear();
                grv.AutoGenerateColumns = false;
                grv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                var obj = new RegisterDTO();
                grv.Columns.AddRange(new DataGridViewColumn[] {
                    new DataGridViewTextBoxColumn(){ HeaderText ="Mã đăng kí" , DataPropertyName = nameof(obj.IDRegister) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Thời gian đăng kí" , DataPropertyName = nameof(obj.CreateDate) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Bệnh nhân" , DataPropertyName = nameof(obj.Account_FullName) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Bác sĩ" , DataPropertyName = nameof(obj.Doctor_FullName) },
                    new DataGridViewButtonColumn(){ HeaderText ="Lịch sử khám bệnh" , UseColumnTextForButtonValue = true,Text="Xem" },
                    new DataGridViewButtonColumn(){ HeaderText ="Kết quả" , UseColumnTextForButtonValue = true,Text="Xem" },
                });

                var allDoctor = new DoctorBUS(this).GetAll();
                cmbDoctor.DisplayMember = "FullName";
                cmbDoctor.ValueMember = "IDDoctor";
                cmbDoctor.DataSource = allDoctor;

                var allAccount = new AccountBUS(this).GetAll().Where(q => string.IsNullOrWhiteSpace(q.POSITION)).ToList();
                cmbAccount.DisplayMember = "FullName";
                cmbAccount.ValueMember = "IDAccount";
                cmbAccount.DataSource = allAccount;

                IsEdit = false;
            }
        }

        private bool _login()
        {
            lblSystem_User.Text = "Vui lòng đăng nhập";
            if (new frmLogin().ShowDialog() != DialogResult.OK) Close();
            else
            {
                lblSystem_User.Text = $"{COMMON.User.FullName} | {COMMON.User.POSITION}";
                _reload();
                return true;
            }
            return false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if ("Bạn có muốn đăng xuất".XacNhan() == DialogResult.Yes)
            {
                COMMON.User = null;
                _login();
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (new frmAccount().ShowDialog() == DialogResult.OK)
            {
                _reload();
            }
        }

        private void _reload()
        {
            _readyUse = false;

            var allSpecia = new SpeciaBUS(this).GetAll().Where(q => q.Status == "ACTIVE").ToList();
            allSpecia.Insert(0, new SpeciaDTO { IDSpecia = 0, Name = "Tất cả phòng khám" });

            search_cmbSpecia.DataSource = allSpecia;
            search_cmbSpecia.DisplayMember = "Name";
            search_cmbSpecia.ValueMember = "IDSpecia";

            _loadDoctor(0);

            _loadRegister();

            IsEdit = false;
            _readyUse = true;
        }

        private void _loadRegister()
        {
            var allRegister = new RegisterBUS(this).GetAll().Where(q => q.Status == "ACTIVE").ToList();
            grv.DataSource = new BindingList<RegisterDTO>(allRegister);
        }

        void _loadDoctor(int idSpecia)
        {
            var allDoctor = new DoctorBUS(this).GetAll();
            if (idSpecia > 0)
            {
                allDoctor = allDoctor.Where(q => q.IDSpecia == idSpecia).ToList();
            }
            allDoctor.Insert(0, new SchedureDTO.DoctorDTO { IDDoctor = 0, FullName = "Tất cả bác sĩ" });

            search_cmbDoctor.DataSource = allDoctor;
            search_cmbDoctor.DisplayMember = "FullName";
            search_cmbDoctor.ValueMember = "IDDoctor";

        }

        public string GetToken()
        {
            return COMMON.TokenBasic;
        }

        private void cmbSpecia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_readyUse) _loadDoctor((int)search_cmbSpecia.SelectedValue);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            new frmChangePassword().ShowDialog();
        }

        private void btnPhongKham_Click(object sender, EventArgs e)
        {
            new frmSpecia().ShowDialog();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            new frmDoctor().ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var source = new List<RegisterDTO>();

            int id = -1;
            if (string.IsNullOrWhiteSpace(txtIDRegister.Text) == false)
            {
                if (int.TryParse(txtIDRegister.Text, out id))
                {
                    var res = new RegisterBUS(this).GetByID(id);
                    if (res != null) source.Add(res);
                }
            }

            if (id <= 0)
            {
                source = new RegisterBUS(this).GetAll();


                if (((int)search_cmbSpecia.SelectedValue) > 0)
                {
                    source = new RegisterBUS(this).GetByIDSpecia((int)search_cmbSpecia.SelectedValue);
                }

                if (((int)search_cmbDoctor.SelectedValue) > 0)
                {
                    source = source.Where(q => q.IDDoctor == (int)search_cmbDoctor.SelectedValue).ToList();
                }
            }

            grv.DataSource = source;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string message = "";
            if (cmbAccount.SelectedValue == null)
            {
                message += "+ Vui lòng chọn bệnh nhân cần đăng kí!";
            }
            if (cmbDoctor.SelectedValue == null)
            {
                message += "+ Vui lòng chọn bác sĩ khám bệnh!";
            }
            if (message == "")
            {
                new RegisterBUS(this).Create(_getRegister());
                _reload();
                "Đăng kí thành công".ThongBao();
            }
            else
            {
                message.ThongBao();
            }
        }

        private RegisterDTO _getRegister()
        {
            return new RegisterDTO
            {
                Account_FullName = "",
                CreateDate = DateTime.Now,
                Doctor_FullName = "",
                IDAccount = (int?)cmbAccount.SelectedValue,
                IDDoctor = (int?)cmbDoctor.SelectedValue,
                IDRegister = (int)numID.Value,
                Message = Message.Text,
                Status = "ACTIVE"
            };
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new RegisterBUS(this).Update(_getRegister());
            _reload();
            "Sửa thành công".ThongBao();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ("Bạn có muốn xóa đơn đăng kí này".XacNhan() == DialogResult.Yes)
            {
                new RegisterBUS(this).Delete((int)numID.Value);
                _reload();
                "Xóa thành công".ThongBao();
            }
        }

        private void grv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (grv.Rows[e.RowIndex].DataBoundItem is RegisterDTO value)
                {
                    cmbAccount.SelectedValue = value.IDAccount;
                    cmbDoctor.SelectedValue = value.IDDoctor;
                    Message.Text = value.Message;
                    createDate.Value = value.CreateDate ?? DateTime.Now;
                    numID.Value = value.IDRegister;
                    IsEdit = true;

                    if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
                    {
                        var frm = new frmLichSuKhamBenh(value.IDAccount.Value);
                        if (e.ColumnIndex == 5)
                        {
                            frm.LoadRegister(value.IDRegister);
                        }
                        frm.ShowDialog();
                        _reload();
                    }
                }
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            new frmThuoc().ShowDialog();
        }
    }
}
