using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IFamousRepository
    {
        Famous UpdateFamous(Famous famous);
        Famous AddFamous(Famous famous);
        Famous GetFamous(int id);
        Famous GetFamous(string name);
        List<Famous> GetFamouses();
    }
}
