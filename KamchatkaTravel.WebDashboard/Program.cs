using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Application.Services;
using KamchatkaTravel.Application;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using KamchatkaTravel.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using KamchatkaTravel.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using KamchatkaTravel.Identity.Models;
using KamchatkaTravel.Identity.Interfaces;
using KamchatkaTravel.Identity.Repositories;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
//#if DEBUG
//    .AddJsonFile("appsettings.Development.json");
//#else
    .AddJsonFile("appsettings.json");
//#endif

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(KamchatkaTravelAutoMapperProfile));
builder.Services.AddDbContext<KamchatkaTravelDbContext>(
    c => c.UseSqlServer(builder.Configuration.GetConnectionString("DbTravel")));
builder.Services.AddDbContext<KamchatkaTravelIdentityDbContext>(
    c => c.UseSqlServer(builder.Configuration.GetConnectionString("DbIdentity")));

builder.Services.AddIdentity<IdentityPerson, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<KamchatkaTravelIdentityDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy =>
        policy.RequireRole("SuperAdmin", "Admin", "User", "Visitor"));
});
// Add services to the container.

builder.Services.AddScoped<IDataRepository, DataRepository>();
//builder.Services.AddTransient<IDataService, DataService>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddTransient<IDashboardService, DashboardService>();

builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();
builder.Services.AddTransient<IIdentityService, IdentityService>();

//builder.Services.AddScoped<IUserStore<IdentityPerson>, IdentityPersonStore>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
