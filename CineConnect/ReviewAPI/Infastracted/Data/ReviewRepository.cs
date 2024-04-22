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
        /// <summary>
        /// Добавляет новый отзыв.
        /// </summary>
        /// <param name="review">Отзыв для добавления.</param>
        /// <returns>Идентификатор добавленного отзыва.</returns>
        public async Task<Guid> AddReview(Review review)
        {
            return Guid.NewGuid();
        }

        public Task<Review[]> GetAllAsync()
        {
            return Task.FromResult(new Review[] { });
        }

        /// <summary>
        /// Получает все отзывы.
        /// </summary>
        /// <returns>Список всех отзывов.</returns>
        public async Task<List<Review>> GetAllReviews()
        {
            return new List<Review>();
        }

        /// <summary>
        /// Получает отзывы для указанного фильма.
        /// </summary>
        /// <param name="movieId">Идентификатор фильма.</param>
        /// <returns>Список отзывов для указанного фильма.</returns>
        public async Task<List<Review>> GetReviewsForMovie(Guid movieId)
        {
            return new List<Review>();
        }
    }
}
