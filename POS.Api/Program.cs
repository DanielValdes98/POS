using POS.Api.Extensions;
using POS.Application.Extensions;
using POS.Infrastucture.Extensions;

// Se crea el constructor de la aplicación web
var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

var Cors = "Cors";

// Agregar servicios al contenedor de servicios
builder.Services.AddInjectionInfrastucture(builder.Configuration);
builder.Services.AddInjectionApplication(builder.Configuration);
builder.Services.AddAuthentication(Configuration);

// Se añaden controladores MVC a los servicios
builder.Services.AddControllers();

// Se añaden servicios para Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name : Cors,
        builder =>
        {
            builder.WithOrigins("*"); // Acepta todos los dominios
            builder.AllowAnyMethod(); // Acepta todos los métodos
            builder.AllowAnyHeader(); // Acepta todos los encabezados
        }); 
});

// Se construye la aplicación
var app = builder.Build();

app.UseCors(Cors);

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Si estamos en entorno de desarrollo, se habilita Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirección HTTPS
app.UseHttpsRedirection();

app.UseAuthentication();

// Autorización
app.UseAuthorization();

// Mapeo de controladores MVC
app.MapControllers();

// Se ejecuta la aplicación
app.Run();

// Para hacer pruebas unitarios y sea accesible a la capa de Test
public partial class Program { }
