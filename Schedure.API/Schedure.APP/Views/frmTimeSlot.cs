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
    public partial class frmTimeSlot : FormBase
    {
        public frmTimeSlot()
        {
            InitializeComponent();
        }

        private void frmTimeSlot_Load(object sender, EventArgs e)
        {
            mDataGridView1.BinDataPropertyName<TimeSlotDTO>(
                new ColumnFormat<TimeSlotDTO>(q => q.Name),
                new ColumnFormat<TimeSlotDTO>(q => q.HourStart),
                new ColumnFormat<TimeSlotDTO>(q => q.HourEnd)
                );

            _reload();
        }

        private void _reload()
        {
            IsEdit = false;
            mDataGridView1.DataSource = new TimeSlotBUS(this).GetAll();
        }

        bool _isEdit;

        public bool IsEdit
        {
            get => _isEdit;
            set
            {
                _isEdit = value;
                buttonX1.Text = _isEdit ? "Sửa" : "Thêm";
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                new TimeSlotBUS(this).Update(new TimeSlotDTO
                {
                    IDTimeSlot = (int)txtName.Tag,
                    HourEnd = new TimeSpan(dateENd.Value.Hour, dateENd.Value.Minute, dateENd.Value.Second),
                    HourStart = new TimeSpan(dateStart.Value.Hour, dateStart.Value.Minute, dateStart.Value.Second),
                    Status = "ACTIVE",
                    Name = txtName.Text,
                });
            }
            else
            {
                new TimeSlotBUS(this).Create(new TimeSlotDTO
                {
                    IDTimeSlot = 0,
                    HourEnd = new TimeSpan(dateENd.Value.Hour, dateENd.Value.Minute, dateENd.Value.Second),
                    HourStart = new TimeSpan(dateStart.Value.Hour, dateStart.Value.Minute, dateStart.Value.Second),
                    Status = "ACTIVE",
                    Name = txtName.Text,
                });
            }
            _reload();
        }

        private void mDataGridView1_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            var obj = dataBoundItem as TimeSlotDTO;
            if (obj != null)
            {
                if (e.ColumnIndex == mDataGridView1.ColumnCount - 1)
                {
                    if ($"Bạn có muốn xóa {obj.Name}".XacNhan() == DialogResult.OK)
                    {
                        new TimeSlotBUS(this).Delete(obj.IDTimeSlot);
                        _reload();
                    }
                }
                else
                {
                    IsEdit = true;
                    txtName.Text = obj.Name;
                    txtName.Tag = obj.IDTimeSlot;
                    dateStart.Value = new DateTime(2018, 1, 1).Add(obj.HourStart ?? TimeSpan.FromDays(0));
                    dateENd.Value = new DateTime(2018, 1, 1).Add(obj.HourEnd ?? TimeSpan.FromDays(0));
                }
            }
        }
    }
}
