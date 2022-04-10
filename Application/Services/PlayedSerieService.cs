using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlayedSerieService : IPlayedSerieService
    {
        private readonly IPlayedSerieRepository playedSerieRepository;
        private readonly IMapper mapper;

        public PlayedSerieService(IPlayedSerieRepository playedSerieRepository, IMapper mapper)
        {
            this.playedSerieRepository = playedSerieRepository;
            this.mapper = mapper;
        }

        public PlayedSerieDto GetPlayedSerie(int id)
        {
            return mapper.Map<PlayedSerieDto>(playedSerieRepository.GetPlayedSerie(id));
        }

        public List<PlayedSerieDto> GetPlayedSeriesByFamousID(int famousId)
        {
            return mapper.Map<List<PlayedSerieDto>>(playedSerieRepository.GetPlayedSeriesByFamousID(famousId));
        }

        public List<PlayedSerieDto> GetPlayedSeriesByFilmID(int filmId)
        {
            return mapper.Map<List<PlayedSerieDto>>(playedSerieRepository.GetPlayedSeriesByFilmID(filmId));
        }

        public PlayedSerieDto SavePlayedSerie(PlayedSerieDto playedSerie)
        {
            if (playedSerie.ID > 0)
            {
                PlayedSerie playedSerieTemp = playedSerieRepository.GetPlayedSerie(playedSerie.ID);
                playedSerieTemp.Character = playedSerie.Character;
                playedSerieTemp.FamousID = playedSerie.FamousID;
                playedSerieTemp.FilmID = playedSerie.FilmID;
                playedSerieTemp.Year = playedSerie.Year;
                playedSerieTemp = playedSerieRepository.UpdatePlayedSerie(playedSerieTemp);
                playedSerie = mapper.Map<PlayedSerieDto>(playedSerieTemp);
            }
            else
            {
                playedSerie = mapper.Map<PlayedSerieDto>(playedSerieRepository.AddPlayedSerie(mapper.Map<PlayedSerie>(playedSerie)));
            }
            return playedSerie;
        }
    }
}
