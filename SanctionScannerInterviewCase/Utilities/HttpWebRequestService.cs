using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SanctionScannerInterviewCase.Utilities
{
    public class HttpWebRequestService
    {
        public static string RequestWithUrl(string url)
        {
            string siteContent = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader streamReader = new StreamReader(responseStream))
            {
                siteContent = streamReader.ReadToEnd();
            }

            return siteContent;
        }
    }
}
