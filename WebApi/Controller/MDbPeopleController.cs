using Application.Interfaces;
using Application.Models;
using Application.ViewModels;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MDbPeopleController : ControllerBase
    {
        private readonly IFamousService famousService;
        private readonly IFilmService filmService;
        private readonly IPlayedFilmService playedFilmService;
        private readonly IMovieDbPeopleService peopleService;
        public MDbPeopleController(IFamousService famousService, IFilmService filmService, IPlayedFilmService playedFilmService, IMovieDbPeopleService peopleService)
        {
            this.famousService = famousService;
            this.filmService = filmService;
            this.playedFilmService = playedFilmService;
            this.peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult AddPopularPeopleFromMovieDb()
        {
            List<People> people = null;
            FamousDto famous = null;
            FilmDto film = null;
            PlayedFilmDto playedFilm = null;
            int counterofAdded = 0;
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
                            famous = new FamousDto();
                            famous.Gender = (short)human.gender;
                            famous.Name = human.name;
                            famous.Popularity = human.popularity;
                            famous.ProfilePath = human.profile_path;
                            famous = famousService.SaveFamous(famous);
                            foreach (KnownFor knowFor in human.known_for)
                            {
                                film = filmService.GetFilmByOriginalName(knowFor.original_title);
                                if(film == null)
                                {
                                    film = new FilmDto();
                                    film.Name = knowFor.name;
                                    film.OriginalName = knowFor.original_title;
                                    film.PosterPath = knowFor.poster_path;
                                    film.ReleaseDate = Convert.ToInt32(knowFor.release_date.Substring(0, 4));
                                    film.Country = "Other";
                                    film.Subject = knowFor.overview;
                                    film = filmService.SaveFilm(film);
                                }
                                playedFilm = new PlayedFilmDto();
                                playedFilm.FamousID = famous.ID;
                                playedFilm.FilmID = film.ID;
                                playedFilm = playedFilmService.SavePlayedFilm(playedFilm);
                                counterofAdded++;
                            }
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
