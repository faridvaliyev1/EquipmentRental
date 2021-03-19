using EquipmentRental.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRental.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder applicationBuilder)
        {
            using var services = applicationBuilder.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
