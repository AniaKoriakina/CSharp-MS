using Core.HttpLogic.Services.Interfaces;
using Core.HttpLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HttpLogic
{
    /// <summary>
    /// Регистрация в DI сервисов для HTTP-соединений
    /// </summary>
    public static class HttpServiceStartup
    {
        /// <summary>
        /// Добавление сервиса для осуществления запросов по HTTP
        /// </summary>
        public static IServiceCollection AddHttpRequestService(this IServiceCollection services)
        {
            services
                .AddHttpContextAccessor()
                .AddHttpClient()
                .AddTransient<IHttpConnectionService, HttpConnectionService>();

            services.TryAddTransient<IHttpRequestService, HttpRequestService>();

            return services;
        }
    }
}
