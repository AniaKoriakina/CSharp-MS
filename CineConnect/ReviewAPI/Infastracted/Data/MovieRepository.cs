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
        /// <inheritdoc />
        public async Task<Guid> AddMovie(Movie movie)
        {
            return Guid.NewGuid();
        }

        /// <inheritdoc />
        public async Task DeleteMovie(Guid movieId)
        {
            Console.WriteLine($"Фильм с идентификатором {movieId} удален.");
        }

        /// <inheritdoc />
        public async Task<List<Movie>> GetAllMovies()
        {
            return new List<Movie>();
        }

        /// <inheritdoc />
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
