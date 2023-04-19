using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleCore.CommandHandler;
using ScheduleCore.Entities;
using ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCore.Extension
{
    public static class Register
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection servicecollection, string connectionString)
        {
            var serviceCollection = servicecollection.AddDbContext<ScheduleDbContext>()
                .AddSqlServer<ScheduleDbContext> (connectionString);
                
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
        }

        public static void SeedDatabase(IServiceScope scope)
        {
            var serviceSeeder = scope.ServiceProvider.GetService<ScheduleSeeder>();
            if (serviceSeeder != null)  serviceSeeder.Seed();
        }

    }
}
