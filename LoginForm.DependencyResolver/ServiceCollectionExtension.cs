using LoginForm.BL.Algorithms;
using LoginForm.BL.Parsing;
using LoginForm.BL.Services;
using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Repositories;
using LoginForm.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoginForm.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICurrentUserAware, CurrentUserAware>();
            services.AddScoped<ISourceParser, XlsxSourceParser>();
            services.AddScoped<IAlgorithmProcessor, AnalyticHierarchyProcessor>();
            services.AddScoped<IAlgorithmService, AnaliticHierarchyService>();
        }
    }
}
