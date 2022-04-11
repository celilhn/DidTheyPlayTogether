using Xunit;
using Application.Interfaces;
using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Services.Tests
{
    public class PlayedSerieServiceTests
    {
        private readonly IPlayedSerieService playedSerieService;

        public PlayedSerieServiceTests(IPlayedSerieService playedSerieService)
        {
            this.playedSerieService = playedSerieService;
        }

        [Theory()]
        [InlineData(2)]
        public void GetPlayedSerie_IsNull_False1(int id)
        {
            PlayedSerieDto playedSerie = playedSerieService.GetPlayedSerie(id);
            Assert.False(playedSerie == null);
        }

        [Theory()]
        [InlineData(2, 3)]
        public void GetPlayedSerie_IsNull_False(int famousId, int filmId)
        {
            PlayedSerieDto playedSerie = playedSerieService.GetPlayedSerie(famousId, filmId);
            Assert.False(playedSerie == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetPlayedSeriesByFamousID_IsNull_False(int famousId)
        {
            List<PlayedSerieDto> playedSerie = playedSerieService.GetPlayedSeriesByFamousID(famousId);
            Assert.False(playedSerie == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetPlayedSeriesByFilmID_IsNull_False(int filmId)
        {
            List<PlayedSerieDto> playedSerie = playedSerieService.GetPlayedSeriesByFilmID(filmId);
            Assert.False(playedSerie == null); ;
        }
    }
}