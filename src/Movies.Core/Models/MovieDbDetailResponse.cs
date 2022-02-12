using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Models
{
    public class MovieDbDetailResponse
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public int[] GenreIds { get; set; }
        public int Id { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public double VoteCount { get; set; }
    }
}
