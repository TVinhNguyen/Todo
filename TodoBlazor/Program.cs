using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoBlazor;
using TodoBlazor.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<TodoService>();

builder.Services.AddScoped<ITokenService,TokenService>();

builder.Services.AddSingleton<AuthState>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddTransient<AuthMessageHandler>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5289") 
});



await builder.Build().RunAsync();
