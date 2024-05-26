using Core.Services.RabbitMq.interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using Core.Sagas.Events;
using MassTransit;

namespace Api.Controllers
{
    public record ReviewListResponse
    {
        [Required]
        public ReviewResponse[] ReviewList { get; init; }
    }

    public record ReviewResponse
    {
        [JsonProperty("id")]
        [Required]
        public Guid ReviewId { get; init; }

        [JsonProperty("userId")]
        [Required]
        public Guid UserId { get; init; }

        [JsonProperty("userName")]
        [Required]
        public UserNameResponse UserName { get; init; }

        [JsonProperty("selectedMovie")]
        [Required]
        public Movie SelectedMovie { get; init; }

        [JsonProperty("viewingDate")]
        [Required]
        public DateTime ViewingDate { get; init; }

        [JsonProperty("reviewText")]
        [Required]
        [MaxLength(500)]
        public string ReviewText { get; init; }

        [JsonProperty("rating")]
        [Required]
        [Range(1, 5)]
        public int Rating { get; init; }
    }

    public record ReviewRequest
    {
        [Required]
        public Guid UserId { get; init; }

        [Required]
        public Movie SelectedMovie { get; init; }

        [Required]
        public DateTime ViewingDate { get; init; }

        [Required]
        [MaxLength(500)]
        public string ReviewText { get; init; }

        [Required]
        [Range(1,5)]
        public int Rating { get; init; }
    }

    public record UserNameResponse
    {
        [Required]
        public string Name {  get; init; }
    }

    [Route("api/review")]
    public class ReviewController : ControllerBase
    {
        private readonly ICreateReview _reviewSystem;
        private readonly IRabbitMqService _rabbitMqService;
        private readonly IBus _bus;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(ICreateReview reviewSystem, IRabbitMqService rabbitMqService, IBus bus,
            ILogger<ReviewController> logger)
        {
            _reviewSystem = reviewSystem;
            _rabbitMqService = rabbitMqService;
            _bus = bus;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType<ReviewListResponse>(200)]
        public async Task<IActionResult> GetReviewListAsync()
        {
            var res = await _reviewSystem.GetReviewListAsync();

            var response = new ReviewListResponse
            {
                ReviewList = res.Select(val => new ReviewResponse
                {
                    ReviewId = val.ReviewId,
                    UserId = val.UserId,
                    UserName = new UserNameResponse
                    {
                        Name = val.UserName.Name
                    },
                    SelectedMovie = val.SelectedMovie,
                    ViewingDate = val.ViewingDate,
                    ReviewText = val.ReviewText,
                    Rating = val.Rating
                }).ToArray()
            };

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> AddReviewAsync([FromBody] ReviewRequest request)
        {
            var reviewId = Guid.NewGuid();

            var review = new Review
            {
                ReviewId = reviewId, 
                UserId = request.UserId,
                SelectedMovie = request.SelectedMovie,
                ViewingDate = request.ViewingDate,
                ReviewText = request.ReviewText,
                Rating = request.Rating,
            };

            await _reviewSystem.CreateReviewAsync(review);

            var reviewCreated = new ReviewCreated
            {
                ReviewId = reviewId, 
                UserId = review.UserId
            };

            await _bus.Publish(reviewCreated);

            _rabbitMqService.SendMessage(request.ToString());

            _logger.LogInformation("Ревью {ReviewId} создано успешно для пользователя {UserId}", reviewId,
                review.UserId);

            return Ok();
        }
    }
}
