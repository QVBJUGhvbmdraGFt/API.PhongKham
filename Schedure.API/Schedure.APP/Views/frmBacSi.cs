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
                new ColumnFormat<DoctorDTO>(q => q.PhongBan.ChuyenKhoa.Name),
                new ColumnFormat<DoctorDTO>(q => q.PhongBan.TenPhongBan),
                new ColumnFormat<DoctorDTO>(q => q.FullName)
                );

            cmbPhongBan.BindItems(new PhongKhamsBUS(this).GetAll(), q => q.TenPhongBan);
            _fillter();
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
    }
}
