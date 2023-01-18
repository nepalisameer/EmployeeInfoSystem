using EmployeeISBlazer.Repository;
using EmployeeISBlazer;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorStrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IEmployeeIS, EmployeeIS>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7244/") });
builder.Services.AddBlazorStrap();
await builder.Build().RunAsync();
