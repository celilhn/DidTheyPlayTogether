using Domain.Models;

namespace Domain.Interfaces
{
    public interface IFamousRepository
    {
        Famous UpdateFamous(Famous famous);
        Famous AddFamous(Famous famous);
        Famous GetFamous(int id);
        Famous GetFamous(string name);
    }
}
