namespace InstemDb.Data.Models
{

    public class MovieInfoActor
    {
        public int MovieInfoId { get; set; }

        public int ActorId { get; set; }

        public MovieInfo MovieInfo { get; set; }

        public Actor Actor { get; set; }
    }

}