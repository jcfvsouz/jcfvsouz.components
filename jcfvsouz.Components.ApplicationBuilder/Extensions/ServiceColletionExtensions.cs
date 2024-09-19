using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.ApplicationBuilder.Extensions
{
    public static class ServiceColletionExtensions
    {
        public static IConfiguration AddConfiguration(this IServiceCollection serviceCollection,
            string jsonFile = "appsettings.json")
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile(jsonFile, optional: false, reloadOnChange: true)
            .Build();

            serviceCollection.AddScoped((_) => configuration);

            return configuration;
        }
    }
}
