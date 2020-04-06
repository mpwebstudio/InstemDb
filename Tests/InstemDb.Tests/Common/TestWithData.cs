using System.Threading.Tasks;
using InstemDb.Data;
using InstemDb.Data.Models;
using InstemDb.Tests.Fakes;

namespace InstemDb.Tests.Common
{
    public abstract class TestWithData
    {
        protected async Task InitializeDatabase(string databaseName)
        {
            var fakeDatabase = new FakeInstemDbContext(databaseName);

            await AddFakeMovies(fakeDatabase);

            Database = fakeDatabase.Data;
        }

        protected InstemDbContext Database { get; private set; }

        private static async Task AddFakeMovies(FakeInstemDbContext fakeDb)
            => await fakeDb.Add(new Movie
            {
                Id = 1,
                Title = "Test Movie",
                Year = 2020,
                MovieInfo = new MovieInfo
                {
                    ImageUrl = "https://www.instem.com/images/style/logo.png"
                }
            },
            new Movie
            {
                Id = 10,
                Title = "Test Movie",
                Year = 2020,
                MovieInfo = new MovieInfo
                {
                    ImageUrl = "https://www.instem.com/images/style/logo.png"
                }
            },
            new Movie
            {
                Id = 11,
                Title = "Test Movie",
                Year = 2020,
                MovieInfo = new MovieInfo
                {
                    ImageUrl = "https://www.instem.com/images/style/logo.png"
                }
            },
            new Movie
            {
                Id = 12,
                Title = "Test Movie",
                Year = 2020,
                MovieInfo = new MovieInfo
                {
                    ImageUrl = "https://www.instem.com/images/style/logo.png"
                }
            },
            new Director
            {
                Id = 1,
                Name = "Roman Polanski"
            },
            new Actor
            {
                Id = 1,
                Name = "Robert De Niro"
            });
    }
}
