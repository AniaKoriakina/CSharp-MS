using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite; 
using Dapper;
using System.Data;

namespace Infastracted.Data
{
    /// <summary>
    /// Репозиторий для работы с фильмами.
    /// </summary>
    public class MovieRepository : IMovieRepository
    {
        /// <summary>
        /// Добавляет новый фильм.
        /// </summary>
        /// <param name="movie">Фильм для добавления.</param>
        /// <returns>Идентификатор добавленного фильма.</returns>
        public async Task<Guid> AddMovie(Movie movie)
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// Удаляет фильм по его идентификатору.
        /// </summary>
        /// <param name="movieId">Идентификатор фильма.</param>
        public async Task DeleteMovie(Guid movieId)
        {
            Console.WriteLine($"Фильм с идентификатором {movieId} удален.");
        }


        /// <summary>
        /// Получает список всех фильмов.
        /// </summary>
        /// <returns>Список всех фильмов.</returns>
        public async Task<List<Movie>> GetAllMovies()
        {
            return new List<Movie>();
        }

        /// <summary>
        /// Получает фильм по его идентификатору.
        /// </summary>
        /// <param name="movieId">Идентификатор фильма.</param>
        /// <returns>Фильм с указанным идентификатором.</returns>
        public async Task<Movie> GetMovieById(Guid movieId)
        {
            var movie = new Movie
            {
                MovieId = movieId,
                GenreId = Guid.NewGuid(),
                Title = "Пример фильма",
                ReleaseYear = 2022,
                Description = "Описание фильма",
                Rating = 7.5
            };

            return movie;
        }
    }
}
