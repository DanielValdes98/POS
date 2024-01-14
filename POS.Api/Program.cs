using POS.Application.Extensions;
using POS.Infrastucture.Extensions;

// Se crea el constructor de la aplicaci�n web
var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor de servicios
builder.Services.AddInjectionInfrastucture(builder.Configuration);
builder.Services.AddInjectionApplication(builder.Configuration);

// Se a�aden controladores MVC a los servicios
builder.Services.AddControllers();

// Se a�aden servicios para Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Se construye la aplicaci�n
var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Si estamos en entorno de desarrollo, se habilita Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirecci�n HTTPS
app.UseHttpsRedirection();

// Autorizaci�n
app.UseAuthorization();

// Mapeo de controladores MVC
app.MapControllers();

// Se ejecuta la aplicaci�n
app.Run();

// Para hacer pruebas unitarios y sea accesible a la capa de Test
public partial class Program { }
