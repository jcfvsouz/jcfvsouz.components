using jcfvsouz.Components.Cloud.SecretsManager.Option.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace jcfvsouz.Components.Cloud.SecretsManager.Option.Configurator
{
    public class SecretsManagerOptionConfigurator(ISecretsManagerClient client)
        : ISecretsManagerOptionConfigurator
    {
        private Dictionary<string, string>? secretValueResponses { get; set; }

        public void ConfigureSecretsManagerOption<T>(IServiceCollection serviceCollection,
            string secretKey) where T : class
        {
            var secretValue = GetSecretValue(secretKey);

            serviceCollection.Configure<T>(options =>
            {
                JsonConvert.PopulateObject(secretValue, options);
            });
        }

        private string GetSecretValue(string secretKey)
        {
            if (secretValueResponses == null) secretValueResponses = new();

            if (secretValueResponses.TryGetValue(secretKey, out var secretValue)) return secretValue;

            secretValue = client.GetSecret(secretKey);
            secretValueResponses.Add(secretKey, secretValue);

            return secretValue;
        }
    }
}
