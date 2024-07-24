using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Agrega servicios de Ocelot
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Servicios de CORS
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
    

var app = builder.Build();

//Uso de Ocelot
app.UseOcelot();

//Uso del Middleware CORS
app.UseCors("CorsPolicy");

//configuración pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

