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
    public partial class frmDetailKQKB : FormBase
    {
        public frmDetailKQKB(int KhamBenh_Id)
        {
            InitializeComponent();
            var obj = new KQKBBUS(this).NVGetByKhamBenhId(KhamBenh_Id);
            if (obj != null)
            {
                TenBenhNhan.FormatTextFromTag(obj.TenBenhNhan);
                MaYTe.FormatTextFromTag(obj.MaYTe);
                Tuoi.FormatTextFromTag(obj.Tuoi);
                GioiTinh.FormatTextFromTag(obj.GioiTinh);
                DiaChi.FormatTextFromTag(obj.DiaChi);
                SDT.FormatTextFromTag(obj.SoDienThoai);
                THoiGianKham.FormatTextFromTag(obj.ThoiGianKham);
                NoiDungKham.FormatTextFromTag(obj.NoiDungKham);
                TrieuChungLamSang.FormatTextFromTag(obj.TrieuChungLamSang);
                ChuanDoanLamSang.FormatTextFromTag(obj.ChanDoanKhoaKham);
                TenPhongBan.FormatTextFromTag(obj.TenPhongBan);
                HuyeAp.FormatTextFromTag(obj.HuyetAp);
                Mach.FormatTextFromTag(obj.Mach);
                NhietDo.FormatTextFromTag(obj.NhietDo);
                NhipTho.FormatTextFromTag(obj.NhipTho);
                ChieuCao.FormatTextFromTag(obj.ChieuCao);
                CanNang.FormatTextFromTag(obj.CanNang);
                SoBHYT.FormatTextFromTag(obj.SoBHYT);
                NguoiLienHe.FormatTextFromTag(obj.NguoiLienHe);
                NgayhentaiKham.FormatTextFromTag(obj.NgayHenTaiKham);
                MaBenh.FormatTextFromTag(obj.MaBenh);
                MaBenhPhu.FormatTextFromTag(obj.MaBenhPhu);
            }
        }

        private void frmDetailKQKB_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
