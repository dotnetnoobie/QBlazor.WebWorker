using Microsoft.Extensions.DependencyInjection;
using QBlazor.WebWorker;

namespace QBlazor
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddQBlazorWebWorker(this IServiceCollection services)
        {
            services.AddScoped<IWorker, Worker>();

            return services;
        }
    }
}