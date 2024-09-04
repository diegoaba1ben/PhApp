//importación de espacios y directivas
using Microsoft.EntityFrameworkCore;
using System;
using PhAppUser.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

//Configuración de DbContext
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Controladores o servicios relacionados PhAppGateway
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
