using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstemDb.Services;
using InstemDb.Services.Models.Carousel;

namespace InstemDb.Tests.Fakes
{
    public class FakeCarouselService : ICarouselService
    {
        public async Task<IEnumerable<CarouselServiceModel>> GetCarouselData(int? year)
        {
            var result = new List<CarouselServiceModel>
            {
                new CarouselServiceModel { Id = 1, ImageUrl = "https://www.instem.com/images/style/logo.png", Year = 2020},
                new CarouselServiceModel { Id = 2, ImageUrl = "https://www.instem.com/images/style/logo.png", Year = 2020},
                new CarouselServiceModel { Id = 3, ImageUrl = "https://www.instem.com/images/style/logo.png", Year = 2020},
                new CarouselServiceModel { Id = 4, ImageUrl = "https://www.instem.com/images/style/logo.png", Year = 2020},
                new CarouselServiceModel { Id = 5, ImageUrl = "https://www.instem.com/images/style/logo.png", Year = 2019},
            };

            return await Task.FromResult(result.Where(x => x.Year == year).Take(4));
        }
    }
}
