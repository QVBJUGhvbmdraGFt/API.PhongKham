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
    public partial class frmDetailKQKB2 : FormBase
    {
        public frmDetailKQKB2(int KhamBenh_Id)
        {
            InitializeComponent();
            var obj = new KQKBBUS(this).NVGetByKhamBenhId(KhamBenh_Id);
            if (obj != null)
            {
                webBrowser1.DocumentText = new templateDetailKQKB2()
                {
                    Model = obj
                }.TransformText();
            }
        }

        private void frmDetailKQKB_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
    }
}
