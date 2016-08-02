using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace JonHuss_CaaS.Embed.Helpers
{
    public class HttpHelper
    {
        public string ExecuteQuery(string url, string method = "GET", string content = null)
        {
            string responseData = string.Empty;

            HttpWebRequest webRequest = HttpWebRequest.CreateHttp(url);

            webRequest.Headers.Add("Authorization", "BotConnector " + ConfigurationManager.AppSettings["DirectLineSecret"]);
            webRequest.Method = method;
            webRequest.ContentLength = 0;

            if (!string.IsNullOrEmpty(content))
            {
                webRequest.ContentLength = content.Length;

                using (StreamWriter writer = new StreamWriter(webRequest.GetRequestStream()))
                {
                    writer.Write(content);
                }
            }

            using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseData = reader.ReadToEnd();
                }
            }

            return responseData;
        }
    }
}