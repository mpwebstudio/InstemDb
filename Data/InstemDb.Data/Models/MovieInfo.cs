using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstemDb.Data.Models
{
    public class MovieInfo
    {
        public MovieInfo()
        {
            MovieInfoDirectors = new HashSet<MovieInfoDirector>();
            MovieInfoGenres = new HashSet<MovieInfoGenre>();
            MovieInfoActors = new HashSet<MovieInfoActor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MovieId { get; set; }

        public DateTime ReleaseDate { get; set; }

        [StringLength(2048)]
        public string ImageUrl { get; set; }

        public string Plot { get; set; }

        public int Rank { get; set; }

        public double Rating { get; set; }

        public int RunningTimeSecs { get; set; }

        public Movie Movie { get; set; }

        public ICollection<MovieInfoDirector> MovieInfoDirectors { get; set; }

        public ICollection<MovieInfoGenre> MovieInfoGenres { get; set; }

        public ICollection<MovieInfoActor> MovieInfoActors { get; set; }
    }
}