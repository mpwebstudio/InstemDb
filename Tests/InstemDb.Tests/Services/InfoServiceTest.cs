using System.Threading.Tasks;
using AutoMapper;
using InstemDb.Services.Implementation;
using InstemDb.Services.Infrastructure;
using InstemDb.Tests.Common;
using Xunit;

namespace InstemDb.Tests.Services
{
    public class InfoServiceTest : TestWithData
    {
        [Fact]
        public async Task GetInfo_MovieInfo_ShouldReturnData()
        {
            //Arrange
            var infoService = await GetInfoService("InfoService");

            //Act
            var exist = await infoService.MovieInfo(1);

            //Assert
            Assert.NotNull(exist);
        }

        [Fact]
        public async Task GetInfo_MovieInfo_ShouldReturnNull()
        {
            //Arrange
            var infoService = await GetInfoService("InfoService2");

            //Act
            var exist = await infoService.MovieInfo(2);

            //Assert
            Assert.Null(exist);
        }

        [Fact]
        public async Task GetInfo_ActorInfo_ShouldReturnData()
        {
            //Arrange
            var infoService = await GetInfoService("InfoService3");

            //Act
            var exist = await infoService.ActorInfo(1);

            //Assert
            Assert.NotNull(exist);
        }

        [Fact]
        public async Task GetInfo_ActorInfo_ShouldReturnNull()
        {
            //Arrange
            var infoService = await GetInfoService("InfoService4");

            //Act
            var exist = await infoService.ActorInfo(2);

            //Assert
            Assert.Null(exist);
        }

        [Fact]
        public async Task GetInfo_DirectorInfo_ShouldReturnData()
        {
            //Arrange
            var infoService = await GetInfoService("InfoService5");

            //Act
            var exist = await infoService.DirectorInfo(1);

            //Assert
            Assert.NotNull(exist);
        }

        [Fact]
        public async Task GetInfo_DirectorInfo_ShouldReturnNull()
        {
            //Arrange
            var infoService = await GetInfoService("InfoService6");

            //Act
            var exist = await infoService.DirectorInfo(2);

            //Assert
            Assert.Null(exist);
        }

        private async Task<InfoService> GetInfoService(string databaseName)
        {
            await InitializeDatabase(databaseName);

            var mapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile<InfoServiceMappingProfile>();
            }));

            return new InfoService(Database, mapper);
        }
    }
}
