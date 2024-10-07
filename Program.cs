using DotNetEnv;
using HotelAPI.Data;
using HotelAPI.Repositories;
using HotelAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Environment
Env.Load();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Configure the database connection string.
var conectionDB = $"server={dbHost};port={dbPort};database={dbDatabaseName};uid={dbUser};password={dbPassword}";

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(conectionDB, ServerVersion.Parse("8.0.20-mysql"))
);

builder.Services.AddScoped<IBookingRepository, BookingServices>();
builder.Services.AddScoped<IGuestRepository, GuestServices>();
builder.Services.AddScoped<IRoomRepository, RoomServices>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWelcomePage(new WelcomePageOptions
{
    Path = "/"
});

app.MapControllers();

app.Run();
