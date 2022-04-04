using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;

namespace Application.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository filmRepository;
        private readonly IMapper mapper;

        public FilmService(IFilmRepository filmRepository, IMapper mapper)
        {
            this.filmRepository = filmRepository;
            this.mapper = mapper;
        }

        public FilmDto GetFilm(int id)
        {
            return mapper.Map<FilmDto>(filmRepository.GetFilm(id));
        }

        public FilmDto GetFilm(string name)
        {
            return mapper.Map<FilmDto>(filmRepository.GetFilm(name));
        }

        public FilmDto SaveFilm(FilmDto film)
        {
            if (film.ID > 0)
            {
                Film filmTemp = filmRepository.GetFilm(film.ID);
                filmTemp.Name = film.Name;
                filmTemp.Note = film.Note;
                filmTemp.Producer = film.Producer;
                filmTemp.Subject = film.Subject;
                filmTemp = filmRepository.UpdateFilm(filmTemp);
                film = mapper.Map<FilmDto>(filmTemp);
            }
            else
            {
                film = mapper.Map<FilmDto>(filmRepository.AddFilm(mapper.Map<Film>(film)));
            }
            return film;
        }
    }
}
