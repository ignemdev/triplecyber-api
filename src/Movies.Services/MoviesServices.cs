using AutoMapper;
using Microsoft.Extensions.Configuration;
using Movies.Core.DTOs;
using Movies.Core.Exceptions;
using Movies.Core.Models;
using Movies.Core.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class MoviesServices : IMoviesServices
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DefaultContractResolver _snakeCaseContractResolver;

        public MoviesServices(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _snakeCaseContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
        }

        public async Task<MovieDetailResponse> GetMovieByIdAsync(int id)
        {
            var response = await GetRequestResponse(id.ToString(), "language=en-US");
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject(json,
                typeof(MovieDbErrorResponse), new JsonSerializerSettings { ContractResolver = _snakeCaseContractResolver });

                throw new BadMovieDbRequestException((MovieDbErrorResponse)error, (int)response.StatusCode);
            }

            var dbMovie = JsonConvert.DeserializeObject(json,
                typeof(MovieDbDetailResponse),
                new JsonSerializerSettings { ContractResolver = _snakeCaseContractResolver });

            var movie = _mapper.Map<MovieDetailResponse>(dbMovie);

            return movie;
        }

        public async Task<MovieResponse<MovieDetailResponse>> GetMoviesByPageAsync(int page)
        {
            var response = await GetRequestResponse("top_rated", $"page={page}", "language=en-US");
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject(json,
                typeof(MovieDbErrorResponse), new JsonSerializerSettings { ContractResolver = _snakeCaseContractResolver });

                throw new BadMovieDbRequestException((MovieDbErrorResponse)error, (int)response.StatusCode);
            }

            var dbMovies = JsonConvert.DeserializeObject(json,
                typeof(MovieDbResponse<MovieDbDetailResponse>),
                new JsonSerializerSettings { ContractResolver = _snakeCaseContractResolver });

            var movies = _mapper.Map<MovieResponse<MovieDetailResponse>>(dbMovies);

            return movies;
        }

        private async Task<HttpResponseMessage> GetRequestResponse(string endpoint, params string[] query)
        {
            using var client = new HttpClient();

            var queryParams = query.ToList();
            queryParams.Add($"api_key={_configuration["TheMovieDb:ApiKey"]}");

            client.BaseAddress = new Uri($"{_configuration["TheMovieDb:BaseAddress"]}{endpoint}");

            var response = await client.GetAsync($"?{string.Join("&", queryParams)}");

            return response;
        }
    }
}
