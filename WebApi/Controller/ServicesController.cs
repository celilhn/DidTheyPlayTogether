using Application.Interfaces;
using Application.ViewModels;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IFamousService famousService;

        public ServicesController(IFamousService famousService)
        {
            this.famousService = famousService;
        }


        [HttpGet]
        public IActionResult AddFamousNamesFromWikipedia()
        {
            FamousDto famous = null;
            HtmlWeb web = null;
            HtmlDocument document = null;
            try
            {
                int counterofAdded = 0;
                web = new HtmlWeb();
                document = web.Load("https://tr.wikipedia.org/wiki/T%C3%BCrk_oyuncular_listesi");
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
                HttpContext.Response.HttpContext.Items.Add("StatusCode", 1);
                HttpContext.Response.HttpContext.Items.Add("Message", counterofAdded + " Adet kişi Eklendi.");
            }
            catch (Exception)
            {
                HttpContext.Response.HttpContext.Items.Add("Message", "Kayıt Başarısız.");
                throw;
            }
            return Ok();
        }

        public IActionResult AddFamousInfoFromWikipedia()
        {
            List<FamousDto> famouses = null;
            HtmlWeb web = null;
            HtmlDocument document = null;
            try
            {
                famouses = famousService.GetFamouses();
                foreach (FamousDto famous in famouses)
                {
                    int counterofAdded = 0;
                    web = new HtmlWeb();
                    document = web.Load("https://tr.wikipedia.org/wiki/K%C4%B1van%C3%A7_Tatl%C4%B1tu%C4%9F");
                }
                
            }
            catch (Exception)
            {
            }
            return Ok();
        }
    }
}
