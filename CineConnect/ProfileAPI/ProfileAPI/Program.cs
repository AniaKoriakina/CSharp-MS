using Dal;
using Logic;
using Logic.Users.Interfaces;
using Core.HttpLogic;
using Core.TraceIdLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

StartupTraceId.TryAddTraceID(builder.Services);
HttpServiceStartup.AddHttpRequestService(builder.Services);

builder.Services.TryAddLogic();
builder.Services.TryAddDal();

var app = builder.Build();

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
