namespace InstemDb.Data.Models
{

    public class MovieInfoDirector
    {
        public int MovieInfoId { get; set; }

        public int DirectorId { get; set; }

        public MovieInfo MovieInfo { get; set; }

        public Director Director { get; set; }
    }

}