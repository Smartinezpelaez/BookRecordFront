
using BookRecord.WEB;
using BookRecord.WEB.Models;
using BookRecord.WEB.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
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

// Configurar DbContext para la base de datos
var connectionString = "Server=DESKTOP-I0OTQSJ\\SQLEXPRESS;Database=BookRecord;User ID=UserBookRecord;Password=123456;TrustServerCertificate=Yes";
builder.Services.AddDbContext<BookRecordContext>(options => options.UseSqlServer(connectionString));


//builder.Services.AddDbContext<BookRecordContext>(options =>
//            options.UseSqlServer("Server=DESKTOP-I0OTQSJ\\SQLEXPRESS;Database=BookRecord;User ID=UserBookRecord;Password=123456;TrustServerCertificate=Yes"));


await builder.Build().RunAsync();
