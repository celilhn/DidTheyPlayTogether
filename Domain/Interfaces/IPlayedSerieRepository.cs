using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPlayedSerieRepository
    {
        PlayedSerie GetPlayedSerie(int id);
        PlayedSerie GetPlayedSerie(int famousId, int filmId);
        List<PlayedSerie> GetPlayedSeriesByFamousID(int famousId);
        List<PlayedSerie> GetPlayedSeriesByFilmID(int filmId);
        PlayedSerie AddPlayedSerie(PlayedSerie playedSerie);
        PlayedSerie UpdatePlayedSerie(PlayedSerie playedSerie);
    }
}
