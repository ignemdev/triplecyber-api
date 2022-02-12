using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.DTOs
{
    public class MovieDetailResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public double VoteAverage { get; set; }
    }
}
