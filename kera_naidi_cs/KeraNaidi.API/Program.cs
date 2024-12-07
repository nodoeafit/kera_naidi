using System.Runtime.CompilerServices;
using KeraNaidi.Data;
using KeraNaidi.Interfaces;
using KeraNaidi.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IHealthService, HealthService>();

builder.Services.AddDbContext<KeraNaidiContext>(
    opt => opt.UseInMemoryDatabase("KeiraNaidi")
);
var app = builder.Build();
PopulateDb(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


# region Db Populate
async void PopulateDb(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var healthService = scope.ServiceProvider.GetRequiredService<IHealthService>();
        await healthService.AddHealthCheck(new KeraNaidi.Data.Models.HealthCheck{
            Date = DateTime.Now,
            Message = "DB Check is Complete"
        });
        
    }
}
#endregion