﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchedureBUS;

namespace Schedure.APP.Views
{
    public partial class frmLogin : BaseForm
    {
        public frmLogin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var resLogin = new AuthenticateBUS().Login(txtUsername.Text, txtPassword.Text);
            if (resLogin.Key)
            {
                var acc = new AuthenticateBUS().GetAccount(resLogin.Value);
                if (acc.POSITION == "BACSI" || acc.POSITION == "YTA" || acc.POSITION == "SA")
                {
                    COMMON.User = acc;
                    COMMON.TokenBasic = resLogin.Value;
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
            }
            "Đăng nhập thất bại".ThongBao();
        }
    }
}
