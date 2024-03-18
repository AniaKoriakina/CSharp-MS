using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    /// <summary>
    /// Интерфейс для фильтрации фильмов.
    /// </summary>
    public interface IFilterService
    {
        /// <summary>
        /// Фильтрует список фильмов по заданным критериям.
        /// </summary>
        /// <param name="filter">Критерии фильтрации.</param>
        /// <returns>Отфильтрованный список фильмов.</returns>
        Task<List<Movie>> FilterMoviesAsync(Filter filter);
    }
}
