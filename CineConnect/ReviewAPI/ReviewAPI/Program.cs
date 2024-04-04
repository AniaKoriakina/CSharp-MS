using Api;
using Core.HttpLogic;
using Core.TraceIdLogic;
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
