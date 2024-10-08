using Microsoft.EntityFrameworkCore;
using System;
using PhAppUser.Infrastructure.Context;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Conector MySQL
using DotNetEnv; // Importar DotNetEnv para manejar el archivo .env
using PhAppUser.Application.Interfaces; // Agrega la interfaz del repositorio
using PhAppUser.Infrastructure.Repositories; // Agrega la implementación del repositorio

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables de entorno desde el archivo .env
Env.Load();

// Obtener la cadena de conexión desde las variables de entorno
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión no está configurada en el archivo .env.");
}

// Configuración de DbContext para MySQL utilizando la cadena de conexión del .env
builder.Services.AddDbContext<PhAppUserDbContext>(options =>
    options.UseMySql(connectionString,
    new MySqlServerVersion(new Version(8, 0, 2))));

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin() // Permitir cualquier origen
                   .AllowAnyMethod() // Permitir cualquier método HTTP (GET, POST, etc.)
                   .AllowAnyHeader(); // Permitir cualquier encabezado
        });
});

// Registro de repositorios
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<IRepLegalRepository, RepLegalRepository>();
builder.Services.AddScoped<IEntidadPrestadoraRepository, EntidadPrestadoraRepository>();
builder.Services.AddScoped<IEntSaludRepository, EntSaludRepository>(); // Cambiado a EntSaludRepository
builder.Services.AddScoped<IPerfilUsuarioRepository, PerfilUsuarioRepository>()
builder.Services.AddScopped<IValidationService, ValidationService>();
// Controladores y servicios relacionados
builder.Services.AddControllers();
// builder.Services.AddRazorPages(); // Si no estás utilizando Razor Pages, puedes comentarlo

var app = builder.Build();

// Configuración de HTTP requerida por el pipeline.
if (app.Environment.IsDevelopment())
{
    // Puedes usar Developer Exception Page o una configuración especial en desarrollo
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll"); // Activar CORS en la aplicación

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
