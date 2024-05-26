using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Semaphore;

namespace Services
{
    public class CreateReview : ICreateReview
    {
        private readonly IReviewSystem _reviewSystem;
        private readonly ICheckUser _checkUser;
        private readonly IDistributedSemaphore _semaphore;
        private const string SemaphoreKey = "review_creation";
        private static readonly TimeSpan SemaphoreTimeout = TimeSpan.FromSeconds(30);

        public CreateReview(IReviewSystem reviewSystem, ICheckUser checkUser, IDistributedSemaphore semaphore)
        {
            _reviewSystem = reviewSystem;
            _checkUser = checkUser;
            _semaphore = semaphore;
        }

        public async Task<Guid> CreateReviewAsync(Review review)
        {
            if (!await _checkUser.CheckUserValidAsync(review.UserId)) 
            {
                throw new Exception("Неверный пользователь");
            }

            if (!await _semaphore.WaitAsync(SemaphoreKey, SemaphoreTimeout))
            {
                try
                {
                    var id = await _reviewSystem.AddReview(review);
                    return id;
                }
                finally
                {
                    await _semaphore.ReleaseAsync(SemaphoreKey);
                }
            }
            else
            {
                throw new Exception("Timeout");
            } 
        }

        public async Task<Review[]> GetReviewListAsync()
        {
            var reviewList = await _reviewSystem.GetAllAsync();
            return reviewList;
        }
    }
}
