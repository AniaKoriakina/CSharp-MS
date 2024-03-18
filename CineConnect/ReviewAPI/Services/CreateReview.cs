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
    public class CreateReview : ICreateReview
    {
        private readonly IReviewSystem _reviewSystem;
        private readonly ICheckUser _checkUser;

        public CreateReview(IReviewSystem reviewSystem, ICheckUser checkUser)
        {
            _reviewSystem = reviewSystem;
            _checkUser = checkUser;
        }

        public async Task<Guid> CreateReviewAsync(Review review)
        {
            if (!await _checkUser.CheckUserValidAsync(review.UserId)) 
            {
                throw new Exception("Неверный пользователь");
            }

            var id = await _reviewSystem.AddReview(review);

            return id;
        }
    }
}
