using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICreateReview
    {
        Task<Guid> CreateReviewAsync(Review review);

        Task<Review[]> GetReviewListAsync();
    }
}
