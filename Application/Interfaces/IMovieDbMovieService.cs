using Application.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IMovieDbMovieService
    {
        List<Movies> GetPopularMovies(string page = "");
        List<Movies> GetNowPlayingMovies(string page = "");
    }
}
