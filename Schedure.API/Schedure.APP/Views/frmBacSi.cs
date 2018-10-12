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
    public partial class frmBacSi : FormBase
    {
        public frmBacSi()
        {
            InitializeComponent();
        }

        private void frmBacSi_Load(object sender, EventArgs e)
        {
            mDataGridView1.BinDataPropertyName<DoctorDTO>(
                null,
                new ColumnFormat<DoctorDTO>(q => q.PhongBan.ChuyenKhoa.Name),
                new ColumnFormat<DoctorDTO>(q => q.PhongBan.TenPhongBan),
                new ColumnFormat<DoctorDTO>(q => q.FullName)
                );

            cmbChuyenKhoa.BindItems(new ChuyenKhoasBUS(this).NVAllChuyenKhoa().OrderBy(q => q.Name).ToList(), q => q.Name);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            _fillter();
        }

        private void _fillter()
        {
            var obj = cmbPhongBan.SelectedItem as PhongBanDTO;
            if (obj != null)
            {
                mDataGridView1.DataSource = new PhongKhamsBUS(this).GetDoctorByPhongKham(obj.IDPhongBan);
            }
        }

        private void cmbChuyenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = cmbChuyenKhoa.SelectedItem as ChuyenKhoaDTO;
            if (obj != null)
            {
                cmbPhongBan.BindItems(obj.PhongBans.OrderBy(q => q.TenPhongBan).ToList(), q => q.TenPhongBan);
            }
        }

        private void mDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
        }
    }
}
