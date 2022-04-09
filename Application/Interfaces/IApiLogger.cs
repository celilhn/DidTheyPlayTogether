using Application.Models;

namespace Application.Interfaces
{
    public interface IApiLogger
    {
        public void Log(LogDetail logDetail);
    }
}
