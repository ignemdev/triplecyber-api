using Microsoft.Extensions.Configuration;
using Movies.Core.DTOs;
using Movies.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class MoviesServices : IMoviesServices
    {
        private readonly IConfiguration _configuration;

        public MoviesServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }    

        public Task<MovieDetailResponse> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieResponse<MovieDetailResponse>> GetMoviesByPageAsync(int page)
        {
            throw new NotImplementedException();
        }


    }
}
