using Xunit;
using Domain.Interfaces;
using Domain.Models;
using System;

namespace Infrastructure.Repositories.Tests
{
    public class FilmRepositoryTests
    {
        private readonly IFilmRepository filmRepository;

        public FilmRepositoryTests(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }

        [Fact()]
        public void AddFilm_IsNull_False()
        {
            Film film = new Film();
            film.Country = "Test";
            film.Director = "Test";
            film.FilmCategoryID = 1;
            film.Name = "Test";
            film.Note = "Test";
            film.Subject = "Test";
            film.Status = 0;
            film = filmRepository.AddFilm(film);
            Assert.False(film == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetFilm_IsNull_False(int id)
        {
            Film film = filmRepository.GetFilm(id);
            Assert.False(film == null);
        }

        [Theory()]
        [InlineData("Ant")]
        public void GetFilm_IsNull_False1(string name)
        {
            Film film = filmRepository.GetFilm(name);
            Assert.False(film == null);
        }

        [Theory()]
        [InlineData("Ant")]
        public void GetFilmByOriginalName_IsNull_False(string originalName)
        {
            Film film = filmRepository.GetFilmByOriginalName(originalName);
            Assert.False(film == null);
        }

        [Fact()]
        public void UpdateFilm_IsNull_False()
        {
            Film film = filmRepository.GetFilm(11);
            film.UpdateDate = DateTime.Now;
            Assert.False(film == null);
        }
    }
}