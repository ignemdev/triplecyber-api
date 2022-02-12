using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.DTOs
{
    public class MovieResponse <T> where T : class
    {
        public int Page { get; set; }
        public IEnumerable<T> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
