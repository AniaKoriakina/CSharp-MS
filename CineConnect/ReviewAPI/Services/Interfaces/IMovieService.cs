using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с фильмами.
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Получает фильм по его идентификатору.
        /// </summary>
        /// <param name="movieId">Идентификатор фильма.</param>
        /// <returns>Фильм с указанным идентификатором.</returns>
        Task<Movie> GetMovieByIdAsync(Guid movieId);

        /// <summary>
        /// Получает список всех фильмов.
        /// </summary>
        /// <returns>Список всех фильмов.</returns>
        Task<List<Movie>> GetAllMoviesAsync();

        /// <summary>
        /// Добавляет новый фильм.
        /// </summary>
        /// <param name="movie">Информация о новом фильме.</param>
        /// <returns>Идентификатор добавленного фильма.</returns>
        Task<Guid> AddMovieAsync(Movie movie);

        /// <summary>
        /// Удаляет фильм по его идентификатору.
        /// </summary>
        /// <param name="movieId">Идентификатор удаляемого фильма.</param>
        Task DeleteMovieAsync(Guid movieId);
    }
}
