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
    public class PlayedFilmService : IPlayedFilmService
    {
        private readonly IPlayedFilmRepository playedFilmRepository;
        private readonly IMapper mapper;

        public PlayedFilmService(IPlayedFilmRepository playedFilmRepository, IMapper mapper)
        {
            this.playedFilmRepository = playedFilmRepository;
            this.mapper = mapper;
        }

        public PlayedFilmDto GetPlayedFilm(int id)
        {
            return mapper.Map<PlayedFilmDto>(playedFilmRepository.GetPlayedFilm(id));
        }

        public List<PlayedFilmDto> GetPlayedFilmByFilmID(int famousId)
        {
            return mapper.Map<List<PlayedFilmDto>>(playedFilmRepository.GetPlayedFilmByFilmID(famousId));
        }

        public List<PlayedFilmDto> GetPlayedFilmsByFamousID(int famousId)
        {
            return mapper.Map<List<PlayedFilmDto>>(playedFilmRepository.GetPlayedFilmsByFamousID(famousId));
        }

        public PlayedFilmDto SavePlayedFilm(PlayedFilmDto playedFilm)
        {
            if (playedFilm.ID > 0)
            {
                PlayedFilm playedFilmTemp = playedFilmRepository.GetPlayedFilm(playedFilm.ID);
                playedFilmTemp.Character = playedFilm.Character;
                playedFilmTemp.ContributionID = playedFilm.ContributionID;
                playedFilmTemp.FamousID = playedFilm.FamousID;
                playedFilmTemp.FilmID = playedFilm.FilmID;
                playedFilmTemp.Year = playedFilm.Year;
                playedFilmTemp = playedFilmRepository.UpdatePlayedFilm(playedFilmTemp);
                playedFilm = mapper.Map<PlayedFilmDto>(playedFilmTemp);
            }
            else
            {
                playedFilm = mapper.Map<PlayedFilmDto>(playedFilmRepository.AddPlayedFilm(mapper.Map<PlayedFilm>(playedFilm)));
            }
            return playedFilm;
        }
    }
}
