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

        public APIHelper(string TokenBasic) : base()
        {
            this.TokenBasic = tokenBasic;
        }

        #region ASYNC

        public async Task<KeyValuePair<bool, T>> POSTAsyns<T>(string url, object value)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(url, value);
            if (response.IsSuccessStatusCode)
            {
                return new KeyValuePair<bool, T>(true, await response.Content.ReadAsAsync<T>());
            }
            response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
            return new KeyValuePair<bool, T>(false, default(T));
        }

        public async Task<KeyValuePair<bool, T>> GETAsyns<T>(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return new KeyValuePair<bool, T>(true, await response.Content.ReadAsAsync<T>());
            }
            response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
            return new KeyValuePair<bool, T>(false, default(T));
        }

        public async Task<KeyValuePair<bool, T>> PUTAsyns<T>(string url, object value)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(url, value);
            if (response.IsSuccessStatusCode)
            {
                return new KeyValuePair<bool, T>(true, await response.Content.ReadAsAsync<T>());
            }
            response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
            return new KeyValuePair<bool, T>(false, default(T));
        }

        public async Task<KeyValuePair<bool, T>> DELETEAsyns<T>(string url)
        {
            HttpResponseMessage response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return new KeyValuePair<bool, T>(true, await response.Content.ReadAsAsync<T>());
            }
            response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
            return new KeyValuePair<bool, T>(false, default(T));
        }

        public async Task<KeyValuePair<bool, T>> UploadImageAsync<T>(string url, byte[] imageData, string nameImage)
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(new MemoryStream(imageData)), "image", nameImage);
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return new KeyValuePair<bool, T>(true, await response.Content.ReadAsAsync<T>());
                }
                response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
                return new KeyValuePair<bool, T>(false, default(T));
            }
        }

        #endregion

        #region VOID

        public KeyValuePair<bool, T> POST<T>(string url, object value)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(url, value).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                return new KeyValuePair<bool, T>(true, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
            }
            response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
            return new KeyValuePair<bool, T>(false, default(T));
        }

        public KeyValuePair<bool, T> GET<T>(string url)
        {
            HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                return new KeyValuePair<bool, T>(true, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
            }
            response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
            return new KeyValuePair<bool, T>(false, default(T));
        }

        public KeyValuePair<bool, T> PUT<T>(string url, object value)
        {
            HttpResponseMessage response = client.PutAsJsonAsync(url, value).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                return new KeyValuePair<bool, T>(true, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
            }
            response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
            return new KeyValuePair<bool, T>(false, default(T));
        }

        public KeyValuePair<bool, T> DELETE<T>(string url)
        {
            HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                return new KeyValuePair<bool, T>(true, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
            }
            response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
            return new KeyValuePair<bool, T>(false, default(T));
        }

        public KeyValuePair<bool, T> UploadImage<T>(string url, byte[] imageData, string nameImage)
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(new MemoryStream(imageData)), "image", nameImage);
                var response = client.PostAsync(url, content).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    return new KeyValuePair<bool, T>(true, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
                }
                response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
                return new KeyValuePair<bool, T>(false, default(T));
            }
        }

        #endregion

        #region CUSTOM

        public async Task<KeyValuePair<HttpStatusCode, T>> POSTAsynsCode<T>(string url, object value)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(url, value);
            if (response.IsSuccessStatusCode)
            {
                return new KeyValuePair<HttpStatusCode, T>(response.StatusCode, response.Content.ReadAsAsync<T>().GetAwaiter().GetResult());
            }
            response.Content.ReadAsStringAsync().GetAwaiter().GetResult().DebugLog($"[{(int)response.StatusCode}-{response.StatusCode}] - ({url})");
            return new KeyValuePair<HttpStatusCode, T>(response.StatusCode, default(T));
        }

        #endregion

    }
}
