using System.Threading.Tasks;
using InstemDb.Data;
using Microsoft.EntityFrameworkCore;

namespace InstemDb.Tests.Fakes
{
    public class FakeInstemDbContext
    {
        public FakeInstemDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<InstemDbContext>()
                .UseInMemoryDatabase(name)
                .Options;

            Data = new InstemDbContext(options);
        }

        public InstemDbContext Data { get; }

        public async Task Add(params object[] data)
        {
            Data.AddRange(data);
            await Data.SaveChangesAsync();
        }
    }
}
