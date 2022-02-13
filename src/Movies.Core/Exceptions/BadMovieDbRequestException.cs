using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Core.Exceptions
{
    public class BadMovieDbRequestException : Exception
    {
        public int StatusCode { get; set; }
        public BadMovieDbRequestException(MovieDbErrorResponse movieDbErrorResponse, int statusCode) 
            : base(movieDbErrorResponse.StatusMessage ??  string.Join("\n",movieDbErrorResponse.Errors))
        {
            StatusCode = statusCode;
        }
    }
}
