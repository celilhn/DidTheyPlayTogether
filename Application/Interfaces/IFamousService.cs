using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IFamousService
    {
        FamousDto SaveFamous(FamousDto famous);
        FamousDto GetFamous(int id);
        FamousDto GetFamous(string name);
        List<FamousDto> GetFamouses();
    }
}
