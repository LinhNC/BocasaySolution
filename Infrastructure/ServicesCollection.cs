using Application.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure
{
    public static class ServicesCollection
    {
        /// <summary>
        /// Services Collection for Infrastructure Layer
        /// </summary>
        /// <param name="services">Services</param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IPersonService, PersonService>();
            return services;
        }
    }
}
