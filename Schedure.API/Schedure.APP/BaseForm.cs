using SchedureBUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP
{
    public class BaseForm : Form, IToken
    {
        public string GetToken()
        {
            return COMMON.TokenBasic + "";
        }
    }
}
