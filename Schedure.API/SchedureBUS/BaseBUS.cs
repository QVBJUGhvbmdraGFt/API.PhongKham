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
        public ILogin login { get; set; }

        public BaseBUS(IToken token)
        {
            this.token = token;
            API = new APIHelper
            {
                TokenBasic = token.GetToken()
            };

            API.ResponseMessage += API_ResponseMessage;
        }

        public virtual void API_ResponseMessage(System.Net.Http.HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                login?.Login();
            }
        }
    }
}
