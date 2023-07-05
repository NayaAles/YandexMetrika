﻿using System.Net;
using System.Text;

namespace YandexMetrika
{
    public class ApiYandexMetrika
    {
        public static void SimplePost(string filePath, string mode, string delimiter)
        {
            string url = $"https://api-metrika.yandex.net/cdp/api/v1/counter/89339240/data/simple_orders?merge_mode={mode}&delimiter_type={delimiter}";

            var client = new MyWebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.Headers.Add("Authorization", "OAuth y0_AgAAAABDRnkZAAhMMgAAAADllzv3veg-lpg3TJeEwYY3z4M7iPZnXJI");
            client.Headers.Add("Content-Type", "text/csv");

            var response = Encoding.ASCII.GetString(client.UploadFile(url, "POST", filePath));
            Console.WriteLine(response);
            client.Dispose();
        }
    }

    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
           var w = (HttpWebRequest)base.GetWebRequest(uri);
            w.Timeout = 1000 * 20 * 60 * 1000;
            return w;
        }
    }
}