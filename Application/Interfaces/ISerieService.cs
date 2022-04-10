using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISerieService
    {
        SerieDto GetSerie(int ID); 
        SerieDto GetSerie(string name);
        SerieDto GetSerieByOriginalName(string originalName);
        SerieDto SaveSerie(SerieDto serie);
    }
}
