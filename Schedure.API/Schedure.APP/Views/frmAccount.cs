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
    public partial class frmAccount : BaseForm
    {
        private bool isEdit;

        public bool IsEdit
        {
            get => isEdit; set
            {
                isEdit = value;
                btnAdd.Enabled = !isEdit;
                btnEdit.Enabled = btnDelete.Enabled = btnLichSuKhamBenh.Enabled = isEdit;
                ucAccount1.ClearError();
            }
        }

        public frmAccount()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            ucAccount1.Token = this;

            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var obj = new AccountDTO();
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                    new DataGridViewTextBoxColumn(){ HeaderText ="Mã tài khoản" , DataPropertyName = nameof(obj.IDAccount) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Tên đăng nhập" , DataPropertyName = nameof(obj.Username) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Họ tên" , DataPropertyName = nameof(obj.FullName) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Email" , DataPropertyName = nameof(obj.Email) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="SDT" , DataPropertyName = nameof(obj.Phone) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Email" , DataPropertyName = nameof(obj.Email) },
                });

            var source_postion = new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("YTA", "Y tá"),
                new KeyValuePair<string, string>("","Bệnh nhân"),
            };

            if (COMMON.User.POSITION != "YTA")
            {
                source_postion.Add(new KeyValuePair<string, string>("BACSI", "Bác sĩ"));

                if (COMMON.User.POSITION == "SA")
                {
                    source_postion.Add(new KeyValuePair<string, string>("SA", "Super Admin"));
                }
            }

            btnAdd.Visible = btnDelete.Visible = btnEdit.Visible = COMMON.User.POSITION != "YTA";

            search_Position.DataSource = source_postion;
            search_Position.ValueMember = "Key";
            search_Position.DisplayMember = "Value";


            _reload();
        }

        private void _reload()
        {
            var allAccount = new AccountBUS(this).GetAll().Where(q=>q.Status == "ACTIVE").ToList();
            if (COMMON.User.POSITION != "SA") allAccount = allAccount.Where(q => q.POSITION != "SA").ToList();

            dataGridView1.DataSource = allAccount;

            btnDelete.Tag = 0;
            btnEdit.Tag = "12345678";
            search_ID.Clear();

            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox txt)
                {
                    txt.Clear();
                }
            }

            IsEdit = false;
            ucAccount1.ClearError();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var obj = dataGridView1.Rows[e.RowIndex].DataBoundItem;
                if (obj is AccountDTO value)
                {
                    ucAccount1.FillAccount(new AccountBUS(this).GetByID(value.IDAccount));
                    btnDelete.Tag = value.IDAccount;
                    btnEdit.Tag = value.Password;

                    IsEdit = true;
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ucAccount1.CheckInput())
            {
                var obj = ucAccount1.GetAccount();
                new AuthenticateBUS().Register(obj);
                _reload();

                $"Đăng kí cho bệnh nhân thành công, bệnh nhân vui lòng xác nhận trong hòm thư email {obj.Email}".ThongBao();
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ucAccount1.CheckInput())
            {
                var obj = ucAccount1.GetAccount();
                new AccountBUS(this).Update(obj);
                _reload();

                "Sửa thành công".ThongBao();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ("Bạn có muốn xóa tài khoản này?".XacNhan() == DialogResult.Yes)
            {
                var obj = ucAccount1.GetAccount();
                new AccountBUS(this).Delete(obj.IDAccount);
                _reload();

                "Xóa thành công".ThongBao();
            }
        }

        private void btnLichSuKhamBenh_Click(object sender, EventArgs e)
        {
            new frmLichSuKhamBenh(int.Parse(btnDelete.Tag + "")).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = -1;
            List<AccountDTO> all = new List<AccountDTO>();
            if (string.IsNullOrWhiteSpace(search_ID.Text) == false)
            {
                if (int.TryParse(search_ID.Text + "", out id))
                {
                    var acc = new AccountBUS(this).GetByID(id);
                    if (acc != null)
                    {
                        all.Add(acc);
                        ucAccount1.FillAccount(all[0]);
                    }
                }
            }
            if (id <= 0)
            {
                all = new AccountBUS(this).GetAll().Where(q => q.POSITION == search_Position.SelectedValue + "").ToList();
            }

            dataGridView1.DataSource = all;
        }
    }
}
