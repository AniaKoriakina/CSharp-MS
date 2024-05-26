using Core.Sagas.Commands;
using Core.Sagas.Events;
using MassTransit;

namespace Core.Sagas.Handlers;

public class CreateReviewHandler : IConsumer<CreateReview>
{
    public async Task Consume(ConsumeContext<CreateReview> context)
    {
        var reviewId = context.Message.ReviewId;
        var userId = context.Message.UserId;
        
        await Console.Out.WriteLineAsync($"Ревью {reviewId} создано для пользователя {userId}");

        var reviewCreated = new ReviewCreated
        {
            ReviewId = reviewId,
            UserId = userId
        };
        
        await context.Publish(reviewCreated);
    }
}