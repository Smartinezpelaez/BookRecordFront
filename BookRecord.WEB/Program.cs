
using BookRecord.WEB;
using BookRecord.WEB.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Services

builder.Services.AddScoped<AutoresService>();
builder.Services.AddScoped<LibrosServices>();

// Configurar MudBlazor
builder.Services.AddMudBlazorDialog();
builder.Services.AddMudBlazorSnackbar();
builder.Services.AddMudBlazorResizeListener();
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



await builder.Build().RunAsync();
