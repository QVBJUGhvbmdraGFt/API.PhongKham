using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Schedure.API.Models;

namespace Schedure.API.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Test([FromBody]int k)
        {
            var data = new
            {
                A = "Hoàng Tiệp",
                B = 123.123
            };
            string encode = JsonConvert.SerializeObject(data);
            string kk = Convert.ToBase64String(Encoding.UTF8.GetBytes(encode));
            return Ok(kk);
        }

        [HttpGet]
        public IHttpActionResult Test2([FromBody]int k)
        {
            var data = new Account_BenhNhan
            {
                Username = "Hoàng Tiệp",
                IDAccountBN = 10
            };
            return Ok(data.Encode<Account_BenhNhan>(Models.Encoder.GetKey()));
        }
    }
}