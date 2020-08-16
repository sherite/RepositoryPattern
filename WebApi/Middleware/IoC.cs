namespace WebApi.Middleware
{
    using DataAccess.Generic;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyecta los servicios del repositorio generico
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}