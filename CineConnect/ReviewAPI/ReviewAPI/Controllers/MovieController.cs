using Domain.Interfaces;
using Domain.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Domain.Entities;

namespace Api.Controllers
{
    /// <summary>
    /// Запрос для создания фильма.
    /// </summary>
    public record MovieRequest
    {
        [Required]
        public Guid MovieId { get; init; }

        [Required]
        public Guid GenreId { get; init; }

        [Required]
        public string Title { get; init; }

        [Required]
        public int ReleaseYear { get; init; }

        [Required]
        public string Description {  get; init; }

        [Required]
        [Range(1,10)]
        public double Rating { get; init; }
    }

    /// <summary>
    /// Контроллер для управления фильмами.
    /// </summary>
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        /// <summary>
        /// Добавляет новый фильм.
        /// </summary>
        /// <param name="request">Запрос на создание фильма.</param>
        /// <returns>Результат выполнения операции.</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> AddMovieAsync([FromBody] MovieRequest request)
        {
            var movieId = Guid.NewGuid();
            await _movieRepository.AddMovie(new Movie
            {
                MovieId = movieId,
                GenreId = request.GenreId,
                Title = request.Title,
                ReleaseYear = request.ReleaseYear,
                Description = request.Description,
                Rating = request.Rating,
            });
            return Ok();
        }

        /// <summary>
        /// Получает информацию о фильме по его идентификатору.
        /// </summary>
        /// <param name="movieId">Идентификатор фильма.</param>
        /// <returns>Информация о фильме.</returns>
        [HttpGet("{movieId}")]
        [ProducesResponseType(200, Type = typeof(Movie))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Movie>> GetMovieByIdAsync(Guid movieId)
        {
            var movie = await _movieRepository.GetMovieById(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        /// <summary>
        /// Получает список всех фильмов.
        /// </summary>
        /// <returns>Список всех фильмов.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllMovies();
            return Ok(movies);
        }

        /// <summary>
        /// Удаляет фильм по его идентификатору.
        /// </summary>
        /// <param name="movieId">Идентификатор фильма.</param>
        [HttpDelete]
        [ProducesResponseType(200)]
        public async Task<ActionResult> DeleteMovieAsync(Guid movieId)
        {
            await _movieRepository.DeleteMovie(movieId);
            return Ok();
        }
    }
}
