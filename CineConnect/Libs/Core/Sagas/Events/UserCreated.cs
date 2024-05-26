namespace Core.Sagas.Events;

public class UserCreated
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
}