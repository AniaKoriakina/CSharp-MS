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
    public class FilterService : IFilterService
    {
        private readonly IMovieFilter _movieFilter;

        public FilterService(IMovieFilter movieFilter)
        {
            _movieFilter = movieFilter;
        }

        public async Task<List<Movie>> FilterMoviesAsync(Filter filter)
        {
            return await _movieFilter.FilterMovies(filter);
        }
    }
}
