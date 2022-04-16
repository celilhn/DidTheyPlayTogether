using Application.Interfaces;
using Application.Utilities;
using Application.ViewModels;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Infrastructure.GoogleServices
{
    public class PexelsModel
    {
        public string PhotoOwnerName { get; set; }
        public string PhotoLink { get; set; }
    }

    public class KimdirKimService : IKimdirKimService
    {
        private HtmlWeb web;
        private HtmlDocument document;
        private readonly string URL = AppUtilities.GetConfigurationValue("KimKimdirUrl");
        private readonly IFamousService famousService;
        private readonly IFilmService filmService;
        private readonly ISerieService serieService;
        private readonly IPlayedSerieService playedSerieService;
        private readonly IPlayedFilmService playedFilmService;
        public KimdirKimService(IFamousService famousService, IFilmService filmService, ISerieService serieService
            , IPlayedSerieService playedSerieService, IPlayedFilmService playedFilmService)
        {
            this.web = new HtmlWeb();
            this.famousService = famousService;
            this.filmService = filmService;
            this.serieService = serieService;
            this.playedSerieService = playedSerieService;
            this.playedFilmService = playedFilmService;
        }

        /// <summary>
        /// In this function, I pull only wikipedia famous's information(film,movies)
        /// </summary>
        /// <returns></returns>
        public void GetFamousInformations()
        {
            List<FamousDto> famouses = null;
            int counterofAdded = 0;
            try
            {
                famouses = famousService.GetFamousFromMovieDb();
                foreach (FamousDto famous in famouses)
                {
                    HtmlNodeCollection filmsMovies = FilmsAndMoviesRequest(famous.Name);
                    foreach (var item in filmsMovies)
                    {
                        string name = SetName(item.InnerText);
                        if (name.Contains("Film"))
                        {
                            FilmDto film = filmService.GetFilm(name);
                            if(film != null)
                            {
                                PlayedFilmDto playedFilm = new PlayedFilmDto();
                                playedFilm.FamousID = famous.ID;
                                playedFilm.FilmID = film.ID;
                                playedFilmService.SavePlayedFilm(playedFilm);
                            }
                            // Filme bak var mı
                            // Varsa playedfilme ekle
                        }
                        else
                        {
                            SerieDto serie = serieService.GetSerie(name);
                            if (serie != null)
                            {
                                PlayedSerieDto playedSerie = new PlayedSerieDto();
                                playedSerie.FamousID = famous.ID;
                                playedSerie.FilmID = serie.ID;
                                playedSerieService.SavePlayedSerie(playedSerie);
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private HtmlNodeCollection FilmsAndMoviesRequest(string name)
        {
            HtmlNodeCollection filmsMovies;
            try
            {
                string Url = SetUrl(name);
                Uri url = new Uri(Url);
                WebClient client = new WebClient();
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); 
                filmsMovies = document.DocumentNode.SelectNodes("//*[@id='the-post']/div[3]/div[2]/p[11]/text()");
            }
            catch (Exception)
            {
                throw;
            }
            return filmsMovies;
        }

        private string SetUrl(string name)
        {
            string Url = "";
            string[] nameParts;
            try
            {
                nameParts = name.Split(' ');
                for (int i = 0; i < nameParts.Length; i++)
                {
                    Url += nameParts[i] + "-";
                    if (i == nameParts.Length - 1)
                    {
                        Url += "kimdir.html";
                    }
                }
                Url = URL + Url;
            }
            catch (Exception)
            {
                throw;
            }
            return Url;
        }

        private string SetName(string innerText)
        {
            string name = innerText;
            string namer = name.Replace("&#8217;", "'");
            string[] names = namer.Split(";");
            return names[1];
        }

    }
}
