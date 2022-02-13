using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Models
{
    public class MovieDbErrorResponse
    {
        public string StatusMessage { get; set; }
        public string[] Errors { get; set; }
    }
}
