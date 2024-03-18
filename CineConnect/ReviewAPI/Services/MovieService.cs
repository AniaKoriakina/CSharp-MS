using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Guid> AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddMovie(movie);
            return movie.MovieId;
        }

        public async Task DeleteMovieAsync(Guid movieId)
        {
            await _movieRepository.DeleteMovie(movieId);
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMovies();
        }

        public async Task<Movie> GetMovieByIdAsync(Guid movieId)
        {
            return await _movieRepository.GetMovieById(movieId);
        }
    }
}
