using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IFilmService
    {
        FilmDto GetFilm(int id);
        FilmDto GetFilm(string name);
        FilmDto GetFilmByOriginalName(string originalName);
        FilmDto SaveFilm(FilmDto film);
    }
}
