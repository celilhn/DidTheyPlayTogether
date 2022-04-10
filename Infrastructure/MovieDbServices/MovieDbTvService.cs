using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Infrastructure.MovieDbServices
{
    public class MovieDbTvService : IMovieDbTvService
    {
        private readonly string apiKey = AppUtilities.GetConfigurationValue("MovieApiKey");
        private readonly string URL = AppUtilities.GetConfigurationValue("MovieUrl");
        private readonly static string resource = "/person/popular";
        private readonly IHttpUtilities httpUtilities;
        public MovieDbTvService(IHttpUtilities httpUtilities)
        {
            this.httpUtilities = httpUtilities;
        }

        public List<PopularTv> GetPopularTvs(string page = "")
        {
            List<PopularTv> popularTvs = null;
            try
            {
                string endpoint = URL + resource + "?api_key=" + apiKey;
                if (page != "")
                {
                    endpoint = endpoint + "&page=" + page + "";
                }
                string response = httpUtilities.ExecuteHttpRequest(endpoint);
                if (response != "")
                {
                    popularTvs = JsonSerializer.Deserialize<Result>(response).Results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return popularTvs;
        }
    }
}
