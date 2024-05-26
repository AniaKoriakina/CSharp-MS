namespace Core.Sagas.Events;

public class ReviewCreated
{
    public Guid ReviewId { get; set; }
    public Guid UserId { get; set; }
}