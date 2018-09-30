using Schedure.APP.Views;
using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP
{
    public partial class FormBase : DevComponents.DotNetBar.Office2007Form, IToken, ILogin
    {
        public Account_NhanVienDTO User { get => COMMON.User; }

        public FormBase()
        {
            InitializeComponent();
        }

        public virtual string GetToken()
        {
            return COMMON.TokenBasic + "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = string.Format(lblTime.Tag + "", DateTime.Now);
        }

        public virtual void SetStatus(object message)
        {
            lblStatus.Text = string.Format(lblStatus.Tag + "", DateTime.Now, message + "");
        }

        public virtual bool SetStatus(bool success = true, string message = null)
        {
            if (string.IsNullOrWhiteSpace(success ? "Thành công." : "Thất bại."))
            {
                message = success ? "Thành công." : "Thất bại.";
            }
            lblStatus.Text = string.Format(lblStatus.Tag + "", DateTime.Now, message);
            if(success == false)
            {
                SystemSounds.Beep.Play();
            }
            return success;
        }

        private void FormBase_Load(object sender, EventArgs e)
        {

        }

        public virtual void Login()
        {
            if (new frmLogin().ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
