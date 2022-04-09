using Xunit;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Repositories.Tests
{
    public class FamousRepositoryTests
    {
        private readonly IFamousRepository famousRepository;

        public FamousRepositoryTests(IFamousRepository famousRepository)
        {
            this.famousRepository = famousRepository;
        }

        [Fact()]
        public void AddFamous_IsNull_False()
        {
            Famous famous = new Famous();
            famous.Age = "1111";
            famous.Education = "Yüksek Lisans";
            famous.Gender = 0;
            famous.Name = "Celilhan Kadıoğlu";
            famous.Popularity = 20;
            famous.Weight = "65";
            famous.Status = 0;
            famous.InsertionDate = System.DateTime.Now;
            famous.UpdateDate = System.DateTime.Now;
            famous = famousRepository.AddFamous(famous);
            Assert.False(famous == null);
        }

        [Theory()]
        [InlineData(2)]
        public void GetFamous_IsNull_False(int id)
        {
            Famous famous = famousRepository.GetFamous(id);
            Assert.False(famous == null);
        }

        [Theory()]
        [InlineData("Kıvanç Tatlıtuğ")]
        public void GetFamous_IsNull_False1(string name)
        {
            Famous famous = famousRepository.GetFamous(name);
            Assert.False(famous == null);
        }

        [Fact()]
        public void GetFamouses_IsNull_False()
        {
            List<Famous> famouses = famousRepository.GetFamouses();
            Assert.False(famouses == null);
        }

        [Fact()]
        public void UpdateFamous_IsNull_False()
        {
            Famous famous = famousRepository.GetFamous(111);
            famous.UpdateDate = System.DateTime.Now;
            famous = famousRepository.UpdateFamous(famous);
            Assert.False(famous == null);
        }
    }
}