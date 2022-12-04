using GymSystem.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GymSystem.Data
{
    public static class DataModule
    {
        public static IServiceCollection AddGymSystemServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();

            return services;
        }
    }
}