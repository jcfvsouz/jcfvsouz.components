using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using jcfvsouz.Components.Cloud.SecretsManager.Option.Interfaces;

namespace jcfvsouz.Components.Azure.KeyVault.Option.Client
{
    public class KeyVaultClient(string keyVaultName) : ISecretsManagerClient
    {
        public string GetSecret(string secretKey)
        {
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            var secret = client.GetSecret(secretKey);

            return secret?.Value?.Value ?? string.Empty;
        }
    }
}