using Microsoft.Extensions.DependencyInjection;
using app.Components;
using DataLayer;
using DataLayer.Auction;
using DataLayer.UserService;
using DataLayer.AdminService;
using DataLayer.AuctionUpdateService;
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
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IBidRepository, BidRepository>();
builder.Services.AddSingleton<IAuctionRepository, AuctionRepository>();
builder.Services.AddSingleton<AuctionUpdateService>();

var app = builder.Build();

//setup automatic AuctionUpdateState
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var auctionUpdateService = services.GetRequiredService<AuctionUpdateService>();

    // Start the timer for updating auctions
    auctionUpdateService.Start();
}

// configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
