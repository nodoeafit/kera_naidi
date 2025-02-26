using System.Runtime.CompilerServices;
using System.Text;
using KeraNaidi.Data;
using KeraNaidi.Data.Entities;
using KeraNaidi.Interfaces;
using KeraNaidi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quetzalcoatl.Business.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<KeraNaidiContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("KeraNaidi"))
);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.

builder.Services.AddScoped<IBateriasService, BateriasService>();
builder.Services.AddTransient<IHealthService, HealthService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<KeraNaidiContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>{
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
        };
    });





var app = builder.Build();
PopulateDb(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


# region Db Populate
async void PopulateDb(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        await unitOfWork.HealthRepository.AddAsync(new KeraNaidi.Data.Models.HealthCheck{
            Date = DateTime.Now,
            Message = "DB Check is Complete"
        });


        // var seedAdmin = scope.ServiceProvider.GetRequiredService<IUserService>();
        // await seedAdmin.SeedAdmin();
    }
}
#endregion