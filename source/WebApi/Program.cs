
using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Data;
using Project.WebApi.Configurations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    
}
else
{
    app.UseHsts();
}

app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerConfiguration();

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/swagger"));

app.Run();

public partial class Program { }

