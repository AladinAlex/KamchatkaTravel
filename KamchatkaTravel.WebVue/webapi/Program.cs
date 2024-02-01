using KamchatkaTravel.Application;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Application.Services;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using KamchatkaTravel.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
//#if DEBUG
//    .AddJsonFile("appsettings.Development.json");
//#else
    .AddJsonFile("appsettings.json");
//#endif

// Add services to the container.

builder.Services.AddAutoMapper(typeof(KamchatkaTravelAutoMapperProfile));
builder.Services.AddDbContext<KamchatkaTravelDbContext>(
    c => c.UseSqlServer(builder.Configuration.GetConnectionString("DbTravel")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITourService, TourService>();
builder.Services.AddTransient<ITourRepository, TourRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("VuePolicy",
        builder =>
        {
            builder
                .WithOrigins("https://localhost:5002")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();

            //.AllowAnyOrigin()
            //.AllowAnyHeader()
            //.AllowAnyMethod();

        });
});

//builder.Services.AddControllers();

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
});
    //.AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseCors("VuePolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
