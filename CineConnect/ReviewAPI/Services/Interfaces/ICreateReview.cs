using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    /// <summary>
    /// Интерфейс для создания отзывов.
    /// </summary>
    public interface ICreateReview
    {
        /// <summary>
        /// Создает новый отзыв.
        /// </summary>
        /// <param name="review">Отзыв.</param>
        /// <returns>Идентификатор созданного отзыва.</returns>
        Task<Guid> CreateReviewAsync(Review review);
    }
}
