using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPlayedFilmRepository
    {
        PlayedFilm GetPlayedFilm(int id);
        PlayedFilm GetPlayedFilm(int filmID, int famousID);
        List<PlayedFilm> GetPlayedFilmsByFamousID(int famousId);
        List<PlayedFilm> GetPlayedFilmByFilmID(int filmId);
        PlayedFilm AddPlayedFilm(PlayedFilm playedFilm);
        PlayedFilm UpdatePlayedFilm(PlayedFilm playedFilm);
    }
}
