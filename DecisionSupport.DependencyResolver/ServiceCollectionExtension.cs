using DecisionSupport.BL.Algorithms;
using DecisionSupport.BL.Parsing;
using DecisionSupport.BL.Services;
using DecisionSupport.BL.Services.Contracts;
using DecisionSupport.DataAccess.Repositories;
using DecisionSupport.DataAccess.Repositories.Abstract;
using DecisionSupport.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DecisionSupport.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDatabaseFactory, EfDatabaseFactory>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAlternativeRepository, AlternativeRepository>();
            services.AddScoped<IVotingRepository, VotingRepository>();
            services.AddScoped<IVotingResultRepository, VotingResultRepository>();


            services.AddScoped<ICurrentUserAware, CurrentUserAware>();
            services.AddScoped<ISourceParser, XlsxSourceParser>();
            services.AddScoped<IAnalyticHierarchyProcessorProcessor, AnalyticHierarchyProcessor>();
            services.AddScoped<IAlgorithmService, AnaliticHierarchyService>();

            services.AddScoped<IVotingProcessor, VotingProcessor>();
            services.AddScoped<IVotingAlgorithmService, VotingAlgorithmService>();
        }
    }
}
