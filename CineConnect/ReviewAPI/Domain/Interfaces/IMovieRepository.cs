using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с хранилищем фильмов
    /// </summary>
    public interface IMovieRepository
    {
        /// <summary>
        /// Получает фильм по его идентификатору
        /// </summary>
        /// <param name="movieId">Идентификатор фильма</param>
        /// <returns>Фильм</returns>
        Task<Movie> GetMovieById(Guid movieId);

        /// <summary>
        /// Получает список всех фильмов.
        /// </summary>
        /// <returns>Список фильмов.</returns>
        Task<List<Movie>> GetAllMovies();

        /// <summary>
        /// Добавляет новый фильм.
        /// </summary>
        /// <param name="movie">Фильм для добавления.</param>
        /// <returns>Идентификатор добавленного фильма.</returns>
        Task<Guid> AddMovie(Movie movie);

        /// <summary>
        /// Удаляет фильм по его идентификатору.
        /// </summary>
        /// <param name="movieId">Идентификатор фильма для удаления.</param>
        Task DeleteMovie(Guid movieId);
    }
}
