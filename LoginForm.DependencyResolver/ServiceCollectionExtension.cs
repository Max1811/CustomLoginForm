﻿using LoginForm.BL.Algorithms;
using LoginForm.BL.Parsing;
using LoginForm.BL.Services;
using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Repositories;
using LoginForm.DataAccess.Repositories.Abstract;
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
