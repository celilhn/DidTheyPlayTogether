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
    public class WikipediaController : ControllerBase
    {
        private readonly IFamousService famousService;
        private readonly ISerieService serieService;
        private HtmlWeb web;
        private HtmlDocument document;
        public WikipediaController(IFamousService famousService, ISerieService serieService)
        {
            this.famousService = famousService;
            this.serieService = serieService;
            this.web = new HtmlWeb();
        }

        [HttpGet]
        public IActionResult AddFamousNamesFromWikipedia()
        {
            FamousDto famous = null;
            int counterofAdded = 0;
            try
            {
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
                            famous.SourceID = 0;
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
            return Ok(counterofAdded + " Adet kişi Eklendi.");
        }

        [HttpGet]
        public IActionResult AddFamousInfoFromWikipedia()
        {
            List<FamousDto> famouses = null;
            try
            {
                famouses = famousService.GetFamouses();
                foreach (FamousDto famous in famouses)
                {
                    //int counterofAdded = 0;
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
            int counterofAdded = 0;
            try
            {
                document = web.Load("https://tr.wikipedia.org/wiki/T%C3%BCrk_dizileri_listesi");
                for (int i = 3; i < 22; i++)
                {
                    string xPath = "//*[@id='mw-content-text']/div[1]/table[" + i + "]";
                    HtmlNode table = document.DocumentNode.SelectNodes(xPath).First();
                    HtmlNode tbody = table.SelectNodes("tbody").First();
                    HtmlNode[] tr = tbody.SelectNodes("tr").ToArray();
                    int counter = 0;
                    int firstEpisodeAirDate = 0;
                    int lastEpisodeAirDate = 0;
                    foreach (HtmlNode node in tr)
                    {
                        if (counter == 0)
                        {
                            HtmlNode th = node.SelectNodes("th").First();
                            string yearInfo = th.InnerText.ToString();
                            if (yearInfo.Count() < 7)
                            {
                                firstEpisodeAirDate = (int)Convert.ToUInt32(yearInfo);
                                lastEpisodeAirDate = (int)Convert.ToUInt32(yearInfo);
                            }
                            else
                            {
                                string[] years = yearInfo.Split("-");
                                firstEpisodeAirDate = (int)Convert.ToUInt32(years[0]);
                                lastEpisodeAirDate = (int)Convert.ToUInt32(years[1]);
                            }
                        }
                        else if (counter > 1)
                        {
                            HtmlNode[] td = node.SelectNodes("td").ToArray();
                            serie = serieService.GetSerie(td[0].InnerText.ToString());
                            if (serie == null)
                            {
                                serie = new SerieDto();
                                serie.Name = td[0].InnerText.ToString();
                                serie.Channel = td[4].InnerText.ToString();
                                string NumberofSeasons = (td[2].InnerText.ToString()).Replace("\n", string.Empty);
                                string NumberofEpisodes = (td[1].InnerText.ToString()).Replace("\n", string.Empty);
                                if (NumberofSeasons != "-" && NumberofSeasons != "" && NumberofSeasons.Count() < 3)
                                {
                                    serie.NumberofSeasons = (int)Convert.ToUInt32(NumberofSeasons);
                                }
                                if (NumberofEpisodes != "-" && NumberofEpisodes != "" && NumberofEpisodes.Count() < 4)
                                {
                                    serie.NumberofEpisodes = (int)Convert.ToUInt32(NumberofEpisodes);
                                }
                                serie.FirstEpisodeAirDate = firstEpisodeAirDate;
                                serie.LastEpisodeAirDate = lastEpisodeAirDate;
                                serie.Siciation = td[3].InnerText.ToString();
                                serieService.SaveSerie(serie);
                                counterofAdded++;
                            }
                        }
                        counter++;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(counterofAdded + " Adet Eklendi.");
        }
    }
}
