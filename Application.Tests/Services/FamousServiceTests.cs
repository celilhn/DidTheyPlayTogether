using Xunit;
using Application.Interfaces;
using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Services.Tests
{
    public class FamousServiceTests
    {
        private readonly IFamousService famousService;

        public FamousServiceTests(IFamousService famousService)
        {
            this.famousService = famousService;
        }

        [Theory()]
        [InlineData(2)]
        public void GetFamous_IsNull_False(int id)
        {
            FamousDto famous = famousService.GetFamous(id);
            Assert.False(famous == null);
        }

        [Theory()]
        [InlineData("Hasan")]
        [InlineData("CCCCCCC")]
        public void GetFamous_IsNotNull_False(string name)
        {
            FamousDto famous = famousService.GetFamous(name);
            Assert.False(famous == null);
        }

        [Fact()]
        public void GetFamouses_IsNull_False()
        {
            List<FamousDto> famouses = famousService.GetFamouses();
            Assert.True(famouses == null);
        }
    }
}