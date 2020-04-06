using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InstemDb.Services.Implementation;
using InstemDb.Services.Infrastructure;
using InstemDb.Services.Models.Search;
using InstemDb.Tests.Common;
using Xunit;

namespace InstemDb.Tests.Services
{
    public class SearchServiceTest : TestWithData
    {
        [Fact]
        public async Task Search_ByTitle_ShouldReturnData()
        {
            //Arrange
            var searchService = await GetSearchService("SearchService");
            var request = new SearchRequestModel { SearchTerm = "Test", SearchParam = "title" };

            //Act
            var exist = await searchService.Search(request);

            //Assert
            Assert.True(exist.Any());
        }

        [Fact]
        public async Task Search_ByTitle_ShouldReturnEmptyList()
        {
            //Arrange
            var searchService = await GetSearchService("SearchService1");
            var request = new SearchRequestModel { SearchTerm = "Instem", SearchParam = "title" };

            //Act
            var exist = await searchService.Search(request);

            //Assert
            Assert.False(exist.Any());
        }

        [Fact]
        public async Task Search_ByDirector_ShouldReturnData()
        {
            //Arrange
            var searchService = await GetSearchService("SearchService2");
            var request = new SearchRequestModel { SearchTerm = "Roman", SearchParam = "director" };

            //Act
            var exist = await searchService.Search(request);

            //Assert
            Assert.True(exist.Any());
        }

        [Fact]
        public async Task Search_ByDirector_ShouldReturnEmptyList()
        {
            //Arrange
            var searchService = await GetSearchService("SearchService3");
            var request = new SearchRequestModel { SearchTerm = "Instem", SearchParam = "director" };

            //Act
            var exist = await searchService.Search(request);

            //Assert
            Assert.False(exist.Any());
        }

        [Fact]
        public async Task Search_ByActor_ShouldReturnData()
        {
            //Arrange
            var searchService = await GetSearchService("SearchService4");
            var request = new SearchRequestModel { SearchTerm = "Robert", SearchParam = "actor" };

            //Act
            var exist = await searchService.Search(request);

            //Assert
            Assert.True(exist.Any());
        }

        [Fact]
        public async Task Search_ByActor_ShouldReturnEmptyList()
        {
            //Arrange
            var searchService = await GetSearchService("SearchService5");
            var request = new SearchRequestModel { SearchTerm = "Instem", SearchParam = "actor" };

            //Act
            var exist = await searchService.Search(request);

            //Assert
            Assert.False(exist.Any());
        }

        private async Task<SearchService> GetSearchService(string databaseName)
        {
            await InitializeDatabase(databaseName);

            var mapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile<SearchServiceMappingProfile>();
            }));

            return new SearchService(Database, mapper);
        }
    }
}
