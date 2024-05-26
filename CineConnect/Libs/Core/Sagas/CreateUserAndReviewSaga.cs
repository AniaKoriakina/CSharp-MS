using Core.Sagas.Commands;
using Core.Sagas.Events;
using MassTransit;
using MassTransit.Mediator;

using Microsoft.Extensions.Logging;

namespace Core.Sagas;

 public class CreateUserAndReviewSaga : MassTransitStateMachine<CreateUserAndReviewSagaInstance>
{
    private readonly ILogger<CreateUserAndReviewSaga> _logger;

    public CreateUserAndReviewSaga(ILogger<CreateUserAndReviewSaga> logger)
    {
        _logger = logger;

        InstanceState(x => x.CurrentState);

        Event(() => UserCreatedEvent, x => x.CorrelateById(context => context.Message.UserId));
        Event(() => CreateReviewCommand, x => x.CorrelateById(context => context.Message.UserId));

        Initially(
            When(UserCreatedEvent)
                .Then(context =>
                {
                    context.Saga.UserId = context.Message.UserId;
                    context.Saga.Email = context.Message.Email;
                    context.Saga.UserName = context.Message.UserName;
                })
                .TransitionTo(UserCreated)
                .Publish(context => new CreateUser(context.Message.UserId, context.Message.Email, context.Message.UserName))
                .Catch<Exception>(ex => ex
                    .Then(context => _logger.LogError("Error creating user: {Message}"))
                    .TransitionTo(Failed)));

        During(UserCreated,
            When(CreateReviewCommand)
                .Then(context => { context.Instance.ReviewId = context.Data.ReviewId; })
                .Publish(context => new CreateReview(context.Instance.ReviewId, context.Instance.UserId))

                .TransitionTo(ReviewCreated)
                .Catch<Exception>(ex => ex
                    .Then(context => _logger.LogError("Error creating review: {Message}"))
                    .TransitionTo(Failed)));

        DuringAny(
            When(Failed.Enter)
                .Then(context => _logger.LogError("Error for UserId: {UserId}", context.Instance.UserId))
                .Finalize());

        SetCompletedWhenFinalized();
    }

    public State Failed { get; private set; } = null!;
    public State UserCreated { get; private set; } = null!;
    public State ReviewCreated { get; private set; } = null!;

    public Event<UserCreated> UserCreatedEvent { get; private set; } = null!;
    public Event<CreateReview> CreateReviewCommand { get; private set; } = null!;
}
