using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedureBUS
{
    public class BaseBUS
    {
        public APIHelper API { get; private set; }
        public IToken token { get; private set; }

        public BaseBUS(IToken token)
        {
            this.token = token;
            API = new APIHelper
            {
                TokenBasic = token.GetToken()
            };
        }
    }
}
