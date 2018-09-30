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
    public partial class frmKQCLS : FormBase
    {
        public frmKQCLS()
        {
            InitializeComponent();
        }

        private void frmKQCLS_Load(object sender, EventArgs e)
        {
            mDataGridView1.BinDataPropertyName<NgayKhamDTO>(
                new ColumnFormat<NgayKhamDTO>(q => q.ThoiGianKham),
                new ColumnFormat<NgayKhamDTO>(q => q.TenPhongBan),
                new ColumnFormat<NgayKhamDTO>(q => q.MaYTe),
                new ColumnFormat<NgayKhamDTO>(q => q.TenBenhNhan),
                new ColumnFormat<NgayKhamDTO>(q => q.TrieuChungLamSang),
                new ColumnFormat<NgayKhamDTO>(q => q.NgayHenTaiKham)
                );

            _reload();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void _reload()
        {
            //cmbChuyenKhoa.BindItems(new ChuyenKhoasBUS(this).NVJoinAllChuyenKhoa(), q => q.Name);

            dateend.Value = DateTime.Now;
            datestart.Value = dateend.Value.AddDays(-10);

            numSearch.Value = 0;

            _fillter();
        }

        private void cmbChuyenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var data = cmbChuyenKhoa.SelectedItem;
            //if (data is ChuyenKhoaDTO obj)
            //{
            //    cmbPhongKham.BindItems(obj.PhongBans, q => q.TenPhongBan);
            //}
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            _fillter();
        }

        private void _fillter()
        {
            int? benhnhan_id = numSearch.Value > 0 ? (int?)numSearch.Value : null;
            var data = new KQKBBUS(this).NVFillter(benhnhan_id, datestart.Value, dateend.Value);
            mDataGridView1.DataSource = data;
            SetStatus();
        }

        private void mDataGridView1_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            if (e.ColumnIndex == mDataGridView1.ColumnCount - 1 && dataBoundItem is NgayKhamDTO obj)
            {
                new frmDetailKQKB2(obj.KhamBenh_Id).ShowDialog();
            }
        }
    }
}
