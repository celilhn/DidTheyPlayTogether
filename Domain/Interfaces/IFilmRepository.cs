using Domain.Models;

namespace Domain.Interfaces
{
    public interface IFilmRepository
    {
        Film GetFilm(int id);
        Film GetFilm(string name);
        Film GetFilmByOriginalName(string originalName);
        Film AddFilm(Film film);
        Film UpdateFilm(Film film);
    }
}
