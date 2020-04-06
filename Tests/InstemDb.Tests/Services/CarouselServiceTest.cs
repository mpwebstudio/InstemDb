using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InstemDb.Services.Implementation;
using InstemDb.Services.Infrastructure;
using InstemDb.Tests.Common;
using Xunit;

namespace InstemDb.Tests.Services
{
    public class CarouselServiceTest : TestWithData
    {
        [Fact]
        public async Task CarouselService_GetCarouselData_ShouldReturnDataWithNoSuppliedYear()
        {
            //Arrange
            var carouselService = await CarouselService("carouselService");

            //Act
            var exist = await carouselService.GetCarouselData(null);

            //Assert
            Assert.NotNull(exist);
        }

        [Fact]
        public async Task CarouselService_GetCarouselData_ShouldReturnDataWithSuppliedFeatureYear()
        {
            //Arrange
            var carouselService = await CarouselService("carouselService2");

            //Act
            var exist = await carouselService.GetCarouselData(DateTime.UtcNow.Year + 1);

            //Assert
            Assert.NotNull(exist);
        }

        [Fact]
        public async Task CarouselService_GetCarouselData_CarouselService_GetCarouselData_ShouldReturnDataWithSuppliedCurrentYear()
        {
            //Arrange
            var carouselService = await CarouselService("carouselService3");

            //Act
            var exist = await carouselService.GetCarouselData(DateTime.UtcNow.Year);

            //Assert
            Assert.NotNull(exist);
        }

        [Fact]
        public async Task CarouselService_ActorInfo_ShouldReturnEmptyCollectionWithSuppliedPastYear()
        {
            //Arrange
            var carouselService = await CarouselService("carouselService4");

            //Act
            var exist = await carouselService.GetCarouselData(2019);

            //Assert
            Assert.False(exist.Any());
        }

        private async Task<CarouselService> CarouselService(string databaseName)
        {
            await InitializeDatabase(databaseName);

            var mapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile<CarouselServiceMappingProfile>();
            }));

            return new CarouselService(Database, mapper);
        }
    }
}
