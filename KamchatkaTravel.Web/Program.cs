using KamchatkaTravel.Application;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Application.Services;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using KamchatkaTravel.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
#if DEBUG
    .AddJsonFile("appsettings.Development.json");
#else
    .AddJsonFile("appsettings.json");
#endif

builder.Services.AddControllersWithViews();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(KamchatkaTravelAutoMapperProfile));
builder.Services.AddDbContext<KamchatkaTravelDbContext>(
    c => c.UseSqlServer(builder.Configuration.GetConnectionString("DbTravel")));
// Add services to the container.

builder.Services.AddTransient<ITourService, TourService>();
builder.Services.AddTransient<ITourRepository, TourRepository>();

//builder.Services.AddTransient<IAdminService, AdminService>();
//builder.Services.AddTransient<IAdminRepository, AdminRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseHsts();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
