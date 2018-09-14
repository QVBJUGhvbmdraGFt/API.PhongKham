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
    public partial class frmThuoc : BaseForm
    {
        private bool isEdit;

        ThuocBUS BUS { get { return new ThuocBUS(this); } }

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

        public frmThuoc()
        {
            InitializeComponent();
        }

        private void frmThuoc_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var obj = new ThuocDTO();
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                    new DataGridViewTextBoxColumn(){ HeaderText ="Mã thuốc" , DataPropertyName = nameof(obj.IDThuoc) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Tên thuốc" , DataPropertyName = nameof(obj.Name) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Đơn vị" , DataPropertyName = nameof(obj.DonVi) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Giá tiền" , DataPropertyName = nameof(obj.GiaTien) },
                });

            numericUpDown1.Maximum = int.MaxValue;
            _reload();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                BUS.Create(_getObject());
                _reload();
                "Thêm thành công".ThongBao();
            }
        }

        private bool checkInput()
        {
            var res = true;
            res = res & errorProvider1.Validate(DonVi, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(TenThuoc, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(numericUpDown1, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            return res;
        }

        private ThuocDTO _getObject()
        {
            return new ThuocDTO
            {
                DonVi = DonVi.Text,
                IDThuoc = (int)IDThuoc.Value,
                Name = TenThuoc.Text,
                GiaTien = (int)numericUpDown1.Value,
                Status = "ACTIVE",
            };
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void _reload()
        {
            dataGridView1.DataSource = BUS.GetAll();
            IsEdit = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BUS.Update(_getObject());
            _reload();
            "Sửa thành công".ThongBao();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ("Bạn có muốn xóa?".XacNhan() == DialogResult.Yes)
            {
                BUS.Delete(_getObject().IDThuoc);
                _reload();
                "Xóa thành công".ThongBao();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<ThuocDTO>();
            if (BUS.GetByID((int)search_IDThuoc.Value) is ThuocDTO value)
            {
                _loadObject(value);
                dataGridView1.DataSource = new List<ThuocDTO>() { value };
            }
            else "Không tìm thấy".ThongBao();
        }

        private void _loadObject(ThuocDTO value)
        {
            IDThuoc.Value = value.IDThuoc;
            TenThuoc.Text = value.Name;
            DonVi.Text = value.DonVi;
            numericUpDown1.Value = value.GiaTien ?? 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is ThuocDTO value)
                {
                    _loadObject(value);
                    IsEdit = true;
                }
            }
        }

    }
}
