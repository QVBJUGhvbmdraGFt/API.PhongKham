using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedure.API.Models
{
    public class UploadHelper
    {
        public static KeyValuePair<bool, string> SaveImage()
        {
            var request = HttpContext.Current.Request;
            var files = request.Files;
            if (files != null && files.Count == 1)
            {
                var image = files[0];
                if (image.ContentLength <= 1 * 1024 * 1024)
                {
                    var filename = $"{DateTime.Now.ToString("hhmmssddMMyyyy")}_{image.FileName}";
                    var path = $"/Upload/image/{filename}";
                    image.SaveAs(HttpContext.Current.Server.MapPath(path));
                    path = $"http://{request.Url.Authority}{path}";
                    return new KeyValuePair<bool, string>(true, path);
                }
                return new KeyValuePair<bool, string>(false, $"Size max file {1 * 1024 * 1024} bytes.");
            }
            return new KeyValuePair<bool, string>(false, "FAILT");
        }
    }
}