using Domain.Interfaces;
using Infastracted.Connections;
using Infastracted.Data;
using Services;
using Services.Interfaces;
using Core.Services.RabbitMq;
using Core.Services.RabbitMq.interfaces;
using Core.Services.HttpLogic.Interfaces;
using Core.Services.HttpLogic;
using Core.RabbitMq;

namespace Api
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<MovieService>();

            services.AddScoped<IMovieFilter, FilterRepository>();
            services.AddScoped<FilterService>();

            services.AddScoped<ICreateReview, CreateReview>();

            services.AddScoped<IReviewSystem, ReviewRepository>();
            services.AddScoped<CreateReview>();

            services.AddScoped<ICheckUser, CheckUser>();

            services.AddScoped<IRabbitMqService, RabbitMqService>();
            services.AddHostedService<RabbitMqListener>();

            services.AddScoped<IHttpConnectionService, HttpConnectionService>();
            services.AddScoped<IHttpRequestService, HttpRequestService>();

            services.AddControllers();
        }
    }
}
