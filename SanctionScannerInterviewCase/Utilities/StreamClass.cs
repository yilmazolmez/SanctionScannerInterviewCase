using SanctionScannerInterviewCase.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace SanctionScannerInterviewCase.Utilities
{
    public  class StreamClass
    {
        public static void StreamWriter(List<PostModel> postList)
        {
            using (StreamWriter sw = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "PostFile.txt"))
            {
                int count = 1;
                foreach (var item in postList)
                {
                    var convertPostPrice = item.PostPrice.ToString("#,#", CultureInfo.InvariantCulture).Replace(",", ".");
                    sw.WriteLine($"{count} - Post Title = { item.PostTitle }, Post Price = { convertPostPrice } TL");
                    count++;
                }
            }

        }
    }
}
