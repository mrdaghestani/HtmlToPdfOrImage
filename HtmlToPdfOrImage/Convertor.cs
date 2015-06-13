using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToPdfOrImage
{
    public class Api
    {
        //"http://localhost:25288/Api/"
        //"http://htmltopdforimage.com/Api/"
        private string _apiUrl = "http://localhost:25288/Api/";

        public string ApiUrl
        {
            get { return _apiUrl; }
            set { _apiUrl = value; }
        }
        private int _timeout = 60 * 1000;

        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }


        public Api(string apiKey, string password)
        {
            ApiKey = apiKey;
            Password = password;
        }
        public string ApiKey { get; set; }
        public string Password { get; set; }

        public JsonResultViewModel Convert(Uri uri, GenerateSettings settings = null)
        {
            if (settings == null)
            {
                settings = new GenerateSettings();
            }
            settings.Url = uri.ToString();
            return Convert(settings);
        }
        public JsonResultViewModel Convert(string html, GenerateSettings settings = null)
        {
            if (settings == null)
            {
                settings = new GenerateSettings();
            }
            settings.Url = null;
            settings.HtmlFileContent = html;
            return Convert(settings);
        }
        private JsonResultViewModel Convert(GenerateSettings settings)
        {
            return Execute<byte[]>(ApiUrl + "Generate", settings);
        }
        public JsonResultViewModel Credit()
        {
            return Execute<int>(ApiUrl + "Credit");
        }
        private JsonResultViewModel Execute<T>(string url, object data = null)
        {
            var result = Execute<JsonResultViewModel>(url, Newtonsoft.Json.JsonConvert.SerializeObject(data));
            if (result.model != null)
            {
                result.model = (T)Newtonsoft.Json.JsonConvert.DeserializeObject(result.model.ToString(), typeof(T));
            }
            return result;
        }
        private T Execute<T>(string url, string data)
        {
            var value = Execute(url, data);
            return (T)Newtonsoft.Json.JsonConvert.DeserializeObject(value, typeof(T));
        }
        private string Execute(string url, string data)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            byte[] textArray = data == null ? new byte[0] : Encoding.UTF8.GetBytes(data);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json; charset=utf-8";
            httpRequest.Timeout = Timeout;

            //Write api-key & password to request
            httpRequest.Headers.Add("dh-ApiKey", ApiKey);
            httpRequest.Headers.Add("dh-Password", Password);

            httpRequest.ContentLength = textArray.Length;
            httpRequest.GetRequestStream().Write(textArray, 0, textArray.Length);

            using (HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var jsonResult = reader.ReadToEnd();
                    return jsonResult;
                }
            }
        }

    }
}
