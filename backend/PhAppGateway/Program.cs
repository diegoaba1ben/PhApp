using Microsoft.AspNetCore.Builder; //Configuración Ocelot
using Microsoft.AspNetCore.SignalR; //Configuración Ocelot
using Microsoft.Extensions.DependencyInjection; //Configuración Ocelot
using Microsoft.Extensions.Configuration; //Configuración Ocelot
using Microsoft.Extensions.Hosting; //Configuración Ocelot
using Ocelot.DependencyInjection; //Configuración Ocelot
using Ocelot.Middleware; //Configuración Ocelot

var builder = WebApplication.CreateBuilder(args);

//Carga de la configuración de Ocelot
builder.Configuration.AddJsonFile("ocelot.json");//Configuración Ocelot

// Configuración de servicios.
builder.Services.AddControllers(); //Configuración Ocelot
builder.Services.AddOcelot(builder.Configuration); //Configuración Ocelot

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de Pipeline de solicitud HTTP.
if (app.Environment.IsDevelopment())
{
    // Configuración de Swagger para la documentación de la API en desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gateway API V1");
    });
}


//Redireccionamiento HTTPS, archivos estáticos y enrutamiento
app.UseHttpsRedirection();
app.UseStaticFiles();//Configuración Ocelot
app.UseRouting();//Configuración Ocelot

//Autorización y autenticación si es necesario
app.UseAuthentication();//Configuración Ocelot
app.UseAuthorization(); //Configuración Ocelot

//Mapeo de controladores y uso de Ocelot para la gestión de proxy API Gateway
app.MapControllers();//Configuración Ocelot
app.UseOcelot().Wait();//Configuración Ocelot



app.Run();

