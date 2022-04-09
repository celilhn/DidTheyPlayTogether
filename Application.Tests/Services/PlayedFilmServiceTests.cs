using Xunit;
using Application.Interfaces;
using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Services.Tests
{
    public class PlayedFilmServiceTests
    {
        private readonly IPlayedFilmService playedFilmService;

        public PlayedFilmServiceTests(IPlayedFilmService playedFilmService)
        {
            this.playedFilmService = playedFilmService;
        }

        [Theory()]
        [InlineData(2)]
        public void GetPlayedFilm_IsNull_False(int id)
        {
            PlayedFilmDto playedFilm = playedFilmService.GetPlayedFilm(id);
            Assert.False(playedFilm == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetPlayedFilmByFilmID_IsNull_False(int filmId)
        {
            List<PlayedFilmDto> playedFilm = playedFilmService.GetPlayedFilmByFilmID(filmId);
            Assert.False(playedFilm == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetPlayedFilmsByFamousID_IsNull_False(int famousId)
        {
            List<PlayedFilmDto> playedFilm = playedFilmService.GetPlayedFilmsByFamousID(famousId);
            Assert.False(playedFilm == null);
        }
    }
}