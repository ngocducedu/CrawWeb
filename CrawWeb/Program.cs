using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Text;
using System.Data.Odbc;
using System.Threading.Tasks;
using System.IO;


namespace CrawWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            startCrawlerasync();
            
            Console.ReadKey();
        }

        private static async Task startCrawlerasync()
        {
            var url = "https://vn.investing.com/economic-calendar/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            //var plainText = HtmlUtilities.ConvertToPlainText(string html);

            //string[] text =
            //    {
            //            htmlDocument.DocumentNode.OuterHtml
            //     };


            //await File.WriteAllLinesAsync("WriteLines.txt", text);
            var cars = new List<Car>();
            var divs =
             htmlDocument.DocumentNode.Descendants("tr")
                .Where(node => node.GetAttributeValue("class", "").Equals("js-event-item"));

            string combindedString2 = string.Join(",", "");
            foreach (var node in divs)
            {
              
                combindedString2 = string.Join(",", node.InnerHtml);

            }
            string combindedString = string.Join(",", divs);
            string[] text2 =
                {
                        combindedString2
                 };

            await File.WriteAllLinesAsync("WriteLines.txt", text2);
            //string[] texts =
            //    {
            //            htmlDocument.DocumentNode.SelectSingleNode("//*[@id='eventRowId_431304']");
            //    };


            //await File.WriteAllLinesAsync("WriteLines.txt", texts);

            //var td = div.SelectNodes("td").Select(td => td.InnerText)
            //foreach (var div in divs)
            //{

            //    var car = new Car
            //    {

            //        //Price = div.Descendants("div").FirstOrDefault().InnerText,
            //        //Link = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value,
            //        //ImageUrl = div.Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value
            //    };

            //    cars.Add(car);
            //}

            //cars.ForEach(i => Console.Write("{0}\t", i));

            //string combindedString2 = string.Join(",", cars);
            //string[] text2 =
            //    {
            //            combindedString2
            //     };

            //await File.WriteAllLinesAsync("WriteLines.txt", text2);
        } 



    }
}
