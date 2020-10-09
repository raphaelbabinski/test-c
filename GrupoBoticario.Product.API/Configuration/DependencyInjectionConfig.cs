using GrupoBoticario.Product.Business;
using GrupoBoticario.Product.Business.Interfaces;
using GrupoBoticario.Product.Business.Service;
using GrupoBoticario.Product.Data.Context;
using GrupoBoticario.Product.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoBoticario.Product.API.Controllers
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
