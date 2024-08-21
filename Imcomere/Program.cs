using Blazored.LocalStorage;
using Imcomere;
using Imcomere.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazoredLocalStorage();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(sp => new LocalStorage(sp.GetRequiredService<IJSRuntime>()));
builder.Services.AddSingleton(sp => new Cart(sp.GetRequiredService<LocalStorage>()));

await builder.Build().RunAsync();
