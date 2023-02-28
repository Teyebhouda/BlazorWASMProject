using Blazored.LocalStorage;
using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReportProjectV1.Client;
using ReportProjectV1.Client.Services;
using ReportProjectV1.Client.ServicesImplementation;


using ReportProjectV1.Shared.Models;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient();

builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddBlazoredToast();
builder.Services.AddJSWindow();
builder.Services.AddAuthorizationCore();
builder.Services.AddJSWindow();

builder.Services.AddScoped(typeof(IGenericServices<>), typeof(GenericServices<>));
builder.Services.AddScoped<IAuthService, AuthService>(); ;
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

  
var host = builder.Build();
var authenticationService = host.Services.GetRequiredService<AuthenticationService>();
//await authenticationService.Initialize();

await builder.Build().RunAsync();
 static async Task Main(string[] args)
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("app");

    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

    builder.Services.AddAuthorizationCore();
    builder.Services.AddBlazoredLocalStorage();
   
  

    await builder.Build().RunAsync();
}


