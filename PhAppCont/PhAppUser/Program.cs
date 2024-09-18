using Microsoft.EntityFrameworkCore;
using System;
using PhAppUser.Infrastructure.Context;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; //connector
using DotNetEnv; // Importar DotNetEnv para manejar el archivo .env

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables de entorno desde el archivo .env
Env.Load();

// Obtener la cadena de conexión desde las variables de entorno
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

// Configuración de DbContext para MySql utilizando la cadena de conexión del .env
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseMySql(connectionString, 
    new MySqlServerVersion(new Version(8, 0, 2))));

// Configuración de CORS
builder.Services.AddCors("AllowAll", builder => builder
    .AllowAnyOrigin() 
    .AllowAnyMethod()
    .AllowAnyHeader());

// Controladores o servicios relacionados PhAppGateway
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configuración de HTTP requeridas por el pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Aplicación de la política de CORS
app.UseCors("AllowAll");

app.UseAuthorization();

// Mapeo de endpoints de API
app.MapControllers();
app.MapRazorPages();

app.Run();

