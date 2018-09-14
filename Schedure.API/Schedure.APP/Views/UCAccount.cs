using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchedureDTO;
using SchedureBUS;
using System.IO;

namespace Schedure.APP.Views
{
    public partial class UCAccount : UserControl
    {
        public IToken Token { get; set; }

        public UCAccount()
        {
            InitializeComponent();
        }

        public void FillAccount(AccountDTO value)
        {
            ID.Text = value.IDAccount + "";
            Username.Text = value.Username;
            Email.Text = value.Email;
            Phone.Text = value.Phone;
            Adress.Text = value.Adress;
            FullName.Text = value.FullName;
            Male.Checked = value.Male ?? false;
            Birthday.Value = value.Birthday ?? new DateTime(1990, 1, 1);
            TieuSu.Text = value.TieuSu;
            Position.SelectedValue = value.POSITION + "";
            Username.Tag = value.IDAccount;
            Email.Tag = value.Password;
            pictureBox1.Tag = value.Avatar;
            if (string.IsNullOrWhiteSpace(value.Avatar) == false)
                pictureBox1.LoadAsync(value.Avatar + "");
            else pictureBox1.Image = null;

            this.Refresh();
        }

        public void ClearError()
        {
            errorProvider1.Clear();
        }

        public bool CheckInput()
        {
            errorProvider1.Clear();
            var res = true;
            res = res & errorProvider1.Validate(Username, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(Adress, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(Email, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(FullName, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(Phone, (s) => { return string.IsNullOrWhiteSpace(s) == false; });
            res = res & errorProvider1.Validate(Position, (s) => { return string.IsNullOrWhiteSpace(s) == false; });

            return res;
        }

        public AccountDTO GetAccount()
        {
            return new AccountDTO
            {
                Adress = Adress.Text,
                Avatar = pictureBox1.Tag + "",
                Birthday = Birthday.Value,
                Email = Email.Text,
                FullName = FullName.Text,
                IDAccount = (int?)Username.Tag ?? 0,
                Male = Male.Checked,
                Password = Email.Tag + "",
                Phone = Phone.Text,
                POSITION = Position.SelectedValue + "",
                Status = "ACTIVE",
                TieuSu = TieuSu.Text,
                Username = Username.Text,
            };
        }


        private void UCAccount_Load(object sender, EventArgs e)
        {
            var source_postion = new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("SA","Super Admin"),
                new KeyValuePair<string, string>("ADMIN","Admin"),
                new KeyValuePair<string, string>("YTA","Y tá"),
                new KeyValuePair<string, string>("","Bệnh nhân"),
            };


            Position.DataSource = source_postion;
            Position.ValueMember = "Key";
            Position.DisplayMember = "Value";
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var image = Image.FromFile(openFileDialog1.FileName);
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    var data = m.ToArray();
                    var res = new AccountBUS(Token).ChangeAvatar(GetAccount().IDAccount, data, Path.GetFileName(openFileDialog1.FileName));

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
