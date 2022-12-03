namespace GymSystem.API
{
    using GymSystem.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(optionsAction: o => o.UseSqlServer(configuration["ConnectionStrings:DefaultConnectionString"]));
            return services;
        }
    }
}