using Core.Sagas;
using Core.Sagas.Handlers;
using Core.Services.HttpLogic;
using Core.TraceIdLogic;
using Dal;
using Logic;
using Logic.Users.Interfaces;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateUserHandler>();
    x.AddConsumer<CreateReviewHandler>();

    x.AddSagaStateMachine<CreateUserAndReviewSaga, CreateUserAndReviewSagaInstance>()
        .InMemoryRepository();

    x.UsingRabbitMq((context, cfg) =>
    {
        
        cfg.Host("rabbitmq://localhost", h => { });

        cfg.ReceiveEndpoint("create-user-queue", e =>
        {
            e.ConfigureConsumer<CreateUserHandler>(context);
        });

        cfg.ReceiveEndpoint("create-review-queue", e =>
        {
            e.ConfigureConsumer<CreateReviewHandler>(context);
        });

        cfg.ReceiveEndpoint("create-user-and-review-saga", e =>
        {
            e.ConfigureSaga<CreateUserAndReviewSagaInstance>(context);
        });
    });
});
builder.Services.AddMassTransitHostedService();

StartupTraceId.TryAddTraceID(builder.Services);
HttpServiceStartup.AddHttpRequestService(builder.Services);

builder.Services.TryAddLogic();
builder.Services.TryAddDal();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseMiddleware<TraceIdMiddleware>();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
