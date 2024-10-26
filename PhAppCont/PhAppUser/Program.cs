using Microsoft.EntityFrameworkCore;
using PhAppUser.Infrastructure.Context;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using DotNetEnv;
using PhAppUser.Application.Interfaces;
using PhAppUser.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuración básica de Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Cargar las variables de entorno desde el archivo .env
Env.Load();

// Configuración de la cadena de conexión
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión no está configurada en el archivo .env.");
}

// Configuración de DbContext para MySQL
builder.Services.AddDbContext<PhAppUserDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 2))));

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Registro de repositorios
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<IRepLegalRepository, RepLegalRepository>();
builder.Services.AddScoped<IContadorRepository, ContadorRepository>();
builder.Services.AddScoped<IEntSaludRepository, EntSaludRepository>();
builder.Services.AddScoped<IEntPensionRepository, EntPensionRepository>(); // Corregido de "IEnPensionRepository"
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();

// Servicios adicionales
builder.Services.AddScoped<IValidationService, ValidationService>();

// Configuración de controladores
builder.Services.AddControllers();

var app = builder.Build();

// Middleware para manejo de errores
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        // Registro de la excepción en el logger
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error ocurrido durante la solicitud.");

        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Ocurrió un error en el servidor.");
    }
});

// Configuración de HTTP requerida por el pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

