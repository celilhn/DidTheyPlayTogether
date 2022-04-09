using Xunit;
using System.Collections.Generic;
using Application.Interfaces;
using Application.Models;

namespace Infrastructure.MovieDbServices.Tests
{
    public class MovieDbMovieServiceTests
    {
        private readonly IMovieDbMovieService movieDbMovieService;

        public MovieDbMovieServiceTests(IMovieDbMovieService movieDbMovieService)
        {
            this.movieDbMovieService = movieDbMovieService;
        }

        [Theory()]
        [InlineData("1")]
        public void GetPopularMovies_IsNull_False(string page = "")
        {
            List<Movies> movies = movieDbMovieService.GetPopularMovies(page);
            Assert.False(movies == null);
        }

        [Theory()]
        [InlineData("1")]
        public void GetNowPlayingMovies_IsNull_False(string page = "")
        {
            List<Movies> movies = movieDbMovieService.GetNowPlayingMovies(page);
            Assert.False(movies == null);
        }
    }
}