using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Logic.Users;
using Logic.Users.Interfaces;

namespace Logic
{
    public static class LogicStartUp
    {
        public static IServiceCollection TryAddLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped<IUserLogicManager, UserLogicManager>();
            return serviceCollection;
        }
    }
}
