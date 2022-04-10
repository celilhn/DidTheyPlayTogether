using Xunit;
using Application.Interfaces;
using System.Collections.Generic;
using Application.Models;

namespace Infrastructure.MovieDbServices.Tests
{
    public class MovieDbTvServiceTests
    {
        private readonly IMovieDbTvService movieDbTvService;

        public MovieDbTvServiceTests(IMovieDbTvService movieDbTvService)
        {
            this.movieDbTvService = movieDbTvService;
        }

        [Theory()]
        [InlineData("1")]
        public void GetPopularTvs_IsNull_False(string page = "")
        {
            List<PopularTv> popularTvs = movieDbTvService.GetPopularTvs(page);
            Assert.False(popularTvs == null);
        }
    }
}