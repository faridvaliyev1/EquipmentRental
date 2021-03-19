using Microsoft.Extensions.Configuration;

namespace EquipmentRental.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string getDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("default");
    }
}
