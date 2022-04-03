using Application.Interfaces;
using Application.ViewModels;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controller
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IFamousService famousService;
        private readonly ISerieService serieService;

        public ServicesController(IFamousService famousService, ISerieService serieService)
        {
            this.famousService = famousService;
            this.serieService = serieService;
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

        [HttpGet]
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

        [HttpGet]
        public IActionResult AddSeriesFromWikipedia()
        {
            SerieDto serie = null;
            HtmlWeb web = null;
            HtmlDocument document = null;
            try
            {
                int counterofAdded = 0;
                web = new HtmlWeb();
                document = web.Load("https://tr.wikipedia.org/wiki/T%C3%BCrk_dizileri_listesi");
                for (int i = 3; i < 22; i++)
                {
                    string xPath = "//*[@id='mw-content-text']/div[1]/table[" + i + "]";
                    HtmlNode table = document.DocumentNode.SelectNodes(xPath).First();
                    HtmlNode tbody = table.SelectNodes("tbody").First();
                    HtmlNode[] tr = tbody.SelectNodes("tr").ToArray();
                    int counter = 0;
                    int year = 0;
                    foreach (HtmlNode node in tr)
                    {
                        if(counter == 0)
                        {
                            HtmlNode th = node.SelectNodes("th").First();
                            year = (int)Convert.ToUInt32(th.InnerText.ToString());
                        }
                        else if (counter > 1)
                        {
                            HtmlNode[] td = node.SelectNodes("td").ToArray();
                            serie = serieService.GetSerie(td[0].InnerText.ToString());
                            if(serie == null)
                            {
                                serie = new SerieDto();
                                serie.Name = td[0].InnerText.ToString();
                                serie.Channel = td[4].InnerText.ToString();
                                serie.NumberofSeasons = (int)Convert.ToUInt32((td[2].InnerText).ToString());
                                serie.NumberofEpisodes = (int)Convert.ToUInt32((td[1].InnerText).ToString());
                                serie.FirstEpisodeAirDate = year;
                                serie.Siciation = td[3].InnerText.ToString();
                                serieService.SaveSerie(serie);
                                counterofAdded++;
                            }
                        }
                        counter++;
                    }
                }

            }
            catch (Exception)
            {
            }
            return Ok();
        }
    }
}
