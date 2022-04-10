using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPlayedSerieRepository
    {
        PlayedSerie GetPlayedSerie(int id);
        List<PlayedSerie> GetPlayedSeriesByFamousID(int famousId);
        List<PlayedSerie> GetPlayedSeriesByFilmID(int filmId);
        PlayedSerie AddPlayedSerie(PlayedSerie playedSerie);
        PlayedSerie UpdatePlayedSerie(PlayedSerie playedSerie);
    }
}
