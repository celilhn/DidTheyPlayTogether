using Application.Interfaces;
using Application.Models;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static Domain.Constants.Constants;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MDbPeopleController : ControllerBase
    {
        private readonly IFamousService famousService;
        private readonly IFilmService filmService;
        private readonly IPlayedFilmService playedFilmService;
        private readonly IPlayedSerieService playedSerieService;
        private readonly IMovieDbPeopleService peopleService;
        public MDbPeopleController(IFamousService famousService, IFilmService filmService, IPlayedFilmService playedFilmService, IPlayedSerieService playedSerieService, IMovieDbPeopleService peopleService)
        {
            this.famousService = famousService;
            this.filmService = filmService;
            this.playedFilmService = playedFilmService;
            this.playedSerieService = playedSerieService;
            this.peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult AddPopularPeopleFromMovieDb()
        {
            List<People> people = null;
            FamousDto famous = null;
            PlayedFilmDto playedFilm = null;
            PlayedSerieDto playedSerie = null;
            FilmDto film = null;
            int counterofFamousAdded = 0;
            int counterofFilmAdded = 0;
            int counterofPlayedFilmAdded = 0;
            int counterofPlayedSerieAdded = 0;
            try
            {
                for (int i = 1; i < 500; i++)
                {
                    people = peopleService.GetPopularPeople(i.ToString());
                    foreach (People human in people)
                    {
                        famous = famousService.GetFamous(human.name);
                        if (famous == null)
                        {
                            famous = SaveFamaous(human);
                            counterofFamousAdded++;
                            foreach (KnownFor knowFor in human.known_for)
                            {
                                film = filmService.GetFilmByOriginalName(knowFor.original_title);
                                counterofFilmAdded++;
                                if (film == null)
                                {
                                    film = SaveFilm(knowFor);
                                }
                                if (knowFor.media_type == MediaTypes.movie.ToString())
                                {
                                    playedFilm = SavePlayedFilm(famous, film);
                                    counterofPlayedFilmAdded++;
                                }
                                else if(knowFor.media_type == MediaTypes.tv.ToString())
                                {
                                    playedSerie = SavePlayedSerie(famous, film);
                                    counterofPlayedSerieAdded++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(counterofFamousAdded + " Adet Ünlü, " + counterofFilmAdded + " Adet Film, " + counterofPlayedFilmAdded + " Adet PLayedFilm, " + counterofPlayedSerieAdded + " Adet PlayedSerie Eklendi.");
        }

        private FamousDto SaveFamaous(People human)
        {
            FamousDto famous = null;
            try
            {
                famous = new FamousDto();
                famous.Gender = (short)human.gender;
                famous.Name = human.name;
                famous.Popularity = human.popularity;
                famous.ProfilePath = human.profile_path;
                famous.SourceID = (int)SourceTypes.MovieDb;
                famous = famousService.SaveFamous(famous);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return famous;
        }

        private FilmDto SaveFilm(KnownFor knowFor)
        {
            FilmDto film = null;
            try
            {
                film = new FilmDto();
                film.Name = knowFor.name;
                film.OriginalName = knowFor.original_title;
                film.PosterPath = knowFor.poster_path;
                film.ReleaseDate = Convert.ToInt32(knowFor.release_date.Substring(0, 4));
                film.Country = "Other";
                film.Subject = knowFor.overview;
                film.SourceID = (int)SourceTypes.MovieDb;
                film = filmService.SaveFilm(film);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return film;
        }

        private PlayedFilmDto SavePlayedFilm(FamousDto famous, FilmDto film)
        {
            PlayedFilmDto playedFilm = null;
            try
            {
                playedFilm = new PlayedFilmDto();
                playedFilm.FamousID = famous.ID;
                playedFilm.FilmID = film.ID;
                playedFilm = playedFilmService.SavePlayedFilm(playedFilm);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return playedFilm;
        }

        private PlayedSerieDto SavePlayedSerie(FamousDto famous, FilmDto film)
        {
            PlayedSerieDto playedSerie = null;
            try
            {
                playedSerie = new PlayedSerieDto();
                playedSerie.FamousID = famous.ID;
                playedSerie.FilmID = film.ID;
                playedSerie = playedSerieService.SavePlayedSerie(playedSerie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return playedSerie;
        }
    }
}
