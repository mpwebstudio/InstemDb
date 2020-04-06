using System;
using System.Collections.Generic;

namespace InstemDb.Services.Models.Info
{
    public class MovieInfoResponseModel
    {
        public string Title { get; set; }

        public double Rating { get; set; }

        public string RunningTimeSecs { get; set; }

        public List<string> Genres { get; set; }

        public List<string> Directors { get; set; }

        public List<string> Actors { get; set; }

        public string ImageUrl { get; set; }

        public string Plot { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
