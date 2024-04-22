using Core.RabbitMq;
using Core.Services.RabbitMq.interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/filter")]
    public class FilterController : ControllerBase
    {
        private readonly IMovieFilter _movieFilter;
        private readonly IRabbitMqService _rabbitMqService;

        public FilterController(IMovieFilter movieFilter, IRabbitMqService rabbitMqService)
        {
            _movieFilter = movieFilter;
            _rabbitMqService = rabbitMqService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<Movie>>> FilterMoviesAsync([FromQuery] Filter filter)
        {
            var filteredMovies = _movieFilter.FilterMovies(filter);
            _rabbitMqService.SendMessage(filter.ToString());
            return Ok(filteredMovies);
        }
    }
}
