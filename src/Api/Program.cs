using Andreani.Arq.Observability.Extensions;
using Andreani.Arq.WebHost.Extension;
using Microsoft.AspNetCore.Builder;
using PruebaAPI.Application.Boopstrap;
using PruebaAPI.Infrastructure.Boopstrap;


var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.AddObservability();

var app = builder.Build();

app.UseObservability();
app.ConfigureAndreani();

app.Run();
