using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> GetMoviesByPage([FromQuery] int page = 1)
        {
            return Ok(page);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetMovieById(int id)
        {
            return Ok(id);
        }

    }
}
