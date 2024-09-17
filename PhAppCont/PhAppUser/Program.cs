using Microsoft.EntityFrameworkCore;
using System;
using PhAppUser.Infrastructure.Context;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; //connector

var builder = WebApplication.CreateBuilder(args);

//Configuración de DbContext para MySql
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerConnection(new(8,0,32))));

//Controladores o servicios relacionados PhAppGateway
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configuración de  HTTP requeridas por el pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Mapeo de endpoints de API
app.MapControllers();

app.MapRazorPages();

app.Run();
