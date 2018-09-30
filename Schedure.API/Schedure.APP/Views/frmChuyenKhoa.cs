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
            SetStatus("Vui lòng chờ...");
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                SetStatus(false,"Vui lòng nhập tên chuyên khoa");
            }
            else if ((mDataGridView1.DataSource as IList<ChuyenKhoaDTO>).Any(q => q.Name.ToLower() == txtName.Text.Trim().ToLower()))
            {
                SetStatus(false, "Tên chuyên khoa đã được sử dụng");
            }
            else
            {
                bool success = false;
                if (Isedit)
                {
                    success = new ChuyenKhoasBUS(this).Update(new ChuyenKhoaDTO
                    {
                        Name = txtName.Text.Trim(),
                        IDChuyenKhoa = (int)txtName.Tag
                    });
                }
                else
                {
                    success = new ChuyenKhoasBUS(this).Create(new ChuyenKhoaDTO
                    {
                        Name = txtName.Text.Trim()
                    });
                }
                SetStatus(success);
                _reload();
            }
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
                    SetStatus(true);
                }
                SetStatus(false);
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
