using Microsoft.AspNetCore.ResponseCompression;
using ReportProjectV1.Client;
using ReportProjectV1.Client.Services;

using ReportProjectV1.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddHttpClient();
builder.Services.AddCors(p => p.AddPolicy(name: "corspolicy", build =>
{
/*    build.AllowAnyHeader();
    build.AllowAnyMethod();
    build.AllowAnyOrigin();
    build.
    build.WithOrigins("http://localhost:5242");*/
   build.WithOrigins("http://localhost:5242").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("corspolicy");


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
