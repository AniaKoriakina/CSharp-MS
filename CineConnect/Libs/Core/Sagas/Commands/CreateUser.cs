namespace Core.Sagas.Commands;

public record CreateUser(Guid UserId, string Email, string UserName);
