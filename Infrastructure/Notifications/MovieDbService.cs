using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace Infrastructure.Notifications
{
    public class MovieDbService : IMovieDbService
    {
        private readonly string apiKey = AppUtilities.GetConfigurationValue("MovieApiKey");
        private readonly string URL = AppUtilities.GetConfigurationValue("MovieUrl");
        private readonly static string resource = "/movie/popular";
        private readonly IHttpUtilities httpUtilities;
        public MovieDbService(IHttpUtilities httpUtilities)
        {
            this.httpUtilities = httpUtilities;
        }

        public List<Movies> GetPopularMovies(string page = "")
        {
            PopularMovie popularMovies = null;
            string endpoint = URL + resource + "?api_key=" + apiKey;
            if (page != "")
            {
                endpoint = endpoint + "&page=" + page + "";
            }
            string response = httpUtilities.ExecuteHttpRequest(endpoint);
            if (response != "")
            {
                popularMovies = JsonSerializer.Deserialize<PopularMovie>(response);
            }
            return popularMovies.results;
        }

        public List<People> GetPopularPeople(string page)
        {
            string url = URL + "/person/popular?api_key=3a1945ec77e5a87c3deccf7477584891&language=tr";
            List<People> people = null;
            PopularPeople popularPeople = null;
            try
            {
                if (page != "")
                {
                    url = url + "&page=" + page + "";
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
                            //popularPeople = JsonConvert.DeserializeObject<PopularPeople>(PopularMoviesAsJson);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (popularPeople == null)
            {
                return people;
            }
            else
            {
                return popularPeople.results;
            }
        }
    }
}
