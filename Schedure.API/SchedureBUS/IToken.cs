using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public interface IToken
    {
        string GetToken();
    }

    public interface ILogin
    {
        void Login();
    }
}
