using jcfvsouz.Components.AWS.SecretsManager.Option.Client;
using jcfvsouz.Components.Cloud.SecretsManager.Option.Configurator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.AWS.SecretsManager.Option.Extensions
{
    public static class SecretManagerOptionExtensions
    {


        public static void ConfigureOptionFromSecretsManager<T>(this IServiceCollection serviceCollection,
            IConfiguration config) where T : class
        {
            var awsRegion = config.GetValue<string>("AWS:Region") ?? string.Empty;
            var awsSecretId = config.GetValue<string>("AWS:SecretId") ?? string.Empty;

            serviceCollection.ConfigureOptionFromSecretsManager<T>(awsRegion, awsSecretId);
        }

        public static void ConfigureOptionFromSecretsManager<T>(this IServiceCollection serviceCollection,
             string awsRegion, string secretId) where T : class
        {
            var configurator = GetConfiguratorInstance(awsRegion);

            configurator.ConfigureSecretsManagerOption<T>(serviceCollection, secretId);
        }
        private static SecretsManagerOptionConfigurator GetConfiguratorInstance(string awsRegion)
        {
            var client = new SecretManagerClient(awsRegion);

            return new SecretsManagerOptionConfigurator(client);
        }
    }
}
