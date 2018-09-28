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
    public partial class frmLichLamViec : FormBase
    {
        private List<TimeSlotDTO> _lstTimeSlot;

        public frmLichLamViec()
        {
            InitializeComponent();
            _lstTimeSlot = new TimeSlotBUS(this).GetAll();
        }

        private void frmLichLamViec_Load(object sender, EventArgs e)
        {
            mDataGridView1.AutoGenerateColumns = true;
            cmbPhongKham.BindItems(new PhongKhamsBUS(this).GetAll(), q => q.TenPhongBan);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            _fillter();
        }

        private void _fillter()
        {
            var obj = cmbPhongKham.SelectedItem as PhongBanDTO;
            if (obj != null)
            {

                var lich = new LichLamViecsBUS().GetByIDPhongBan(obj.IDPhongBan);
                var bacsi = new PhongKhamsBUS(this).GetDoctorByPhongKham(obj.IDPhongBan);
                DataTable table = new DataTable();

                table.Columns.Add(new DataColumn("BS", typeof(string)));
                table.Columns.Add(new DataColumn("ID_BS", typeof(int)));
                foreach (var item in _lstTimeSlot)
                {
                    table.Columns.Add(item.IDTimeSlot.ToString(), typeof(int));
                    table.Columns.Add($"{item.Name} ({item.HourStart?.ToString("hh\\:mm")} - {item.HourEnd?.ToString("hh\\:mm")})", typeof(bool));
                }

                foreach (var item in bacsi)
                {
                    var row = table.NewRow();
                    row[0] = item.FullName; //BS
                    row[1] = item.IDDoctor; //IDBS

                    var bybs = lich.Where(q => q.NhanVien_Id == item.IDDoctor);
                    for (int i = 2; i < table.Columns.Count; i += 2)
                    {
                        int id_timeslot = int.Parse(table.Columns[i].ColumnName);
                        var tr = bybs.FirstOrDefault(q => q.IDTimeSlot == id_timeslot);
                        row[i] = tr?.IDLich ?? 0; // id
                        row[i + 1] = tr != null; // checkbox
                    }

                    table.Rows.Add(row);
                }

                mDataGridView1.DataSource = table;

                mDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                mDataGridView1.Columns[1].Visible = false;
                for (int i = 2; i < mDataGridView1.Columns.Count; i += 2)
                {
                    mDataGridView1.Columns[i].Visible = false;
                }
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (cmbPhongKham.SelectedItem is PhongBanDTO obj)
            {
                var bus = new LichLamViecsBUS();
                var id_phongban = obj.IDPhongBan;
                foreach (DataGridViewRow row in mDataGridView1.Rows)
                {
                    int id_bs = (int)row.Cells[1].Value;
                    for (int i = 2; i < mDataGridView1.Columns.Count; i += 2)
                    {
                        if (row.Cells[i + 1] is DataGridViewCheckBoxCell checkbox)
                        {
                            var new_value = (bool)checkbox.Value;
                            int id_lich = (int)row.Cells[i].Value;
                            if (id_lich == 0 && new_value == true)
                            {
                                bus.Create(this, new LichLamViecDTO
                                {
                                    NhanVien_Id = id_bs,
                                    IDTimeSlot = int.Parse(mDataGridView1.Columns[i].Name),
                                    IDPhongKham = id_phongban,
                                    CreaterDate = DateTime.Now,
                                    Status = "ACTIVE",
                                    Creater_Id = User.IDAccountNV,
                                    Date = DateTime.Now
                                });
                            }
                            else if (id_lich > 0 && new_value == false)
                            {
                                bus.Delete(this, id_lich);
                            }
                        }
                    }
                }

                _fillter();
                "Lưu thành công".ThongBao();
            }
        }

        private void mDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 2 && mDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell checkbox)
            {
                checkbox.Style.BackColor = (bool)e.Value ? Color.Green : SystemColors.Control;
            }
        }
    }
}
