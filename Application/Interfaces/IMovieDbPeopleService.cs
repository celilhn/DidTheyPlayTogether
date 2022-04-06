using Application.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IMovieDbPeopleService
    {
        List<People> GetPopularPeople(string page = "");
    }
}
