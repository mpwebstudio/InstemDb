namespace InstemDb.Services.Models.Carousel
{

    public class CarouselServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Plot { get; set; }

        public int Rank { get; set; }

        public double Rating { get; set; }

        public int RunningTimeSecs { get; set; }

        public int Year { get; set; }
    }
}