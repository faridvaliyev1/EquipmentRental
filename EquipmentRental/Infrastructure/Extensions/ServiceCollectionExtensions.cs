using EquipmentRental.Infrastructure.Filters;
using EquipmentRental.Data;
using EquipmentRental.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EquipmentRental;

namespace Catstagram.Server.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });

            return services;
        }
        public static IServiceCollection Addidentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            })
               .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

            
        public static void AddApiControllers(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add<ModelOrNotFoundActionFilter>());
        }

    }
}
