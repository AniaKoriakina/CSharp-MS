using MassTransit;

namespace Core.Sagas;

public class CreateUserAndReviewSagaInstance : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public string CurrentState { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public Guid ReviewId { get; set; }
}