using Core.TraceIdLogic.Interfaces;
using Core.TraceLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TraceIdLogic
{
    public static class StartupTraceId
    {
        public static IServiceCollection TryAddTraceID(this IServiceCollection services)
        {
            services.AddScoped<TraceIdAccessor>();
            services.TryAddScoped<ITraceWriter>(provider => provider.GetRequiredService<TraceIdAccessor>());
            services.TryAddScoped<ITraceReader>(provider => provider.GetRequiredService<TraceIdAccessor>());
            services.TryAddScoped<ITraceIdAccessor>(provider => provider.GetRequiredService<TraceIdAccessor>());
            return services;
        }
    }
}
