using SanctionScannerInterviewCase.Model;
using SanctionScannerInterviewCase.Utilities;
using System;
using System.Collections.Generic;

namespace SanctionScannerInterviewCase
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PostModel> PostModelList = new List<PostModel>();

            var siteContent = HttpWebRequestService.RequestWithUrl("https://www.otokocikinciel.comasdasdsa");

            if (siteContent == null  || siteContent == "")
            {
                Console.WriteLine("Empty content");
                return;
            }


        }
    }
}
