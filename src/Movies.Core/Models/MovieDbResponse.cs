using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Movies.Core.Models
{
    public class MovieDbResponse<T> where T : class
    {
        public int Page { get; set; }
        public IEnumerable<T> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
