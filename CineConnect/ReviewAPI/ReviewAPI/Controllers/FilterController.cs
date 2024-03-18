using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/filter")]
    public class FilterController : ControllerBase
    {
        private readonly IMovieFilter _movieFilter;

        public FilterController(IMovieFilter movieFilter)
        {
            _movieFilter = movieFilter;
        }

        /// <summary>
        /// Выполняет фильтрацию фильмов согласно указанным параметрам.
        /// </summary>
        /// <param name="filter">Параметры фильтрации.</param>
        /// <returns>Список отфильтрованных фильмов.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<Movie>>> FilterMoviesAsync([FromQuery] Filter filter)
        {
            var filteredMovies = _movieFilter.FilterMovies(filter);
            return Ok(filteredMovies);
        }
    }
}
