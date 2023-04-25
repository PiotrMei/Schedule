using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleCore.CommandHandler;
using ScheduleCore.Entities;
using ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration;
using ScheduleCore.QueryHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCore.Extension
{
    public static class Register
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection servicecollection, string? connectionString)
        {
            var serviceCollection = servicecollection.AddDbContext<ScheduleDbContext>(options => options.UseSqlServer(connectionString));
                       
            return serviceCollection;

        }
        public static IServiceCollection RegisterMediatR(this IServiceCollection servicecollection)
        {
            //var serviceCollection = servicecollection.AddMediatR(Assembly.GetExecutingAssembly());
            var serviceCollection = servicecollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return serviceCollection;   
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection servicecollection)
        {
            // var serviceCollection = servicecollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var serviceCollection = servicecollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            return serviceCollection;

        }

        public static IServiceCollection RegisterSeeder(this IServiceCollection servicecollection)
        {
            var serviceCollection = servicecollection.AddScoped<ScheduleSeeder>();
            return serviceCollection;

        }

        public static IServiceCollection RegisterValidator(this IServiceCollection servicecollection)
        {
            var serviceCollection = servicecollection.AddScoped<ITermsValidator, TermValidator>();
            return serviceCollection;

        }

        public static async Task MigrateAsyncDatabase(IServiceScope scope, CancellationToken ct)
        {
            var dbContext = scope.ServiceProvider.GetService<ScheduleDbContext>();
            await dbContext!.Database.MigrateAsync(ct);
            dbContext.SaveChanges();
        }

        public static void SeedDatabase(IServiceScope scope)
        {
            var serviceSeeder = scope.ServiceProvider.GetService<ScheduleSeeder>();
            if (serviceSeeder != null)  serviceSeeder.Seed();
        }

    }
}
