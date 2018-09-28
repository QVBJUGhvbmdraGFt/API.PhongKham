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
    public partial class frmChucVu : FormBase
    {
        private bool _isEdit;
        private PositionDTO _position;

        public bool IsEdit
        {
            get => _isEdit; set
            {
                _isEdit = value;
                btnEdit.Text = _isEdit ? "Sửa" : "Thêm mới";
                btnDelete.Enabled = _isEdit;
            }
        }

        public frmChucVu()
        {
            InitializeComponent();
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            mDataGridView1.BinDataPropertyName<PositionDTO>(
                new ColumnFormat<PositionDTO>(q => q.Name),
                new ColumnFormat<PositionDTO>(q => q.QL_Bac_Si),
                new ColumnFormat<PositionDTO>(q => q.QL_Chuyen_Khoa),
                new ColumnFormat<PositionDTO>(q => q.Xem_KQCLS),
                new ColumnFormat<PositionDTO>(q => q.QL_Lich_Lam_Viec),
                new ColumnFormat<PositionDTO>(q => q.QL_Phong_Ban),
                new ColumnFormat<PositionDTO>(q => q.QL_Dang_Ky),
                new ColumnFormat<PositionDTO>(q => q.QL_Thoi_Gian_Lam),
                new ColumnFormat<PositionDTO>(q => q.QL_Thong_Tin_Benh_Vien)
                );

            _reload();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (_position != null && $"Bạn có muốn xóa {_position.Name}?".XacNhan() == DialogResult.OK)
            {
                new PositionBUS(this).Delete(_position.IDPosition);
                _reload();
            }
        }

        private void _reload()
        {
            var data = new PositionBUS(this).GetAll();
            mDataGridView1.DataSource = new BindingList<PositionDTO>(data);

            IsEdit = false;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                _position.Name = txtName.Text;
                new PositionBUS(this).Update(_position);
            }
            else
            {
                _position = new PositionDTO
                {
                    Name = txtName.Text
                };
                new PositionBUS(this).Create(_position);
            }
            _reload();
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            foreach (var item in mDataGridView1.DataSource as IList<PositionDTO>)
            {
                new PositionBUS(this).Update(item);
            }
            _reload();
        }

        private void mDataGridView1_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            _position = dataBoundItem as PositionDTO;
            IsEdit = _position != null;
            if (IsEdit)
            {
                txtName.Text = _position.Name;
            }
        }
    }
}
