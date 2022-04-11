using Infrastructure.Repositories;
using Xunit;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System;

namespace Infrastructure.Repositories.Tests
{
    public class PlayedFilmRepositoryTests
    {
        private readonly IPlayedFilmRepository playedFilmRepository;

        public PlayedFilmRepositoryTests(IPlayedFilmRepository playedFilmRepository)
        {
            this.playedFilmRepository = playedFilmRepository;
        }

        [Fact()]
        public void AddPlayedFilm_IsNull_False()
        {
            PlayedFilm playedFilm = new PlayedFilm();
            playedFilm.Character = "Test";
            playedFilm.ContributionID = 12;
            playedFilm.FamousID = 12;
            playedFilm.FilmID = 12;
            playedFilm.Status = 0;
            playedFilm.InsertionDate = DateTime.Now;
            playedFilm.UpdateDate = DateTime.Now;
            playedFilm = playedFilmRepository.AddPlayedFilm(playedFilm);
            Assert.False(playedFilm == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetPlayedFilm_IsNull_False(int id)
        {
            PlayedFilm playedFilm = playedFilmRepository.GetPlayedFilm(id);
            Assert.False(playedFilm == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetPlayedFilmByFilmID_IsNull_False(int filmID)
        {
            List<PlayedFilm> playedFilms = playedFilmRepository.GetPlayedFilmByFilmID(filmID);
            Assert.False(playedFilms == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetPlayedFilmsByFamousID_IsNull_False(int famousID)
        {
            List<PlayedFilm> playedFilms = playedFilmRepository.GetPlayedFilmsByFamousID(famousID);
            Assert.False(playedFilms == null);
        }

        [Fact()]
        public void UpdatePlayedFilm_IsNull_False()
        {
            PlayedFilm playedFilm = playedFilmRepository.GetPlayedFilm(10);
            playedFilm.UpdateDate = DateTime.Now;
            playedFilm = playedFilmRepository.UpdatePlayedFilm(playedFilm);
            Assert.False(playedFilm == null);
        }

        [Theory()]
        [InlineData(3,2)]
        public void GetPlayedFilm_IsNull_False1(int filmID, int famousID)
        {
            PlayedFilm playedFilm = playedFilmRepository.GetPlayedFilm(filmID, famousID);
            Assert.False(playedFilm == null);
        }
    }
}
