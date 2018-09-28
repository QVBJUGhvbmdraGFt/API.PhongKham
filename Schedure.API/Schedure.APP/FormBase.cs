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

namespace Schedure.APP
{
    public partial class FormBase : Form, IToken
    {
        public Account_NhanVienDTO User { get => COMMON.User; }

        public FormBase()
        {
            InitializeComponent();
        }

        public string GetToken()
        {
            return COMMON.TokenBasic + "";
        }

    }
}
