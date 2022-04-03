using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;

namespace Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository serieRepository;
        private readonly IMapper mapper;

        public SerieService(ISerieRepository serieRepository, IMapper mapper)
        {
            this.serieRepository = serieRepository;
            this.mapper = mapper;
        }

        public SerieDto GetSerie(int ID)
        {
            return mapper.Map<SerieDto>(serieRepository.GetSerie(ID));
        }

        public SerieDto GetSerie(string name)
        {
            return mapper.Map<SerieDto>(serieRepository.GetSerie(name));
        }

        public SerieDto SaveSerie(SerieDto serie)
        {
            if (serie.ID > 0)
            {
                Serie serieTemp = serieRepository.GetSerie(serie.ID);
                serieTemp.Name = serie.Name;
                serieTemp.Channel = serie.Channel;
                serieTemp.FirstEpisodeAirDate = serie.FirstEpisodeAirDate;
                serieTemp.LastEpisodeAirDate = serie.LastEpisodeAirDate;
                serieTemp.NumberofEpisodes = serie.NumberofEpisodes;
                serieTemp.NumberofSeasons = serie.NumberofSeasons;
                serieTemp.Producer = serie.Producer;
                serieTemp = serieRepository.UpdateSerie(serieTemp);
                serie = mapper.Map<SerieDto>(serieTemp);
            }
            else
            {
                serie = mapper.Map<SerieDto>(serieRepository.AddSerie(mapper.Map<Serie>(serie)));
            }
            return serie;
        }
    }
}
