using Xunit;
using Application.Interfaces;
using Application.ViewModels;

namespace Application.Services.Tests
{
    public class SerieServiceTests
    {
        private readonly ISerieService serieService;

        public SerieServiceTests(ISerieService serieService)
        {
            this.serieService = serieService;
        }

        [Theory()]
        [InlineData(2)]
        public void GetSerie_IsNull_False(int id)
        {
            SerieDto serie = serieService.GetSerie(id);
            Assert.False(serie == null);
        }

        [Theory()]
        [InlineData("Çukur")]
        public void GetSerie_IsNull_False1(string name)
        {
            SerieDto serie = serieService.GetSerie(name);
            Assert.False(serie == null);
        }
    }
}