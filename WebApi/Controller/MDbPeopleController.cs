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
        private readonly IMovieDbPeopleService peopleService;
        public MDbPeopleController(IFamousService famousService, IMovieDbPeopleService peopleService)
        {
            this.famousService = famousService;
            this.peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult AddPopularPeopleFromMovieDb()
        {
            List<People> people = null;
            FamousDto famous = null;
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
                            foreach (KnownFor knowFor in human.known_for)
                            {
                                // played filme ekleme yapacak
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
            return Ok();
        }
    }
}
