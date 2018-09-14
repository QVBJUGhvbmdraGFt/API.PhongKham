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
    public partial class frmLichSuKhamBenh : BaseForm
    {
        private bool isEdit;
        private List<CTToaThuocDTO> lstCTThuoc;
        private bool _isEnload = false;

        public AccountDTO Account { get; set; }
        public bool IsEdit
        {
            get => isEdit;
            set
            {
                isEdit = value;
                btnSaveHistory.Enabled = isEdit;
                grToaThuoc.Enabled = isEdit;
                grHistory.Visible = isEdit;
                if (isEdit == false) grToaThuoc.Visible = false;
            }
        }

        public frmLichSuKhamBenh(int IDAccount)
        {
            InitializeComponent();
            Account = new AccountBUS(this).GetByID(IDAccount);
            ucAccount1.FillAccount(Account);
        }

        private void frmLichSuKhamBenh_Load(object sender, EventArgs e)
        {
            this.ucAccount1.Token = this;

            grvRegister.AutoGenerateColumns = false;
            grvRegister.Columns.Clear();
            var obj = new RegisterDTO();
            grvRegister.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn{ DataPropertyName =nameof(obj.IDRegister) ,HeaderText ="Mã đăng kí" },
                new DataGridViewTextBoxColumn{ DataPropertyName = nameof(obj.CreateDate) ,HeaderText ="Ngày đăng kí" },
                new DataGridViewTextBoxColumn{ DataPropertyName = nameof(obj.Doctor_FullName),HeaderText ="Bác sĩ" },
                new DataGridViewTextBoxColumn{ DataPropertyName = nameof(obj.Status),HeaderText ="Trạng thái" },
        });

            grvCTToaThuoc.AutoGenerateColumns = false;
            grvCTToaThuoc.Columns.Clear();
            var obj2 = new CTToaThuocDTO();
            grvCTToaThuoc.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn{ DataPropertyName =nameof(obj2.IDThuoc) ,HeaderText ="Mã thuốc" },
                new DataGridViewTextBoxColumn{ DataPropertyName =nameof(obj2.Thuoc_Name) ,HeaderText ="Tên thuốc" },
                new DataGridViewTextBoxColumn{ DataPropertyName =nameof(obj2.SoLuong) ,HeaderText ="Số lượng" },
                new DataGridViewTextBoxColumn{ DataPropertyName =nameof(obj2.Thuoc_DonVi) ,HeaderText ="Đơn vị" },
                new DataGridViewTextBoxColumn{ DataPropertyName =nameof(obj2.GiaTien) ,HeaderText ="Giá tiền (VND)" },
                new DataGridViewButtonColumn{ HeaderText="",UseColumnTextForButtonValue= true, Text = "Xóa"  },
        });

            cmbDoctor.DataSource = new DoctorBUS(this).GetAll();
            cmbDoctor.DisplayMember = "FullName";
            cmbDoctor.ValueMember = "IDDoctor";

            var source = new ThuocBUS(this).GetAll().ToArray();
            cmbThuoc.DataSource = source;
            cmbThuoc.DisplayMember = "Name";
            cmbThuoc.ValueMember = "IDThuoc";

            var lstCacGiaiQuyet = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("HenTaiKham","Hẹn tái khám"),
                new KeyValuePair<string, string>("CapDonThuoc","Cấp đơn thuốc"),
                new KeyValuePair<string, string>("","Khác"),
            };
            cmbCachGiaiQuyet.DataSource = lstCacGiaiQuyet;
            cmbCachGiaiQuyet.ValueMember = "Key";
            cmbCachGiaiQuyet.DisplayMember = "Value";

            _reload();

            _isEnload = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void _reload()
        {
            grvRegister.DataSource = new RegisterBUS(this).GetByAccount(Account.IDAccount);
            IsEdit = false;
        }

        private void btnSearch_History_Click(object sender, EventArgs e)
        {
            var lst = new List<RegisterDTO>();
            if (new RegisterBUS(this).GetByID((int)search_history.Value) is RegisterDTO value)
            {
                lst.Add(value);
            }
            else "Không tìm thấy".ThongBao();
            grvRegister.DataSource = lst;
        }

        public void LoadRegister(int iDRegister)
        {
            var register = new RegisterBUS(this).GetByID(iDRegister);
            if (register != null)
            {
                var kq = new HistoryKhamBenhBUS(this).GetByIDRegister(iDRegister);
                if (kq == null || kq.IDHistory == 0)
                {
                    kq = new HistoryKhamBenhDTO
                    {
                        IDHistory = 0,
                        IDDoctor = register.IDDoctor,
                        IDRegister = register.IDRegister
                    };
                }
                _fillHistory(kq);
                ucAccount1.Tag = iDRegister;
            }
        }

        private void _fillHistory(HistoryKhamBenhDTO kq)
        {
            MaICD.Tag = kq.IDHistory;

            cmbDoctor.SelectedValue = kq.IDDoctor;
            MaICD.Value = kq.ICD ?? 0;
            ChieuCao.Value = kq.ChieuCao ?? 0;
            CanNang.Value = kq.CanNang ?? 0;
            NhietDo.Value = kq.NhietDo ?? 0;
            HuyetApTT.Value = kq.HuyetApTT ?? 0;
            HuyetApTD.Value = kq.HuyetApTD ?? 0;
            NhipTho.Value = kq.NhipTho ?? 0;
            Mach.Value = kq.Mach ?? 0;
            CreateDate.Value = kq.CreateTime ?? DateTime.Now;
            TrieuChungLamSang.Text = kq.TrieuChungLS;
            cmbCachGiaiQuyet.SelectedValue = kq.CachGiaiQuyet ?? "";
            ChuanDoanSoBo.Text = kq.ChuanDoanSoBo;

            lstCTThuoc = new List<CTToaThuocDTO>();
            if (kq.IDHistory > 0 && kq.CachGiaiQuyet == "CapDonThuoc")
            {
                var toathuoc = new ToaThuocBUS(this).GetByIDHistory(kq.IDHistory);
                if (toathuoc == null)
                {
                    toathuoc = new ToaThuocDTO
                    {
                        IDHistory = kq.IDHistory,
                        Gia = 0,
                        IDToaThuoc = 0,
                        CachDung = "",
                        GhiChu = ""
                    };
                }
                lstCTThuoc = new CTToaThuocBUS(this).GetByIDToaThuoc(toathuoc.IDToaThuoc);

                CachDung.Tag = toathuoc.IDToaThuoc;
                CachDung.Text = toathuoc.CachDung;
                GhiChu.Text = toathuoc.GhiChu;
                Gia.Value = toathuoc.Gia ?? 0;
                MaICD.Tag = toathuoc.IDHistory ?? 0;

            }
            grvCTToaThuoc.DataSource = new List<CTToaThuocDTO>(lstCTThuoc);
        }

        private void btnSaveHistory_Click(object sender, EventArgs e)
        {
            var his = getHistory();
            if (his.IDHistory == 0)
            {
                new HistoryKhamBenhBUS(this).Create(his);
                his = new HistoryKhamBenhBUS(this).GetByIDRegister(his.IDRegister.Value);
            }
            else new HistoryKhamBenhBUS(this).Update(his);

            if (his.CachGiaiQuyet == "CapDonThuoc")
            {
                ToaThuocDTO toaThuoc = _getToaThuoc();
                toaThuoc.IDHistory = his.IDHistory;
                if (toaThuoc.IDToaThuoc == 0)
                {
                    new ToaThuocBUS(this).Create(toaThuoc);
                    toaThuoc = new ToaThuocBUS(this).GetByIDHistory(his.IDHistory);
                }
                else new ToaThuocBUS(this).Update(toaThuoc);

                var busCT = new CTToaThuocBUS(this);
                foreach (var item in lstCTThuoc)
                {
                    if (item.IDCT > 0)
                    {
                        busCT.Update(item);
                    }
                    else
                    {
                        item.IDToaThuoc = toaThuoc.IDToaThuoc;
                        busCT.Create(item);
                    }
                }
            }

            var registerBUS = new RegisterBUS(this);
            var register = registerBUS.GetByID(his.IDRegister.Value);
            if (register.Status != "DONE")
            {
                register.Status = "DONE";
                registerBUS.Update(register);
            }

            IsEdit = false;
            _reload();
            "Lưu kết quả thành công".ThongBao();
        }

        private ToaThuocDTO _getToaThuoc()
        {
            return new ToaThuocDTO
            {
                IDToaThuoc = (int?)CachDung.Tag ?? 0,
                CachDung = CachDung.Text,
                GhiChu = GhiChu.Text,
                Gia = (int)Gia.Value,
                IDHistory = (int?)MaICD.Tag ?? 0,
            };
        }

        private HistoryKhamBenhDTO getHistory()
        {
            return new HistoryKhamBenhDTO
            {
                CachGiaiQuyet = cmbCachGiaiQuyet.SelectedValue.ToString(),
                ChuanDoanSoBo = ChuanDoanSoBo.Text,
                TrieuChungLS = TrieuChungLamSang.Text,
                CanNang = (int)CanNang.Value,
                ChieuCao = (int)CanNang.Value,
                CreateTime = CreateDate.Value,
                HuyetApTD = (int)HuyetApTD.Value,
                HuyetApTT = (int)HuyetApTT.Value,
                ICD = (int)MaICD.Value,
                IDDoctor = (int)cmbDoctor.SelectedValue,
                IDHistory = (int?)MaICD.Tag ?? 0,
                IDRegister = (int?)ucAccount1.Tag,
                Mach = (int)Mach.Value,
                NhietDo = (int)NhietDo.Value,
                NhipTho = (int)NhipTho.Value,
            };
        }

        private void grvRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (grvRegister.Rows[e.RowIndex].DataBoundItem is RegisterDTO value)
                {
                    LoadRegister(value.IDRegister);
                    IsEdit = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var toaThuoc = _getToaThuoc();
            var ct = lstCTThuoc.FirstOrDefault(q => q.IDThuoc == (int)cmbThuoc.SelectedValue);
            var thuoc = ((ThuocDTO)cmbThuoc.SelectedItem);

            if (ct == null)
            {
                lstCTThuoc.Add(new CTToaThuocDTO
                {
                    GiaTien = thuoc.GiaTien * (int)SoLuong.Value,
                    IDCT = 0,
                    IDThuoc = (int)cmbThuoc.SelectedValue,
                    IDToaThuoc = toaThuoc.IDToaThuoc,
                    SoLuong = (int)SoLuong.Value,
                    Thuoc_DonVi = thuoc.DonVi,
                    Thuoc_Name = thuoc.Name,
                });
            }
            else
            {
                ct.SoLuong = (int)SoLuong.Value;
                ct.GiaTien = ct.SoLuong * thuoc.GiaTien;
            }

            Gia.Value = lstCTThuoc.Sum(q => q.GiaTien) ?? 0;
            grvCTToaThuoc.DataSource = new List<CTToaThuocDTO>(lstCTThuoc);
        }

        private void cmbThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isEnload == false) return;

            var ct = lstCTThuoc.FirstOrDefault(q => q.IDThuoc == (int)cmbThuoc.SelectedValue);
            if (ct is CTToaThuocDTO value)
            {
                _fillCTToaThuoc(value);
            }
            else
            {
                SoLuong.Value = 0;
            }
        }

        private void _fillCTToaThuoc(CTToaThuocDTO value)
        {
            SoLuong.Value = value.SoLuong ?? 0;
            cmbThuoc.SelectedValue = value.IDThuoc;

            btnUpdate.Tag = value.IDCT;
        }

        private void grvCTToaThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var ct = grvCTToaThuoc.Rows[e.RowIndex].DataBoundItem as CTToaThuocDTO;
                var item = lstCTThuoc.FirstOrDefault(q => q.IDThuoc == ct.IDThuoc);
                if (e.ColumnIndex == 5)
                {
                    if ("Bạn có muốn xóa Thuốc này không?".XacNhan() == DialogResult.Yes)
                    {
                        if (item != null)
                        {
                            lstCTThuoc.Remove(item);
                            grvCTToaThuoc.DataSource = new List<CTToaThuocDTO>(lstCTThuoc);
                            if (item.IDCT > 0)
                            {
                                new CTToaThuocBUS(this).Delete(item.IDCT);
                            }
                        }
                    }
                }
                else
                {
                    _fillCTToaThuoc(ct);
                }
            }
        }

        private void grvCTToaThuoc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void cmbCachGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isEnload)
            {
                grToaThuoc.Visible = ((cmbCachGiaiQuyet.SelectedValue + "") == "CapDonThuoc");
            }
        }
    }
}
