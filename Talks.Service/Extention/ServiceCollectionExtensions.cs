using Microsoft.Extensions.DependencyInjection;
using Talks.Data.Extention;

namespace Talks.Service.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceDependencies(
           this IServiceCollection services)
        {
            services.AddDataDependencies();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ITalkService, TalkService>();
            return services;
        }
    }
}
