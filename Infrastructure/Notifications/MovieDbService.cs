using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Notifications
{
    public class MovieDbService : IMovieDbService
    {
        private const string URL = "https://api.themoviedb.org/3/movie";
        private readonly string apiKey = AppUtilities.GetConfigurationValue("MovieApiKey");

        public List<Movies> GetPopulars(string page = "")
        {
            string url = URL + "/popular?api_key=3a1945ec77e5a87c3deccf7477584891&language=tr";
            List<Movies> movies = null;
            PopularMovie popularMovies = null;
            try
            {
                if (page != "")
                {
                    url = url + "&page=458";
                }
                var webRequest = WebRequest.Create(url) as HttpWebRequest;
                if (webRequest != null)
                {
                    webRequest.ContentType = "application/json";
                    webRequest.UserAgent = "Nothing";

                    using (var s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (var sr = new StreamReader(s))
                        {
                            var PopularMoviesAsJson = sr.ReadToEnd();
                            popularMovies = JsonConvert.DeserializeObject<PopularMovie>(PopularMoviesAsJson);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            if(popularMovies == null)
            {
                return movies;
            }
            else
            {
                return popularMovies.results;
            }
        }
    }
}
