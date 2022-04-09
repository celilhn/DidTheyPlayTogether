using Xunit;
using System.Collections.Generic;
using Application.Interfaces;
using Application.Models;

namespace Infrastructure.MovieDbServices.Tests
{
    public class MovieDbPeopleServiceTests
    {
        private readonly IMovieDbPeopleService movieDbPeopleService;

        public MovieDbPeopleServiceTests(IMovieDbPeopleService movieDbPeopleService)
        {
            this.movieDbPeopleService = movieDbPeopleService;
        }

        [Theory()]
        [InlineData("1")]
        public void GetPopularPeople_IsNull_False(string page = "")
        {
            List<People> movies = movieDbPeopleService.GetPopularPeople(page);
            Assert.False(movies == null);
        }
    }
}