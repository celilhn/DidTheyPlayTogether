using Application.Interfaces;
using Application.ViewModels;
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
        private readonly IFamousService famousService;

        public AddFamouses(IFamousService famousService)
        {
            this.famousService = famousService;
        }
        
        public void GetHtml()
        {
            FamousDto famous = null;
            try
            {
                int counterofAdded = 0;
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load("https://tr.wikipedia.org/wiki/T%C3%BCrk_oyuncular_listesi");
                for (int i = 0; i < 28; i++)
                {
                    string xPath = "//*[@id='mw-content-text']/div[1]/ul[" + (i + 1) + "]";
                    HtmlNode ul = document.DocumentNode.SelectNodes(xPath).First();
                    HtmlNode[] li = ul.SelectNodes("li").ToArray();
                    foreach (HtmlNode liNode in li)
                    {
                        famous = famousService.GetFamous((liNode.InnerText).ToString());
                        if (famous == null)
                        {
                            famous.Name = liNode.InnerText.ToString();
                            famous = famousService.SaveFamous(famous);
                            counterofAdded++;
                        }
                    }
                }
                Console.WriteLine(counterofAdded + " Adet kişi Eklendi.");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
