using Infrastructure.Repositories;
using Xunit;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.Models;

namespace Infrastructure.Repositories.Tests
{
    public class PlayedSerieRepositoryTests
    {
        private readonly IPlayedSerieRepository playedSerieRepository;

        public PlayedSerieRepositoryTests(IPlayedSerieRepository playedSerieRepository)
        {
            this.playedSerieRepository = playedSerieRepository;
        }

        [Fact()]
        public void AddPlayedSerie_IsNull_False()
        {
            PlayedSerie playedSerie = new PlayedSerie();
            playedSerie.Character = "Test";
            playedSerie.FamousID = 12;
            playedSerie.FilmID = 23;
            playedSerie.Status = 0;
            playedSerie = playedSerieRepository.AddPlayedSerie(playedSerie);
            Assert.False(playedSerie == null);
        }

        [Theory()]
        [InlineData(3, 2)]
        public void GetPlayedSerie_IsNull_False(int famousId, int filmId)
        {
            PlayedSerie playedSerie = playedSerieRepository.GetPlayedSerie(famousId, filmId);
            Assert.False(playedSerie == null);
        }

        [Theory()]
        [InlineData(3)]
        public void GetPlayedSerie_IsNull_False1(int id)
        {
            PlayedSerie playedSerie = playedSerieRepository.GetPlayedSerie(id);
            Assert.False(playedSerie == null);
        }

        [Theory()]
        [InlineData(3)]
        public void GetPlayedSeriesByFamousID_IsNull_False(int famousId)
        {
            List<PlayedSerie> playedSerie = playedSerieRepository.GetPlayedSeriesByFamousID(famousId);
            Assert.False(playedSerie == null);
        }

        [Theory()]
        [InlineData(3)]
        public void GetPlayedSeriesByFilmID_IsNull_False(int filmId)
        {
            List<PlayedSerie> playedSerie = playedSerieRepository.GetPlayedSeriesByFilmID(filmId);
            Assert.False(playedSerie == null);
        }

        [Fact()]
        public void UpdatePlayedSerie_IsNull_False()
        {
            PlayedSerie playedSerie = playedSerieRepository.GetPlayedSerie(12, 23);
            playedSerie.Year = "2345";
            playedSerie = playedSerieRepository.UpdatePlayedSerie(playedSerie);
            Assert.True(playedSerie == null);
        }
    }
}