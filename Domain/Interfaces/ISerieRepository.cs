using Domain.Models;

namespace Domain.Interfaces
{
    public interface ISerieRepository
    {
        Serie GetSerie(int ID);
        Serie GetSerie(string name);
        Serie GetSerieByOriginalName(string originalName);
        Serie UpdateSerie(Serie serie);
        Serie AddSerie(Serie serie);
    }
}
