﻿using System;

namespace Application.ViewModels
{
    public class SerieDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int FirstEpisodeAirDate { get; set; }
        public int LastEpisodeAirDate { get; set; }
        public int NumberofSeasons { get; set; }
        public int NumberofEpisodes { get; set; }
        public string Channel { get; set; }
        public string Producer { get; set; }
        public string Siciation { get; set; }
        public int SourceID { get; set; }
    }
}
