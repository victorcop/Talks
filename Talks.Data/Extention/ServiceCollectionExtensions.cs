﻿using Microsoft.Extensions.DependencyInjection;
using Talks.Data.Repositories;

namespace Talks.Data.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataDependencies(
           this IServiceCollection services)
        {
            services.AddSingleton<ITalkRepository, InMemoryTalkRepository>();
            return services;
        }
    }
}
