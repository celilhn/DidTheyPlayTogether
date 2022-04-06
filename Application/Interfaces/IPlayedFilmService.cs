using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IPlayedFilmService
    {
        PlayedFilmDto GetPlayedFilm(int id);
        List<PlayedFilmDto> GetPlayedFilmsByFamousID(int famousId);
        List<PlayedFilmDto> GetPlayedFilmByFilmID(int famousId);
        PlayedFilmDto SavePlayedFilm(PlayedFilmDto playedFilm);
    }
}
