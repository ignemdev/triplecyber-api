using Microsoft.AspNetCore.Mvc;
using Movies.Core.DTOs;
using Movies.Core.Exceptions;
using Movies.Core.Services;
using System.Threading.Tasks;

namespace Movies.Api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesServices _moviesServices;

        public MoviesController(IMoviesServices moviesServices)
        {
            _moviesServices = moviesServices;
        }

        [HttpGet]
        public async Task<ActionResult<MovieResponse<MovieDetailResponse>>> GetMoviesByPage([FromQuery] int page = 1)
        {
            var movies = new MovieResponse<MovieDetailResponse>();

            try
            {
                movies = await _moviesServices.GetMoviesByPageAsync(page);
            }
            catch (BadMovieDbRequestException e)
            {
                return StatusCode(e.StatusCode, new { message = e.Message });
            }

            return Ok(movies);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDetailResponse>> GetMovieById(int id)
        {
            var movie = new MovieDetailResponse();

            try
            {
                movie = await _moviesServices.GetMovieByIdAsync(id);
            }
            catch (BadMovieDbRequestException e)
            {
                return StatusCode(e.StatusCode, new { message = e.Message });
            }

            return Ok(movie);
        }

    }
}
