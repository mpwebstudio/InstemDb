using System.Collections.Generic;
using System.Threading.Tasks;
using InstemDb.Services.Models.Carousel;

namespace InstemDb.Services
{

    public interface ICarouselService
    {
        Task<IEnumerable<CarouselServiceModel>> GetCarouselData(int? year);
    }

}