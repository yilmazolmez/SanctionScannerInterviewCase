using HtmlAgilityPack;
using SanctionScannerInterviewCase.Model;
using SanctionScannerInterviewCase.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SanctionScannerInterviewCase
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<PostModel> PostModelList = new List<PostModel>();
                string websiteUrl = "https://www.otokocikinciel.com";
                var siteContent = HttpWebRequestService.RequestWithUrl(websiteUrl);
                if (siteContent == null || siteContent == "")
                {
                    Console.WriteLine("Empty Content");
                    return;
                }

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(siteContent);

                var sliderList = pageDocument.DocumentNode.SelectNodes("(//ul[contains(@class,'vehicle-slider')]//li)");
                if (sliderList == null)
                {
                    Console.WriteLine("No Content Found");
                    return;
                }

                foreach (var item in sliderList)
                {
                    if (PostModelList.Count == 5) break;

                    var getLinkFromNode = item.SelectSingleNode(".//a");
                    if (getLinkFromNode == null)
                    {
                        continue;
                    }
                    var hrefValue = getLinkFromNode.Attributes["href"].Value;

                    var siteContentDetail = HttpWebRequestService.RequestWithUrl(websiteUrl + hrefValue);
                    if (siteContentDetail == null || siteContentDetail == "")
                    {
                        Console.WriteLine("Empty Detail Content");
                        continue;
                    }

                    HtmlDocument pageDocumentDetail = new HtmlDocument();
                    pageDocumentDetail.LoadHtml(siteContentDetail);

                    var getPostTitle = pageDocumentDetail.DocumentNode.SelectSingleNode("(//div[contains(@class,'ok-hsph-text')]//h1)").InnerText.Trim();

                    var getPostPrice = pageDocumentDetail.DocumentNode.SelectSingleNode("(//div[contains(@class,'ok-veh-price')]//span)").InnerText.Trim().Replace("TL", "");
                    decimal parsedGetPostPrice = decimal.Parse(getPostPrice);

                    PostModelList.Add(new PostModel
                    {
                        PostTitle = getPostTitle,
                        PostPrice = parsedGetPostPrice
                    });
                }

                if (PostModelList.Count == 0)
                {
                    Console.WriteLine("Not Found Post");
                    return;
                }
                else
                {
                    int count = 1;
                    foreach (var item in PostModelList)
                    {
                        var convertPostPrice = item.PostPrice.ToString("#,#", CultureInfo.InvariantCulture).Replace(",", ".");

                        Console.WriteLine($"{count} - Post Title = { item.PostTitle }, Post Price = { convertPostPrice } TL");
                        count++;
                    }

                    var avaragePrice = PostModelList.Average(x => x.PostPrice);
                    Console.WriteLine($"Price of Average = {avaragePrice.ToString("#,#", CultureInfo.InvariantCulture).Replace(",", ".") }");

                    StreamClass.StreamWriter(PostModelList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error In Main. {ex.Message}");
            }
        }
    }
}
