using InstemDb.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstemDb.Data
{

    public class InstemDbContext : IdentityDbContext<IdentityUser>
    {
        public InstemDbContext(DbContextOptions<InstemDbContext> options)
            : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieInfo> MovieInfos { get; set; }

        public DbSet<MovieInfoActor> MovieInfoActors { get; set; }

        public DbSet<MovieInfoDirector> MovieInfoDirectors { get; set; }

        public DbSet<MovieInfoGenre> MovieInfoGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .HasOne(a => a.MovieInfo)
                .WithOne(b => b.Movie)
                .HasForeignKey<MovieInfo>(a => a.MovieId);

            builder.Entity<MovieInfoActor>().HasKey(a => new { a.ActorId, a.MovieInfoId });

            builder.Entity<MovieInfoActor>()
                .HasOne(a => a.MovieInfo)
                .WithMany(b => b.MovieInfoActors)
                .HasForeignKey(a => a.MovieInfoId);

            builder.Entity<MovieInfoActor>()
                .HasOne(a => a.Actor)
                .WithMany(b => b.MovieInfoActors)
                .HasForeignKey(a => a.ActorId);

            builder.Entity<MovieInfoDirector>().HasKey(a => new { a.DirectorId, a.MovieInfoId });

            builder.Entity<MovieInfoDirector>()
                .HasOne(a => a.MovieInfo)
                .WithMany(b => b.MovieInfoDirectors)
                .HasForeignKey(a => a.MovieInfoId);

            builder.Entity<MovieInfoDirector>()
                .HasOne(a => a.Director)
                .WithMany(b => b.MovieInfoDirectors)
                .HasForeignKey(a => a.DirectorId);

            builder.Entity<MovieInfoGenre>().HasKey(a => new { a.GenreId, a.MovieInfoId });

            builder.Entity<MovieInfoGenre>()
                .HasOne(a => a.MovieInfo)
                .WithMany(b => b.MovieInfoGenres)
                .HasForeignKey(a => a.MovieInfoId);

            builder.Entity<MovieInfoGenre>()
                .HasOne(a => a.Genre)
                .WithMany(b => b.MovieInfoGenres)
                .HasForeignKey(a => a.GenreId);

            builder.Entity<MovieInfo>()
                .Property(x => x.ReleaseDate)
                .HasColumnType("datetime2");

            base.OnModelCreating(builder);
        }
    }

}