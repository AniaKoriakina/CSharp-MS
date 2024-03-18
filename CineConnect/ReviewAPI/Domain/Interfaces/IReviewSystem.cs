using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReviewSystem
    {
        Task<Guid> AddReview(Review review);
        Task<List<Review>> GetAllReviews();
        Task<List<Review>> GetReviewsForMovie(Guid moveId);
    }
}
