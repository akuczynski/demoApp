using WebApp1;
using ElectronNET.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddElectron();
builder.WebHost.UseElectron(args);

// Add services to the container.
builder.Services.AddRazorPages();


await builder.AddApplicationAsync<AppModule>();

var app = builder.Build();


if (HybridSupport.IsElectronActive)
{
    var window = await Electron.WindowManager.CreateWindowAsync();
    window.OnClosed += () => {
        Electron.App.Quit();
    };
} 

await app.InitializeApplicationAsync();
await app.RunAsync();
 