using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovieById(Guid movieId);
        Task<List<Movie>> GetAllMovies();
        Task<Guid> AddMovie(Movie movie);
        Task DeleteMovie(Guid movieId);
    }
}
