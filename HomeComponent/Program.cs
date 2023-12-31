using Blazored.LocalStorage;
using HomeComponent;
using HomeComponent.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddHttpClient<GenericService<T>>(Uri =>
//{
//    Uri.baseAddress = new Uri("URI");
//});
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:54349/HomePage") });
builder.Services.AddTelerikBlazor();

builder.Services.AddHttpClient<HomeUIService>(
    client =>
    {
        client.BaseAddress = new Uri("http://localhost:53258/HomePage");


    });

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    builder.WithOrigins("https://localhost:7194")
//           .AllowAnyMethod()
//           .AllowAnyHeader());
//});
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:54349") });
//builder.Services.AddSingleton<HomeUIService>();
builder.Services.AddBlazoredLocalStorage(); 
var app = builder.Build();
await app.RunAsync();
