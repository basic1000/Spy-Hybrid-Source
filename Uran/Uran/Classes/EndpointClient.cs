using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Uran_Launcher.Classes
{
    public static class EndpointClient
    {
        public static string HTTPGet(string url)
        {
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static string JSON1 = EndpointClient.HTTPGet("https://UranLauncher.sdkhfgsdjhsdfja.repl.co/general.json");

        public static dynamic jsondata = JsonConvert.DeserializeObject<dynamic>(JSON1);

        public static string version = jsondata["version"].ToString();
        public static string hybrid = jsondata["hybrid"].ToString();
        public static string prvt = jsondata["private"].ToString();
        public static string prvtlabel = jsondata["privatelabel"].ToString();
        public static string hybridlabel = jsondata["hybridlabel"].ToString();
    }
}