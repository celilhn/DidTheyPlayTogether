using Application.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IMovieDbTvService
    {
        List<PopularTv> GetPopularTvs(string page = "");
    }
}
