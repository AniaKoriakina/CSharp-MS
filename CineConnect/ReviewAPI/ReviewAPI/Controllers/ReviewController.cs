﻿using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
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

    [Route("api/review")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewSystem _reviewSystem;

        public ReviewController(IReviewSystem reviewSystem)
        {
            _reviewSystem = reviewSystem;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> AddReviewAsync([FromBody] ReviewRequest request)
        {
            var review = new Review
            {
                UserId = request.UserId,
                SelectedMovie = request.SelectedMovie,
                ViewingDate = request.ViewingDate,
                ReviewText = request.ReviewText,
                Rating = request.Rating,
            };
            await _reviewSystem.AddReview(review);
            return Ok();
        }
    }
}
