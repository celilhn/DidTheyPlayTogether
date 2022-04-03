using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AddFamouses
    {
        static public void GetHtml()
        {
            int counterofAdded = 0;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://tr.wikipedia.org/wiki/T%C3%BCrk_oyuncular_listesi");
            for (int i = 0; i < 28; i++)
            {
                Boolean isExist = true;
                string xPath = "//*[@id='mw-content-text']/div[1]/ul[" + (i + 1) + "]";
                HtmlNode ul = document.DocumentNode.SelectNodes(xPath).First();
                HtmlNode[] li = ul.SelectNodes("li").ToArray();
                foreach (HtmlNode liNode in li)
                {
                    //isExist = ControlisFamousExist((liNode.InnerText).ToString());
                    if (!isExist)
                    {
                        //AddFamous((liNode.InnerText).ToString());
                        counterofAdded++;
                    }
                }
            }
            Console.WriteLine(counterofAdded + " Adet kişi Eklendi.");
        }
    }
}
