using Domain.Entities;
using Microsoft.Extensions.Hosting;
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
        Task<Review[]> GetAllAsync();
        Task<List<Review>> GetReviewsForMovie(Guid moveId);
    }
}
