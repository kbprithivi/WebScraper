using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    class DataScrap
    {
        //string Link1 = "";
        string Link1 { get; set; }
        // class used to get the link.
        public void DataLink(string link1)
        {
            Link1 = link1;
        }
        public List<string> Scrapdata()
        {
            
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(Link1);
            // Scraping the data using particular nodes.
            var title = doc.DocumentNode.SelectNodes("//a[@class ='s-item__link']").ToList();
            var subtitle = doc.DocumentNode.SelectSingleNode("//*[@id='srp-river-results']/ul/li[1]/div/div[2]/div[3]").InnerText;
            var link = doc.DocumentNode.SelectSingleNode("//a[@class ='s-item__link']").GetAttributeValue("href", "default");
            var image = doc.DocumentNode.SelectSingleNode("//*[@id='srp-river-results']/ul/li[1]/div/div[1]/div/a[1]/div/img").GetAttributeValue("src", "Default");
            var review = doc.DocumentNode.SelectSingleNode("//*[@class='x-star-rating']/span");
            var price = doc.DocumentNode.SelectSingleNode("//*[@class='s-item__price']");
            //var est = doc.DocumentNode.SelectSingleNode("//*[@id='srp-river-results']/ul/li[1]/div/div[2]/div[5]/span[2]/span/span").InnerText;
            // var est = doc.DocumentNode.SelectSingleNode("//*[@id='srp - river - results']/ul/li[1]/div/div[2]/div[5]/span[2]/span").InnerText;
            //var est = doc.DocumentNode.SelectSingleNode("//*[@id='srp-river-results']/ul/li[1]/div/div[2]/div[4]/span[2]/span/span").InnerText;
            var est = doc.DocumentNode.SelectSingleNode("//*[@id='srp-river-results']/ul/li[1]/div/div[2]/div[4]/span/span").InnerText;
            // List to store the scraped data.
            List<string> scrap = new List<string>();

           //Adding Scraped data to the List...
            scrap.Add(title[0].InnerText);
            scrap.Add(subtitle);
            scrap.Add(link);
            scrap.Add(image);
            scrap.Add(review.InnerText);
            scrap.Add(price.InnerText);
            scrap.Add(est);
            return scrap;
        }
    }
}
