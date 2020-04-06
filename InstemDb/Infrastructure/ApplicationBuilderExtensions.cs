using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InstemDb.Data;
using InstemDb.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace InstemDb.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            return app;
        }

        public static IApplicationBuilder UseEndpoints(this IApplicationBuilder app)
            => app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "custom",
                    pattern: "custom/{controller}/{action}");

                endpoints.MapRazorPages();
            });

        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<InstemDbContext>();
                db.Database.Migrate();
                LoadData(db);

                return app;
            }
        }

        private static void LoadData(InstemDbContext db)
        {
            if (db.Genres.Any())
            {
                return;
            }

            var myJsonString = File.ReadAllText("./Db/moviedata.json");

            var myJsonObject = JsonConvert.DeserializeObject<List<RootObject>>(myJsonString);

            var directors = myJsonObject.Where(x => x.info.directors != null)
                                        .SelectMany(x => x.info.directors.Select(z => z))
                                        .ToHashSet()
                                        .Select(z => new Director { Name = z })
                                        .ToList();

            var genres = myJsonObject.Where(x => x.info.genres != null)
                                    .SelectMany(x => x.info.genres.Select(z => z))
                                    .ToHashSet()
                                    .Select(x => new Genre { GenreType = x })
                                    .ToList();

            var actors = myJsonObject.Where(x => x.info.actors != null)
                                    .SelectMany(x => x.info.actors.Select(x => x))
                                    .ToHashSet()
                                    .Select(z => new Actor { Name = z })
                                    .ToList();

            db.Directors.AddRange(directors);
            db.Genres.AddRange(genres);
            db.Actors.AddRange(actors);
            db.SaveChanges();

            var movies = myJsonObject.Select(movie => new Movie
            {
                Title = movie.title,
                Year = movie.year,
                MovieInfo = new MovieInfo
                {
                    ImageUrl = movie.info.image_url,
                    Plot = movie.info.plot,
                    Rank = movie.info.rank,
                    Rating = movie.info.rating,
                    ReleaseDate = movie.info.release_date,
                    RunningTimeSecs = movie.info.running_time_secs,
                    MovieInfoGenres = genres.Where(x => movie.info.genres != null && movie.info.genres.Contains(x.GenreType))
                            .Select(x => new MovieInfoGenre { GenreId = x.Id })
                            .ToList(),
                    MovieInfoActors = actors.Where(x => movie.info.actors != null && movie.info.actors.Contains(x.Name))
                            .Select(x => new MovieInfoActor { ActorId = x.Id })
                            .ToList(),
                    MovieInfoDirectors = directors.Where(x => movie.info.directors != null && movie.info.directors.Contains(x.Name))
                            .Select(x => new MovieInfoDirector { DirectorId = x.Id })
                            .ToList()
                }
            })
                .ToList();

            db.Movies.AddRange(movies);
            db.SaveChanges();
        }

        private class Info
        {
            public List<string> directors { get; set; }
            public DateTime release_date { get; set; }
            public double rating { get; set; }
            public List<string> genres { get; set; }
            public string image_url { get; set; }
            public string plot { get; set; }
            public int rank { get; set; }
            public int running_time_secs { get; set; }
            public List<string> actors { get; set; }
        }

        private class RootObject
        {
            public int year { get; set; }
            public string title { get; set; }
            public Info info { get; set; }
        }
    }
}
