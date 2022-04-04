using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IFilmService
    {
        FilmDto GetFilm(int id);
        FilmDto GetFilm(string name);
        FilmDto SaveFilm(FilmDto film);
    }
}
