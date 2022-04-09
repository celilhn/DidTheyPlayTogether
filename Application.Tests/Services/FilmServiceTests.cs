using Xunit;
using Application.Interfaces;
using Application.ViewModels;

namespace Application.Services.Tests
{
    public class FilmServiceTests
    {
        private readonly IFilmService filmService;

        public FilmServiceTests(IFilmService filmService)
        {
            this.filmService = filmService;
        }

        [Theory()]
        [InlineData(2)]
        public void GetFilm_IsNull_False(int id)
        {
            FilmDto film = filmService.GetFilm(id);
            Assert.False(film == null);
        }

        [Theory()]
        [InlineData("Ant")]
        public void GetFilm_IsNull_False1(string name)
        {
            FilmDto film = filmService.GetFilm(name);
            Assert.False(film == null);
        }

        [Theory()]
        [InlineData("Ant")]
        public void GetFilmByOriginalName_IsNull_False(string originalName)
        {
            FilmDto film = filmService.GetFilmByOriginalName(originalName);
            Assert.False(film == null);
        }
    }
}