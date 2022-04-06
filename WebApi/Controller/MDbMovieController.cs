using Application.Interfaces;
using Application.Models;
using Application.ViewModels;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MDbMovieController : ControllerBase
    {
        private readonly IFilmService filmService;
        private readonly IMovieDbMovieService movieDbService;
        public MDbMovieController(IFilmService filmService, IMovieDbMovieService movieDbService)
        {
            this.filmService = filmService;
            this.movieDbService = movieDbService;
        }

        [HttpGet]
        public IActionResult AddPopularFilmsFromMovieDb()
        {
            List<Movies> movies = null;
            FilmDto film = null;
            int counterofAdded = 0;
            try
            {
                for (int i = 1; i < 500; i++)
                {
                    movies = movieDbService.GetPopularMovies(i.ToString());
                    foreach (Movies movie in movies)
                    {
                        film = filmService.GetFilm(movie.title);
                        if (film == null)
                        {
                            film = filmService.GetFilm(movie.original_title);
                        }
                        if (film == null)
                        {
                            film = new FilmDto();
                            film.Country = "Other";
                            film.Name = movie.title;
                            film.OriginalName = movie.original_title;
                            film.PosterPath = movie.poster_path;
                            if (movie.release_date != null)
                            {
                                if (movie.release_date.Count() > 3)
                                {
                                    film.ReleaseDate = Convert.ToInt32(movie.release_date.Substring(0, 4));
                                }
                            }
                            film.Subject = movie.overview;
                            film = filmService.SaveFilm(film);
                            counterofAdded++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(counterofAdded + " Adet Eklendi.");
        }
    }
}
