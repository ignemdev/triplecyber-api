using Movies.Core.DTOs;
using Movies.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Services
{
    public interface IMoviesServices
    {
        Task<MovieResponse<MovieDetailResponse>> GetMoviesByPageAsync(int page);
        Task<MovieDetailResponse> GetMovieByIdAsync(int id);
    }
}
