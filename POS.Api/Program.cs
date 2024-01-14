using POS.Application.Extensions;
using POS.Infrastucture.Extensions;

// Se crea el constructor de la aplicación web
var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor de servicios
builder.Services.AddInjectionInfrastucture(builder.Configuration);
builder.Services.AddInjectionApplication(builder.Configuration);

// Se añaden controladores MVC a los servicios
builder.Services.AddControllers();

// Se añaden servicios para Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Se construye la aplicación
var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Si estamos en entorno de desarrollo, se habilita Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirección HTTPS
app.UseHttpsRedirection();

// Autorización
app.UseAuthorization();

// Mapeo de controladores MVC
app.MapControllers();

// Se ejecuta la aplicación
app.Run();

// Para hacer pruebas unitarios y sea accesible a la capa de Test
public partial class Program { }
