using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AnketaProSerializer;

namespace AnketaProDB
{
    public class QuickFormsDbClient : IQuickFormsDbClient
    {
        private HttpWebRequest request;
        private JsonSerializer serializer;
        private readonly int port;
        private readonly string host;

        public QuickFormsDbClient()
        {
            port = 6892;
            host = "www.ungerfall-anketa.ru";
        }

        public Dictionary<string, List<object>> GetMyForms(string owner)
        {
            var response = GetResponse(String.Format("forms/GetMyForms.php?owner={0}", owner));
            return response == null
                ? null
                : serializer.Deserialize<Dictionary<string, List<object>>>(response.ReadToEnd());
        }

        private HttpWebResponse GetResponse(string methodName, string body = "")
        {
            serializer = new JsonSerializer();
            request = (HttpWebRequest)WebRequest.Create(string.Format("{0}:{1}/{2}", host, port, methodName));
            request.Timeout = 150;
            request.ContentLength = Encoding.UTF8.GetByteCount(body);
            request.Method = (body == string.Empty) ? "GET" : "POST";
            if (body.Length > 0)
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(Encoding.UTF8.GetBytes(body), 0, (int)request.ContentLength);
                }
            }

            try
            {
                return (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                return null;
            }
        }

    }
}