namespace InstemDb.Data.Models
{

    public class MovieInfoGenre
    {
        public int GenreId { get; set; }
        
        public int MovieInfoId { get; set; }

        public MovieInfo MovieInfo { get; set; }

        public Genre Genre { get; set; }
    }

}