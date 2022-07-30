using HtmlAgilityPack;
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
            try
            {
                List<PostModel> PostModelList = new List<PostModel>();

                var siteContent = HttpWebRequestService.RequestWithUrl("https://www.otokocikinciel.com");

                if (siteContent == null || siteContent == "")
                {
                    Console.WriteLine("Empty content");
                    return;
                }

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(siteContent);



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Main. {ex.Message}");
            }
        }
    }
}
