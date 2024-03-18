using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastracted.Data
{
    /// <summary>
    /// Репозиторий для работы с отзывами.
    /// </summary>
    public class ReviewRepository : IReviewSystem
    {
        /// <inheritdoc />
        public async Task<Guid> AddReview(Review review)
        {
            return Guid.NewGuid();
        }

        /// <inheritdoc />
        public async Task<List<Review>> GetAllReviews()
        {
            return new List<Review>();
        }

        /// <inheritdoc />
        public async Task<List<Review>> GetReviewsForMovie(Guid movieId)
        {
            return new List<Review>();
        }
    }
}
