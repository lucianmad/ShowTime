using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Services;
using ShowTime.Components;
using ShowTime.DataAccess;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories;
using ShowTime.DataAccess.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ShowTimeContext");
builder.Services.AddDbContext<ShowTimeDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth-token";
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
builder.Services.AddTransient<IFestivalRepository, FestivalRepository>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<ILineupRepository, LineupRepository>();

builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IFestivalService, FestivalService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<ILineupService, LineupService>();
builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddMudServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();