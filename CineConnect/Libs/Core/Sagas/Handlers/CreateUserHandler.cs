using Core.Sagas.Commands;
using Core.Sagas.Events;
using MassTransit;

namespace Core.Sagas.Handlers;

public class CreateUserHandler : IConsumer<CreateUser>
{
    public async Task Consume(ConsumeContext<CreateUser> context)
    {
        var userId = context.Message.UserId;
        var email = context.Message.Email;
        var userName = context.Message.UserName;
        
        await Console.Out.WriteLineAsync($"Пользователь {userId} создан с email {email}");

        var userCreated = new UserCreated
        {
            UserId = userId,
            Email = email,
            UserName = userName
        };
        
        await context.Publish(userCreated);
    }
}