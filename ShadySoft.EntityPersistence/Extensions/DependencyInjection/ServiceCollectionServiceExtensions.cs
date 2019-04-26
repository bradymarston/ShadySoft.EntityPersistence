using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ShadySoft.EntityPersistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence<TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> contextOptions)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>(contextOptions);
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();

            return services;
        }

        public static IServiceCollection AddDefaultRepository<TEntity, TContext>(this IServiceCollection services)
            where TEntity : class
            where TContext : DbContext
        {
            return services.AddRepository<TEntity, Repository<TEntity, TContext>>();
        }

        public static IServiceCollection AddRepository<TEntity, TRepository>(this IServiceCollection services)
            where TEntity : class
            where TRepository : class, IRepository<TEntity>
        {
            services.AddScoped<TRepository>();
            services.AddScoped<IRepository<TEntity>, TRepository>();
            services.AddFindEntityFilter<TEntity>();
            return services;
        }

        private static IServiceCollection AddFindEntityFilter<TEntity>(this IServiceCollection services)
            where TEntity : class
        {
            return services.AddScoped<FindEntityFilter<TEntity>>();
        }
    }
}