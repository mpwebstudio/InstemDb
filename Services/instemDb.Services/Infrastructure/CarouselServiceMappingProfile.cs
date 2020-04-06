using AutoMapper;
using InstemDb.Data.Models;
using InstemDb.Services.Models.Carousel;

namespace InstemDb.Services.Infrastructure
{
    public class CarouselServiceMappingProfile : Profile
    {
        public CarouselServiceMappingProfile()
        {
            CreateMap<Movie, CarouselServiceModel>()
                .ForMember(f => f.ImageUrl, a => a.MapFrom(f => f.MovieInfo.ImageUrl))
                .ForMember(f => f.Rating, a => a.MapFrom(f => f.MovieInfo.Rating));
        }
    }
}
