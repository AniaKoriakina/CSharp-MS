using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с системой отзывов.
    /// </summary>
    public interface IReviewSystem
    {
        /// <summary>
        /// Добавляет новый отзыв.
        /// </summary>
        /// <param name="review">Отзыв для добавления.</param>
        /// <returns>Идентификатор добавленного отзыва.</returns>
        Task<Guid> AddReview(Review review);

        /// <summary>
        /// Получает список всех отзывов.
        /// </summary>
        /// <returns>Список отзывов.</returns>
        Task<List<Review>> GetAllReviews();

        /// <summary>
        /// Получает список отзывов для определенного фильма.
        /// </summary>
        /// <param name="moveId">Идентификатор фильма.</param>
        /// <returns>Список отзывов для указанного фильма.</returns>
        Task<List<Review>> GetReviewsForMovie(Guid moveId);
    }
}
