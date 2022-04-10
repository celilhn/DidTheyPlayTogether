using Application.Interfaces;
using Application.Models;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static Domain.Constants.Constants;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MDbTvController : ControllerBase
    {
        private readonly ISerieService serieService;
        private readonly IMovieDbTvService movieDbTvService;
        private readonly IMapper mapper;
        public MDbTvController(ISerieService serieService, IMovieDbTvService movieDbTvService, IMapper mapper)
        {
            this.serieService = serieService;
            this.movieDbTvService = movieDbTvService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddTvsFromMovieDb()
        {
            List<PopularTv> popularTvs = null;
            SerieDto serie = null;
            int counterofAdded = 0;
            try
            {
                for (int i = 1; i < 501; i++)
                {
                    popularTvs = movieDbTvService.GetPopularTvs(i.ToString());
                    if (popularTvs != null)
                    {
                        foreach (PopularTv popularTv in popularTvs)
                        {
                            serie = serieService.GetSerie(popularTv.Name);
                            if (serie == null)
                            {
                                serie = serieService.GetSerieByOriginalName(popularTv.OriginalName);
                            }
                            if(serie != null)
                            {
                                serie = new SerieDto();
                                serie.Country = popularTv.OriginCountry[0];
                                serie.Description = popularTv.Overview;
                                serie.FirstEpisodeAirDate = Convert.ToInt32(popularTv.FirstAirDate.Substring(0, 4));
                                serie.Language = popularTv.OriginalLanguage;
                                serie.Name = popularTv.Name;
                                serie.OriginalName = popularTv.OriginalName;
                                serie.PosterPath = popularTv.PosterPath;
                                serie.SourceID = (int)SourceTypes.MovieDb;
                                serie = serieService.SaveSerie(serie);
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
            return Ok(counterofAdded + " Adet Tv Series Eklendi.");
        }
    }
}
