using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Infrastructure.MovieDbServices
{
    public class MovieDbMovieService : IMovieDbMovieService
    {
        private readonly string apiKey = AppUtilities.GetConfigurationValue("MovieApiKey");
        private readonly string URL = AppUtilities.GetConfigurationValue("MovieUrl");
        private readonly static string resource = "/movie";
        private readonly IHttpUtilities httpUtilities;
        public MovieDbMovieService(IHttpUtilities httpUtilities)
        {
            this.httpUtilities = httpUtilities;
        }

        public List<Movies> GetPopularMovies(string page = "")
        {
            List<Movies> movies = null;
            try
            {
                string endpoint = URL + resource + "/popular?api_key=" + apiKey;
                if (page != "")
                {
                    endpoint = endpoint + "&page=" + page + "";
                }
                string response = httpUtilities.ExecuteHttpRequest(endpoint);
                if (response != "")
                {
                    movies = JsonSerializer.Deserialize<PopularMovie>(response).results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return movies;
        }

        public List<Movies> GetNowPlayingMovies(string page = "")
        {
            List<Movies> movies = null;
            try
            {
                string endpoint = URL + resource + "/now_playing?api_key=" + apiKey;
                if (page != "")
                {
                    endpoint = endpoint + "&page=" + page + "";
                }
                string response = httpUtilities.ExecuteHttpRequest(endpoint);
                if (response != "")
                {
                    movies = JsonSerializer.Deserialize<PopularMovie>(response).results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return movies;
        }

    }
}
