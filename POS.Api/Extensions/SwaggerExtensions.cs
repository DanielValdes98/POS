using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace POS.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "POS API",
                Version = "v1",
                Description = "API for POS 2024",
                TermsOfService = new Uri("http://opensource.org/licenses/NIT"),
                Contact = new OpenApiContact
                {
                    Name = "Daniel Valdes",
                    Email = "danielvaldes.dev@gmail.com",
                    Url = new Uri("http://localhost:5000")
                },
                License = new OpenApiLicense
                {
                    Name ="Use under LICX",
                    Url = new Uri("http://opensource.org/licenses/NIT")
                }
            };

            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Jwt Authentication",
                    Description = "Jwt Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[]{} }
                });
            });

            return services;
        }
    }
}
