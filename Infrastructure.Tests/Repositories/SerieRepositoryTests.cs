using Xunit;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Infrastructure.Repositories.Tests
{
    public class SerieRepositoryTests
    {
        private readonly ISerieRepository serieRepository;

        public SerieRepositoryTests(ISerieRepository serieRepository)
        {
            this.serieRepository = serieRepository;
        }

        [Fact()]
        public void AddSerie_IsNull_False()
        {
            Serie serie = new Serie();
            serie.InsertionDate = DateTime.Now;
            serie.Name = "Test";
            serie.UpdateDate = DateTime.Now;
            serie.Producer = "Test";
            serie.NumberofEpisodes = 23;
            serie.Status = 0;
            serie = serieRepository.AddSerie(serie);
            Assert.False(serie == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetSerie_IsNull_False(int id)
        {
            Serie serie = serieRepository.GetSerie(id);
            Assert.False(serie == null);
        }

        [Theory()]
        [InlineData("Çukur")]
        public void GetSerie_IsNull_False1(string name)
        {
            Serie serie = serieRepository.GetSerie(name);
            Assert.False(serie == null);
        }

        [Fact()]
        public void UpdateSerie_IsNull_False()
        {
            Serie serie = new Serie();
            serie.UpdateDate = DateTime.Now;
            serie = serieRepository.UpdateSerie(serie);
            Assert.False(serie == null);
        }
    }
}