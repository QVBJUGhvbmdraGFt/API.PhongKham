using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP.Views
{
    public partial class frmDoctor : BaseForm
    {

        bool isEdit;

        public bool IsEdit
        {
            get => isEdit;
            set
            {
                isEdit = value;
                errorProvider1.Clear();

                btnAdd.Enabled = !isEdit;
                btnEdit.Enabled = isEdit;
                btnDelete.Enabled = isEdit;
                btnChangeAvatar.Enabled = isEdit;
            }
        }

        public frmDoctor()
        {
            InitializeComponent();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void _reload()
        {
            dataGridView1.DataSource = new DoctorBUS(this).GetAll();
            IsEdit = false;
        }

        private void frmDoctor_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var obj = new DoctorDTO();
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                    new DataGridViewTextBoxColumn(){ HeaderText ="Mã bác sĩ" , DataPropertyName = nameof(obj.IDDoctor) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Họ tên" , DataPropertyName = nameof(obj.FullName) },
                    new DataGridViewTextBoxColumn(){ HeaderText ="Giới thiệu" , DataPropertyName = nameof(obj.Sumary) },
                });

            var allSpecia = new SpeciaBUS(this).GetAll();
            cmbSpecia.DataSource = allSpecia;
            cmbSpecia.DisplayMember = "Name";
            cmbSpecia.ValueMember = "IDSpecia";

            search_Specia.DataSource = allSpecia;
            search_Specia.DisplayMember = "Name";
            search_Specia.ValueMember = "IDSpecia";

            search_id.Maximum = int.MaxValue;
            _reload();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is DoctorDTO value)
                {
                    _fillDoctor(value);
                    IsEdit = true;
                }
            }
        }

        private void _fillDoctor(DoctorDTO value)
        {
            txtName.Text = value.FullName;
            ID.Text = value.IDDoctor + "";
            Sumary.Text = value.Sumary;
            TrainingProcess.Text = value.TrainingProcess;
            Study.Text = value.Study;
            cmbSpecia.SelectedValue = value.IDSpecia;
            if (string.IsNullOrWhiteSpace(value.Avatar) == false)
                pictureBox1.LoadAsync(value.Avatar + "");
            else pictureBox1.Image = null;

            btnEdit.Tag = value.IDDoctor;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                new DoctorBUS(this).Create(getDoctor());
                _reload();

                "Thêm thành công".ThongBao();
            }
        }

        private bool checkInput()
        {
            errorProvider1.Clear();
            var res = errorProvider1.Validate(txtName, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(cmbSpecia, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(Study, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            return res;
        }

        private DoctorDTO getDoctor()
        {
            var doctor = new DoctorDTO
            {
                Avatar = pictureBox1.Tag + "",
                FullName = txtName.Text,
                IDDoctor = IsEdit ? int.Parse(btnEdit.Tag + "") : 0,
                IDSpecia = (int)cmbSpecia.SelectedValue,
                Status = "ACTIVE",
                Study = Study.Text,
                Sumary = Sumary.Text,
                TrainingProcess = TrainingProcess.Text,
            };
            return doctor;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new DoctorBUS(this).Update(getDoctor());
            _reload();

            "Sửa thành công".ThongBao();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ("Bạn có muốn xóa bác sĩ này?".XacNhan() == DialogResult.Yes)
            {
                new DoctorBUS(this).Delete(int.Parse(btnEdit.Tag + ""));
                _reload();

                "Xóa thành công".ThongBao();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var source = new List<DoctorDTO>();

            var doctor = new DoctorBUS(this).GetByID((int)search_id.Value);
            source.Add(doctor);

            if (doctor is DoctorDTO value)
            {
                _fillDoctor(value);
            }
            else
            {
                ("Không tìm thấy Bác sĩ có mã " + (int)search_id.Value).ThongBao();
            }

            dataGridView1.DataSource = source;
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            if (IsEdit == false)
            {
                "Vui lòng thêm bác sĩ trước khi thay ảnh".ThongBao();
                return;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var image = Image.FromFile(openFileDialog1.FileName);
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    var data = m.ToArray();
                    var res = new DoctorBUS(this).ChangeAvatar(int.Parse(btnEdit.Tag + ""), data, Path.GetFileName(openFileDialog1.FileName));

                    if (res.Key)
                    {
                        pictureBox1.LoadAsync(res.Value);
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        "Thay đổi thất bại".ThongBao();
                    }
                }
            }
        }
    }
}
