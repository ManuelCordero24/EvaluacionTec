using System;
using Microsoft.EntityFrameworkCore;
using Prospectos1.Datos;
using Prospectos1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Conexion a la BD usando la configuracion puesta en appsettings.json
builder.Services.AddDbContext<contextoBD>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
