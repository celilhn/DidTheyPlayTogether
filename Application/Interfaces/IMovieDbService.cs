using Application.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IMovieDbService
    {
        List<Movies> GetPopulars(string page = "");
    }
}
