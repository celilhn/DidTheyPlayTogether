using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IPlayedSerieService
    {
        PlayedSerieDto GetPlayedSerie(int id);
        List<PlayedSerieDto> GetPlayedSeriesByFamousID(int famousId);
        List<PlayedSerieDto> GetPlayedSeriesByFilmID(int filmId);
        PlayedSerieDto SavePlayedSerie(PlayedSerieDto playedSerie);
    }
}
