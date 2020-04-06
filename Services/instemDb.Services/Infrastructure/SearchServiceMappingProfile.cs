using AutoMapper;
using InstemDb.Data.Models;
using InstemDb.Services.Models.Search;

namespace InstemDb.Services.Infrastructure
{
    public class SearchServiceMappingProfile : Profile
    {
        public SearchServiceMappingProfile()
        {
            CreateMap<Movie, SearchResponseModel>()
                .ForMember(t => t.ImageUrl, a => a.MapFrom(f => f.MovieInfo.ImageUrl))
                .ForMember(t => t.Name, a => a.MapFrom(f => $"{f.Title} ({f.Year})"))
                .ForMember(t => t.Url, a => a.MapFrom(f => $"/Info/MovieInfo/?id={f.Id}"));

            CreateMap<Director, SearchResponseModel>()
                .ForMember(t => t.ImageUrl, a => a.MapFrom(f => string.Empty))
                .ForMember(t => t.Name, a => a.MapFrom(f => f.Name))
                .ForMember(t => t.Url, a => a.MapFrom(f => $"/Info/DirectorInfo/?id={f.Id}"));

            CreateMap<Actor, SearchResponseModel>()
                .ForMember(t => t.ImageUrl, a => a.MapFrom(f => string.Empty))
                .ForMember(t => t.Name, a => a.MapFrom(f => f.Name))
                .ForMember(t => t.Url, a => a.MapFrom(f => $"/Info/ActorInfo/?id={f.Id}"));
        }
    }
}
