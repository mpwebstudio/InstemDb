﻿using System.Collections.Generic;

namespace InstemDb.Services.Models.Info
{
    public class ActorInfoResponseModel
    {
        public string Name { get; set; }

        public List<FilmographyResponseModel> Filmography { get; set; }
    }
}
