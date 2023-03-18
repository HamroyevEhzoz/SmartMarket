using Microsoft.Extensions.Configuration;

namespace SmartMarket.WPF.infrastructureLayer.Persistence
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath("C:\\Users\\User\\source\\repos\\e-security\\SmartMarket\\SmartMarket.WPF\\InfrastructureLayer\\Persistence\\AppDbContext");
            builder.AddJsonFile("appsettings.json");
            return builder.Build();
        }
    }
}
