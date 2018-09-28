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
    public partial class frmChuyenKhoa : FormBase
    {
        bool _isedit;

        public bool Isedit
        {
            get => _isedit;
            set
            {
                _isedit = value;
                btnSave.Text = _isedit ? "Sửa" : "Thêm";
            }
        }

        public frmChuyenKhoa()
        {
            InitializeComponent();
        }

        private void frmChuyenKhoa_Load(object sender, EventArgs e)
        {
            mDataGridView1.BinDataPropertyName<ChuyenKhoaDTO>(
                new ColumnFormat<ChuyenKhoaDTO>(q => q.Name)
                );
            _reload();
        }

        private void _reload()
        {
            mDataGridView1.DataSource = new ChuyenKhoasBUS(this).NVAllChuyenKhoa();
            Isedit = false;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Isedit)
            {
                new ChuyenKhoasBUS(this).Update(new ChuyenKhoaDTO
                {
                    Name = txtName.Text,
                    IDChuyenKhoa = (int)txtName.Tag
                });
            }
            else
            {
                new ChuyenKhoasBUS(this).Create(new ChuyenKhoaDTO
                {
                    Name = txtName.Text
                });
            }
            _reload();
        }

        private void mDataGridView1_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            var obj = dataBoundItem as ChuyenKhoaDTO;
            if (e.ColumnIndex == mDataGridView1.ColumnCount - 1)
            {
                Isedit = false;
                if ($"Xác nhận xóa chuyên khoa {obj.Name}?".XacNhan() == DialogResult.OK)
                {
                    new ChuyenKhoasBUS(this).Delete(obj.IDChuyenKhoa);
                    _reload();
                }
            }
            else
            {
                txtName.Text = obj.Name;
                txtName.Tag = obj.IDChuyenKhoa;
                Isedit = true;
            }
        }
    }
}
