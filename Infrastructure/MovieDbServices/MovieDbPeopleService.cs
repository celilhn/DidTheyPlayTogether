using Application.Interfaces;
using Application.Models;
using Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Infrastructure.MovieDbServices
{
    public class MovieDbPeopleService : IMovieDbPeopleService
    {
        private readonly string apiKey = AppUtilities.GetConfigurationValue("MovieApiKey");
        private readonly string URL = AppUtilities.GetConfigurationValue("MovieUrl");
        private readonly static string resource = "/person/popular";
        private readonly IHttpUtilities httpUtilities;
        public MovieDbPeopleService(IHttpUtilities httpUtilities)
        {
            this.httpUtilities = httpUtilities;
        }

        public List<People> GetPopularPeople(string page = "")
        {
            List<People> people = null;
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
                    people = JsonSerializer.Deserialize<PopularPeople>(response).results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return people;
        }

    }
}
