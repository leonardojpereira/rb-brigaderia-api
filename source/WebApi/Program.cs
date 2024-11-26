using Microsoft.EntityFrameworkCore;
using Project.Converters;
using Project.WebApi.Configurations;
using Project.Application.Services;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Infrastructure.Data.Repositories;
using System.IO;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration); // SwaggerConfiguration já está incluído aqui

builder.Services.AddScoped<IVendasCaixinhasMetricsService, VendasCaixinhasMetricsService>();
builder.Services.AddScoped<IVendasCaixinhasRepository, VendasCaixinhasRepository>();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Configuração do conversor para TimeSpan
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter());
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowSpecificOrigin");
}

app.UseSwaggerConfiguration();

app.UseHealthChecks("/health");
app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
