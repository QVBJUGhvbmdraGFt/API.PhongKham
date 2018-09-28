using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace Schedure.Web.Models
{
    public class CaptchaGoogle
    {
        public static CaptchaResponse CheckCaptcha()
        {
            var response = HttpContext.Current.Request["g-recaptcha-response"];
            //secret that was generated in key value pair
            //public: 6Lc_T3IUAAAAAJKxZHH3qqc1Q-H1UokW7uZWBw8q
            //private: 6Lc_T3IUAAAAACoBnbXmB1dL8-X_7lGHA1ocdaX2
            const string secret = "6Lc_T3IUAAAAACoBnbXmB1dL8-X_7lGHA1ocdaX2";

            var client = new WebClient();
            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            return captchaResponse;
        }
    }
    public class CaptchaResponse
    {
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}