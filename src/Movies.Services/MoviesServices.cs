using AutoMapper;
using Microsoft.Extensions.Configuration;
using Movies.Core.DTOs;
using Movies.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class MoviesServices : IMoviesServices
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public MoviesServices(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }    

        public async Task<MovieDetailResponse> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieResponse<MovieDetailResponse>> GetMoviesByPageAsync(int page)
        {
            string moviesJson = await GetRequestResult("top_rated", $"page={page}","language=en-US");
            return null;
        }

        private async Task<string> GetRequestResult(string endpoint, params string[] query)
        {
            using var client = new HttpClient();

            var queryParams = query.ToList();
            queryParams.Add($"api_key={_configuration["TheMovieDb:ApiKey"]}");

            client.BaseAddress = new Uri($"{_configuration["TheMovieDb:BaseAddress"]}{endpoint}");

            var response = await client.GetAsync($"?{string.Join("&", queryParams)}");
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

    }
}
