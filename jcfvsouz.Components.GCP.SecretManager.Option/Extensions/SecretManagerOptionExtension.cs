using jcfvsouz.Components.Cloud.SecretsManager.Option.Configurator;
using jcfvsouz.Components.GCP.SecretManager.Option.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.GCP.SecretManager.Option.Extensions
{
    public static class SecretManagerOptionExtension
    {
        public static void ConfigureOptionFromSecretManager<T>(this IServiceCollection serviceCollection,
            IConfiguration config) where T : class
        {
            var projectId = config.GetValue<string>("GCP:ProjectId") ?? string.Empty;
            var secretId = config.GetValue<string>("GCP:SecretId") ?? string.Empty;
            var secretVersionId = config.GetValue<string>("GCP:SecretVersionId") ?? string.Empty;

            serviceCollection.ConfigureOptionFromSecretManager<T>(projectId, secretId, secretVersionId);
        }

        public static void ConfigureOptionFromSecretManager<T>(this IServiceCollection serviceCollection,
             string projectId, string secretId, string secretVersionId) where T : class
        {
            var configurator = GetConfiguratorInstance(projectId, secretVersionId);

            configurator.ConfigureSecretsManagerOption<T>(serviceCollection, secretId);
        }

        private static SecretsManagerOptionConfigurator GetConfiguratorInstance(string projectId,
            string secretVersionId)
        {
            var client = new SecretManagerClient(projectId, secretVersionId);

            return new SecretsManagerOptionConfigurator(client);
        }
    }
}
