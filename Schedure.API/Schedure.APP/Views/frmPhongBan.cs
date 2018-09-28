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
    public partial class frmPhongBan : FormBase
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            mDataGridView1.BinDataPropertyName<PhongBanDTO>(
                new ColumnFormat<PhongBanDTO>(q => q.ChuyenKhoa.Name),
                new ColumnFormat<PhongBanDTO>(q => q.TenPhongBan),
                new ColumnFormat<PhongBanDTO>(q => q.Status)
                );

            cmbChuyenKhoa.BindItems(new ChuyenKhoasBUS(this).NVAllChuyenKhoa(), q => q.Name);

            _reload();
        }

        private void _reload()
        {
            var src = new PhongKhamsBUS(this).GetSource();
            var have = new PhongKhamsBUS(this).GetAll();
            src = src.Where(q => !have.Any(a => a.PhongBan_Id == q.PhongBan_Id)).ToList();
            cmbPhongBan.BindItems(src, q => q.TenPhongBan);

            mDataGridView1.DataSource = new PhongKhamsBUS(this).GetAll();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (new PhongKhamsBUS(this).Create(new PhongBanDTO
            {
                IDChuyenKhoa = (cmbChuyenKhoa.SelectedItem as ChuyenKhoaDTO).IDChuyenKhoa,
                PhongBan_Id = (cmbPhongBan.SelectedItem as PhongBanDTO).PhongBan_Id,
                IDPhongBan = (cmbPhongBan.SelectedItem as PhongBanDTO).PhongBan_Id ?? 0,
                Status = "ACTIVE"
            }))
            {
                _reload();
            }
        }

        private void mDataGridView1_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            if (e.ColumnIndex == mDataGridView1.ColumnCount - 1)
            {
                var obj = dataBoundItem as PhongBanDTO;
                if ($"Bạn muốn xóa phòng ban {obj.TenPhongBan}?".XacNhan() == DialogResult.OK)
                {
                    new PhongKhamsBUS(this).Delete(obj.IDPhongBan);
                    _reload();
                }
            }
        }
    }
}
