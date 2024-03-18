using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastracted.Data
{
    public class FilterRepository : IMovieFilter
    {

        private readonly IMovieRepository _movieRepository;

        public FilterRepository(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> FilterMovies(Filter filter)
        {
            var allMovies = _movieRepository.GetAllMovies().Result;

            var filteredMovies = allMovies.Where(movie =>
                (filter.MovieId == Guid.Empty || movie.MovieId == filter.MovieId) &&
                (filter.GenreId == Guid.Empty || movie.GenreId == filter.GenreId) &&
                (string.IsNullOrEmpty(filter.Title) || movie.Title.Contains(filter.Title)) &&
                (filter.ReleaseYear == default || movie.ReleaseYear == filter.ReleaseYear) &&
                (movie.Rating >= filter.MinRating && movie.Rating <= filter.MaxRating) &&
                (movie.ReleaseYear >= filter.MinReleaseYear && movie.ReleaseYear <= filter.MaxReleaseYear)).ToList();

            return filteredMovies;
        }
    }
}
