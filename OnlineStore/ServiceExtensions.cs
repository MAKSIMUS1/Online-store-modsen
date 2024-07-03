using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace OnlineStore
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        }
    }
}
