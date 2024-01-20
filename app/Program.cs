using Microsoft.Extensions.DependencyInjection;
using app.Components;
using DataLayer;
using DataLayer.Auction;
using DataLayer.UserService;
using DataLayer.AdminService;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage(); // local storage
builder.WebHost.UseStaticWebAssets();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IAdminService, AdminService>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IAuctionRepository, AuctionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
