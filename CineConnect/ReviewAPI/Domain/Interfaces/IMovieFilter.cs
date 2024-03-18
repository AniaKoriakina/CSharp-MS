using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для фильтрации фильмов.
    /// </summary>
    public interface IMovieFilter
    {
        /// <summary>
        /// Фильтрует фильмы по заданным критериям.
        /// </summary>
        /// <param name="filter">Критерии фильтрации.</param>
        /// <returns>Отфильтрованный список фильмов.</returns>
        Task<List<Movie>> FilterMovies(Filter filter);
    }
}
