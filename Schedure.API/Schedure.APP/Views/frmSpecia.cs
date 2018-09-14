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
    public partial class frmSpecia : BaseForm
    {
        public frmSpecia()
        {
            InitializeComponent();
        }

        private void frmSpecia_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var obj = new SpeciaDTO();
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                    new DataGridViewTextBoxColumn(){ HeaderText ="Tên phòng khám" , DataPropertyName = nameof(obj.Name) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Thời gian khám" , DataPropertyName = nameof(obj.TimeUse) },
                });

            _reload();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void _reload()
        {
            dataGridView1.DataSource = new SpeciaBUS(this).GetAll();

            txtName.Clear();
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                new SpeciaBUS(this).Create(new SpeciaDTO
                {
                    TimeUse = (int)TimeUse.Value,
                    Name = txtName.Text,
                    Avatar = "",
                    IDSpecia = 0,
                    Status = "ACTIVE"
                });
                _reload();

                "Thêm thành công".ThongBao();
            }
        }

        private bool checkInput()
        {
            var res = true;
            res = res & errorProvider1.Validate(TimeUse, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(txtName, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            return res;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {

                new SpeciaBUS(this).Update(new SpeciaDTO
                {
                    TimeUse = (int)TimeUse.Value,
                    Name = txtName.Text,
                    Avatar = "",
                    IDSpecia = int.Parse(btnAdd.Tag + ""),
                    Status = "ACTIVE"
                });
                _reload();

                "Sửa thành công".ThongBao();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is SpeciaDTO value)
                {
                    btnAdd.Tag = value.IDSpecia + "";

                    txtName.Text = value.Name;
                    TimeUse.Value = value.TimeUse ?? 0;

                    btnAdd.Enabled = false;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ("Bạn có muốn xóa phòng khám này?".XacNhan() == DialogResult.Yes)
            {
                new SpeciaBUS(this).Delete(int.Parse(btnAdd.Tag + ""));

                _reload();
                "Xóa thành công".ThongBao();
            }
        }
    }
}
