namespace Core.Sagas.Commands;

public record CreateReview(Guid ReviewId, Guid UserId);