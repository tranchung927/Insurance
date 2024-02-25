﻿using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Server.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection RegisterSwagger(
            this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.UseInlineDefinitionsForEnums();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "InsuranceCore",
                    Description = "Powerful .NET 6 Insurance API",
                    Version = "v1"
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlDocumentationPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
                if (File.Exists(xmlDocumentationPath))
                    c.IncludeXmlComments(xmlDocumentationPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            return services;
        }
    }
}
