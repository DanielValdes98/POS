using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infrastucture.Persistences.Context;
using POS.Infrastucture.Persistences.Interfaces;
using POS.Infrastucture.Persistences.Repositories;

namespace POS.Infrastucture.Extensions
{
    // Clase estática que contendrá la lógica de extensión
    public static class InjectionExtensions
    {
        // Método de extensión para IServiceCollection, utilizado para configurar servicios
        public static IServiceCollection AddInjectionInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            // Se obtiene el nombre completo de la Asamblea (Assembly) que contiene PosContext
            // Esto se utilizará más adelante en la configuración del contexto de la base de datos.
            var assembly = typeof(PosContext).Assembly.FullName;

            // Se agrega el contexto de la base de datos PosContext como servicio
            services.AddDbContext<PosContext>(
                // Configuración del DbContext con SQL Server como proveedor de base de datos
                options => options.UseSqlServer(
                    // Se obtiene la cadena de conexión desde la configuración de la aplicación
                    configuration.GetConnectionString("DefaultConnection"),
                    // Se especifica la Asamblea para las migraciones
                    b => b.MigrationsAssembly(assembly)),
                // Se establece el tiempo de vida del servicio como Transient
                ServiceLifetime.Transient);

            // Se agregan los repositorios como servicios
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Se devuelve el objeto services modificado
            return services;
        }
    }
}
