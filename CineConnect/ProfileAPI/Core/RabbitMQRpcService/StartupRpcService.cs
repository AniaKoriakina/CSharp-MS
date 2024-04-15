using Core.TraceIdLogic.Interfaces;
using Core.TraceIdLogic;
using Core.TraceLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQRpcService
{
    public static class StartupRpcService
    {
        public static IServiceCollection AddRpcService(this IServiceCollection services)
        {
            services.AddSingleton<RpcClient>();
            return services;
        }
    }
}
