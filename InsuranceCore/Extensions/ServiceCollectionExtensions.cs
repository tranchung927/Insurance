﻿using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using InsuranceCore.Authorization.PermissionHandlers.Attributes;
using InsuranceCore.Authorization.PermissionHandlers.Dtos;
using InsuranceCore.Authorization.PermissionHandlers.Resources;
using InsuranceCore.Builder;
using InsuranceCore.Data;
using InsuranceCore.DataContext;
using InsuranceCore.Models.DTOs.Account;
using InsuranceCore.Models.DTOs.Category;
using InsuranceCore.Models.DTOs.Post;
using InsuranceCore.Models.DTOs.Role;
using InsuranceCore.Models.DTOs.Tag;
using InsuranceCore.Models.Exceptions;
using InsuranceCore.Repositories.Category;
using InsuranceCore.Repositories.Post;
using InsuranceCore.Repositories.Role;
using InsuranceCore.Repositories.Tag;
using InsuranceCore.Repositories.UnitOfWork;
using InsuranceCore.Repositories.User;
using InsuranceCore.Services.CategoryService;
using InsuranceCore.Services.PostService;
using InsuranceCore.Services.RoleService;
using InsuranceCore.Services.TagService;
using InsuranceCore.Services.UrlService;
using InsuranceCore.Services.UserService;
using InsuranceCore.Validators;

namespace InsuranceCore.Extensions
{
    /// <summary> 
    /// Extension of <see cref="IServiceCollection"/> adding methods to inject Insurance Services 
    /// </summary> 
    public static class ServiceCollectionExtensions
    {
        /// <summary> 
        /// class used to Register database provider services 
        /// </summary> 
        /// <param name="services"></param> 
        /// <returns></returns> 
        public static IServiceCollection RegisterDatabaseProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var dbProvider = configuration.GetSection("DatabaseProvider");
            if (!dbProvider.Exists())
                throw new DatabaseProviderException("Database provider is not specified inside the configuration.");
            switch (dbProvider.Value)
            {
                case "MsSQL":
                    services.AddDbContext<InsuranceDbContext, MsSqlDbContext>(o => o.UseSqlServer(
                        configuration.GetConnectionString("Default")));
                    break;

                case "PostgreSQL":
                    services.AddDbContext<InsuranceDbContext, PostgreSqlDbContext>(o => o.UseNpgsql(
                    configuration.GetConnectionString("Default")));
                    break;
                case "HerokuPostgreSQL":
                    var builder = new PostgreSqlConnectionStringBuilder(configuration["DATABASE_URL"])
                    {
                        Pooling = true,
                        TrustServerCertificate = true,
                        SslMode = SslMode.Require
                    };
                    services.AddDbContext<InsuranceDbContext, PostgreSqlDbContext>(o =>
                        o.UseNpgsql(builder.ConnectionString));
                    break;
                default:
                    throw new DatabaseProviderException("Unsupported database provider : " + dbProvider);
            }

            return services;
        }

        /// <summary> 
        /// class used to register identity services 
        /// </summary> 
        /// <param name="services"></param> 
        /// <returns></returns> 
        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
                .AddEntityFrameworkStores<InsuranceDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }
        /// <summary> 
        /// class used to register repository services 
        /// </summary> 
        /// <param name="services"></param> 
        /// <returns></returns> 
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        /// <summary> 
        /// class used to register resource services 
        /// </summary> 
        /// <param name="services"></param> 
        /// <returns></returns> 
        public static IServiceCollection RegisterResourceServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserService, UserService>();
            services.AddHttpClient<IUrlService, UrlService>();
            services.AddScoped<IUrlService, UrlService>();
            return services;
        }

        /// <summary> 
        /// class used to register resource validators
        /// </summary> 
        /// <param name="services"></param> 
        /// <returns></returns> 
        public static IServiceCollection RegisterDtoResourceValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ICategoryDto>, CategoryDtoValidator>();
            services.AddScoped<IValidator<IPostDto>, PostDtoValidator>();
            services.AddScoped<IValidator<IRoleDto>, RoleDtoValidator>();
            services.AddScoped<IValidator<ITagDto>, TagDtoValidator>();
            services.AddScoped<IValidator<IAccountDto>, AccountDtoValidator>();
            return services;
        }

        /// <summary> 
        /// class used to register resource services 
        /// </summary> 
        /// <param name="services"></param> 
        /// <returns></returns> 
        public static IServiceCollection RegisterAuthorizationHandlers(this IServiceCollection services)
        {
            // Resource Handlers
            services.AddScoped<IAuthorizationHandler, HasAllPermissionRangeAuthorizationHandler<Role>>();
            services.AddScoped<IAuthorizationHandler, HasAllPermissionRangeAuthorizationHandler<Tag>>();
            services.AddScoped<IAuthorizationHandler, HasAllPermissionRangeAuthorizationHandler<Category>>();
            services.AddScoped<IAuthorizationHandler, HasOwnOrAllPermissionRangeForHasAuthorEntityAuthorizationHandler<Post>>();
            services.AddScoped<IAuthorizationHandler, HasOwnOrAllPermissionRangeForUserResourceAuthorizationHandler>();

            // DTO Handlers
            services.AddScoped<IAuthorizationHandler, HasOwnOrAllPermissionRangeForHasAuthorDtoAuthorizationHandler<IPostDto>>();

            // Resource Attribute Handler
            services.AddScoped<IAuthorizationHandler, PermissionWithRangeAuthorizationHandler>();

            return services;
        }

        public static IServiceCollection AddAllHttpLoggingInformationAvailable(this IServiceCollection services)
        {
            services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All;
                logging.RequestHeaders.Add(HeaderNames.Accept);
                logging.RequestHeaders.Add(HeaderNames.ContentType);
                logging.RequestHeaders.Add(HeaderNames.ContentDisposition);
                logging.RequestHeaders.Add(HeaderNames.ContentEncoding);
                logging.RequestHeaders.Add(HeaderNames.ContentLength);

                logging.MediaTypeOptions.AddText("application/json");
                logging.MediaTypeOptions.AddText("multipart/form-data");

                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
            });

            return services;
        }
    }
}
