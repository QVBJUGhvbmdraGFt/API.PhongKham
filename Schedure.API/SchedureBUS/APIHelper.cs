using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SchedureBUS
{
    public class APIHelper
    {
        private HttpClient client = new HttpClient();
        string tokenBasic;

        public string TokenBasic
        {
            get => tokenBasic;
            set
            {
                tokenBasic = value;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", TokenBasic);
            }
        }

        public APIHelper()
        {
            client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["BaseAddress"]);
            client.Timeout = TimeSpan.FromSeconds(60);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public KeyValuePair<bool, T> POST<T>(string url, object value)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(url, value).GetAwaiter().GetResult();
            return new KeyValuePair<bool, T>(response.IsSuccessStatusCode, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
        }

        public KeyValuePair<bool, T> GET<T>(string url)
        {
            HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();
            return new KeyValuePair<bool, T>(response.IsSuccessStatusCode, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
        }

        public KeyValuePair<bool, T> PUT<T>(string url, object value)
        {
            HttpResponseMessage response = client.PutAsJsonAsync(url, value).GetAwaiter().GetResult();
            return new KeyValuePair<bool, T>(response.IsSuccessStatusCode, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
        }

        public KeyValuePair<bool, T> DELETE<T>(string url)
        {
            HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();
            return new KeyValuePair<bool, T>(response.IsSuccessStatusCode, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
        }

        public KeyValuePair<bool, T> UploadImage<T>(string url, byte[] imageData, string nameImage)
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(new MemoryStream(imageData)), "image", nameImage);
                var res = client.PostAsync(url, content).GetAwaiter().GetResult();
                return new KeyValuePair<bool, T>(res.IsSuccessStatusCode, res.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
            }
        }
    }
}
