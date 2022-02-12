using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Movies.Api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesController()
        {

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
