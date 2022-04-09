using Application.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IMovieDbService
    {
        List<Movies> GetPopularMovies(string page = ""); 
        List<People> GetPopularPeople(string page = "");
    }
}
