using System;
using System.Linq;
using AutoMapper;
using InstemDb.Data.Models;
using InstemDb.Services.Models.Info;

namespace InstemDb.Services.Infrastructure
{
    public class InfoServiceMappingProfile : Profile
    {
        public InfoServiceMappingProfile()
        {
            CreateMap<Actor, ActorInfoResponseModel>()
                .ForMember(t => t.Name, a => a.MapFrom(f => f.Name))
                .ForMember(t => t.Filmography, a => a.MapFrom(f => f.MovieInfoActors));

            CreateMap<MovieInfoActor, FilmographyResponseModel>()
                .ForMember(t => t.Id, a => a.MapFrom(f => f.MovieInfo.Id))
                .ForMember(t => t.Title, a => a.MapFrom(f => $"{f.MovieInfo.Movie.Title} ({f.MovieInfo.Movie.Year})"))
                .ForMember(t => t.ImageUrl, a => a.MapFrom(f => f.MovieInfo.ImageUrl))
                .ForMember(t => t.Year, a => a.MapFrom(f => f.MovieInfo.Movie.Year));

            CreateMap<Director, DirectorInfoResponseModel>()
                .ForMember(t => t.Name, a => a.MapFrom(f => f.Name))
                .ForMember(t => t.Filmography, a => a.MapFrom(f => f.MovieInfoDirectors));

            CreateMap<MovieInfoDirector, FilmographyResponseModel>()
                .ForMember(t => t.Id, a => a.MapFrom(f => f.MovieInfo.Id))
                .ForMember(t => t.Title, a => a.MapFrom(f => $"{f.MovieInfo.Movie.Title} ({f.MovieInfo.Movie.Year})"))
                .ForMember(t => t.ImageUrl, a => a.MapFrom(f => f.MovieInfo.ImageUrl))
                .ForMember(t => t.Year, a => a.MapFrom(f => f.MovieInfo.Movie.Year));

            CreateMap<Movie, MovieInfoResponseModel>()
               .ForMember(t => t.Title, a => a.MapFrom(f => $"{f.Title} ({f.Year})"))
               .ForMember(t => t.Rating, a => a.MapFrom(f => f.MovieInfo.Rating))
               .ForMember(t => t.RunningTimeSecs, a => a.MapFrom(f => TimeSpan.FromSeconds(f.MovieInfo.RunningTimeSecs).ToString(@"hh\:mm")))
               .ForMember(t => t.Genres, a => a.MapFrom(f => f.MovieInfo.MovieInfoGenres.Select(x => x.Genre.GenreType)))
               .ForMember(t => t.Directors, a => a.MapFrom(f => f.MovieInfo.MovieInfoDirectors.Select(x => x.Director.Name)))
               .ForMember(t => t.Actors, a => a.MapFrom(f => f.MovieInfo.MovieInfoActors.Select(x => x.Actor.Name)))
               .ForMember(t => t.ImageUrl, a => a.MapFrom(f => f.MovieInfo.ImageUrl))
               .ForMember(t => t.Plot, a => a.MapFrom(f => f.MovieInfo.Plot))
               .ForMember(t => t.ReleaseDate, a => a.MapFrom(f => f.MovieInfo.ReleaseDate));
        }
    }
}
