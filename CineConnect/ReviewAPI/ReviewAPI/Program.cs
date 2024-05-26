using Api;
using Core.Sagas;
using Core.Sagas.Handlers;
using Core.Semaphore;
using Core.Services.HttpLogic;
using Core.TraceIdLogic;
using MassTransit;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Startup.ConfigureServices(builder.Services);
StartupTraceId.TryAddTraceID(builder.Services);
HttpServiceStartup.AddHttpRequestService(builder.Services);

builder.Services.AddSingleton<IDistributedSemaphore>(sp => 
    new RedisSemaphore("localhost:6379"));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateUserHandler>();
    x.AddConsumer<CreateReviewHandler>();

    x.AddSagaStateMachine<CreateUserAndReviewSaga, CreateUserAndReviewSagaInstance>()
        .InMemoryRepository();

    x.UsingRabbitMq((context, cfg) =>
    {
        
        cfg.Host("rabbitmq://localhost", h => { });

        cfg.ReceiveEndpoint("create-user-and-review-saga", e =>
        {
            e.ConfigureSaga<CreateUserAndReviewSagaInstance>(context);
        });

        cfg.ReceiveEndpoint("user-service", e =>
        {
            e.ConfigureConsumer<CreateUserHandler>(context);
        });

        cfg.ReceiveEndpoint("review-service", e =>
        {
            e.ConfigureConsumer<CreateReviewHandler>(context);
        });
    });
});
builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<TraceIdMiddleware>();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
