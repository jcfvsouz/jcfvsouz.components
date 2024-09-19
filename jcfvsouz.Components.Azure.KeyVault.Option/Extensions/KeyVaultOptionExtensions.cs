using jcfvsouz.Components.Azure.KeyVault.Option.Client;
using jcfvsouz.Components.Cloud.SecretsManager.Option.Configurator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.Azure.KeyVault.Option.Extensions
{
    public static class KeyVaultOptionExtensions
    {
        public static void ConfigureOptionFromKeyVault<T>(this IServiceCollection serviceCollection,
            IConfiguration config) where T : class
        {
            var keyVaultName = config.GetValue<string>("Azure:keyVaultName") ?? string.Empty;
            var secretKey = config.GetValue<string>("Azure:secretKey") ?? string.Empty;

            serviceCollection.ConfigureOptionFromKeyVault<T>(keyVaultName, secretKey);
        }

        public static void ConfigureOptionFromKeyVault<T>(this IServiceCollection serviceCollection,
             string keyVaultName, string secretKey) where T : class
        {
            var configurator = GetConfiguratorInstance(keyVaultName);

            configurator.ConfigureSecretsManagerOption<T>(serviceCollection, secretKey);
        }
        private static SecretsManagerOptionConfigurator GetConfiguratorInstance(string keyVaultName)
        {
            var client = new KeyVaultClient(keyVaultName);

            return new SecretsManagerOptionConfigurator(client);
        }
    }
}
