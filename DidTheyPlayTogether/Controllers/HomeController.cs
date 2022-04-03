using Application.Interfaces;
using Application.ViewModels;
using DidTheyPlayTogether.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DidTheyPlayTogether.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFamousService famousService;

        public HomeController(ILogger<HomeController> logger, IFamousService famousService)
        {
            this.famousService = famousService;
        }

        public IActionResult Index()
        {
            GetHtml();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                            famous = new FamousDto();
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
