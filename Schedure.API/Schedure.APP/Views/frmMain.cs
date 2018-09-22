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
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm, IToken
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            mDataGridView1.BinDataPropertyName<RegisterDTO>(
                new ColumnFormat<RegisterDTO>(q => q.IDRegister),
                new ColumnFormat<RegisterDTO>(q => q.LichLamViec.Doctor.PhongKham.ChuyenKhoa.Name),
                new ColumnFormat<RegisterDTO>(q => q.LichLamViec.Doctor.PhongKham.Name),
                new ColumnFormat<RegisterDTO>(q => q.Account_BenhNhan.FullName),
                new ColumnFormat<RegisterDTO>(q => q.LichLamViec.Doctor.FullName),
                new ColumnFormat<RegisterDTO>(q => q.NgayKham),
                new ColumnFormat<RegisterDTO>(q => q.LichLamViec.TimeSlot.HourStart + " - " + q.LichLamViec.TimeSlot.HourEnd),
                new ColumnFormat<RegisterDTO>(q => q.CreateDate),
                new ColumnFormat<RegisterDTO>(q => q.Status),
                new ColumnFormat<RegisterDTO>(q => q.Status)
                );

            if (_login())
            {
                _reload();
            }
        }

        private bool _login()
        {
            this.Hide();
            if (new frmLogin().ShowDialog() == DialogResult.OK)
            {
                Show();
                return true;
            }
            else
            {
                Close();
            }
            return false;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            _login();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void _reload()
        {
            datestart.Value = DateTime.Now;
            dateend.Value = DateTime.Now.AddDays(14);
            var lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>("", "Tất cả"));
            lst.Add(new KeyValuePair<string, string>("ACTIVE", "Chờ khám"));
            lst.Add(new KeyValuePair<string, string>("CONFIRM", "Chờ xác nhận"));
            lst.Add(new KeyValuePair<string, string>("DONE", "Đã khám"));
            lst.Add(new KeyValuePair<string, string>("CANCLE", "Đã hủy"));
            cmbTrangThai.BindDataSource(lst, q => q.Key, q => q.Value);
            cmbTrangThai.SelectedIndex = 2;

            var pk = new PhongKhamsBUS(this).GetAll();
            pk.Insert(0, new PhongKhamDTO
            {
                IDPhongKham = 0,
                Name = "Tất cả"
            });
            cmbPhongKham.BindDataSource(pk, q => q.IDPhongKham, q => q.Name);
            cmbPhongKham.SelectedIndex = 0;

            _fillter();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            _fillter();
        }

        private void _fillter()
        {
            mDataGridView1.DataSource = new RegisterBUS(this).Fillter(datestart.Value, dateend.Value, (int?)cmbPhongKham.SelectedValue, (string)cmbTrangThai.SelectedValue);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            _search();
        }

        private void _search()
        {
            var res = new RegisterBUS(this).NVGetByID((int)numSearch.Value);
            mDataGridView1.DataSource = new List<RegisterDTO>() { res };
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            _dialog(new frmRegister());
        }

        private void _dialog(frmRegister frmRegister)
        {
            if (frmRegister.ShowDialog() == DialogResult.OK)
            {
                _reload();
            }
        }

        public string GetToken()
        {
            return COMMON.TokenBasic + "";
        }

        private void mDataGridView1_MyCellClick(object sender, DataGridViewCellEventArgs e, object dataBoundItem)
        {
            var obj = dataBoundItem as RegisterDTO;
            if (obj != null)
            {
                if (e.ColumnIndex == mDataGridView1.ColumnCount - 1)
                {
                    switch (obj.Status)
                    {
                        case "CONFIRM":
                            if (new frmConfirm(obj).ShowDialog() == DialogResult.OK)
                            {
                                _reload();
                            }
                            break;
                        case "ACTIVE":
                            if(new frmKQKB(obj).ShowDialog() == DialogResult.OK)
                            {
                                _reload();
                            }
                            
                            break;
                        case "CANCLE":
                            "Đăng kí đã hủy khám!".ThongBao();
                            break;
                        case "DONE":

                            break;
                        default:
                            obj.Status.ThongBao();
                            break;
                    }
                }
            }
        }
    }
}
